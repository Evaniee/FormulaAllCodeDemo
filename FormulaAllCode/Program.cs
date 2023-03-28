using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace FormulaAllCode
{
    class Program
    {
        /*
         *  Commands:
         *      Required:
         *          Setup();                                    - Setup the robot to recieve commands
         *              Setup(port);                            - Setup the robot to recieve commands on a given port
         *              Setup(port, silent);                    - Setup the robot to recieve commands on a given port using silent mode if 'silent' is 'true' otherwise must be 'false'
         *          Shutdown();                                 - Stop the robot recieving commands
         *      Special Modes:
         *          Manual();                                   - Contol the robot using WASD or arrow keys
         *          DragStrip();                                - Make the robot move forward at any speed, individual motor control is possible, moves on spacebar press
         *              DragStrip(time, speed)                  - Make the robot move forward at the listed speed for listed time
         *              DragStrip(time, leftSpeed, rightSpeed)  - Make the robot move forward at the listed speed for listed time
         *      Movement:
         *          Forward();                                  - Make the robot move forward
         *              Forward(distance);                      - Make the robot move forward a given distance
         *          Backward();                                 - Make the robot move backward
         *              Backward(distance);                     - Make the robot move backward a given distance
         *          Left();                                     - Make the robot turn 45 degrees left
         *              Left(angle);                            - Make the robot turn left by given angle
         *          Right();                                    - Make the robot turn 45 degrees right
         *              Right(angle);                           - Make the robot turn right by a given angle
         */

        static void Main(string[] args)
        {
            Setup();        // You need this to make your robot start. If you know your port number you can enter it inside the brackets.

            // Your code starts below here!

            Manual();       // You can replace me too!

            // And ends above here!
            Shutdown();     // You need this to stop the robot without turning it off. (If it all goes correct, sometimes you need to hit the physical power button.)
        }

        #region You can ignore all this below unless you're interested in the details

        #region Variables
        static char port;                     // port number for bluetooth communication
        static readonly byte MAX_SPEED = 100;       // Maximum speed the robot can move at
        static readonly uint MAX_TIME = 10_000;     // Maximum time the robot can move for
        #endregion

        #region Special Modes
        /// <summary>
        /// Allow the user to manually move the robot using WASD or arrow keys
        /// </summary>
        static void Manual()
        {
            Console.Write("Entering Manual Mode. Press \'Escape\' to exit: ");
            bool loop = true;
            while (loop)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Forward();
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Backward();
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Left();
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Right();
                        break;
                    case ConsoleKey.Escape:
                        loop = false;
                        Console.WriteLine("Esc");
                        break;
                }
            }
        }

        /// <summary>
        /// Move the robot forward at a given speed for a given time
        /// </summary>
        static void DragStrip()
        {
            // Ask user if they want seperate motor speeds
            Console.WriteLine("Do you want both motors at the same speed?: ");
            byte leftSpeed = 0;
            byte rightSpeed = 0;
            bool loop = true;
            while (loop)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        leftSpeed = GetSpeed("left");
                        rightSpeed = GetSpeed("right");
                        loop = false;
                        break;
                    case ConsoleKey.Y:
                        leftSpeed = GetSpeed("motor");
                        rightSpeed = leftSpeed;
                        loop = false;
                        break;
                }
            }

            // Get the distance the User wants to travel
            uint time;
            Console.Write("Enter time to move (Max {0}): ", MAX_TIME);
            while (!uint.TryParse(Console.ReadLine(), out time) || time > MAX_TIME)
                Console.WriteLine("Retry with a valid distance (0 - {0}).", MAX_TIME);
            Console.WriteLine("Distance Set to {0}", time);

            // Hold until spacebar press
            Console.WriteLine("Press Spacebar to go");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) ;

            DragStrip(time, leftSpeed, rightSpeed);
        }

        /// <summary>
        /// Move the robot forward at a given speed for a given time
        /// </summary>
        /// <param name="time">Time to move for</param>
        /// <param name="speed">Speed to move at</param>
        static void DragStrip(uint time, int speed)
        {
            DragStrip(time, speed, speed);
        }

        /// <summary>
        /// Move the robot forward at a given speed for a given time
        /// </summary>
        /// <param name="time">Time to move for</param>
        /// <param name="leftSpeed">Speed to move left</param>
        /// <param name="rightSpeed">Speed to move right</param>
        static void DragStrip(uint time, int leftSpeed, int rightSpeed)
        {
            FA_DLL.FA_SetMotors(port, leftSpeed, rightSpeed);
            Thread.Sleep((int)time);
            FA_DLL.FA_SetMotors(port, 0, 0);
        }
        #endregion

        #region General
        /// <summary>
        /// Setup the robot to accept commands
        /// </summary>
        private static void Setup()
        {
            // Get User's port number via input
            Console.Write("What is your port number: ");
            byte port;
            while (!byte.TryParse(Console.ReadLine(), out port))
                Console.WriteLine("Retry with a valid port number.");
            Setup(port);
        }

        /// <summary>
        /// Setup the robot to accept commands
        /// </summary>
        /// <param name="portNumber">The number of the robot's port</param>
        private static void Setup(int portNumber)
        {
            port = (char)portNumber;

            // Open port
            FA_DLL.FA_ComOpen(port);

            // Short noise to inform user the robot is online
            FA_DLL.FA_PlayNote(port, 500, 100);
            FA_DLL.FA_PlayNote(port, 100, 100);
            FA_DLL.FA_PlayNote(port, 600, 100);
        }

        /// <summary>
        /// Setup the robot to accept commands
        /// </summary>
        /// <param name="portNumber">The number of the robot's port</param>
        /// <param name="silent">Does the robot play a noise on startup</param>
        private static void Setup(int portNumber, bool silent)
        {
            port = (char)portNumber;

            // Open port
            FA_DLL.FA_ComOpen(port);

            // Short noise to inform user the robot is online if not silent
            if (!silent)
            {
                FA_DLL.FA_PlayNote(port, 500, 100);
                FA_DLL.FA_PlayNote(port, 100, 100);
                FA_DLL.FA_PlayNote(port, 600, 100);
            }
        }

        /// <summary>
        /// Shutdown the robot
        /// </summary>
        private static void Shutdown()
        {
            FA_DLL.FA_ComClose(port);
        }
        #endregion

        #region Movement
        /// <summary>
        /// Make the Robot move forwards
        /// </summary>
        private static void Forward()
        {
            Forward(100);
        }

        /// <summary>
        /// Make the Robot move forwards
        /// </summary>
        /// <param name="distance">Distance to move forwards</param>
        private static void Forward(uint distance)
        {
            FA_DLL.FA_Forwards(port, distance);
        }

        /// <summary>
        /// Make the Robot move backwards
        /// </summary>
        private static void Backward()
        {
            Backward(100);
        }

        /// <summary>
        /// Make the Robot move backwards
        /// </summary>
        /// <param name="distance">Distance to move backwards</param>
        private static void Backward(uint distance)
        {
            FA_DLL.FA_Backwards(port, distance);
        }

        /// <summary>
        /// Make the Robot turn left
        /// </summary>
        private static void Left()
        {
            Left(45);
        }

        /// <summary>
        /// Make the Robot turn left
        /// </summary>
        /// <param name="distance">Distance to turn left</param>
        private static void Left(uint angle)
        {
            FA_DLL.FA_Left(port, angle);
        }

        /// <summary>
        /// Make the Robot turn right
        /// </summary>
        private static void Right()
        {
            Right(45);
        }

        /// <summary>
        /// Make the Robot ture right
        /// </summary>
        /// <param name="angle">Angle to turn right</param>
        private static void Right(uint angle)
        {
            FA_DLL.FA_Right(port, angle);
        }
        #endregion

        #region Generic Commands
        /// <summary>
        /// Ask the user for a speed
        /// </summary>
        /// <param name="type">Type of speed to ask for</param>
        /// <returns>Speed given by user</returns>
        private static byte GetSpeed(string type)
        {
            // Get the speed the User wants to travel at
            byte speed;
            Console.Write("Enter {0} speed: ", type);
            while (!byte.TryParse(Console.ReadLine(), out speed) || speed > MAX_SPEED)
                Console.WriteLine("Retry with a valid speed (0 - {0}).", MAX_SPEED);
            return speed;
        }
        #endregion
        #endregion
    }
}
