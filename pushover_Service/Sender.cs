using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoFridge.pushover_Service
{
    /// <summary>
    /// Provides functions to send Messages through the pushover.net API
    /// </summary>
    public class Sender
    {
        public enum DeviceIDOrTitel {Device, Title};

        public static bool SendMessage(string applicationID, string userID, string message)
        {
            var parameters = new NameValueCollection {
                                                            { "token", applicationID  },
                                                            { "user", userID  },
                                                            { "message", message  }
                                                        };
            return SendToService(parameters);
        }

        public static bool SendMessage(string applicationID, string userID, string message, string deviceOrTitle, DeviceIDOrTitel choice)
        {
            
            var parameters = new NameValueCollection();
            if (choice == DeviceIDOrTitel.Device)
            {
                parameters = new NameValueCollection {
                                                            { "token", applicationID  },
                                                            { "user", userID  },
                                                            { "device", deviceOrTitle},
                                                            { "message", message  }
                                                        };
            }
            else
            {
                parameters = new NameValueCollection {
                                                            { "token", applicationID },
                                                            { "user", userID },
                                                            { "title", deviceOrTitle },
                                                            { "message", message }
                                                        };

            }
            return SendToService(parameters);
        }

        public static bool SendMessage(string applicationID, string userID, string message, string deviceID, string titel)
        {
            var parameters = new NameValueCollection {
                                                            { "token", applicationID  },
                                                            { "user", userID  },
                                                            { "device", deviceID},
                                                            { "title", titel },
                                                            { "message", message  }
                                                        };
            return SendToService(parameters);
        }

        /// <summary>
        /// Sends th Message to the Server
        /// </summary>
        /// <param name="parameters">NaemValueCollection of Message parameters</param>
        /// <returns>success</returns>
        private static bool SendToService(NameValueCollection parameters)
        {
            bool success = false;
            try
            {
                using (var client = new WebClient())
                {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                }

                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show(ex.Message);
            }

            return success;
        }
    }
}
