using IPKevinMendoza.Domain.Entitites;
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

        public OpenWeatherAPIClient openWeatherAPIClient;
        public OpenWeather openWeather;
        private string city;
        public Form1()
        {
            openWeatherAPIClient = new OpenWeatherAPIClient();
            InitializeComponent();
            
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

            FrmHistorial frmHistorial = new FrmHistorial();
            frmHistorial.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            city = txtCiudad.Text;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public async Task Request()
        {
            openWeather=await OpenWeatherAPIClient.Get
        }
    }
}
