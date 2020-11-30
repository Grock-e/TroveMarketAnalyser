using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataRetrevialLib
{
    public class KeyboardController
    {
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVK, byte bscan, uint dwFlags, int dwExtraInfo);

        /// <summary>
        /// presses a key for a respective keyCode
        /// </summary>
        /// <param name="keyCode">code for specified key</param>
        public void PressKey(KeyInputCode keyCode)
        {
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }

}
