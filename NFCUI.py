#Imports
import tkinter as tk
from tkinter import messagebox
import pygubu
#import NFC
import CardSectorData

# Define the function callbacks
def HexRead():
    messagebox.showinfo('Hex Read', 'You clicked Button 1')

#Application Class
class Application:
    def __init__(self, master):

        #1: Create a builder
        self.builder = builder = pygubu.Builder()

        #2: Load an ui file
        builder.add_from_file('NFC.ui')

        #3: Create the widget using a master as parent
        self.mainwindow = builder.get_object('Body', master)

        #Configure Callbacks
        callbacks = {
            'HexBtnRead': HexRead
        }

        builder.connect_callbacks(callbacks)

#UI run loop
if __name__ == '__main__':
    root = tk.Tk()
    root.title("NFCPy Read/Write")
    app = Application(root)
    root.mainloop()
