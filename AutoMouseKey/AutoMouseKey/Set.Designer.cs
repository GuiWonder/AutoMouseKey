
namespace AutoMouseKey
{
    partial class Set
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBoxTimer = new System.Windows.Forms.CheckBox();
            this.textBoxx = new System.Windows.Forms.TextBox();
            this.textBoxy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageM = new System.Windows.Forms.TabPage();
            this.checkBoxHotKey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMy2 = new System.Windows.Forms.TextBox();
            this.textBoxMx2 = new System.Windows.Forms.TextBox();
            this.textBoxMy = new System.Windows.Forms.TextBox();
            this.textBoxMx = new System.Windows.Forms.TextBox();
            this.comboBoxM2 = new System.Windows.Forms.ComboBox();
            this.comboBoxM1 = new System.Windows.Forms.ComboBox();
            this.tabPageK = new System.Windows.Forms.TabPage();
            this.comboBoxKey3 = new System.Windows.Forms.ComboBox();
            this.comboBoxKey2 = new System.Windows.Forms.ComboBox();
            this.comboBoxKey1 = new System.Windows.Forms.ComboBox();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.labelHelp = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageM.SuspendLayout();
            this.tabPageK.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxTimer
            // 
            this.checkBoxTimer.AutoSize = true;
            this.checkBoxTimer.Location = new System.Drawing.Point(7, 8);
            this.checkBoxTimer.Name = "checkBoxTimer";
            this.checkBoxTimer.Size = new System.Drawing.Size(96, 16);
            this.checkBoxTimer.TabIndex = 0;
            this.checkBoxTimer.Text = "当前鼠标位置";
            this.checkBoxTimer.UseVisualStyleBackColor = true;
            // 
            // textBoxx
            // 
            this.textBoxx.Enabled = false;
            this.textBoxx.Location = new System.Drawing.Point(109, 6);
            this.textBoxx.Name = "textBoxx";
            this.textBoxx.Size = new System.Drawing.Size(55, 21);
            this.textBoxx.TabIndex = 1;
            this.textBoxx.Text = "0";
            // 
            // textBoxy
            // 
            this.textBoxy.Enabled = false;
            this.textBoxy.Location = new System.Drawing.Point(170, 6);
            this.textBoxy.Name = "textBoxy";
            this.textBoxy.Size = new System.Drawing.Size(55, 21);
            this.textBoxy.TabIndex = 2;
            this.textBoxy.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择操作";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(105, 279);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPageM);
            this.tabControl.Controls.Add(this.tabPageK);
            this.tabControl.Controls.Add(this.tabPageText);
            this.tabControl.Location = new System.Drawing.Point(12, 24);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(295, 249);
            this.tabControl.TabIndex = 8;
            // 
            // tabPageM
            // 
            this.tabPageM.Controls.Add(this.checkBoxHotKey);
            this.tabPageM.Controls.Add(this.label2);
            this.tabPageM.Controls.Add(this.textBoxMy2);
            this.tabPageM.Controls.Add(this.textBoxMx2);
            this.tabPageM.Controls.Add(this.textBoxMy);
            this.tabPageM.Controls.Add(this.textBoxMx);
            this.tabPageM.Controls.Add(this.comboBoxM2);
            this.tabPageM.Controls.Add(this.comboBoxM1);
            this.tabPageM.Controls.Add(this.textBoxy);
            this.tabPageM.Controls.Add(this.textBoxx);
            this.tabPageM.Controls.Add(this.checkBoxTimer);
            this.tabPageM.Location = new System.Drawing.Point(4, 25);
            this.tabPageM.Name = "tabPageM";
            this.tabPageM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageM.Size = new System.Drawing.Size(287, 220);
            this.tabPageM.TabIndex = 1;
            this.tabPageM.Text = "模拟鼠标";
            this.tabPageM.UseVisualStyleBackColor = true;
            // 
            // checkBoxHotKey
            // 
            this.checkBoxHotKey.AutoSize = true;
            this.checkBoxHotKey.Enabled = false;
            this.checkBoxHotKey.Location = new System.Drawing.Point(7, 32);
            this.checkBoxHotKey.Name = "checkBoxHotKey";
            this.checkBoxHotKey.Size = new System.Drawing.Size(96, 16);
            this.checkBoxHotKey.TabIndex = 4;
            this.checkBoxHotKey.Text = "按F1自动输入";
            this.checkBoxHotKey.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "提示：\r\n\r\n请分别输入鼠标位置的横纵坐标。\r\n拖动时，请分别输入起始和结束两点的坐标对。";
            // 
            // textBoxMy2
            // 
            this.textBoxMy2.Location = new System.Drawing.Point(197, 93);
            this.textBoxMy2.Name = "textBoxMy2";
            this.textBoxMy2.Size = new System.Drawing.Size(50, 21);
            this.textBoxMy2.TabIndex = 2;
            this.textBoxMy2.Text = "0";
            // 
            // textBoxMx2
            // 
            this.textBoxMx2.Location = new System.Drawing.Point(141, 93);
            this.textBoxMx2.Name = "textBoxMx2";
            this.textBoxMx2.Size = new System.Drawing.Size(50, 21);
            this.textBoxMx2.TabIndex = 1;
            this.textBoxMx2.Text = "0";
            // 
            // textBoxMy
            // 
            this.textBoxMy.Location = new System.Drawing.Point(63, 93);
            this.textBoxMy.Name = "textBoxMy";
            this.textBoxMy.Size = new System.Drawing.Size(50, 21);
            this.textBoxMy.TabIndex = 2;
            this.textBoxMy.Text = "0";
            // 
            // textBoxMx
            // 
            this.textBoxMx.Location = new System.Drawing.Point(7, 93);
            this.textBoxMx.Name = "textBoxMx";
            this.textBoxMx.Size = new System.Drawing.Size(50, 21);
            this.textBoxMx.TabIndex = 1;
            this.textBoxMx.Text = "0";
            // 
            // comboBoxM2
            // 
            this.comboBoxM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxM2.FormattingEnabled = true;
            this.comboBoxM2.Items.AddRange(new object[] {
            "单击",
            "双击",
            "按下",
            "放开"});
            this.comboBoxM2.Location = new System.Drawing.Point(141, 54);
            this.comboBoxM2.Name = "comboBoxM2";
            this.comboBoxM2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxM2.TabIndex = 0;
            // 
            // comboBoxM1
            // 
            this.comboBoxM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxM1.FormattingEnabled = true;
            this.comboBoxM1.Items.AddRange(new object[] {
            "左键",
            "右键",
            "中键",
            "上滚动",
            "下滚动",
            "移动",
            "拖动"});
            this.comboBoxM1.Location = new System.Drawing.Point(7, 54);
            this.comboBoxM1.Name = "comboBoxM1";
            this.comboBoxM1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxM1.TabIndex = 0;
            // 
            // tabPageK
            // 
            this.tabPageK.Controls.Add(this.comboBoxKey3);
            this.tabPageK.Controls.Add(this.comboBoxKey2);
            this.tabPageK.Controls.Add(this.comboBoxKey1);
            this.tabPageK.Location = new System.Drawing.Point(4, 25);
            this.tabPageK.Name = "tabPageK";
            this.tabPageK.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageK.Size = new System.Drawing.Size(287, 220);
            this.tabPageK.TabIndex = 2;
            this.tabPageK.Text = "模拟键盘";
            this.tabPageK.UseVisualStyleBackColor = true;
            // 
            // comboBoxKey3
            // 
            this.comboBoxKey3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKey3.FormattingEnabled = true;
            this.comboBoxKey3.Items.AddRange(new object[] {
            "单击",
            "按下",
            "放开"});
            this.comboBoxKey3.Location = new System.Drawing.Point(3, 63);
            this.comboBoxKey3.Name = "comboBoxKey3";
            this.comboBoxKey3.Size = new System.Drawing.Size(121, 20);
            this.comboBoxKey3.TabIndex = 2;
            // 
            // comboBoxKey2
            // 
            this.comboBoxKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKey2.FormattingEnabled = true;
            this.comboBoxKey2.Items.AddRange(new object[] {
            "不按任何键",
            "鼠标左键",
            "鼠标右键按钮中",
            "CANCEL 键",
            "鼠标中键",
            "第一个 x 鼠标按钮",
            "第二个鼠标按钮 x",
            "BACKSPACE 键",
            "TAB 键",
            "LINEFEED 键",
            "CLEAR 键",
            "RETURN 键",
            "ENTER 键",
            "SHIFT 键",
            "CTRL 键",
            "ALT 键",
            "PAUSE 键",
            "CAPS LOCK 键",
            "IME Kana 模式键",
            "IME Hanguel 模式键",
            "IME Hangul 模式键",
            "IME Junja 模式键",
            "IME 最终模式键",
            "IME Hanja 模式键",
            "IME Kanji 模式键",
            "ESC 键",
            "IME convert 键",
            "IME nonconvert 键",
            "IME 接受密钥",
            "IME 接受密钥(已过时)",
            "IME 模式更改密钥",
            "SPACEBAR 键",
            "PAGE UP 键",
            "PAGE DOWN 键",
            "END 键",
            "HOME 键",
            "LEFT ARROW 键",
            "UP ARROW 键",
            "RIGHT ARROW 键",
            "DOWN ARROW 键",
            "SELECT 键",
            "PRINT 键",
            "EXECUTE 键",
            "PRINT SCREEN 键",
            "INS 键",
            "DEL 键",
            "HELP 键",
            "0 键",
            "1 键",
            "2 键",
            "3 键",
            "4 键",
            "5 键",
            "6 键",
            "7 键",
            "8 键",
            "9 键",
            "A 键",
            "B 键",
            "C 键",
            "D 键",
            "E 键",
            "F 键",
            "G 键",
            "H 键",
            "I 键",
            "J 键",
            "K 键",
            "L 键",
            "M 键",
            "N 键",
            "O 键",
            "P 键",
            "Q 键",
            "R 键",
            "S 键",
            "T 键",
            "U 键",
            "V 键",
            "W 键",
            "X 键",
            "Y 键",
            "Z 键",
            "左 Windows 徽标键",
            "右 Windows 徽标键",
            "应用程序密钥",
            "计算机休眠键",
            "数字键盘上的 0 键",
            "数字键盘上的 1 键",
            "数字键盘上的 2 键",
            "数字键盘上的 3 键",
            "数字键盘上的 4 键",
            "数字键盘上的 5 键",
            "数字键盘上的 6 键",
            "数字键盘上的 7 键",
            "数字键盘上的 8 键",
            "数字键盘上的 9 键",
            "乘号键",
            "加号键",
            "分隔符键",
            "减号键",
            "句点键",
            "除号键",
            "F1 键",
            "F2 键",
            "F3 键",
            "F4 键",
            "F5 键",
            "F6 键",
            "F7 键",
            "F8 键",
            "F9 键",
            "F10 键",
            "F11 键",
            "F12 键",
            "F13 键",
            "F14 键",
            "F15 键",
            "F16 键",
            "F17 键",
            "F18 键",
            "F19 键",
            "F20 键",
            "F21 键",
            "F22 键",
            "F23 键",
            "F24 键",
            "NUM LOCK 键",
            "SCROLL LOCK 键",
            "左的 SHIFT 键",
            "右 SHIFT 键",
            "左 CTRL 键",
            "右 CTRL 键",
            "左 ALT 键",
            "右 ALT 键",
            "浏览器后退键",
            "浏览器前进键",
            "浏览器刷新键",
            "浏览器停止键",
            "浏览器搜索键",
            "浏览器收藏键",
            "浏览器主页键",
            "卷静音键",
            "音量降低键",
            "音量增大键",
            "媒体下一曲目键",
            "媒体上一曲目键",
            "媒体停止键",
            "在媒体播放暂停键",
            "启动邮件键",
            "选择媒体键 中",
            "启动应用程序1键",
            "启动应用程序2键",
            "OEM 分号键",
            "OEM 1 键",
            "OEM 加上密钥",
            "OEM 逗号键",
            "OEM 减号键",
            "OEM 期间键",
            "OEM 问号键",
            "OEM 2 键",
            "OEM 颚化符键",
            "OEM 3 键",
            "OEM 左大括号键",
            "OEM 4 键",
            "OEM 管道键",
            "OEM 5 键",
            "OEM 右大括号键",
            "OEM 6 键",
            "OEM 意见/双精度型引号密钥",
            "OEM 7 键",
            "OEM 8 键",
            "OEM 尖括号或反斜杠键",
            "OEM 102 键",
            "PROCESS 键键中",
            "传递 Unicode 字符",
            "ATTN 键",
            "CRSEL 键",
            "EXSEL 键",
            "ERASE EOF 键",
            "播放键",
            "缩放键",
            "留待将来使用的常数",
            "PA1 键",
            "OEM CLEAR 键",
            "密钥键代码位屏蔽",
            "SHIFT 修改键",
            "CTRL 修改键",
            "ALT 修改键"});
            this.comboBoxKey2.Location = new System.Drawing.Point(139, 21);
            this.comboBoxKey2.Name = "comboBoxKey2";
            this.comboBoxKey2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxKey2.TabIndex = 2;
            // 
            // comboBoxKey1
            // 
            this.comboBoxKey1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKey1.FormattingEnabled = true;
            this.comboBoxKey1.Items.AddRange(new object[] {
            "无组合键",
            "Ctr",
            "Shift",
            "Alt",
            "Ctr+Shift",
            "Ctr+Alt",
            "Alt+Shift",
            "Ctr+Shift+Alt"});
            this.comboBoxKey1.Location = new System.Drawing.Point(3, 21);
            this.comboBoxKey1.Name = "comboBoxKey1";
            this.comboBoxKey1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxKey1.TabIndex = 1;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.labelHelp);
            this.tabPageText.Controls.Add(this.textBoxText);
            this.tabPageText.Location = new System.Drawing.Point(4, 25);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Size = new System.Drawing.Size(287, 220);
            this.tabPageText.TabIndex = 3;
            this.tabPageText.Text = "连续键盘";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.labelHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelHelp.Location = new System.Drawing.Point(247, 208);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(11, 12);
            this.labelHelp.TabIndex = 9;
            this.labelHelp.Text = "?";
            // 
            // textBoxText
            // 
            this.textBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxText.Location = new System.Drawing.Point(0, 0);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxText.Size = new System.Drawing.Size(287, 220);
            this.textBoxText.TabIndex = 0;
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(565, 328);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Set";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务设置";
            this.tabControl.ResumeLayout(false);
            this.tabPageM.ResumeLayout(false);
            this.tabPageM.PerformLayout();
            this.tabPageK.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTimer;
        private System.Windows.Forms.TextBox textBoxx;
        private System.Windows.Forms.TextBox textBoxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageM;
        private System.Windows.Forms.TabPage tabPageK;
        private System.Windows.Forms.ComboBox comboBoxM1;
        private System.Windows.Forms.TextBox textBoxMx;
        private System.Windows.Forms.TextBox textBoxMy;
        private System.Windows.Forms.ComboBox comboBoxKey2;
        private System.Windows.Forms.ComboBox comboBoxKey1;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.CheckBox checkBoxHotKey;
        private System.Windows.Forms.TextBox textBoxMy2;
        private System.Windows.Forms.TextBox textBoxMx2;
        private System.Windows.Forms.ComboBox comboBoxM2;
        private System.Windows.Forms.ComboBox comboBoxKey3;
    }
}