using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DP_Targil1
{
    public class AppSettings
    {
        private const string k_XmlFile = "appSettings.xml";

        public bool RememberUser { get; set; } 

        public string LastAccessToken { get; set; } 

        private AppSettings()
        {
            RememberUser = false;
            LastAccessToken = null;
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings obj = new AppSettings();
            if(File.Exists(k_XmlFile))
            {
                 using(Stream stream = new FileStream(k_XmlFile, FileMode.Open))
                 {
                      XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                      try
                      {
                           obj = serializer.Deserialize(stream) as AppSettings;
                      }
                      catch(Exception)
                      {
                           Console.WriteLine("Failed to read settings file");
                      }
                 }
            }

            return obj;
        }

        public void SaveToFile()
        {
            using (Stream stream = new FileStream(k_XmlFile, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
