﻿using System;
using System.Collections.ObjectModel;
using AnorocMobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AnorocMobileApp.ViewModels.Home
{
    /// <summary>
    /// ViewModel for Home page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class HomeViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Models.Home> featuredStories;

        private ObservableCollection<Models.Home> latestStories;

        private ObservableCollection<Models.ContagionContact> contagionContact;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="HomeViewModel" /> class.
        /// </summary>
        public HomeViewModel()
        {
            this.ContagionContact = new ObservableCollection<ContagionContact>
            {
                new Models.ContagionContact
                {
                    Location = "Francis Baard, Pretoria",
                    DateTime = new DateTime(2020, 07, 15, 13, 30, 0)
                },
                new Models.ContagionContact
                {
                    Location = "Menlyn Mall, Pretoria",
                    DateTime = new DateTime(2020, 03, 11, 15, 30, 0)
                },
                new Models.ContagionContact
                {
                    Location = "Mike's Butchery",
                    DateTime = new DateTime(2020, 02, 14, 12, 30, 0)
                }
            };

            this.FeaturedStories = new ObservableCollection<Models.Home>
            {
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage2.png",
                    Name = "Learning to Reset",
                    Author = "John Doe",
                    Date = "Aug 2010",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage3.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage4.png",
                    Name = "Guiding Your Flock to Success",
                    Author = "John Doe",
                    Date = "May 2012",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage5.png",
                    Name = "Be a Nurturing, Fierce Team Leader",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage6.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Dec 2013",
                    AverageReadingTime = "5 mins read"
                }
            };

            this.LatestStories = new ObservableCollection<Models.Home>
            {
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "Article_image1.png",
                    Name = "Learning to Reset",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "Article_image2.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "May 26",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "Article_image3.png",
                    Name = "Guiding Your Flock to Success",
                    Author = "John Doe",
                    Date = "Apr 10",
                    AverageReadingTime = "5 mins read"
                },
                new Models.Home
                {
                    ImagePath = App.BaseImageUrl + "Article_image4.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
            };

            this.MenuCommand = new Command(this.MenuClicked);
            this.BookmarkCommand = new Command(this.BookmarkButtonClicked);
            this.FeatureStoriesCommand = new Command(this.FeatureStoriesClicked);
            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }
        #endregion

        #region Public Properties

        public ObservableCollection<ContagionContact> ContagionContact
        {
            get => contagionContact;
            set
            {
                if (this.contagionContact == value)
                {
                    return;
                }

                this.contagionContact = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with the rotator view, which displays the articles featured stories items.
        /// </summary>
        public ObservableCollection<Models.Home> FeaturedStories
        {
            get
            {
                return this.featuredStories;
            }

            set
            {
                if (this.featuredStories == value)
                {
                    return;
                }

                this.featuredStories = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with the list view, which displays the articles latest stories items.
        /// </summary>
        public ObservableCollection<Models.Home> LatestStories
        {
            get
            {
                return this.latestStories;
            }

            set
            {
                if (this.latestStories == value)
                {
                    return;
                }

                this.latestStories = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the bookmark button is clicked.
        /// </summary>
        public Command BookmarkCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will executed when the feature stories item is clicked.
        /// </summary>
        public Command FeatureStoriesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the bookmark button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            if (obj is Models.Home article)
            {
                article.IsBookmarked = !article.IsBookmarked;
            }
        }

        /// <summary>
        /// Invoked when the the feature stories item is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void FeatureStoriesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ItemSelected(object obj)
        {
            // Do something
        }

        #endregion
    }
}
