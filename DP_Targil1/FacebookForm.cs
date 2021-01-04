using System.Threading;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using DP_Targil1.Patterns.Facade;

namespace DP_Targil1
{
    public partial class FacebookForm : Form
    {
        private readonly FormLoginSingleton r_FormLogin = FormLoginSingleton.getForm;
        
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
                new Thread(this.fetchUserInfo).Start();
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
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void fetchMatchAlert()
        {
            ViewModel.MatchSuggestion = new MatchSuggestion(this.r_FormLogin.LoggedInUser);
            ViewModel.MatchSuggestion.CheckPersonMatch(null, 0, 0, null);
        }

        private void fetchUserInfo()
        {
            new Thread(this.fetchPosts).Start();
            new Thread(this.fetchProfilePicture).Start();
            new Thread(this.fetchMatchAlert).Start();
            
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
                    coverPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void linkPosts_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkPosts.LinkColor = Color.Gray;
            this.fetchPosts();
        }

        private void fetchPosts()
        {
            listBoxPosts.Invoke(new Action(() => listBoxPosts.Visible = true));
            messageTextBox.Invoke(new Action(() => messageTextBox.Visible = true));
            postBindingSource.DataSource = this.r_FormLogin.LoggedInUser.Posts;
        }

        private void linkAlbums_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            listBoxAlbums.Visible = true;
            AlbumsLink.LinkColor = Color.Gray;

            new Thread(this.fetchAlbums).Start();
        }

        private void fetchAlbums()
        {
            imageAlbumPictureBox.Invoke(new Action(() => imageAlbumPictureBox.Visible = true));
            albumBindingSource.DataSource = this.r_FormLogin.LoggedInUser.Albums;
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
            messageTextBox.Visible = false;
            listBoxAlbums.Visible = false;
            friendsListBox.Visible = false;
            aboutLabel.Visible = false;
            imageAlbumPictureBox.Visible = false;
            aboutMeLabel.Visible = false;
            linkLabelByLikes.Enabled = true;
            linkLabelByComments.Enabled = true;
            linkLabelLikesAndComments.Enabled = true;
        }

        private void fetchAbout(User i_User, Label i_Label)
        {
            i_Label.Text = ViewModel.AboutMe(i_User);
        }

