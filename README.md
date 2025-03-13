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
## Resources used  
Setup Methodology From: [Formula AllCode Robotics Course](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&ved=2ahUKEwi8iN_u9_z9AhWSQ0EAHbhlDUoQFnoECBcQAQ&url=https%3A%2F%2Fwww.matrixtsl.com%2Fresources%2Fgetresource.php%3Fid%3D950&usg=AOvVaw0NPuWYiCmg6-O7ltyILys8) (Download)  
Code Adapted From: [FA_C#_Formula AllCode C# VS2015](https://www.matrixtsl.com/allcode/resources/)
