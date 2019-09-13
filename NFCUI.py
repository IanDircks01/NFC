#Imports
import tkinter as tk
from tkinter import messagebox
import pygubu
import NFC
import CardSectorData

# Define the function callbacks
def on_button1_click():
    messagebox.showinfo('Message', 'You clicked Button 1')

def on_button2_click():
    messagebox.showinfo('Message', 'You clicked Button 2')

def on_button3_click():
    messagebox.showinfo('Message', 'You clicked Button 3')

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
            'on_button1_clicked': on_button1_click,
            'on_button2_clicked': on_button2_click,
            'on_button3_clicked': on_button3_click
        }

        builder.connect_callbacks(callbacks)

#UI run loop
if __name__ == '__main__':
    root = tk.Tk()
    app = Application(root)
    root.mainloop()
