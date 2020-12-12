using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encode
{
    public partial class Encode : Form
    {
        public string Inifilepath = Application.StartupPath + "/option.ini";
        //private string activestr = "";
        //private string cpuId = "";
        //private string key = "Heyyoo";
        private List<string> fileEndList = new List<string>();

        public Encode()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.comboBox_Select.Items.Clear();
            List<string> list = new List<string>();
            list.Add("UTF8");
            list.Add("ASCII");
            list.Add("Unicode");
            list.Add("UTF8(BOM)");
            this.comboBox_Select.Items.AddRange(list.ToArray());
            this.comboBox_Select.SelectedIndex = 0;
            this.richTextBox_FileType.Text = IniManager.Load("Option", "fileList", ".txt|.lua|.cs", this.Inifilepath);
            //this.textBox_active.Text = IniManager.Load("Option", "active", "", this.Inifilepath);
            //this.cpuId = Encryption.GetCPUID() + Encryption.GetDiskSerialNumber() + Encryption.GetMoAddress();
            //this.activestr = Encryption.Md5Encrypt(this.cpuId + this.key, true);
            //bool flag = this.activestr.Equals(this.textBox_active.Text);
            //if (flag)
            //{
            //    this.button_Change.Enabled = true;
            //    this.textBox_info.Visible = false;
            //    this.textBox_active.Visible = false;
            //    this.button_active.Visible = false;
            //}
            //else
            //{
            //    this.button_Change.Enabled = false;
            //    this.textBox_info.Text = this.cpuId;
            //}
        }

        private static bool IsUTF8Bytes(byte[] data)
        {
            int num = 1;
            bool result;
            for (int i = 0; i < data.Length; i++)
            {
                byte b = data[i];
                bool flag = num == 1;
                if (flag)
                {
                    bool flag2 = b >= 128;
                    if (flag2)
                    {
                        while (((b = (byte)(b << 1)) & 128) > 0)
                        {
                            num++;
                        }
                        bool flag3 = num == 1 || num > 6;
                        if (flag3)
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                else
                {
                    bool flag4 = (b & 192) != 128;
                    if (flag4)
                    {
                        result = false;
                        return result;
                    }
                    num--;
                }
            }
            bool flag5 = num > 1;
            if (flag5)
            {
                throw new Exception("非预期的byte格式");
            }
            result = true;
            return result;
        }

        private bool ChageFileType(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            return this.fileEndList.Contains(fileInfo.Extension);
        }

        private bool CheckBOM(string _filePath)
        {
            bool result = false;
            string path = _filePath.Replace('/', '\\');
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] array = new byte[3];
            fileStream.Read(array, 0, 3);
            bool flag = 239 == array[0] && 187 == array[1] && 191 == array[2];
            if (flag)
            {
                result = true;
            }
            fileStream.Dispose();
            fileStream.Close();
            return result;
        }

        private string GetEncode(byte[] buffer)
        {
            bool flag = buffer[0] == 239 && buffer[1] == 187 && buffer[2] == 191;
            string result;
            if (flag)
            {
                result = Encoding.UTF8.EncodingName.ToString() + "(BOM)";
            }
            else
            {
                bool flag2 = IsUTF8Bytes(buffer);
                if (flag2)
                {
                    result = Encoding.UTF8.EncodingName.ToString();
                }
                else
                {
                    bool flag3 = buffer.Length == 0 || buffer[0] < 239;
                    if (flag3)
                    {
                        result = Encoding.ASCII.EncodingName.ToString();
                    }
                    else
                    {
                        bool flag4 = buffer[0] == 254 && buffer[1] == 255;
                        if (flag4)
                        {
                            result = Encoding.BigEndianUnicode.EncodingName.ToString();
                        }
                        else
                        {
                            bool flag5 = buffer[0] == 255 && buffer[1] == 254;
                            if (flag5)
                            {
                                result = Encoding.Unicode.EncodingName.ToString();
                            }
                            else
                            {
                                result = Encoding.Default.EncodingName.ToString();
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void RefreshAllFile()
        {
            this.fileEndList.Clear();
            bool flag = string.IsNullOrEmpty(this.richTextBox_FileType.Text);
            if (flag)
            {
                this.richTextBox_FileType.Text = ".txt|.lua|.cs";
            }
            string[] array = this.richTextBox_FileType.Text.Trim().Split(new char[]
            {
        '|'
            });
            for (int i = 0; i < array.Length; i++)
            {
                bool flag2 = !string.IsNullOrEmpty(array[i]);
                if (flag2)
                {
                    this.fileEndList.Add(array[i]);
                }
            }
            IniManager.Save("Option", "fileList", this.richTextBox_FileType.Text, this.Inifilepath);
            this.listView_Mes.Items.Clear();
            string[] array2 = this.richTextBox_path.Text.Split(new char[]
            {
        '\n'
            });
            for (int j = 0; j < array2.Length; j++)
            {
                bool flag3 = string.IsNullOrEmpty(array2[j]);
                if (!flag3)
                {
                    ListViewGroup listViewGroup = new ListViewGroup();
                    listViewGroup.Header = array2[j];
                    this.listView_Mes.Groups.Add(listViewGroup);
                    string[] files = Directory.GetFiles(array2[j], "*.*", SearchOption.AllDirectories);
                    for (int k = 0; k < files.Length; k++)
                    {
                        bool flag4 = !this.ChageFileType(files[k]);
                        if (!flag4)
                        {
                            byte[] array3 = File.ReadAllBytes(files[k]);
                            if (array3.Length == 0)
                                continue;

                            string text = files[k].Replace(array2[j], "").Replace('/', '\\');
                            ListViewItem listViewItem = new ListViewItem();
                            listViewItem.SubItems.Add(text);
                            listViewItem.SubItems.Add(this.GetEncode(array3));
                            bool flag5 = array3.Length < 1024;
                            if (flag5)
                            {
                                listViewItem.SubItems.Add(array3.Length.ToString() + "B");
                            }
                            else
                            {
                                bool flag6 = array3.Length < 1048576;
                                if (flag6)
                                {
                                    listViewItem.SubItems.Add(((float)array3.Length / 1024f).ToString("f3") + "KB");
                                }
                                else
                                {
                                    listViewItem.SubItems.Add(((float)array3.Length / 1048576f).ToString("f3") + "MB");
                                }
                            }
                            listViewItem.SubItems.RemoveAt(0);
                            listViewItem.Group = listViewGroup;
                            this.listView_Mes.Items.Add(listViewItem);
                        }
                    }
                }
            }
        }

        public void OnDragEnter(object sender, DragEventArgs e)
        {
            bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            if (dataPresent)
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < array.Length; i++)
            {
                bool flag = File.Exists(array[i]) || this.richTextBox_path.Text.Contains(array[i]);
                if (!flag)
                {
                    RichTextBox expr_48 = this.richTextBox_path;
                    expr_48.Text = expr_48.Text + array[i] + "\n";
                }
            }
            this.RefreshAllFile();
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            bool flag2 = string.IsNullOrEmpty(this.richTextBox_path.Text);
            if (!flag2)
            {
                try
                {
                    string[] array = this.richTextBox_path.Text.Split(new char[]
                    {
                    '\n'
                    });
                    for (int i = 0; i < array.Length; i++)
                    {
                        bool flag3 = string.IsNullOrEmpty(array[i]);
                        if (!flag3)
                        {
                            string[] files = Directory.GetFiles(array[i], "*.*", SearchOption.AllDirectories);
                            for (int j = 0; j < files.Length; j++)
                            {
                                bool flag4 = !this.ChageFileType(files[j]);
                                if (!flag4)
                                {
                                    Encoding encoding = Encoding.ASCII;
                                    string text = this.comboBox_Select.Text;
                                    switch (text)
                                    {
                                        case "ASCII":
                                            encoding = Encoding.ASCII;
                                            break;
                                        case "Unicode":
                                            encoding = Encoding.Unicode;
                                            break;
                                        case "UTF8(BOM)":
                                            encoding = Encoding.UTF8;
                                            break;
                                        case "UTF8":
                                            encoding = new UTF8Encoding(false);
                                            break;
                                    }
                                    //if (!(text == "ASCII"))
                                    //{
                                    //    if (!(text == "Unicode"))
                                    //    {
                                    //        if (text == "UTF8")
                                    //        {
                                    //            encoding = Encoding.UTF8;
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        encoding = Encoding.Unicode;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    encoding = Encoding.ASCII;
                                    //}

                                    string path = files[j].Replace('/', '\\');
                                    string contents = File.ReadAllText(path);
                                    bool flag5 = File.Exists(path);
                                    if (flag5)
                                    {
                                        File.Delete(path);
                                    }
                                    File.WriteAllText(path, contents, encoding);

                                    //bool flag6 = object.Equals(this.comboBox_Select.Text, "UTF8 无BOM");
                                    //if (flag6)
                                    //{
                                    //    File.WriteAllText(path, contents, new UTF8Encoding(false));
                                    //}
                                    //else
                                    //{
                                    //    File.WriteAllText(path, contents, encoding);
                                    //}
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("有不支持的文件：" + ex.ToString(), "错误");
                }
                this.RefreshAllFile();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.richTextBox_path.Text = "";
            this.listView_Mes.Groups.Clear();
            this.listView_Mes.Items.Clear();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择文件路径";
            bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                string selectedPath = folderBrowserDialog.SelectedPath;
                this.richTextBox_path.Text = selectedPath;
                this.RefreshAllFile();
            }
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            this.RefreshAllFile();
        }


    }
}
