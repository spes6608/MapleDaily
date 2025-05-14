using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static System.Collections.Specialized.BitVector32;


namespace MapleDaily
{
    public partial class Form1 : Form
    {
        private bool IsDone;
        private string SettingPath;
        private string SignPath;
        private bool OnlyWeekUnchecked;

        public Form1()
        {
            InitializeComponent();
            SettingPath = System.Environment.CurrentDirectory + ("\\Setting.ini");
            //讀取設定檔
            LoadSetting();
            // 獲取當前年份和月份
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            // 清除之前的日曆
            pnlCalendar.Controls.Clear();
            IsDone = false;
            OnlyWeekUnchecked = false;
            // 繪製當前月份的日曆
            DrawCalendar(year, month);
            CheckItemRefresh(DateTime.Now.ToString("yyyyMMdd"));
            //偵測簽到檔大小
            lbSettingFileSize.Text = CheckFileSize(SignPath);
        }

        private void DrawCalendar(int year, int month)
        {
            //計算每個單元格的大小
            int cellWidth = pnlCalendar.Width / 7;
            int cellHeight = pnlCalendar.Height / 7;

            //繪製年分月份標題
            string YearMonth = $"{year}/{month}";
            Label lblYear = new Label
            {
                Text = YearMonth,
                Size = new Size(pnlCalendar.Width, cellHeight),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16, FontStyle.Bold)
            };
            pnlCalendar.Controls.Add(lblYear);

