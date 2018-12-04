# Remote-Desktop-Viewer
A simple C# .NET tool that allows th user to view to screen of another computer.
## The Server Program
The server program is the program you want to run on YOUR computer, not the one you want to connect to. When the windows pops up, 
enter the port you would like to listen on, ex: 1717. Then click listen. A window will pop up, it will have a grey background until
you connect from the client computer. After that, then the window will be displaying the client computer's screen.

## The Client Program
The client is the program that you run on the computer you want to
see the screen of. On the client computer, fire up the program. In the 'IP' boax, put the IP Adress of the server computer,
ex: 192.168.0.0, then enter the port you put in on your server computer, ex: 1717. After that click connect and a box should 
pop up and let you know that you connected. Then click 'Share Screen'. You can end this connection at any time.

## How to Use _Light Mode_ and _Dark Mode_ 
In the bottom left of the both the Server window and the Client window, there is a button labeled *Light Mode*. When you click this button the color scheme will change to the *Light Mode* scheme and the button will be *Dark Mode*. When you click that button, the window will go back to the default *Dark Mode* and the button will say *Light Mode* Again.

## System Reqirements
This program will run on any 64 or 32 bit windows 7/8/8.1/10 System
