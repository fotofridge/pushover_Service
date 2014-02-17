using System;
using MonoDevelop.Core;
using System.IO;

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
        public static readonly string AppDataFileName = "FotoFridgeSettings.xml";


        public Setting()
        {

        }

        public static void GetUserSettings()
        {
            ////Get location of user Settings file
            string appDataFolder = Path.Combine(
                                       Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                       Setting.AppName);



        }

    }
}

