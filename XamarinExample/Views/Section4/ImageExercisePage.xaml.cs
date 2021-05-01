using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Section4
{
    public partial class ImageExercisePage : ContentPage
    {
        private int imageId = 1;
        private string imageUrl = "";

        public ImageExercisePage()
        {
            InitializeComponent();
            //previousImage.Source = ImageSource.FromResource("XamarinExample.Images.left.png");
            nextImage.Source = ImageSource.FromResource("XamarinExample.Images.right.png");
            BindImage();
        }

        void BindImage()
        {
            switch (imageId)
            {
                case 1: imageUrl = "https://image.freepik.com/free-photo/hand-painted-watercolor-background-with-sky-clouds-shape_24972-1095.jpg"; break;
                case 2: imageUrl = "https://image.freepik.com/free-vector/white-abstract-background_23-2148810113.jpg"; break;
                case 3: imageUrl = "https://image.freepik.com/free-vector/blue-copy-space-digital-background_23-2148821698.jpg"; break;
                default: imageUrl = "https://image.freepik.com/free-photo/hand-painted-watercolor-background-with-sky-clouds-shape_24972-1095.jpg"; break;
            }

            image.Source = new UriImageSource
            {
                Uri = new Uri(String.Format(imageUrl)),
                CachingEnabled = false
            };
        }

        void Previous_Clicked(object sender, EventArgs e)
        {
            if (imageId == 1)
                imageId = 3;
            else
                imageId--;

            BindImage();
        }

        void Next_Clicked(object sender, EventArgs e)
        {
            if (imageId == 3)
                imageId = 1;
            else
                imageId++;

            BindImage();
        }
    }
}
