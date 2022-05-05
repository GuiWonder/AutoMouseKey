using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace AutoMouseKey
{
    public partial class FormMain : Form
    {
        public static string[] mkinfo = new string[4];
        readonly string cfgfile;// = "AutoMouseKey.xml";
        int waittime, count;
        bool pause, cancel;
        Set set = new Set();
        string working;

        public FormMain()
        {
            //string apppath = Application.ExecutablePath;
            string appdir = Application.StartupPath.TrimEnd('\\');
            string appname = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            cfgfile = appdir + "\\" + appname + ".xml";
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            comboBoxHotKey.SelectedIndex = 0;
            buttonAdd.Click += ButtonAdd_Click;
            buttonEdit.Click += ButtonEdit_Click;
            buttonInsert.Click += ButtonInsert_Click;
            buttonRemove.Click += ButtonRemove_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonUp.Click += ButtonUp_Click;
            buttonDown.Click += ButtonDown_Click;
            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonLoad.Click += ButtonLoad_Click;
            checkBoxTopmost.CheckedChanged += CheckBoxTopmost_CheckedChanged;
            listView.Columns.Add("启用", 40, HorizontalAlignment.Left);
            listView.Columns.Add("类型", 60, HorizontalAlignment.Left);
            listView.Columns.Add("参数1", 90, HorizontalAlignment.Left);
            listView.Columns.Add("参数2", 90, HorizontalAlignment.Left);
            listView.Columns.Add("参数3", 210, HorizontalAlignment.Left);
            ReadCfg(cfgfile, true);
        }

        #region cfg
        private void ReadCfg(string xmlfile, bool q)
        {
            if (!System.IO.File.Exists(xmlfile))
            {
                return;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlfile);
                numericUpDownTime.Value = int.Parse(doc.SelectSingleNode("Config/Setting/Time").InnerText);
                numericUpDownCount.Value = int.Parse(doc.SelectSingleNode("Config/Setting/Count").InnerText);
                comboBoxHotKey.SelectedItem = doc.SelectSingleNode("Config/Setting/Hotkey").InnerText;
                XmlNodeList datas = doc.SelectNodes("Config/Datas/Data");
                foreach (XmlNode item in datas)
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.Checked = bool.Parse(item.Attributes["On"].Value);
                    lvitem.SubItems.Add(item.SelectSingleNode("Type").InnerText);
                    lvitem.SubItems.Add(item.SelectSingleNode("Set1").InnerText);
                    lvitem.SubItems.Add(item.SelectSingleNode("Set2").InnerText);
                    lvitem.SubItems.Add(item.SelectSingleNode("Set3").InnerText);
                    listView.Items.Add(lvitem);
                }
            }
            catch (Exception ex)
            {
                if (!q)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void WriteCfg(string xmlfile)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement cfg = doc.CreateElement("Config");
            doc.AppendChild(cfg);
            XmlElement set = doc.CreateElement("Setting");
            cfg.AppendChild(set);
            XmlElement time = doc.CreateElement("Time");
            time.InnerText = numericUpDownTime.Value.ToString();
            set.AppendChild(time);
            XmlElement count = doc.CreateElement("Count");
            count.InnerText = numericUpDownCount.Value.ToString();
            set.AppendChild(count);
            XmlElement hotkey = doc.CreateElement("Hotkey");
            hotkey.InnerText = comboBoxHotKey.Text;
            set.AppendChild(hotkey);
            XmlElement datas = doc.CreateElement("Datas");
            cfg.AppendChild(datas);
            foreach (ListViewItem item in listView.Items)
            {
                XmlElement data = doc.CreateElement("Data");
                data.SetAttribute("On", item.Checked.ToString());
                XmlElement type = doc.CreateElement("Type");
                type.InnerText = item.SubItems[1].Text;
                XmlElement set1 = doc.CreateElement("Set1");
                set1.InnerText = item.SubItems[2].Text;
                XmlElement set2 = doc.CreateElement("Set2");
                set2.InnerText = item.SubItems[3].Text;
                XmlElement set3 = doc.CreateElement("Set3");
                set3.InnerText = item.SubItems[4].Text;
                data.AppendChild(type);
                data.AppendChild(set1);
                data.AppendChild(set2);
                data.AppendChild(set3);
                datas.AppendChild(data);
            }
            doc.Save(xmlfile);
        }
        #endregion

        #region mk
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            cancel = true;
            pause = false;
            buttonStart.Enabled = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count < 1)
            {
                return;
            }
            WriteCfg(cfgfile);
            waittime = (int)numericUpDownTime.Value;
            count = (int)numericUpDownCount.Value;
            pause = true;
            cancel = false;
            Keys hotKey = Event.GetKeys(comboBoxHotKey.Text);
            if (!Event.RegisterHotKey(this.Handle, 1, 0, hotKey))
            {
                MessageBox.Show("HotKey Failed!");
                buttonStart.Enabled = true;
                return;
            }
            else
            {
                Text = "准备就绪，请按快捷键";
            }
            buttonStart.Enabled = false;
            System.Threading.Thread thread = new System.Threading.Thread(MainThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void MainThread()
        {
            for (int i = 0; i < count; i++)
            {
                working = i + "/" + count;
                if (cancel)
                {
                    break;
                }
                foreach (ListViewItem item in listView.CheckedItems)
                {
                    Application.DoEvents();
                    while (pause)
                    {
                        System.Threading.Thread.Sleep(10);
                        Application.DoEvents();
                    }
                    if (cancel)
                    {
                        break;
                    }
                    Text = "工作中... " + working;
                    System.Threading.Thread.Sleep(waittime);
                    mkinfo[0] = item.SubItems[1].Text;
                    mkinfo[1] = item.SubItems[2].Text;
                    mkinfo[2] = item.SubItems[3].Text;
                    mkinfo[3] = item.SubItems[4].Text;
                    RunMouseKey();
                }
            }
            BeginInvoke(new Action(delegate
            {
                if (!Event.UnregisterHotKey(Handle, 1))
                    MessageBox.Show("Un HotKey Faild!");
                else
                    Text = "鼠键模拟器";
                buttonStart.Enabled = true;
            }));
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                if (m.WParam.ToString().Equals("1")) //(m.WParam.ToInt32() == 1)
                {
                    pause = !pause;
                    if (pause)
                    {
                        Text = "暂停中..." + working;
                    }
                    else
                    {
                        Text = "工作中... " + working;
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void RunMouseKey()
        {
            if (mkinfo[0] == "模拟鼠标")
            {
                if (mkinfo[1] == "拖动")
                {
                    int x1 = int.Parse(mkinfo[2].Split(',')[0]);
                    int y1 = int.Parse(mkinfo[2].Split(',')[1]);
                    int x2 = int.Parse(mkinfo[3].Split(',')[0]);
                    int y2 = int.Parse(mkinfo[3].Split(',')[1]);
                    Event.MouseDrags(x1, y1, x2, y2);

                }
                else if (mkinfo[1] == "移动" || mkinfo[1] == "上滚动" || mkinfo[1] == "下滚动")
                {
                    int x = int.Parse(mkinfo[3].Split(',')[0]);
                    int y = int.Parse(mkinfo[3].Split(',')[1]);
                    Event.SetCursorPos(x, y);
                    Event.MouseEvents(mkinfo[1], mkinfo[2]);
                }
                else
                {
                    int x = int.Parse(mkinfo[3].Split(',')[0]);
                    int y = int.Parse(mkinfo[3].Split(',')[1]);
                    Event.SetCursorPos(x, y);
                    Event.MouseEvents(mkinfo[1], mkinfo[2]);
                }
            }
            else if (mkinfo[0] == "模拟键盘")
            {
                Event.KeyClicks(Event.GetKeys(mkinfo[2]), mkinfo[1].Contains("Ctr"), mkinfo[1].Contains("Alt"), mkinfo[1].Contains("Shift"), mkinfo[3]);

            }
            else if (mkinfo[0] == "连续键盘")
            {
                Event.CloseCapslk();
                string text = mkinfo[2].Replace("\r\n", "回").Replace("\n", "回").Replace("\r", "回");
                char[] ch = text.ToArray();
                foreach (char item in ch)
                {
                    Application.DoEvents();
                    while (pause)
                    {
                        System.Threading.Thread.Sleep(10);
                        Application.DoEvents();
                    }
                    if (cancel)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(waittime);
                    Keys evk = Event.GetCharKey(item, out bool ShiftKey);
                    Event.KeyClicks(evk, false, false, ShiftKey, "单击");
                }
            }
        }
        #endregion

        #region gui

        private void CheckBoxTopmost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBoxTopmost.Checked;
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                if (listView.SelectedItems[0].Index < listView.Items.Count - 1)
                {
                    ListViewItem listViewItem = listView.SelectedItems[0];
                    listView.Items.RemoveAt(i);
                    listView.Items.Insert(i + 1, listViewItem);
                }
            }
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                if (i > 0)
                {
                    ListViewItem listViewItem = listView.SelectedItems[0];
                    listView.Items.RemoveAt(i);
                    listView.Items.Insert(i - 1, listViewItem);
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                listView.SelectedItems[0].Remove();
                if (i < listView.Items.Count)
                {
                    listView.Items[i].Selected = true;
                }
                else if (listView.Items.Count > 0)
                {
                    listView.Items[i - 1].Selected = true;
                }
            }
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                set.TopMost = TopMost;
                if (set.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = new ListViewItem();
                    item.Checked = true;
                    item.SubItems.AddRange(mkinfo);
                    listView.Items.Insert(listView.SelectedItems[0].Index, item);
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                mkinfo = new string[] { listView.SelectedItems[0].SubItems[1].Text, listView.SelectedItems[0].SubItems[2].Text, listView.SelectedItems[0].SubItems[3].Text, listView.SelectedItems[0].SubItems[4].Text };
                set.TopMost = TopMost;
                set.SetTodo();
                if (set.ShowDialog() == DialogResult.OK)
                {
                    listView.SelectedItems[0].SubItems[1].Text = mkinfo[0];
                    listView.SelectedItems[0].SubItems[2].Text = mkinfo[1];
                    listView.SelectedItems[0].SubItems[3].Text = mkinfo[2];
                    listView.SelectedItems[0].SubItems[4].Text = mkinfo[3];
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            set.TopMost = TopMost;
            if (set.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem();
                item.Checked = true;
                item.SubItems.AddRange(mkinfo);
                listView.Items.Add(item);
                listView.Items[listView.Items.Count - 1].Selected = true;
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "配置文件|*.xml|所有文件|*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ReadCfg(openFileDialog.FileName, false);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "配置文件|*.xml|所有文件|*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    WriteCfg(saveFileDialog.FileName);
                }
            }
        }
        #endregion
    }
}
