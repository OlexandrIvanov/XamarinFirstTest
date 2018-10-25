using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Test1
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
         
        }

        private void OnButtonClicked(object sender, System.EventArgs e) {
            
            if (!String.IsNullOrEmpty(myEnasd.Text)&&!String.IsNullOrEmpty(entryPassword.Text)){
                if (myEnasd.Text.Length > 6 && EmailValidate(myEnasd.Text))
                {
                    if (entryPassword.Text.Length > 6)
                    {
                        ToSecondForm();
           
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Password Error", "Incorrect Password", "OK");
                        });
                    }

                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Email Error", "Incorrect Email", "OK");
                    });
                }
            }



        }

        private bool EmailValidate(string s) {
          
            string a = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
           
            Regex regex = new Regex(a);
            Match match = regex.Match(s);

            

            return match.Success;
        }

        private async void ToSecondForm()
        {
            await Navigation.PushModalAsync(new SecondForm());
        }
    }
}