            //繪製星期標題
            string[] days = { "日", "一", "二", "三", "四", "五", "六" };
            for (int i = 0; i < days.Length; i++)
            {
                Label lblDay = new Label
                {
                    Text = days[i],
                    Size = new Size(cellWidth, cellHeight),
                    Location = new Point(i * cellWidth, cellHeight),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlCalendar.Controls.Add(lblDay);
            }

            //繪製日期
            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDay = (int)firstDay.DayOfWeek;
            DateTime today = DateTime.Today;
            for (int i = 0; i < daysInMonth; i++)
            {
                int currentDay = i + 1;
                Label lblDate = new Label
                {
                    Text = currentDay.ToString("D2"),
                    Size = new Size(cellWidth, cellHeight),
                    Location = new Point((i + startDay) % 7 * cellWidth, (i + startDay) / 7 * cellHeight + cellHeight * 2),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = currentDay,
                };
                //把今天日期標上紅框
                if (year == today.Year && month == today.Month && (i + 1) == today.Day)
                {
                    lblDate.ForeColor = Color.IndianRed;
                    lblDate.Font = new Font(lblDate.Font, FontStyle.Bold);
                    lblDate.BackColor = Color.LightYellow;
                    lblDate.Padding = new Padding(1);
                    lblDate.BorderStyle = BorderStyle.FixedSingle;
                }
                //綁定OnClick事件
                lblDate.Click += new EventHandler(DayLabel_Click);
                //綁定繪圖事件
                lblDate.Paint += (sender, e) => LabelDay_Paint(sender, e);
                pnlCalendar.Controls.Add(lblDate);
            }
        }
        private void DayLabel_Click(object sender, EventArgs e)
        {
            Label ClickedLabel = sender as Label;

            if (ClickedLabel != null)
            {
                string Today = DateTime.Now.ToString("yyyyMM") + ClickedLabel.Text;
                CheckItemRefresh(Today);
            }
        }
        private void CheckItemRefresh(string Date)
        {
            pnlCheckItem.Controls.Clear();
            //每日
            foreach (var item in ckblDaily.Items)
            {
                bool IsSign = ReadBool(SignPath, Date, item.ToString());
                //bool exists = pnlCheckItem.Controls.OfType<CheckBox>().Any(cb => cb.Text == item.ToString());
                //checkboxlist比較麻煩 要用index去獲得狀態
                int index = ckblDaily.Items.IndexOf(item);
                bool IsCheck = ckblDaily.GetItemChecked(index);
                //未存在在每日清單中&有勾選的項目才新增
                if (IsCheck)
                {
                    CheckBox newCheckBox = new CheckBox();
                    newCheckBox.Text = item.ToString();
                    newCheckBox.AutoSize = true;
                    newCheckBox.Location = new Point(10, pnlCheckItem.Controls.Count * 30);
                    newCheckBox.Checked = IsSign;
                    pnlCheckItem.Controls.Add(newCheckBox);
                }
            }
            //每周
            var IniData = ReadIniFile(SignPath);
            DateTime DateTrans;
            DateTime startOfWeek = new DateTime();
            DateTime endOfWeek = new DateTime();
            if (DateTime.TryParseExact(Date, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTrans))
            {
                int DaysSinceThursday = (DateTrans.DayOfWeek >= DayOfWeek.Thursday)
                                                    ? (int)DateTrans.DayOfWeek - (int)DayOfWeek.Thursday : (7 - ((int)DayOfWeek.Thursday - (int)DateTrans.DayOfWeek));
                //找到這個週期的開始（上週四）
                startOfWeek = DateTrans.AddDays(-DaysSinceThursday);
                //該週的結束日（從星期四開始到下週三結束）
                endOfWeek = startOfWeek.AddDays(6);
            }

            foreach (var item in ckblWeekly.Items)
            {
                string ItemText = "周-" + item.ToString();
                bool IsWeeklyChecked = false;
                //檢查在這個週期內的所有日期，該項目的勾選狀態
                foreach (var section in IniData)
                {
                    DateTime sectionDate;
                    if (DateTime.TryParseExact(section.Key, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sectionDate)
                        && sectionDate >= startOfWeek && sectionDate <= endOfWeek)
                    {
                        if (section.Value.ContainsKey(ItemText) && section.Value[ItemText] == "True")
                        {
                            IsWeeklyChecked = true;
                            break; //如果在週期內有一天勾選了該項目，就可以停止檢查了
                        }
                    }
                }
                //bool exists = pnlCheckItem.Controls.OfType<CheckBox>().Any(cb => cb.Text == ItemText.ToString());
                //checkboxlist比較麻煩 要用index去獲得狀態
                int index = ckblWeekly.Items.IndexOf(item);
                bool IsCheck = ckblWeekly.GetItemChecked(index);
                //未存在在每日清單中&有勾選的項目才新增
                if (IsCheck)
                {
                    CheckBox newCheckBox = new CheckBox();
                    newCheckBox.Text = ItemText;
                    newCheckBox.AutoSize = true;
                    newCheckBox.Location = new Point(10, pnlCheckItem.Controls.Count * 30);
                    newCheckBox.Checked = IsWeeklyChecked;

                    pnlCheckItem.Controls.Add(newCheckBox);
                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CheckItemRefresh(DateTime.Now.ToString("yyyyMMdd"));
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            IsDone = true;
            OnlyWeekUnchecked = false;
            IsDone = pnlCheckItem.Controls
                                 .OfType<CheckBox>()
                                 .All(checkBox => checkBox.Checked);
            if (!IsDone)
            {
                OnlyWeekUnchecked = pnlCheckItem.Controls
                             .OfType<CheckBox>()
                             .Where(checkBox => !checkBox.Checked)
                             .All(checkBox => checkBox.Text.Contains("周-"));
            }
            else
                OnlyWeekUnchecked = false;  //如果都簽到完成就清空這個flag
            //將簽到結果記錄下來
            if (SignPath != "")
            {
                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                string sectionHeader = $"[{currentDate}]";
                bool insideSection = false;
                bool CycleSection = false;

                //使用暫時檔案來寫入修改後的資料
                string tempFile = Path.GetTempFileName();

                //計算當周周期
                DateTime DateTrans;
                DateTime startOfWeek = new DateTime();
                DateTime endOfWeek = new DateTime();
                if (DateTime.TryParseExact(currentDate, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTrans))
                {
                    int DaysSinceThursday = (DateTrans.DayOfWeek >= DayOfWeek.Thursday)
                                                        ? (int)DateTrans.DayOfWeek - (int)DayOfWeek.Thursday : (7 - ((int)DayOfWeek.Thursday - (int)DateTrans.DayOfWeek));
                    //找到這個週期的開始（上週四）
                    startOfWeek = DateTrans.AddDays(-DaysSinceThursday);
                    //該週的結束日（從星期四開始到下週三結束）
                    endOfWeek = startOfWeek.AddDays(6);
                }

                var updateCheckboxes = new Dictionary<string, bool>();
                //將當前的周-checkbox狀態加入到字典
                foreach (Control control in pnlCheckItem.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Text.Contains("周-"))
                    {
                        updateCheckboxes[checkBox.Text] = checkBox.Checked;
                    }
                }

                DateTime sectionDate;
                using (StreamReader reader = new StreamReader(SignPath, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(tempFile, false, Encoding.UTF8))
                {
                    string line;
                    //逐行讀取文件
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            if (DateTime.TryParseExact(line.Trim('[', ']'), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sectionDate)
                                && sectionDate >= startOfWeek && sectionDate <= endOfWeek)
                                CycleSection = true;
                            else
                                CycleSection = false;

                            insideSection = line == sectionHeader;
                            if (insideSection)
                            {
                                continue;   //跳過舊的當日資料
                            }
                            if (CycleSection)
                            {
                                writer.WriteLine(line); //這行是日期行，直接寫回
                                continue; //跳到下一行
                            }
                        }
                        //如果不在目標section範圍內，就寫回原內容
                        if (!insideSection)
                        {
                            if (CycleSection)
                            {
                                // 這行是項目行
                                string[] parts = line.Split('=');
                                if (parts.Length == 2 && updateCheckboxes.ContainsKey(parts[0]))
                                {
                                    //如果是要更新的checkbox，則更新狀態
                                    writer.WriteLine($"{parts[0]}={updateCheckboxes[parts[0]]}");
                                }
                                else if (parts[0] == "Done")    //更新Done狀態
                                {
                                    if (!OnlyWeekUnchecked && parts[1] == "3")    //周任完成且每日都打勾了
                                        writer.WriteLine("Done=2");
                                    else if (OnlyWeekUnchecked && parts[1] == "2")   //周任沒完成且每日都打勾了
                                        writer.WriteLine("Done=3");
                                    else
                                        writer.WriteLine(line);

                                }
                                else
                                {
                                    //不需更新就寫回原內容
                                    writer.WriteLine(line);
                                }
                            }
                            else
                                writer.WriteLine(line);
                        }
                    }
                    //在文件末尾寫入新section
                    writer.WriteLine(sectionHeader);
                    foreach (Control control in pnlCheckItem.Controls)
                    {
                        if (control is CheckBox checkBox)
                        {
                            writer.WriteLine($"{checkBox.Text}={checkBox.Checked}");
                        }
                    }
                    if (OnlyWeekUnchecked)
                        writer.WriteLine("Done=3");//3表示周任未完成
                    else
                        writer.WriteLine(IsDone ? "Done=2" : "Done=1");
                }

                // 替換原始檔案
                File.Delete(SignPath);
                File.Move(tempFile, SignPath);
            }
            else
                MessageBox.Show("請先設定好簽到檔路徑!!");

            int today = DateTime.Today.Day;
            foreach (Control control in pnlCalendar.Controls)
            {
                if (control is Label labelDay)
                {
                    labelDay.Invalidate(); // 觸發重新繪製
                    labelDay.Update();     // 更新控制項
                }
            }
            if (IsDone)
                MessageBox.Show("好MS寶簽到完成~");
            else
                MessageBox.Show("請繼續坐牢^^");
        }

