using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Media;

namespace DireccionLib
{
    public partial class StudentForm : Form
    {
            
        //private string origen = "ninguno";

        public StudentForm()
        {
            InitializeComponent();
            parentescobox.Text = "MADRE";
            string userDataName = UserAccessForm.getusername() + "_student_table";
            StudentsClass show = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            //declaradocombo.Text = "SI";
            actapanel.Show();
            picturetextbox.Hide();
            //delabel.Hide();
            //declaradocombo.Hide();
            //gardas.Hide();


            


            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Normal;
            menu.Show();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio")
            {
                StudentsClass studentobject = new StudentsClass();
                DireccionGestor menu = new DireccionGestor();
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
            }
            else {
                StudentsClass studentobject = new StudentsClass();
                StudentFormSearch buscar = new StudentFormSearch();
                buscar.WindowState = FormWindowState.Maximized;
                buscar.Show();
            }
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
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;






        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            StudentsClass studentobject = new StudentsClass();
            ageBox.Text = "";
            gradebox.Text = "";
            nroActaBox.Text = "";
            proviciabox.Text = "";
            municipiobox.Text = "";
            oficialiacomboBox.Text = "";
            libro.Text = "";
            folio.Text = "";
            comboAño.Text = "";
            actapanel.Show();

            EmpresaBox.Text = "";
            EmpresaTelefonoBox.Text = "";
            jobpanel.Show();

            sindromenameBox.Text = "";
            sindromepanel.Show();

            medicinenameBox.Text = "";
            reasonmedicineBox.Text = "";
            medicinePanel.Show();

            schedule.Text = "";
            addressBox.Text = "";
            C.Text = "";
            telefonoBox.Text = "";
            ageBox.Text = "";
            

            pictureBox.ImageLocation = "";
            dateTimegetin.Text = DateTime.Now.ToString();
            salidapicker.Text= DateTime.Now.ToString();
            birthdatePicker.Text = DateTime.Now.ToString();



        }
        


