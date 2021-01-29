using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1
{
    public class ImageSuggestion
    {
        private StringBuilder m_AboutString;

        public User User { get; set; }

        public Photo SourcePhoto { get; set; }

        public FacebookObjectCollection<Album> AlbumsCollection { get; set; }

        public List<Photo> Photos { get; set; }

        public ImageSuggestion(User i_User)
        {
            m_AboutString = new StringBuilder();
            User = i_User;
            initAlbums();
            initPhotos();
        }

        private void initAlbums()
        {
             AlbumsCollection = new FacebookObjectCollection<Album>();
             
             foreach (Album album in User.Albums)
             {
                  AlbumsCollection.Add(album);
             }
        }

        private void initPhotos()
        {
            Photos = new List<Photo>();

            if (AlbumsCollection != null)
            {
                foreach (Album album in AlbumsCollection)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        Photos.Add(photo);
                        if (Photos.Count == 20)
                        {
                            return;
                        }
                    }
                }
            }
        }


        public int comparisonByLikes(Photo i_Photo1, Photo i_Photo2)
        {
            return i_Photo2.LikedBy.Count.CompareTo(i_Photo1.LikedBy.Count);
        }

        public int comparisonByComments(Photo i_Photo1, Photo i_Photo2)
        {
            return i_Photo2.Comments.Count.CompareTo(i_Photo1.Comments.Count);
        }

        public int comparisonByLikesAndComments(Photo i_Photo1, Photo i_Photo2)
        {
            return (i_Photo2.Comments.Count * i_Photo2.LikedBy.Count).CompareTo(i_Photo1.Comments.Count * i_Photo1.LikedBy.Count);
        }

        public string SetDetailsPhoto()
        {
            m_AboutString.Clear();
            m_AboutString.Append(string.Format("Title: {0}{1}", SourcePhoto.Name, Environment.NewLine));
            m_AboutString.Append(string.Format("Album name: {0}{1}", SourcePhoto.Album.Name, Environment.NewLine));
            m_AboutString.Append(string.Format("Upload Time: {0}{1}", SourcePhoto.CreatedTime.ToString(), Environment.NewLine));
            m_AboutString.Append(string.Format("Quantity of likes: {0}{1}", SourcePhoto.LikedBy.Count, Environment.NewLine));
            m_AboutString.Append(string.Format("Quantity of comments: {0}{1}", SourcePhoto.Comments.Count, Environment.NewLine));

            return m_AboutString.ToString();
        }

        public Bitmap SetFilter(eFilter i_Filter)
        {
            Bitmap newBmp = new Bitmap(SourcePhoto.ImageNormal.Width, SourcePhoto.ImageNormal.Height);
            Graphics graphics = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = null;

            switch (i_Filter)
            {
                case eFilter.BlackAndWhite:
                    {
                        colorMatrix = blackAndWhiteFilter();
                    }

                    break;
                case eFilter.Transparency:
                    {
                        colorMatrix = transparencyFilter();
                    }

                    break;
                case eFilter.Sepia:
                    {
                        colorMatrix = sepiaFilter();
                    }

                    break;
            }

            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            graphics.DrawImage(SourcePhoto.ImageNormal, new Rectangle(0, 0, SourcePhoto.ImageNormal.Width, SourcePhoto.ImageNormal.Height), 0, 0, SourcePhoto.ImageNormal.Width, SourcePhoto.ImageNormal.Height, GraphicsUnit.Pixel, img);
            graphics.Dispose();

            return newBmp;
        }

        private ColorMatrix blackAndWhiteFilter()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { .3f, .3f, .3f, 0, 0 },
                        new float[] { .59f, .59f, .59f, 0, 0 },
                        new float[] { .11f, .11f, .11f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }

        private ColorMatrix sepiaFilter()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { .393f, .349f, .272f, 0, 0 },
                        new float[] { .769f, .686f, .534f, 0, 0 },
                        new float[] { .189f, .168f, .131f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }

        private ColorMatrix transparencyFilter()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { 1, 0, 0, 0, 0 },
                        new float[] { 0, 1, 0, 0, 0 },
                        new float[] { 0, 0, 1, 0, 0 },
                        new float[] { 0, 0, 0, 0.3f, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }

        public byte[] ConvertImageToBytes(Image i_Image)
        {
           ImageConverter imageConverter = new ImageConverter();
           byte[] byteArr = (byte[])imageConverter.ConvertTo(i_Image, typeof(byte[]));
           return byteArr;
        }
    }
}