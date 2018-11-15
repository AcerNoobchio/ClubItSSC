using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubItConsole.Models
{
    public class Constants
    {
        public static bool isInDev = true;
        public static Color BackgroundColor = Color.FromRgb(16, 30, 81);
        public static Color MainTextColor = Color.White;
        public static int LabelSize = 200;
        public static int LoginIconHeight = 500;

        //-----------Login------------
        public static string LoginURL = "https://test.com/api/Auth/Login";
    }
}
