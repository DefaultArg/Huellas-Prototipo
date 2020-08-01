using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huellas_Prototipo
{
    public partial class AltaAnimales : Form
    {
        public AltaAnimales()
        {
            InitializeComponent();
        }

        private void AltaAnimales_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Mascota cargada con exito!", "", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
