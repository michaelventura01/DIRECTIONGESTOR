using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DireccionLib
{
    public partial class carga : Form
    {
        private int cuenta;
        private int cuenta2;

        public carga()
        {
            InitializeComponent();
            if (DireccionGestor.getorigen() == "listo")
            {

                //message2.Show();
                message.Hide();
                
            }
            else {
                //message2.Hide();
                message.Show();

            }
        }

        private void timecharge_Tick(object sender, EventArgs e)
        {
            cuenta2 += 1;
            cuenta += 1;


            if (cuenta2 == 20) {
                message.ForeColor = Color.White;
            }
            else if (cuenta2 == 60) {
                message.ForeColor = Color.Yellow;
            }
            else if (cuenta2 == 100)
            {
                message.ForeColor = Color.Orange;

            } else if (cuenta2==140) {
                message.ForeColor = Color.Red;
                cuenta2 = 0;
            }



                
             
             if (cuenta == 1) {

                message.Text = "CARGANDO.";

            }
            else if (cuenta == 5)
            {

                message.Text = "CARGANDO..";

            }
            else if (cuenta == 10)
            {

                message.Text = "CARGANDO...";
                cuenta = 0;
            }



            cuenta++;
            if (cuenta == 2000)
            {

                cuenta = 0;
                this.Close();
            }



        }


        

        private void carga_Load(object sender, EventArgs e)
        {

        }

        private void carga_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
