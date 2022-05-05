using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMouseKey
{
    class Event
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT pt);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(Keys bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int flg, int dx, int dy, int button, int extraInfo);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetDoubleClickTime();

        public struct POINT
        {
            public int X;
            public int Y;
        }

        internal static void CloseCapslk()
        {
            if (GetKeyState(0x14) == 1)
            {
                keybd_event((Keys)0x14, 0x45, 0x1 | 0, 0);
                keybd_event((Keys)0x14, 0x45, 0x1 | 0x2, 0);
            }
        }

        public static POINT GetMousePos()
        {
            GetCursorPos(out POINT p);
            return p;
        }

        internal static void MouseEvents(string k, string clik)
        {
            if (k == "上滚动")
            {
                mouse_event(2048, 0, 0, 120, 0);
            }
            else if (k == "下滚动")
            {
                mouse_event(2048, 0, 0, -120, 0);
            }
            else if (k == "移动")
            {
                mouse_event(1, 0, 0, 0, 0);
            }
            else
            {
                int keynum = 2;
                if (k == "右键")
                {
                    keynum = 8;
                }
                else if (k == "中键")
                {
                    keynum = 32;
                }
                if (clik == "单击" || clik == "双击" || clik == "按下")
                {
                    mouse_event(keynum, 0, 0, 0, 0);
                }
                if (clik == "双击")
                {
                    mouse_event(keynum * 2, 0, 0, 0, 0);
                    System.Threading.Thread.Sleep(GetDoubleClickTime());
                    mouse_event(keynum, 0, 0, 0, 0);
                }
                if (clik == "单击" || clik == "双击" || clik == "放开")
                {
                    mouse_event(keynum * 2, 0, 0, 0, 0);
                }
            }
        }

        internal static void MouseDrags(int fromeX, int fromeY, int toX, int toY)
        {
            SetCursorPos(fromeX, fromeY);
            mouse_event(2, 0, 0, 0, 0);
            SetCursorPos(toX, toY);
            System.Threading.Thread.Sleep(50);
            mouse_event(2 * 2, 0, 0, 0, 0);
        }

        internal static void KeyClicks(Keys k, bool Ctr, bool Alt, bool Shift, string click)
        {
            if (click == "单击" || click == "按下")
            {
                if (Ctr)
                {
                    keybd_event(Keys.ControlKey, 0, 0, 0);
                }
                if (Alt)
                {
                    keybd_event(Keys.Menu, 0, 0, 0);
                }
                if (Shift)
                {
                    keybd_event(Keys.ShiftKey, 0, 0, 0);
                }
                keybd_event(k, 0, 0, 0);
            }
            if (click == "单击" || click == "放开")
            {
                keybd_event(k, 0, 2, 0);
                if (Shift)
                {
                    keybd_event(Keys.ShiftKey, 0, 2, 0);
                }
                if (Alt)
                {
                    keybd_event(Keys.Menu, 0, 2, 0);
                }
                if (Ctr)
                {
                    keybd_event(Keys.ControlKey, 0, 2, 0);
                }
            }
        }


        internal static Keys GetCharKey(char item, out bool shiftKey)
        {
            shiftKey = false;

            Keys vkey;
            switch (item)
            {

                case '消':
                    vkey = Keys.Cancel;
                    break;

                case '退':
                    vkey = Keys.Back;
                    break;
                case '表':
                    vkey = Keys.Tab;
                    break;
                case '\t':
                    vkey = Keys.Tab;
                    break;
                case '行':
                    vkey = Keys.LineFeed;
                    break;
                case '清':
                    vkey = Keys.Clear;
                    break;
                case '回':
                    vkey = Keys.Enter;
                    break;
                case '档':
                    vkey = Keys.ShiftKey;
                    break;
                case '控':
                    vkey = Keys.ControlKey;
                    break;
                case '换':
                    vkey = Keys.Menu;
                    break;
                case '暂':
                    vkey = Keys.Pause;
                    break;
                case '大':
                    vkey = Keys.CapsLock;
                    break;
                case '返':
                    vkey = Keys.Escape;
                    break;
                case '白':
                    vkey = Keys.Space;
                    break;
                case ' ':
                    vkey = Keys.Space;
                    break;
                case '前':
                    vkey = Keys.PageUp;
                    break;
                case '后':
                    vkey = Keys.PageDown;
                    break;
                case '尾':
                    vkey = Keys.End;
                    break;
                case '首':
                    vkey = Keys.Home;
                    break;
                case '左':
                    vkey = Keys.Left;
                    break;
                case '上':
                    vkey = Keys.Up;
                    break;
                case '右':
                    vkey = Keys.Right;
                    break;
                case '下':
                    vkey = Keys.Down;
                    break;
                case '选':
                    vkey = Keys.Select;
                    break;
                case '印':
                    vkey = Keys.Print;
                    break;
                case '执':
                    vkey = Keys.Execute;
                    break;
                case '屏':
                    vkey = Keys.PrintScreen;
                    break;
                case '插':
                    vkey = Keys.Insert;
                    break;
                case '删':
                    vkey = Keys.Delete;
                    break;
                case '助':
                    vkey = Keys.Help;
                    break;
                case '0':
                    vkey = Keys.D0;
                    break;
                case '1':
                    vkey = Keys.D1;
                    break;
                case '2':
                    vkey = Keys.D2;
                    break;
                case '3':
                    vkey = Keys.D3;
                    break;
                case '4':
                    vkey = Keys.D4;
                    break;
                case '5':
                    vkey = Keys.D5;
                    break;
                case '6':
                    vkey = Keys.D6;
                    break;
                case '7':
                    vkey = Keys.D7;
                    break;
                case '8':
                    vkey = Keys.D8;
                    break;
                case '9':
                    vkey = Keys.D9;
                    break;
                case ')':
                    vkey = Keys.D0;
                    shiftKey = true;
                    break;
                case '!':
                    vkey = Keys.D1;
                    shiftKey = true;
                    break;
                case '@':
                    vkey = Keys.D2;
                    shiftKey = true;
                    break;
                case '#':
                    vkey = Keys.D3;
                    shiftKey = true;
                    break;
                case '$':
                    vkey = Keys.D4;
                    shiftKey = true;
                    break;
                case '%':
                    vkey = Keys.D5;
                    shiftKey = true;
                    break;
                case '^':
                    vkey = Keys.D6;
                    shiftKey = true;
                    break;
                case '&':
                    vkey = Keys.D7;
                    shiftKey = true;
                    break;
                case '*':
                    vkey = Keys.D8;
                    shiftKey = true;
                    break;
                case '(':
                    vkey = Keys.D9;
                    shiftKey = true;
                    break;

                case 'A':
                    vkey = Keys.A;
                    shiftKey = true;
                    break;
                case 'B':
                    vkey = Keys.B;
                    shiftKey = true;
                    break;
                case 'C':
                    vkey = Keys.C;
                    shiftKey = true;
                    break;
                case 'D':
                    vkey = Keys.D;
                    shiftKey = true;
                    break;
                case 'E':
                    vkey = Keys.E;
                    shiftKey = true;
                    break;
                case 'F':
                    vkey = Keys.F;
                    shiftKey = true;
                    break;
                case 'G':
                    vkey = Keys.G;
                    shiftKey = true;
                    break;
                case 'H':
                    vkey = Keys.H;
                    shiftKey = true;
                    break;
                case 'I':
                    vkey = Keys.I;
                    shiftKey = true;
                    break;
                case 'J':
                    vkey = Keys.J;
                    shiftKey = true;
                    break;
                case 'K':
                    vkey = Keys.K;
                    shiftKey = true;
                    break;
                case 'L':
                    vkey = Keys.L;
                    shiftKey = true;
                    break;
                case 'M':
                    vkey = Keys.M;
                    shiftKey = true;
                    break;
                case 'N':
                    vkey = Keys.N;
                    shiftKey = true;
                    break;
                case 'O':
                    vkey = Keys.O;
                    shiftKey = true;
                    break;
                case 'P':
                    vkey = Keys.P;
                    shiftKey = true;
                    break;
                case 'Q':
                    vkey = Keys.Q;
                    shiftKey = true;
                    break;
                case 'R':
                    vkey = Keys.R;
                    shiftKey = true;
                    break;
                case 'S':
                    vkey = Keys.S;
                    shiftKey = true;
                    break;
                case 'T':
                    vkey = Keys.T;
                    shiftKey = true;
                    break;
                case 'U':
                    vkey = Keys.U;
                    shiftKey = true;
                    break;
                case 'V':
                    vkey = Keys.V;
                    shiftKey = true;
                    break;
                case 'W':
                    vkey = Keys.W;
                    shiftKey = true;
                    break;
                case 'X':
                    vkey = Keys.X;
                    shiftKey = true;
                    break;
                case 'Y':
                    vkey = Keys.Y;
                    shiftKey = true;
                    break;
                case 'Z':
                    vkey = Keys.Z;
                    shiftKey = true;
                    break;
                case 'a':
                    vkey = Keys.A;
                    break;
                case 'b':
                    vkey = Keys.B;
                    break;
                case 'c':
                    vkey = Keys.C;
                    break;
                case 'd':
                    vkey = Keys.D;
                    break;
                case 'e':
                    vkey = Keys.E;
                    break;
                case 'f':
                    vkey = Keys.F;
                    break;
                case 'g':
                    vkey = Keys.G;
                    break;
                case 'h':
                    vkey = Keys.H;
                    break;
                case 'i':
                    vkey = Keys.I;
                    break;
                case 'j':
                    vkey = Keys.J;
                    break;
                case 'k':
                    vkey = Keys.K;
                    break;
                case 'l':
                    vkey = Keys.L;
                    break;
                case 'm':
                    vkey = Keys.M;
                    break;
                case 'n':
                    vkey = Keys.N;
                    break;
                case 'o':
                    vkey = Keys.O;
                    break;
                case 'p':
                    vkey = Keys.P;
                    break;
                case 'q':
                    vkey = Keys.Q;
                    break;
                case 'r':
                    vkey = Keys.R;
                    break;
                case 's':
                    vkey = Keys.S;
                    break;
                case 't':
                    vkey = Keys.T;
                    break;
                case 'u':
                    vkey = Keys.U;
                    break;
                case 'v':
                    vkey = Keys.V;
                    break;
                case 'w':
                    vkey = Keys.W;
                    break;
                case 'x':
                    vkey = Keys.X;
                    break;
                case 'y':
                    vkey = Keys.Y;
                    break;
                case 'z':
                    vkey = Keys.Z;
                    break;
                case '窗':
                    vkey = Keys.LWin;
                    break;
                case '温':
                    vkey = Keys.RWin;
                    break;
                case '应':
                    vkey = Keys.Apps;
                    break;
                case '眠':
                    vkey = Keys.Sleep;
                    break;
                case '〇':
                    vkey = Keys.NumPad0;
                    break;
                case '零':
                    vkey = Keys.NumPad0;
                    break;
                case '一':
                    vkey = Keys.NumPad1;
                    break;
                case '二':
                    vkey = Keys.NumPad2;
                    break;
                case '三':
                    vkey = Keys.NumPad3;
                    break;
                case '四':
                    vkey = Keys.NumPad4;
                    break;
                case '五':
                    vkey = Keys.NumPad5;
                    break;
                case '六':
                    vkey = Keys.NumPad6;
                    break;
                case '七':
                    vkey = Keys.NumPad7;
                    break;
                case '八':
                    vkey = Keys.NumPad8;
                    break;
                case '九':
                    vkey = Keys.NumPad9;
                    break;
                case '乘':
                    vkey = Keys.Multiply;
                    break;
                case '加':
                    vkey = Keys.Add;
                    break;
                case '分':
                    vkey = Keys.Separator;
                    break;
                case '减':
                    vkey = Keys.Subtract;
                    break;
                case '点':
                    vkey = Keys.Decimal;
                    break;
                case '除':
                    vkey = Keys.Divide;
                    break;
                case '子':
                    vkey = Keys.F1;
                    break;
                case '丑':
                    vkey = Keys.F2;
                    break;
                case '寅':
                    vkey = Keys.F3;
                    break;
                case '卯':
                    vkey = Keys.F4;
                    break;
                case '辰':
                    vkey = Keys.F5;
                    break;
                case '巳':
                    vkey = Keys.F6;
                    break;
                case '午':
                    vkey = Keys.F7;
                    break;
                case '未':
                    vkey = Keys.F8;
                    break;
                case '申':
                    vkey = Keys.F9;
                    break;
                case '酉':
                    vkey = Keys.F10;
                    break;
                case '戌':
                    vkey = Keys.F11;
                    break;
                case '亥':
                    vkey = Keys.F12;
                    break;
                case '数':
                    vkey = Keys.NumLock;
                    break;
                case '滚':
                    vkey = Keys.Scroll;
                    break;
                case ';':
                    vkey = Keys.OemSemicolon;
                    break;
                case '=':
                    vkey = Keys.Oemplus;
                    break;
                case ',':
                    vkey = Keys.Oemcomma;
                    break;
                case '-':
                    vkey = Keys.OemMinus;
                    break;
                case '.':
                    vkey = Keys.OemPeriod;
                    break;
                case '/':
                    vkey = Keys.OemQuestion;
                    break;
                case '`':
                    vkey = Keys.Oemtilde;
                    break;
                case '[':
                    vkey = Keys.OemOpenBrackets;
                    break;
                case '\\':
                    vkey = Keys.OemPipe;
                    break;
                case ']':
                    vkey = Keys.OemCloseBrackets;
                    break;
                case '\'':
                    vkey = Keys.OemQuotes;
                    break;
                case ':':
                    vkey = Keys.OemSemicolon;
                    shiftKey = true;
                    break;
                case '+':
                    vkey = Keys.Oemplus;
                    shiftKey = true;
                    break;
                case '<':
                    vkey = Keys.Oemcomma;
                    shiftKey = true;
                    break;
                case '_':
                    vkey = Keys.OemMinus;
                    shiftKey = true;
                    break;
                case '>':
                    vkey = Keys.OemPeriod;
                    shiftKey = true;
                    break;
                case '?':
                    vkey = Keys.OemQuestion;
                    shiftKey = true;
                    break;
                case '~':
                    vkey = Keys.Oemtilde;
                    shiftKey = true;
                    break;
                case '{':
                    vkey = Keys.OemOpenBrackets;
                    shiftKey = true;
                    break;
                case '|':
                    vkey = Keys.OemPipe;
                    shiftKey = true;
                    break;
                case '}':
                    vkey = Keys.OemCloseBrackets;
                    shiftKey = true;
                    break;
                case '"':
                    vkey = Keys.OemQuotes;
                    shiftKey = true;
                    break;
                default:
                    vkey = Keys.None;
                    break;
            }
            return vkey;
        }

        public static Keys GetKeys(string keyName)
        {
            Keys vkey;
            switch (keyName)
            {
                case "不按任何键":
                    vkey = Keys.None;
                    break;
                case "鼠标左键":
                    vkey = Keys.LButton;
                    break;
                case "鼠标右键按钮中":
                    vkey = Keys.RButton;
                    break;
                case "CANCEL 键":
                    vkey = Keys.Cancel;
                    break;
                case "鼠标中键":
                    vkey = Keys.MButton;
                    break;
                case "第一个 x 鼠标按钮":
                    vkey = Keys.XButton1;
                    break;
                case "第二个鼠标按钮 x":
                    vkey = Keys.XButton2;
                    break;
                case "BACKSPACE 键":
                    vkey = Keys.Back;
                    break;
                case "TAB 键":
                    vkey = Keys.Tab;
                    break;
                case "LINEFEED 键":
                    vkey = Keys.LineFeed;
                    break;
                case "CLEAR 键":
                    vkey = Keys.Clear;
                    break;
                case "RETURN 键":
                    vkey = Keys.Return;
                    break;
                case "ENTER 键":
                    vkey = Keys.Enter;
                    break;
                case "SHIFT 键":
                    vkey = Keys.ShiftKey;
                    break;
                case "CTRL 键":
                    vkey = Keys.ControlKey;
                    break;
                case "ALT 键":
                    vkey = Keys.Menu;
                    break;
                case "PAUSE 键":
                    vkey = Keys.Pause;
                    break;
                case "CAPS LOCK 键":
                    vkey = Keys.CapsLock;
                    break;
                case "IME Kana 模式键":
                    vkey = Keys.KanaMode;
                    break;
                case "IME Hanguel 模式键":
                    vkey = Keys.HanguelMode;
                    break;
                case "IME Hangul 模式键":
                    vkey = Keys.HangulMode;
                    break;
                case "IME Junja 模式键":
                    vkey = Keys.JunjaMode;
                    break;
                case "IME 最终模式键":
                    vkey = Keys.FinalMode;
                    break;
                case "IME Hanja 模式键":
                    vkey = Keys.HanjaMode;
                    break;
                case "IME Kanji 模式键":
                    vkey = Keys.KanjiMode;
                    break;
                case "ESC 键":
                    vkey = Keys.Escape;
                    break;
                case "IME convert 键":
                    vkey = Keys.IMEConvert;
                    break;
                case "IME nonconvert 键":
                    vkey = Keys.IMENonconvert;
                    break;
                case "IME 接受密钥":
                    vkey = Keys.IMEAccept;
                    break;
                case "IME 接受密钥(已过时)":
                    vkey = Keys.IMEAceept;
                    break;
                case "IME 模式更改密钥":
                    vkey = Keys.IMEModeChange;
                    break;
                case "SPACEBAR 键":
                    vkey = Keys.Space;
                    break;
                case "PAGE UP 键":
                    vkey = Keys.PageUp;
                    break;
                case "PAGE DOWN 键":
                    vkey = Keys.PageDown;
                    break;
                case "END 键":
                    vkey = Keys.End;
                    break;
                case "HOME 键":
                    vkey = Keys.Home;
                    break;
                case "LEFT ARROW 键":
                    vkey = Keys.Left;
                    break;
                case "UP ARROW 键":
                    vkey = Keys.Up;
                    break;
                case "RIGHT ARROW 键":
                    vkey = Keys.Right;
                    break;
                case "DOWN ARROW 键":
                    vkey = Keys.Down;
                    break;
                case "SELECT 键":
                    vkey = Keys.Select;
                    break;
                case "PRINT 键":
                    vkey = Keys.Print;
                    break;
                case "EXECUTE 键":
                    vkey = Keys.Execute;
                    break;
                case "PRINT SCREEN 键":
                    vkey = Keys.PrintScreen;
                    break;
                case "INS 键":
                    vkey = Keys.Insert;
                    break;
                case "DEL 键":
                    vkey = Keys.Delete;
                    break;
                case "HELP 键":
                    vkey = Keys.Help;
                    break;
                case "0 键":
                    vkey = Keys.D0;
                    break;
                case "1 键":
                    vkey = Keys.D1;
                    break;
                case "2 键":
                    vkey = Keys.D2;
                    break;
                case "3 键":
                    vkey = Keys.D3;
                    break;
                case "4 键":
                    vkey = Keys.D4;
                    break;
                case "5 键":
                    vkey = Keys.D5;
                    break;
                case "6 键":
                    vkey = Keys.D6;
                    break;
                case "7 键":
                    vkey = Keys.D7;
                    break;
                case "8 键":
                    vkey = Keys.D8;
                    break;
                case "9 键":
                    vkey = Keys.D9;
                    break;
                case "A 键":
                    vkey = Keys.A;
                    break;
                case "B 键":
                    vkey = Keys.B;
                    break;
                case "C 键":
                    vkey = Keys.C;
                    break;
                case "D 键":
                    vkey = Keys.D;
                    break;
                case "E 键":
                    vkey = Keys.E;
                    break;
                case "F 键":
                    vkey = Keys.F;
                    break;
                case "G 键":
                    vkey = Keys.G;
                    break;
                case "H 键":
                    vkey = Keys.H;
                    break;
                case "I 键":
                    vkey = Keys.I;
                    break;
                case "J 键":
                    vkey = Keys.J;
                    break;
                case "K 键":
                    vkey = Keys.K;
                    break;
                case "L 键":
                    vkey = Keys.L;
                    break;
                case "M 键":
                    vkey = Keys.M;
                    break;
                case "N 键":
                    vkey = Keys.N;
                    break;
                case "O 键":
                    vkey = Keys.O;
                    break;
                case "P 键":
                    vkey = Keys.P;
                    break;
                case "Q 键":
                    vkey = Keys.Q;
                    break;
                case "R 键":
                    vkey = Keys.R;
                    break;
                case "S 键":
                    vkey = Keys.S;
                    break;
                case "T 键":
                    vkey = Keys.T;
                    break;
                case "U 键":
                    vkey = Keys.U;
                    break;
                case "V 键":
                    vkey = Keys.V;
                    break;
                case "W 键":
                    vkey = Keys.W;
                    break;
                case "X 键":
                    vkey = Keys.X;
                    break;
                case "Y 键":
                    vkey = Keys.Y;
                    break;
                case "Z 键":
                    vkey = Keys.Z;
                    break;
                case "左 Windows 徽标键":
                    vkey = Keys.LWin;
                    break;
                case "右 Windows 徽标键":
                    vkey = Keys.RWin;
                    break;
                case "应用程序密钥":
                    vkey = Keys.Apps;
                    break;
                case "计算机休眠键":
                    vkey = Keys.Sleep;
                    break;
                case "数字键盘上的 0 键":
                    vkey = Keys.NumPad0;
                    break;
                case "数字键盘上的 1 键":
                    vkey = Keys.NumPad1;
                    break;
                case "数字键盘上的 2 键":
                    vkey = Keys.NumPad2;
                    break;
                case "数字键盘上的 3 键":
                    vkey = Keys.NumPad3;
                    break;
                case "数字键盘上的 4 键":
                    vkey = Keys.NumPad4;
                    break;
                case "数字键盘上的 5 键":
                    vkey = Keys.NumPad5;
                    break;
                case "数字键盘上的 6 键":
                    vkey = Keys.NumPad6;
                    break;
                case "数字键盘上的 7 键":
                    vkey = Keys.NumPad7;
                    break;
                case "数字键盘上的 8 键":
                    vkey = Keys.NumPad8;
                    break;
                case "数字键盘上的 9 键":
                    vkey = Keys.NumPad9;
                    break;
                case "乘号键":
                    vkey = Keys.Multiply;
                    break;
                case "加号键":
                    vkey = Keys.Add;
                    break;
                case "分隔符键":
                    vkey = Keys.Separator;
                    break;
                case "减号键":
                    vkey = Keys.Subtract;
                    break;
                case "句点键":
                    vkey = Keys.Decimal;
                    break;
                case "除号键":
                    vkey = Keys.Divide;
                    break;
                case "F1 键":
                    vkey = Keys.F1;
                    break;
                case "F2 键":
                    vkey = Keys.F2;
                    break;
                case "F3 键":
                    vkey = Keys.F3;
                    break;
                case "F4 键":
                    vkey = Keys.F4;
                    break;
                case "F5 键":
                    vkey = Keys.F5;
                    break;
                case "F6 键":
                    vkey = Keys.F6;
                    break;
                case "F7 键":
                    vkey = Keys.F7;
                    break;
                case "F8 键":
                    vkey = Keys.F8;
                    break;
                case "F9 键":
                    vkey = Keys.F9;
                    break;
                case "F10 键":
                    vkey = Keys.F10;
                    break;
                case "F11 键":
                    vkey = Keys.F11;
                    break;
                case "F12 键":
                    vkey = Keys.F12;
                    break;
                case "F13 键":
                    vkey = Keys.F13;
                    break;
                case "F14 键":
                    vkey = Keys.F14;
                    break;
                case "F15 键":
                    vkey = Keys.F15;
                    break;
                case "F16 键":
                    vkey = Keys.F16;
                    break;
                case "F17 键":
                    vkey = Keys.F17;
                    break;
                case "F18 键":
                    vkey = Keys.F18;
                    break;
                case "F19 键":
                    vkey = Keys.F19;
                    break;
                case "F20 键":
                    vkey = Keys.F20;
                    break;
                case "F21 键":
                    vkey = Keys.F21;
                    break;
                case "F22 键":
                    vkey = Keys.F22;
                    break;
                case "F23 键":
                    vkey = Keys.F23;
                    break;
                case "F24 键":
                    vkey = Keys.F24;
                    break;
                case "NUM LOCK 键":
                    vkey = Keys.NumLock;
                    break;
                case "SCROLL LOCK 键":
                    vkey = Keys.Scroll;
                    break;
                case "左的 SHIFT 键":
                    vkey = Keys.LShiftKey;
                    break;
                case "右 SHIFT 键":
                    vkey = Keys.RShiftKey;
                    break;
                case "左 CTRL 键":
                    vkey = Keys.LControlKey;
                    break;
                case "右 CTRL 键":
                    vkey = Keys.RControlKey;
                    break;
                case "左 ALT 键":
                    vkey = Keys.LMenu;
                    break;
                case "右 ALT 键":
                    vkey = Keys.RMenu;
                    break;
                case "浏览器后退键":
                    vkey = Keys.BrowserBack;
                    break;
                case "浏览器前进键":
                    vkey = Keys.BrowserForward;
                    break;
                case "浏览器刷新键":
                    vkey = Keys.BrowserRefresh;
                    break;
                case "浏览器停止键":
                    vkey = Keys.BrowserStop;
                    break;
                case "浏览器搜索键":
                    vkey = Keys.BrowserSearch;
                    break;
                case "浏览器收藏键":
                    vkey = Keys.BrowserFavorites;
                    break;
                case "浏览器主页键":
                    vkey = Keys.BrowserHome;
                    break;
                case "卷静音键":
                    vkey = Keys.VolumeMute;
                    break;
                case "音量降低键":
                    vkey = Keys.VolumeDown;
                    break;
                case "音量增大键":
                    vkey = Keys.VolumeUp;
                    break;
                case "媒体下一曲目键":
                    vkey = Keys.MediaNextTrack;
                    break;
                case "媒体上一曲目键":
                    vkey = Keys.MediaPreviousTrack;
                    break;
                case "媒体停止键":
                    vkey = Keys.MediaStop;
                    break;
                case "在媒体播放暂停键":
                    vkey = Keys.MediaPlayPause;
                    break;
                case "启动邮件键":
                    vkey = Keys.LaunchMail;
                    break;
                case "选择媒体键 中":
                    vkey = Keys.SelectMedia;
                    break;
                case "启动应用程序1键":
                    vkey = Keys.LaunchApplication1;
                    break;
                case "启动应用程序2键":
                    vkey = Keys.LaunchApplication2;
                    break;
                case "OEM 分号键":
                    vkey = Keys.OemSemicolon;
                    break;
                case "OEM 1 键":
                    vkey = Keys.Oem1;
                    break;
                case "OEM 加上密钥":
                    vkey = Keys.Oemplus;
                    break;
                case "OEM 逗号键":
                    vkey = Keys.Oemcomma;
                    break;
                case "OEM 减号键":
                    vkey = Keys.OemMinus;
                    break;
                case "OEM 期间键":
                    vkey = Keys.OemPeriod;
                    break;
                case "OEM 问号键":
                    vkey = Keys.OemQuestion;
                    break;
                case "OEM 2 键":
                    vkey = Keys.Oem2;
                    break;
                case "OEM 颚化符键":
                    vkey = Keys.Oemtilde;
                    break;
                case "OEM 3 键":
                    vkey = Keys.Oem3;
                    break;
                case "OEM 左大括号键":
                    vkey = Keys.OemOpenBrackets;
                    break;
                case "OEM 4 键":
                    vkey = Keys.Oem4;
                    break;
                case "OEM 管道键":
                    vkey = Keys.OemPipe;
                    break;
                case "OEM 5 键":
                    vkey = Keys.Oem5;
                    break;
                case "OEM 右大括号键":
                    vkey = Keys.OemCloseBrackets;
                    break;
                case "OEM 6 键":
                    vkey = Keys.Oem6;
                    break;
                case "OEM 意见/双精度型引号密钥":
                    vkey = Keys.OemQuotes;
                    break;
                case "OEM 7 键":
                    vkey = Keys.Oem7;
                    break;
                case "OEM 8 键":
                    vkey = Keys.Oem8;
                    break;
                case "OEM 尖括号或反斜杠键":
                    vkey = Keys.OemBackslash;
                    break;
                case "OEM 102 键":
                    vkey = Keys.Oem102;
                    break;
                case "PROCESS 键键中":
                    vkey = Keys.ProcessKey;
                    break;
                case "传递 Unicode 字符":
                    vkey = Keys.Packet;
                    break;
                case "ATTN 键":
                    vkey = Keys.Attn;
                    break;
                case "CRSEL 键":
                    vkey = Keys.Crsel;
                    break;
                case "EXSEL 键":
                    vkey = Keys.Exsel;
                    break;
                case "ERASE EOF 键":
                    vkey = Keys.EraseEof;
                    break;
                case "播放键":
                    vkey = Keys.Play;
                    break;
                case "缩放键":
                    vkey = Keys.Zoom;
                    break;
                case "留待将来使用的常数":
                    vkey = Keys.NoName;
                    break;
                case "PA1 键":
                    vkey = Keys.Pa1;
                    break;
                case "OEM CLEAR 键":
                    vkey = Keys.OemClear;
                    break;
                case "密钥键代码位屏蔽":
                    vkey = Keys.KeyCode;
                    break;
                case "SHIFT 修改键":
                    vkey = Keys.Shift;
                    break;
                case "CTRL 修改键":
                    vkey = Keys.Control;
                    break;
                case "ALT 修改键":
                    vkey = Keys.Alt;
                    break;
                default:
                    vkey = Keys.None;
                    break;
            }

            return vkey;
        }
    }
}
