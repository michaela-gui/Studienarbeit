WEB8 = 'C:\\Data\\Python\\Python38\\Lib\\site-packages\\tkinterweb\\'
WEB9 = 'C:\\Data\\Python\\Python39\\Lib\\site-packages\\tkinterweb\\'
WEB_PIL = 'C:\\Data\\Python\\Python38\\Lib\\site-packages\\PIL'

import sys
sys.path.append(WEB8)
sys.path.append(WEB9)
sys.path.append(WEB_PIL)

#link = "http://www.somesite.com/details.pl?urn=2344"
link2 = "https://www.roomle.com/t/planner?mode=3D&id=bpf7gyjw1vw3jsl1svtlfsa9dnvyxra&shared=1"
#from urllib.request import urlopen

import tkinter as tk
import pil
from bindings import TkinterWeb

root = tk.Tk()
frame = HtmlFrame.HtmlFrame(root)
frame.load_website(link2)
frame.pack(fill="both", expand=True)
root.mainloop()
