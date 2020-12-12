using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Encoding
{
    public partial class FormEncoding : Form
    {
        public string Inifilepath = Application.StartupPath + "/option.ini";
        private string activestr = "";
        private string cpuId = "";
        private string key = "Heyyoo";
        private List<string> fileEndList = new List<string>();

        public FormEncoding()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            this.cpuId = Encryption.GetCPUID() + Encryption.GetDiskSerialNumber() + Encryption.GetMoAddress();
            this.activestr = Encryption.Md5Encrypt(this.cpuId + this.key, true);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox.Text = this.activestr;
        }
    }
}
