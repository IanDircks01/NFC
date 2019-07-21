import serial
import io

def beep():
    ser = serial.Serial()
    ser.port = 'COM4'
    ser.baudrate = 9600
    ser.open()
    buffer = bytearray([0x02,0x13,0x15])
    print(buffer)
    ser.write(buffer)
    ser.close()

while True:
    command = input("Command:")
    if command == "beep":
        beep()
        command = ""
    elif command == "exit":
        print("Exiting...")
        break
    else:
        print("Command error! Invalid command!")

