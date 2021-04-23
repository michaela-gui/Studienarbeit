FREECADPATH = 'C:\\Program Files\\FreeCAD 0.19\\bin'
FREECADGUIPATH = 'C:\\Program Files\\FreeCAD 0.19\\bin'
#FREECADCMDPATH = 'C:/Program Files/FreeCAD 0.19/bin/'
QTGUIPATH = 'C:\\Data\\Python\\Python38\\Lib\\site-packages\\qtgui'
PYSIDE2PATH = 'C:\\Data\\Python\\Python38\\Lib\\site-packages\\PySide2'
PYSIDEPATH = 'C:\\Data\\Python\\Python38\\Lib\\site-packages\\PySide'
PYQT5PATH = 'C:\\Data\\Python\\Python38\\Lib\\site-packages'#\\PyQt5\\Qt5\\bin'


import sys
sys.path.append(FREECADPATH)
sys.path.append(FREECADGUIPATH)
#sys.path.append(FREECADCMDPATH)
sys.path.append(QTGUIPATH)
#sys.path.append(PYSIDE2PATH)
#sys.path.append(PYSIDEPATH)
sys.path.append(PYQT5PATH)

import FreeCAD
import FreeCADGui
#import FreeCADCmd
#from PySide2 import QtGui
#from PySide import QtGui
import math
import os
import PyQt5
import PyQt5.QtWidgets as QtWidgets
import PyQt5.QtGui as QtGui
import PyQt5.QtCore as QtCore
#from PyQt5.QtWidgets import *
#from PyQt5.QtGui import *
#from PyQt5.QtCore import *
from tkinter import *
import Part
#import ImportGui

def function():
    with open('C:/Program Files/FreeCAD 0.19/data/Mod/Start/StartPage/LoadMRU.py') as file:
        exec(file.read())
    #doc = FreeCAD.newDocument()
    #objects = doc.addObject("Part::Box", "myBox")

    #doc.recompute()
    FreeCAD.openDocument('C:/Users/mfle/AppData/Roaming/FreeCAD/Macro/TestPythonSkripting')
    Gui.ActiveDocument = Gui.getDocument("TestPythonSkripting")

def show():
    QtGui.QMessageBox.information(None, "Appollo program", "Houston")

def test():
    part = FreeCAD.ActiveDocument.getObject(Part)

    if FreeCAD.GuiUp:
        part.ViewObject.Visibility = isVisible
        
def callWindow():
    root = Tk()
    
    welcome = Label()
    welcome["text"] = "Herzlich Willkommen"
    welcome.pack(side="top")
    entry = Entry()
    entry.pack()
    QUIT = Button()
    QUIT["text"] = "Schliessen"
    QUIT["fg"] = "red"
    QUIT["command"] = quit
    QUIT.pack({"side": "left"})
    submit = Button()
    submit["text"] = "Abschicken",
    submit["command"] = quit
    submit.pack({"side": "left"})
    app.mainloop()
    root.destroy()
    logo = PhotoImage(file="C:/Users/mfle/Documents/GitHub/Studienarbeit/Studienarbeit/Bilder/Gluehlampe_Paulmann_E27.jpg")
    w1 = Label(root, image=logo).pack(side="right",
                                     explanation = """Herzlich Willkommen im Handarbeitsübersetzer""")
    w2 = Label(root, 
               justify=LEFT,
               padx = 10, 
               text=explanation).pack(side="left")
    root.mainLoop()
        
def main():
    import Draft
    #myDocument = "C:/Users/mfle/AppData/Roaming/FreeCAD/Macro/TestPythonSkripting"
    doc = FreeCAD.openDocument('C:/Users/mfle/AppData/Roaming/FreeCAD/Macro/TestPythonSkripting.FCStd')
    objects = doc.Objects
    #for ob in objects:
    #    print(ob)
    App.setActiveDocument("TestPythonSkripting")
    App.ActiveDocument=App.getDocument("TestPythonSkripting")
    #FreeCADGui.showMainWindow()
    #Gui.ActiveDocument=Gui.getDocument("TestPythonSkripting")
    #Gui.runCommand('Std_OrthographicCamera',1)
    #Gui.showMainWindow() #um das FreeCAD Programm zu öffnen
    #build()

    #doc = App.newDocument()
    #box = doc.addObject("Part::Box", "myBox")
    #doc.recompute()
    #Gui.exec_loop()
    #Gui.showMainWindow()

    fn = 'C:\\Users\\mfle\\Documents\\GitHub\\Studienarbeit\\Studienarbeit\\ErstelleRectangle.FCMacro'
    #macro = open(fn).read()
    #exec(macro)
    #FreeCADGui.showMainWindow()
    #mw=FreeCADGui.getMainWindow()
    #mw.hide()

    QtGui.QGuiApplication(["Hallo"])

    #root = Tk()
    #welcome = Image()
    #welcome = Image.PhotoImage(Image.open(FreeCAD.ActiveDocument))
    #panel = Tk.Label(root, image = img)
    #panel.pack(side = "bottom", fill="both", expand="yes")
    #app.mainloop()
    



if __name__=='__main__':
    main()
