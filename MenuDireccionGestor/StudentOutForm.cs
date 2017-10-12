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
    public partial class StudentOutForm : Form
    {
        public StudentOutForm()
        {
            InitializeComponent();
            rutafoto.Hide();
            actionbox.Text = "DESINSCRIBIR";

            namelabel.Text=StudentsClass.getstaticname().ToString();
            StudentsClass student = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT * FROM "+UserAccessForm.getusername()+ "_student_table WHERE `NOMBRE COMPLETO` = '"+namelabel.Text+"';";
            student.filleverylabel(agelabel, gradelabel, horariolabel, birthdatelabel, nacionalitylabel, telephonelabel, adresslabel, sexolabel, inscritolabel, fechaentradalabel, fechasalidalabel, numeroactalabel, foliolabel, librolabel, yearlabel, oficialialabel, municipiolabel, alergialabel, medicinalabel, razonmedicinalabel, sindromelabel, tutorlabel, cedulalabel, mensualidadlabel, tipomoneda, rutafoto, parentescolabel,emaillabel,orden);
           

            if ( inscritolabel.Text == "SI")
            {
                actionbox.Text = "DESINSCRIBIR";
                fechasalidalabel.Show();
                titulofechasalida.Show();
                //birthDateBox.Text = fechasalidalabel.Text;
                birthDateBox.Show();
                titulosalidaopen.Show();
                
            }
            if (inscritolabel.Text == "NO")
            {
                fechasalidalabel.Hide();
                titulofechasalida.Hide();
                birthDateBox.Hide();
                titulosalidaopen.Hide();
                actionbox.Text = "INSCRIBIR";
            }

            if (inscritolabel.Text == "NO") {
                actionbox.Text = "INSCRIBIR";

            }
            if (inscritolabel.Text == "SI")
            {
                actionbox.Text = "DESINSCRIBIR";
                fechasalidalabel.Hide();
                titulofechasalida.Hide();
                
            }


            

            if (rutafoto.Text != "")
            {
            
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                string fotopath = System.IO.Path.Combine(combinacion, rutafoto.Text);
             
                pictureBox.ImageLocation = fotopath;


                }
            datecontrol.Hide();
            datecontrol.Enabled = false;

            }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            
            StudentFormSearch menu = new StudentFormSearch();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {

            TimeClass timeobject = new TimeClass();
            hourlabelstrip.Text = timeobject.clockshape();
            datelabelstrip.Text = timeobject.dateshape();



            AgendaClass ev = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

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

            if (inscritolabel.Text == "SI" && actionbox.Text == "INSCRIBIR")
            {
                outbutton.Enabled = false;
            }
            else if (inscritolabel.Text == "NO" && actionbox.Text == "DESINSCRIBIR")
            {

                outbutton.Enabled = false;
            }
            else { outbutton.Enabled = true; }
            cuenta++;
            if (cuenta == 4000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void StudentOutForm_Load(object sender, EventArgs e)
        {
            outbutton.Enabled = false;
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private string inscrito;

        private void desincriptionbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            
            if (actionbox.Text == "DESINCRIBIR") {
                birthDateBox.Show();
                titulosalidaopen.Show();
                birthDateBox.Show();
                titulosalidaopen.Show();
                inscrito = "NO";

                if (inscritolabel.Text == "SI" && actionbox.Text == "INSCRIBIR")
                {
                    outbutton.Enabled = false;
                }
                else if (inscritolabel.Text == "NO" && actionbox.Text == "DESINSCRIBIR")
                {

                    outbutton.Enabled = false;
                }
                else { outbutton.Enabled = true; }

            } else {

                birthDateBox.Hide();
                titulosalidaopen.Hide();
                titulofechasalida.Hide();
                fechasalidalabel.Hide();
                inscrito = "SI";

                if (inscritolabel.Text == "SI" && actionbox.Text == "INSCRIBIR")
                {
                    outbutton.Enabled = false;
                }
                else if (inscritolabel.Text == "NO" && actionbox.Text == "DESINSCRIBIR")
                {

                    outbutton.Enabled = false;
                }
                else { outbutton.Enabled = true; }
            }

            outbutton.Text = actionbox.Text;

        }

        private void birthDateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            titulofechasalida.Show();
            fechasalidalabel.Show();
            fechasalidalabel.Text = birthDateBox.Text;
        }

        private void tipomoneda_Click(object sender, EventArgs e)
        {

        }

        private void mensualidadlabel_Click(object sender, EventArgs e)
        {

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setsombrestatic(namelabel.Text);
            
            DireccionGestor.setotrostatic(gradelabel.Text);
            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass student = new StudentsClass();
            string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + namelabel.Text + "' and CURSO= '" + gradelabel.Text + "';";
            DireccionGestor.setorigen("editor");
            DireccionGestor.setordensql(orden);

            StudentForm studentaddobject = new StudentForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
                this.Close();
            
        }
        private string salida;
        private void outbutton_Click(object sender, EventArgs e)
        {
            StudentsClass clas = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            MovementsClass cas = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            string user = UserAccessForm.getusername() + "_student_table";
            string orden;
            string control= datecontrol.Value.Day.ToString() + "/" + datecontrol.Value.Month.ToString() + "/" + datecontrol.Value.Year.ToString();
            if (actionbox.Text == "INSCRIBIR") { salida = "00/00/0000"; }
            else { salida = birthDateBox.Value.Day.ToString() + "/" + birthDateBox.Value.Month.ToString() + "/" + birthDateBox.Value.Year.ToString(); }
            string deuda;
           

            clas.ModifyData(user, namelabel.Text, salida,  inscrito);
        
            StudentFormSearch menu = new StudentFormSearch();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
