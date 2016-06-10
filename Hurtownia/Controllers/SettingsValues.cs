using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Models;

namespace Hurtownia.Controllers
{
    public static class SettingsValues
    {
        public static ObservableCollection<SettingValue> SettingValuesList { get; set; } =
            new ObservableCollection<SettingValue>();

        public static string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\settings.conf";

        public static void SaveSettings()
        {
            using (var sw = new StreamWriter(FilePath))
            {
                foreach (var item in SettingValuesList)
                {
                    sw.WriteLine(item.Name + "=" + item.Key + "=" + item.Value);
                }
            }
        }

        public static void LoadSettings()
        {
            try
            {
                using (var sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string data = sr.ReadLine();
                        string[] newSetting = data.Split('=');
                        AddSettings(newSetting);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    using (var sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine("companyname=Nazwa firmy=\ncompanyowner=Właściciel firmy=");
                    }
                }
                MessageBox.Show(ex.Message);
            }
        }

        private static void AddSettings(string[] newSetting)
        {
            SettingValue newSettingValue = new SettingValue(newSetting[0], newSetting[1], newSetting[2]);
            SettingValuesList.Add(newSettingValue);
        }

        public static string GetValue(string name)
        {
            foreach (var item in SettingValuesList)
            {
                if (item.Name == name)
                {
                    string value = item.Value;
                    return value;
                }
            }
            return null;

        }

        public static void EditSettingsValue(int index, SettingValue settingValue)
        {
            SettingValuesList.RemoveAt(index);
            SettingValuesList.Insert(index, settingValue);
        }
    }
}