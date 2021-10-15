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
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            Models.DatosGps dat = new Models.DatosGps();
            dat.IdDatos = Convert.ToInt32(txtcod.Text);
            dat.longitud = Convert.ToDouble(txtlongitud.Text);
            dat.latitud = Convert.ToDouble(txtlatitud.Text);
            dat.textocorto = txtcorto.Text;
            dat.textolargo = txtlargo.Text;

            if (await App.SQLiteDB.SaveDatos(dat) != 0)
            {
                await DisplayAlert("Datos Actualizado", "Los datos han sido actualizados", "Ok");
                await Navigation.PushAsync(new Page.ListaPage());
            }
            else
            {
                await DisplayAlert("Error", "Problema al actualizar datos", "Ok");
            }
        }

        private async void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            Models.DatosGps dat = new Models.DatosGps();
            dat.IdDatos = Convert.ToInt32(txtcod.Text);
            dat.longitud = Convert.ToDouble(txtlongitud.Text);
            dat.latitud = Convert.ToDouble(txtlatitud.Text);
            dat.textocorto = txtcorto.Text;
            dat.textolargo = txtlargo.Text;

            if (await App.SQLiteDB.DropDatosAsync(dat) != 0)
            {
                await DisplayAlert("Drop", "Los datos han sido borrados", "Ok");
                await Navigation.PushAsync(new Page.ListaPage());
            }
            else
            {
                await DisplayAlert("Drop", "Problema al borrar los datos", "Ok");
            }
        }
    }
}