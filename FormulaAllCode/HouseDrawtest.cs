using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAllCode
{
    class HouseDrawtest
    {
        //Assign Port Number - Remember to change this to match your Formula AllCode port number
        static char PortNumber = (char)4;
        public void House()
        {
            //Open Port
            FA_DLL.FA_ComOpen(PortNumber);

            //Send Play Note Command
            FA_DLL.FA_PlayNote(PortNumber, 500, 100);
            FA_DLL.FA_PlayNote(PortNumber, 100, 100);
            FA_DLL.FA_PlayNote(PortNumber, 600, 100);
            //FA_DLL.FA_Forwards((char)4, 500);
            //FA_DLL.FA_SetMotors((char)4, 100, -100);
            //Thread.Sleep(500);
            //FA_DLL.FA_Forwards((char)4, 500);
            //FA_DLL.FA_SetMotors((char) 4, 0, 0);

            //Print String on LCD
            FA_DLL.FA_LCDClear(PortNumber);
            FA_DLL.FA_LCDPrintString(PortNumber, 19, 8, "Formula AllCode");
            FA_DLL.FA_LCDPrintString(PortNumber, 34, 16, "C# Example");
            FA_DLL.FA_LEDOn(PortNumber, (char)0);
            FA_DLL.FA_LEDOn(PortNumber, (char)2);
            FA_DLL.FA_LEDOn(PortNumber, (char)4);
            FA_DLL.FA_LEDOn(PortNumber, (char)6);


            //Draw a house
            FA_DLL.FA_SetMotors(PortNumber, 50, 50);
            FA_DLL.FA_Forwards(PortNumber, 200);
            FA_DLL.FA_Right(PortNumber, 45);
            FA_DLL.FA_Forwards(PortNumber, 100);
            FA_DLL.FA_Right(PortNumber, 90);
            FA_DLL.FA_Forwards(PortNumber, 100);
            FA_DLL.FA_Right(PortNumber, 45);
            FA_DLL.FA_Forwards(PortNumber, 200);
            FA_DLL.FA_Right(PortNumber, 90);
            FA_DLL.FA_Forwards(PortNumber, 200);

            FA_DLL.FA_SetMotors(PortNumber, 100, -100);
            FA_DLL.FA_SetMotors(PortNumber, 0, 0);

            //End command sound
            FA_DLL.FA_PlayNote(PortNumber, 600, 100);
            FA_DLL.FA_PlayNote(PortNumber, 100, 100);
            FA_DLL.FA_PlayNote(PortNumber, 500, 100);
            FA_DLL.FA_LEDOff(PortNumber, (char)0);
            FA_DLL.FA_LEDOff(PortNumber, (char)2);
            FA_DLL.FA_LEDOff(PortNumber, (char)4);
            FA_DLL.FA_LEDOff(PortNumber, (char)6);

            while (true)
            {
                uint line_1 = FA_DLL.FA_ReadLine(PortNumber, (char)1);
                uint line_2 = FA_DLL.FA_ReadLine(PortNumber, (char)2);
                uint ir1 = FA_DLL.FA_ReadIR(PortNumber, (char)0);
                uint ir2 = FA_DLL.FA_ReadIR(PortNumber, (char)1);
                uint ir3 = FA_DLL.FA_ReadIR(PortNumber, (char)2);
                uint ir4 = FA_DLL.FA_ReadIR(PortNumber, (char)3);
                uint ir5 = FA_DLL.FA_ReadIR(PortNumber, (char)4);
                uint ir6 = FA_DLL.FA_ReadIR(PortNumber, (char)5);
                uint ir7 = FA_DLL.FA_ReadIR(PortNumber, (char)6);
                uint ir8 = FA_DLL.FA_ReadIR(PortNumber, (char)7);
                Console.WriteLine("Values = " + line_1 + "\t" + line_2 + "\t" + ir1 + "\t" + ir2 + "\t" + ir3 + "\t" + ir4 + "\t" + ir5 + "\t" + ir6 + "\t" + ir7 + "\t" + ir8);
            }
            //Close Port
            FA_DLL.FA_ComClose(PortNumber);
        }
    }
}
