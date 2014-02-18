using System;
using MonoDevelop.Core;
using System.IO;

////TODO: Notifying Object

namespace FotoFridge.pushover_Service
{
    /// <summary>
    /// Provides User Settings for the pushover.net Service
    /// </summary>
    public class Setting
    {
        public static string UserID = String.Empty;
        public static string DeviceID = String.Empty;
        public static readonly string AppName = "FotoFridge";
        public static readonly string AppDataFileName = "FotoFridge_PushoverSettings.xml";

        public static Setting.SettingData Current;

        public Setting()
        {

        }

        public static void GetUserSettings()
        {
            ////Get location of user Settings file
            string appDataFolder = Path.Combine(
                                       Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                       Setting.AppName);
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            string appDataFilePath = Path.Combine(appDataFolder, Setting.AppDataFileName);

            if (File.Exists(appDataFilePath))
            {
                using (StreamReader reader = new StreamReader(appDataFilePath))
                {
                    System.Xml.Serialization.XmlSerializer
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(Setting.SettingData));

                    Setting.Current = (SettingData)serializer.Deserialize(reader);
                }
            }

        }

        /// <summary>
        /// Provides User Settings Data
        /// </summary>
        public class SettingData
        {
            public SettingData(){}

            private string userID;

            /// <summary>
            /// Gets or sets the pushover.net UserID
            /// </summary>
            /// <value>The user ID</value>
            public string UserID
            {
                get
                {
                    if (this.userID == null)
                    {
                        this.userID = String.Empty;
                    }
                    return this.userID;
                }
                set
                {
                    this.userID = value;
                }
            }

            private string userDevice;

            /// <summary>
            /// Gets or sets the users pushover.net device.
            /// </summary>
            /// <value>The user device name</value>
            public string UserDevice
            {
                get
                {
                    if (this.userDevice == null)
                    {
                        this.userDevice = String.Empty;
                    }
                    return this.userDevice;
                }
                set
                {
                    this.userDevice = value;
                }
            }

        }



    }
}

