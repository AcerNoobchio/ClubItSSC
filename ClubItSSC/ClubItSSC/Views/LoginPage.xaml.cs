using ClubItConsole.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClubItSSC;

namespace ClubItConsole.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            Lbl_Header.VerticalOptions = LayoutOptions.CenterAndExpand;
            Lbl_Header.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => LoginProcedureAsync(s, e);
        }

        async void LoginProcedureAsync(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if(user.CheckInformation())
            {
                DisplayAlert("Login", "Login Successful", "Ok");
                var result = await App.RestService.Login(user);
                if(result.access_token != null)
                {
                    App.UserDatabase.SaveUser(user);
                }
            }
            else
            {
                DisplayAlert("Login", "Login Unsuccessful, You are missing a username or password.", "Ok");
            }
        }
    }
}