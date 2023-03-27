using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAllCode
{
    class FollowTheLine
    {
        //Assign Port Number - Remember to change this to match your Formula AllCode port number
        static char PortNumber = (char)4;

        public void RaceTrack()
        {
            //Open Port
            FA_DLL.FA_ComOpen(PortNumber);

            FA_DLL.FA_LCDClear(PortNumber);
            FA_DLL.FA_LCDPrintString(PortNumber, 0, 0, "Left Right");

            int black = 0;
            int white = 200;
            int correction = 10;

            
            while (true)
            {
                uint Left = FA_DLL.FA_ReadLine(PortNumber, (char)0);
                uint Right = FA_DLL.FA_ReadLine(PortNumber, (char)1);
                FA_DLL.FA_SetMotors(PortNumber, 25, 25);

                if(Left >= white)
                {
                    FA_DLL.FA_Right(PortNumber, 10);
                }
                else if(Right >= white)
                {
                    FA_DLL.FA_Left(PortNumber, 10);
                }
            }
            //Close Port
            FA_DLL.FA_ComClose(PortNumber);
        }
    }
}
