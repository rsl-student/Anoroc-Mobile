﻿using System;
using AnorocMobileApp.Models;
using AnorocMobileApp.Services;
using AnorocMobileApp.Views.Navigation;
using Microsoft.Identity.Client;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AnorocMobileApp.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWithSocialIconPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWithSocialIconPage" /> class.
        /// </summary>
        public LoginWithSocialIconPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function sets Main Page to Navigation Page
        /// </summary>
        private void Button_Clicked(object sender, EventArgs e)
        {
             OnSignInSignOut(sender,e);
        }

        async void OnSignInSignOut(object sender, EventArgs e)
        {


            try
            {
                var userContext = await B2CAuthenticationService.Instance.SignInAsync();
                UpdateSignInState(userContext);
                if(userContext.IsLoggedOn)
                {
                    Console.WriteLine("Access Token: " + userContext.AccessToken);
                    Application.Current.Properties["TOKEN"] = userContext.AccessToken;
                 }
                else
                {
                    Console.WriteLine("Error: Access Token is not available");
                }

            }
            catch (Exception ex)
            {
                // Checking the exception message 
                // should ONLY be done for B2C
                // reset and not any other error.
                if (ex.Message.Contains("AADB2C90118"))
                    OnPasswordReset();
                // Alert if any exception excluding user canceling sign-in dialog
                else if (((ex as MsalException)?.ErrorCode != "authentication_canceled"))
                    await DisplayAlert($"Exception:", ex.ToString(), "Dismiss");
            }


        }


        void UpdateSignInState(UserContext userContext)
        {
            var isSignedIn = userContext.IsLoggedOn;
            btnSignInSignOut.Text = isSignedIn ? "Sign out" : "Sign in";

        }

    }
}