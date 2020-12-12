using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Encoding
{
    class Encryption
    {
        public static string GetCPUID()
        {
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection instances = managementClass.GetInstances();
            string result = "";
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    ManagementObject managementObject = (ManagementObject)enumerator.Current;
                    result = managementObject.Properties["ProcessorId"].Value.ToString();
                }
            }
            managementClass.Dispose();
            instances.Dispose();
            return result;
        }

        public static string GetDiskSerialNumber()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher();
            managementObjectSearcher.Query = new SelectQuery("Win32_DiskDrive", "", new string[]
            {
        "PNPDeviceID",
        "Signature"
            });
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator();
            enumerator.MoveNext();
            ManagementBaseObject current = enumerator.Current;
            string result = current.Properties["signature"].Value.ToString().Trim();
            current.Dispose();
            managementObjectSearcher.Dispose();
            return result;
        }

        public static string GetMoAddress()
        {
            string text = " ";
            using (ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection instances = managementClass.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
                        bool flag = (bool)managementObject["IPEnabled"];
                        if (flag)
                        {
                            text = managementObject["MacAddress"].ToString();
                        }
                        managementObject.Dispose();
                    }
                }
                instances.Dispose();
            }
            return text.ToString();
        }
        public static string Md5Encrypt(string inputstr, bool A)
        {
            string result;
            try
            {
                MD5 mD = MD5.Create();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(inputstr); // Encoding.UTF8.GetBytes(inputstr);
                byte[] array = mD.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                    if (A)
                    {
                        stringBuilder.Append(array[i].ToString("X2"));
                    }
                    else
                    {
                        stringBuilder.Append(array[i].ToString("x2"));
                    }
                }
                result = stringBuilder.ToString();
            }
            catch (Exception e)
            {
                result = "";
            }
            return result;
        }

        public static string TextDecrypt(char[] data, string secretKey)
        {
            char[] array = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                int expr_14_cp_1 = i;
                data[expr_14_cp_1] ^= array[i % array.Length];
            }
            return new string(data);
        }

        public static string TextEncrypt(string content, string secretKey)
        {
            char[] array = content.ToCharArray();
            char[] array2 = secretKey.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char[] expr_1B_cp_0 = array;
                int expr_1B_cp_1 = i;
                expr_1B_cp_0[expr_1B_cp_1] ^= array2[i % array2.Length];
            }
            return new string(array);
        }


    }
}