        private void friendsLinkLabel_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            friendsListBox.Visible = true;
            friendsLinkLabel.LinkColor = Color.Gray;
            new Thread(this.fetchFriends).Start();
        }

        private void fetchFriends()
        {
            friendsListBox.Invoke(new Action(() => friendsListBox.Items.Clear()));
            friendsListBox.Invoke(new Action(() => friendsListBox.DisplayMember = "Name"));

            foreach (User friend in this.r_FormLogin.LoggedInUser.Friends)
            {
                friendsListBox.Invoke(new Action(() => friendsListBox.Items.Add(friend.Name)));
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
                ViewModel.ImageSuggestion.SourcePhoto = ListBoxPhotos.SelectedItem as Photo;
                if (ViewModel.ImageSuggestion.SourcePhoto?.PictureNormalURL != null)
                {
                    PictureBoxSuggests.LoadAsync(ViewModel.ImageSuggestion.SourcePhoto.PictureNormalURL);
                    PictureBoxSuggests.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            LabelAboutThePhoto.Text = ViewModel.ImageSuggestion.SetDetailsPhoto();
        }

        private void radioButtonBlackAndWhiteFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonBlackAndWhiteFilter.Checked == true)
            {
                PictureBoxSuggests.Image = ViewModel.ImageSuggestion.SetFilter(eFilter.BlackAndWhite);
            }
        }

        private void radioButtonTransparencyFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonTransparencyFilter.Checked == true)
            {
                PictureBoxSuggests.Image = ViewModel.ImageSuggestion.SetFilter(eFilter.Transparency);
            }
        }

        private void radioButtonSepiaFilter_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (this.radioButtonSepiaFilter.Checked == true)
            {
                PictureBoxSuggests.Image = ViewModel.ImageSuggestion.SetFilter(eFilter.Sepia);
            }
        }

        private void buttonSetProfilePic_Click(object i_Sender, EventArgs i_EventArgs)
        {
            byte[] byteArr = ViewModel.ImageSuggestion.ConvertImageToBytes(this.pictureBoxSuggests.Image);
            ViewModel.setPicture(byteArr, this.r_FormLogin.LoggedInUser);
        }

        private void linkLabelByLikes_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelByLikes.LinkColor = Color.Gray;
            ViewModel.ImageSuggestion.SortListPhotos(eSort.ByLikes);
            linkLabelByLikes.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private void linkLabelByComments_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelByComments.LinkColor = Color.Gray;
            ViewModel.ImageSuggestion.SortListPhotos(eSort.ByComments);
            linkLabelByComments.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private void linkLabelLikesAndComments_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_EventArgs)
        {
            this.setDefaultLink();
            linkLabelLikesAndComments.LinkColor = Color.Gray;
            ViewModel.ImageSuggestion.SortListPhotos(eSort.ByLikesAndComments);
            linkLabelLikesAndComments.Enabled = false;
            this.loadToListBoxPhotos();
        }

        private void buttonSuggestMeImage_Click(object i_Sender, EventArgs i_EventArgs)
        {
            pictureBoxSuggests.Visible = true;
            labelChoosePhoto.Visible = true;
            ViewModel.ImageSuggestion = new ImageSuggestion(this.r_FormLogin.LoggedInUser);
            listBoxPhotos.Visible = true;
            labelOrderBy.Visible = true;
            buttonSuggestMe.Visible = false;
            linkLabelLikesAndComments.Visible = true;
            linkLabelByComments.Visible = true;
            linkLabelByLikes.Visible = true;
            linkLabelLikesAndComments.Enabled = false;
            labelDetails.Visible = true;
            ViewModel.ImageSuggestion.SortListPhotos(eSort.ByLikesAndComments);

            this.loadToListBoxPhotos();
        }

        private void loadToListBoxPhotos()
        {
            ListBoxPhotos.Items.Clear();
            foreach (Photo photoList in ViewModel.ImageSuggestion.Photos)
            {
                ListBoxPhotos.Items.Add(photoList);
            }

            if (ListBoxPhotos.Items.Count == 0)
            {
                MessageBox.Show("No photos to retrieve");
            }
        }

        private void suggestMeMatchingButton_Click(object sender, EventArgs e)
        {
            this.cleanProfileData();
            ViewModel.MatchSuggestion = new MatchSuggestion(this.r_FormLogin.LoggedInUser);
            ViewModel.SelectedMatch = null;
            matcPeopleListBox.Items.Clear();
            ViewModel.MatchSuggestion.TopMatchedUsers.Clear();
            matcPeopleListBox.DisplayMember = "Name";
            string filteredGender = null;
            int filteredFromAge = 0;
            int filteredToAge = 0;
            string filteredHometown = null;

            if (!string.IsNullOrEmpty(genderTextBox.Text))
            {
                if (ViewModel.CheckGenderValidity(genderTextBox.Text))
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
           
            ViewModel.MatchSuggestion.CheckPersonMatch(filteredGender, filteredFromAge, filteredToAge, filteredHometown);

            foreach (FacebookUser matchedPeople in ViewModel.MatchSuggestion.TopMatchedUsers)
            {
                matcPeopleListBox.Items.Add(matchedPeople);
            }

            if (ViewModel.MatchSuggestion.TopMatchedUsers.Count == 0)
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
            this.messageButton.Text = string.Format("Post a meesage on {0}'s wall", ViewModel.SelectedMatch.User.FirstName);
            this.matchPictureBox.LoadAsync(ViewModel.SelectedMatch.User.PictureNormalURL);
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
         //  new Thread(new ThreadStart(fetchAbout(ViewModel.SelectedMatch.User, this.matchAboutLabel));
            this.fetchAbout(ViewModel.SelectedMatch.User, this.matchAboutLabel);
            percentLabel.Text = string.Format("{0}%", ViewModel.SelectedMatch.MatchPercentage);
        }

        private void displaySelectedMatch()
        {
            if (matcPeopleListBox.SelectedItems.Count == 1)
            {
                ViewModel.SelectedMatch = this.matcPeopleListBox.SelectedItem as FacebookUser;
                if (ViewModel.SelectedMatch != null)
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
            ViewModel.PostStatus(matchTextBox.Text);            
        }

        private void buttonSetStatus_Click(object i_Sender, EventArgs i_EventArgs)
        {
            ViewModel.PostStatus(postStatusTextBox.Text);
        }

        private void circlePictureBox_Paint(object i_Sender, PaintEventArgs i_EventArgs) 
        {
            ViewModel.DrawPicture(i_EventArgs);
        }

        private void matchAlert_Click(object i_Sender, EventArgs i_EventArgs)
        {
            matcPeopleListBox.Invoke(new Action(() => matcPeopleListBox.Items.Clear()));
            matcPeopleListBox.Invoke(new Action(() => matcPeopleListBox.DisplayMember = "Name"));
            
            foreach (FacebookUser match in ViewModel.MatchSuggestion.TopMatchedUsers)
            {
                if (match.MatchPercentage >= 75)
                {
                    matchAlertListBox.Invoke(new Action(() => matchAlertListBox.Items.Add(match)));
                }
            }

            if (matchAlertListBox.Items.Count > 0)
            {
                matchAlertListBox.Invoke(new Action(() => matchAlertListBox.Visible = true));
            }
            else
            {
                MessageBox.Show("No Match Alerts");
            }
        }
    }
}