        private void LoadSetting()
        {
            if (!File.Exists(SettingPath))  //沒有就新增檔案
                File.Create(SettingPath).Close();

            //載入每日項目
            int Index = ReadValue(SettingPath, "CheckBox_Daily", "Index");
            List<string> ckblItem = new List<string>();
            ckblItem = ReadAllKeys("CheckBox_Daily");
            ckblDaily.Items.Clear();
            for (int i = 0; i < Index; i++)
            {
                ckblDaily.Items.Add(ckblItem[i]);
                ckblDaily.SetItemChecked(i, ReadBool(SettingPath, "CheckBox_Daily", ckblItem[i]));
            }
            //載入每周項目
            Index = ReadValue(SettingPath, "CheckBox_Weekly", "Index");
            ckblItem = ReadAllKeys("CheckBox_Weekly");
            ckblWeekly.Items.Clear();
            for (int i = 0; i < Index; i++)
            {
                ckblWeekly.Items.Add(ckblItem[i]);
                ckblWeekly.SetItemChecked(i, ReadBool(SettingPath, "CheckBox_Weekly", ckblItem[i]));
            }
            //載入簽到檔路徑
            tbSignPath.Text = ReadString(SettingPath, "Save_Path", "Path");
            if (tbSignPath.Text == "" || !Directory.Exists(tbSignPath.Text))//空路徑or路徑不存在
                tbSignPath.Text = System.Environment.CurrentDirectory;
            SignPath = tbSignPath.Text + ("\\CheckFile.ini");
            if (!File.Exists(SignPath))
            {
                using (FileStream fs = File.Create(SignPath))
                {
                    //用using create完後自動關閉
                }
            }
        }

