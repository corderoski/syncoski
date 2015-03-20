using System;
using System.Configuration;
using System.Text;

namespace Syncoski.Framework
{
    public abstract class ConfigurationHelper
    {
        #region -Fields And Properties

        public static readonly Encoding DefaultEncoding = System.Text.Encoding.UTF8;

        #endregion

        public static String GetSetting(string name)
        {
            return GetSetting<String>(name);
        }

        public static T GetSetting<T>(string name)
        {
            var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var temp = conf.AppSettings.Settings[name].Value;
            return (T)(temp == null ? null : Convert.ChangeType(temp, typeof(T)));
        }

        public static void SaveValue(String key, String value)
        {
            var conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            conf.AppSettings.Settings[key].Value = value;
            conf.Save();
        }

    }
}
