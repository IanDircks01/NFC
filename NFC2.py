#Update this to prevent code from auto converting certain hex to ascii (example is serial numer/anticollision)

import serial
import io
import time
import CardSectors

ser = serial.Serial()

NFCProt = {
    "beep": b'\x02\x13\x15',
    "anticollision": b'\x02\x03\x05',
    "card-check": b'\x03\x02\x00\x05',
    "card-found": b'\x03\x02\x01\x06',
    "no-card-found": b'\x02\x01\x03',
    "manufacture-data": b'\x0A\x05\x00\x03\xFF\xFF\xFF\xFF\xFF\xFF\x0C'
}

def serialOpen():
    ser.port = 'COM4'
    ser.baudrate = 9600
    ser.open()

def beep():
    ser.write(NFCProt["beep"])
    time.sleep(0.25)

def cardCheck():
    ser.write(NFCProt["card-check"])
    check = ser.read(3)
    if check == NFCProt["no-card-found"]:
        print("No Card Found. Aborting...")
        ser.close()
    else:
        print("Card Found")
        time.sleep(0.25)

def anticollision():
    serialOpen()
    cardCheck()
    ser.write(NFCProt["anticollision"])
    time.sleep(0.25)
    resp = ser.read(8)
    print(resp[3:])
    beep()
    ser.close()

def manufacture():
    serialOpen()
    cardCheck()
    ser.write(b'\x03\x0A\x00\x0D')
    ser.read(8)
    time.sleep(0.25)
    ser.write(NFCProt["manufacture-data"])
    ser.read(3)
    time.sleep(0.25)
    ser.write(b'\x03\x06\x00\x09')
    resp = ser.read(19)
    print(resp[3:])
    beep()
    ser.close()

def readsector(sector=None,block=None):
    #Sector and Block Pick
    sectorChoose = CardSectors.sec[sector]
    blockChoose = CardSectors.secblock[sector]
    blockIDEnding = CardSectors.secreadend
    blockIDMid = CardSectors.secreadstart
    byteread = bytearray()
    bytereadend1 = bytearray([0x0A,0x05])
    bytereadend2 = bytearray([0x03,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF])
    bytereadend = bytearray()
    
    #byteread
    byteread.extend('\x03\x06'.encode('utf-8'))
    byteread.extend(sectorChoose[block].encode('utf-8'))
    byteread.extend(blockChoose[block].encode('utf-8'))
    
    #bytereadend1
    bytereadend1.extend(blockIDMid[sector].encode('utf-8'))
    
    #bytereadend2
    bytereadend2.extend(blockIDEnding[sector].encode('utf-8'))

    #bytereadend
    bytereadend.extend(bytereadend1)
    bytereadend.extend(bytereadend2)

    #Beginning of card read
    serialOpen()
    cardCheck()
    ser.write(b'\x03\x0A\x00\x0D')
    ser.read(8)
    time.sleep(0.25)
    ser.write(bytereadend)
    ser.read(3)
    time.sleep(0.25)
    ser.write(byteread)
    resp = ser.read(19)
    print(resp[3:])
    beep()
    ser.close()

#Console CMD Runner
print("WARNING: Not all data shown in console is accurate due to python automatically converting some hex data")
while True:
    command = input("Command:")
    if command == "beep":
        beep()
    elif command == "anticollision":
        anticollision()
    elif command == "manufacture":
        manufacture()
    elif command == "sectorread":
        sect = input("Sector:")
        block = input("Block:")
        readsector(int(sect),int(block)) 
    elif command == "exit":
        print("Exiting...")
        break
    else:
        print("Command error! Invalid command!")