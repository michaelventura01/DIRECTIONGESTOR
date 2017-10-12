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
    public partial class userPasswordForm : Form
    {
        public userPasswordForm()
        {
            InitializeComponent();
        }
        private int count;
        private void userPasswordForm_Load(object sender, EventArgs e)
        {
            try {
                picturetext.Hide();
                OKbutton.BackColor = Color.Green;
                cancelbutton.BackColor = Color.Red;
                userlabel.Text = UsersShowForm.getdatum()[0];
                tipolabel.Text = UsersShowForm.getdatum()[1];
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden = "select * from  USERS_TABLE where USER_NAME = '" + userlabel.Text + "';";
                show.fillpic(picturetext, orden);


                if (picturetext.Text != "")
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, "users");
                    string fotopath = System.IO.Path.Combine(combinacion, picturetext.Text);
                    pictureBox.ImageLocation = fotopath;

                }

                if (UsersShowForm.getstate() == "change")
                {

                    seguridadlabel.Text = "CAMBIAR CONTRASEÑA";
                }
                else {

                    seguridadlabel.Text = "CONTROL DE SEGURIDAD";
                    newlabel.Hide();
                    newpasstextbox.Hide();
                }
            }
            catch (ArgumentNullException pap) {
                pap.ToString();
                MessageBox.Show("TIENE QUE SELECCIONAR UN USUARIO PARA EJECUTAR LAS FUNCIONES DEL MENU");
            }
            catch (NullReferenceException pap)
            {
                pap.ToString();
                MessageBox.Show("TIENE QUE SELECCIONAR UN USUARIO PARA EJECUTAR LAS FUNCIONES DEL MENU");
            }

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            
            this.Close();


        }
        int cuenta;
        private void OKbutton_Click(object sender, EventArgs e)
        {
            string orden;
            if (UsersShowForm.getstate() == "change")
            {

                if (passwordbox.Text == "" || newpasstextbox.Text == "" || repettextbox.Text == "")
                {
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (newpasstextbox.Text == "") { newpasstextbox.BackColor = Color.Red; } else { newpasstextbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }

                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else if (newpasstextbox.Text != repettextbox.Text)
                {

                    repettextbox.BackColor = Color.Red;
                    MessageBox.Show("LOS CAMPOS PARA CAMBIAR LAS CONTRASEÑA DEBEN DE SER IGUALES");


                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {
                        cuenta = 0;
                        orden = "UPDATE users_table SET USER_PASSWORD='" + newpasstextbox.Text + "' WHERE USER_NAME='" + UsersShowForm.getdatum()[0] + "' AND USERTIPO='" + UsersShowForm.getdatum()[1] + "' AND ID='" + UsersShowForm.getdatum()[2] + "' AND FECHA_CREACION='" + UsersShowForm.getdatum()[3] + "';";
                        if (show.ordensql(orden) == true)
                        {
                            MessageBox.Show("CONTRASEÑA CAMBIADA CON EXITO");
                            show = new LoginClass();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CONTRASEÑA CAMBIADA");
                            show = new LoginClass();
                            this.Close();
                        }


                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIFIQUE");
                        passwordbox.BackColor = Color.Red;
                        newpasstextbox.Text = "";
                        repettextbox.Text = "";
                        cuenta++;
                        if (cuenta == 3)
                        {

                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Maximized;
                            begin.Show();
                            this.Close();
                        }
                    }


                }


            }
            else if (UsersShowForm.getstate() == "edit")
            {

                if (passwordbox.Text == "" || repettextbox.Text == "")
                {

                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else if (passwordbox.Text != repettextbox.Text)
                {




                    repettextbox.BackColor = Color.Red;
                    MessageBox.Show("LAS CONTRASEÑAS DEBEN DE SER IGUALES");

                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {

                        cuenta = 0;
                        UserAddForm add = new UserAddForm();
                        add.WindowState = FormWindowState.Maximized;
                        add.Show();
                        DireccionGestor.setcloseshowuser();
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIIQUE");
                        passwordbox.BackColor = Color.Red;
                        newpasstextbox.Text = "";
                        repettextbox.Text = "";
                        cuenta++;
                        if (cuenta == 3)
                        {


                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();
                        }
                    }


                }


            }
            else if (UsersShowForm.getstate() == "delete")
            {


                if (passwordbox.Text == "" || repettextbox.Text == "")
                {
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {

                        cuenta = 0;
                        orden = "DROP TABLE IF EXISTS `" + UsersShowForm.getdatum()[0] + "_employee_table;`";
                        show.ordensql(orden);
                        orden = "DROP TABLE IF EXISTS `" + UsersShowForm.getdatum()[0] + "_student_table;`";
                        show.ordensql(orden);
                        orden = "DROP TABLE IF EXISTS `" + UsersShowForm.getdatum()[0] + "_events_table;`";
                        show.ordensql(orden);
                        orden = "DROP TABLE IF EXISTS `" + UsersShowForm.getdatum()[0] + "_movements_table`;";
                        show.ordensql(orden);
                        orden = "delete from users.users_table WHERE USER_NAME= '" + UsersShowForm.getdatum()[0] + "' AND USERTIPO='" + UsersShowForm.getdatum()[1] + "' AND ID='" + UsersShowForm.getdatum()[2] + "' AND FECHA_CREACION='" + UsersShowForm.getdatum()[3] + "';";
                        show.ordensql(orden);

                        MessageBox.Show("USUARIO " + UsersShowForm.getdatum()[0] + " ELIMINADO");


                        if (UserAccessForm.getusername() == UsersShowForm.getdatum()[0])
                        {
                            DireccionGestor.setcloseshowuser();
                            UserAccessForm begin = new UserAccessForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();


                        }
                        else
                        {

                            show = new LoginClass();
                            UsersShowForm.setrefresh("refresh");
                            this.Close();

                        }



                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIIQUE");
                        cuenta++;
                        if (cuenta == 3)
                        {
                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();
                        }
                    }


                }


            }
            else if (UsersShowForm.getstate() == "save")
            {

                if (passwordbox.Text == "" || repettextbox.Text == "")
                {
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {
                        cuenta = 0;
                        //some codde heereeee


                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIIQUE");
                        cuenta++;
                        if (cuenta == 3)
                        {
                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();
                        }
                    }


                }



            }
            else if (UsersShowForm.getstate() == "cargar")
            {

                if (passwordbox.Text == "" || repettextbox.Text == "")
                {
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {
                        cuenta = 0;
                        //some codde heereeee


                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIIQUE");
                        cuenta++;
                        if (cuenta == 3)
                        {
                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();
                        }
                    }


                }


            }
            else if (UsersShowForm.getstate() == "comprobar") {

                if (passwordbox.Text == "" || repettextbox.Text == "")
                {
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATAOS IMPORTANTES VACIOS");
                }
                else
                {
                    LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {
                        cuenta = 0;
                        ShowSubjects.setpaso(true);


                    }
                    else
                    {
                        MessageBox.Show("CONTRASEÑA EQUIVOCADA, POR FAVOR RECTIIQUE");
                        cuenta++;
                        if (cuenta == 3)
                        {
                            ShowSubjects.setpaso(false);
                            MessageBox.Show("POR MOTIVOS DE SEGURIDAD SE EMPEZARA UNA RECTIFICACION DE DATOS");
                            UserSecurityForm begin = new UserSecurityForm();
                            begin.WindowState = FormWindowState.Normal;
                            begin.Show();
                            this.Close();
                        }
                    }


                }


                ///////////////////////////////////
                
            }
            else { MessageBox.Show("HA OCURRIDO ALGO DURANTE EL PROCESO"); }
            
        }

        private void passwordbox_TextChanged(object sender, EventArgs e)
        {
            passwordbox.BackColor = Color.White;
        }

        private void newpasstextbox_TextChanged(object sender, EventArgs e)
        {
            newpasstextbox.BackColor = Color.White;
        }

        private void repettextbox_TextChanged(object sender, EventArgs e)
        {
            repettextbox.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                cancelbutton.PerformClick();
            }



        }

        private void userPasswordForm_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void passwordbox_Click(object sender, EventArgs e)
        {
            passwordbox.BackColor = Color.White;
        }

        private void newpasstextbox_Click(object sender, EventArgs e)
        {
            newpasstextbox.BackColor = Color.White;
        }

        private void repettextbox_Click(object sender, EventArgs e)
        {
            repettextbox.BackColor = Color.White;
        }
    }
}
