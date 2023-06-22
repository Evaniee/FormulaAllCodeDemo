# Formula AllCode Demo
A streamlined and simplified way of interacting with the Formula AllCode robots from [Matrix TSL](https://www.matrixtsl.com/).   
## Setup (For Windows 10)  
1. Ensure Bluetooth is turned on.  
	* Search for 'Bluetooth' in the start menu search bar and select 'Bluetooth & other devices settings'  
3. Switch the robot on, a blue LED should show.  
4. Select the device from the list of devices.  
	* Sometimes the devices will show as 'Unknown Device'. Try and select one and it will tell you the name of the device, check it matches with the name on the robot's screen.  
	* If you are asked for a code enter the default code of 1234.  
5. Find the COM port(s) the robot is using to communicate.  
	* There are many ways to do this:  
		1. If you are quick you can select the pop-up in the bottom right that appears when the device is ready.  
		2. If not you can go into the 'Control Panel' then 'Hardware and Sound' then 'Devices and Printers'
			* You can then find the device that you are paired with, double click it and go to 'Services'. Here you will see which ports your device is using.
		3. If none of the previous options worked search for 'cmd' in the start menu search bar and enter `rundll32.exe shell32.dll,Control_RunDLL bthprops.cpl,,2 `
	* You should be able to find the outgoing port using one of these methods. Keep a note of it for the next step.
6. Now you have your outgoing port number you can run the program normally and enter your port number when asked. You should hear a noise from the robot and a message saying you have been placed in Manual mode and can move around using the WASD or arrow keys.
	* If you want to skip entering this in every time you run the program enter your port number inside the brackets in the line that says `Setup();`.
## Available Commands
### Required:
* Setup
	* Setup the robot to accept commands.
	* You can Setup the robot using the following commands:
		* `Setup();`
			* Requests Port Number from user via console to use for communication
		* `Setup(port);`
			* Use the port given as parameter for communication
		* `Setup(port, silent)`;
			* Use the port given as parameter for communication, will launch without a sound if 'silent' is 'true'
* Shutdown
	* Stop the robot receiving commands.
	* You can stop the robot receving commands using `Shutdown();`
### Special Modes
* Manual  
  * Control the Robot using WASD or the arrow keys until the Escape key is pressed.  
  * Manual mode can be accessed by the command `Manual();`  
* Drag Strip  
  * Make the robot move forward at any speed for a given time.  
  * You can individually control the left and right motors, or have both motors move at the same speed.  
  * Drag Strip mode can be accessed using any of the following commands:  
    * `DragStrip();`  
    * `DragStrip(time, speed);`  
      * Where 'time' is how long you want to move for and 'speed' is the speed you want to move at.  
    * `DragStrip(time, leftSpeed, rightSpeed);`  
      * Where 'time' is how long you want to move for, 'leftSpeed' is the speed you want the left motor to move at and 'rightSpeed' is the speed you want the right motor to move at.  
### Movement:  
* Forward  
  * You can move forward using any of the following commands:  
    * `Forward();`  
      * Will move you forward slightly.  
    * `Forward(distance);`  
      * Will move you forward the given distance.  
* Backward
  * You can move backwards using any of the following commands:  
    * `Backward();`  
      * Will move you backwards slightly.  
    * `Backward(distance);`  
      * Will move you backward the given distance.  
* Left  
  * You can move left using any of the following commands:  
    * `Left();`  
      * Will move you left 45 degrees.  
    * `Left(angle)`  
      * Will move you left by the given angle.  
* Right 
  * You can move right using any of the following commands:  
    * `Right();`  
      * Will move you right 45 degrees.  
    * `Right(angle)`  
      * Will move you right by the given angle.  
## Resources used  
Setup Methodology From: [Formula AllCode Robotics Course](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&ved=2ahUKEwi8iN_u9_z9AhWSQ0EAHbhlDUoQFnoECBcQAQ&url=https%3A%2F%2Fwww.matrixtsl.com%2Fresources%2Fgetresource.php%3Fid%3D950&usg=AOvVaw0NPuWYiCmg6-O7ltyILys8) (Download)  
Code Adapted From: [FA_C#_Formula AllCode C# VS2015](https://www.matrixtsl.com/allcode/resources/)
