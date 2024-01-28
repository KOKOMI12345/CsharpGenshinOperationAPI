using System;
using System.Runtime.InteropServices;

namespace Operation
{
    public class Operate
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        private readonly IntPtr user32;

        public Operate()
        {
            user32 = LoadLibrary("user32.dll");
        }

        public void PressKey(byte key)
        {
            keybd_event(key, 0, 0, UIntPtr.Zero);
        }

        public void ReleaseKey(byte key)
        {
            keybd_event(key, 0, 2, UIntPtr.Zero);
        }
        
        public void Mouse(uint button, int x = 0, int y = 0)
        {
            var (dx, dy) = GetMousePos(x, y);
            mouse_event(button, dx, dy, 0, UIntPtr.Zero);
        }

        private (int, int) GetMousePos(int x, int y)
        {
            SetProcessDPIAware();
            int width = GetSystemMetrics(0);
            int height = GetSystemMetrics(1);
            int dx = Convert.ToInt32(x * 65535 / width);
            int dy = Convert.ToInt32(y * 65535 / height);
            return (dx, dy);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetProcessDPIAware();
    }
}
