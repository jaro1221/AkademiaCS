using System;
using System.Collections.ObjectModel;
using System.IO;
using Hurtownia.Models;

namespace Hurtownia.Controllers
{
    public class SettingsValues
    {
        public ObservableCollection<SettingValue> SettingValuesList { get; set; } =
            new ObservableCollection<SettingValue>();

        public string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\settings.conf";

        private void LoadSettings()
        {
            using (var sr = new StreamReader(FilePath))
            {
            }
        }

        private void AddSettings(SettingValue newSettingValue)
        {
            SettingValuesList.Add(newSettingValue);
        }
    }
}