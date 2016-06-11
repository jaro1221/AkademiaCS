using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
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
                        var data = sr.ReadLine();
                        var newSetting = data.Split('=');
                        AddSettings(newSetting);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void AddSettings(string[] newSetting)
        {
            var newSettingValue = new SettingValue(newSetting[0], newSetting[1], newSetting[2]);
            SettingValuesList.Add(newSettingValue);
        }

        public static string GetValue(string name)
        {
            foreach (var item in SettingValuesList)
            {
                if (item.Name == name)
                {
                    var value = item.Value;
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