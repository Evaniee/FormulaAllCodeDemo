using System.Runtime.InteropServices;

namespace FormulaAllCode
{
    class FA_DLL
    {
        [DllImport("FASlave.dll")]
        public static extern char FA_ComOpen(char Port);
        [DllImport("FASlave.dll")]
        public static extern char FA_ComClose(char Port);

        [DllImport("FASlave.dll")]
        public static extern void FA_LEDWrite(char Port, char value);
        [DllImport("FASlave.dll")]
        public static extern void FA_LEDOn(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern void FA_LEDOff(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern char FA_ReadSwitch(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern void FA_SetMotors(char Port, int left, int right);
        [DllImport("FASlave.dll")]
        public static extern uint FA_ReadIR(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern uint FA_ReadLine(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern uint FA_ReadLight(char Port);
        [DllImport("FASlave.dll")]
        public static extern void FA_Forwards(char Port, uint distance);
        [DllImport("FASlave.dll")]
        public static extern void FA_Backwards(char Port, uint distance);
        [DllImport("FASlave.dll")]
        public static extern void FA_Left(char Port, uint angle);
        [DllImport("FASlave.dll")]
        public static extern void FA_Right(char Port, uint angle);
        [DllImport("FASlave.dll")]
        public static extern void FA_SetLogoSpeed(char Port, char speed);
        [DllImport("FASlave.dll")]
        public static extern void FA_EncoderReset(char Port);
        [DllImport("FASlave.dll")]
        public static extern uint FA_EncoderRead(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDClear(char Port);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDPrintString(char Port, char x, char y, byte[] text); 
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDPrintNumber(char Port, char x, char y, int number);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDDrawPixel(char Port, char x, char y, char state);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDDrawLine(char Port, char x1, char y1, char x2, char y2);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDDrawRect(char Port, char x1, char y1, char x2, char y2);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDBacklight(char Port, char value);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDVerbose(char Port, char value);
        [DllImport("FASlave.dll")]
        public static extern void FA_LCDOptions(char Port, char FG, char BG, char Trans);

        [DllImport("FASlave.dll")]
        public static extern uint FA_ReadMic(char Port);
        [DllImport("FASlave.dll")]
        public static extern void FA_PlayNote(char Port, uint note, uint time);
        [DllImport("FASlave.dll")]
        public static extern char FA_GetAPIVersion(char Port);

        [DllImport("FASlave.dll")]
        public static extern void FA_ServoEnable(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern void FA_ServoDisable(char Port, char index);
        [DllImport("FASlave.dll")]
        public static extern void FA_ServoSetPosition(char Port, char index, char position);
        [DllImport("FASlave.dll")]
        public static extern void FA_ServoAutoMoveToPosition(char Port, char index, char position);
        [DllImport("FASlave.dll")]
        public static extern void FA_ServoSetAutoMoveSpeed(char Port, char speed);

        [DllImport("FASlave.dll")]
        public static extern char FA_CardInit(char Port);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardCreate(char Port, byte[] filename);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardOpen(char Port, byte[] filename);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardDelete(char Port, byte[] filename);
        [DllImport("FASlave.dll")]
        public static extern void FA_CardWriteByte(char Port, char data);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardReadByte(char Port);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardRecordMic(char Port, char bitdepth, char samplerate, uint time, byte[] filename);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardPlayback(char Port, byte[] filename);
        [DllImport("FASlave.dll")]
        public static extern char FA_CardBitmap(char Port, char x, char y, byte[] filename);

        [DllImport("FASlave.dll")]
        public static extern int FA_ReadAxis(char Port, char index);



        //String Functions with conversions
        public static void FA_LCDPrintString(char Port, int x, int y, string text)
        {
            FA_LCDPrintString(Port, (char) x, (char) y, System.Text.Encoding.UTF8.GetBytes(text));
        }

        public static char FA_CardCreate(char Port, string filename)
        {
            return FA_CardCreate(Port, System.Text.Encoding.UTF8.GetBytes(filename));
        }

        public static char FA_CardOpen(char Port, string filename)
        {
            return FA_CardOpen(Port, System.Text.Encoding.UTF8.GetBytes(filename));
        }

        public static char FA_CardDelete(char Port, string filename)
        {
            return FA_CardDelete(Port, System.Text.Encoding.UTF8.GetBytes(filename));
        }

        public static char FA_CardRecordMic(char Port, char bitdepth, char samplerate, uint time, string filename)
        {
            return FA_CardRecordMic(Port, bitdepth, samplerate, time, System.Text.Encoding.UTF8.GetBytes(filename));
        }

        public static char FA_CardPlayback(char Port, string filename)
        {
            return FA_CardPlayback(Port, System.Text.Encoding.UTF8.GetBytes(filename));
        }

        public static char FA_CardBitmap(char Port, char x, char y, string filename)
        {
            return FA_CardBitmap(Port, x, y, System.Text.Encoding.UTF8.GetBytes(filename));
        }

    }
}
