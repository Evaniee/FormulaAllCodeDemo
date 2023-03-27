using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAllCode
{
    class mazeRunner
    {
        //Assign Port Number - Remember to change this to match your Formula AllCode port number
        static char PortNumber = (char)9;

        public void MazeRunner()
        {
            //Open Port
            FA_DLL.FA_ComOpen(PortNumber);
            //Send Play Note Command
            FA_DLL.FA_PlayNote(PortNumber, 500, 100);
            FA_DLL.FA_PlayNote(PortNumber, 100, 100);
            FA_DLL.FA_PlayNote(PortNumber, 600, 100);


            int clearance = 100;
            int wall = 600;
            while (true)
            {                
                uint left = FA_DLL.FA_ReadIR(PortNumber, (char)0);
                uint front = FA_DLL.FA_ReadIR(PortNumber, (char)2);
                //Console.WriteLine("Values = " + left + "\t" + front + "\t");
                /*if (left <= wall && front <= clearance)
                {
                    FA_DLL.FA_SetMotors(PortNumber, 25, 25);
                }*/

                //check if enough left clearance and no obstical to the front to go foward
                if (left <= wall) //break into nested ifs, Have alternatives for if its not <=
                {
                    if (front <= 200)
                    {
                        Console.WriteLine("A - move forward");
                        // check if enough front clearance  
                        FA_DLL.FA_SetMotors(PortNumber, 25, 25);
                    }
                    //clearance to left but obstical to front so turn right
                    else
                    {
                        Console.WriteLine("B - clearance left and front obstacle - turn right");
                        FA_DLL.FA_SetMotors(PortNumber, 0, 0);
                        FA_DLL.FA_Right(PortNumber, 90);
                    }
                    // is there a left turn, if so turn left
                    if (left < clearance)
                    {
                        Console.WriteLine("C - clearance at left so turn left");
                        FA_DLL.FA_Forwards(PortNumber, 80);
                        FA_DLL.FA_SetMotors(PortNumber, 0, 0);
                        FA_DLL.FA_Left(PortNumber, 90);
                    }
                }
                
                //to close to left wall
                else if (left >= wall)
                {
                    //and to close to front so turn right
                    if (front >= wall)
                    {
                        Console.WriteLine("D - left / front walls so turn right");
                        FA_DLL.FA_SetMotors(PortNumber, 0, 0);
                        FA_DLL.FA_Right(PortNumber, 90);
                    }
                }
                else
                {
                    Console.WriteLine("ELSE - move forward");
                    FA_DLL.FA_SetMotors(PortNumber, 25, 25);
                }
            }
            //Close Port
            FA_DLL.FA_ComClose(PortNumber);
        }       
    }
}
