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
    public partial class StudentFormSearch : Form
    {

        
        public StudentFormSearch()
        {
            InitializeComponent();
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            datecontrol.Hide();
            inscritobox.Text = "SI";
            string userDataName = UserAccessForm.getusername() + "_student_table";

            string allorden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '"+inscritobox.Text+"'; ";
            show.ShowDataGrid(findinggrid, allorden);
            encontradoslabel.Text = show.getcuenta().ToString();

            string curso = "select distinct CURSO from " + userDataName + "";
            show.Fillcombo(gradebox, curso);

            string nombre = "select distinct `NOMBRE COMPLETO` from " + userDataName + "";
            show.Fillcombo(namebox, nombre);

            string edad = "select distinct EDAD from " + userDataName + "";
            show.Fillcombo(edadbox, edad);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void hourlabelstrip_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            TimeClass timeobject = new TimeClass();
            datelabelstrip.Text = timeobject.dateshape();
            hourlabelstrip.Text = timeobject.clockshape();

            AgendaClass ev = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            string hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string fechal = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(); ;
            string fechashort = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();




            string orden = "SELECT DESCRIPCION, HORA, PRIORIDAD FROM " + UserAccessForm.getusername() + "_events_table WHERE (HORA='" + hora + "' AND ( FECHA='" + fechal + "' or `FECHA DE RECORDATORIO`='" + fechashort + "'))AND ACTIVO='SI';";
            if (ev.getnametarea( orden))
            {
                DireccionGestor.setsombrestatic(ev.getname());
                DireccionGestor.setotrostatic(ev.gettime());
                DireccionGestor.setprioridadstatic(ev.getprioridad());
                DireccionGestor.setestadostatic(true);
                SystemSounds.Hand.Play();
                MessageBox.Show("SON LAS " + ev.gettime() + " ES HORA DE " + ev.getname());
            }
            cuenta++;
            if (cuenta == 4000)
            {

                cuenta = 0;
                backstripbutton.PerformClick();
            }



        }


        private int cuenta;

        private void StudentFormSearch_Load(object sender, EventArgs e)
        {
            inscritobox.Text = "SI";
            eliminarbutton.Enabled = false;
            editbutton.Enabled = false;
            addbutton.BackColor = Color.Green;
            eliminarbutton.BackColor = Color.Red;
            editbutton.BackColor = Color.DarkBlue;
            searchbutton.BackColor = Color.Blue;
            
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            namebox.Text = "";
            edadbox.Text = "";
            gradebox.Text = "";
            inscritobox.Text = "SI";
            inscritopanel.Hide();
            string userDataName = UserAccessForm.getusername() + "_student_table";
            string allorden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '" + inscritobox.Text + "'; ";
            StudentsClass show = new StudentsClass();
            show.ShowDataGrid(findinggrid, allorden);
            encontradoslabel.Text = show.getcuenta().ToString();
            getoutdateTimePicker.Text = DateTime.Today.ToString();
            getindateTimePicker.Text = DateTime.Today.ToString();
            birthdate.Text = DateTime.Today.ToString();
        }

        
        private string birthdates;
        private string timegetin;
        private string timegetout;
        private void searchbutton_Click(object sender, EventArgs e) {

            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden;
            string fecha = datecontrol.Value.Day.ToString() + "/" + datecontrol.Value.Month.ToString() + "/" + datecontrol.Value.Year.ToString();

            birthdates = birthdate.Value.Day.ToString() + "/" + birthdate.Value.Month.ToString() + "/" + birthdate.Value.Year.ToString();
            timegetin = getindateTimePicker.Value.Day.ToString() + "/" + getindateTimePicker.Value.Month.ToString() + "/" + getindateTimePicker.Value.Year.ToString();
            timegetout = getoutdateTimePicker.Value.Day.ToString() + "/" + getoutdateTimePicker.Value.Month.ToString() + "/" + getoutdateTimePicker.Value.Year.ToString();

            

            if (inscritobox.Text == "si" || inscritobox.Text == "SI") {

                orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                show.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = show.getcuenta().ToString();

                if (birthdates == fecha) {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (namebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edadbox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && namebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  EDAD = '" + edadbox.Text + "' AND  `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edadbox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "'  AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && edadbox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && namebox.Text == "" && edadbox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && edadbox.Text == "" && gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && edadbox.Text == "" && gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && namebox.Text == "" && gradebox.Text == "") {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where EDAD = '" + edadbox.Text + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && edadbox.Text == "" && gradebox.Text == "" && birthdates == fecha)
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
            } else {

                orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                show.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = show.getcuenta().ToString();

                if (birthdates == fecha)
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (namebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edadbox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && namebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  EDAD = '" + edadbox.Text + "' AND  `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edadbox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND EDAD = '" + edadbox.Text + "'  AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && edadbox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where EDAD = '" + edadbox.Text + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && namebox.Text == "" && edadbox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where    `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && edadbox.Text == "" && gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && edadbox.Text == "" && gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where `NOMBRE COMPLETO` like '%" + namebox.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (birthdates == fecha && namebox.Text == "" && gradebox.Text == "")
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where EDAD = '" + edadbox.Text + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
                else if (namebox.Text == "" && edadbox.Text == "" && gradebox.Text == "" && birthdates == fecha)
                {
                    orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  `FECHA DE ENTRADA` = '" + timegetin + "' AND CURSO ='" + gradebox.Text + "' AND ESTUDIANDO = '" + inscritobox.Text + "');";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
            }

            



            //////////////////////////////////////////////////////////////////
            string mandosql = "select `NOMBRE COMPLETO` from " + userDataName + " where `NOMBRE COMPLETO` ='" + namebox.Text + "' and EDAD = '" + edadbox.Text + "' and CURSO = '" + gradebox.Text + "';";

            if (show.ordensql(mandosql) == true)
            {
                eliminarbutton.Enabled = true;
                editbutton.Enabled = true;
            }
            else {
                eliminarbutton.Enabled = false;
                editbutton.Enabled = false;
            }

            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "")
            {
                editbutton.Enabled = false;
            }
            else
            {
                editbutton.Enabled = true;
            }
        }
    

        private void birthdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void findinggrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try {
                StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_student_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();
                namebox.Text = dato;
                string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + namebox.Text + "';";
                if (show.fillboxes(namebox, birthdate, edadbox, gradebox, inscritobox, getindateTimePicker, getoutdateTimePicker, inscritobox, inscritopanel, orden))
                {

                    editbutton.Enabled = true;
                    eliminarbutton.Enabled = true;
                }
                else
                {


                    editbutton.Enabled = false;
                    eliminarbutton.Enabled = false;

                }


            }
            catch (NullReferenceException pafh) { pafh.ToString(); }


}

        private void addbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");
            StudentForm studentaddobject = new StudentForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
            this.Close();
        }

        private void eliminarbutton_Click(object sender, EventArgs e)
        {
            if (inscritobox.Text == "NO")
            {
                MessageBox.Show("Solo se pueden desincribir estudiantes.");
                inscritobox.BackColor = Color.Red;
            }
            else
            {
                if (gradebox.Text == "" || edadbox.Text == "" || namebox.Text == "")
                {
                    MessageBox.Show("Hay datos importantes faltantes.");

                    if (gradebox.Text == "") gradebox.BackColor = Color.Red;
                    if (edadbox.Text == "") edadbox.BackColor = Color.Red;
                    if (namebox.Text == "") namebox.BackColor = Color.Red;

                }
                else {


                    string salida = datecontrol.Value.Day.ToString() + "/" + datecontrol.Value.Month.ToString() + "/" + datecontrol.Value.Year.ToString();
                    StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    string userDataName = UserAccessForm.getusername() + "_student_table";
                    string mandosql = "update "+userDataName+ " set ESTUDIANDO ='NO', `FECHA DE SALIDA`='" + salida + "' where `NOMBRE COMPLETO` ='" + namebox.Text + "' and EDAD = '" + edadbox.Text + "' and CURSO = '" + gradebox.Text + "';";
                    if (show.ordensql(mandosql) == true) MessageBox.Show("Estudiante ha sido desinscrito");
                    else MessageBox.Show("Estudiante desinscrito");
                    string allorden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '" + inscritobox.Text + "'; ";

                    show.ShowDataGrid(findinggrid, allorden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
            }
        }

        private void gradebox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '" + inscritobox.Text + "' AND CURSO='"+gradebox.Text+"'; ";
            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();

            gradebox.BackColor = Color.White;
            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" || inscritobox.Text == "NO") {
                eliminarbutton.Enabled = false;
                
            }
            else {
                eliminarbutton.Enabled = true;
                
            }

            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" )
            {
                
                editbutton.Enabled = false;
            }
            else
            {
             
                editbutton.Enabled = true;
            }


        }

        private void inscritobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inscritobox.Text == "SI") inscritopanel.Hide();
            else inscritopanel.Show();
            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" || inscritobox.Text == "NO")
            {
                eliminarbutton.Enabled = false;
            }

            else
            {
                eliminarbutton.Enabled = true;

            }

            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" )
            {
                
                editbutton.Enabled = false;
            }
            else
            {
                
                editbutton.Enabled = true;
            }

            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_student_table";
            string orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where  ESTUDIANDO = '" + inscritobox.Text + "';";

            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();


        }

        private void namebox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '" + inscritobox.Text + "' AND `NOMBRE COMPLETO` like '%" + namebox.Text + "%';";
            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();

            namebox.BackColor = Color.White;
            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" || inscritobox.Text == "NO") {
                eliminarbutton.Enabled = false;
                
            }
            else {
                eliminarbutton.Enabled = true;
                
            }

            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" )
            {
        
                editbutton.Enabled = false;
            }
            else
            {
                
                editbutton.Enabled = true;
            }


        }

        private void edadbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`,EDAD, `FECHA DE NACIMIENTO`, CURSO, HORARIO, NACIONALIDAD, SEXO, TELEFONO, DIRECCION, `NOMBRE DEL TUTOR` from " + userDataName + " where estudiando = '" + inscritobox.Text + "' and EDAD='"+edadbox.Text+"'; ";
            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();

            edadbox.BackColor = Color.White;
            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" || inscritobox.Text == "NO") {
                eliminarbutton.Enabled = false;
             
            }
            else {
                eliminarbutton.Enabled = true;
                }

            if (namebox.Text == "" || edadbox.Text == "" || gradebox.Text == "" )
            {
                
                editbutton.Enabled = false;
            }
            else
            {
               
                editbutton.Enabled = true;
            }
        }

        
        private void editbutton_Click(object sender, EventArgs e)
        {
            if (gradebox.Text == "" || edadbox.Text == "" || namebox.Text == "")
            {
                MessageBox.Show("Hay datos importantes faltantes.");

                if (gradebox.Text == "") gradebox.BackColor = Color.Red;
                if (edadbox.Text == "") edadbox.BackColor = Color.Red;
                if (namebox.Text == "") namebox.BackColor = Color.Red;

            }
            else
            {
                
                DireccionGestor.setsombrestatic(namebox.Text);
                DireccionGestor.setedadstatic(int.Parse(edadbox.Text));
                DireccionGestor.setotrostatic(gradebox.Text);
                string userDataName = UserAccessForm.getusername() + "_student_table";
                StudentsClass student = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + namebox.Text + "' and EDAD = '"+edadbox.Text+"' and CURSO= '"+gradebox.Text+"';";
                if(student.fillcombos(namebox, edadbox,gradebox, orden) == true) {
                    DireccionGestor.setorigen("editor");
                    DireccionGestor.setordensql(orden);
                   
                    StudentForm studentaddobject = new StudentForm();
                    studentaddobject.WindowState = FormWindowState.Maximized;
                    studentaddobject.Show();
                    this.Close();
                }
            }
        }

        private void findinggrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_student_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();
                namebox.Text = dato;
                string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + namebox.Text + "' ;";
                if (show.fillboxes(namebox, birthdate, edadbox, gradebox, inscritobox, getindateTimePicker, getoutdateTimePicker, inscritobox, inscritopanel, orden) == true)
                {
                    StudentOutForm menu = new StudentOutForm();
                    menu.WindowState = FormWindowState.Maximized;
                    menu.Show();
                    this.Close();
                }
            }
            catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void findinggrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void finderpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void buttonpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
    }

