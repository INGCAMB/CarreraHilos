using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Para manejar hilos
using System.Threading;

namespace CarreraHilos
{
    public partial class frmCarrera : Form
    {
        //Variables utilizadas para velocidad
        int A, B, C, D;

        //Definir diferentes procesos
        Thread procesodecaballo;

        //Random para variar los cambios
        Random random = new Random();

        //Variables
        //int Contador = 0;

        public frmCarrera()
        {
            InitializeComponent();

            procesodecaballo = new Thread(new ThreadStart(Movimiento));

            btnReiniciar.Enabled = false;
        }

        private void frmCarrera_Load(object sender, EventArgs e)
        {
            //Esta linea te permite ejecutar varios hilos
            CheckForIllegalCrossThreadCalls = false;
        }

        public void Movimiento()
        {
            while (true)
            {
                A = random.Next(1, 10);
                B = random.Next(1, 10);
                C = random.Next(1, 10);
                D = random.Next(1, 10);

                if (pbCaballoNegro.Right >= pbMeta.Left)
                {
                    lblGana1.Text = "Gana";
                    lblGana2.Text = "Pierde";
                    lblGana3.Text = "Pierde";
                    lblGana4.Text = "Pierde";
                    lblGana1.ForeColor = Color.Green;
                    lblGana2.ForeColor = Color.Red;
                    lblGana3.ForeColor = Color.Red;
                    lblGana4.ForeColor = Color.Red;
                    procesodecaballo.Abort();
                }
                else if (pbCaballoCafe.Right >= pbMeta.Left)
                {
                    lblGana1.Text = "Pierde";
                    lblGana2.Text = "Gana";
                    lblGana3.Text = "Pierde";
                    lblGana4.Text = "Pierde";
                    lblGana1.ForeColor = Color.Red;
                    lblGana2.ForeColor = Color.Green;
                    lblGana3.ForeColor = Color.Red;
                    lblGana4.ForeColor = Color.Red;
                    procesodecaballo.Abort();
                }
                else if (pbCaballoGris.Right >= pbMeta.Left)
                {
                    lblGana1.Text = "Pierde";
                    lblGana2.Text = "Pierde";
                    lblGana3.Text = "Gana";
                    lblGana4.Text = "Pierde";
                    lblGana1.ForeColor = Color.Red;
                    lblGana2.ForeColor = Color.Red;
                    lblGana3.ForeColor = Color.Green;
                    lblGana4.ForeColor = Color.Red;
                    procesodecaballo.Abort();
                }
                else if (pbCaballoAmarillo.Right >= pbMeta.Left)
                {
                    lblGana1.Text = "Pierde";
                    lblGana2.Text = "Pierde";
                    lblGana3.Text = "Pierde";
                    lblGana4.Text = "Gana";
                    lblGana1.ForeColor = Color.Red;
                    lblGana2.ForeColor = Color.Red;
                    lblGana3.ForeColor = Color.Red;
                    lblGana4.ForeColor = Color.Green;
                    procesodecaballo.Abort();
                }
                else
                {
                    pbCaballoNegro.Left += A;
                    pbCaballoCafe.Left += B;
                    pbCaballoGris.Left += C;
                    pbCaballoAmarillo.Left += D;
                }

                Thread.Sleep(50);
            }
        }

        //Iniciar
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.Enabled = false;
            btnReiniciar.Enabled = true;

            pbCaballoNegro.Left = +12;
            pbCaballoCafe.Left = +12;
            pbCaballoGris.Left = +12;
            pbCaballoAmarillo.Left = +12;

            try
            {
                procesodecaballo.Start();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }

        //Abortar
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.Enabled = true;
            btnReiniciar.Enabled = false;
            lblGana1.Text = "Suerte";
            lblGana1.ForeColor = Color.Black;
            lblGana2.Text = "Suerte";
            lblGana2.ForeColor = Color.Black;
            lblGana3.Text = "Suerte";
            lblGana3.ForeColor = Color.Black;
            lblGana4.Text = "Suerte";
            lblGana4.ForeColor = Color.Black;

            try
            {
                if(procesodecaballo.IsAlive)
                procesodecaballo.Abort();
                procesodecaballo = new Thread(new ThreadStart(Movimiento));

                pbCaballoNegro.Location = new Point(12, 12);
                pbCaballoCafe.Location = new Point(12, 68);
                pbCaballoGris.Location = new Point(12, 124);
                pbCaballoAmarillo.Location = new Point(12, 180);
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
    }
}
