using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DireccionLib
{
    public partial class UserAddForm : Form
    {
        public UserAddForm()
        {
            InitializeComponent();
        }


        private string dbserver;
        private string dbname;
        private string dbuser;
        private string dbpassword;
        private string dbport;

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            picturetextbox.Hide();


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
            titlelabel.Text = "AGREGAR USUARIO";


            if (UsersShowForm.getstate() == "edit")
            {
                repetlabel.Hide();
                passwordsecuritybox.Hide();
                titlelabel.Text = "MODIFICAR USUARIO";
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden = "select * from users_table WHERE USER_NAME = '" + UsersShowForm.getdatum()[0] + "' AND USERTIPO = '" + UsersShowForm.getdatum()[1] + "' AND ID = '" + UsersShowForm.getdatum()[2] + "' AND FECHA_CREACION = '" + UsersShowForm.getdatum()[3] + "'; ";

                show.fillevery(nameBox,passwordbox,usercombo,askbox1,answerbox1,askbox2,answerbox2, askbox3, answerbox3, askbox4, answerbox4, askbox5, answerbox5, picturetextbox,institucionbox,telefonobox,emailbox,orden);
                if (picturetextbox.Text != "")
                {

                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                    string fotopath = System.IO.Path.Combine(combinacion, picturetextbox.Text);
                    pictureBox.ImageLocation = fotopath;
                }
            }




        }
        private string rutafoto;
        private void picturebutton_Click(object sender, EventArgs e)
        {
            carga man = new carga();
            man.WindowState = FormWindowState.Normal;
            man.Show();
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            OpenFileDialog getfile = new OpenFileDialog();
            getfile.InitialDirectory = "C:\\";
            getfile.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            getfile.FilterIndex = 1;

            if (getfile.ShowDialog() == DialogResult.OK)
            {
                string begin = getfile.FileName;
                string sourcePath = Path.GetDirectoryName(begin);
                string targetPath = System.IO.Path.Combine(path, UserAccessForm.getusername());

                picturetextbox.Text = System.IO.Path.GetFileName(getfile.FileName);
                string sourcefile = getfile.FileName;
                string destfile = System.IO.Path.Combine(path, picturetextbox.Text);

                pictureBox.Image = Image.FromFile(getfile.FileName);



                rutafoto = picturetextbox.Text;


                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }


                if (getfile.CheckFileExists)
                {


                }
                try
                {
                    System.IO.File.Copy(sourcefile, sourcefile, true);
                }
                catch (System.IO.IOException getto)
                {


                    getto.ToString();

                }




                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        picturetextbox.Text = System.IO.Path.GetFileName(s);
                        destfile = System.IO.Path.Combine(targetPath, picturetextbox.Text);
                        try
                        {
                            System.IO.File.Copy(s, destfile, true);
                        }
                        catch (System.IO.IOException exept)
                        {

                            //MessageBox.Show("TRATE DE SELECCIONAR OTRA FOTO");
                            //picturetextbox.Text = System.IO.Path.GetFileName(getfile.FileName);
                            exept.ToString();

                        }
                    }
                }

            }

            man.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {


            TimeClass timeobject = new TimeClass();
            hourlabelstrip.Text = timeobject.clockshape();
            datelabelstrip.Text = timeobject.dateshape();


            AgendaClass ev = new AgendaClass(dbserver,dbname,dbuser,dbpassword,dbport);

            string hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string fechal = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(); ;
            string fechashort = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();


            string orden = "";
            if (DireccionGestor.getorigen()=="inicio") {
                orden = "SELECT DESCRIPCION, HORA, PRIORIDAD FROM " + UserAccessForm.getusername() + "_events_table WHERE (HORA='" + hora + "' AND ( FECHA='" + fechal + "' or `FECHA DE RECORDATORIO`='" + fechashort + "'))AND ACTIVO='SI';";
                if (ev.getnametarea(orden))
                {
                    DireccionGestor.setsombrestatic(ev.getname());
                    DireccionGestor.setotrostatic(ev.gettime());
                    DireccionGestor.setprioridadstatic(ev.getprioridad());
                    DireccionGestor.setestadostatic(true);
                    SystemSounds.Hand.Play();
                    MessageBox.Show("SON LAS " + ev.gettime() + " ES HORA DE " + ev.getname());

                }
                else if(DireccionGestor.getorigen()==""){
                    orden = "";
                    DireccionGestor.setorigen("");



                }
            }
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            DireccionGestor.setcloseshowuser();
            if (DireccionGestor.getorigen() == "" || DireccionGestor.getorigen() == null || DireccionGestor.getorigen() == "out")
            {

                UserAccessForm menu = new UserAccessForm();
                //menu.WindowState = FormWindowState.Normal;
                menu.Show();

                LoginClass save = new LoginClass();
                // this.Close();

            }
            else if (DireccionGestor.getorigen() == "buscador" || UsersShowForm.getstate() == "edit")
            {
                UsersShowForm menu = new UsersShowForm();
                //menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                LoginClass save = new LoginClass();
                // this.Hide();

            }
            else if (DireccionGestor.getorigen() == "inicio")
            {
                DireccionGestor menu = new DireccionGestor();

                //menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                LoginClass save = new LoginClass();
                // this.Hide();

            }

            this.Close();
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            nameBox.Text = "";
            passwordbox.Text = "";
            passwordsecuritybox.Text = "";
            askbox1.Text = "";
            askbox2.Text = "";
            askbox3.Text = "";
            askbox4.Text = "";
            askbox5.Text = "";
            answerbox1.Text = "";
            answerbox2.Text = "";
            answerbox3.Text = "";
            answerbox4.Text = "";
            answerbox5.Text = "";
            pictureBox.ImageLocation = "";
            institucionbox.Text = "";
            telefonobox.Text = "";
            emailbox.Text = "";
            LoginClass save = new LoginClass();

        }

        private void cancelbuttonstrip_Click(object sender, EventArgs e)
        {
            nameBox.Text = "";
            passwordbox.Text = "";
            passwordsecuritybox.Text = "";
            askbox1.Text = "";
            askbox2.Text = "";
            askbox3.Text = "";
            askbox4.Text = "";
            askbox5.Text = "";
            answerbox1.Text = "";
            answerbox2.Text = "";
            answerbox3.Text = "";
            answerbox4.Text = "";
            answerbox5.Text = "";
            pictureBox.ImageLocation = "";
            LoginClass save = new LoginClass();

            if (UserAccessForm.getusername() == null || UserAccessForm.getusername() == "")
            {

                UserAccessForm menu = new UserAccessForm();
            
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                this.Close();
                save = new LoginClass();

            }
            else
            {
                DireccionGestor menu = new DireccionGestor();
                
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                this.Close();
                save = new LoginClass();


            }
        }

        private void savebuttonstrip_Click(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;


            string fecha = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
            string hora = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();

            carga men = new carga();
            men.WindowState = FormWindowState.Normal;
            men.Show();
            LoginClass save = new LoginClass(dbserver, dbname, dbuser, dbpassword, dbport);

            if (UsersShowForm.getstate() == "edit")
            {
                if (nameBox.Text=="" || passwordbox.Text=="" || usercombo.Text=="" || askbox1.Text==""|| answerbox1.Text=="" || askbox2.Text == "" || answerbox2.Text == "" || askbox3.Text == "" || answerbox3.Text == "" || askbox4.Text == "" || answerbox4.Text == "" || askbox5.Text == "" || answerbox5.Text == "") {
                    men.Close();
                    if (nameBox.Text == "") { nameBox.BackColor = Color.Red; } else { nameBox.BackColor = Color.Green; }
                    if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                    if (usercombo.Text == "") { usercombo.BackColor = Color.Red; } else { usercombo.BackColor = Color.Green; }

                    if (askbox1.Text == "") { askbox1.BackColor = Color.Red; } else { askbox1.BackColor = Color.Green; }
                    if (answerbox1.Text == "") { answerbox1.BackColor = Color.Red; } else { answerbox1.BackColor = Color.Green; }

                    if (askbox2.Text == "") { askbox2.BackColor = Color.Red; } else { askbox2.BackColor = Color.Green; }
                    if (answerbox2.Text == "") { answerbox2.BackColor = Color.Red; } else { answerbox2.BackColor = Color.Green; }

                    if (askbox3.Text == "") { askbox3.BackColor = Color.Red; } else { askbox3.BackColor = Color.Green; }
                    if (answerbox3.Text == "") { answerbox3.BackColor = Color.Red; } else { answerbox3.BackColor = Color.Green; }

                    if (askbox4.Text == "") { askbox4.BackColor = Color.Red; } else { askbox4.BackColor = Color.Green; }
                    if (answerbox4.Text == "") { answerbox4.BackColor = Color.Red; } else { answerbox4.BackColor = Color.Green; }

                    if (askbox5.Text == "") { askbox5.BackColor = Color.Red; } else { askbox5.BackColor = Color.Green; }
                    if (answerbox5.Text == "") { answerbox5.BackColor = Color.Red; } else { answerbox5.BackColor = Color.Green; }

                    if (institucionbox.Text == "") { institucionbox.BackColor = Color.Red; } else { institucionbox.BackColor = Color.Green; }
                    if (telefonobox.Text=="") { telefonobox.BackColor = Color.Red; } else { telefonobox.BackColor = Color.Green; }
                    if (emailbox.Text=="") { emailbox.BackColor = Color.Red; } else { emailbox.BackColor = Color.Green; }
                    MessageBox.Show("HAY DATOS IMPORTANTES VACIOS");

                }
                else {

                    string name = nameBox.Text;
                    string password = passwordbox.Text;
                    string usertipo = usercombo.Text;
                    string ask1 = askbox1.Text;
                    string answer1 = answerbox1.Text;
                    string ask2 = askbox2.Text;
                    string answer2 = answerbox2.Text;
                    string ask3 = askbox3.Text;
                    string answer3 = answerbox3.Text;
                    string ask4 = askbox4.Text;
                    string answer4 = answerbox4.Text;
                    string ask5 = askbox5.Text;
                    string answer5 = answerbox5.Text;
                    string foto = picturetextbox.Text;
                    string email = emailbox.Text;
                    string telefono = telefonobox.Text;
                    string institucion = institucionbox.Text;
                    string orden = "UPDATE users_table SET USER_NAME= '" + name + "', USER_PASSWORD='" + password + "', USERTIPO='" + usertipo + "', QUESTION1='" + ask1 + "',ANSWER1='" + answer1 + "', QUESTION2='" + ask2 + "',ANSWER2='" + answer2 + "',QUESTION3='" + ask3 + "',ANSWER3='" + answer3 + "',QUESTION4='" + ask4 + "',ANSWER4='" + answer4 + "',QUESTION5='" + ask5 + "',ANSWER5='" + answer5 + "',PICTURE_ROUTE='" + picturetextbox.Text + "' ,INSTITUCION='" + institucion + "',TELEFONO='" + telefono + "',EMAIL='" + email + "' WHERE USER_NAME = '" + UsersShowForm.getdatum()[0] + "' AND USERTIPO = '" + UsersShowForm.getdatum()[1] + "' AND ID = '" + UsersShowForm.getdatum()[2] + "' AND FECHA_CREACION = '" + UsersShowForm.getdatum()[3] + "'; ";
                    save.ordensql(orden);
                    men.Close();
                    MessageBox.Show("USUARIO " + UsersShowForm.getdatum()[0] + " HA SIDO MODIFICADO");
                    if (UserAccessForm.getusername() != nameBox.Text)
                    {


                        UserAccessForm add = new UserAccessForm();
                        add.WindowState = FormWindowState.Maximized;
                        add.Show();
                        this.Close();

                    }
                    else {

                        UsersShowForm add = new UsersShowForm();
                        add.WindowState = FormWindowState.Maximized;
                        add.Show();
                        this.Close();

                    }
                }
            }
            else {
                if (save.UserNoCopied(nameBox.Text) == true)
                {
                    men.Close();
                    MessageBox.Show("El usuario " + nameBox.Text + " ya existe");
                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        save = new LoginClass();

                        DireccionGestor menu = new DireccionGestor();
                        menu.WindowState = FormWindowState.Normal;
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        save = new LoginClass();
                        UserAddForm menu = new UserAddForm();
                        menu.WindowState = FormWindowState.Normal;
                        menu.Show();
                        this.Close();
                    }
                }
                else if (save.UserNoCopied(nameBox.Text) == false)
                {



                    if (passwordbox.Text != passwordsecuritybox.Text)
                    {
                        men.Close();
                        MessageBox.Show("LAS CONTRASEÑAS NO COINCIDEN");

                    }

                    else
                    {


                        if (nameBox.Text == "" || passwordbox.Text == "" || passwordsecuritybox.Text == "" || askbox1.Text == "" || askbox2.Text == "" || askbox3.Text == "" || askbox4.Text == "" || askbox5.Text == "" || answerbox1.Text == "" || answerbox2.Text == "" || answerbox3.Text == "" || answerbox4.Text == "" || answerbox5.Text == "" || emailbox.Text==""||telefonobox.Text==""||institucionbox.Text=="")
                        {
                            men.Close();

                            MessageBox.Show("Hay datos importantes vacios, termine el formulario.");

                        }

                        else
                        {



                            if (DireccionGestor.getorigen() == "inicio")
                            {



                                //institucion, telefono, email
                                if (save.CreateNewUser(nameBox.Text, passwordbox.Text, picturetextbox.Text, askbox1.Text, askbox2.Text, askbox3.Text, askbox4.Text, askbox5.Text, answerbox1.Text, answerbox2.Text, answerbox3.Text, answerbox4.Text, answerbox5.Text, usercombo.Text, fecha, hora, institucionbox.Text,telefonobox.Text,emailbox.Text) == true)
                                {
                                    men.Close();
                                    MessageBox.Show("NUEVO USUARIO " + nameBox.Text + " HA SIDO CREADO EXITOSAMENTE.");
                                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        save = new LoginClass();

                                        DireccionGestor menu = new DireccionGestor();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        save = new LoginClass();

                                        UserAddForm menu = new UserAddForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                }
                                else if (DireccionGestor.getorigen() == "buscador")
                                {
                                    men.Close();
                                    MessageBox.Show("NUEVO USUARIO " + nameBox.Text + " HA SIDO CREADO.");

                                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        save = new LoginClass();

                                        UsersShowForm menu = new UsersShowForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        save = new LoginClass();

                                        UserAddForm menu = new UserAddForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }

                                }

                                else
                                {
                                    men.Close();
                                    MessageBox.Show("NUEVO USUARIO " + nameBox.Text + " HA SIDO CREADO.");

                                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        save = new LoginClass();

                                        DireccionGestor menu = new DireccionGestor();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        save = new LoginClass();

                                        UserAddForm menu = new UserAddForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }

                                }

                            }
                            else if (DireccionGestor.getorigen() == "" || DireccionGestor.getorigen() == null || DireccionGestor.getorigen()=="out")
                            {


                                //institucion,telefono,email
                                if (save.CreateNewUser(nameBox.Text, passwordbox.Text, picturetextbox.Text, askbox1.Text, askbox2.Text, askbox3.Text, askbox4.Text, askbox5.Text, answerbox1.Text, answerbox2.Text, answerbox3.Text, answerbox4.Text, answerbox5.Text, usercombo.Text, fecha, hora,institucionbox.Text,telefonobox.Text,emailbox.Text) == true)
                                {
                                    men.Close();
                                    MessageBox.Show("NUEVO USUARIO " + nameBox.Text + " NO PUDO SER CREADO.");
                                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        save = new LoginClass();

                                        UserAccessForm menu = new UserAccessForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        save = new LoginClass();

                                        UserAddForm menu = new UserAddForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                }

                                else
                                {
                                    men.Close();
                                    MessageBox.Show("NUEVO USUARIO " + nameBox.Text + " HA SIDO CREADO EXITOSAMENTE.");

                                    if (MessageBox.Show("Agregar a otro usuario?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    {
                                        save = new LoginClass();

                                        UserAccessForm menu = new UserAccessForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        save = new LoginClass();

                                        UserAddForm menu = new UserAddForm();
                                        menu.WindowState = FormWindowState.Normal;
                                        menu.Show();
                                        this.Close();
                                    }

                                }

                            }
                        }

                    }
                }

            }


            save = new LoginClass();
            

        }

        private void picturetextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            

            }

        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten Espacios en Blanco");

            }

            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten este Tipo de Simbolos");

            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten este Tipo de Simbolos");

            }

        }

        private void passwordbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten Espacios en Blanco");

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DireccionGestor.setcloseshowuser();
            if (DireccionGestor.getorigen() == "" || DireccionGestor.getorigen() == null || DireccionGestor.getorigen() == "out")
            {

                UserAccessForm menu = new UserAccessForm();
                //menu.WindowState = FormWindowState.Normal;
                menu.Show();
                
                LoginClass save = new LoginClass();
               // this.Close();
                
            }
            else if (DireccionGestor.getorigen() == "buscador"|| UsersShowForm.getstate() == "edit")
            {
                UsersShowForm menu = new UsersShowForm();
                //menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                LoginClass save = new LoginClass();
               // this.Hide();

            }
            else if(DireccionGestor.getorigen() == "inicio")
            {
                DireccionGestor menu = new DireccionGestor();

                //menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                LoginClass save = new LoginClass();
               // this.Hide();

            }

            this.Close();
        }

        private void telefonobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten Espacios en Blanco");

            }

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo es para Introducir un Numero de Telefono");

            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo es para Introducir un Numero de Telefono");

            }
        }

        private void telefonobox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
    }

