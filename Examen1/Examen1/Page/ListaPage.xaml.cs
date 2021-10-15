using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen1.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPage : ContentPage
    {
        public ListaPage()
        {
            InitializeComponent();
        }

        public async void LlenarDatos()
        {
            var datoslist = await App.SQLiteDB.GetDatosAync();
            if (datoslist != null)
            {
                LstDatos.ItemsSource = datoslist;
            }
            else
            {

            }
        }
        protected async override void OnAppearing()
        {
            var datoslist = await App.SQLiteDB.GetDatosAync();
            if (datoslist != null)
            {
                LstDatos.ItemsSource = datoslist;
            }
            else
            {

            }
        }

        private async void LstDatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.DatosGps item = (Models.DatosGps)e.Item;
            var ver = new Page.UpdatePage();
            ver.BindingContext = item;
            await Navigation.PushAsync(ver);
        }
    }
}