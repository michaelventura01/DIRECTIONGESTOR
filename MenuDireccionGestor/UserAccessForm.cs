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
    public partial class UserAccessForm : Form
    {
        private static string username;
        public static string getusername() { return username; }
        
        public static void setusername(string user) { username = user; }

        public UserAccessForm()
        {
            InitializeComponent();


            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string targetPath = System.IO.Path.Combine(path, "users");
            FuncionClass f = new FuncionClass();
            try
            {

                dbserver = f.readperfil(targetPath)[0];
                dbname = f.readperfil(targetPath)[1];
                dbuser = f.readperfil(targetPath)[2];
                dbpassword = f.readperfil(targetPath)[3];
                dbport = f.readperfil(targetPath)[4];

            }
            catch (NullReferenceException er)
            {
                er.ToString();


                dbserver = "localhost";
                dbname = "users";
                dbuser = "root";
                dbpassword = "1234";
                dbport = "3306";

            }


            mode = "carga";
            


        }

        private static string mode="";
        public static void setmode(string moder) {
            mode = moder;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private static string dbserver;
        public static string getdbserver() { return dbserver; }
        private static string dbname;
        public static string getdbname() { return dbname; }
        private static string dbuser;
        public static string getdbuser() { return dbuser; }
        private static string dbpassword;
        public static string getdbpassword() { return dbpassword; }
        private static string dbport;
        public static string getdbport() { return dbport; }
        private void UserAccessForm_Load(object sender, EventArgs e)
        {
            conexionpanel.Hide();
            problemuserbutton.Hide();

            LoginClass student = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);
            DireccionGestor.setorigen("");
            if (student.FillUserBox(userbox) == false) { pictureBox1.Hide(); } else { pictureBox1.Show(); }
            picture.Hide();

            mode = "carga";

        }

        private void cargobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginClass student = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);
            string orden = "SELECT * FROM  users_table WHERE USER_NAME= '" + userbox.Text + "';";
            student.fillpic(picture, orden);

            if (picture.Text != "")
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, "users");
                string fotopath = System.IO.Path.Combine(combinacion, picture.Text);
                pictureBox.ImageLocation = fotopath;

            }

            if (userbox.Text!="") {
                conexionpanel.Show();
                student.filllabel(horalabel, fechalabel,orden);

            }


        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
            Application.Exit();
            
        }


        
        private void createuserbutton_Click(object sender, EventArgs e)
        {

            LoginClass loginobject = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);
            carga men = new carga();
            men.WindowState = FormWindowState.Normal;
            men.Show();

            loginobject.FillUserBox(userbox);
            loginobject.CreateSchema("users");
            loginobject.CreateUsertabla();

            username = "";
            this.Hide();

            DireccionGestor.setorigen("out");

            UserAddForm adduser = new UserAddForm();
            adduser.WindowState = FormWindowState.Maximized;
            adduser.Show();
            men.Close();
        }

        private void accessbutton_Click(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            
            string fecha = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            string hora = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();

            username = userbox.Text;
            problemuserbutton.Hide();
            
            if(userbox.Text != "" || passwordbox.Text != "") { 
                LoginClass control = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);

                control.setConection(userbox.Text, passwordbox.Text);

                if (control.setConection(userbox.Text, passwordbox.Text) == true)
                {
                    cuenta = 0;
                    
                    string order = "UPDATE users_table SET `FECHA_LAST_CONECTION`= '"+fecha+ "', `HORA_LAST_CONECTION`='"+hora+"' WHERE `USER_NAME`='"+userbox.Text+"' ;";
                    control.ordensql(order);
                    DireccionGestor menu = new DireccionGestor();
                    
                    
                    menu.WindowState = FormWindowState.Maximized;
                    
                   
                    this.Hide();
                    menu.Show();
                }
                else if (control.setConection(userbox.Text, passwordbox.Text) == false) 
                {
                    cuenta++;
                    if (cuenta == 5)
                    {
                        MessageBox.Show("POR MOTIVOS DE SEGURIDAD LA APLICACION SE CERRARA");
                        this.Close();
                    }
                    problemuserbutton.Text = control.getMensajeUser();
                    problemuserbutton.Text = "Hay problemas con el USUARIO o la CONTRASEÑA, Modificar Usuario?";

                    
                    problemuserbutton.Show();
                    userbox.Text = "";
                    passwordbox.Text = "";
                    
                }
            }
           else {

                problemuserbutton.Show();
                
            }
        }

        private void problemuserbutton_Click(object sender, EventArgs e)
        {

            UserSecurityForm begin = new UserSecurityForm();
            begin.WindowState = FormWindowState.Maximized;
            begin.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private int cuenta;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mode== "carga") {

                mode = "";

                

                LoginClass student = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);
                student.FillUserBox(userbox);
                DireccionGestor.setorigen("");

            }
            cuenta++;
            if (cuenta == 8000)
            {

                cuenta = 0;
                closebutton.PerformClick();
            }



        }


        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {

            Databaseperfil menu = new Databaseperfil();
            menu.WindowState = FormWindowState.Normal;
            menu.Show();
            this.Hide();

            LoginClass save = new LoginClass();

           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            LoginClass student = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);
            DireccionGestor.setorigen("");

            string orden = "select * from users_table";

            if (student.ordensql(orden) == true)
            {

                student.FillUserBox(userbox);
                MessageBox.Show("BASE DE DATOS MYSQL ESTA SYNCRONIZADA");
            }
            else {

                MessageBox.Show("BASE DE DATOS MYSQL NO HA SIDO SYNCRONIZADA, CREE UN NUEVO USUARIO O SINO REVISE EL PERFIL DE BASE DE DATOS");
            }


            picture.Hide();

        }
    }
}
