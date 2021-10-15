using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Examen1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page.IngresaPage());
        }
    }
}
