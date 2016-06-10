using System.Collections.Specialized;

namespace Hurtownia.Models
{
    public class SettingValue
    {
        public SettingValue()
        {
        }

        public SettingValue(string name, string key, string value)
        {
            
            Name = name;
            Key = key;
            Value = value;
        }


        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}