using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace FormulaAllCode
{
    class Program
    {
        static char portNumber;
        static readonly byte MAX_SPEED = 100;
        static readonly uint MAX_DISTANCE = 10_000;

        static void Setup()
        {
            // Get User's port number via input
            Console.Write("What is your port number: ");
            byte portNumberByte;
            while (!byte.TryParse(Console.ReadLine(), out portNumberByte))
                Console.WriteLine("Retry with a valid port number.");
            portNumber = (char)portNumberByte;

            // Open Port
            FA_DLL.FA_ComOpen(portNumber);

            //while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                // Playnote Test
                FA_DLL.FA_PlayNote(portNumber, 500, 100);
                FA_DLL.FA_PlayNote(portNumber, 100, 100);
                FA_DLL.FA_PlayNote(portNumber, 600, 100);
            }
        }

        static void SelfControl()
        {
            Console.WriteLine("Entering User Control Mode");
            bool loop = true;
            while (loop)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        FA_DLL.FA_Forwards(portNumber, 100);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        FA_DLL.FA_Backwards(portNumber, 100);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        FA_DLL.FA_Left(portNumber, 45);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        FA_DLL.FA_Right(portNumber, 45);
                        break;
                    case ConsoleKey.Escape:
                        loop = false;
                        break;
                }
            }
        }

        static void DragStrip()
        {
            byte speed;
            Console.Write("Enter speed: ");
            while (!byte.TryParse(Console.ReadLine(), out speed) || speed > MAX_SPEED)
                Console.WriteLine("Retry with a valid speed (0 - {0}).", MAX_SPEED);
            FA_DLL.FA_SetMotors(portNumber, speed, speed);
            Console.WriteLine("Speed Set to {0}", speed);

            uint distance;
            Console.Write("Enter distance (Max {0}): ", MAX_DISTANCE);
            while (!uint.TryParse(Console.ReadLine(), out distance) || distance > MAX_DISTANCE)
                Console.WriteLine("Retry with a valid distance (0 - {0}).", MAX_DISTANCE);
            Console.WriteLine("Distance Set to {0}", distance);

            Console.WriteLine("Press Spacebar to go");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) ;
            FA_DLL.FA_Forwards(portNumber, distance);
        }

        static void Shutdown()
        {
            FA_DLL.FA_ComClose(portNumber);
        }

        static void Main(string[] args)
        {
            Setup();
            SelfControl();
            //DragStrip();
            Forward(100);
            Shutdown();
            Console.ReadKey(true);
        }     
           
        static void Forward(uint distance)
        {
            FA_DLL.FA_Forwards(portNumber, distance);
        }
    }
}

#region Adam's Old Stuff
//bool quit = false;
//do
//{
//    Console.WriteLine("What do you want me to do?");
//    Console.WriteLine("A: Draw a House, B: Follow a Black line, C: Maze Runner");
//    string option = Console.ReadLine();

//    switch (option)
//    {
//        case "A":
//        case "a":
//            HouseDrawtest house = new HouseDrawtest();
//            house.House();
//            break;
//        case "B":
//        case "b":
//            FollowTheLine line = new FollowTheLine();
//            line.RaceTrack();
//            break;
//        case "C":
//        case "c":
//            mazeRunner runner = new mazeRunner();
//            runner.MazeRunner();
//            break;
//        case "0":
//            quit = true;
//            break;
//        default:
//            Console.WriteLine("Invalid choice!");
//            break;
//    }
//} while (quit == false);
#endregion