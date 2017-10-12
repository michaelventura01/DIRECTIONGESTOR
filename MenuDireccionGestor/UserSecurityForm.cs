using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DireccionLib
{
    public partial class UserSecurityForm : Form
    {
        public UserSecurityForm()
        {
            InitializeComponent();
        }

        private void UserSecurityForm_Load(object sender, EventArgs e)
        {
            picturetext.Hide();
            string dbserver="";
            string dbname="";
            string dbuser = "";
            string dbpassword = "";
            string dbport = "";

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


            }

            f = new FuncionClass(dbserver, dbname, dbuser, dbpassword, dbport);

           
                
                
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            try
            {
                string orden = "select * from users_table WHERE USER_NAME = '" + UsersShowForm.getdatum()[0] + "' AND USERTIPO = '" + UsersShowForm.getdatum()[1] + "' AND ID = '" + UsersShowForm.getdatum()[2] + "' AND FECHA_CREACION = '" + UsersShowForm.getdatum()[3] + "'; ";
            
                show.fillsecurity(userlabel,asklabel1,asklabel2,asklabel3,asklabel4,asklabel5,picturetext,orden);
                if (picturetext.Text != "")
                {

                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                    string fotopath = System.IO.Path.Combine(combinacion, picturetext.Text);
                    pictureBox.ImageLocation = fotopath;
                }
                problempanel.Hide();
                picturetext.Hide();
            }
            catch (NullReferenceException pad) {

                problempanel.Hide();
                picturetext.Hide();
                pad.ToString();
            }
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            passwordbox.Text = "";
            answerbox1.Text = "";
            answerbox2.Text = "";
            answerbox3.Text = "";
            answerbox4.Text = "";
            answerbox5.Text = "";
        }

        
        private void timera_Tick(object sender, EventArgs e)
        {

            TimeClass timeobject = new TimeClass();
            hourlabelstrip.Text = timeobject.clockshape();
            datelabelstrip.Text = timeobject.dateshape();


            AgendaClass ev = new AgendaClass();

            string hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string fechal = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(); ;
            string fechashort = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();




            string orden = "SELECT DESCRIPCION, HORA, PRIORIDAD FROM " + UserAccessForm.getusername() + "_events_table WHERE (HORA='" + hora + "' AND ( FECHA='" + fechal + "' or `FECHA DE RECORDATORIO`='" + fechashort + "'))AND ACTIVO='SI';";
            if (ev.getnametarea(orden))
            {
                DireccionGestor.setsombrestatic(ev.getname());
                DireccionGestor.setotrostatic(ev.gettime());
                DireccionGestor.setprioridadstatic(ev.getprioridad());
                DireccionGestor.setestadostatic(true);
                SystemSounds.Hand.Play();
                MessageBox.Show("SON LAS " + ev.gettime() + " ES HORA DE " + ev.getname());

            }
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
               cancelbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            
            UserAccessForm begin = new UserAccessForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            this.Close();
        }

        private void cancelbuttonstrip_Click(object sender, EventArgs e)
        {
            DireccionGestor.setcloseshowuser();

            UserAccessForm begin = new UserAccessForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }
        private int count=0;
        private void savebuttonstrip_Click(object sender, EventArgs e)
        {
            if (passwordbox.Text == "" || answerbox1.Text == "" || answerbox2.Text == "" || answerbox3.Text == "" || answerbox4.Text == "" || answerbox5.Text == "")
            {
                if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                if (answerbox1.Text == "") { answerbox1.BackColor = Color.Red; } else { answerbox1.BackColor = Color.Green; }
                if (answerbox2.Text == "") { answerbox2.BackColor = Color.Red; } else { answerbox2.BackColor = Color.Green; }
                if (answerbox3.Text == "") { answerbox3.BackColor = Color.Red; } else { answerbox3.BackColor = Color.Green; }
                if (answerbox4.Text == "") { answerbox4.BackColor = Color.Red; } else { answerbox4.BackColor = Color.Green; }
                if (answerbox5.Text == "") { answerbox5.BackColor = Color.Red; } else { answerbox5.BackColor = Color.Green; }

            }
            else {

                LoginClass log = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                if (log.setConectionsecurity(userlabel.Text, passwordbox.Text, answerbox1.Text, answerbox2.Text, answerbox3.Text, answerbox4.Text, answerbox5.Text) == true)
                {
                    count = 0;

                    UsersShowForm begin = new UsersShowForm();
                    begin.WindowState = FormWindowState.Normal;
                    begin.Show();
                    this.Close();

                }
                else {
                    problempanel.Show();
                    MessageBox.Show("ERROR AL INTRODUCIR DATOS");
                    if (count ==5) {
                        MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE CERRARA LA APLICACION");
                        this.Dispose();
                        Application.Exit();

                    }
                    count++;

                }


            }



            
        }

        private void problempanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void UserSecurityForm_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
//MAIL WHEN THE USER GET A PROBLEM
//MAIL TO CONECT O MESSAGE WITH THE PARENTS OR AT LEAST WITH THE RESPONSABLE
//MESSAGING SINCE C#
//add address direction at the students form and employee form
//add school name apart of the user
//send messages and alerts using messages or emails