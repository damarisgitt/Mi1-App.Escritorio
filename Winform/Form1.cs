using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using ConexionDB;

namespace Winform
{ 
    public partial class FrmCatalogos : Form
    {
        private List<Articulos> listaArticulos;
        public FrmCatalogos()
        {
            InitializeComponent();
        }

        private void FrmCatalogos_Load(object sender, EventArgs e)
        {
            //Aqui invocamos la lectura
            ConexionEscritBD Conex = new ConexionEscritBD();

            listaArticulos = Conex.listar();

            dgvCatalogo.DataSource = listaArticulos;

            pboxArticulos.Load(listaArticulos[0].ImagenUrl.ImagenUrl);
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            Articulos Seleccionado = (Articulos)dgvCatalogo.CurrentRow.DataBoundItem;
            pboxArticulos.Load(Seleccionado.ImagenUrl.ImagenUrl);
        }
    }
}
