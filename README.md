# Formula AllCode Demo
A streamlined and simplified way of interacting with the Formula AllCode robots from [Matrix TSL](https://www.matrixtsl.com/).  
Used for the [College of West Anglia](https://cwa.ac.uk/) Staff Conference on the 31st of March 2023.  
## Available Commands
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
Adapted from 'Formula AllCode C# VS2015'
