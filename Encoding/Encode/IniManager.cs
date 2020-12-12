using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Encode
{
    class IniManager
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        public static void Save(string _section, string _key, string _value, string _filepath)
        {
            IniManager.WritePrivateProfileString(_section, _key, _value, _filepath);
        }

        public static string Load(string _section, string _key, string _def, string _filePath)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            int privateProfileString = IniManager.GetPrivateProfileString(_section, _key, _def, stringBuilder, 1024, _filePath);
            return stringBuilder.ToString();
        }

    }
}
