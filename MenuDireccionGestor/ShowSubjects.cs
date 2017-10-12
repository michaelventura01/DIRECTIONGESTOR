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
    public partial class ShowSubjects : Form
    {
        public ShowSubjects()
        {
            InitializeComponent();
            texta.Hide();
            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            seguridadpanel.Hide();
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table";
            show.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = show.getcuenta().ToString();
            /////////////////////////

            userlabel.Text = UserAccessForm.getusername();
            orden = "select * from  USERS_TABLE where USER_NAME = '" + userlabel.Text + "';";
            show.fillpic(texta, orden);


            if (texta.Text != "")
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, "users");
                string fotopath = System.IO.Path.Combine(combinacion, texta.Text);
                picture.ImageLocation = fotopath;

            }

            ////////////////////////
            orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table";
            show.Fillcombo(asignaturabox, orden);
            orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table";
            show.Fillcombo(asignadobox, orden);
            editbutton.Enabled = false;
            eliminarbutton.Enabled = false;
        }

        private void agregarbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");
            AddSubject ad = new AddSubject();
            ad.WindowState = FormWindowState.Normal;
            ad.Show();
        }
        private static string change;
        public static void setchange(string pad) { change = pad; }
        public static string getchange() { return change; }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("editor");
            AddSubject ad = new AddSubject();
            ad.WindowState = FormWindowState.Normal;
            ad.Show();
        }

        private static bool paso;
        public static void setpaso(bool pass) {
            paso = pass;
        }

        public static bool getpaso() { return paso; }
        private void ShowSubjects_Load(object sender, EventArgs e)
        {
            texta.Hide();
            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            seguridadpanel.Hide();
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM "+UserAccessForm.getusername()+ "_subject_table";
            show.ShowDataGridFound(dataGrid,orden);
            cuentalabel.Text = show.getcuenta().ToString();
            /////////////////////////

            userlabel.Text = UserAccessForm.getusername();
            orden = "select * from  USERS_TABLE where USER_NAME = '" + userlabel.Text + "';";
            show.fillpic(texta, orden);


            if (texta.Text != "")
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, "users");
                string fotopath = System.IO.Path.Combine(combinacion, texta.Text);
                picture.ImageLocation = fotopath;

            }

            ////////////////////////
            orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table";
            show.Fillcombo(asignaturabox,orden);
            orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table";
            show.Fillcombo(asignadobox, orden);
            editbutton.Enabled = false;
            eliminarbutton.Enabled = false;
        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarbutton_Click(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table";
            show.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = show.getcuenta().ToString();
            asignaturabox.Text = "TODOS";
            asignadobox.Text = "TODOS";

        }

        private void asignaturabox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNATURA='"+asignaturabox.Text+"';";
            show.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void asignadobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNADO='" + asignadobox.Text + "';";
            show.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void buscarbutton_Click(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table;";

            if (asignaturabox.Text=="" && asignadobox.Text=="") {

                orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table;";
            }
            if (asignaturabox.Text != "" && asignadobox.Text == "") {
                orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNATURA='"+asignaturabox.Text+"';";
            }
            if (asignaturabox.Text == "" && asignadobox.Text != "")
            {
                orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNADO='" + asignadobox.Text + "';";

            }
            if (asignaturabox.Text != "" && asignadobox.Text != "") {
                orden = "SELECT ASIGNATURA,ASIGNADO,DESCRIPCION FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNADO='" + asignadobox.Text + "' AND ASIGNATURA='" + asignaturabox.Text + "';";
            }



            show.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try {
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_subject_table";
                string dato = this.dataGrid.CurrentCell.Value.ToString();

                string orden = "select ASIGNATURA from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                if (show.takedatatable(orden,"ASIGNATURA") != "")
                {
                    editbutton.Enabled = true;
                    eliminarbutton.Enabled = true;
                    orden = "select ASIGNATURA from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                    asignaturabox.Text = show.takedatatable(orden, "ASIGNATURA");
                    orden = "select ASIGNADO from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                    asignadobox.Text = show.takedatatable(orden, "ASIGNADO");
                    orden = "SELECT DESCRIPCION FROM " + userDataName+ " where ASIGNATURA = '" + asignaturabox.Text + "' AND ASIGNADO='" + asignadobox.Text + "';";
                    string descripcion= show.takedatatable(orden, "DESCRIPCION");

                    info = new string[3];
                    info[0] = asignaturabox.Text;
                    info[1] = asignadobox.Text;
                    info[2] = descripcion;
                }
                else
                {

                    editbutton.Enabled = false;
                    eliminarbutton.Enabled = false;
                    asignaturabox.Text = "";
                    asignadobox.Text = "";
                    MessageBox.Show("DEBERIA SELECCIONAR EL CAMPO [ASIGNATURA] O ALMENOS EL CAMPO ASIGNADO [ASIGNADO]");

                }

            }
            catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private static string[] info;
        public static string[] getinfo() {
            return info;
        }
        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try {
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_subject_table";
                string dato = this.dataGrid.CurrentCell.Value.ToString();

                string orden = "select ASIGNATURA from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                if (show.takedatatable(orden,"ASIGNATURA") != "")
                {
                    orden = "select ASIGNATURA from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                    asignaturabox.Text = show.takedatatable(orden, "ASIGNATURA");
                    orden = "select ASIGNADO from " + userDataName + " where ASIGNATURA = '" + dato + "' or ASIGNADO='" + dato + "';";
                    asignadobox.Text = show.takedatatable(orden, "ASIGNADO");
                    orden = "SELECT DESCRIPCION FROM " + userDataName + " where ASIGNATURA = '" + asignaturabox.Text + "' AND ASIGNADO='" + asignadobox.Text + "';";
                    string descripcion = show.takedatatable(orden, "DESCRIPCION");

                    info = new string[3];
                    info[0] = asignaturabox.Text;
                    info[1] = asignadobox.Text;
                    info[2] = descripcion;

                    editbutton.PerformClick();
                }
                else
                {

                    eliminarbutton.Enabled = false;
                    editbutton.Enabled = false;
                    MessageBox.Show("DEBERIA SELECCIONAR EL CAMPO [ASIGNATURA] O ALMENOS EL CAMPO ASIGNADO [ASIGNADO]");

                }
            }
            catch (NullReferenceException pafh) { pafh.ToString(); }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (change=="modify") {
                limpiarbutton.PerformClick();
                change = "";
            }
            cuenta++;
            if (cuenta==1000) {
                cancelbutton.PerformClick();
            }
            if (cuenta == 3000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void eliminarbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ASEGURECE DE HACER UNA COPIA DE SEGURIDAD ANTES DE EFECTUAR ESTE PROCESO, SE PUEDEN PERDER DATOS");


            seguridadpanel.Show();

            

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            seguridadpanel.Hide();
            passwordbox.Text = "";
            repettextbox.Text = "";
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (passwordbox.Text == "" || repettextbox.Text == "")
            {
                MessageBox.Show("HAY DATOS CLAVES VACIOS, RECTIFIQUE");
                if (passwordbox.Text == "") { passwordbox.BackColor = Color.Red; } else { passwordbox.BackColor = Color.Green; }
                if (repettextbox.Text == "") { repettextbox.BackColor = Color.Red; } else { repettextbox.BackColor = Color.Green; }

            } else if (passwordbox.Text != repettextbox.Text ) {

                repettextbox.BackColor = Color.Red;
                MessageBox.Show("LOS CAMPOS SON DIFERENTES, DEBERIAN SER IGUALES PARA VALIDARLOS ");
                
            }
            else {
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                try {

                    if (show.setConection(userlabel.Text, passwordbox.Text))
                    {
                        string complete = "`" + UserAccessForm.getusername() + "_subject_table`";
                        MessageBox.Show("LA ASIGNATURA " + asignaturabox.Text + " DE " + asignadobox.Text + " HA SIDO ELIMINADA");
                        repettextbox.Text = "";
                        passwordbox.Text = "";
                        repettextbox.BackColor = Color.White;
                        passwordbox.BackColor = Color.White;
                        limpiarbutton.PerformClick();
                        seguridadpanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL INTRODUCIR LAS CONTRASEÑAS");
                        repettextbox.Text = "";
                        passwordbox.Text = "";
                        repettextbox.BackColor = Color.White;
                        passwordbox.BackColor = Color.White;
                        limpiarbutton.PerformClick();
                        seguridadpanel.Hide();
                    }
                } catch (NullReferenceException OPR) {
                    OPR.ToString();
                    limpiarbutton.PerformClick();
                }
               

            }
        }

        private void passwordbox_Click(object sender, EventArgs e)
        {
            passwordbox.BackColor = Color.White;
        }

        private void repettextbox_Click(object sender, EventArgs e)
        {
            repettextbox.BackColor = Color.White;
        }

        private void seguridadpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void dataGrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void ShowSubjects_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