        private void SaveSetting()
        {
            string iniPath = System.Environment.CurrentDirectory + ("\\Setting.ini");
            using (StreamWriter writer = new StreamWriter(iniPath, false, Encoding.UTF8))
            {
                // 每日項目
                writer.WriteLine("[CheckBox_Daily]");
                for (int i = 0; i < ckblDaily.Items.Count; i++)
                {
                    writer.WriteLine($"{ckblDaily.Items[i]}={ckblDaily.GetItemChecked(i)}");
                }
                writer.WriteLine($"Index={ckblDaily.Items.Count}");

                // 每周項目
                writer.WriteLine("[CheckBox_Weekly]");
                for (int i = 0; i < ckblWeekly.Items.Count; i++)
                {
                    writer.WriteLine($"{ckblWeekly.Items[i]}={ckblWeekly.GetItemChecked(i)}");
                }
                writer.WriteLine($"Index={ckblWeekly.Items.Count}");
                //簽到檔路徑
                writer.WriteLine("[Save_Path]");
                writer.WriteLine($"Path={tbSignPath.Text}");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //儲存設定
            if (!File.Exists(SettingPath))  //沒有就新增檔案
                File.Create(SettingPath).Close();
            SaveSetting();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "請選擇簽到檔存檔路徑";
            dialog.SelectedPath = System.Environment.CurrentDirectory;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "資料夾路徑不能為空", "提示");
                    return;
                }
                string s = dialog.SelectedPath.Substring(dialog.SelectedPath.Length - 2, 2);
                if (dialog.SelectedPath.Substring(dialog.SelectedPath.Length - 2, 2) != "\\")
                {
                    tbSignPath.Text = dialog.SelectedPath + "\\";
                }
                SignPath = tbSignPath.Text;
            }
        }

        private void btnNewdaily_Click(object sender, EventArgs e)
        {
            string NewDaily = tbDaily.Text;
            ckblDaily.Items.Add(NewDaily, false);
            tbDaily.Text = "";
        }

        private void btnNewWeekly_Click(object sender, EventArgs e)
        {
            string NewWeekly = tbWeekly.Text;
            ckblWeekly.Items.Add(NewWeekly, false);
            tbWeekly.Text = "";
        }

        private void btnDeleteDaily_Click(object sender, EventArgs e)
        {
            if (ckblDaily.SelectedItem != null)
            {
                ckblDaily.Items.Remove(ckblDaily.SelectedItem);
            }
        }

        private void btnDeleteWeekly_Click(object sender, EventArgs e)
        {
            if (ckblWeekly.SelectedItem != null)
            {
                ckblWeekly.Items.Remove(ckblWeekly.SelectedItem);
            }
        }

        private void btnCleanFIle_Click(object sender, EventArgs e)
        {
            if (File.Exists(SignPath))
            {
                using (StreamWriter writer = new StreamWriter(SignPath, false))
                {
                    //清空檔案
                }
            }
            else
                MessageBox.Show("檔案不存在!!");
            lbSettingFileSize.Text = CheckFileSize(SignPath);
        }

        private void LabelDay_Paint(object sender, PaintEventArgs e)
        {
            Label lblDate = sender as Label;
            int day = Convert.ToInt32(lblDate.Tag);
            DateTime today = DateTime.Today;
            string Year = DateTime.Now.ToString("yyyy");
            string Month = DateTime.Now.ToString("MM");

            Graphics g = e.Graphics;

            //統一從ini檔讀資料
            int Day_Check = ReadValue(SignPath, Year + Month + lblDate.Text, "Done");
            if (Day_Check == 3)  //3==周任還沒做，這裡有點反邏輯，之後要想辦法改，因為讀不到日期default是0要避開
            {
                //繪製三角形
                using (Pen redPen = new Pen(Color.Tan, 3))
                {
                    int Padding = 10;
                    Point[] points = new Point[]
                    {
                            new Point(lblDate.Width / 2, Padding),
                            new Point(Padding, lblDate.Height - Padding),
                            new Point(lblDate.Width - Padding, lblDate.Height - Padding)
                    };
                    g.DrawPolygon(redPen, points);
                }
            }
            else if (Day_Check == 2) //2==之前做完了
            {
                // 繪製圓形
                using (Pen BluePen = new Pen(Color.SteelBlue, 3))
                {
                    g.DrawEllipse(BluePen, 3, 3, lblDate.Width - 10, lblDate.Height - 10);
                }
            }
            else if (Day_Check == 1) //1==之前沒完成
            {
                // 繪製叉叉
                using (Pen LightCoralPen = new Pen(Color.LightCoral, 3))
                {
                    g.DrawLine(LightCoralPen, 5, 5, lblDate.Width - 5, lblDate.Height - 5);
                    g.DrawLine(LightCoralPen, lblDate.Width - 5, 5, 5, lblDate.Height - 5);
                }
            }

        }
        private string CheckFileSize(string Path)
        {
            FileInfo fileInfo = new FileInfo(Path);
            double fileSizeInKB = 0.0;
            if (fileInfo.Exists)
            {
                long fileSizeInBytes = fileInfo.Length; // 檔案大小，以位元組為單位
                fileSizeInKB = fileSizeInBytes / 1024.0;
            }
            return fileSizeInKB.ToString("0.00");
        }
        #region - strem 讀取資料流 -

        public int ReadValue(string Path, string sSection, string sKey)
        {
            int value = 0;
            bool sectionFound = false;
            try
            {
                using (StreamReader reader = new StreamReader(Path, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        //檢查是否為section
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            if (line.Equals($"[{sSection}]", StringComparison.OrdinalIgnoreCase))
                            {
                                sectionFound = true;    //找到指定的section
                            }
                            else if (sectionFound)
                            {
                                break;  //找到指定的section
                            }
                        }
                        else if (sectionFound && line.StartsWith(sKey + "="))
                        {
                            // 找到指定的key，返回值
                            value = int.Parse(line.Substring(line.IndexOf('=') + 1).Trim());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading INI file: {ex.Message}");
            }

            return value; //如果沒有找到，則返回0
        }
        public bool ReadBool(string Path, string sSection, string sKey)
        {
            bool value = false;
            bool sectionFound = false;
            try
            {
                using (StreamReader reader = new StreamReader(Path, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        //檢查是否為section
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            if (line.Equals($"[{sSection}]", StringComparison.OrdinalIgnoreCase))
                            {
                                sectionFound = true;    //找到指定的section
                            }
                            else if (sectionFound)
                            {
                                break;  //找到指定的section
                            }
                        }
                        else if (sectionFound && line.StartsWith(sKey + "="))
                        {
                            // 找到指定的 key，返回其值
                            bool.TryParse(line.Substring(line.IndexOf('=') + 1).Trim(), out value);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading INI file: {ex.Message}");
            }

            return value; //如果沒有找到，則返回false
        }
        public string ReadString(string Path, string sSection, string sKey)
        {
            string value = null;
            bool sectionFound = false;

            try
            {
                using (StreamReader reader = new StreamReader(Path, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

                        //檢查是否為section
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            if (line.Equals($"[{sSection}]", StringComparison.OrdinalIgnoreCase))
                            {
                                sectionFound = true;    //找到指定的section
                            }
                            else if (sectionFound)
                            {
                                break;  //找到指定的section
                            }
                        }
                        else if (sectionFound && line.StartsWith(sKey + "="))
                        {
                            // 找到指定的 key，返回其值
                            value = line.Substring(line.IndexOf('=') + 1).Trim(); //獲取等號後面的值
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading INI file: {ex.Message}");
            }

            return value; // 如果沒有找到，則返回 null
        }
        public List<string> ReadAllKeys(string sSection)
        {
            List<string> keys = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(SettingPath, Encoding.UTF8))
                {
                    string line;
                    bool sectionFound = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        //檢查是否為section
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            if (line.Equals($"[{sSection}]", StringComparison.OrdinalIgnoreCase))
                            {
                                sectionFound = true;    //找到指定的section
                            }
                            else if (sectionFound)
                            {
                                break;  //遇到下一個section，停止讀取
                            }
                        }
                        else if (sectionFound)
                        {
                            //找到section 後，檢查每一行
                            if (line.Contains("="))
                            {
                                //分離key和value
                                string key = line.Substring(0, line.IndexOf('=')).Trim(); //提取key
                                keys.Add(key); //添加key到List中
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading INI file: {ex.Message}");
            }

            return keys;
        }
        private Dictionary<string, Dictionary<string, string>> ReadIniFile(string filePath)
        {
            Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();
            string currentSection = "";

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Trim('[', ']');
                    if (!iniData.ContainsKey(currentSection))
                    {
                        iniData[currentSection] = new Dictionary<string, string>();
                    }
                }
                else if (line.Contains("="))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        iniData[currentSection][parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            return iniData;
        }
        #endregion
    }
}
