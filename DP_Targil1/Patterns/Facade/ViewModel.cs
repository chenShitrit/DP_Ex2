using System.Threading;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DP_Targil1.Patterns.Strategy;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1.Patterns.Facade
{
    public static class ViewModel
    {
        public static MatchSuggestion MatchSuggestion { get; set; }

        public static FacebookUser SelectedMatch { get; set; }

        public static ImageSuggestion ImageSuggestion { get; set; }

        public static void PostStatus(string i_Text)
        {
            try
            {
                Status postedStatus = SelectedMatch.User.PostStatus(i_Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Status could not be posted");
            }
        }

        public static string AboutMe(User i_CurrUser)
        {
            StringBuilder aboutString = new StringBuilder();
            aboutString.Append(string.Format("Gender: {0}{1}", i_CurrUser.Gender, Environment.NewLine));
            aboutString.Append(string.Format("Birth Day: {0}{1}", i_CurrUser.Birthday, Environment.NewLine));
            aboutString.Append(string.Format("Email Address: {0}{1}", i_CurrUser.Email, Environment.NewLine));
            aboutString.Append(string.Format("Education: {0}{1}", i_CurrUser.Educations, Environment.NewLine));
            aboutString.Append(string.Format("Work Experience: {0}{1}", i_CurrUser.WorkExperiences, Environment.NewLine));
            aboutString.Append(string.Format("Relationship Status: {0}{1}", i_CurrUser.RelationshipStatus, Environment.NewLine));

            return aboutString.ToString();
        }

        public static void DrawPicture(PaintEventArgs i_EventArgs)
        {
            Graphics graphics = i_EventArgs.Graphics;
            Pen pen = new Pen(Color.MediumVioletRed, 2);
            graphics.DrawEllipse(pen, 0, 0, 55, 55);
        }

        public static void setPicture(byte[] i_ByteArr, User i_CurrUser)
        {
            try
            {
                foreach (Album album in i_CurrUser.Albums)
                {
                    if (album.Name == "Profile Pictures")
                    {
                        album.UploadPhoto(i_ByteArr);
                        MessageBox.Show("Image uploaded successfully!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to upload image");
            }
        }

        public static bool CheckGenderValidity(string i_Gender)
        {
            bool isValid = false;
            if (i_Gender.ToLower() == "female" || i_Gender.ToLower() == "male")
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Please enter female or male");
            }

            return isValid;
        }
    }
}
