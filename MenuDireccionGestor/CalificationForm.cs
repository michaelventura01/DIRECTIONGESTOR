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
    public partial class CalificationForm : Form
    {
        public CalificationForm()
        {
            InitializeComponent();
            panelevaluar.Hide();
            newperiodoevaluarpanel.Hide();
            paneladdcalificar.Hide();
            aceptarpanel.BackColor = Color.Green;
            aceptarevaluacion.BackColor = Color.Green;
            addbutton.BackColor = Color.Green;
            funtionbutton.BackColor = Color.Orange;
            searchbutton.BackColor = Color.DarkBlue;
            newperiod.BackColor = Color.Firebrick;
            generarperiodobutton.BackColor = Color.DarkOrchid;
            modificarbutton.Enabled = false;
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateAsistanceStudentTable(UserAccessForm.getusername());
            create.CreateAsistanceEmployeeTable(UserAccessForm.getusername());
            create.CreateCalificationEmployeeTable(UserAccessForm.getusername());
            create.CreateCalificationStudentTable(UserAccessForm.getusername());
        }

        private void backstripbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor ap = new DireccionGestor();
            ap.WindowState = FormWindowState.Maximized;
            ap.Show();
            this.Close();
        }
        private string change;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta == 3000) {
                picturecalificationstate.Hide();
                paneladdcalificar.Hide();
                pictureperiodstate.Hide();
                findinggrid.Enabled = true;
                studentstates.Enabled = true;
                employeestatee.Enabled = true;
                combocurso.Enabled = true;
                generarperiodobutton.Enabled = true;
                actionbox.Enabled = true;
                monthbox.Enabled = true;
                comboasignatura.Enabled = true;
                periodobox.Enabled = true;
                profesorcombo.Enabled = true;
                searchbutton.Enabled = true;
                newperiod.Enabled = true;
                newperiodoevaluarpanel.Hide();
                
                cleanbuttonstrip.PerformClick();
                scoretext.Text = "";
                pictureevaluationstate.Hide();
                panelevaluar.Hide();
                scoreevaluacion.Text = "";
                funtionbutton.Enabled = false;
                addbutton.Enabled = false;
            }
            if (cuenta == 6000)
            {

                cuenta = 0;
                backstripbutton.PerformClick();
            }

            if (change == "update") {

                cleanbuttonstrip.PerformClick();
            }

            if (periodobox.Text == "")
            {
                findinggrid.Enabled = false;
                periodoiniciolabel.ForeColor = Color.Red;
            }
            else {
                findinggrid.Enabled = true;
                periodoiniciolabel.ForeColor = Color.Black;
            }

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

                MessageBox.Show(DireccionGestor.getnombrestatic().ToString());
            }


            if(namebox.Text!=""&& periodobox.Text!="")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    try
                    {
                        namebox.Text = findinggrid.CurrentCell.Value.ToString();
                    }
                    catch (NullReferenceException ec) { ec.ToString(); }
                    LoginClass eev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    eev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    if (eev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO= '" + periodobox.Text + "';") != namebox.Text)
                    {
                        MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                        funtionbutton.Enabled = false;
                        addbutton.Enabled = false;
                        picturecalificationstate.Hide();
                        pictureinicio.Hide();
                    }
                    else
                    {
                        funtionbutton.Enabled = true;
                        addbutton.Enabled = true;
                        photoname = eev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                        employeestatee.Text = eev.getback("ESTADO", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        periodoperiodo.Text = periodobox.Text;

                        if (photoname == "")
                        {
                            pictureinicio.Hide();

                        }
                        else
                        {

                            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            string combinacion = System.IO.Path.Combine(path, "users");
                            string fotopath = System.IO.Path.Combine(combinacion, photoname);
                            pictureinicio.ImageLocation = fotopath;
                            pictureinicio.Show();
                        }

                        id = eev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");


                    }

                }

                else if (DireccionGestor.getorigen() == "inicio calification empleado")
                {
                    try
                    {
                        namebox.Text = findinggrid.CurrentCell.Value.ToString();
                    }
                    catch (NullReferenceException ec) { ec.ToString(); }
                    LoginClass eev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    eev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    if (eev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO= '" + periodobox.Text + "';") != namebox.Text)
                    {
                        MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                        funtionbutton.Enabled = false;
                        addbutton.Enabled = false;
                        picturecalificationstate.Hide();
                        pictureinicio.Hide();
                    }
                    else
                    {
                        funtionbutton.Enabled = true;
                        addbutton.Enabled = true;
                        photoname = eev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                        employeestatee.Text = eev.getback("ESTADO", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        periodoperiodo.Text = periodobox.Text;

                        if (photoname == "")
                        {
                            pictureinicio.Hide();

                        }
                        else
                        {

                            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            string combinacion = System.IO.Path.Combine(path, "users");
                            string fotopath = System.IO.Path.Combine(combinacion, photoname);
                            pictureinicio.ImageLocation = fotopath;
                            pictureinicio.Show();
                        }

                        id = eev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");


                    }


                }
            }
            
        }


        private int cuenta;

        private void buttonpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void findinggrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void finderpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }


        private void getmonth(ComboBox monthbox) {
            string month = DateTime.Now.Month.ToString();
            switch (int.Parse(month))
            {
                case 1:
                    monthbox.Text = "ENERO";
                    break;
                case 2:
                    monthbox.Text = "FEBRERO";
                    break;
                case 3:
                    monthbox.Text = "MARZO";
                    break;
                case 4:
                    monthbox.Text = "ABRIL";
                    break;
                case 5:
                    monthbox.Text = "MAYO";
                    break;
                case 6:
                    monthbox.Text = "JUNIO";
                    break;
                case 7:
                    monthbox.Text = "JULIO";
                    break;
                case 8:
                    monthbox.Text = "AGOSTO";
                    break;
                case 9:
                    monthbox.Text = "SEPTIEMBRE";
                    break;
                case 10:
                    monthbox.Text = "OCTUBRE";
                    break;
                case 11:
                    monthbox.Text = "NOVIEMBRE";
                    break;
                case 12:
                    monthbox.Text = "DICIEMBRE";
                    break;
                }
            }


        private string papel;
        private void CalificationForm_Load(object sender, EventArgs e)
        {
            
            getmonth(monthbox);

            ///////////////////////////////////////////here
            panelperiodo.Hide();
            studentstates.Text="TODOS";
            employeestatee.Text="TODOS";
            aceptarevaluation.BackColor = Color.Green;
            pictureinicio.Hide();
            picturecalificationstate.Hide();
            pictureevaluationstate.Hide();
            pictureperiodstate.Hide();
            if (DireccionGestor.getorigen() == "inicio asistencia empleado") {
                
                cursolabel.Hide();
                combocurso.Hide();
                titulolabel.Text = "ASISTENCIA DE EMPLEADO";
                actionbox.Show();
                actionbox.Text = "ASISTENCIA";
                papel = "empleado";
                actionlabel.Show();
                studentpicture.Show();
                employeego.Show();
                empleadopicture.Hide();
                studentgo.Hide();
                addbutton.Text = "GENERAR ASISTENCIA";

                profesorcombo.Hide();
                profesorlabel.Hide();
                asignaturalabel.Hide();
                comboasignatura.Hide();

                funtionbutton.Text = "ASISTENCIA";
                calificacion.Hide();
                
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM "+ UserAccessForm.getusername()+ "_period_table order by periodo DESC LIMIT 1;");

                orden = "SELECT `NOMBRE` , ENERO , FEBRERO , MARZO , ABRIL ,MAYO , JUNIO ,JULIO ,AGOSTO ,SEPTIEMBRE ,OCTUBRE , NOVIEMBRE ,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                studentstates.Hide();
                employeestatee.Show();

                ev.Createperiodtable(UserAccessForm.getusername());

            }

            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante") {
                cursolabel.Show();
                combocurso.Show();
                titulolabel.Text = "ASISTENCIA DE ESTUDIANTE";
                profesorcombo.Hide();
                profesorlabel.Hide();
                actionbox.Show();
                actionlabel.Show();

                empleadopicture.Show();
                studentpicture.Hide();
                employeego.Hide();
                studentgo.Show();
                addbutton.Text = "GENERAR ASISTENCIA";
                asignaturalabel.Hide();
                comboasignatura.Hide();
                actionbox.Text = "ASISTENCIA";
                funtionbutton.Text = "ASISTENCIA";
                papel = "estudiante";
                calificacion.Show();
                
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");
                orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                ev.Fillcombo(combocurso, orden);
                orden = "SELECT `NOMBRE` , ENERO , FEBRERO , MARZO , ABRIL ,MAYO , JUNIO ,JULIO ,AGOSTO ,SEPTIEMBRE ,OCTUBRE , NOVIEMBRE ,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
                studentstates.Show();
                employeestatee.Hide();
                ev.Createperiodtable(UserAccessForm.getusername());
            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado") {
                titulolabel.Text = "CALIFICACION DE EMPLEADO";
                actionbox.Show();
                actionlabel.Show();
                cursolabel.Hide();
                combocurso.Hide();
                empleadopicture.Hide();
                studentpicture.Show();
                employeego.Show();
                studentgo.Hide();
                addbutton.Text = "GENERAR CALIFICACION";
                profesorcombo.Hide();
                profesorlabel.Hide();
                asignaturalabel.Hide();
                comboasignatura.Hide();
                actionbox.Text = "CALIFICAR";
                funtionbutton.Text = "CALIFICAR";
                papel = "empleado";
                calificacion.Hide();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE` FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
                studentstates.Hide();
                employeestatee.Show();
                ev.Createperiodtable(UserAccessForm.getusername());
            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {

                titulolabel.Text = "CALIFICACION DE ESTUDIANTE";
                actionbox.Text = "CALIFICAR";
                papel = "estudiante";
                addbutton.Text = "GENERAR CALIFICACION";
                empleadopicture.Show();
                studentpicture.Hide();
                employeego.Hide();
                studentgo.Show();
                actionbox.Show();
                actionlabel.Show();
                calificacion.Show();
                funtionbutton.Text = "CALIFICAR";
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                encontradoslabel.Text = ev.getcuenta().ToString();
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(profesorcombo, orden);
                orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(combocurso, orden);
                orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                ev.Fillcombo(comboasignatura, orden);
                orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                cursolabel.Show();
                combocurso.Show();
                studentstates.Show();
                employeestatee.Hide();
                ev.Createperiodtable(UserAccessForm.getusername());
            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante") {
                titulolabel.Text = "EVALUACION DE ESTUDIANTE";
                actionbox.Hide();
                actionlabel.Hide();
                papel = "estudiante";
                calificacion.Hide();
                addbutton.Text = "GENERAR EVALUACION";
                empleadopicture.Show();
                studentpicture.Hide();
                employeego.Hide();
                studentgo.Show();
                cursolabel.Show();
                combocurso.Show();
                funtionbutton.Text = "EVALUAR";
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignatura, orden);
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(profesorcombo, orden);
                orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(combocurso, orden);
                orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");
                orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
                studentstates.Show();
                employeestatee.Hide();
                ev.Createperiodtable(UserAccessForm.getusername());
            }

        }
        string photoname;
        string nombre;
        private string id;
        private void findinggrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                namebox.Text = this.findinggrid.CurrentCell.Value.ToString();
                nombre = namebox.Text;

                if (papel == "estudiante")
                {

                    if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_asistance_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_asistance_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                            pictureinicio.Hide();
                        }
                        else
                        {
                            funtionbutton.Enabled = true;
                            addbutton.Enabled = true;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            studentstates.Text = ev.getback("`ESTADO`", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_asistance_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "")
                            {
                                pictureinicio.Hide();

                            }
                            else
                            {
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureinicio.ImageLocation = fotopath;
                                pictureinicio.Show();
                            }
                            id = ev.getback("ID", "SELECT ID FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "'");

                        }
                    }

                    else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        profesorcombo.Text = ev.getback("PROFESOR", "SELECT PROFESOR FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        comboasignatura.Text = ev.getback("ASIGNATURA", "SELECT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                            pictureinicio.Hide();
                        }
                        else
                        {
                            funtionbutton.Enabled = true;
                            addbutton.Enabled = true;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            studentstates.Text = ev.getback("`ESTADO`", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "")
                            {
                                pictureinicio.Hide();

                            }
                            else
                            {

                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureinicio.ImageLocation = fotopath;
                                pictureinicio.Show();
                            }

                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");

                        }
                    }

                    else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        profesorcombo.Text = ev.getback("PROFESOR", "SELECT PROFESOR FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        comboasignatura.Text = ev.getback("ASIGNATURA", "SELECT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                            pictureinicio.Hide();
                        }
                        else
                        {
                            funtionbutton.Enabled = true;
                            addbutton.Enabled = true;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            studentstates.Text = ev.getback("`ESTADO`", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "")
                            {
                                pictureinicio.Hide();

                            }
                            else
                            {

                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureinicio.ImageLocation = fotopath;
                                pictureinicio.Show();
                            }

                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");

                        }


                    }


                }
                else if (papel == "empleado")
                {
                    if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                    {
                        
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        namebox.Text = findinggrid.CurrentCell.Value.ToString();
                        id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM "+UserAccessForm.getusername()+"_asistance_employee_table WHERE NOMBRE='"+namebox.Text+"' AND PERIODO= '"+periodobox.Text+"';") != namebox.Text)
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                            pictureinicio.Hide();
                        }
                        else
                        {
                            funtionbutton.Enabled = true;
                            addbutton.Enabled = true;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            employeestatee.Text = ev.getback("ESTADO", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "")
                            {
                                pictureinicio.Hide();

                            }
                            else
                            {

                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureinicio.ImageLocation = fotopath;
                                pictureinicio.Show();
                            }                          

                        }

                    }

                    else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                    {
                        
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        namebox.Text = findinggrid.CurrentCell.Value.ToString();
                        id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        //MessageBox.Show(id.ToString());
                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO= '" + periodobox.Text + "';") != namebox.Text)
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                            pictureinicio.Hide();
                        }
                        else
                        {

                            funtionbutton.Enabled = true;
                            addbutton.Enabled = true;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            employeestatee.Text = ev.getback("ESTADO", "SELECT `ESTADO` FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;
                            
                            if (photoname == "")
                            {
                                pictureinicio.Hide();

                            }
                            else
                            {

                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureinicio.ImageLocation = fotopath;
                                pictureinicio.Show();
                            }                                                       

                        }


                    }
                }
                
                

            } catch (NullReferenceException pafh) { pafh.ToString(); }
        }

        private void findinggrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            try
            {
                findinggrid.Enabled = false;
                namebox.Text = this.findinggrid.CurrentCell.Value.ToString();
                periodocombocalificar.Text = periodobox.Text;
                nombre = namebox.Text;

                if (papel == "estudiante")
                {

                    if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                    {
                        label6.Text = "TOTAL ASISTENCIA:";
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_asistance_student_table;";
                        ev.Fillcombo(periodocombocalificar, orden);
                        orden = "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_asistance_student_table;";
                        ev.Fillcombo(combocalificarcurso, orden);
                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_asistance_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_asistance_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                        }
                        else
                        {
                            funtionbutton.PerformClick();
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "") {
                                picturecalificationstate.Hide();
                                studentphotocalificar.Show();
                            }
                            else
                            {
                                studentphotocalificar.Hide();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                picturecalificationstate.ImageLocation = fotopath;
                                picturecalificationstate.Show();
                            }
                            id = ev.getback("ID", "SELECT ID FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "'");


                        }
                    }

                    else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                        ev.Fillcombo(asignaturacombocalificar, orden);
                        orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                        ev.Fillcombo(profesorcombocalificar, orden);
                        orden = "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                        ev.Fillcombo(combocalificarcurso, orden);
                        orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                        ev.Fillcombo(periodocombocalificar, orden);
                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        profesorcombo.Text = ev.getback("PROFESOR", "SELECT PROFESOR FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        comboasignatura.Text = ev.getback("ASIGNATURA", "SELECT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                        }
                        else
                        {
                            funtionbutton.PerformClick();
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "") {
                                picturecalificationstate.Hide();
                                studentphotocalificar.Show();
                            }
                            else
                            {
                                studentphotocalificar.Hide();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                picturecalificationstate.ImageLocation = fotopath;
                                picturecalificationstate.Show();
                            }

                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");
                            
                        }

                    }

                    else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                    {
                        
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                        ev.Fillcombo(asignaturaevaluacion, orden);
                        orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                        ev.Fillcombo(profesorevaluacion, orden);
                        orden = "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_callification_student_table;";
                        ev.Fillcombo(cursoevaluacion, orden);
                        orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                        ev.Fillcombo(periodoevaluacionpanel, orden);
                        combocurso.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        profesorcombo.Text = ev.getback("PROFESOR", "SELECT PROFESOR FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                        comboasignatura.Text = ev.getback("ASIGNATURA", "SELECT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");

                        if (ev.getback("NOMBRE", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';") == "")
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                        }
                        else
                        {
                            funtionbutton.PerformClick();
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            periodopanellabel.Text = periodobox.Text;
                            if (photoname == "") {
                                picturecalificationstate.Hide();
                                evaluationphoto.Show();
                            }
                            else
                            {
                                evaluationphoto.Hide();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                pictureevaluationstate.ImageLocation = fotopath;
                                picturecalificationstate.Show();
                            }
                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_student_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';");

                        }


                    }


                }
                else if (papel == "empleado")
                {

                    if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                    {
                        label6.Text = "TOTAL ASISTENCIA:";
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_asistance_employee_table;";
                        ev.Fillcombo(periodocombocalificar, orden);
                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO= '" + periodobox.Text + "';") != namebox.Text)
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            picturecalificationstate.Hide();
                        }
                        else
                        {
                            funtionbutton.PerformClick();
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;
                            if (photoname == "") {
                                picturecalificationstate.Hide();
                                employeephotocalificar.Hide();
                            }
                            else
                            {
                                employeephotocalificar.Show();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                picturecalificationstate.ImageLocation = fotopath;
                                picturecalificationstate.Show();
                            }

                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_asistance_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");


                        }

                    }

                    else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                        ev.Fillcombo(periodocombocalificar, orden);
                        if (ev.getback("NOMBRE", "SELECT NOMBRE FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO= '" + periodobox.Text + "';") != namebox.Text)
                        {
                            MessageBox.Show("DEBE SELECCIONAR EL CAMPO [NOMBRE]");
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            pictureevaluationstate.Hide();
                            employeephotocalificar.Show();
                        }
                        else
                        {
                            employeephotocalificar.Hide();
                            funtionbutton.PerformClick();
                            funtionbutton.Enabled = false;
                            addbutton.Enabled = false;
                            photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                            periodoperiodo.Text = periodobox.Text;

                            if (photoname == "") { picturecalificationstate.Hide(); }
                            else
                            {

                                
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                                string combinacion = System.IO.Path.Combine(path, "users");
                                string fotopath = System.IO.Path.Combine(combinacion, photoname);
                                picturecalificationstate.ImageLocation = fotopath;
                                picturecalificationstate.Show();
                            }

                            id = ev.getback("ID", "SELECT ID FROM " + UserAccessForm.getusername() + "_calification_employee_table WHERE NOMBRE='" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';");
                            MessageBox.Show(id.ToString());
                        }
                    }
                }

                
                
            }
            catch (NullReferenceException pafh) {
                findinggrid.Enabled = true;
                pafh.ToString(); }
        }

        private void actionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getmonth(monthbox);
            LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (papel == "estudiante") {
                namebox.Text = "";
                pictureinicio.Hide();
                studentstates.Show();
                employeestatee.Hide();
                namebox.Text = "";
                funtionbutton.Enabled = false;
                addbutton.Enabled = false;
                modificarbutton.Enabled = false;
                if (actionbox.Text == "ASISTENCIA")
                {
                    DireccionGestor.setorigen("inicio asistencia estudiante");
                    titulolabel.Text = "ASISTENCIA DE ESTUDIANTE";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR ASISTENCIA";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "ASISTENCIA";
                    cursolabel.Show();
                    combocurso.Show();
                    ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";

                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                    orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                    ev.Fillcombo(combocurso, orden);
                    orden = "SELECT `NOMBRE` , ENERO , FEBRERO , MARZO , ABRIL ,MAYO , JUNIO ,JULIO ,AGOSTO ,SEPTIEMBRE ,OCTUBRE , NOVIEMBRE ,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();


                }

                else if (actionbox.Text == "CALIFICAR")
                {
                    titulolabel.Text = "CALIFICACION DE ESTUDIANTE";
                    DireccionGestor.setorigen("inicio calificar estudiante");
                    profesorcombo.Show();
                    profesorlabel.Show();
                    asignaturalabel.Show();
                    comboasignatura.Show();
                    addbutton.Text = "GENERAR CALIFICACION";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "CALIFICAR";
                    combocurso.Show();
                    cursolabel.Show();
                    ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(profesorcombo, orden);
                    orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(combocurso, orden);
                    orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");
                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                    ev.Fillcombo(comboasignatura, orden);
                    cursolabel.Show();
                    combocurso.Show();
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
            }
            else if (papel == "empleado") {
                studentstates.Hide();
                pictureinicio.Hide();
                employeestatee.Show();
                combocurso.Hide();
                cursolabel.Hide();
                namebox.Text = "";
                funtionbutton.Enabled = false;
                addbutton.Enabled = false;
                modificarbutton.Enabled = false;
                if (actionbox.Text == "ASISTENCIA")
                {
                    titulolabel.Text = "ASISTENCIA DE EMPLEADO";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR ASISTENCIA";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "ASISTENCIA";
                    DireccionGestor.setorigen("inicio asistencia empleado");
                    combocurso.Hide();
                    cursolabel.Hide();
                    ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (actionbox.Text == "CALIFICAR")
                {
                    titulolabel.Text = "CALIFICACION DE EMPLEADO";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR CALIFICACION";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "CALIFICAR";
                    DireccionGestor.setorigen("inicio calificar empleado");
                    combocurso.Hide();
                    cursolabel.Hide();
                    ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE` FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
            }
        }

        private void monthbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante") {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {

                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {

                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {


                }

            }
            else if (papel == "empleado") {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {

                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {


                }

            }
        }

        private void periodobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante") {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

            }
            else if (papel == "empleado") {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }


                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

            }
        }

        private void comboasignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
            }
            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND PERIODO='" + periodobox.Text + "';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
            }

        }

        private void namebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante") {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE = '" + namebox.Text + "' AND PERIODO='"+periodobox.Text+"';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }

                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE = '" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                } else if (DireccionGestor.getorigen() == "inicio evaluar estudiante") {

                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE = '" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }

            }
            else if (papel == "empleado") {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE NOMBRE = '" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }

                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {

                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE NOMBRE = '" + namebox.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }
            }
        }

        private void profesorcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante") {

                if (DireccionGestor.getorigen() == "inicio calificar estudiante" )
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PROFESOR = '" + profesorcombo.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }
                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PROFESOR = '" + profesorcombo.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                }
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getmonth(monthbox);
            pictureinicio.Hide();
            generarperiodobutton.Hide();
            newperiod.Hide();
            studentstates.Show();
            employeestatee.Hide();
            titulolabel.Text = "EVALUACION DE ESTUDIANTE";
            actionbox.Hide();
            actionlabel.Hide();
            DireccionGestor.setorigen("inicio evaluar estudiante");
            calificacion.Hide();
            addbutton.Text = "GENERAR EVALUACION";
            funtionbutton.Text = "EVALUAR";

            studentstates.Text = "TODOS";
            employeestatee.Text = "TODOS";


            if (DireccionGestor.getorigen() == "inicio calificar estudiante" || DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM `" + UserAccessForm.getusername() + "_subject_table`;";
                ev.Fillcombo(profesorcombo, orden);
                orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(combocurso, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignatura, orden);
                orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_period_table;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                ev.Fillcombo(periodoevaluacionpanel, orden);
                orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='"+combocurso.Text+"' AND ASIGNATURA='"+comboasignatura.Text+"';";
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
                profesorcombo.Show();
                profesorlabel.Show();
                asignaturalabel.Show();
                comboasignatura.Show();
                combocurso.Show();
                cursolabel.Show();
                
            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(namebox, orden);
                orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(profesorcombo, orden);
                orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                ev.Fillcombo(combocurso, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignatura, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodobox, orden);
                periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                ev.Fillcombo(periodoevaluacionpanel, orden);
                orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "';";
               
                ev.ShowDataGridFound(findinggrid, orden);
                encontradoslabel.Text = ev.getcuenta().ToString();
                profesorcombo.Show();
                profesorlabel.Show();
                asignaturalabel.Show();
                comboasignatura.Show();
                combocurso.Show();
                cursolabel.Show();
                
            }


        }

        private void studentpicture_Click(object sender, EventArgs e)
        {
            getmonth(monthbox);
            pictureinicio.Hide();
            generarperiodobutton.Show();
            newperiod.Show();
            studentstates.Text = "TODOS";
            employeestatee.Text = "TODOS";
            namebox.Text = "";
            profesorcombo.Text = "";
            comboasignatura.Text = "";
            studentstates.Show();
            employeestatee.Hide();

            namebox.Text = "";
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
            modificarbutton.Enabled = false;
            
            papel = "estudiante";
            if (papel == "estudiante")
            {
                if (actionbox.Text == "ASISTENCIA")
                {
                    DireccionGestor.setorigen("inicio asistencia estudiante");
                    titulolabel.Text = "ASISTENCIA DE ESTUDIANTE";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR ASISTENCIA";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "ASISTENCIA";
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                    orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                    ev.Fillcombo(combocurso, orden);
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    cursolabel.Show();
                    combocurso.Show();
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (actionbox.Text == "CALIFICAR")
                {
                    LoginClass av = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                    av.Fillcombo(comboasignatura, orden);
                    titulolabel.Text = "CALIFICACION DE ESTUDIANTE";

                    DireccionGestor.setorigen("inicio calificar estudiante");
                    profesorcombo.Show();
                    profesorlabel.Show();
                    asignaturalabel.Show();
                    comboasignatura.Show();
                    combocurso.Show();
                    cursolabel.Show();
                    addbutton.Text = "GENERAR CALIFICACION";
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "CALIFICAR";
                    
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(profesorcombo, orden);
                    orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ev.Fillcombo(combocurso, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                    ev.Fillcombo(comboasignatura, orden);
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
            }

            empleadopicture.Show();
            studentpicture.Hide();
            employeego.Hide();
            studentgo.Show();
            calificacion.Show();
        }

        private void empleadopicture_Click(object sender, EventArgs e)
        {
            getmonth(monthbox);
            pictureinicio.Hide();
            generarperiodobutton.Show();
            newperiod.Show();
            studentstates.Text = "TODOS";
            employeestatee.Text = "TODOS";
            studentstates.Hide();
            employeestatee.Show();
            namebox.Text = "";
            profesorcombo.Text = "";
            comboasignatura.Text = "";
            papel = "empleado";
            combocurso.Hide();
            cursolabel.Hide();

            namebox.Text = "";
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
            modificarbutton.Enabled = false;

            string accion= actionbox.Text;
            if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                actionbox.Text = "ASISTENCIA";
            }
            else { actionbox.Text = accion; }
                

            if (papel == "empleado")
            {
                if (actionbox.Text == "ASISTENCIA")
                {
                    funtionbutton.Text = "ASISTENCIA";
                    titulolabel.Text = "ASISTENCIA DE EMPLEADO";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR ASISTENCIA";
                    DireccionGestor.setorigen("inicio asistencia empleado");
                    actionbox.Show();
                    actionlabel.Show();
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                    orden = "SELECT DISTINCT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table`;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                }
                else if (actionbox.Text == "CALIFICAR")
                {
                    titulolabel.Text = "CALIFICACION DE EMPLEADO";
                    profesorcombo.Hide();
                    profesorlabel.Hide();
                    asignaturalabel.Hide();
                    comboasignatura.Hide();
                    addbutton.Text = "GENERAR CALIFICACION";
                    DireccionGestor.setorigen("inicio calificar empleado");
                    actionbox.Show();
                    actionlabel.Show();
                    funtionbutton.Text = "CALIFICAR";
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                    orden = "SELECT DISTINCT `NOMBRE` FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                    ev.Fillcombo(namebox, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_period_table;";
                    ev.Fillcombo(periodobox, orden);
                    periodobox.Text = ev.getback("PERIODO", "SELECT periodo FROM " + UserAccessForm.getusername() + "_period_table order by periodo DESC LIMIT 1;");

                }
            }

            empleadopicture.Hide();
            studentpicture.Show();
            employeego.Show();
            studentgo.Hide();
            calificacion.Hide();


        }

        private void label7_Click(object sender, EventArgs e)
        {
            scoretext.BackColor = Color.White;
            mescombocalificar.BackColor = Color.White;
            periodocombocalificar.BackColor = Color.White;
            combocalificarcurso.BackColor = Color.White;
            picturecalificationstate.Hide();
            findinggrid.Enabled = true;
            studentstates.Enabled = true;
            employeestatee.Enabled = true;
            combocurso.Enabled = true;
            generarperiodobutton.Enabled = true;
            actionbox.Enabled = true;
            monthbox.Enabled = true;
            comboasignatura.Enabled = true;
            periodobox.Enabled = true;
            profesorcombo.Enabled = true;
            searchbutton.Enabled = true;
            funtionbutton.Enabled = true;
            newperiod.Enabled = true;
            generarperiodobutton.Enabled = true;
            paneladdcalificar.Hide();
            cleanbuttonstrip.PerformClick();
            scoretext.Text = "";
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
        }

        private void paneladd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paneladd_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void newperiodolabelclose_Click(object sender, EventArgs e)
        {
            
            pictureperiodstate.Hide();
            findinggrid.Enabled = true;
            studentstates.Enabled = true;
            employeestatee.Enabled = true;
            combocurso.Enabled = true;
            generarperiodobutton.Enabled = true;
            actionbox.Enabled = true;
            monthbox.Enabled = true;
            comboasignatura.Enabled = true;
            periodobox.Enabled = true;
            profesorcombo.Enabled = true;
            searchbutton.Enabled = true;
            newperiod.Enabled = true;
            
            newperiodoevaluarpanel.Hide();
            
            cleanbuttonstrip.PerformClick();
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
        }

        private void closeevaluacionpanel_Click(object sender, EventArgs e)
        {
            
            pictureevaluationstate.Hide();

            findinggrid.Enabled = true;
            studentstates.Enabled = true;
            employeestatee.Enabled = true;
            combocurso.Enabled = true;
            generarperiodobutton.Enabled = true;
            actionbox.Enabled = true;
            monthbox.Enabled = true;
            comboasignatura.Enabled = true;
            periodobox.Enabled = true;
            profesorcombo.Enabled = true;
            searchbutton.Enabled = true;
            newperiod.Enabled = true;
            
            cleanbuttonstrip.PerformClick();
            panelevaluar.Hide();
            scoreevaluacion.Text = "";
            funtionbutton.Enabled = false;
            addbutton.Enabled = false;
        }

        private string orden;
        //you are doing smt wrong remember if you going to declarate that a student is studing or not, 
        //the thing which could decide isnt the evaluation, it is the asistance list dont to be so dork
        //so remember to change that part, and smt special take the time to think about it

        private void newperiod_Click(object sender, EventArgs e)
        {
            modo = "agregar";
            chargeperiodbutton.Text = "AGREGAR";
            findinggrid.Enabled = false;
            studentstates.Enabled = false;
            employeestatee.Enabled = false;
            modificarbutton.Enabled = false;
            combocurso.Enabled = false;
            generarperiodobutton.Enabled = false;
            cursolabel.Enabled = false;
            actionbox.Enabled = false;
            monthbox.Enabled = false;
            comboasignatura.Enabled = false;
            periodobox.Enabled = false;
            profesorcombo.Enabled = false;
            searchbutton.Enabled = false;
            newperiod.Enabled = false;
            addbutton.Enabled = false;
            funtionbutton.Enabled = false;
            addperiodlabel.Text = "AGREGAR PERIODO";
            //finalstate.Hide();
            employeestate.Text="TRABAJANDO";
            estudentstate.Text="ESTUDIANDO";
            panelperiodo.Hide();
            LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {

                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO EMPLEADO A ASISTENCIA";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                combocursoperiodo.Hide();
                cursolabelperiodo.Hide();
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);
                oldperiodolabel.Show();
                periodoperiodo.Show();
                finalstate.Show();
                employeestate.Show();
                estudentstate.Hide();
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
                ev.Fillcombo(periodobox, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO ESTUDIANTE A ASISTENCIA";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                combocursoperiodo.Show();
                cursolabelperiodo.Show();
                orden = "SELECT DISTINCT `CURSO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(combocursoperiodo, orden);
                oldperiodolabel.Show();
                periodoperiodo.Show();
                finalstate.Show();
                employeestate.Hide();
                estudentstate.Show();
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
                ev.Fillcombo(periodobox, orden);
            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO EMPLEADO A CALIFICACION";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);
                oldperiodolabel.Show();
                periodoperiodo.Show();
                combocursoperiodo.Hide();
                cursolabelperiodo.Hide();
                finalstate.Show();
                employeestate.Show();
                estudentstate.Hide();
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
                ev.Fillcombo(periodobox, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO ESTUDIANTE A CALIFICACION";
                asignaturaperiodolabel.Show();
                comboasignaturaperiodo.Show();
                profesorperiodolabel.Show();
                comboprofesorperiodo.Show();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignaturaperiodo, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboprofesorperiodo, orden);
                combocursoperiodo.Show();
                cursolabelperiodo.Show();
                orden = "SELECT DISTINCT `CURSO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(combocursoperiodo, orden);
                oldperiodolabel.Show();
                periodoperiodo.Show();
                finalstate.Show();
                employeestate.Hide();
                estudentstate.Show();
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
                ev.Fillcombo(periodobox, orden);
            }
            
            periodoperiodo.Text = periodobox.Text;
            
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            //remember to put here the do{}while in order to get a secuence of the students, i would prefer a for bucle  i aint know you
            modo = "agregar";
            modificarbutton.Enabled = false;
            combocurso.Enabled = false;
            generarperiodobutton.Enabled = false;
           
            actionbox.Enabled = false;
            monthbox.Enabled = false;
            comboasignatura.Enabled = false;
            periodobox.Enabled = false;
            profesorcombo.Enabled = false;
            searchbutton.Enabled = false;
            newperiod.Enabled = false;
            addbutton.Enabled = false;
            funtionbutton.Enabled = false;
            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "ASISTENCIA DE EMPLEADO";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Hide();
                employeephotocalificar.Show();
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_asistance_employee_table;";
                ev.Fillcombo(periodocombocalificar, orden);


            }

            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "ASISTENCIA DE ESTUDIANTE";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Show();
                employeephotocalificar.Hide();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_asistance_student_table;";
                ev.Fillcombo(periodocombocalificar, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "CALIFICAR EMPLEADO";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Hide();
                employeephotocalificar.Show();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                ev.Fillcombo(periodocombocalificar, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "CALIFICAR ESTUDIANTE";
                asignaturaboxcalificar.Show();
                profesorcombocalificar.Show();
                asignaturalabelcalificar.Show();
                profesorlabelcalificar.Show();
                studentphotocalificar.Show();
                employeephotocalificar.Hide();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(asignaturaevaluacion, orden);
            }
            else
            {


                if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    panelevaluar.Show();
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(asignaturaevaluacion, orden);
                }

            }

        }

        private void funtionbutton_Click(object sender, EventArgs e)
        {
            modo = "agregar";
            findinggrid.Enabled = false;
            studentstates.Enabled = false;
            employeestatee.Enabled = false;
            modificarbutton.Enabled = false;
            combocurso.Enabled = false;
            generarperiodobutton.Enabled = false;
            
            actionbox.Enabled = false;
            monthbox.Enabled = false;
            comboasignatura.Enabled = false;
            periodobox.Enabled = false;
            profesorcombo.Enabled = false;
            searchbutton.Enabled = false;
            newperiod.Enabled = false;
            addbutton.Enabled = false;
            funtionbutton.Enabled = false;
            
            
            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {
                label6.Text = "TOTAL ASISTENCIA:";
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "ASISTENCIA DE EMPLEADO";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Hide();
                employeephotocalificar.Show();
                labelcalificarcurso.Hide();
                combocalificarcurso.Hide();
                asignaturalabelcalificar.Hide();
                asignaturacombocalificar.Hide();
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodocombocalificar, orden);
                namelabelcalificar.Text = namebox.Text;
                periodocombocalificar.Text = periodobox.Text;
                mescombocalificar.Text = monthbox.Text;
                photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");
                
                if (photoname == "")
                {
                    picturecalificationstate.Hide();
                    studentphotocalificar.Show();
                }
                else
                {
                    studentphotocalificar.Hide();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, "users");
                    string fotopath = System.IO.Path.Combine(combinacion, photoname);
                    picturecalificationstate.ImageLocation = fotopath;
                    picturecalificationstate.Show();
                }

            }
            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                label6.Text = "TOTAL ASISTENCIA:";
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "ASISTENCIA DE ESTUDIANTE";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Show();
                employeephotocalificar.Hide();
                labelcalificarcurso.Show();
                combocalificarcurso.Show();
                asignaturalabelcalificar.Hide();
                asignaturacombocalificar.Hide();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodocombocalificar, orden);
                orden= "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_asistance_student_table;";
                ev.Fillcombo(combocalificarcurso, orden);
                namelabelcalificar.Text = namebox.Text;
                periodocombocalificar.Text = periodobox.Text;
                mescombocalificar.Text = monthbox.Text;
                combocalificarcurso.Text = combocurso.Text;

                photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");

                if (photoname == "")
                {
                    picturecalificationstate.Hide();
                    studentphotocalificar.Show();
                }
                else
                {
                    studentphotocalificar.Hide();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, "users");
                    string fotopath = System.IO.Path.Combine(combinacion, photoname);
                    picturecalificationstate.ImageLocation = fotopath;
                    picturecalificationstate.Show();
                }
            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "CALIFICAR EMPLEADO";
                asignaturaboxcalificar.Hide();
                profesorcombocalificar.Hide();
                asignaturalabelcalificar.Hide();
                profesorlabelcalificar.Hide();
                studentphotocalificar.Hide();
                employeephotocalificar.Show();
                labelcalificarcurso.Hide();
                combocalificarcurso.Hide();
                asignaturalabelcalificar.Hide();
                asignaturacombocalificar.Hide();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodocombocalificar, orden);
                namelabelcalificar.Text = namebox.Text;
                periodocombocalificar.Text = periodobox.Text;
                mescombocalificar.Text = monthbox.Text;

                photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");

                if (photoname == "")
                {
                    picturecalificationstate.Hide();
                    studentphotocalificar.Show();
                }
                else
                {
                    studentphotocalificar.Hide();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, "users");
                    string fotopath = System.IO.Path.Combine(combinacion, photoname);
                    picturecalificationstate.ImageLocation = fotopath;
                    picturecalificationstate.Show();
                }
            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                paneladdcalificar.Show();
                titulopanelcalificar.Text = "CALIFICAR ESTUDIANTE";
                profesorcombocalificar.Show();
                asignaturalabelcalificar.Show();
                profesorlabelcalificar.Show();
                studentphotocalificar.Show();
                employeephotocalificar.Hide();
                labelcalificarcurso.Show();
                combocalificarcurso.Show();

                asignaturalabelcalificar.Show();
                asignaturacombocalificar.Show();

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT PERIODO FROM `"+ UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodocombocalificar, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(asignaturacombocalificar, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(profesorcombocalificar, orden);
                orden = "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                ev.Fillcombo(combocalificarcurso, orden);
                


                namelabelcalificar.Text = namebox.Text;
                periodocombocalificar.Text = periodobox.Text;
                mescombocalificar.Text = monthbox.Text;
                combocalificarcurso.Text = combocurso.Text;
                profesorcombocalificar.Text = profesorcombo.Text;
                asignaturacombocalificar.Text = comboasignatura.Text;
                photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");

                if (photoname == "")
                {
                    picturecalificationstate.Hide();
                    studentphotocalificar.Show();
                }
                else
                {
                    studentphotocalificar.Hide();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, "users");
                    string fotopath = System.IO.Path.Combine(combinacion, photoname);
                    picturecalificationstate.ImageLocation = fotopath;
                    picturecalificationstate.Show();
                }
            }
            else {

                if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    panelevaluar.Show();
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(asignaturaevaluacion, orden);
                    orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(profesorevaluacion, orden);
                    orden = "SELECT DISTINCT CURSO FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                    ev.Fillcombo(cursoevaluacion, orden);
                    orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_period_table;";
                    ev.Fillcombo(periodoevaluacionpanel, orden);

                    namevaluacionpanel.Text = namebox.Text;
                    periodoevaluacionpanel.Text = periodobox.Text;
                    cursoevaluacion.Text = combocurso.Text;
                    profesorevaluacion.Text = profesorcombo.Text;
                    asignaturaevaluacion.Text = comboasignatura.Text;

                    photoname = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + namebox.Text + "';");

                    if (photoname == "")
                    {
                        picturecalificationstate.Hide();
                        studentphotocalificar.Show();
                    }
                    else
                    {
                        studentphotocalificar.Hide();
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                        string combinacion = System.IO.Path.Combine(path, "users");
                        string fotopath = System.IO.Path.Combine(combinacion, photoname);
                        picturecalificationstate.ImageLocation = fotopath;
                        picturecalificationstate.Show();
                    }
                }

            }

        }

        private void searchbutton_Click(object sender, EventArgs e)
        {


            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {

            }

            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {

            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {


            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {

            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {


            }
        }

        private void comboprofesorperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                comboasignaturaperiodo.Text = ev.getback("ASIGNATURA","SELECT ASIGNATURA FROM "+UserAccessForm.getusername()+ "_subject_table WHERE ASIGNADO='"+comboprofesorperiodo.Text+"';");

            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                comboasignaturaperiodo.Text = ev.getback("ASIGNATURA", "SELECT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNADO='" + comboprofesorperiodo.Text + "';");


            }
        }

        private void comboasignaturaperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {

                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                comboasignaturaperiodo.Text = ev.getback("ASIGNADO", "SELECT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNATURA='" + comboasignaturaperiodo.Text + "';");


            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                comboasignaturaperiodo.Text = ev.getback("ASIGNADO", "SELECT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table WHERE ASIGNATURA='" + comboasignaturaperiodo.Text + "';");


            }


        }

        private void newperiodoevaluarpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void asignaturaboxcalificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void aceptarevalua_Click(object sender, EventArgs e)
        {
            
                if (papel == "estudiante")
                {

                    if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                    {
                        if (nombreperiodo.Text == "" || periodoperiodo.Text == "" || combocursoperiodo.Text == "" )
                        {

                            MessageBox.Show("HAY DATOS VACION POR FAVOR RECTIFIQUE");
                            nombreperiodo.BackColor = Color.Red;
                        periodoperiodo.BackColor = Color.Red;
                            combocursoperiodo.BackColor = Color.Red;
                            
                        if (nombreperiodo.Text != "") { nombreperiodo.BackColor = Color.Green; }
                            if (periodoperiodo.Text != "") { periodoperiodo.BackColor = Color.Green; }
                            if (combocursoperiodo.Text != "") { combocursoperiodo.BackColor = Color.Green; }

                        }
                        else
                        {
                            StudentsClass ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        
                       
                            
                            
                            if (nombreperiodo.Text == ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' AND CURSO='" +combocursoperiodo.Text+ "';"))
                            {
                                MessageBox.Show("ESTUDIANTE "+ nombreperiodo.Text + " YA EXISTE EN EL PERIODO "+ periodoperiodo.Text);
                                
                            }
                            else
                            {

                                ev.AddAsistanceStudent(nombreperiodo.Text, periodoperiodo.Text, combocursoperiodo.Text,employeestate.Text, UserAccessForm.getusername());
                                

                                MessageBox.Show("ESTUDIANTE " + nombreperiodo.Text + " AGREGADO EN EL PERIODO " + periodoperiodo.Text+" A LA LISTA DE ASISTENCIA ");
                            }

                            orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                            ev.Fillcombo(periodobox, orden);
                            combocurso.Text = combocursoperiodo.Text;
                            periodobox.Text = periodoperiodo.Text;
                            nombreperiodo.Text = "";
                            combocursoperiodo.Text = "";
                            periodoperiodo.Text = "";
                            cleanbuttonstrip.PerformClick();
                            newperiodoevaluarpanel.Hide();
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            cursolabel.Enabled = true;
                            studentstates.Enabled = true;
                            
                        }
                    }
                    else if (DireccionGestor.getorigen() == "inicio calificar estudiante" )
                    {
                        if (nombreperiodo.Text == "" || periodoperiodo.Text == "" || combocursoperiodo.Text == "" || comboasignaturaperiodo.Text == "" || comboprofesorperiodo.Text == "")
                        {
                            MessageBox.Show("HAY DATOS VACION POR FAVOR RECTIFIQUE");

                            nombreperiodo.BackColor = Color.Red;
                        periodoperiodo.BackColor = Color.Red;
                            combocursoperiodo.BackColor = Color.Red;
                            comboasignaturaperiodo.BackColor = Color.Red;
                            comboprofesorperiodo.BackColor = Color.Red;

                            if (nombreperiodo.Text != "") { nombreperiodo.BackColor = Color.Green; }
                            if (periodoperiodo.Text != "") { periodoperiodo.BackColor = Color.Green; }
                            if (combocursoperiodo.Text != "") { combocursoperiodo.BackColor = Color.Green; }
                            if (comboasignaturaperiodo.Text != "") { comboasignaturaperiodo.BackColor = Color.Green; }
                            if (comboprofesorperiodo.Text != "") { comboprofesorperiodo.BackColor = Color.Green; }
                        }
                        else
                        {

                            StudentsClass ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            //////////////////////////////
                            if (nombreperiodo.Text == ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND CURSO='" + combocursoperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' AND ASIGNATURA='" + comboasignaturaperiodo.Text + "' AND PROFESOR ='" + comboprofesorperiodo.Text + "'"))
                            {
                                MessageBox.Show("ESTUDIANTE " + nombreperiodo.Text + " YA EXISTE EN EL PERIODO " + periodoperiodo.Text+" EN EL CURSO "+combocursoperiodo.Text+" EN LA ASIGNATURA "+comboasignaturaperiodo.Text+" DEL PROFESOR "+comboprofesorperiodo.Text);
                            }
                            else
                            {
                                ev.AddCalificationStudent(nombreperiodo.Text, periodoperiodo.Text, combocursoperiodo.Text, comboasignaturaperiodo.Text, comboprofesorperiodo.Text,estudentstate.Text, UserAccessForm.getusername());
                                if (ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' AND CURSO='" + combocursoperiodo.Text + "';") != nombreperiodo.Text )
                                {
                                    ev.AddAsistanceStudent(nombreperiodo.Text, periodoperiodo.Text, combocursoperiodo.Text,estudentstate.Text, UserAccessForm.getusername());
                                
                                }
                                MessageBox.Show("ESTUDIANTE " + nombreperiodo.Text + " AGREGADO AL PERIODO " + periodoperiodo.Text + " EN EL CURSO " + combocursoperiodo.Text + " EN LA ASIGNATURA " + comboasignaturaperiodo.Text + " DEL PROFESOR " + comboprofesorperiodo.Text);


                            }

                        ////////////////


                            orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                            ev.Fillcombo(periodobox, orden);
                            orden = "SELECT DISTINCT ASIGNATURA FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                            ev.Fillcombo(comboasignatura, orden);
                            orden = "SELECT DISTINCT CURSO FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                            ev.Fillcombo(combocurso, orden);
                            orden = "SELECT DISTINCT PROFESOR FROM `" + UserAccessForm.getusername() + "_calification_student_table`;";
                            ev.Fillcombo(profesorcombo, orden);


                            combocurso.Text = combocursoperiodo.Text;
                            periodobox.Text = periodoperiodo.Text;
                            comboasignatura.Text=comboasignaturaperiodo.Text;
                            profesorcombo.Text = comboprofesorperiodo.Text;

                            combocursoperiodo.Text="";
                            periodoperiodo.Text="";
                            comboasignaturaperiodo.Text="";
                            comboprofesorperiodo.Text="";
                            cleanbuttonstrip.PerformClick();
                            newperiodoevaluarpanel.Hide();
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            cursolabel.Enabled = true;
                            studentstates.Enabled = true;
                    }
                    }

                }
                else if (papel == "empleado")
                {

                    if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                    {
                        if (nombreperiodo.Text == "" || periodoperiodo.Text == "")
                        {
                            MessageBox.Show("HAY DATOS VACION POR FAVOR RECTIFIQUE");
                            nombreperiodo.BackColor = Color.Red;
                            periodoperiodo.BackColor = Color.Red;
                            if (nombreperiodo.Text != "") { nombreperiodo.BackColor = Color.Green; }
                            if (periodoperiodo.Text != "") { periodoperiodo.BackColor = Color.Green; }
                        }
                        else
                        {
                            EmployeeClass ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        //////////////////////////////
                        if ( nombreperiodo.Text== ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' ;"))
                        {
                            MessageBox.Show("EMPLEADO " + nombreperiodo.Text + " YA EXISTE EN EL PERIODO " + periodoperiodo.Text);

                        }
                        else
                        {
                            ev.AddAsistanceEmployee(nombreperiodo.Text, periodoperiodo.Text,employeestate.Text, UserAccessForm.getusername());
                            if ( nombreperiodo.Text != ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' ;")  )
                            {
                                ev.AddCalificationEmployee(nombreperiodo.Text, periodoperiodo.Text, UserAccessForm.getusername());
                            }

                            MessageBox.Show("EMPLEADO " + nombreperiodo.Text + " AGREGAD EN EL PERIODO " + periodoperiodo.Text + " EN LA LISTA DE ASISTENCIA Y CALIFICACION");

                        }

                        ////////////////

                        
                            orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                            ev.Fillcombo(periodobox, orden);
                            periodobox.Text = periodoperiodo.Text;
                            
                            nombreperiodo.Text = "";
                            periodoperiodo.Text = "";
                            cleanbuttonstrip.PerformClick();
                            newperiodoevaluarpanel.Hide();
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            cursolabel.Enabled = true;
                            studentstates.Enabled = true;
                        }
                    }
                    else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                    {
                        if (nombreperiodo.Text == "" || periodoperiodo.Text == "")
                        {
                            MessageBox.Show("HAY DATOS VACION POR FAVOR RECTIFIQUE");
                            nombreperiodo.BackColor = Color.Red;
                            periodoperiodo.BackColor = Color.Red;
                            if (nombreperiodo.Text != "") { nombreperiodo.BackColor = Color.Green; }
                            if (periodoperiodo.Text != "") { periodoperiodo.BackColor = Color.Green; }
                        }
                        else
                        {
                            EmployeeClass ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                            //////////////////////////////
                            if (nombreperiodo.Text==ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' ;"))
                            {
                                MessageBox.Show("EMPLEADO " + nombreperiodo.Text + " YA EXISTE EN EL PERIODO " + periodoperiodo.Text);
                            }
                            else
                            {
                                ev.AddCalificationEmployee(nombreperiodo.Text, periodoperiodo.Text, UserAccessForm.getusername());

                                if (nombreperiodo.Text!=ev.getback("NOMBRE", "SELECT NOMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE NOMBRE='" + nombreperiodo.Text + "' AND PERIODO='" + periodoperiodo.Text + "' ;") )
                                {
                                    ev.AddAsistanceEmployee(nombreperiodo.Text, periodoperiodo.Text,employeestate.Text, UserAccessForm.getusername());
                                    

                                }

                                MessageBox.Show("EMPLEADO " + nombreperiodo.Text + " AGREGAD EN EL PERIODO " + periodoperiodo.Text + " EN LA LISTA DE ASISTENCIA Y CALIFICACION");


                            }

                            ////////////////

                        
                            orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                            ev.Fillcombo(periodobox, orden);
                            periodobox.Text = periodoperiodo.Text;
                            
                            nombreperiodo.Text = "";
                            periodoperiodo.Text = "";
                            cleanbuttonstrip.PerformClick();
                            newperiodoevaluarpanel.Hide();
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            cursolabel.Enabled = true;
                            studentstates.Enabled = true;
                    }
                    }

                }
       
            

        }

        private void aceptarevaluacion_Click(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    if (scoreevaluacion.Text == "" || asignaturaevaluacion.Text == "" || profesorevaluacion.Text == "" || id == "" || cursoevaluacion.Text == "" || periodoevaluacionpanel.Text == "" || calificarevaluacion.Text == "")
                    {

                        MessageBox.Show("HAY DATOS VACIOS POR FAVOR RECTIFIQUE");
                        asignaturaevaluacion.BackColor = Color.Red;
                        profesorevaluacion.BackColor = Color.Red;
                        cursoevaluacion.BackColor = Color.Red;
                        periodoevaluacionpanel.BackColor = Color.Red;
                        calificarevaluacion.BackColor = Color.Red;
                        scoreevaluacion.BackColor = Color.Red;


                        if (asignaturaevaluacion.Text != "") { asignaturaevaluacion.BackColor = Color.Green; }
                        if (profesorevaluacion.Text != "") { profesorevaluacion.BackColor = Color.Green; }
                        if (cursoevaluacion.Text != "") { cursoevaluacion.BackColor = Color.Green; }
                        if (periodoevaluacionpanel.Text != "") { periodoevaluacionpanel.BackColor = Color.Green; }
                        if (calificarevaluacion.Text != "") { calificarevaluacion.BackColor = Color.Green; }
                        if (scoreevaluacion.Text != "") { scoreevaluacion.BackColor = Color.Green; }

                    }
                    else
                    {


                        StudentsClass ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev.editevaluationestudent(scoreevaluacion.Text, calificarevaluacion.Text, id, UserAccessForm.getusername());

                        MessageBox.Show("EVALUACION ASIGNADA A " + namevaluacionpanel.Text + " EN " + calificarevaluacion.Text + " EN EL PERIODO " + periodoevaluacionpanel.Text + " DEL CURSO ASIGNATURA " + asignaturaevaluacion.Text + " DEL PROFESOR " + profesorevaluacion.Text);
                        asignaturaevaluacion.BackColor = Color.White;
                        profesorevaluacion.BackColor = Color.White;
                        cursoevaluacion.BackColor = Color.White;
                        periodoevaluacionpanel.BackColor = Color.White;
                        calificarevaluacion.BackColor = Color.White;
                        panelevaluar.Hide();
                        scoreevaluacion.Text = "";
                        scoreevaluacion.BackColor = Color.White;
                        combocurso.Enabled = true;
                        generarperiodobutton.Enabled = true;
                        actionbox.Enabled = true;
                        monthbox.Enabled = true;
                        comboasignatura.Enabled = true;
                        periodobox.Enabled = true;
                        profesorcombo.Enabled = true;
                        searchbutton.Enabled = true;
                        newperiod.Enabled = true;
                        addbutton.Enabled = true;
                        funtionbutton.Enabled = true;
                        periodobox.Text = periodoevaluacionpanel.Text;
                        combocurso.Text = cursoevaluacion.Text;
                        comboasignatura.Text = asignaturaevaluacion.Text;
                        profesorcombo.Text = profesorevaluacion.Text;
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodoevaluacionpanel.Text + "' AND CURSO='" + cursoevaluacion.Text + "' AND ASIGNATURA='" + asignaturaevaluacion.Text + "' AND ASIGNADO='" + profesorevaluacion.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                }

            }
        }

        private void aceptarpanel_Click(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    if (scoretext.Text == "" ||id == "" || combocalificarcurso.Text == "" || periodocombocalificar.Text == "" || mescombocalificar.Text == "")
                    {

                        MessageBox.Show("HAY DATOS VACIOS POR FAVOR RECTIFIQUE");                        
                        mescombocalificar.BackColor = Color.Red;
                        periodocombocalificar.BackColor = Color.Red;
                        combocalificarcurso.BackColor = Color.Red;
                        scoretext.BackColor = Color.Red;
                        

                        if (mescombocalificar.Text != "") { mescombocalificar.BackColor = Color.Green; }
                        if (periodocombocalificar.Text != "") { periodocombocalificar.BackColor = Color.Green; }
                        if (combocalificarcurso.Text != "") { combocalificarcurso.BackColor = Color.Green; }
                        if (scoretext.Text != "") { scoretext.BackColor = Color.Green; }
                        

                        if (asignaturacombocalificar.Text != "") { asignaturacombocalificar.BackColor = Color.Green; }
                    }
                    else
                    {
                        StudentsClass ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev.editasistancestudent(mescombocalificar.Text,scoretext.Text, id, UserAccessForm.getusername());

                        MessageBox.Show("ASISTENCIA ASIGNADA A " + namelabelcalificar.Text + " EN " + mescombocalificar.Text + " EN EL PERIODO " + periodocombocalificar.Text + " DEL CURSO " + combocalificarcurso.Text );
                        combocalificarcurso.BackColor = Color.White;
                        periodocombocalificar.BackColor = Color.White;
                        mescombocalificar.BackColor = Color.White;
                        paneladdcalificar.Hide();
                        scoretext.Text = "";
                        scoretext.BackColor = Color.White;
                        combocurso.Enabled = true;
                        generarperiodobutton.Enabled = true;
                        actionbox.Enabled = true;
                        monthbox.Enabled = true;
                        comboasignatura.Enabled = true;
                        periodobox.Enabled = true;
                        profesorcombo.Enabled = true;
                        searchbutton.Enabled = true;
                        newperiod.Enabled = true;
                        addbutton.Enabled = true;
                        funtionbutton.Enabled = true;
                        periodobox.Text = periodocombocalificar.Text;
                        combocurso.Text = combocalificarcurso.Text;
                        orden = "SELECT NOMBRE,`ENERO`, FEBRERO, `MARZO` , ABRIL, MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE, DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodocombocalificar.Text + "' AND CURSO='" + combocalificarcurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                        if (scoretext.Text == "" || id == "" || combocalificarcurso.Text == "" || periodocombocalificar.Text == "" || mescombocalificar.Text == "" || profesorcombocalificar.Text == "" || asignaturacombocalificar.Text == "")
                        {

                            MessageBox.Show("HAY DATOS VACIOS POR FAVOR RECTIFIQUE");
                            mescombocalificar.BackColor = Color.Red;
                            periodocombocalificar.BackColor = Color.Red;
                            combocalificarcurso.BackColor = Color.Red;
                            scoretext.BackColor = Color.Red;
                            profesorcombocalificar.BackColor = Color.Red;
                            asignaturacombocalificar.BackColor = Color.Red;


                            if (mescombocalificar.Text != "") { mescombocalificar.BackColor = Color.Green; }
                            if (periodocombocalificar.Text != "") { periodocombocalificar.BackColor = Color.Green; }
                            if (combocalificarcurso.Text != "") { combocalificarcurso.BackColor = Color.Green; }
                            if (scoretext.Text != "") { scoretext.BackColor = Color.Green; }
                            if (profesorcombocalificar.Text != "") { profesorcombocalificar.BackColor = Color.Green; }
                            if (asignaturacombocalificar.Text != "") { asignaturacombocalificar.BackColor = Color.Green; }
                    }
                        else
                        {


                            StudentsClass ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev.editCalificationStudent(mescombocalificar.Text, scoretext.Text, id, UserAccessForm.getusername());

                            MessageBox.Show("CALIFICACION ASIGNADA A " + namelabelcalificar.Text + " EN " + mescombocalificar.Text + " EN EL PERIODO " + periodocombocalificar.Text + " DEL CURSO " + combocalificarcurso.Text +" PARA LA ASIGNATURA "+asignaturacombocalificar.Text+" DEL PROFESOR "+asignaturacombocalificar.Text);
                            combocalificarcurso.BackColor = Color.White;
                            periodocombocalificar.BackColor = Color.White;
                            mescombocalificar.BackColor = Color.White;
                            paneladdcalificar.Hide();
                            scoretext.Text = "";
                            scoretext.BackColor = Color.White;
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            periodobox.Text = periodocombocalificar.Text;
                            combocurso.Text = combocalificarcurso.Text;
                            comboasignatura.Text = asignaturacombocalificar.Text;
                            profesorcombo.Text = profesorcombocalificar.Text;
                            orden = "SELECT NOMBRE,`ENERO`, FEBRERO, `MARZO` , ABRIL, MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE, DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodocombocalificar.Text + "' AND CURSO='" + combocalificarcurso.Text + "' AND PROFESOR='"+profesorcombocalificar.Text+"' AND ASIGNATURA='"+asignaturacombocalificar.Text+"';";
                            ev.ShowDataGridFound(findinggrid, orden);
                            encontradoslabel.Text = ev.getcuenta().ToString();
                        }
                    }

                
            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                     if (scoretext.Text == "" || id == "" || periodocombocalificar.Text == "" || mescombocalificar.Text == "")
                        {

                            MessageBox.Show("HAY DATOS VACIOS POR FAVOR RECTIFIQUE");
                            mescombocalificar.BackColor = Color.Red;
                            periodocombocalificar.BackColor = Color.Red;
                            
                            scoretext.BackColor = Color.Red;


                            if (mescombocalificar.Text != "") { mescombocalificar.BackColor = Color.Green; }
                            if (periodocombocalificar.Text != "") { periodocombocalificar.BackColor = Color.Green; }
                            
                            if (scoretext.Text != "") { scoretext.BackColor = Color.Green; }
                            }
                        else
                        {
                            EmployeeClass ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                            ev.editasistanceemployee(mescombocalificar.Text, scoretext.Text, id, UserAccessForm.getusername());

                            MessageBox.Show("ASISTENCIA ASIGNADA A " + namelabelcalificar.Text + " EN " + mescombocalificar.Text + " EN EL PERIODO " + periodocombocalificar.Text );
                            combocalificarcurso.BackColor = Color.White;
                            periodocombocalificar.BackColor = Color.White;
                            mescombocalificar.BackColor = Color.White;
                            paneladdcalificar.Hide();
                            scoretext.Text = "";
                            scoretext.BackColor = Color.White;
                            combocurso.Enabled = true;
                            generarperiodobutton.Enabled = true;
                            employeestatee.Enabled = true;
                            studentstates.Enabled = true;
                            actionbox.Enabled = true;
                            monthbox.Enabled = true;
                            comboasignatura.Enabled = true;
                            periodobox.Enabled = true;
                            profesorcombo.Enabled = true;
                            searchbutton.Enabled = true;
                            newperiod.Enabled = true;
                            addbutton.Enabled = true;
                            funtionbutton.Enabled = true;
                            periodobox.Text = periodocombocalificar.Text;
                            orden = "SELECT NOMBRE,`ENERO`, FEBRERO, `MARZO` , ABRIL, MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE, DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodocombocalificar.Text + "' ;";
                            ev.ShowDataGridFound(findinggrid, orden);
                            encontradoslabel.Text = ev.getcuenta().ToString();
                        }
                    
                    }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {
                    if (scoretext.Text == "" || id == "" || periodocombocalificar.Text == "" || mescombocalificar.Text == "")
                    {

                        MessageBox.Show("HAY DATOS VACIOS POR FAVOR RECTIFIQUE");
                        mescombocalificar.BackColor = Color.Red;
                        periodocombocalificar.BackColor = Color.Red;

                        scoretext.BackColor = Color.Red;


                        if (mescombocalificar.Text != "") { mescombocalificar.BackColor = Color.Green; }
                        if (periodocombocalificar.Text != "") { periodocombocalificar.BackColor = Color.Green; }

                        if (scoretext.Text != "") { scoretext.BackColor = Color.Green; }
                    }
                    else
                    {
                        EmployeeClass ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        ev = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        ev.editcalificationemployee(mescombocalificar.Text, scoretext.Text, id, UserAccessForm.getusername());

                        MessageBox.Show("CALIFICACION ASIGNADA A " + namelabelcalificar.Text + " EN " + mescombocalificar.Text + " EN EL PERIODO " + periodocombocalificar.Text);
                        combocalificarcurso.BackColor = Color.White;
                        periodocombocalificar.BackColor = Color.White;
                        mescombocalificar.BackColor = Color.White;
                        paneladdcalificar.Hide();
                        scoretext.Text = "";
                        scoretext.BackColor = Color.White;
                        combocurso.Enabled = true;
                        employeestatee.Enabled = true;
                        studentstates.Enabled = true;
                        generarperiodobutton.Enabled = true;
                        actionbox.Enabled = true;
                        monthbox.Enabled = true;
                        comboasignatura.Enabled = true;
                        periodobox.Enabled = true;
                        profesorcombo.Enabled = true;
                        searchbutton.Enabled = true;
                        newperiod.Enabled = true;
                        addbutton.Enabled = true;
                        funtionbutton.Enabled = true;
                        periodobox.Text = periodocombocalificar.Text;
                        orden = "SELECT NOMBRE,`ENERO`, FEBRERO, `MARZO` , ABRIL, MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE, DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodocombocalificar.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                }

            }

        }

        private void searchbutton_Click_1(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    /////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE='" + namebox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }


                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND  ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();

                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ///////////////////////////////////////////////// 
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////
                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((namebox.Text == "") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (namebox.Text == ""))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////


                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";

                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND  ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ///////////////////////////////////////////////// 
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((namebox.Text == "") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (namebox.Text == ""))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////

                }

            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                    if (employeestatee.Text == "" || employeestatee.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE  NOMBRE='" + namebox.Text + "' AND ESTADO='" + employeestatee.Text + "';";

                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }


                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                    if (employeestatee.Text == "" || employeestatee.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE='" + namebox.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE  NOMBRE='" + namebox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }



                }

            }
        }

        private string action;
        private void newbutton_Click(object sender, EventArgs e)
        {
            action = "addnewperson";
            modificarbutton.Enabled = false;
            combocurso.Enabled = false;
            generarperiodobutton.Enabled = false;
            
            actionbox.Enabled = false;
            monthbox.Enabled = false;
            comboasignatura.Enabled = false;
            periodobox.Enabled = false;
            profesorcombo.Enabled = false;
            searchbutton.Enabled = false;
            newperiod.Enabled = false;
            addbutton.Enabled = false;
            funtionbutton.Enabled = false;
            oldperiodolabel.Hide();
            periodoperiodo.Hide();
            finalstate.Hide();
            employeestate.Hide();
            estudentstate.Hide();

            LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {
                
                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO EMPLEADO A ASISTENCIA"; 
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                combocursoperiodo.Hide();
                cursolabelperiodo.Hide();
                ///////////////////////
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);
                


            }
            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO ESTUDIANTE A ASISTENCIA";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                combocursoperiodo.Show();
                cursolabelperiodo.Show();
                orden = "SELECT DISTINCT `CURSO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(combocursoperiodo, orden);



            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO EMPLEADO A CALIFICACION";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO ESTUDIANTE A CALIFICACION";
                asignaturaperiodolabel.Show();
                comboasignaturaperiodo.Show();
                profesorperiodolabel.Show();
                comboprofesorperiodo.Show();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignaturaperiodo, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboprofesorperiodo, orden);
                combocursoperiodo.Show();
                cursolabelperiodo.Show();
                orden = "SELECT DISTINCT `CURSO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(combocursoperiodo, orden);

            }
            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                funtionbutton.Text = "EVALUAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO ESTUDIANTE A EVALUACION";
                asignaturaperiodolabel.Show();
                comboasignaturaperiodo.Show();
                profesorperiodolabel.Show();
                comboprofesorperiodo.Show();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);                
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignaturaperiodo, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboprofesorperiodo, orden);
                combocursoperiodo.Show();
                cursolabelperiodo.Show();
                orden = "SELECT DISTINCT `CURSO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(combocursoperiodo, orden);

            }
        }

        private void combocurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE CURSO='" + combocurso.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante" )
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
            }

        }

        private void generarperiodobutton_Click(object sender, EventArgs e)
        {   //remember to put here the do{}while in order to get a secuence of the students, i would prefer a for bucle  i aint know you
            modo = "agregar";

            chargeperiodbutton.Text = "AGREGAR";
            modificarbutton.Enabled = false;
            combocurso.Enabled = false;
            generarperiodobutton.Enabled = false;
            addperiodlabel.Text = "AGREGAR PERIODO";
            actionbox.Enabled = false;
            monthbox.Enabled = false;
            comboasignatura.Enabled = false;
            periodobox.Enabled = false;
            profesorcombo.Enabled = false;
            searchbutton.Enabled = false;
            newperiod.Enabled = false;
            addbutton.Enabled = false;
            funtionbutton.Enabled = false;
            panelperiodo.Hide();
            if (DireccionGestor.getorigen() == "inicio asistencia empleado")
            {
                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO PERIODO DE ASISTENCIA DE EMPLEADO";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                estudentstate.Hide();
                employeestate.Hide();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                ///////////////////////
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);

            }

            else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                newperiodoevaluarpanel.Show();
                funtionbutton.Text = "ASISTENCIA";
                periodopanellabel.Text = "NUEVO PERIODO DE ASISTENCIA DE ESTUDIANTE";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                estudentstate.Hide();
                employeestate.Hide();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);


            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO PERIODO DE CALIFICACION DE EMPLEADO";
                asignaturaperiodolabel.Hide();
                comboasignaturaperiodo.Hide();
                profesorperiodolabel.Hide();
                comboprofesorperiodo.Hide();
                estudentstate.Hide();
                employeestate.Show();
                finalstate.Show();
                studentperiodophoto.Hide();
                employeeperiodophoto.Show();
                ///////////////////////
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);



            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                funtionbutton.Text = "CALIFICAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO PERIODO DE CALIFICACION DE ESTUDIANTE";
                asignaturaperiodolabel.Show();
                comboasignaturaperiodo.Show();
                profesorperiodolabel.Show();
                comboprofesorperiodo.Show();
                estudentstate.Show();
                employeestate.Hide();
                studentperiodophoto.Show();
                finalstate.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodobox, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignaturaperiodo, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboprofesorperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                funtionbutton.Text = "EVALUAR";
                newperiodoevaluarpanel.Show();
                periodopanellabel.Text = "NUEVO PERIODO DE EVALUACION DE ESTUDIANTE";
                asignaturaperiodolabel.Show();
                comboasignaturaperiodo.Show();
                profesorperiodolabel.Show();
                comboprofesorperiodo.Show();
                estudentstate.Show();
                employeestate.Hide();
                studentperiodophoto.Show();
                employeeperiodophoto.Hide();
                ///////////////////////
                LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                ev.Fillcombo(nombreperiodo, orden);
                orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboasignaturaperiodo, orden);
                orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                ev.Fillcombo(comboprofesorperiodo, orden);
                orden = "SELECT DISTINCT PERIODO FROM `" + UserAccessForm.getusername() + "_period_table`;";
                ev.Fillcombo(periodoperiodo, orden);
            }
        }

        private void generarnuevosbutton_Click(object sender, EventArgs e)
        {
                //remember to put here the do{}while in order to get a secuence of the students, i would prefer a for bucle  i aint know you
                action = "addnew";
                modificarbutton.Enabled = false;
                combocurso.Enabled = false;
                generarperiodobutton.Enabled = false;
                actionbox.Enabled = false;
                monthbox.Enabled = false;
                comboasignatura.Enabled = false;
                periodobox.Enabled = false;
                profesorcombo.Enabled = false;
                searchbutton.Enabled = false;
                newperiod.Enabled = false;
                addbutton.Enabled = false;
                funtionbutton.Enabled = false;
                oldperiodolabel.Hide();
                periodoperiodo.Hide();
                finalstate.Hide();
                employeestate.Hide();
                estudentstate.Hide();


                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {

                    newperiodoevaluarpanel.Show();
                    funtionbutton.Text = "ASISTENCIA";
                    periodopanellabel.Text = "NUEVO EMPLEADO A ASISTENCIA";
                    asignaturaperiodolabel.Hide();
                    comboasignaturaperiodo.Hide();
                    profesorperiodolabel.Hide();
                    comboprofesorperiodo.Hide();
                    studentperiodophoto.Hide();
                    employeeperiodophoto.Show();
                    ///////////////////////
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                    ev.Fillcombo(nombreperiodo, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_asistance_employee_table;";
                    ev.Fillcombo(periodoperiodo, orden);


                }

                else if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    newperiodoevaluarpanel.Show();
                    funtionbutton.Text = "ASISTENCIA";
                    periodopanellabel.Text = "NUEVO ESTUDIANTE A ASISTENCIA";
                    asignaturaperiodolabel.Hide();
                    comboasignaturaperiodo.Hide();
                    profesorperiodolabel.Hide();
                    comboprofesorperiodo.Hide();
                    studentperiodophoto.Show();
                    employeeperiodophoto.Hide();
                    ///////////////////////
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                    ev.Fillcombo(nombreperiodo, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_asistance_student_table;";
                    ev.Fillcombo(periodoperiodo, orden);



                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {
                    funtionbutton.Text = "CALIFICAR";
                    newperiodoevaluarpanel.Show();
                    periodopanellabel.Text = "NUEVO EMPLEADO A CALIFICACION";
                    asignaturaperiodolabel.Hide();
                    comboasignaturaperiodo.Hide();
                    profesorperiodolabel.Hide();
                    comboprofesorperiodo.Hide();
                    studentperiodophoto.Hide();
                    employeeperiodophoto.Show();
                    ///////////////////////
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
                    ev.Fillcombo(nombreperiodo, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_calification_employee_table;";
                    ev.Fillcombo(periodoperiodo, orden);



                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    funtionbutton.Text = "CALIFICAR";
                    newperiodoevaluarpanel.Show();
                    periodopanellabel.Text = "NUEVO ESTUDIANTE A CALIFICACION";
                    asignaturaperiodolabel.Show();
                    comboasignaturaperiodo.Show();
                    profesorperiodolabel.Show();
                    comboprofesorperiodo.Show();
                    studentperiodophoto.Show();
                    employeeperiodophoto.Hide();
                    ///////////////////////
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                    ev.Fillcombo(nombreperiodo, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                    ev.Fillcombo(periodoperiodo, orden);
                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(comboasignaturaperiodo, orden);
                    orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(comboprofesorperiodo, orden);

                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    funtionbutton.Text = "EVALUAR";
                    newperiodoevaluarpanel.Show();
                    periodopanellabel.Text = "NUEVO ESTUDIANTE A EVALUACION";
                    asignaturaperiodolabel.Show();
                    comboasignaturaperiodo.Show();
                    profesorperiodolabel.Show();
                    comboprofesorperiodo.Show();
                    studentperiodophoto.Show();
                    employeeperiodophoto.Hide();
                    ///////////////////////
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT DISTINCT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_student_table;";
                    ev.Fillcombo(nombreperiodo, orden);
                    orden = "SELECT DISTINCT `PERIODO` FROM " + UserAccessForm.getusername() + "_calification_student_table;";
                    ev.Fillcombo(periodoperiodo, orden);
                    orden = "SELECT DISTINCT ASIGNATURA FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(comboasignaturaperiodo, orden);
                    orden = "SELECT DISTINCT ASIGNADO FROM " + UserAccessForm.getusername() + "_subject_table;";
                    ev.Fillcombo(comboprofesorperiodo, orden);

                }
            


        }

        private void nombreperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string photonames;

            if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
            {
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                combocursoperiodo.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`= '" + nombreperiodo.Text + "';");
                photonames = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + nombreperiodo.Text + "';");
                if (photonames == "")
                {
                    pictureperiodstate.Hide();
                    studentperiodophoto.Show();
                }
                else
                {
                    studentperiodophoto.Hide();                    
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());
                    string fotopath = System.IO.Path.Combine(combinacion, photonames);
                    pictureperiodstate.ImageLocation = fotopath;
                    pictureperiodstate.Show();
                }

            }
            else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
            {
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                combocursoperiodo.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`= '" + nombreperiodo.Text + "';");
                photonames = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + nombreperiodo.Text + "';");
                if (photonames == "")
                {
                    pictureperiodstate.Hide();
                    studentperiodophoto.Show();
                }
                else
                {
                    studentperiodophoto.Hide();                    
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());
                    string fotopath = System.IO.Path.Combine(combinacion, photonames);
                    pictureperiodstate.ImageLocation = fotopath;
                    pictureperiodstate.Show();
                }
            }

            else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
            {
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                combocursoperiodo.Text = ev.getback("CURSO", "SELECT CURSO FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`= '" + nombreperiodo.Text + "';");
                photonames = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_student_table WHERE `NOMBRE COMPLETO`='" + nombreperiodo.Text + "';");
                if (photonames == "")
                {
                    pictureperiodstate.Hide();
                    studentperiodophoto.Show();
                }
                else
                {
                    studentperiodophoto.Hide();                    
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());
                    string fotopath = System.IO.Path.Combine(combinacion, photonames);
                    pictureperiodstate.ImageLocation = fotopath;
                    pictureperiodstate.Show();
                }
            }
            else if (DireccionGestor.getorigen() == "inicio calificar empleado") {
                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                photonames = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + nombreperiodo.Text + "';");
                if (photonames == "")
                {
                    pictureperiodstate.Hide();
                    employeeperiodophoto.Show();
                }
                else
                {
                    employeeperiodophoto.Hide();
                    pictureperiodstate.Show();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());
                    string fotopath = System.IO.Path.Combine(combinacion, photonames);
                    pictureperiodstate.ImageLocation = fotopath;
                }
            }
            else if (DireccionGestor.getorigen() == "inicio asistencia empleado") {

                ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                photonames = ev.getback("RUTA DE FOTO", "SELECT `RUTA DE FOTO` FROM " + UserAccessForm.getusername() + "_employee_table WHERE `NOMBRE COMPLETO`='" + nombreperiodo.Text + "';");
                if (photonames == "")
                {
                    pictureperiodstate.Hide();
                    employeeperiodophoto.Show();
                }
                else
                {
                    employeeperiodophoto.Hide();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());
                    string fotopath = System.IO.Path.Combine(combinacion, photonames);
                    pictureperiodstate.ImageLocation = fotopath;
                    pictureperiodstate.Show();
                }
            }
            
            
        }

        private void nombreperiodo_Click(object sender, EventArgs e)
        {
            nombreperiodo.BackColor = Color.White;
        }

        private void comboasignaturaperiodo_Click(object sender, EventArgs e)
        {
            comboasignaturaperiodo.BackColor = Color.White;
        }

        private void comboprofesorperiodo_Click(object sender, EventArgs e)
        {
            comboprofesorperiodo.BackColor = Color.White;
        }

        private void combocursoperiodo_Click(object sender, EventArgs e)
        {
            combocursoperiodo.BackColor = Color.White;
        }

        private void periodoperiodo_Click(object sender, EventArgs e)
        {
            periodoperiodo.BackColor = Color.White;
        }

        private void employeestate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void employeestate_Click(object sender, EventArgs e)
        {
            employeestate.BackColor = Color.White;
        }

        private void estudentstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            estudentstate.BackColor = Color.White;
        }

        private void newperiodotext_Click(object sender, EventArgs e)
        {
            periodoperiodo.BackColor = Color.White;
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            getmonth(monthbox);
            namebox.Text = "";
            profesorcombo.Text = "";
            pictureinicio.Hide();
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT `NOMBRE` , ENERO , FEBRERO , MARZO , ABRIL ,MAYO , JUNIO ,JULIO ,AGOSTO ,SEPTIEMBRE ,OCTUBRE , NOVIEMBRE ,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' ;";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";

                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

            }
        }

        private void searchbutton_Click_2(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                                      
                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    /////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE  CURSO='" + combocurso.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS")) {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == ""&& (studentstates.Text == "" || studentstates.Text == "TODOS")) {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table`;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    

                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND  ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();

                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ///////////////////////////////////////////////// 
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////
                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")) {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS")) {

                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == ""&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    
                    else if (namebox.Text == ""&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& namebox.Text == ""&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////
                                        
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                                        
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == ""&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS")&& namebox.Text == ""&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {

                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((namebox.Text == "")&& (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")&& (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS")&& (namebox.Text == ""))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == ""&& (studentstates.Text == "" || studentstates.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS")&& (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == ""&& (studentstates.Text == "" || studentstates.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS")&& (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////

                    
                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {

                    if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";

                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (combocurso.Text == "" || combocurso.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (comboasignatura.Text == "" || comboasignatura.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (profesorcombo.Text == "" || profesorcombo.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND  ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (studentstates.Text == "" || studentstates.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ///////////////////////////////////////////////// 
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "'  AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if ((comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "' AND NOMBRE='" + namebox.Text + "' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////


                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE CURSO='" + combocurso.Text + "'  AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ASIGNATURA='" + comboasignatura.Text + "' AND ASIGNADO='" + profesorcombo.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    ////////////////////////////////////////////////////////

                    if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ASIGNADO='" + profesorcombo.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////
                    else if ((combocurso.Text == "" || combocurso.Text == "TODOS") && namebox.Text == "" && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    ////////////////////////////////////////////////////////

                    else if ((namebox.Text == "") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (studentstates.Text == "" || studentstates.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' AND CURSO='" + combocurso.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////
                    else if ((periodobox.Text == "" || periodobox.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (namebox.Text == ""))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO='" + studentstates.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    //////////////////////////////////////////////////////////


                    else if (namebox.Text == "" && (studentstates.Text == "" || studentstates.Text == "TODOS") && (profesorcombo.Text == "" || profesorcombo.Text == "TODOS") && (comboasignatura.Text == "" || comboasignatura.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS") && (combocurso.Text == "" || combocurso.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    //////////////////////////////////////////////////////////
                    
                }

            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    
                    if (employeestatee.Text == "" || employeestatee.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (periodobox.Text == "" || periodobox.Text == "TODOS")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + employeestatee.Text + "';";

                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "")
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {

                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS") && (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    

                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {

                    if (employeestatee.Text == "" || employeestatee.Text == "TODOS") {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND NOMBRE LIKE '%" + namebox.Text + "%';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (periodobox.Text == "" || periodobox.Text == "TODOS") {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE  NOMBRE LIKE '%" + namebox.Text + "%' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "") {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (periodobox.Text == "" || periodobox.Text == "TODOS")) {

                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE AND ESTADO='" + employeestatee.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS")) {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE PERIODO='" + periodobox.Text + "' ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }
                    else if (namebox.Text == "" && (employeestatee.Text == "" || employeestatee.Text == "TODOS")&& (periodobox.Text == "" || periodobox.Text == "TODOS"))
                    {
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` ;";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();
                    }

                    

                }

            }
        }

        private void pictureperiodstate_Click(object sender, EventArgs e)
        {

        }

        private void employeestatee_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_employee_table` WHERE ESTADO = '" + employeestatee.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {

                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_employee_table` WHERE ESTADO = '" + employeestatee.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
            }
        }

        private void studentstates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE ESTADO = '" + studentstates.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO = '" + studentstates.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE, CURSO, PROFESOR, PERIODO, `FIN DE PERIODO`,COMPLETIVO,EXTRAORDINARIO,ESPECIAL,ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE ESTADO = '" + studentstates.Text + "' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }

            }
            
        }

        private void findinggrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (findinggrid.Enabled == false)
            {

                MessageBox.Show("PRIMERO TIENE QUE SELECCIONAR EL PERIODO");
                periodoiniciolabel.ForeColor = Color.Red;
            }
            else {
                periodoiniciolabel.ForeColor = Color.Black;
            }
        }

        private void periodobox_Click(object sender, EventArgs e)
        {
            periodoiniciolabel.ForeColor = Color.Black;
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%"+namebox.Text+ "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';"; 
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
               

                }

            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {

                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }

            }
        }

        private void namebox_TextUpdate(object sender, EventArgs e)
        {
            if (papel == "estudiante")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();
                }
                else if (DireccionGestor.getorigen() == "inicio calificar estudiante")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }

                else if (DireccionGestor.getorigen() == "inicio evaluar estudiante")
                {
                    
                        LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        orden = "SELECT NOMBRE,`FIN DE PERIODO`, COMPLETIVO, `EXTRA ORDINARIO` , ESPECIAL, ESTADO FROM `" + UserAccessForm.getusername() + "_calification_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                        ev.ShowDataGridFound(findinggrid, orden);
                        encontradoslabel.Text = ev.getcuenta().ToString();


                    


                }

            }
            else if (papel == "empleado")
            {

                if (DireccionGestor.getorigen() == "inicio asistencia empleado")
                {
                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }
                else if (DireccionGestor.getorigen() == "inicio calificar empleado")
                {

                    LoginClass ev = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "SELECT NOMBRE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE FROM `" + UserAccessForm.getusername() + "_asistance_student_table` WHERE NOMBRE LIKE '%" + namebox.Text + "%' AND PERIODO='" + periodobox.Text + "';";
                    ev.ShowDataGridFound(findinggrid, orden);
                    encontradoslabel.Text = ev.getcuenta().ToString();

                }

            }

        }

        private void scoretext_Click(object sender, EventArgs e)
        {
            scoretext.BackColor = Color.White;
        }

        private void asignaturacombocalificar_Click(object sender, EventArgs e)
        {
            asignaturacombocalificar.BackColor = Color.White;
        }

        private void mescombocalificar_Click(object sender, EventArgs e)
        {
            mescombocalificar.BackColor = Color.White;
        }

        private void periodocombocalificar_Click(object sender, EventArgs e)
        {
            periodocombocalificar.BackColor = Color.White;
        }

        private void combocalificarcurso_Click(object sender, EventArgs e)
        {
            combocalificarcurso.BackColor = Color.White;
        }

        private void profesorcombocalificar_Click(object sender, EventArgs e)
        {
            profesorcombocalificar.BackColor = Color.White;
        }

        private string modo;

        private void modificarbutton_Click(object sender, EventArgs e)
        {
            modo = "editar";
            


        }

        private void chargeperiodbutton_Click(object sender, EventArgs e)
        {
            StudentsClass adv = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (addperiodlabel.Text == "EDITAR PERIODO") {

                if (nomperiodo.Text==adv.getback("PERIODO","SELECT PERIODO FROM "+UserAccessForm.getusername()+" WHERE PERIODO ='"+nomperiodo.Text+"' ;") ) {

                    MessageBox.Show("EL PERIODO "+nomperiodo.Text+" ESTA EN LISTA CON "+mesperiodo.Text+" MESES");
                }
                else {
                    adv = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    adv.editperiod(nomperiodo.Text, int.Parse(mesperiodo.Text), UserAccessForm.getusername(), periodoperiodo.Text);
                    orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_period_table;";
                    adv.Fillcombo(periodobox, orden);
                    adv.Fillcombo(periodoperiodo, orden);
                    MessageBox.Show("PERIODO " + nomperiodo.Text + " EDITADO");
                }
            }
            else if (addperiodlabel.Text == "AGREGAR PERIODO") {

                if (nomperiodo.Text == adv.getback("PERIODO", "SELECT PERIODO FROM " + UserAccessForm.getusername() + " WHERE PERIODO ='" + nomperiodo.Text + "' ;"))
                {

                    MessageBox.Show("EL PERIODO " + nomperiodo.Text + " ESTA EN LISTA CON " + mesperiodo.Text + " MESES");
                }
                else
                {
                    adv = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    adv.addperiod(nomperiodo.Text, int.Parse(mesperiodo.Text), UserAccessForm.getusername());
                    orden = "SELECT DISTINCT PERIODO FROM " + UserAccessForm.getusername() + "_period_table;";
                    adv.Fillcombo(periodobox, orden);
                    adv.Fillcombo(periodoperiodo, orden);
                    MessageBox.Show("PERIODO " + nomperiodo.Text + " EDITADO");
                }
            }
            nomperiodo.Text = "";
            mesperiodo.Text = "";
            panelperiodo.Hide();
                    
        }

       

        private void addperiodlabel_Click(object sender, EventArgs e)
        {
            

            if (addperiodlabel.Text=="AGREGAR PERIODO") {

                panelperiodo.Show();
                newperiodolabel.Text = "NUEVO PERIODO";
                chargeperiodbutton.Text = "AGREGAR";
                
            }
            else if (addperiodlabel.Text == "EDITAR PERIODO")
            {
                panelperiodo.Show();
                newperiodolabel.Text = "EDITAR PERIODO";
                chargeperiodbutton.Text = "EDITAR";
                nomperiodo.Text = periodoperiodo.Text;
                StudentsClass adv = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                mesperiodo.Text=adv.getback("MESES","SELECT MESES FROM "+UserAccessForm.getusername()+ "_period_table WHERE PERIODO='"+periodoperiodo.Text+"';");

            }
        }

        private void periodoperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

                if (periodoperiodo.Text != "")
                {
                    addperiodlabel.Text = "EDITAR PERIODO";
                }
                else if (periodoperiodo.Text == ""){

                    addperiodlabel.Text = "AGREGAR PERIODO";
                }
            
           
        }

        private void label18_Click(object sender, EventArgs e)
        {
            panelperiodo.Hide();
            nomperiodo.Text = "";
            mesperiodo.Text = "";

        }
    }
    }

