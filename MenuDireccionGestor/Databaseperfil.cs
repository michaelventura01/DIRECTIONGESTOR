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
    public partial class Databaseperfil : Form
    {
        public Databaseperfil()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            
            UserAccessForm menu = new UserAccessForm();
            menu.WindowState = FormWindowState.Normal;
            menu.Show();
            LoginClass save = new LoginClass();
            this.Close();
        }

        private void aceptbutton_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetPath = System.IO.Path.Combine(path, "users");
            
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }


            FuncionClass save = new DireccionLib.FuncionClass();
            save.saveperfil(dbserver.Text,dbname.Text, dbuser.Text, dbpassword.Text, dbport.Text, targetPath);

            UserAccessForm.setmode("carga");

            UserAccessForm menu = new UserAccessForm();
            menu.WindowState = FormWindowState.Normal;
            menu.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbport.Text = "";
            dbserver.Text = "";
            dbpassword.Text = "";
            dbuser.Text = "";
            dbname.Text = "";
            FuncionClass F = new FuncionClass();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FuncionClass f = new FuncionClass(dbserver.Text,dbname.Text,dbuser.Text,dbpassword.Text,dbport.Text);
            string orden="select * from users_table";
            if (f.ordensql(orden))
            {
                MessageBox.Show("BASE DE DATOS MYSQL ENLAZADA");
            }
            else {

                MessageBox.Show("BASE DE DATOS MYSQL NO PUDO SER ENLAZADA");
            }

        }

        private void Databaseperfil_Load(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetPath = System.IO.Path.Combine(path, "users");
            FuncionClass f = new FuncionClass();
            try {

                dbserver.Text = f.readperfil(targetPath)[0];
                dbname.Text = f.readperfil(targetPath)[1];
                dbuser.Text = f.readperfil(targetPath)[2];
                dbpassword.Text = f.readperfil(targetPath)[3];
                dbport.Text = f.readperfil(targetPath)[4];

            } catch (NullReferenceException er) {
                er.ToString();


                dbserver.Text = "localhost";
                dbname.Text = "users";
                dbuser.Text = "root";
                dbpassword.Text = "1234";
                dbport.Text = "3306";
                
            }
            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                cancelbutton.PerformClick();
            }



        }


        private int cuenta;

        private void Databaseperfil_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
