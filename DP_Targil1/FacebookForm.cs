using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace DP_Targil1
{
    public partial class FacebookForm : Form
    {
        private readonly FormLogin r_FormLogin = new FormLogin();
        private MatchSuggestion m_MatchSuggestion;
        private FacebookUser m_SelectedMatch;
        private ImageSuggestion m_ImageSuggestion;

        public FacebookObjectCollection<Album> AlbumsCollection { get; set; }

        public FacebookForm()
        {
            FacebookWrapper.FacebookService.s_CollectionLimit = 1000;
            if (this.r_FormLogin.AppSettings.RememberUser == false)
            {
                this.r_FormLogin.ShowDialog();
            }
            else
            {
                this.r_FormLogin.ButtonLoginClicked();
            }

            if (this.r_FormLogin.DialogResult == DialogResult.OK)
            {
                this.InitializeComponent();
                // new Thread(fetchProfilePicture).Start();
                new Thread(fetchUserInfo).Start();
                new Thread(fetchPosts).Start();
                //this.fetchPosts();
            }
        }

        public void StartApp()
        {
            if (this.r_FormLogin.DialogResult == DialogResult.OK)
            {
                Application.Run(this);
            }
        }

        private void buttonLogout_Click(object i_Sender, EventArgs i_EventArgs)
        {
            FacebookService.Logout(new Action(this.loggedOutFinished));
        }

        private void loggedOutFinished()
        {
            this.r_FormLogin.LogoutOrClose();
            Application.Restart();
            this.MinimizeBox = true;
            this.r_FormLogin.AppSettings.RememberUser = false;
            this.r_FormLogin.ShowDialog();
        }

        private void fetchProfilePicture()
        {
            profilePictureBox.LoadAsync(this.r_FormLogin.LoggedInUser.PictureNormalURL);
            profilePictureBox.Invoke(new Action(() => profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage));
        }

        private void fetchUserInfo()
        {
            new Thread(fetchProfilePicture).Start();
            userNameLabel.Invoke(new Action(() => userNameLabel.Text = this.r_FormLogin.LoggedInUser.Name));

            if (this.r_FormLogin.LoggedInUser.Posts.Count > 0)
            {
                postStatusTextBox.Invoke(new Action(() => postStatusTextBox.Text = this.r_FormLogin.LoggedInUser.Posts[0].Message));
            }

            foreach (Album album in this.r_FormLogin.LoggedInUser.Albums)
            {
                if (album.Name == "Cover Photos")
                {
                    coverPictureBox.LoadAsync(album.PictureAlbumURL);
                    coverPictureBox.Invoke(new Action(() => coverPictureBox.SizeMode = PictureBoxSizeMode.StretchImage));
                    break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs i_EventArgs)
        {
            GraphicsPath graphicsPathOfProfile = new GraphicsPath();
            GraphicsPath graphicsPathOfSuggests = new GraphicsPath();
            graphicsPathOfProfile.AddEllipse(0, 0, profilePictureBox.Width, profilePictureBox.Height);
            profilePictureBox.Region = new System.Drawing.Region(graphicsPathOfProfile);
            graphicsPathOfSuggests.AddEllipse(0, 0, PictureBoxSuggests.Width, PictureBoxSuggests.Height);
            PictureBoxSuggests.Region = new System.Drawing.Region(graphicsPathOfSuggests);
            base.OnPaint(i_EventArgs);
        }

        private void buttonSetStatus_Click(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                Status postedStatus = this.r_FormLogin.LoggedInUser.PostStatus(postStatusTextBox.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Status could not be posted");
            }
        }

        private void linkPosts_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkPosts.LinkColor = Color.Gray;

            this.fetchPosts();
        }

        private void fetchPosts()
        {
            listBoxPosts.Invoke(new Action(() => listBoxPosts.Visible = true));

            foreach (Post post in this.r_FormLogin.LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Message)));
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Caption)));
                }
                else
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(string.Format("[{0}]", post.Type))));
                }
            }

            if (this.r_FormLogin.LoggedInUser.Posts.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve");
            }
        }

        private void linkAlbums_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            pictureBoxAlbum.Visible = true;
            listBoxAlbums.Visible = true;
            AlbumsLink.LinkColor = Color.Gray;

            this.fetchAlbums();
        }

        private void fetchAlbums()
        {
            this.AlbumsCollection = new FacebookObjectCollection<Album>();
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            foreach (Album album in this.r_FormLogin.LoggedInUser.Albums)
            {
                this.AlbumsCollection.Add(album);
                listBoxAlbums.Items.Add(album);
            }

            if (this.r_FormLogin.LoggedInUser.Albums.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve");
            }
        }

        private void displaySelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

                if (selectedAlbum?.PictureAlbumURL != null)
                {
                    pictureBoxAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    profilePictureBox.Image = profilePictureBox.ErrorImage;
                }
            }
        }

        private void listBoxAlbums_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.displaySelectedAlbum();
        }

        private void listBoxPhotos_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.radioButtonNormalFilter.Checked = true;
            this.labelChooseFilter.Visible = true;
            this.radioButtonBlackAndWhiteFilter.Visible = true;
            this.radioButtonNormalFilter.Visible = true;
            this.radioButtonSepiaFilter.Visible = true;
            this.radioButtonTransparencyFilter.Visible = true;
            this.buttonSetProfilePic.Visible = true;
            this.labelAboutThePhoto.Visible = true;

            this.setSourcePhoto();
        }

        private void aboutLinkLabel_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            this.aboutLabel.Visible = true;
            aboutMeLabel.Visible = true;
            aboutLinkLabel.LinkColor = Color.Gray;
            this.fetchAbout(this.r_FormLogin.LoggedInUser, this.aboutLabel);
        }

        private void setDefaultLink()
        {
            aboutLinkLabel.LinkColor = Color.Navy;
            friendsLinkLabel.LinkColor = Color.Navy;
            AlbumsLink.LinkColor = Color.Navy;
            linkPosts.LinkColor = Color.Navy;
            linkLabelByLikes.LinkColor = Color.Navy;
            linkLabelByComments.LinkColor = Color.Navy;
            linkLabelLikesAndComments.LinkColor = Color.Navy;
            listBoxPosts.Visible = false;
            listBoxAlbums.Visible = false;
            friendsListBox.Visible = false;
            aboutLabel.Visible = false;
            pictureBoxAlbum.Visible = false;
            aboutMeLabel.Visible = false;
            linkLabelByLikes.Enabled = true;
            linkLabelByComments.Enabled = true;
            linkLabelLikesAndComments.Enabled = true;
        }

        private void fetchAbout(User i_User, Label i_Label)
        {
            StringBuilder aboutString = new StringBuilder();
            aboutString.Append(string.Format("Gender: {0}{1}", i_User.Gender, Environment.NewLine));
            aboutString.Append(string.Format("Birth Day: {0}{1}", i_User.Birthday, Environment.NewLine));
            aboutString.Append(string.Format("Email Address: {0}{1}", i_User.Email, Environment.NewLine));
            aboutString.Append(string.Format("Education: {0}{1}", i_User.Educations, Environment.NewLine));
            aboutString.Append(string.Format("Work Experience: {0}{1}", i_User.WorkExperiences, Environment.NewLine));
            aboutString.Append(string.Format("Relationship Status: {0}{1}", i_User.RelationshipStatus, Environment.NewLine));
            i_Label.Text = aboutString.ToString();
        }

        private void friendsLinkLabel_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            friendsListBox.Visible = true;
            friendsLinkLabel.LinkColor = Color.Gray;
            this.fetchFriends();
        }

        private void fetchFriends()
        {
            friendsListBox.Items.Clear();
            friendsListBox.DisplayMember = "Name";

            foreach (User friend in this.r_FormLogin.LoggedInUser.Friends)
            {
                friendsListBox.Items.Add(friend.Name);
            }

            if (this.r_FormLogin.LoggedInUser.Friends.Count == 0)
            {
                MessageBox.Show("No friends to retrieve");
            }
        }

        private void radioButtonNormalFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonNormalFilter.Checked == true)
            {
                this.setSourcePhoto();
            }
        }

        private void setSourcePhoto()
        {
            if (ListBoxPhotos.SelectedItems.Count == 1)
            {
                this.m_ImageSuggestion.SourcePhoto = ListBoxPhotos.SelectedItem as Photo;
                if (this.m_ImageSuggestion.SourcePhoto?.PictureNormalURL != null)
                {
                    PictureBoxSuggests.LoadAsync(this.m_ImageSuggestion.SourcePhoto.PictureNormalURL);
                    PictureBoxSuggests.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            LabelAboutThePhoto.Text = this.m_ImageSuggestion.SetDetailsPhoto();
        }

        private void radioButtonBlackAndWhiteFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonBlackAndWhiteFilter.Checked == true)
            {
                PictureBoxSuggests.Image = this.m_ImageSuggestion.SetFilter(eFilter.BlackAndWhite);
            }
        }

        private void radioButtonTransparencyFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonTransparencyFilter.Checked == true)
            {
                PictureBoxSuggests.Image = this.m_ImageSuggestion.SetFilter(eFilter.Transparency);
            }
        }

        private void radioButtonSepiaFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonSepiaFilter.Checked == true)
            {
                PictureBoxSuggests.Image = this.m_ImageSuggestion.SetFilter(eFilter.Sepia);
            }
        }

        private void buttonSetProfilePic_Click(object i_Sender, EventArgs i_EventArgs)
        {
            byte[] byteArr = this.m_ImageSuggestion.ConvertImageToBytes(this.pictureBoxSuggests.Image);

            try
            {
                foreach (Album album in this.r_FormLogin.LoggedInUser.Albums)
                {
                    if (album.Name == "Profile Pictures")
                    {
                        album.UploadPhoto(byteArr);
                        MessageBox.Show("Image uploaded successfully!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to upload image");
            }
        }

        private void linkLabelByLikes_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelByLikes.LinkColor = Color.Gray;
            this.m_ImageSuggestion.SortListPhotos(eSort.ByLikes);
            linkLabelByLikes.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private void linkLabelByComments_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelByComments.LinkColor = Color.Gray;
            this.m_ImageSuggestion.SortListPhotos(eSort.ByComments);
            linkLabelByComments.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private void linkLabelLikesAndComments_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelLikesAndComments.LinkColor = Color.Gray;
            this.m_ImageSuggestion.SortListPhotos(eSort.ByLikesAndComments);
            linkLabelLikesAndComments.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private bool checkGenderValidity(string i_Gender)
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

        private void buttonSuggestMeImage_Click(object i_Sender, EventArgs i_EventArgs)
        {
            pictureBoxSuggests.Visible = true;
            labelChoosePhoto.Visible = true;
            this.m_ImageSuggestion = new ImageSuggestion(this.r_FormLogin.LoggedInUser);
            listBoxPhotos.Visible = true;
            labelOrderBy.Visible = true;
            buttonSuggestMe.Visible = false;
            linkLabelLikesAndComments.Visible = true;
            linkLabelByComments.Visible = true;
            linkLabelByLikes.Visible = true;
            linkLabelLikesAndComments.Enabled = false;
            labelDetails.Visible = true;
            this.m_ImageSuggestion.SortListPhotos(eSort.ByLikesAndComments);

            this.loadToListBoxPhotos();
        }

        private void loadToListBoxPhotos()
        {
            ListBoxPhotos.Items.Clear();
            foreach (Photo photoList in this.m_ImageSuggestion.Photos)
            {
                ListBoxPhotos.Items.Add(photoList);
            }

            if (ListBoxPhotos.Items.Count == 0)
            {
                MessageBox.Show("No photos to retrieve");
            }
        }

        private void suggestMeMatchingButtom_Click(object sender, EventArgs e)
        {
            this.cleanProfileData();
            this.m_MatchSuggestion = new MatchSuggestion(this.r_FormLogin.LoggedInUser);
            this.m_SelectedMatch = null;

            matcPeopleListBox.Items.Clear();
            this.m_MatchSuggestion.TopMatchedUsers.Clear();
            matcPeopleListBox.DisplayMember = "Name";
            string filteredGender = null;
            int filteredFromAge = 0;
            int filteredToAge = 0;
            string filteredHometown = null;

            if (!string.IsNullOrEmpty(genderTextBox.Text))
            {
                if (this.checkGenderValidity(genderTextBox.Text))
                {
                    filteredGender = genderTextBox.Text.ToLower();
                }
            }

            if (!string.IsNullOrEmpty(homeTownTextBox.Text))
            {
                filteredHometown = homeTownTextBox.Text.ToLower();
            }

            if (!string.IsNullOrEmpty(fromAgeTextBox.Text))
            {
                filteredFromAge = int.Parse(fromAgeTextBox.Text);
            }

            if (!string.IsNullOrEmpty(this.toAgeTextBox.Text))
            {
                filteredToAge = int.Parse(this.toAgeTextBox.Text);
            }

            this.m_MatchSuggestion.CheckPersonMatch(filteredGender, filteredFromAge, filteredToAge, filteredHometown);

            foreach (FacebookUser matchedPeople in this.m_MatchSuggestion.TopMatchedUsers)
            {
                matcPeopleListBox.Items.Add(matchedPeople);
            }

            if (this.m_MatchSuggestion.TopMatchedUsers.Count == 0)
            {
                MessageBox.Show("No Match to retrieve");
            }
        }

        private void cleanProfileData()
        {
            matchTextBox.Visible = false;
            this.matchDetailsLabel.Visible = false;
            messageButton.Visible = false;
            circlePictureBox.Visible = false;
            matchPictureBox.Visible = false;
            matchAboutLabel.Visible = false;
            percentLabel.Visible = false;
        }

        private void displayMatchData()
        {
            matchTextBox.Visible = true;
            this.matchDetailsLabel.Visible = true;
            messageButton.Visible = true;
            circlePictureBox.Visible = true;
            matchPictureBox.Visible = true;
            matchAboutLabel.Visible = true;
            percentLabel.Visible = true;
            this.messageButton.Text = string.Format("Post a meesage on {0}'s wall", this.m_SelectedMatch.User.FirstName);
            this.matchPictureBox.LoadAsync(this.m_SelectedMatch.User.PictureNormalURL);
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.fetchAbout(this.m_SelectedMatch.User, this.matchAboutLabel);
            percentLabel.Text = string.Format("{0}%", this.m_SelectedMatch.MatchPercentage);
        }

        private void displaySelectedMatch()
        {
            if (matcPeopleListBox.SelectedItems.Count == 1)
            {
                this.m_SelectedMatch = this.matcPeopleListBox.SelectedItem as FacebookUser;
                if (this.m_SelectedMatch != null)
                {
                    this.displayMatchData();
                }
                else
                {
                    profilePictureBox.Image = profilePictureBox.ErrorImage;
                }
            }
        }

        private void matchPeopleListBox_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            this.displaySelectedMatch();
        }

        private void messageButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                Status postedStatus = this.m_SelectedMatch.User.PostStatus(matchTextBox.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Status could not be posted");
            }
        }

        private void circlePictureBox_Paint(object i_Sender, PaintEventArgs i_EventArgs) //facade
        {
            Graphics graphics = i_EventArgs.Graphics;
            Pen pen = new Pen(Color.MediumVioletRed, 2);
            graphics.DrawEllipse(pen, 0, 0, 55, 55);
        }

        private void matchAlert_Click(object i_Sender, EventArgs i_EventArgs)
        {
            matcPeopleListBox.Items.Clear();
            matcPeopleListBox.DisplayMember = "Name";

            foreach (FacebookUser match in this.m_MatchSuggestion.TopMatchedUsers)
            {
                if (match.MatchPercentage >= 75)
                {
                    matchAlertListBox.Items.Add(match);
                }
            }

            if (matchAlertListBox.Items.Count > 0)
            {
                this.matchAlertListBox.Visible = true;
            }
            else
            {
                MessageBox.Show("No Match Alerts");
            }
        }
    }
}