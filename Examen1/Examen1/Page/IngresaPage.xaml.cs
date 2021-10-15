using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using System.Diagnostics;

namespace Examen1.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresaPage : ContentPage
    {

        public double lat;
        public double longi;
        public IngresaPage()
        {
            Localizar();
            InitializeComponent();
            
        }
        private async void Localizar()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationEnabled)
            {
                if (!locator.IsListening)
                {
                    await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                }

                locator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    txtlongitud.Text = loc.Longitude.ToString();
                    longi = double.Parse(txtlongitud.Text);
                    txtlatitud.Text = loc.Latitude.ToString();
                    lat = double.Parse(txtlatitud.Text);
                };
            }

        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (ValidarGps())
            {
                if (ValidarDatos())
                {
                    DatosGps datos = new DatosGps
                    {
                        IdDatos = Convert.ToInt32(this.txtcod.Text),
                        longitud = Convert.ToDouble(this.txtlatitud.Text),
                        latitud = Convert.ToDouble(this.txtlongitud.Text),
                        textocorto = this.txtcorto.Text,
                        textolargo = this.txtlargo.Text

                    };
                    await App.SQLiteDB.SaveDatos(datos);
                    await DisplayAlert("Registro", "Datos agregados de manera correcta", "ok");
                    MapLaunchOptions options = new MapLaunchOptions { Name = txtcorto.Text };
                    await Map.OpenAsync(lat, longi, options);

                    


                }
                else
                {
                    await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
                }
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese Latitud y Longitud", "ok");
            }
           

        }

        private async void BtnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page.ListaPage());
        }

        public bool ValidarGps()
        {
            bool rspgps;
            if (String.IsNullOrEmpty(txtlongitud.Text))
            {
                rspgps = false;
            }

            else if (String.IsNullOrEmpty(txtlatitud.Text))
            {
                rspgps = false;
            }

            else
            {
                rspgps = true;
            }

            return rspgps;
        }

        public bool ValidarDatos()
        {
            bool respuesta;

            if (String.IsNullOrEmpty(txtlongitud.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(txtlatitud.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(txtcorto.Text))
            {
                respuesta = false;
            }
            else if (String.IsNullOrEmpty(txtlargo.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;

        }
        public void Borrar()
        {
            txtcod.Text = "";
            txtlatitud.Text = "";
            txtlargo.Text = "";
            txtlongitud.Text = "";
            txtcorto.Text = "";

        }

        private async void Btnlts_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page.ListaPage());
        }

        private void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            txtcod.Text = "";
            txtlatitud.Text = "";
            txtlargo.Text = "";
            txtlongitud.Text = "";
            txtcorto.Text = "";
        }

       

        
    }
}