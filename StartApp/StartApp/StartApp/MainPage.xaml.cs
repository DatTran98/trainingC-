using StartApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StartApp
{
   
    public partial class MainPage : ContentPage
    {
        private int count = 0;
        public MainPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.DisplayOkLoginPrompt += () => DisplayAlert("Error", "Success Login", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            
            (sender as Button).Text = "Click me again!" + count;
            count ++;
            (sender as Button).CornerRadius = count;
        }
    }
}
