namespace Hurtownia.Models
{
    public class SettingValue
    {
        public SettingValue()
        {
        }

        public SettingValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}