import sys
sys.path.append("C:\\Program Files\\FreeCAD 0.19\\bin")

import FreeCAD
import FreeCADGui
FreeCADGui.setupWithoutGUI()
import Part
import ImportGui

print (FreeCAD.listDocuments())

test = FreeCAD.newDocument("testDoc")

ImportGui.insert("C:\\temp\\JMA(KAE-10D).STEP",test.Name)
ImportGui.insert("C:\\temp\\stift.STEP",test.Name)

doc = FreeCAD.ActiveDocument
objs = FreeCAD.ActiveDocument.Objects

print("objects before cutting")
print("----------------------")
for obj in objs:
    a = obj.Name
    b = obj.Label
    try:
        c = obj.LabelText
        print(a +" "+ (b) +" "+ (c) + "\n")
    except:
        print((a) +" "+ (b) + "\n")
print("----------------------")

myObj = objs[1]
pl = FreeCAD.Placement()
pl.move(FreeCAD.Vector(-2.6, -8, 10))
myObj.Placement = pl

cut = App.ActiveDocument.addObject("Part::Cut","Cut")
cut.Base = objs[0]
cut.Tool = objs[1]

App.ActiveDocument.recompute()

print("objects after cutting")
print("----------------------")
objs = FreeCAD.ActiveDocument.Objects
for obj in objs:
    a = obj.Name
    b = obj.Label
    try:
        c = obj.LabelText
        print(a +" "+ (b) +" "+ (c) + "\n")
    except:
        print((a) +" "+ (b) + "\n")

print("----------------------")

_objs = []
_objs.append(FreeCAD.getDocument(test.Name).getObject("Cut"))
ImportGui.export(_objs,"C:\\temp\\testExport.STEP")
