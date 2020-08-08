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
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        #region Funcionalidades
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0x112, 0);


        }
        #endregion

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form Formulario;
            Formulario = panelFormulario.Controls.OfType<MiForm>().FirstOrDefault();

            if (Formulario == null)
            {
                Formulario = new MiForm();
                Formulario.TopLevel = false;
                //Formulario.FormBorderStyle - FormBorderStyle;
                //Formulario.Dock - DockStyle.Fill();
                panelFormulario.Controls.Add(Formulario);
                panelFormulario.Tag = Formulario;
                Formulario.Show();
                Formulario.BringToFront();
                
            }


            else
            {
                Formulario.BringToFront();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ListadoAnimales>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ListadoAdoptantes>();

        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ListadoVeterinarias>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ListadoTransito>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ListadoListaNegra>();
        }
    }
}
