using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FotoFridge.pushover_Service
{
    public partial class AskUserForm : Form
    {
        public Setting.SettingData DataContext;

        public AskUserForm()
        {
            InitializeComponent();
        }

        public void Initialisieren(Setting.SettingData dataContext)
        {
            this.DataContext = dataContext;

            this.UserIDtxtBox.Text = this.DataContext.UserID;
            this.DeviceNametxtBox.Text = this.DataContext.UserDevice;

            this.DataContext.PropertyChanged += DataContext_PropertyChanged;
            this.UserIDtxtBox.TextChanged += UserIDtxtBox_TextChanged;
            this.DeviceNametxtBox.TextChanged += DeviceNametxtBox_TextChanged;

        }

        void DeviceNametxtBox_TextChanged(object sender, EventArgs e)
        {
            this.DataContext.UserDevice = this.DeviceNametxtBox.Text;
        }

        void UserIDtxtBox_TextChanged(object sender, EventArgs e)
        {
            this.DataContext.UserID = this.UserIDtxtBox.Text;
        }

        void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "UserID":
                    this.UserIDtxtBox.Text = this.DataContext.UserID;
                    break;
                case "UserDevice":
                    this.DeviceNametxtBox.Text = this.DataContext.UserDevice;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
