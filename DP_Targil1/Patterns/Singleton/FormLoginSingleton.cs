using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace DP_Targil1
{
    public sealed partial class FormLoginSingleton : Form
    {
        private const string k_AppId = "350660342698485";
        private static FormLoginSingleton s_FormExist = null;

        public static FormLoginSingleton getForm
        {
            get
            {
                if (s_FormExist == null)
                {
                    s_FormExist = new FormLoginSingleton();
                }

                return s_FormExist;
            }
        }

        public AppSettings AppSettings { get; }

        public User LoggedInUser { get; set; }

        public LoginResult LoginResult { get; set; }

        private FormLoginSingleton()
        {
            this.InitializeComponent();
            AppSettings = AppSettings.LoadFromFile();
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);
        }

        private void loginAndInit()
        {
            if (LoginResult == null)
            {
                LoginResult = FacebookService.Login(
                    k_AppId,
                    "public_profile",
                    "email",
                    "publish_to_groups",
                    "user_birthday",
                    "user_age_range",
                    "user_gender",
                    "user_link",
                    "user_tagged_places",
                    "user_videos",
                    "publish_to_groups",
                    "groups_access_member_info",
                    "user_friends",
                    "user_events",
                    "user_likes",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_hometown");
            }

            if (!string.IsNullOrEmpty(LoginResult.AccessToken))
            {
                 this.LoggedInUser = this.LoginResult.LoggedInUser;
            }
            else
            {
                MessageBox.Show(LoginResult.ErrorMessage);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs i_EventArgs)
        {
            base.OnFormClosing(i_EventArgs);

            if (LoginResult != null)
            {
                 this.LogoutOrClose();
            }
        }

        public void LogoutOrClose()
        {
            AppSettings.LastAccessToken = LoginResult.AccessToken;
            AppSettings.RememberUser = this.checkBoxRememberUser.Checked;
            AppSettings.SaveToFile();
        }

        private void buttonLogin_Click_1(object i_Sender, EventArgs i_EventArgs)
        {
            this.ButtonLoginClicked();
        }

        public void ButtonLoginClicked()
        {
            this.DialogResult = DialogResult.OK;
            if (AppSettings.RememberUser && !string.IsNullOrEmpty(AppSettings.LastAccessToken))
            {
                LoginResult = FacebookService.Connect(AppSettings.LastAccessToken);
                this.LoggedInUser = this.LoginResult.LoggedInUser;
            }
            else
            {
                 this.loginAndInit();
            }
        }
    }
}
