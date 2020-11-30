using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MarketAnalyserLibrary
{
    public class MouseController
    {
        // import for mouse clicking events
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);
        private const uint mouseEventLeftDown = 0x0002;
        private const uint mouseEventLeftUp = 0x0004;

        // imports for getting and setting cursor positions
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        /// <summary>
        /// presses then releases the left mouse button
        /// </summary>
        public void ClickLeftButton()
        {
            mouse_event(mouseEventLeftDown, 0, 0, 0, 0);
            Thread.Sleep(100);
            mouse_event(mouseEventLeftUp, 0, 0, 0, 0);

        }

        /// <summary>
        /// sets the cursor to a specified point
        /// </summary>
        /// <param name="setPosition"></param>
        public void SetToPoint(Point setPosition)
        {
            SetCursorPos(setPosition.X, setPosition.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the current cursor position</returns>
        public Point GetCursorPosition()
        {
            Point output;
            GetCursorPos(out output);
            return output;
        }
    }
}
