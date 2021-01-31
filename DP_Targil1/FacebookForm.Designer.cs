using System.Windows.Forms;

namespace DP_Targil1
{
    public partial class FacebookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookForm));
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.albumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postStatusLabel = new System.Windows.Forms.Label();
            this.postStatusTextBox = new System.Windows.Forms.TextBox();
            this.postStatusButtonSet = new System.Windows.Forms.Button();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AlbumsLink = new System.Windows.Forms.LinkLabel();
            this.linkPosts = new System.Windows.Forms.LinkLabel();
            this.facebookTabControl = new System.Windows.Forms.TabControl();
            this.myProfileTabPage = new System.Windows.Forms.TabPage();
            this.imageAlbumPictureBox = new System.Windows.Forms.PictureBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.matchAlertListBox = new System.Windows.Forms.ListBox();
            this.matchAlert = new System.Windows.Forms.PictureBox();
            this.aboutMeLabel = new System.Windows.Forms.Label();
            this.friendsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.matchPeopleTabPage = new System.Windows.Forms.TabPage();
            this.CheckBoxShowMatchesWithPhotos = new System.Windows.Forms.CheckBox();
            this.matcPeopleListBox = new System.Windows.Forms.ListBox();
            this.SuggestMeMatchingButtom = new System.Windows.Forms.Button();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.genderLabel = new System.Windows.Forms.Label();
            this.homeTownTextBox = new System.Windows.Forms.TextBox();
            this.hometownLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toAgeTextBox = new System.Windows.Forms.TextBox();
            this.fromAgeTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.filterLable = new System.Windows.Forms.Label();
            this.matchTextBox = new System.Windows.Forms.TextBox();
            this.messageButton = new System.Windows.Forms.Button();
            this.percentLabel = new System.Windows.Forms.Label();
            this.matchDetailsLabel = new System.Windows.Forms.Label();
            this.matchPictureBox = new System.Windows.Forms.PictureBox();
            this.matchAboutLabel = new System.Windows.Forms.Label();
            this.circlePictureBox = new System.Windows.Forms.PictureBox();
            this.imageSuggestaionTabPage = new System.Windows.Forms.TabPage();
            this.labelDetails = new System.Windows.Forms.Label();
            this.labelAboutThePhoto = new System.Windows.Forms.Label();
            this.linkLabelLikesAndComments = new System.Windows.Forms.LinkLabel();
            this.linkLabelByComments = new System.Windows.Forms.LinkLabel();
            this.labelOrderBy = new System.Windows.Forms.Label();
            this.linkLabelByLikes = new System.Windows.Forms.LinkLabel();
            this.buttonSetProfilePic = new System.Windows.Forms.Button();
            this.labelChoosePhoto = new System.Windows.Forms.Label();
            this.radioButtonSepiaFilter = new System.Windows.Forms.RadioButton();
            this.radioButtonTransparencyFilter = new System.Windows.Forms.RadioButton();
            this.radioButtonBlackAndWhiteFilter = new System.Windows.Forms.RadioButton();
            this.radioButtonNormalFilter = new System.Windows.Forms.RadioButton();
            this.labelChooseFilter = new System.Windows.Forms.Label();
            this.pictureBoxSuggests = new System.Windows.Forms.PictureBox();
            this.listBoxPhotos = new System.Windows.Forms.ListBox();
            this.buttonSuggestMe = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            this.facebookTabControl.SuspendLayout();
            this.myProfileTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbumPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            this.matchPeopleTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).BeginInit();
            this.imageSuggestaionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuggests)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.DataSource = this.albumBindingSource;
            this.listBoxAlbums.DisplayMember = "Name";
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 20;
            this.listBoxAlbums.Location = new System.Drawing.Point(76, 555);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(641, 244);
            this.listBoxAlbums.TabIndex = 37;
            this.listBoxAlbums.Visible = false;
            // 
            // albumBindingSource
            // 
            this.albumBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Album);
            // 
            // postStatusLabel
            // 
            this.postStatusLabel.AutoSize = true;
            this.postStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.postStatusLabel.Location = new System.Drawing.Point(253, 459);
            this.postStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postStatusLabel.Name = "postStatusLabel";
            this.postStatusLabel.Size = new System.Drawing.Size(118, 25);
            this.postStatusLabel.TabIndex = 44;
            this.postStatusLabel.Text = "Post Status:";
            // 
            // postStatusTextBox
            // 
            this.postStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postStatusTextBox.Location = new System.Drawing.Point(379, 454);
            this.postStatusTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.postStatusTextBox.Name = "postStatusTextBox";
            this.postStatusTextBox.Size = new System.Drawing.Size(270, 26);
            this.postStatusTextBox.TabIndex = 45;
            // 
            // postStatusButtonSet
            // 
            this.postStatusButtonSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.postStatusButtonSet.Location = new System.Drawing.Point(660, 449);
            this.postStatusButtonSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.postStatusButtonSet.Name = "postStatusButtonSet";
            this.postStatusButtonSet.Size = new System.Drawing.Size(112, 35);
            this.postStatusButtonSet.TabIndex = 46;
            this.postStatusButtonSet.Text = "Post";
            this.postStatusButtonSet.UseVisualStyleBackColor = true;
            this.postStatusButtonSet.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPosts.DataSource = this.postBindingSource;
            this.listBoxPosts.DisplayMember = "Type";
            this.listBoxPosts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 29;
            this.listBoxPosts.Location = new System.Drawing.Point(76, 555);
            this.listBoxPosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(641, 120);
            this.listBoxPosts.TabIndex = 40;
            this.listBoxPosts.Visible = false;
            // 
            // postBindingSource
            // 
            this.postBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Post);
            // 
            // AlbumsLink
            // 
            this.AlbumsLink.AutoSize = true;
            this.AlbumsLink.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumsLink.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.AlbumsLink.LinkColor = System.Drawing.Color.Navy;
            this.AlbumsLink.Location = new System.Drawing.Point(802, 502);
            this.AlbumsLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlbumsLink.Name = "AlbumsLink";
            this.AlbumsLink.Size = new System.Drawing.Size(106, 45);
            this.AlbumsLink.TabIndex = 47;
            this.AlbumsLink.TabStop = true;
            this.AlbumsLink.Text = "Albums";
            this.AlbumsLink.UseCompatibleTextRendering = true;
            this.AlbumsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAlbums_LinkClicked);
            // 
            // linkPosts
            // 
            this.linkPosts.AutoSize = true;
            this.linkPosts.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPosts.LinkArea = new System.Windows.Forms.LinkArea(0, 12);
            this.linkPosts.LinkColor = System.Drawing.Color.Gray;
            this.linkPosts.Location = new System.Drawing.Point(76, 502);
            this.linkPosts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkPosts.Name = "linkPosts";
            this.linkPosts.Size = new System.Drawing.Size(81, 45);
            this.linkPosts.TabIndex = 49;
            this.linkPosts.TabStop = true;
            this.linkPosts.Text = "Posts";
            this.linkPosts.UseCompatibleTextRendering = true;
            this.linkPosts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPosts_LinkClicked);
            // 
            // facebookTabControl
            // 
            this.facebookTabControl.Controls.Add(this.myProfileTabPage);
            this.facebookTabControl.Controls.Add(this.matchPeopleTabPage);
            this.facebookTabControl.Controls.Add(this.imageSuggestaionTabPage);
            this.facebookTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facebookTabControl.Location = new System.Drawing.Point(0, 0);
            this.facebookTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.facebookTabControl.Name = "facebookTabControl";
            this.facebookTabControl.SelectedIndex = 0;
            this.facebookTabControl.Size = new System.Drawing.Size(1054, 859);
            this.facebookTabControl.TabIndex = 51;
            // 
            // myProfileTabPage
            // 
            this.myProfileTabPage.AutoScroll = true;
            this.myProfileTabPage.BackColor = System.Drawing.Color.LightBlue;
            this.myProfileTabPage.Controls.Add(this.imageAlbumPictureBox);
            this.myProfileTabPage.Controls.Add(this.messageTextBox);
            this.myProfileTabPage.Controls.Add(this.matchAlertListBox);
            this.myProfileTabPage.Controls.Add(this.matchAlert);
            this.myProfileTabPage.Controls.Add(this.aboutMeLabel);
            this.myProfileTabPage.Controls.Add(this.friendsLinkLabel);
            this.myProfileTabPage.Controls.Add(this.aboutLabel);
            this.myProfileTabPage.Controls.Add(this.aboutLinkLabel);
            this.myProfileTabPage.Controls.Add(this.profilePictureBox);
            this.myProfileTabPage.Controls.Add(this.buttonLogout);
            this.myProfileTabPage.Controls.Add(this.userNameLabel);
            this.myProfileTabPage.Controls.Add(this.listBoxAlbums);
            this.myProfileTabPage.Controls.Add(this.AlbumsLink);
            this.myProfileTabPage.Controls.Add(this.listBoxPosts);
            this.myProfileTabPage.Controls.Add(this.postStatusButtonSet);
            this.myProfileTabPage.Controls.Add(this.postStatusTextBox);
            this.myProfileTabPage.Controls.Add(this.postStatusLabel);
            this.myProfileTabPage.Controls.Add(this.linkPosts);
            this.myProfileTabPage.Controls.Add(this.coverPictureBox);
            this.myProfileTabPage.Controls.Add(this.friendsListBox);
            this.myProfileTabPage.Location = new System.Drawing.Point(4, 29);
            this.myProfileTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.myProfileTabPage.Name = "myProfileTabPage";
            this.myProfileTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.myProfileTabPage.Size = new System.Drawing.Size(1046, 826);
            this.myProfileTabPage.TabIndex = 1;
            this.myProfileTabPage.Text = "My Profile";
            // 
            // imageAlbumPictureBox
            // 
            this.imageAlbumPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.albumBindingSource, "ImageAlbum", true));
            this.imageAlbumPictureBox.Location = new System.Drawing.Point(714, 555);
            this.imageAlbumPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imageAlbumPictureBox.Name = "imageAlbumPictureBox";
            this.imageAlbumPictureBox.Size = new System.Drawing.Size(297, 245);
            this.imageAlbumPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageAlbumPictureBox.TabIndex = 77;
            this.imageAlbumPictureBox.TabStop = false;
            this.imageAlbumPictureBox.Visible = false;
            // 
            // messageTextBox
            // 
            this.messageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postBindingSource, "Message", true));
            this.messageTextBox.Location = new System.Drawing.Point(714, 555);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(266, 124);
            this.messageTextBox.TabIndex = 75;
            this.messageTextBox.Visible = false;
            // 
            // matchAlertListBox
            // 
            this.matchAlertListBox.FormattingEnabled = true;
            this.matchAlertListBox.ItemHeight = 20;
            this.matchAlertListBox.Location = new System.Drawing.Point(802, 60);
            this.matchAlertListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchAlertListBox.Name = "matchAlertListBox";
            this.matchAlertListBox.Size = new System.Drawing.Size(234, 224);
            this.matchAlertListBox.TabIndex = 74;
            this.matchAlertListBox.Visible = false;
            // 
            // matchAlert
            // 
            this.matchAlert.BackColor = System.Drawing.Color.Transparent;
            this.matchAlert.ErrorImage = null;
            this.matchAlert.Image = global::DP_Targil1.Properties.Resources.alert;
            this.matchAlert.InitialImage = global::DP_Targil1.Properties.Resources.alert;
            this.matchAlert.Location = new System.Drawing.Point(975, 5);
            this.matchAlert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchAlert.Name = "matchAlert";
            this.matchAlert.Size = new System.Drawing.Size(55, 58);
            this.matchAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.matchAlert.TabIndex = 73;
            this.matchAlert.TabStop = false;
            this.matchAlert.WaitOnLoad = true;
            this.matchAlert.Click += new System.EventHandler(this.matchAlert_Click);
            // 
            // aboutMeLabel
            // 
            this.aboutMeLabel.AutoSize = true;
            this.aboutMeLabel.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutMeLabel.Location = new System.Drawing.Point(84, 561);
            this.aboutMeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutMeLabel.Name = "aboutMeLabel";
            this.aboutMeLabel.Size = new System.Drawing.Size(112, 30);
            this.aboutMeLabel.TabIndex = 72;
            this.aboutMeLabel.Text = "About Me";
            this.aboutMeLabel.Visible = false;
            // 
            // friendsLinkLabel
            // 
            this.friendsLinkLabel.AutoSize = true;
            this.friendsLinkLabel.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendsLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.friendsLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.friendsLinkLabel.Location = new System.Drawing.Point(546, 502);
            this.friendsLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.friendsLinkLabel.Name = "friendsLinkLabel";
            this.friendsLinkLabel.Size = new System.Drawing.Size(110, 45);
            this.friendsLinkLabel.TabIndex = 70;
            this.friendsLinkLabel.TabStop = true;
            this.friendsLinkLabel.Text = "Friends";
            this.friendsLinkLabel.UseCompatibleTextRendering = true;
            this.friendsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.friendsLinkLabel_LinkClicked);
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.Location = new System.Drawing.Point(86, 611);
            this.aboutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(0, 29);
            this.aboutLabel.TabIndex = 69;
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.aboutLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.aboutLinkLabel.Location = new System.Drawing.Point(315, 502);
            this.aboutLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(90, 45);
            this.aboutLinkLabel.TabIndex = 68;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "About";
            this.aboutLinkLabel.UseCompatibleTextRendering = true;
            this.aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLinkLabel_LinkClicked);
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Location = new System.Drawing.Point(397, 160);
            this.profilePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(140, 140);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.profilePictureBox.TabIndex = 41;
            this.profilePictureBox.TabStop = false;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(4, 9);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(112, 35);
            this.buttonLogout.TabIndex = 65;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.userNameLabel.Location = new System.Drawing.Point(406, 380);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(181, 37);
            this.userNameLabel.TabIndex = 63;
            this.userNameLabel.Text = "userNames";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.coverPictureBox.Location = new System.Drawing.Point(9, 62);
            this.coverPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(1004, 262);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverPictureBox.TabIndex = 66;
            this.coverPictureBox.TabStop = false;
            // 
            // friendsListBox
            // 
            this.friendsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendsListBox.DisplayMember = "name";
            this.friendsListBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.ItemHeight = 29;
            this.friendsListBox.Location = new System.Drawing.Point(76, 555);
            this.friendsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(934, 120);
            this.friendsListBox.TabIndex = 71;
            this.friendsListBox.Visible = false;
            // 
            // matchPeopleTabPage
            // 
            this.matchPeopleTabPage.BackColor = System.Drawing.Color.LightBlue;
            this.matchPeopleTabPage.BackgroundImage = global::DP_Targil1.Properties.Resources.love;
            this.matchPeopleTabPage.Controls.Add(this.CheckBoxShowMatchesWithPhotos);
            this.matchPeopleTabPage.Controls.Add(this.matcPeopleListBox);
            this.matchPeopleTabPage.Controls.Add(this.SuggestMeMatchingButtom);
            this.matchPeopleTabPage.Controls.Add(this.genderTextBox);
            this.matchPeopleTabPage.Controls.Add(this.genderLabel);
            this.matchPeopleTabPage.Controls.Add(this.homeTownTextBox);
            this.matchPeopleTabPage.Controls.Add(this.hometownLabel);
            this.matchPeopleTabPage.Controls.Add(this.label1);
            this.matchPeopleTabPage.Controls.Add(this.toAgeTextBox);
            this.matchPeopleTabPage.Controls.Add(this.fromAgeTextBox);
            this.matchPeopleTabPage.Controls.Add(this.ageLabel);
            this.matchPeopleTabPage.Controls.Add(this.filterLable);
            this.matchPeopleTabPage.Controls.Add(this.matchTextBox);
            this.matchPeopleTabPage.Controls.Add(this.messageButton);
            this.matchPeopleTabPage.Controls.Add(this.percentLabel);
            this.matchPeopleTabPage.Controls.Add(this.matchDetailsLabel);
            this.matchPeopleTabPage.Controls.Add(this.matchPictureBox);
            this.matchPeopleTabPage.Controls.Add(this.matchAboutLabel);
            this.matchPeopleTabPage.Controls.Add(this.circlePictureBox);
            this.matchPeopleTabPage.Location = new System.Drawing.Point(4, 29);
            this.matchPeopleTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchPeopleTabPage.Name = "matchPeopleTabPage";
            this.matchPeopleTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchPeopleTabPage.Size = new System.Drawing.Size(1046, 826);
            this.matchPeopleTabPage.TabIndex = 2;
            this.matchPeopleTabPage.Text = "Matching Suggestion";
            // 
            // CheckBoxShowMatchesWithPhotos
            // 
            this.CheckBoxShowMatchesWithPhotos.AutoSize = true;
            this.CheckBoxShowMatchesWithPhotos.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxShowMatchesWithPhotos.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.CheckBoxShowMatchesWithPhotos.Location = new System.Drawing.Point(51, 256);
            this.CheckBoxShowMatchesWithPhotos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxShowMatchesWithPhotos.Name = "CheckBoxShowMatchesWithPhotos";
            this.CheckBoxShowMatchesWithPhotos.Size = new System.Drawing.Size(256, 28);
            this.CheckBoxShowMatchesWithPhotos.TabIndex = 92;
            this.CheckBoxShowMatchesWithPhotos.Text = "Show Matches With Photos";
            this.CheckBoxShowMatchesWithPhotos.UseVisualStyleBackColor = false;
            // 
            // matcPeopleListBox
            // 
            this.matcPeopleListBox.DisplayMember = "Name";
            this.matcPeopleListBox.FormattingEnabled = true;
            this.matcPeopleListBox.ItemHeight = 20;
            this.matcPeopleListBox.Location = new System.Drawing.Point(50, 358);
            this.matcPeopleListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matcPeopleListBox.Name = "matcPeopleListBox";
            this.matcPeopleListBox.Size = new System.Drawing.Size(313, 284);
            this.matcPeopleListBox.TabIndex = 91;
            this.matcPeopleListBox.SelectedIndexChanged += new System.EventHandler(this.matchPeopleListBox_SelectedIndexChanged);
            // 
            // SuggestMeMatchingButtom
            // 
            this.SuggestMeMatchingButtom.Location = new System.Drawing.Point(50, 291);
            this.SuggestMeMatchingButtom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SuggestMeMatchingButtom.Name = "SuggestMeMatchingButtom";
            this.SuggestMeMatchingButtom.Size = new System.Drawing.Size(315, 39);
            this.SuggestMeMatchingButtom.TabIndex = 90;
            this.SuggestMeMatchingButtom.Text = "Suggest Me Matched People";
            this.SuggestMeMatchingButtom.UseVisualStyleBackColor = true;
            this.SuggestMeMatchingButtom.Click += new System.EventHandler(this.suggestMeMatchingButton_Click);
            // 
            // genderTextBox
            // 
            this.genderTextBox.Location = new System.Drawing.Point(154, 94);
            this.genderTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.Size = new System.Drawing.Size(84, 26);
            this.genderTextBox.TabIndex = 89;
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.BackColor = System.Drawing.Color.Transparent;
            this.genderLabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderLabel.Location = new System.Drawing.Point(45, 94);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(76, 24);
            this.genderLabel.TabIndex = 88;
            this.genderLabel.Text = "Gender:";
            // 
            // homeTownTextBox
            // 
            this.homeTownTextBox.Location = new System.Drawing.Point(154, 199);
            this.homeTownTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.homeTownTextBox.Name = "homeTownTextBox";
            this.homeTownTextBox.Size = new System.Drawing.Size(84, 26);
            this.homeTownTextBox.TabIndex = 86;
            // 
            // hometownLabel
            // 
            this.hometownLabel.AutoSize = true;
            this.hometownLabel.BackColor = System.Drawing.Color.Transparent;
            this.hometownLabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hometownLabel.Location = new System.Drawing.Point(46, 202);
            this.hometownLabel.Name = "hometownLabel";
            this.hometownLabel.Size = new System.Drawing.Size(101, 24);
            this.hometownLabel.TabIndex = 85;
            this.hometownLabel.Text = "Hometown:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 24);
            this.label1.TabIndex = 84;
            this.label1.Text = "-";
            this.label1.Visible = false;
            // 
            // toAgeTextBox
            // 
            this.toAgeTextBox.Location = new System.Drawing.Point(195, 146);
            this.toAgeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toAgeTextBox.Name = "toAgeTextBox";
            this.toAgeTextBox.Size = new System.Drawing.Size(39, 26);
            this.toAgeTextBox.TabIndex = 83;
            // 
            // fromAgeTextBox
            // 
            this.fromAgeTextBox.Location = new System.Drawing.Point(127, 146);
            this.fromAgeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fromAgeTextBox.Name = "fromAgeTextBox";
            this.fromAgeTextBox.Size = new System.Drawing.Size(39, 26);
            this.fromAgeTextBox.TabIndex = 82;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.Location = new System.Drawing.Point(45, 148);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(48, 24);
            this.ageLabel.TabIndex = 81;
            this.ageLabel.Text = "Age:";
            // 
            // filterLable
            // 
            this.filterLable.AutoSize = true;
            this.filterLable.BackColor = System.Drawing.Color.Transparent;
            this.filterLable.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLable.Location = new System.Drawing.Point(44, 34);
            this.filterLable.Name = "filterLable";
            this.filterLable.Size = new System.Drawing.Size(118, 31);
            this.filterLable.TabIndex = 80;
            this.filterLable.Text = "Filter By:";
            // 
            // matchTextBox
            // 
            this.matchTextBox.Location = new System.Drawing.Point(590, 612);
            this.matchTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchTextBox.Name = "matchTextBox";
            this.matchTextBox.Size = new System.Drawing.Size(354, 26);
            this.matchTextBox.TabIndex = 79;
            this.matchTextBox.Visible = false;
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(640, 652);
            this.messageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(251, 35);
            this.messageButton.TabIndex = 77;
            this.messageButton.Text = "Post";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Visible = false;
            this.messageButton.Click += new System.EventHandler(this.messageButton_Click);
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.BackColor = System.Drawing.Color.Transparent;
            this.percentLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLabel.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.percentLabel.Location = new System.Drawing.Point(690, 31);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(0, 32);
            this.percentLabel.TabIndex = 76;
            // 
            // matchDetailsLabel
            // 
            this.matchDetailsLabel.AutoSize = true;
            this.matchDetailsLabel.BackColor = System.Drawing.Color.Transparent;
            this.matchDetailsLabel.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchDetailsLabel.Location = new System.Drawing.Point(584, 355);
            this.matchDetailsLabel.Name = "matchDetailsLabel";
            this.matchDetailsLabel.Size = new System.Drawing.Size(265, 30);
            this.matchDetailsLabel.TabIndex = 75;
            this.matchDetailsLabel.Text = "Details About My Match";
            this.matchDetailsLabel.Visible = false;
            // 
            // matchPictureBox
            // 
            this.matchPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.matchPictureBox.Location = new System.Drawing.Point(590, 99);
            this.matchPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.matchPictureBox.Name = "matchPictureBox";
            this.matchPictureBox.Size = new System.Drawing.Size(253, 231);
            this.matchPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.matchPictureBox.TabIndex = 46;
            this.matchPictureBox.TabStop = false;
            // 
            // matchAboutLabel
            // 
            this.matchAboutLabel.AutoSize = true;
            this.matchAboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.matchAboutLabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchAboutLabel.Location = new System.Drawing.Point(585, 402);
            this.matchAboutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.matchAboutLabel.Name = "matchAboutLabel";
            this.matchAboutLabel.Size = new System.Drawing.Size(0, 24);
            this.matchAboutLabel.TabIndex = 45;
            // 
            // circlePictureBox
            // 
            this.circlePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.circlePictureBox.Location = new System.Drawing.Point(674, 8);
            this.circlePictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.circlePictureBox.Name = "circlePictureBox";
            this.circlePictureBox.Size = new System.Drawing.Size(109, 102);
            this.circlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circlePictureBox.TabIndex = 78;
            this.circlePictureBox.TabStop = false;
            this.circlePictureBox.Visible = false;
            this.circlePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.circlePictureBox_Paint);
            // 
            // imageSuggestaionTabPage
            // 
            this.imageSuggestaionTabPage.BackColor = System.Drawing.Color.LightBlue;
            this.imageSuggestaionTabPage.Controls.Add(this.labelDetails);
            this.imageSuggestaionTabPage.Controls.Add(this.labelAboutThePhoto);
            this.imageSuggestaionTabPage.Controls.Add(this.linkLabelLikesAndComments);
            this.imageSuggestaionTabPage.Controls.Add(this.linkLabelByComments);
            this.imageSuggestaionTabPage.Controls.Add(this.labelOrderBy);
            this.imageSuggestaionTabPage.Controls.Add(this.linkLabelByLikes);
            this.imageSuggestaionTabPage.Controls.Add(this.buttonSetProfilePic);
            this.imageSuggestaionTabPage.Controls.Add(this.labelChoosePhoto);
            this.imageSuggestaionTabPage.Controls.Add(this.radioButtonSepiaFilter);
            this.imageSuggestaionTabPage.Controls.Add(this.radioButtonTransparencyFilter);
            this.imageSuggestaionTabPage.Controls.Add(this.radioButtonBlackAndWhiteFilter);
            this.imageSuggestaionTabPage.Controls.Add(this.radioButtonNormalFilter);
            this.imageSuggestaionTabPage.Controls.Add(this.labelChooseFilter);
            this.imageSuggestaionTabPage.Controls.Add(this.pictureBoxSuggests);
            this.imageSuggestaionTabPage.Controls.Add(this.listBoxPhotos);
            this.imageSuggestaionTabPage.Controls.Add(this.buttonSuggestMe);
            this.imageSuggestaionTabPage.Location = new System.Drawing.Point(4, 29);
            this.imageSuggestaionTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageSuggestaionTabPage.Name = "imageSuggestaionTabPage";
            this.imageSuggestaionTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageSuggestaionTabPage.Size = new System.Drawing.Size(1046, 826);
            this.imageSuggestaionTabPage.TabIndex = 3;
            this.imageSuggestaionTabPage.Text = "Image Suggestion";
            // 
            // labelDetails
            // 
            this.labelDetails.AutoSize = true;
            this.labelDetails.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetails.Location = new System.Drawing.Point(654, 52);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(84, 30);
            this.labelDetails.TabIndex = 74;
            this.labelDetails.Text = "Details";
            this.labelDetails.Visible = false;
            // 
            // labelAboutThePhoto
            // 
            this.labelAboutThePhoto.AutoSize = true;
            this.labelAboutThePhoto.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutThePhoto.Location = new System.Drawing.Point(642, 109);
            this.labelAboutThePhoto.Name = "labelAboutThePhoto";
            this.labelAboutThePhoto.Size = new System.Drawing.Size(0, 24);
            this.labelAboutThePhoto.TabIndex = 73;
            this.labelAboutThePhoto.Visible = false;
            // 
            // linkLabelLikesAndComments
            // 
            this.linkLabelLikesAndComments.AutoSize = true;
            this.linkLabelLikesAndComments.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLikesAndComments.LinkArea = new System.Windows.Forms.LinkArea(0, 12);
            this.linkLabelLikesAndComments.LinkColor = System.Drawing.Color.Gray;
            this.linkLabelLikesAndComments.Location = new System.Drawing.Point(318, 362);
            this.linkLabelLikesAndComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelLikesAndComments.Name = "linkLabelLikesAndComments";
            this.linkLabelLikesAndComments.Size = new System.Drawing.Size(209, 34);
            this.linkLabelLikesAndComments.TabIndex = 72;
            this.linkLabelLikesAndComments.TabStop = true;
            this.linkLabelLikesAndComments.Text = "Likes and comments";
            this.linkLabelLikesAndComments.UseCompatibleTextRendering = true;
            this.linkLabelLikesAndComments.Visible = false;
            this.linkLabelLikesAndComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLikesAndComments_LinkClicked);
            // 
            // linkLabelByComments
            // 
            this.linkLabelByComments.AutoSize = true;
            this.linkLabelByComments.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelByComments.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.linkLabelByComments.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelByComments.Location = new System.Drawing.Point(154, 362);
            this.linkLabelByComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelByComments.Name = "linkLabelByComments";
            this.linkLabelByComments.Size = new System.Drawing.Size(113, 36);
            this.linkLabelByComments.TabIndex = 71;
            this.linkLabelByComments.TabStop = true;
            this.linkLabelByComments.Text = "Comments";
            this.linkLabelByComments.UseCompatibleTextRendering = true;
            this.linkLabelByComments.Visible = false;
            this.linkLabelByComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelByComments_LinkClicked);
            // 
            // labelOrderBy
            // 
            this.labelOrderBy.AutoSize = true;
            this.labelOrderBy.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderBy.Location = new System.Drawing.Point(40, 286);
            this.labelOrderBy.Name = "labelOrderBy";
            this.labelOrderBy.Size = new System.Drawing.Size(124, 31);
            this.labelOrderBy.TabIndex = 70;
            this.labelOrderBy.Text = "Order by:";
            this.labelOrderBy.Visible = false;
            // 
            // linkLabelByLikes
            // 
            this.linkLabelByLikes.AutoSize = true;
            this.linkLabelByLikes.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelByLikes.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.linkLabelByLikes.LinkColor = System.Drawing.Color.Navy;
            this.linkLabelByLikes.Location = new System.Drawing.Point(28, 362);
            this.linkLabelByLikes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelByLikes.Name = "linkLabelByLikes";
            this.linkLabelByLikes.Size = new System.Drawing.Size(61, 36);
            this.linkLabelByLikes.TabIndex = 69;
            this.linkLabelByLikes.TabStop = true;
            this.linkLabelByLikes.Text = "Likes";
            this.linkLabelByLikes.UseCompatibleTextRendering = true;
            this.linkLabelByLikes.Visible = false;
            this.linkLabelByLikes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelByLikes_LinkClicked);
            // 
            // buttonSetProfilePic
            // 
            this.buttonSetProfilePic.Location = new System.Drawing.Point(723, 751);
            this.buttonSetProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetProfilePic.Name = "buttonSetProfilePic";
            this.buttonSetProfilePic.Size = new System.Drawing.Size(186, 41);
            this.buttonSetProfilePic.TabIndex = 50;
            this.buttonSetProfilePic.Text = "Set as profile picture";
            this.buttonSetProfilePic.UseVisualStyleBackColor = true;
            this.buttonSetProfilePic.Visible = false;
            this.buttonSetProfilePic.Click += new System.EventHandler(this.buttonSetProfilePic_Click);
            // 
            // labelChoosePhoto
            // 
            this.labelChoosePhoto.AutoSize = true;
            this.labelChoosePhoto.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoosePhoto.Location = new System.Drawing.Point(40, 471);
            this.labelChoosePhoto.Name = "labelChoosePhoto";
            this.labelChoosePhoto.Size = new System.Drawing.Size(189, 31);
            this.labelChoosePhoto.TabIndex = 49;
            this.labelChoosePhoto.Text = "Choose a photo:";
            this.labelChoosePhoto.Visible = false;
            // 
            // radioButtonSepiaFilter
            // 
            this.radioButtonSepiaFilter.AutoSize = true;
            this.radioButtonSepiaFilter.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSepiaFilter.Location = new System.Drawing.Point(873, 682);
            this.radioButtonSepiaFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSepiaFilter.Name = "radioButtonSepiaFilter";
            this.radioButtonSepiaFilter.Size = new System.Drawing.Size(81, 27);
            this.radioButtonSepiaFilter.TabIndex = 48;
            this.radioButtonSepiaFilter.Text = "Sepia ";
            this.radioButtonSepiaFilter.UseVisualStyleBackColor = true;
            this.radioButtonSepiaFilter.Visible = false;
            this.radioButtonSepiaFilter.CheckedChanged += new System.EventHandler(this.radioButtonSepiaFilter_CheckedChanged);
            // 
            // radioButtonTransparencyFilter
            // 
            this.radioButtonTransparencyFilter.AutoSize = true;
            this.radioButtonTransparencyFilter.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTransparencyFilter.Location = new System.Drawing.Point(645, 682);
            this.radioButtonTransparencyFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonTransparencyFilter.Name = "radioButtonTransparencyFilter";
            this.radioButtonTransparencyFilter.Size = new System.Drawing.Size(135, 27);
            this.radioButtonTransparencyFilter.TabIndex = 47;
            this.radioButtonTransparencyFilter.Text = "Transparency";
            this.radioButtonTransparencyFilter.UseVisualStyleBackColor = true;
            this.radioButtonTransparencyFilter.Visible = false;
            this.radioButtonTransparencyFilter.CheckedChanged += new System.EventHandler(this.radioButtonTransparencyFilter_CheckedChanged);
            // 
            // radioButtonBlackAndWhiteFilter
            // 
            this.radioButtonBlackAndWhiteFilter.AutoSize = true;
            this.radioButtonBlackAndWhiteFilter.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBlackAndWhiteFilter.Location = new System.Drawing.Point(873, 571);
            this.radioButtonBlackAndWhiteFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonBlackAndWhiteFilter.Name = "radioButtonBlackAndWhiteFilter";
            this.radioButtonBlackAndWhiteFilter.Size = new System.Drawing.Size(149, 27);
            this.radioButtonBlackAndWhiteFilter.TabIndex = 46;
            this.radioButtonBlackAndWhiteFilter.Text = "Black and white";
            this.radioButtonBlackAndWhiteFilter.UseVisualStyleBackColor = true;
            this.radioButtonBlackAndWhiteFilter.Visible = false;
            this.radioButtonBlackAndWhiteFilter.CheckedChanged += new System.EventHandler(this.radioButtonBlackAndWhiteFilter_CheckedChanged);
            // 
            // radioButtonNormalFilter
            // 
            this.radioButtonNormalFilter.AutoSize = true;
            this.radioButtonNormalFilter.Checked = true;
            this.radioButtonNormalFilter.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNormalFilter.Location = new System.Drawing.Point(645, 571);
            this.radioButtonNormalFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNormalFilter.Name = "radioButtonNormalFilter";
            this.radioButtonNormalFilter.Size = new System.Drawing.Size(88, 27);
            this.radioButtonNormalFilter.TabIndex = 45;
            this.radioButtonNormalFilter.TabStop = true;
            this.radioButtonNormalFilter.Text = "Normal";
            this.radioButtonNormalFilter.UseVisualStyleBackColor = true;
            this.radioButtonNormalFilter.Visible = false;
            this.radioButtonNormalFilter.CheckedChanged += new System.EventHandler(this.radioButtonNormalFilter_CheckedChanged);
            // 
            // labelChooseFilter
            // 
            this.labelChooseFilter.AutoSize = true;
            this.labelChooseFilter.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseFilter.Location = new System.Drawing.Point(717, 471);
            this.labelChooseFilter.Name = "labelChooseFilter";
            this.labelChooseFilter.Size = new System.Drawing.Size(176, 31);
            this.labelChooseFilter.TabIndex = 44;
            this.labelChooseFilter.Text = "Choose a filter";
            this.labelChooseFilter.Visible = false;
            // 
            // pictureBoxSuggests
            // 
            this.pictureBoxSuggests.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxSuggests.Location = new System.Drawing.Point(318, 52);
            this.pictureBoxSuggests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxSuggests.Name = "pictureBoxSuggests";
            this.pictureBoxSuggests.Size = new System.Drawing.Size(278, 246);
            this.pictureBoxSuggests.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSuggests.TabIndex = 43;
            this.pictureBoxSuggests.TabStop = false;
            this.pictureBoxSuggests.Visible = false;
            // 
            // listBoxPhotos
            // 
            this.listBoxPhotos.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxPhotos.FormattingEnabled = true;
            this.listBoxPhotos.ItemHeight = 20;
            this.listBoxPhotos.Location = new System.Drawing.Point(28, 526);
            this.listBoxPhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxPhotos.Name = "listBoxPhotos";
            this.listBoxPhotos.Size = new System.Drawing.Size(448, 264);
            this.listBoxPhotos.TabIndex = 38;
            this.listBoxPhotos.Visible = false;
            this.listBoxPhotos.SelectedIndexChanged += new System.EventHandler(this.listBoxPhotos_SelectedIndexChanged);
            // 
            // buttonSuggestMe
            // 
            this.buttonSuggestMe.Location = new System.Drawing.Point(28, 52);
            this.buttonSuggestMe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSuggestMe.Name = "buttonSuggestMe";
            this.buttonSuggestMe.Size = new System.Drawing.Size(252, 41);
            this.buttonSuggestMe.TabIndex = 0;
            this.buttonSuggestMe.Text = "Suggest me a profile picture";
            this.buttonSuggestMe.UseVisualStyleBackColor = true;
            this.buttonSuggestMe.Click += new System.EventHandler(this.buttonSuggestMeImage_Click);
            // 
            // FacebookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 859);
            this.Controls.Add(this.facebookTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FacebookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook For Desktop";
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            this.facebookTabControl.ResumeLayout(false);
            this.myProfileTabPage.ResumeLayout(false);
            this.myProfileTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbumPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            this.matchPeopleTabPage.ResumeLayout(false);
            this.matchPeopleTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).EndInit();
            this.imageSuggestaionTabPage.ResumeLayout(false);
            this.imageSuggestaionTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuggests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox profilePictureBox;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Label postStatusLabel;
        private System.Windows.Forms.TextBox postStatusTextBox;
        private System.Windows.Forms.Button postStatusButtonSet;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.LinkLabel AlbumsLink;
        private System.Windows.Forms.LinkLabel linkPosts;
        private System.Windows.Forms.TabControl facebookTabControl;
        private System.Windows.Forms.TabPage myProfileTabPage;
        private TabPage imageSuggestaionTabPage;
        private Label userNameLabel;
        private Button buttonLogout;
        private PictureBox coverPictureBox;
        private LinkLabel aboutLinkLabel;
        private Label aboutLabel;
        private LinkLabel friendsLinkLabel;
        private ListBox friendsListBox;
        private Label aboutMeLabel;
        private Button buttonSuggestMe;
        private ListBox listBoxPhotos; 
        private PictureBox pictureBoxSuggests;
        private RadioButton radioButtonSepiaFilter;
        private RadioButton radioButtonTransparencyFilter;
        private RadioButton radioButtonBlackAndWhiteFilter;
        private RadioButton radioButtonNormalFilter;
        private Label labelChooseFilter;
        private Button buttonSetProfilePic;
        private Label labelChoosePhoto;
        private LinkLabel linkLabelByComments;
        private Label labelOrderBy;
        private LinkLabel linkLabelByLikes;
        private LinkLabel linkLabelLikesAndComments;
        private Label labelAboutThePhoto;
        private Label labelDetails;
        private TabPage matchPeopleTabPage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label matchAboutLabel;
        private PictureBox matchPictureBox;
        private Label matchDetailsLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label percentLabel;
        private Button messageButton;
        private PictureBox circlePictureBox;
        private TextBox matchTextBox;
        private ListBox matchAlertListBox;
        private PictureBox matchAlert;
        private TextBox homeTownTextBox;
        private Label hometownLabel;
        private Label label1;
        private TextBox toAgeTextBox;
        private TextBox fromAgeTextBox;
        private Label ageLabel;
        private Label filterLable;
        private TextBox genderTextBox;
        private Label genderLabel;
        private ListBox matcPeopleListBox;
        private Button SuggestMeMatchingButtom;
        private BindingSource postBindingSource;
        private TextBox messageTextBox;
        private BindingSource albumBindingSource;
        private PictureBox imageAlbumPictureBox;
        private CheckBox CheckBoxShowMatchesWithPhotos;

        public Label LabelAboutThePhoto
        {
            get
            {
                return labelAboutThePhoto;
            }

            set
            {
                labelAboutThePhoto = value;
            }
        }

        public ListBox ListBoxPhotos
        {
            get
            {
                return listBoxPhotos;
            }

            set
            {
                listBoxPhotos = value;
            }
        }

        public PictureBox PictureBoxSuggests
        {
            get
            {
                return pictureBoxSuggests;
            }

            set
            {
                pictureBoxSuggests = value;
            }
        }
    }
}
