using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class FrmCatalogos : Form
    {
        public FrmCatalogos()
        {
            InitializeComponent();
        }

        private void FrmCatalogos_Load(object sender, EventArgs e)
        {
            //Aqui invocamos la lectura
            ConexionEscritBD Conex = new ConexionEscritBD();
            dgvCatalogo.DataSource = Conex.listar();
        }
    }
}
