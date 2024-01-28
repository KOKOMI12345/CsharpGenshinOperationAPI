//这个是按键输入和输出
namespace UserComputer
{
    public static class Keyboard
    {
        /*
        NOTE: 键盘操作类
        */

        public const int ENTER = 0x0D;
        public const int ESC = 0x1B;
        public const int BACKSPACE = 0x08;
        public const int TAB = 0x09;
        public const int SHIFT = 0x10;
        public const int W = 0x57;
        public const int A = 0x41;
        public const int S = 0x53;
        public const int D = 0x44;
        public const int E = 0x45;
        public const int Q = 0x51;
        public const int F = 0x46;
        public const int SPACE = 0x20;
    }

    public static class Mouse
    {
        /*
        NOTE: 鼠标操作类
        */

        public const int MOUSECENTERKEY_UP = 0x0010;
        public const int MOUSECENTERKEY_DOWN = 0x0020;
        public const int MOUSEEVENT_LEFTUP = 0x0002;
        public const int MOUSEEVENT_LEFTDOWN = 0x0004;
    }
}