        private void comboNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "editor") {

                if (comboNacionalidad.Text == "DOMINICANA")
                {
                    declaradocombo.Show();
                    declaradocombo.Enabled = true;
                    declaradocombo.Text = "SI";
                    delabel.Show();
                    
                    nroacta.Text = "";
                    nroacta.Enabled = true;
                    
                    provincia.Text = "";
                    provincia.Enabled = true;
                    municipio.Text = "";
                    municipio.Enabled = true;
                    oficialia.Text = "";
                    oficialia.Enabled = true;
                    llibro.Text = "";
                    llibro.Enabled = true;
                    ffolio.Text = "";
                    ffolio.Enabled = true;
                    anio.Text = "";
                    anio.Enabled = true;
                    actapanel.Hide();

                }
                else {

                    nroacta.Text = "NINGUNA";
                    nroacta.Enabled = false;
                    
                    provincia.Text = "NINGUNA";
                    provincia.Enabled = false;
                    municipio.Text = "NINGUNA";
                    municipio.Enabled = false;
                    oficialia.Text = "NINGUNA";
                    oficialia.Enabled = false;
                    llibro.Text = "NINGUNA";
                    llibro.Enabled = false;
                    ffolio.Text = "NINGUNA";
                    ffolio.Enabled = false;
                    anio.Text = "0000";
                    anio.Enabled = false;
                    actapanel.Hide();
                }
                

            }
            else {
                nacionalitytutorbox.Text = comboNacionalidad.Text;

                if (comboNacionalidad.Text != "DOMINICANA")
                {
                    declaradocombo.Hide();
                    delabel.Hide();
                    actapanel.Hide();
                    declaradocombo.Text = "NO";

                    nroActaBox.Text = "NINGUNA";
                    proviciabox.Text = "NINGUNA";
                    municipiobox.Text = "NINGUNA";
                    oficialiacomboBox.Text = "NINGUNA";
                    libro.Text = "NINGUNA";
                    folio.Text = "NINGUNA";
                    comboAño.Text = "0000";
                    actapanel.Hide();
                }
                else {
                    declaradocombo.Show();
                    delabel.Show();
                    actapanel.Show();
                    declaradocombo.Text = "SI";

                    nroActaBox.Text = "";
                    proviciabox.Text = "";
                    municipiobox.Text = "";
                    oficialiacomboBox.Text = "";
                    libro.Text = "";
                    folio.Text = "";
                    comboAño.Text = "";
                    
                }

                comboNacionalidad.BackColor = Color.White;
                
            }
        }

        private void schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            schedule.BackColor = Color.White;
        }

        private void birthdatePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                

                
                    ageBox.Text = (DateTime.Today.AddTicks(-birthdatePicker.Value.Ticks).Year - 1).ToString();
                    agetextBox.Text = (DateTime.Today.AddTicks(-birthdatePicker.Value.Ticks).Year - 1).ToString();
                //int numero = int.Parse(ageBox.Text);
                switch (ageBox.Text)
                {

                    case "1":
                        gradebox.Text = "CUIDO";
                        break;
                    case "2":
                        gradebox.Text = "PARVULOS - INICIAL";
                        break;
                    case "3":
                        gradebox.Text = "PRE-KINDER - INICIAL";
                        break;
                    case "4":
                        gradebox.Text = "KINDER - INICIAL";
                        break;
                    case "5":
                        gradebox.Text = "PRE-PRIMARIO - INICIAL";
                        break;
                    case "6":
                        gradebox.Text = "1RO - BASICA";
                        break;
                    case "7":
                        gradebox.Text = "2DO - BASICA";
                        break;
                    case "8":
                        gradebox.Text = "3RO - BASICA";
                        break;
                    case "9":
                        gradebox.Text = "4TO - BASICA";
                        break;
                    case "10":
                        gradebox.Text = "5TO - BASICA";
                        break;
                    case "11":
                        gradebox.Text = "6T0 - BASICA";
                        break;
                    case "12":
                        gradebox.Text = "1RO - BACHILLERATO";
                        break;
                    case "13":
                        gradebox.Text = "2DO - BACHILLERATO";
                        break;
                    case "14":
                        gradebox.Text = "3RO - BACHILLERATO";
                        break;
                    case "15":
                        gradebox.Text = "4TO - BACHILLERATO";
                        break;
                    case "16":
                        gradebox.Text = "5TO - BACHILLERATO";
                        break;
                    case "17":
                        gradebox.Text = "6TO - BACHILLERATO";
                        break;
                    default:
                        gradebox.Text = "CUIDO";
                        break;


                }

            
            }
            catch (ArgumentOutOfRangeException negativeage)
            {
                MessageBox.Show("Estudiante aun no ha nacido");
                negativeage.ToString();
            }
        }

        private void sexBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sexBox.BackColor = Color.White;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            C.BackColor = Color.White;
        }

        private void ageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ageBox.BackColor = Color.White;
        }

        private void telefonoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            telefonoBox.BackColor = Color.White;
        }

        private void addressBox_TextChanged(object sender, EventArgs e)
        {
            addressBox.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void savebuttonstrip_Click(object sender, EventArgs e)
        {
            carga man = new carga();

            if (savebuttonstrip.Text == "GUARDAR")
            {
                
                man.WindowState = FormWindowState.Normal;
                if (C.Text == "" || schedule.Text == "" || dateTimegetin.Text == "" || comboNacionalidad.Text == "" || nroActaBox.Text == "" || proviciabox.Text == "" || municipiobox.Text == "" || oficialiacomboBox.Text == "" || libro.Text == "" || folio.Text == "" || comboAño.Text == "" || birthdatePicker.Text == "" || sexBox.Text == "" || telefonoBox.Text == "" || addressBox.Text == "" || gradebox.Text == "" || nombreAlergyBox.Text == "" || medicinenameBox.Text == "" || reasonmedicineBox.Text == "" || sindromenameBox.Text == "" || tutornamebox.Text == "" || idtutorbox.Text == "" || mensualidadBox.Text == "" || EmpresaBox.Text == "" || EmpresaTelefonoBox.Text == ""|| emailcombo.Text=="")
                {
                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");
                    if (C.Text == "") { C.BackColor = Color.Red; }
                    else { C.BackColor = Color.Green; }

                    if (schedule.Text == "") { schedule.BackColor = Color.Red; }
                    else { schedule.BackColor = Color.Green; }

                    if (dateTimegetin.Text == "") { dateTimegetin.BackColor = Color.Red; }
                    else { dateTimegetin.BackColor = Color.Green; }

                    if (comboNacionalidad.Text == "") { comboNacionalidad.BackColor = Color.Red; }
                    else { comboNacionalidad.BackColor = Color.Green; }

                    if (nroActaBox.Text == "") { nroActaBox.BackColor = Color.Red; }
                    else { nroActaBox.BackColor = Color.Green; }

                    if (proviciabox.Text == "") { proviciabox.BackColor = Color.Red; }
                    else { proviciabox.BackColor = Color.Green; }

                    if (municipiobox.Text == "") { municipiobox.BackColor = Color.Red; }
                    else { municipiobox.BackColor = Color.Green; }

                    if (libro.Text == "") { libro.BackColor = Color.Red; }
                    else { libro.BackColor = Color.Green; }

                    if (folio.Text == "") { folio.BackColor = Color.Red; }
                    else { folio.BackColor = Color.Green; }

                    if (comboAño.Text == "") { comboAño.BackColor = Color.Red; }
                    else { comboAño.BackColor = Color.Green; }

                    if (birthdatePicker.Text == "") { birthdatePicker.BackColor = Color.Red; }
                    else { birthdatePicker.BackColor = Color.Green; }

                    if (sexBox.Text == "") { sexBox.BackColor = Color.Red; }
                    else { sexBox.BackColor = Color.Green; }

                    if (telefonoBox.Text == "") { telefonoBox.BackColor = Color.Red; }
                    else { telefonoBox.BackColor = Color.Green; }

                    if (addressBox.Text == "") { addressBox.BackColor = Color.Red; }
                    else { addressBox.BackColor = Color.Green; }

                    if (gradebox.Text == "") { gradebox.BackColor = Color.Red; }
                    else { gradebox.BackColor = Color.Green; }

                    if (nombreAlergyBox.Text == "") { nombreAlergyBox.BackColor = Color.Red; }
                    else { nombreAlergyBox.BackColor = Color.Green; }

                    if (medicinenameBox.Text == "") { medicinenameBox.BackColor = Color.Red; }
                    else { medicinenameBox.BackColor = Color.Green; }

                    if (reasonmedicineBox.Text == "") { reasonmedicineBox.BackColor = Color.Red; }
                    else { reasonmedicineBox.BackColor = Color.Green; }

                    if (sindromenameBox.Text == "") { sindromenameBox.BackColor = Color.Red; }
                    else { sindromenameBox.BackColor = Color.Green; }

                    if (tutornamebox.Text == "") { tutornamebox.BackColor = Color.Red; }
                    else { tutornamebox.BackColor = Color.Green; }

                    if (idtutorbox.Text == "") { idtutorbox.BackColor = Color.Red; }
                    else { idtutorbox.BackColor = Color.Green; }

                    if (mensualidadBox.Text == "") { mensualidadBox.BackColor = Color.Red; }
                    else { mensualidadBox.BackColor = Color.Green; }

                    if (EmpresaBox.Text == "") { EmpresaBox.BackColor = Color.Red; }
                    else { EmpresaBox.BackColor = Color.Green; }

                    if (EmpresaTelefonoBox.Text == "") { EmpresaTelefonoBox.BackColor = Color.Red; }
                    else { EmpresaTelefonoBox.BackColor = Color.Green; }


                    if (oficialiacomboBox.Text == "") { oficialiacomboBox.BackColor = Color.Red; }
                    else { oficialiacomboBox.BackColor = Color.Green; }


                    if (ageBox.Text == "") { ageBox.BackColor = Color.Red; }
                    else { ageBox.BackColor = Color.Green; }

                    if (nacionalitytutorbox.Text == "") { nacionalitytutorbox.BackColor = Color.Red; }
                    else { nacionalitytutorbox.BackColor = Color.Green; }

                    if (emailcombo.Text=="") { emailcombo.Text="NINGUNA"; }
                }
                else
                {

                    try
                    {
                        string userDataName = UserAccessForm.getusername() + "_student_table";
                        StudentsClass save = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        int year = int.Parse(comboAño.Text);
                        int age = int.Parse(ageBox.Text);
                        double mensuality = double.Parse(mensualidadBox.Text);
                        DateTime birthdate = Convert.ToDateTime(birthdatePicker.Value.Date);
                        DateTime timegetin = Convert.ToDateTime(dateTimegetin.Value.ToShortTimeString());



                        if (mensualidadBox.BackColor == Color.Red)
                        {
                            MessageBox.Show("Arregle el campo no valido");
                        }
                        else
                        {

                            if (save.NameNoCopied(C.Text, userDataName) == true)
                            {
                                MessageBox.Show("El estudiante " + C.Text + " ya existe");

                                if (MessageBox.Show("Agregar a otro estudiante?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    save = new StudentsClass();

                                    DireccionGestor menu = new DireccionGestor();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                    this.Close();
                                }

                                else
                                {
                                    save = new StudentsClass();

                                    StudentForm menu = new StudentForm();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                    this.Close();
                                }

                            }
                            else
                            {


                                if (C.Text == "" || schedule.Text == "" || dateTimegetin.Text == "" || comboNacionalidad.Text == "" || nroActaBox.Text == "" || proviciabox.Text == "" || municipiobox.Text == "" || oficialiacomboBox.Text == "" || libro.Text == "" || folio.Text == "" || comboAño.Text == "" || birthdatePicker.Text == "" || sexBox.Text == "" || telefonoBox.Text == "" || addressBox.Text == "" || gradebox.Text == "" || nombreAlergyBox.Text == "" || medicinenameBox.Text == "" || reasonmedicineBox.Text == "" || sindromenameBox.Text == "" || tutornamebox.Text == "" || idtutorbox.Text == "" || mensualidadBox.Text == "" || EmpresaBox.Text == "" || EmpresaTelefonoBox.Text == "")
                                {

                                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");


                                }

                                else
                                {
                                    //inicia


                                    string date = birthdatePicker.Value.Day.ToString()+"/"+birthdatePicker.Value.Month.ToString()+"/"+ birthdatePicker.Value.Year.ToString();
                                    string evento = birthdatePicker.Value.Day.ToString() + "/" + birthdatePicker.Value.Month.ToString();

                                    AgendaClass addevent = new AgendaClass();
                                    string eventoname = "CUMPLEAÑOS DE " + C.Text;
                                    addevent.saveData(UserAccessForm.getusername(), eventoname, 1, date, "7:20:0", "NO", "NO", "NO", "NO", "NO", "NO", "NO", evento, "SI","");

                                    LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                                    add.AddContact(C.Text, telefonoBox.Text, addressBox.Text, emailcombo.Text, UserAccessForm.getusername().ToString());

                                    if (save.SaveData(userDataName, schedule.Text, nroActaBox.Text, proviciabox.Text, municipiobox.Text, oficialiacomboBox.Text, libro.Text, folio.Text, year, birthdatePicker, sexBox.Text, C.Text, age, telefonoBox.Text, addressBox.Text, tutornamebox.Text, idtutorbox.Text, comboNacionalidad.Text, addressBox.Text, telefonoBox.Text, telefonoBox.Text, EmpresaBox.Text, EmpresaTelefonoBox.Text, nombreAlergyBox.Text, medicinenameBox.Text, reasonmedicineBox.Text, telefonoBox.Text, sindromenameBox.Text, mensuality, rutafoto, gradebox.Text, addressBox.Text,nacionalitytutorbox.Text, dateTimegetin, tipomoneda.Text, parentescobox.Text, emailcombo.Text) == true)
                                    {
                                        man.Close();
                                        save.OrderID(userDataName);
                                        MessageBox.Show("NUEVO ESTUDIANTE " + C.Text + " HA SIDO INSCRITO.");

                                        if (MessageBox.Show("Agregar a otro estudiante?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {

                                            save = new StudentsClass();
                                            if (DireccionGestor.getorigen() == "inicio")
                                            {
                                                StudentsClass studentobject = new StudentsClass();
                                                DireccionGestor menu = new DireccionGestor();
                                                menu.WindowState = FormWindowState.Maximized;
                                                menu.Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                StudentsClass studentobject = new StudentsClass();
                                                StudentFormSearch buscar = new StudentFormSearch();
                                                buscar.WindowState = FormWindowState.Maximized;
                                                buscar.Show();
                                                this.Close();
                                            }

                                        }
                                        else
                                        {
                                            save = new StudentsClass();

                                            StudentForm menu = new StudentForm();
                                            menu.WindowState = FormWindowState.Normal;
                                            menu.Show();
                                            this.Close();




                                        }
                                    }
                                    else
                                    {
                                        man.Close();
                                        MessageBox.Show("NUEVO ESTUDIANTE " + C.Text + " HA SIDO INSCRITO.");
                                        if (MessageBox.Show("Agregar a otro estudiante?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {

                                            save = new StudentsClass();
                                            if (DireccionGestor.getorigen() == "inicio")
                                            {
                                                StudentsClass studentobject = new StudentsClass();
                                                DireccionGestor menu = new DireccionGestor();
                                                menu.WindowState = FormWindowState.Maximized;
                                                menu.Show();
                                                this.Close();
                                            }
                                            else
                                            {
                                                StudentsClass studentobject = new StudentsClass();
                                                StudentFormSearch buscar = new StudentFormSearch();
                                                buscar.WindowState = FormWindowState.Maximized;
                                                buscar.Show();
                                                this.Close();
                                            }



                                        }
                                        else
                                        {
                                            save = new StudentsClass();

                                            StudentForm menu = new StudentForm();
                                            menu.WindowState = FormWindowState.Normal;
                                            menu.Show();
                                            this.Close();
                                        }
                                    }
                                }
                            }


                        }
                    }




                    catch (FormatException datethis) { datethis.ToString(); }

                }


            } else if (savebuttonstrip.Text == "MODIFICAR") {

                man.WindowState = FormWindowState.Normal;

                try
                {

                    string userDataName = UserAccessForm.getusername() + "_student_table";
                    StudentsClass save = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    AgendaClass addevent = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    LoginClass addcontact = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    //string eventoname = "CUMPLEAÑOS DE " + C.Text;
                    int year = int.Parse(anio.Text);
                    int age = int.Parse(ageBox.Text);
                    double mensuality = double.Parse(mensualidadBox.Text);
                    


                    

                        
                    string nameevent = "CUMPLEAÑOS DE " + C.Text;
                    string date= birthdatePicker.Value.Day.ToString()+"/"+birthdatePicker.Value.Month.ToString()+"/"+birthdatePicker.Value.Year.ToString();
                    string momentdate = birthdatePicker.Value.Day.ToString() + "/" + birthdatePicker.Value.Month.ToString();
                    save.ModifyData(userDataName, DireccionGestor.getnombrestatic(), schedule.Text, nroacta.Text, provincia.Text, municipio.Text, oficialia.Text, llibro.Text, ffolio.Text, int.Parse(anio.Text), birthdatePicker, sexBox.Text, C.Text, int.Parse( agetextBox.Text), telefonoBox.Text, addressBox.Text, tutornamebox.Text, idtutorbox.Text, nacionalitytutorbox.Text, telefonoBox.Text,empresa.Text, telefono.Text, alergianombre.Text, meddicamentonombre.Text, medicamentomotivo.Text, sindromenombre.Text, double.Parse(mensualidadBox.Text), picturetextbox.Text, gradebox.Text, addressBox.Text, nacionalitytutorbox.Text, dateTimegetin, inscritobox.Text, salidapicker, tipomoneda.Text, parentescobox.Text,emailcombo.Text);

                    man.Close();

                    addevent.modifydata(UserAccessForm.getusername(),DireccionGestor.getnombrestatic(), nameevent,1,date, "7:20:0", "NO", "NO", "NO", "NO", "NO", "NO", "NO", momentdate, "SI");
                    addcontact.editContact(C.Text,telefono.Text,addressBox.Text,emailcombo.Text,DireccionGestor.getnombrestatic(),UserAccessForm.getusername());
                    MessageBox.Show("El estudiante "+C.Text+" ha sido modificado");



                    StudentsClass studentobject = new StudentsClass();
                    StudentFormSearch buscar = new StudentFormSearch();
                    buscar.WindowState = FormWindowState.Maximized;
                    buscar.Show();
                    this.Close();




                }
                catch (FormatException datethis) { datethis.ToString(); }


            }

                
        } 

        private void StudentForm_Load(object sender, EventArgs e)
        {
            StudentsClass student = new StudentsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden;
            orden = "SELECT distinct `NOMBRE DE ALERGIA` FROM " + UserAccessForm.getusername()+"_student_table;";
            student.Fillcombo(nombreAlergyBox, orden);
            student.Fillcombo(alergianombre, orden);
            orden = "SELECT distinct `NOMBRE DE MEDICINA` FROM " + UserAccessForm.getusername() +"_student_table;";
            student.Fillcombo(medicinenameBox, orden);
            student.Fillcombo(meddicamentonombre, orden);
            orden = "SELECT distinct `RAZON DE MEDICINA` FROM " + UserAccessForm.getusername() + "_student_table;";
            student.Fillcombo(reasonmedicineBox, orden);
            student.Fillcombo(medicamentomotivo, orden);
            orden = "SELECT distinct `SINDROME` FROM " + UserAccessForm.getusername() + "_student_table;";
            student.Fillcombo(sindromenameBox, orden);
            student.Fillcombo(sindromenombre, orden);
            orden = "SELECT distinct `NOMBRE DE EMPRESA` FROM " + UserAccessForm.getusername() + "_student_table;";
            student.Fillcombo(EmpresaBox, orden);
            student.Fillcombo(empresa, orden);
            orden = "SELECT distinct `TELEFONO DE EMPRESA` FROM " + UserAccessForm.getusername() + "_student_table;";
            student.Fillcombo(EmpresaTelefonoBox, orden);
            student.Fillcombo(telefono, orden);




            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (DireccionGestor.getorigen()=="inicio" || DireccionGestor.getorigen() == "") {
                tipomoneda.Text = "DOP";

            }
            
            if (DireccionGestor.getorigen() == "editor")
            {


                ageBox.Hide();
                agetextBox.Show();
                picturecover1.Hide();
                picturecover2.Hide();
                

                savebuttonstrip.Text = "MODIFICAR";
                titleestudiante.Text = "EDITAR ESTUDIANTE";               

                l1.Show();
                l2.Show();
                l3.Show();
                l4.Show();
                l5.Show();
                l6.Show();
                nroacta.Show();
                ffolio.Show();
                llibro.Show();
                provincia.Show();
                municipio.Show();
                anio.Show();
                oficialia.Show();

                aboutpanel.Hide();
                ll1.Show();
                ll2.Show();
                ll3.Show();
                ll4.Show();
                ll5.Show();
                ll6.Show();
                ll7.Show();
                alergianombre.Show();
                meddicamentonombre.Show();
                medicamentomotivo.Show();
                sindromenombre.Show();


                delabel.Hide();
                declaradocombo.Hide();
                actapanel.Hide();

                tralabel.Hide();
                trabajacombo.Hide();
                jobpanel.Hide();
                lll1.Show();
                lll2.Show();
                empresa.Show();
                telefono.Show();
                student.filleverything(schedule, dateTimegetin, comboNacionalidad,  nroacta, provincia, municipio, oficialia, llibro, ffolio, anio,  birthdatePicker, sexBox,  C, agetextBox, telefonoBox, addressBox, gradebox, alergianombre, meddicamentonombre, medicamentomotivo, sindromenombre, tutornamebox, idtutorbox, nacionalitytutorbox, mensualidadBox, empresa, telefono, inscritobox,picturetextbox,tipomoneda, parentescobox,emailcombo, DireccionGestor.getordensql());

                ageBox.Text = DireccionGestor.getedadestatic().ToString();

                


                //inscritopanel.Hide();
                if ((comboNacionalidad.Text == "DOMINICANA") && (nroacta.Text != "" || provincia.Text != "" || municipio.Text != "" || oficialia.Text != "" || llibro.Text != "" || ffolio.Text != "" || anio.Text != "" || anio.Text != "0"))
                {
                    delabel.Show();
                    declaradocombo.Show();
                    declaradocombo.Text = "SI";
                    declaradocombo.Enabled = true;
                    picturecover1.Hide();
                }
                else if ((comboNacionalidad.Text == "DOMINICANA") && (nroacta.Text == "NINGUNA" && provincia.Text == "NINGUNA" && municipio.Text == "NINGUNA" && oficialia.Text == "NINGUNA" && llibro.Text == "NINGUNA" && ffolio.Text == "NINGUNA" && anio.Text == "NINGUNA" && anio.Text == "0"))
                {
                    delabel.Show();
                    declaradocombo.Show();
                    declaradocombo.Text = "NO";
                    declaradocombo.Enabled = true;
                    picturecover1.Hide();

                }else if ((comboNacionalidad.Text == "DOMINICANA") && (nroacta.Text != "NINGUNA" && provincia.Text != "NINGUNA" && municipio.Text != "NINGUNA" && oficialia.Text != "NINGUNA" && llibro.Text != "NINGUNA" && ffolio.Text != "NINGUNA" && anio.Text == "NINGUNA" && anio.Text == "0"))
                {
                    delabel.Show();
                    declaradocombo.Show();
                    declaradocombo.Text = "NO";
                    declaradocombo.Enabled = true;
                    picturecover1.Hide();

                }

                else
                {
                    delabel.Hide();
                    declaradocombo.Hide();
                    declaradocombo.Text = "NO";
                    declaradocombo.Enabled = false;
                    picturecover1.Show();


                }






                
                if (picturetextbox.Text != "")
                {

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                    string fotopath = System.IO.Path.Combine(combinacion,picturetextbox.Text);
                    pictureBox.ImageLocation = fotopath;
                }


                
                                
            }
            else {
                picturecover1.Show();
                picturecover2.Show();
                savebuttonstrip.Text = "GUARDAR";
                titleestudiante.Text = "AGREGAR ESTUDIANTE";
                inscritopanel.Hide();
                trabajacombo.Text = "SI";
                sindromeespecialcombo.Text = "SI";
                alergycombo.Text = "SI";
                medicamentosespecialescombo.Text = "SI";
                declaradocombo.Text = "SI";

                ageBox.Show();
                agetextBox.Hide();

            }
        }

        private string rutafoto;
        private void picturebutton_Click(object sender, EventArgs e)
        {
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
                string sourcefile= getfile.FileName;
                string destfile = System.IO.Path.Combine(path,picturetextbox.Text);

                pictureBox.Image = Image.FromFile(getfile.FileName);

              

                rutafoto = picturetextbox.Text;

                
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                       
               
                    if (getfile.CheckFileExists) {
                    

                    }
                try
                {
                    System.IO.File.Copy(sourcefile, sourcefile, true);
                }
                catch (System.IO.IOException getto) {

                   
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
                        try {
                            System.IO.File.Copy(s, destfile, true);
                        }
                        catch (System.IO.IOException exept) {

                            MessageBox.Show("TRATE DE SELECCIONAR OTRA FOTO");
                            //picturetextbox.Text = System.IO.Path.GetFileName(getfile.FileName);
                            exept.ToString();

                        }
                    }
                }
                
            }
            else
            {

                MessageBox.Show("No se ha seleccionado ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        private void cancelbuttonstrip_Click(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio")
            {
                StudentsClass studentobject = new StudentsClass();
                DireccionGestor menu = new DireccionGestor();
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
            }
            else
            {
                StudentsClass studentobject = new StudentsClass();
                StudentFormSearch buscar = new StudentFormSearch();
                buscar.WindowState = FormWindowState.Maximized;
                buscar.Show();
            }
            this.Close();
        }

        private void birthdatePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");

            }
        }

        private void mensualidadBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");

                if (Char.IsPunctuation(e.KeyChar)) { mensualidadBox.BackColor = Color.Green; }
                else { mensualidadBox.BackColor = Color.Red; }

            }
        }

        private void EmpresaTelefonoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Usa el Formato de telefono");

            }
           
        }

        private void idtutorbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Usa el Formato de cedula");

            }
        }

        private void telefonoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Usa el Formato de telefono");

            }
        }

        private void comboAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Es el año solamente");

            }
        }

        private void mensualidadBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mensualidadBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
            }

       }

        private void declaradocombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DireccionGestor.getorigen() == "editor") {

                if (declaradocombo.Text == "SI" || declaradocombo.Text == "si")
                {

                    picturecover1.Hide();
                    //actapanel.Show();
                }
                else
                {
                    actapanel.Hide();
                    nroActaBox.Text = "NINGUNA";
                    proviciabox.Text = "NINGUNA";
                    municipiobox.Text = "NINGUNA";
                    oficialiacomboBox.Text = "NINGUNA";
                    libro.Text = "NINGUNA";
                    folio.Text = "NINGUNA";
                    comboAño.Text = "0000";
                    picturecover1.Show();
                }



            } else { 


                if (declaradocombo.Text == "SI" || declaradocombo.Text=="si"){
                nroActaBox.Text = "";
                proviciabox.Text = "";
                municipiobox.Text = "";
                oficialiacomboBox.Text = "";
                libro.Text = "";
                folio.Text = "";
                comboAño.Text = "";
                    //gardas.Show();


                actapanel.Show();
            }else{
                actapanel.Hide();
                   
                nroActaBox.Text = "NINGUNA";
                proviciabox.Text = "NINGUNA";
                municipiobox.Text = "NINGUNA";
                oficialiacomboBox.Text = "NINGUNA";
                libro.Text = "NINGUNA";
                folio.Text = "NINGUNA";
                comboAño.Text = "0000";
            }
        }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void alergycombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "editor")
            {
                if (alergycombo.Text == "SI" || alergycombo.Text == "si")
                {

                    
                    alergypanel.Show();
                }
                else
                {
                    alergypanel.Hide();
                    nombreAlergyBox.Text = "NINGUNA";
                }

            }
            else { 
                if (alergycombo.Text=="SI"|| alergycombo.Text=="si")
            {

                nombreAlergyBox.Text = "";
                alergypanel.Show();
            }else
            {
                alergypanel.Hide();
                nombreAlergyBox.Text = "NINGUNA";
            }
        }
        }

        private void medicamentosespecialescombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "editor")
            {
                if (medicamentosespecialescombo.Text == "SI" || medicamentosespecialescombo.Text == "si")
                {

                    
                    medicinePanel.Show();
                }
                else
                {
                    medicinePanel.Hide();
                    medicinenameBox.Text = "NINGUNA";
                    reasonmedicineBox.Text = "NINGUNA";
                }

            }
            else { 

                if (medicamentosespecialescombo.Text=="SI" || medicamentosespecialescombo.Text=="si")
            {

                medicinenameBox.Text = "";
                reasonmedicineBox.Text = "";
                medicinePanel.Show();
            }else{
                medicinePanel.Hide();
                medicinenameBox.Text = "NINGUNA";
                reasonmedicineBox.Text = "NINGUNA";
            }
        }
        }

        private void sindromeespecialcombo_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DireccionGestor.getorigen() == "editor")
            {

                if (sindromeespecialcombo.Text == "SI" || sindromeespecialcombo.Text == "si")
                {
                    
                    sindromepanel.Show();
                }
                else
                {
                    sindromepanel.Hide();
                    sindromenameBox.Text = "NINGUNA";
                }


            }
            else { 

                if (sindromeespecialcombo.Text == "SI" || sindromeespecialcombo.Text == "si")
            {
                sindromenameBox.Text = "";
                sindromepanel.Show();
            }
            else
            {
                sindromepanel.Hide();
                sindromenameBox.Text = "NINGUNA";
            }
        }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void trabajacombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DireccionGestor.getorigen() == "editor") {

                if (trabajacombo.Text == "SI" || trabajacombo.Text == "si")
                {
                    jobpanel.Show();
                }
                else
                {
                    EmpresaBox.Text = "NINGUNA";
                    EmpresaTelefonoBox.Text = "NINGUNA";
                    jobpanel.Hide();


                }

            }
            else
            {
                if (trabajacombo.Text == "SI" || trabajacombo.Text == "si")
                {
                    EmpresaBox.Text = "";
                    EmpresaTelefonoBox.Text = "";
                    jobpanel.Show();
                }
                else
                {
                    EmpresaBox.Text = "NINGUNA";
                    EmpresaTelefonoBox.Text = "NINGUNA";
                    jobpanel.Hide();


                }
            }
        }

        private void mensualidadBox_TextChanged(object sender, EventArgs e)
        {
            mensualidadBox.BackColor = Color.White;
        }

        private void EmpresaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaBox.BackColor = Color.White;
        }

        private void nacionalitytutorbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nacionalitytutorbox.BackColor = Color.White;
        }

        private void nombreAlergyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreAlergyBox.BackColor = Color.White;
        }

        private void medicinenameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicinenameBox.BackColor = Color.White;
        }

        private void reasonmedicineBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            reasonmedicineBox.BackColor = Color.White;
        }

        private void sindromenameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sindromenameBox.BackColor = Color.White;
        }

        private void addressBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressBox.BackColor = Color.White;
        }

        private void gradebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gradebox.BackColor = Color.White;
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            C.BackColor = Color.White;
            
        }

        private void nroActaBox_TextChanged(object sender, EventArgs e)
        {
            nroActaBox.BackColor = Color.White;
        }

        private void libro_TextChanged(object sender, EventArgs e)
        {
            libro.BackColor = Color.White;
        }

        private void proviciabox_TextChanged(object sender, EventArgs e)
        {
            proviciabox.BackColor = Color.White;
        }

        private void folio_TextChanged(object sender, EventArgs e)
        {
            folio.BackColor = Color.White;
        }

        private void municipiobox_TextChanged(object sender, EventArgs e)
        {
            municipiobox.BackColor = Color.White;
        }

        private void comboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAño.BackColor = Color.White;
        }

        private void oficialiacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            oficialiacomboBox.BackColor = Color.White;
        }

        private void EmpresaTelefonoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimegetin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void jobpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void actaPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inscritobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inscritobox.Text == "SI")
            {
                salidapicker.Enabled = false;
                
            }
            else
            {
                salidapicker.Enabled = true;
            }
        }

        private void comboAño_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboAño_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
            }
        }

        private void comboAño_TextChanged(object sender, EventArgs e)
        {

        }

        private void C_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void inscritopanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void jobpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void aboutpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void actapanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
