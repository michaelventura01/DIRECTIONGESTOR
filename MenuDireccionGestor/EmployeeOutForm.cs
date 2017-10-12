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
    public partial class EmployeeOutForm : Form
    {
        public EmployeeOutForm()
        {
            InitializeComponent();
            picturetextbox.Hide();
            

        }

        private void label5_Click(object sender, EventArgs e)
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
            cuenta++;
            if (cuenta == 5000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void EmployeeOutForm_Load(object sender, EventArgs e)
        {
            outbutton.Enabled = false;

            EmployeeClass emp = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            //string orden = "SELECT * FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO` = '" + namelabel.Text + "';";
            emp.filleverylabel(namelabel, getintimelabel, gottendegreelabel, idbox, fechanacimientolabel, telephonelabel, schedulelabel, joblabel, nacionalitylabel, agelabel, tipomonedalabel, sueldolabel,referenciapersonallabel, telefonoreferencialabel, referencialabel, alergialabel, dolencialabel, medicinalabel, razonmedicinalabel, trabajandolabel,fechasalidalabel, sexolabel, direccionlabel, picturetextbox,emaillabel,DireccionGestor.getordensql());
            if (fechasalidalabel.Text == "" || fechasalidalabel.Text == "00/00/0000")
            {
                fechasalidalabel.Hide();
                titlesalida.Hide();

            }
            else {
                fechasalidalabel.Show();
                titlesalida.Show();


            }


            if (picturetextbox.Text != "")
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                string fotopath = System.IO.Path.Combine(combinacion, picturetextbox.Text);

                pictureBox.ImageLocation = fotopath;


            }


        }

        private void outbutton_Click(object sender, EventArgs e)
        {

            string mensaje;
            string accion ;
            string salida;
            if (actionbox.Text == "DESPEDIR") {
                accion = "NO";
                salida = salidapicker.Value.Day.ToString() + "/" + salidapicker.Value.Month.ToString() + "/" + salidapicker.Value.Year.ToString();
                mensaje = "EMPLEADO DESPEDIDO";
            }
            else {
                accion = "SI";
                salida = "00/00/0000";
                mensaje = "EMPLEADO CONTRATADO";
            }

            
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            string mandosql = "update " + userDataName + " set TRABAJANDO ='"+accion+"', `FECHA DE SALIDA`='"+salida+"' where `NOMBRE COMPLETO` ='" + namelabel.Text + "' and EDAD = '" + agelabel.Text + "' and PUESTO = '" + joblabel.Text + "';";
            if (show.ordensql(mandosql) == true) MessageBox.Show("Empleado ha sido despedido");
            else MessageBox.Show(mensaje);

            EmployeeFormSearch menu = new EmployeeFormSearch();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();


        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("editor");

            DireccionGestor.setsombrestatic(namelabel.Text);
            DireccionGestor.setotrostatic(joblabel.Text);
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass student = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT * FROM " + userDataName + " WHERE `NOMBRE COMPLETO`= '" + namelabel.Text + "' and EDAD = '" + agelabel.Text + "';";

            DireccionGestor.setorigen("editor");
            DireccionGestor.setordensql(orden);
            EmployeeForm studentaddobject = new EmployeeForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
            this.Close();





        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {

            EmployeeFormSearch menu = new EmployeeFormSearch();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        string salida;

        private void actionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (trabajandolabel.Text == "SI" && actionbox.Text == "CONTRATAR")
            {
                outbutton.Enabled = false;
            }
            else if (trabajandolabel.Text == "NO" && actionbox.Text == "DESPEDIR")
            {

                outbutton.Enabled = false;
            }
            else { outbutton.Enabled = true; }

            if (actionbox.Text == "CONTRATAR") {
                salidapicker.Enabled = false;
                salida = "00/00/0000";
            }
            else {
                salidapicker.Enabled = true;
                salida = salidapicker.Value.Day.ToString() + "/" + salidapicker.Value.Month.ToString() + "/" + salidapicker.Value.Year.ToString();
            }
            outbutton.Text = actionbox.Text;
        }

        private void EmployeeOutForm_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
