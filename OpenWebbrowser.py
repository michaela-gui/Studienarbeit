from tkinter import *
import webbrowser

def callback(url):
    webbrowser.open_new(url)

def myFunction():
    root = Tk()
    link1 = Label(root, text="Google Hyperlink", fg="blue", cursor="hand2")
    link1.pack()
    link1.bind("<Button-1>", lambda e: callback("http://www.google.com"))

    link2 = Label(root, text="Ecosia Hyperlink", fg="blue", cursor="hand2")
    link2.pack()
    link2.bind("<Button-1>", lambda e: callback("http://www.ecosia.org"))

    root.mainloop()

import time
from QtGui.QtWebKitWidgets import QtWebKit

class View(QtWebKit.QWebView):
    def __init__(self, *args, **kwargs):
        super(View, self).__init__(*args, **kwargs)
        self.completed = True
        self.loadFinished.connect(self.setCompleted)

    def setCompleted(self):
        self.completed = True

    def setUrl(self, url):
        self.completed = False
        super(View, self).setUrl(url)
        while not self.completed:
            time.sleep(0.2)



def main():
    view = View(None)
    view.setUrl(QtCore.QUrl("http://www.google.com/"))
    frame = view.page().mainFrame()
    print(frame.toHtml())


if __name__=='__main__':
    main()
