using ClubItSSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClubItSSC.Views
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
            Lbl_Header.TextColor = Constants.MainTextColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            Lbl_Header2.TextColor = Constants.SecondaryTextColor;
            Entry_Username.TextColor = Constants.SecondaryTextColor;
            Entry_Password.TextColor = Constants.SecondaryTextColor;
          
            ActivitySpinner.IsVisible = false;

            Lbl_Header.VerticalOptions = LayoutOptions.CenterAndExpand;
            Lbl_Header.HorizontalOptions = LayoutOptions.CenterAndExpand;
            Lbl_Header.XAlign = TextAlignment.Center;
            Lbl_Header.FontSize = Constants.LabelSize;
            Lbl_Header.Style = Device.Styles.TitleStyle;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => LoginProcedure(s, e);
        }

        //object is the source of the event; EventArgs shows information about an event
        //with the e variable
        // - the await keyword makes sure that nothing within the If Else is executed 
        // before the user clicks "Ok"; in this case the login procedure has to be async
        void LoginProcedure(object sender, EventArgs e)
        {
            // - this makes a new user with new information from the entry fields
            // - using .Text after the variable name extracts the variables (Entry_Username and
            // Entry_Password from the xaml
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            // the CheckInformation function is within the User class
            // this function checks for input in the login fields, returning true if there
            // is input and false if the user hasn't entered text in the fields
            if (user.CheckInformation())
            {
                //Login is the name of the alert box; Login Successful is the alert
                // text that displays when the box pops up; Ok is the text on the button
                // that closes the alert box
                DisplayAlert("Login", "Login Successful", "Ok");
                // var result = await App.RestService.Login(user)
                //if (result.access_token != null)
                //{
                //    //App.UserDatabase.SaveUser(user);
                //}
            }
            // else an alert is shown 
            else
            {
                DisplayAlert("Login", "Login failed, Please enter a username or password.", "Ok");
            }
        }
    }
}