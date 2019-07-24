import serial
import io

ser = serial.Serial()

def serialOpen():
    ser.port = 'COM4'
    ser.baudrate = 9600
    ser.open()

def beep():
    serialOpen()
    buffer = bytearray([0x02,0x13,0x15])
    print(buffer)
    ser.write(buffer)
    print(ser.read(size=len(buffer)))
    ser.close()

def cardcheck():
    serialOpen()
    buffer = bytearray([0x03,0x02,0x00,0x05])
    print(buffer)
    ser.write(buffer)
    print(ser.read(size=4))
    ser.close()

def serialnumber():
    serialOpen()
    buffer = bytearray([0x02,0x03,0x05])
    print(buffer)
    ser.write(buffer)
    print(ser.read(size=4))
    ser.close()

def test():
    serialOpen()
    #Select Card
    buffer = bytearray([0x02,0x04,0x06])
    ser.write(buffer)
    print(ser.read(size=3))
    #Verify Key
    buffer = bytearray([0x04,0x05,0x01,0x03,0x0A])
    ser.write(buffer)
    print(ser.read(size=3))
    #Write data to Sector 1, Block 0
    buffer = bytearray([0x13,0x07,0x04,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x11,0x2E])
    ser.write(buffer)
    print(ser.read(size=3))
    ser.write(bytearray([0x02,0x13,0x15]))
    ser.close()

while True:
    command = input("Command:")
    if command == "beep":
        beep()
        command = ""
    elif command == "cardcheck":
        cardcheck()
    elif command == "serialnumber":
        serialnumber()
    elif command =="test":
        test()
    elif command == "exit":
        print("Exiting...")
        break
    else:
        print("Command error! Invalid command!")