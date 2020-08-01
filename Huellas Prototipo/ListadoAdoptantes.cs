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
    public partial class ListadoAdoptantes : Form
    {
        public ListadoAdoptantes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormAlta = new AltaAdoptante();
            FormAlta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("¿Desea eliminar este dato?", "No", MessageBoxButtons.YesNo);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
