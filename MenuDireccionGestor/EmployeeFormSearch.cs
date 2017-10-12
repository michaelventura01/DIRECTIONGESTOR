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
    public partial class EmployeeFormSearch : Form
    {
        public EmployeeFormSearch()
        {
            InitializeComponent();
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT `NOMBRE COMPLETO`, `CEDULA`, `FECHA DE NACIMIENTO` , `SEXO`, `TITULO UNIVERSITARIO`, PUESTO, EDAD, HORARIO, TELEFONO, DIRECCION FROM " + userDataName + " WHERE TRABAJANDO = 'SI';";
            datecontrol.Hide();
            show.ShowDataGridFound(findinggrid, orden);

            encontradoslabel.Text = show.getcuenta().ToString();

            orden = "select distinct `nombre completo` from " + userDataName + "";
            show.Fillcombo(comboname, orden);

            orden = "select distinct `edad` from " + userDataName+"";
            show.Fillcombo(edadbox,orden);

            orden = "select distinct `puesto` from " + userDataName + "";
            show.Fillcombo(cargobox, orden);

            workingbox.Text = "SI";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void backstripbutton_Click(object sender, EventArgs e)
        {
            
            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
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
            if (cuenta == 4000)
            {

                cuenta = 0;
                backstripbutton.PerformClick();
            }



        }


        private int cuenta;

        private void EmployeeFormSearch_Load(object sender, EventArgs e)
        {
            addbutton.BackColor = Color.Green;
            eliminarbutton.BackColor = Color.Red;
            editbutton.BackColor = Color.DarkBlue;
            searchbutton.BackColor = Color.Blue;
            
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            comboname.Text = "";
            edadbox.Text = "";
            cargobox.Text = "";
            workingbox.Text = "SI";
            trabajandopanel.Hide();
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            string allorden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where TRABAJANDO = '" + workingbox.Text + "'; ";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            show.ShowDataGrid(findinggrid, allorden);

            encontradoslabel.Text = show.getcuenta().ToString();
            getoutdateTimePicker.Text = DateTime.Today.ToString();
            getindateTimePicker.Text = DateTime.Today.ToString();
            birthdatebox.Text = DateTime.Today.ToString();
            
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");
            EmployeeForm studentaddobject = new EmployeeForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
            this.Close();
        }

        private void finderpanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {    
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden;

            string fecha = datecontrol.Value.Day.ToString() + "/" + datecontrol.Value.Month.ToString() + "/" + datecontrol.Value.Year.ToString();
            string name = comboname.Text;
            string edad = edadbox.Text;
            
            string birthdates = birthdatebox.Value.Day.ToString() + "/" + birthdatebox.Value.Month.ToString() + "/" + birthdatebox.Value.Year.ToString();
            string timegetin = getindateTimePicker.Value.Day.ToString() + "/" + getindateTimePicker.Value.Month.ToString() + "/" + getindateTimePicker.Value.Year.ToString();
            string timegetout = getoutdateTimePicker.Value.Day.ToString() + "/" + getoutdateTimePicker.Value.Month.ToString() + "/" + getoutdateTimePicker.Value.Year.ToString();
            string puesto = cargobox.Text;
            string trabaja = workingbox.Text;


            if (trabaja == "SI" || trabaja == "si") {

                orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                show.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = show.getcuenta().ToString();
                
                if (birthdates == fecha)
                {
                    birthdates = "";
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND  `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edad == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where  EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edad == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && edad == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edad == "" && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%'  AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == ""&& edad == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && edad == "" && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edad == "" && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "" && puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "" && edad == ""&& puesto == "") {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE ENTRADA` = '" + timegetin + "' AND `FECHA DE SALIDA` = '" + timegetout + "'AND TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }

            }
            else {
                orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                show.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = show.getcuenta().ToString();

                if (birthdates == fecha)
                {
                    birthdates = "";
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND  `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edad == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where  EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edad == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "'  AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && edad == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (edad == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%'  AND `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "" && edad == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE ENTRADA` = '" + timegetin + "' AND PUESTO ='" + puesto + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (name == "" && edad == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE NACIMIENTO`= '" + birthdates + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && edad == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `NOMBRE COMPLETO` like '%" + comboname.Text + "%' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where EDAD = '" + edad + "' AND `FECHA DE ENTRADA` = '" + timegetin + "' AND  TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }
                else if (birthdates == fecha && name == "" && edad == "" && puesto == "")
                {
                    orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where `FECHA DE ENTRADA` = '" + timegetin + "' AND TRABAJANDO = '" + trabaja + "';";
                    show.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = show.getcuenta().ToString();
                }

            }
            //////////////////////////////////////////////
            string mandosql = "select `NOMBRE COMPLETO` from " + userDataName + " where `NOMBRE COMPLETO` ='" + name + "' and EDAD = '" + edad + "' and PUESTO = '" + puesto + "';";
            if (show.ordensql(mandosql) == true)
            {
                eliminarbutton.Enabled = true;
                editbutton.Enabled = true;
            }
            else {
                eliminarbutton.Enabled = false;
                editbutton.Enabled = false;
            }


            if (comboname.Text == "" || edadbox.Text == "" || cargobox.Text == "")
            {

                editbutton.Enabled = false;
            }
            else
            {

                editbutton.Enabled = true;
            }
          
        }

        private void workingbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (workingbox.Text == "SI") trabajandopanel.Hide();
            else trabajandopanel.Show();
            if (comboname.Text == "" || edadbox.Text == "" || cargobox.Text == "" || workingbox.Text == "NO")
            {
                eliminarbutton.Enabled = false;
            }

            else
            {
                eliminarbutton.Enabled = true;

            }

            if (comboname.Text == "" || edadbox.Text == "" || cargobox.Text == "")
            {

                editbutton.Enabled = false;
            }
            else
            {

                editbutton.Enabled = true;
            }



            string userDataName = UserAccessForm.getusername() + "_employee_table";
            string orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where  TRABAJANDO = '" + workingbox.Text + "';";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            show.ShowDataGridFound(findinggrid, orden);

            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void dataSet1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            if (cargobox.Text == "" || edadbox.Text == "" || comboname.Text == "")
            {
                MessageBox.Show("Hay datos importantes faltantes.");

                if (cargobox.Text == "") cargobox.BackColor = Color.Red;
                if (edadbox.Text == "") edadbox.BackColor = Color.Red;
                if (comboname.Text == "") comboname.BackColor = Color.Red;

            }
            else
            {
                DireccionGestor.setsombrestatic(comboname.Text);
                DireccionGestor.setedadstatic(int.Parse(edadbox.Text));
                DireccionGestor.setotrostatic(cargobox.Text);
                string userDataName = UserAccessForm.getusername() + "_employee_table";
                EmployeeClass student = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden = "SELECT * FROM " + userDataName + " WHERE `NOMBRE COMPLETO`= '" + comboname.Text + "' and EDAD = '"+edadbox.Text+"' and ID='"+EmployeeClass.getids()+"';";

                DireccionGestor.setorigen("editor");
                DireccionGestor.setordensql(orden);


                if (student.fillcombos(comboname, edadbox, cargobox, orden) == true) {
                    
                   
                    EmployeeForm studentaddobject = new EmployeeForm();
                    studentaddobject.WindowState = FormWindowState.Maximized;
                    studentaddobject.Show();
                    this.Close();
                }
            }
  
        }

        private void findinggrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_employee_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();
                comboname.Text = dato;
                string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + comboname.Text + "';";
                if (show.fillboxes(comboname, birthdatebox, edadbox, cargobox, workingbox, getindateTimePicker, getoutdateTimePicker, workingbox, trabajandopanel, orden))
                {
                    editbutton.Enabled = true;
                    eliminarbutton.Enabled = true;

                }
                else
                {

                    editbutton.Enabled = false;
                    eliminarbutton.Enabled = false;

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            


        }

        private void findinggrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_employee_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();
                comboname.Text = dato;
                string orden = "select * from " + userDataName + " where `NOMBRE COMPLETO` = '" + comboname.Text + "';";
                DireccionGestor.setordensql(orden);
                if (show.fillboxes(comboname, birthdatebox, edadbox, cargobox, workingbox, getindateTimePicker, getoutdateTimePicker, workingbox, trabajandopanel, orden) == true)
                {
                    EmployeeOutForm menu = new EmployeeOutForm();
                    menu.WindowState = FormWindowState.Maximized;
                    menu.Show();
                    this.Close();

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
                    
        }

        private void eliminarbutton_Click(object sender, EventArgs e)
        {
            
             if (workingbox.Text == "NO")
            {
                MessageBox.Show("Solo se pueden Despedir Empleados.");
                workingbox.BackColor = Color.Red;
            }
            else
            {
                if (cargobox.Text == "" || edadbox.Text == "" || comboname.Text == "")
                {
                    MessageBox.Show("Hay datos importantes faltantes.");

                    if (cargobox.Text == "") cargobox.BackColor = Color.Red;
                    if (edadbox.Text == "") edadbox.BackColor = Color.Red;
                    if (comboname.Text == "") comboname.BackColor = Color.Red;

                }
                else {
                    EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    string userDataName = UserAccessForm.getusername() + "_employee_table";
                    string mandosql = "update "+userDataName+ " set TRABAJANDO ='NO' where `NOMBRE COMPLETO` ='" + comboname.Text + "' and EDAD = '" + edadbox.Text + "' and PUESTO = '" + cargobox.Text + "' and ID='" + EmployeeClass.getids() + "';";
                    if (show.ordensql(mandosql) == true) MessageBox.Show("Empleado ha sido despedido");
                    else MessageBox.Show("Empleado Despedido");
                    show.ShowDataGrid(findinggrid, userDataName);
                    encontradoslabel.Text = show.getcuenta().ToString();

                }
            }
            
             
        }

        private void comboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where  `NOMBRE COMPLETO` like '%"+ comboname.Text + "%' AND TRABAJANDO='" + workingbox.Text + "';";

            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void edadbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where  EDAD like '%" + edadbox.Text + "%' AND TRABAJANDO='" + workingbox.Text + "';";

            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void cargobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass show = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "select `NOMBRE COMPLETO`, CEDULA, `FECHA DE NACIMIENTO`,SEXO , `TITULO UNIVERSITARIO`, PUESTO , EDAD, HORARIO, TELEFONO, DIRECCION from " + userDataName + " where PUESTO like '%" + cargobox.Text + "%' AND TRABAJANDO='"+workingbox.Text+"';";

            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void EmployeeFormSearch_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void findinggrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void buttonpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void finderpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
