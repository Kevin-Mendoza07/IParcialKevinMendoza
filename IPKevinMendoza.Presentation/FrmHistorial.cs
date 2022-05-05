using IPKevinMendoza.AppCore.Interfaces;
using IPKevinMendoza.Domain.SubModel;
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
    public partial class FrmHistorial : Form
    {

        public IWeatherServices weatherServices { get; set; }
        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private List<WeatherSubModel> GetCitiesOfName(List<WeatherSubModel> subModels, string city)
        {
            return subModels.Where(x => x.Name == city).Select(x => x).ToList();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbFiltrar.Items.Count == 0)
            {
                MessageBox.Show("No ha realizado una busqueda");
                return;
            }
            if (cmbFiltrar.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado una ciudad");
                return;
            }
            dataGridView1.DataSource = GetCitiesOfName(weatherServices.ReadSubModel(),cmbFiltrar.SelectedItem.ToString());
        }
    }

        
    }

