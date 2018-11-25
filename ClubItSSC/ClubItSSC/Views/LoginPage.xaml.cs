using ClubItSSC.Models;
using System;
using lcpi.data.oledb;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.Common;
using System.Data;

namespace ClubItSSC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //private OleDbConnection connection = new OleDbConnection();
        public LoginPage()
        {
            InitializeComponent();
            
            Init();
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Header.TextColor = Constants.MainTextColor;
            Lbl_Email.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            Lbl_Header2.TextColor = Constants.SecondaryTextColor;
            Entry_Email.TextColor = Constants.SecondaryTextColor;
            Entry_Password.TextColor = Constants.SecondaryTextColor;
          
            ActivitySpinner.IsVisible = false;

            Lbl_Header.VerticalOptions = LayoutOptions.CenterAndExpand;
            Lbl_Header.HorizontalOptions = LayoutOptions.CenterAndExpand;
            Lbl_Header.HorizontalTextAlignment = TextAlignment.Center;
            Lbl_Header.FontSize = Constants.LabelSize;
            Lbl_Header.Style = Device.Styles.TitleStyle;

            Entry_Email.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => LoginButtonClicked(s, e);

            //Entry_Password.Completed += (s, e) => Btn_Login_Click(s, e);
        }

        //object is the source of the event; EventArgs shows information about an event
        //with the e variable
        // - the await keyword makes sure that nothing within the If Else is executed 
        // before the user clicks "Ok"; in this case the login procedure has to be async
       

        //void Btn_Login_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand
        //        {
        //            Connection = connection,
        //            CommandText = "select * from User where user_email= '" + Entry_Username.Text + "' and user_password= '" + Entry_Password.Text + "'"
        //        };
        //        OleDbDataReader reader = command.ExecuteReader();
        //        int count = 0;
        //        while(reader.Read())
        //        {
        //            count += 1;
        //        }
        //        if(count == 1)
        //           {
        //              DisplayAlert("Login Alert", "Username and password already exists. Try Again", "Ok");
        //           }
        //        else
        //           {
        //              DisplayAlert(" Login Alert", "Username or password is not correct.", "Ok");
        //           }
        //        connection.Close();   
        //    }
        //    catch (Exception exception)
        //    {
        //         DisplayAlert( "Connection Check", "Error Occurred", "Ok");
        //    }
        //}

        void LoginButtonClicked(object sender, EventArgs e)
        {
            // define the user info that will be inserted
            User user = new User()
            {
                Email = Entry_Email.Text,
                Password = Entry_Password.Text
            };
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Successful", "Ok");
                // make a specific element (the database connection) exist only inside the dbcontext
                // as soon as the using statement is executed, the connection will be disposed
                using (OleDbConnection conn = new OleDbConnection(App.FilePath))  // might have to specify database connection string instead of App.FilePath
                {
                    OleDbCommand command = new OleDbCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO User (user_email, user_password) VALUES (?, ?)";
                    command.Parameters.AddWithValue("user_email", Entry_Email.Text);
                    command.Parameters.AddWithValue("user_password", Entry_Password.Text);
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    DisplayAlert("Alert", "User has been added to database.", "Ok");
                    conn.Close();
                }
            }
            else
            {
                DisplayAlert("Login", "Login failed, Please enter a username or password.", "Ok");
            }
        }
    }
}