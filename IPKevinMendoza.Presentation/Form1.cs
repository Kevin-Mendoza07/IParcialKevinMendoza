using IPKevinMendoza.AppCore.Interfaces;
using IPKevinMendoza.Domain.Entitites;
using IPKevinMendoza.Infraestructure.Repositories;
using IPKevinMendoza.Infraestructure.WeatherAPIClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPKevinMendoza.Presentation
{
    public partial class Form1 : Form
    {
        public IWeatherServices weatherServices;
        public OpenWeatherAPIClient openWeatherAPIClient;
        public OpenWeather openWeather;
        public OneCallAPI oneCallAPI;
        public FileOpenWeatherClient fileOpenWeatherClient;
        public List<FilterSearch> filterSearches=new List<FilterSearch>();
        private string city;
        public Form1(IWeatherServices weatherServices)
        {
            this.weatherServices=weatherServices;
            openWeatherAPIClient = new OpenWeatherAPIClient();
            fileOpenWeatherClient=new FileOpenWeatherClient();
            InitializeComponent();
            
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

            FrmHistorial frmHistorial = new FrmHistorial();
            foreach(var items in filterSearches)
            {
                frmHistorial.cmbFiltrar.Items.Add(items.NameCities);
            }

            object[] DistinctItems = (from object obj in frmHistorial.cmbFiltrar.Items select obj).Distinct().ToArray();
            frmHistorial.cmbFiltrar.Items.Clear();
            frmHistorial.cmbFiltrar.Items.AddRange(DistinctItems);

            frmHistorial.weatherServices = weatherServices;
            frmHistorial.dataGridView1.DataSource = weatherServices.ReadSubModel();
            frmHistorial.ShowDialog();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            city = txtCiudad.Text;

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Debe escribir una ciudad");
                return;
            }
       
            FilterSearch filter = new FilterSearch()
            {
                NameCities = txtCiudad.Text
            };
            filterSearches.Add(filter);

            try {
               
                Task.Run(Request).Wait();
                weatherServices.Create(openWeather);

                if (openWeather == null)
                {
                    throw new NullReferenceException("Fallo al obtener el objeto OpenWeather");
                }
                
                lblTemp.Text = openWeather.Main.Temp.ToString() + "°C";
                lblCity.Visible = true;
                lblCity.Text = openWeather.Name;
                lblCountry.Text = openWeather.Sys.Country;
                lblSunset.Text = ConvertDateTime(openWeather.Sys.Sunset).ToShortTimeString()+"PM";
                lblSunrise.Text = ConvertDateTime(openWeather.Sys.Sunrise).ToShortTimeString() + "AM";
                lblTempMax.Text = openWeather.Main.Temp_max.ToString() + "°C";
                lblTempMin.Text = openWeather.Main.Temp_min.ToString() + "°C";
                pictureBox1.ImageLocation = GetWeatherImage(openWeather.Weather[0].Icon);     

                //oneCallAPI = await openWeatherAPIClient.GetOneCallAsync();
                

            }
            catch (Exception)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCity.Visible = false;
        }

        public async Task Request()
        {
            openWeather = await openWeatherAPIClient.GetWeatherAsync(city);

        }
        public async Task RequestCall()
        {
            oneCallAPI = await openWeatherAPIClient.GetOneCallAsync();
        }
        
        private void lblTemp_Click(object sender, EventArgs e)
        {

        }

        private string GetWeatherImage(string icon)
        {
            string image = "https://openweathermap.org/img/w/" + icon + ".png";

            return image;
        }
        public DateTime ConvertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();
            return day;
        }
    }
}
