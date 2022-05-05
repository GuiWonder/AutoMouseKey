using System;
using System.Windows.Forms;

namespace AutoMouseKey
{
    public partial class Set : Form
    {
        public static string setresult;
        public Set()
        {
            InitializeComponent();
            checkBoxTimer.CheckedChanged += CheckBoxTimer_CheckedChanged;
            checkBoxHotKey.CheckedChanged += CheckBoxHotKey_CheckedChanged;
            buttonOK.Click += ButtonOK_Click;
            labelHelp.Click += LabelHelp_Click;
            timer.Tick += Timer_Tick;
            FormClosing += Set_FormClosing;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            comboBoxM1.SelectedIndexChanged += ComboBoxM1_SelectedIndexChanged;
            //TopMost = FormMain.topmost;
            tabControl.SelectedIndex = 0;
            comboBoxM1.SelectedIndex = 0;
            comboBoxM2.SelectedIndex = 0;
            comboBoxKey1.SelectedIndex = 0;
            comboBoxKey2.SelectedIndex = 0;
            comboBoxKey3.SelectedIndex = 0;
            textBoxMx.Text = "0";
            textBoxMy.Text = "0";
            textBoxText.Text = "";
            SetTodo();
        }

        private void ComboBoxM1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxM2.Enabled = comboBoxM1.SelectedIndex < 3;
            textBoxMx2.Enabled = (string)comboBoxM1.SelectedItem == "拖动";
            textBoxMy2.Enabled = (string)comboBoxM1.SelectedItem == "拖动";
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxTimer.Checked = false;
        }

        private void Set_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkBoxTimer.Checked = false;
            //checkBoxHotKey.Checked = false;
        }

        private void CheckBoxHotKey_CheckedChanged(object sender, EventArgs e)
        {
            RegHotKey(checkBoxHotKey.Checked);
        }

        private void RegHotKey(bool on)
        {
            if (on)
            {
                if (!Event.RegisterHotKey(Handle, 1, 0, Keys.F1))
                {
                    MessageBox.Show("热键开启失败！");
                    return;
                }
            }
            else if (!Event.UnregisterHotKey(Handle, 1))
            {
                MessageBox.Show("热键关闭失败！");
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                if (comboBoxM1.Text == "拖动" && (textBoxMx2.Focused || textBoxMy2.Focused))
                {
                    textBoxMx2.Text = textBoxx.Text;
                    textBoxMy2.Text = textBoxy.Text;
                }
                else
                {
                    textBoxMx.Text = textBoxx.Text;
                    textBoxMy.Text = textBoxy.Text;
                }
            }
            base.WndProc(ref m);
        }

        private void LabelHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        public void SetTodo()
        {
            if (FormMain.mkinfo[0] == "模拟鼠标")
            {
                tabControl.SelectedIndex = 0;
                comboBoxM1.SelectedItem = FormMain.mkinfo[1];
                if (FormMain.mkinfo[1] == "拖动")
                {
                    string[] xy1 = FormMain.mkinfo[2].Split(',');
                    textBoxMx.Text = xy1[0];
                    textBoxMy.Text = xy1[1];
                    string[] xy2 = FormMain.mkinfo[3].Split(',');
                    textBoxMx.Text = xy2[0];
                    textBoxMy.Text = xy2[1];
                }
                else
                {
                    string[] xy = FormMain.mkinfo[3].Split(',');
                    textBoxMx.Text = xy[0];
                    textBoxMy.Text = xy[1];
                    if (FormMain.mkinfo[2] == "左键" || FormMain.mkinfo[2] == "右键" || FormMain.mkinfo[2] == "中键")
                    {
                        comboBoxM2.SelectedItem = FormMain.mkinfo[2];
                    }
                }
            }
            else if (FormMain.mkinfo[0] == "模拟键盘")
            {
                tabControl.SelectedIndex = 1;
                comboBoxKey1.SelectedItem = FormMain.mkinfo[1];
                comboBoxKey2.SelectedItem = FormMain.mkinfo[2];
                comboBoxKey3.SelectedItem = FormMain.mkinfo[3];
            }
            else if (FormMain.mkinfo[0] == "连续键盘")
            {
                tabControl.SelectedIndex = 2;
                textBoxText.Text = FormMain.mkinfo[3].Replace("回", "\r\n");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Event.GetCursorPos(out Event.POINT p);
            textBoxx.Text = p.X.ToString();
            textBoxy.Text = p.Y.ToString();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string[] result = new string[4];
            if (tabControl.SelectedIndex == 0)
            {
                result[0] = "模拟鼠标";
                try
                {
                    result[1] = (string)comboBoxM1.SelectedItem;
                    if (result[1] == "拖动")
                    {
                        int x1 = int.Parse(textBoxMx.Text);
                        int y1 = int.Parse(textBoxMy.Text);
                        int x2 = int.Parse(textBoxMx2.Text);
                        int y2 = int.Parse(textBoxMy2.Text);
                        result[2] = $"{x1},{y1}";
                        result[3] = $"{x2},{y2}";
                    }
                    else
                    {
                        int x = int.Parse(textBoxMx.Text);
                        int y = int.Parse(textBoxMy.Text);
                        result[3] = $"{x},{y}";
                        if (result[1] == "移动")
                        {
                            result[2] = "移动至";
                        }
                        else if (result[1] == "上滚动" || result[1] == "下滚动")
                        {
                            result[2] = "滚动";
                        }
                        else
                        {
                            result[2] = (string)comboBoxM2.SelectedItem;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("输入格式不正确");
                    return;
                }
            }
            else if (tabControl.SelectedIndex == 1)
            {
                result = new string[] { "模拟键盘", (string)comboBoxKey1.SelectedItem, (string)comboBoxKey2.SelectedItem, (string)comboBoxKey3.SelectedItem };
            }
            else if (tabControl.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(textBoxText.Text))
                {
                    MessageBox.Show("内容不能为空。");
                    return;
                }
                else
                {
                    result = new string[] { "连续键盘", "输入", "内容", textBoxText.Text.Replace("\r\n", "回").Replace("\n", "回").Replace("\r", "回"), "" };
                }
            }
            FormMain.mkinfo = result;
            DialogResult = DialogResult.OK;
        }

        private void CheckBoxTimer_CheckedChanged(object sender, EventArgs e)
        {
            textBoxx.Enabled = checkBoxTimer.Checked;
            textBoxy.Enabled = checkBoxTimer.Checked;
            timer.Enabled = checkBoxTimer.Checked;
            checkBoxHotKey.Enabled = checkBoxTimer.Checked;
            checkBoxHotKey.Checked = false;
        }
    }
}
