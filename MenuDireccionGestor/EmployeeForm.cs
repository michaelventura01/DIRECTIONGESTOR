using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace DireccionLib
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            EmployeeClass employeeobj = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            employeeobj.FillNameBox(nameEmployeeBox, userDataName);
            employeeobj.FillAnothers(gottendegree, cargobox, AlergyNmaeBox, DolenciaNameBox, nameMedicineBox, MotivoMedicineBox, userDataName);
            medicamentosopcionbox.Text = "SI";
            referenciaopcionbox.Text = "SI";
            alergiaopcionbox.Text = "SI";
            dolenciaopcionbox.Text = "SI";
            picturetextbox.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "editor" || DireccionGestor.getorigen() == "buscador")
            {
                EmployeeFormSearch menu = new EmployeeFormSearch();
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                this.Hide();

            }
            else {
                DireccionGestor menu = new DireccionGestor();
                menu.WindowState = FormWindowState.Maximized;
                menu.Show();
                this.Hide();


            }

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

                MessageBox.Show(DireccionGestor.getnombrestatic().ToString());
            }

            cuenta++;
            if (cuenta == 4000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void alergybox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void yesbuttonalergy_Click(object sender, EventArgs e)
        {
            AlergyNmaeBox.Text = "";
            alergypanel.Show();

        }

        private void nobuttonalergy_Click(object sender, EventArgs e)
        {
            alergypanel.Hide();
            AlergyNmaeBox.Text = "NINGUNA";
        }

        private void yesbuttondolencia_Click(object sender, EventArgs e)
        {
            DolenciaNameBox.Text = "";
            dolenciapanel.Show();

        }

        private void nobuttondolencia_Click(object sender, EventArgs e)
        {
            dolenciapanel.Hide();
            DolenciaNameBox.Text = "NINGUNA";
        }

        private void yesbuttonmedicine_Click(object sender, EventArgs e)
        {
            MotivoMedicineBox.Text = "";
            nameMedicineBox.Text = "";
            medicinepanel.Show();
        }

        private void nobuttonmedicine_Click(object sender, EventArgs e)
        {
            medicinepanel.Hide();
            MotivoMedicineBox.Text = "NINGUNA";
            nameMedicineBox.Text = "NINGUNA";
        }

        private void yes_Click(object sender, EventArgs e)
        {
            relationReferenceBox.Text = "";
            telephoneReferenceBox.Text = "";
            personalReferenceBox.Text = "";
            referenciapanel.Show();
        }

        private void no_Click(object sender, EventArgs e)
        {
            referenciapanel.Hide();
            relationReferenceBox.Text = "NINGUNA";
            telephoneReferenceBox.Text = "NINGUNA";
            personalReferenceBox.Text = "NINGUNA";

        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            ageBox.Text = "";
            gottendegree.Text = "";
            cargobox.Text = "";
            nameEmployeeBox.Text = "";
            idBox.Text = "";
            ageBox.Text = "";
            telephoneNumberBox.Text = "";

            relationReferenceBox.Text = "";
            telephoneReferenceBox.Text = "";
            personalReferenceBox.Text = "";
            referenciapanel.Show();

            AlergyNmaeBox.Text = "";
            alergypanel.Show();

            DolenciaNameBox.Text = "";
            dolenciapanel.Show();

            MotivoMedicineBox.Text = "";
            nameMedicineBox.Text = "";
            medicinepanel.Show();

            pictureBox.ImageLocation = "";
            dategetin.Text = DateTime.Now.ToString();
            salidapicker.Text = DateTime.Now.ToString();
            birthDateBox.Text = DateTime.Now.ToString();

        }

        private void pictureBoxemployee_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            EmployeeClass emp = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT distinct `TITULO UNIVERSITARIO` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(gottendegree, orden);
            orden = "SELECT distinct `PUESTO` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(cargobox, orden);
            orden = "SELECT distinct `RELACION DE REFERENCIA` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(relationReferenceBox, orden);
            orden = "SELECT distinct `NOMBRE DE ALERGIA` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(AlergyNmaeBox, orden);
            orden = "SELECT distinct `NOMBRE DE DOLENCIA` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(DolenciaNameBox, orden);
            orden = "SELECT distinct `NOMBRE DE MEDICINA` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(nameMedicineBox, orden);
            orden = "SELECT distinct `RAZON DE MEDICINA` FROM " + UserAccessForm.getusername() + "_employee_table;";
            emp.Fillcombo(MotivoMedicineBox, orden);
            
            




            monedatipo.Text = "DOP";
            if (DireccionGestor.getorigen() == "editor")
            {

                titulolabel.Text = "EDITAR EMPLEADO";
                savebuttonstrip.Text = "MODIFICAR";
                emp.filleverything(dategetin, gottendegree, nameEmployeeBox, idBox, birthDateBox, telephoneNumberBox, schedule, cargobox, comboNacionalidad, ageBox, monedatipo, mensualitybox,
                                personalReferenceBox, telephoneReferenceBox, relationReferenceBox, AlergyNmaeBox, DolenciaNameBox, nameMedicineBox, MotivoMedicineBox, trabajando, salidapicker,
                                picturetextbox, direccionbox, sexobox, emailcombo,DireccionGestor.getordensql());


                if (nameMedicineBox.Text == "NINGUNA" && MotivoMedicineBox.Text == "NINGUNA") {
                    medicinepanel.Hide();
                    medicamentosopcionbox.Text = "NO";

                }
                else {
                    medicamentosopcionbox.Text = "SI";
                    medicinepanel.Show();

                }

                if (DolenciaNameBox.Text=="NINGUNA") {
                    dolenciaopcionbox.Text = "NO";
                    dolenciapanel.Hide();
                }
                else {
                    dolenciaopcionbox.Text = "SI";
                    dolenciapanel.Show();


                }

                if (AlergyNmaeBox.Text=="NINGUNA") {
                    alergypanel.Hide();
                    alergiaopcionbox.Text = "NO";

                } else {
                    alergypanel.Show();
                    alergiaopcionbox.Text = "SI";


                }

                if (personalReferenceBox.Text=="NINGUNA" && telephoneReferenceBox.Text=="NINGUNA" && relationReferenceBox.Text=="NINGUNA") {

                    referenciapanel.Hide();
                    referenciaopcionbox.Text = "NO";

                } else {

                    referenciaopcionbox.Text = "SI";
                    referenciapanel.Show();
                }

                empleadopanel.Show();

            }
            else {
                
                savebuttonstrip.Text = "GUARDAR";
                titulolabel.Text = "AGREGAR EMPLEADO";
                empleadopanel.Hide();
            }


            if (picturetextbox.Text != "")
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                string fotopath = System.IO.Path.Combine(combinacion, picturetextbox.Text);
                pictureBox.ImageLocation = fotopath;
            }




        }

        private void picturebutton_Click(object sender, EventArgs e)
        {
            string rutafoto;
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

                    foreach (string s in files)
                    {
                        picturetextbox.Text = System.IO.Path.GetFileName(s);
                        destfile = System.IO.Path.Combine(targetPath, picturetextbox.Text);
                        try
                        {
                            System.IO.File.Copy(s, destfile, true);
                        }
                        catch (System.IO.IOException exept)
                        {
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
            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Maximized;
            menu.Show();
            this.Close();
        }

        private void birthDateBox_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                ageBox.Text = (DateTime.Today.AddTicks(-birthDateBox.Value.Ticks).Year - 1).ToString();
            }
            catch (ArgumentOutOfRangeException negativeage) 
            {
                MessageBox.Show("LA PERSONA AUN NO HA NACIDO");
                negativeage.ToString();
            }
            try {

                int edad = int.Parse(ageBox.Text);
                if (edad <= 18)
                {
                    MessageBox.Show("USTED ESTA CONTRATANDO A UN(A) MENOR DE EDAD");
                }

            } catch (FormatException pad) { pad.ToString(); }
            
        
        }

        private void savebuttonstrip_Click(object sender, EventArgs e)
        {
            carga man = new carga();

            if (savebuttonstrip.Text== "GUARDAR") {

                
                man.WindowState = FormWindowState.Normal;

                if (gottendegree.Text == "" || nameEmployeeBox.Text == "" || idBox.Text == "" || telephoneNumberBox.Text == "" || schedule.Text == "" || cargobox.Text == "" || comboNacionalidad.Text == "" || ageBox.Text == "" || mensualitybox.Text == "" || personalReferenceBox.Text == "" || telephoneReferenceBox.Text == "" || relationReferenceBox.Text == "" || AlergyNmaeBox.Text == "" || DolenciaNameBox.Text == "" || nameMedicineBox.Text == "" || MotivoMedicineBox.Text == "")
                {

                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");



                    if (gottendegree.Text == "") { gottendegree.BackColor = Color.Red; }
                    else { gottendegree.BackColor = Color.Green; }

                    if (nameEmployeeBox.Text == "") { nameEmployeeBox.BackColor = Color.Red; }
                    else { nameEmployeeBox.BackColor = Color.Green; }

                    if (idBox.Text == "") { idBox.BackColor = Color.Red; }
                    else { idBox.BackColor = Color.Green; }

                    if (telephoneNumberBox.Text == "") { telephoneNumberBox.BackColor = Color.Red; }
                    else { telephoneNumberBox.BackColor = Color.Green; }

                    if (schedule.Text == "") { schedule.BackColor = Color.Red; }
                    else { schedule.BackColor = Color.Green; }

                    if (cargobox.Text == "") { cargobox.BackColor = Color.Red; }
                    else { cargobox.BackColor = Color.Green; }

                    if (comboNacionalidad.Text == "") { comboNacionalidad.BackColor = Color.Red; }
                    else { comboNacionalidad.BackColor = Color.Green; }

                    if (ageBox.Text == "") { ageBox.BackColor = Color.Red; }
                    else { ageBox.BackColor = Color.Green; }

                    if (mensualitybox.Text == "") { mensualitybox.BackColor = Color.Red; }
                    else { mensualitybox.BackColor = Color.Green; }

                    if (personalReferenceBox.Text == "") { personalReferenceBox.BackColor = Color.Red; }
                    else { personalReferenceBox.BackColor = Color.Green; }

                    if (telephoneReferenceBox.Text == "") { telephoneReferenceBox.BackColor = Color.Red; }
                    else { telephoneReferenceBox.BackColor = Color.Green; }

                    if (relationReferenceBox.Text == "") { relationReferenceBox.BackColor = Color.Red; }
                    else { relationReferenceBox.BackColor = Color.Green; }

                    if (AlergyNmaeBox.Text == "") { AlergyNmaeBox.BackColor = Color.Red; }
                    else { AlergyNmaeBox.BackColor = Color.Green; }

                    if (DolenciaNameBox.Text == "") { DolenciaNameBox.BackColor = Color.Red; }
                    else { DolenciaNameBox.BackColor = Color.Green; }

                    if (nameMedicineBox.Text == "") { nameMedicineBox.BackColor = Color.Red; }
                    else { nameMedicineBox.BackColor = Color.Green; }

                    if (MotivoMedicineBox.Text == "") { MotivoMedicineBox.BackColor = Color.Red; }
                    else { MotivoMedicineBox.BackColor = Color.Green; }

                }
                else
                {
                    

                    try
                    {
                        string userDataName = UserAccessForm.getusername() + "_employee_table";
                        EmployeeClass employee = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        employee.NameNoCopied(nameEmployeeBox.Text, userDataName);
                        int age = int.Parse(ageBox.Text);
                        double mensuality = double.Parse(mensualitybox.Text);
                        DateTime birthdate = Convert.ToDateTime(birthDateBox.Value.Date);
                        DateTime timegetin = Convert.ToDateTime(dategetin.Value.ToShortTimeString());
                        string access = userDataName;

                        if (mensualitybox.BackColor == Color.Red)
                        {
                            MessageBox.Show("Arregle el campo no valido");
                        }
                        else
                        {

                            if (employee.NameNoCopied(nameEmployeeBox.Text, userDataName) == true)
                            {
                                man.Close();
                                MessageBox.Show("El Empleado " + nameEmployeeBox.Text + " ya existe.");
                                if (MessageBox.Show("Agregar a otro empleado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    employee = new EmployeeClass();

                                    DireccionGestor menu = new DireccionGestor();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                    this.Close();
                                }
                                else
                                {
                                    employee = new EmployeeClass();

                                    EmployeeForm menu = new EmployeeForm();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                    this.Close();
                                }
                            }
                            else if (employee.NameNoCopied(nameEmployeeBox.Text, userDataName) == false)
                            {
                                if (gottendegree.Text == "" || nameEmployeeBox.Text == "" || idBox.Text == "" || telephoneNumberBox.Text == "" || schedule.Text == "" || cargobox.Text == "" || comboNacionalidad.Text == "" || ageBox.Text == "" || mensualitybox.Text == "" || personalReferenceBox.Text == "" || telephoneReferenceBox.Text == "" || relationReferenceBox.Text == "" || AlergyNmaeBox.Text == "" || DolenciaNameBox.Text == "" || nameMedicineBox.Text == "" || MotivoMedicineBox.Text == "")
                                {
                                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");
}
                                else
                                {
                                    string date = birthDateBox.Value.Day.ToString() + "/" + birthDateBox.Value.Month.ToString() + "/" + birthDateBox.Value.Year.ToString();
                                    string evento = birthDateBox.Value.Day.ToString() + "/" + birthDateBox.Value.Month.ToString();
                                    string eventoname = "CUMPLEAÑOS DE " + nameEmployeeBox.Text;

                                    AgendaClass addevent = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                                    addevent.saveData(UserAccessForm.getusername(), eventoname, 1, date, "7:20:0", "NO", "NO", "NO", "NO", "NO", "NO", "NO", evento, "SI", "");

                                    LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                                    add.AddContact(nameEmployeeBox.Text, telephoneNumberBox.Text, direccionbox.Text, emailcombo.Text, UserAccessForm.getusername().ToString());

                                    if (employee.SaveData(userDataName, dategetin, gottendegree.Text, nameEmployeeBox.Text, idBox.Text, birthDateBox, telephoneNumberBox.Text, schedule.Text, cargobox.Text, comboNacionalidad.Text, age, mensuality, personalReferenceBox.Text, telephoneReferenceBox.Text, relationReferenceBox.Text, AlergyNmaeBox.Text, DolenciaNameBox.Text, nameMedicineBox.Text, MotivoMedicineBox.Text, picturetextbox.Text, monedatipo.Text, sexobox.Text, direccionbox.Text, emailcombo.Text))
                                    {
                                       
                                        man.Close();
                                        employee.NameNoCopied(nameEmployeeBox.Text, userDataName);
                                        employee.OrderID(userDataName);
                                        MessageBox.Show("NUEVO EMPLEADO " + nameEmployeeBox.Text + " HA SIDO AGREGADO.");

                                        if (MessageBox.Show("Agregar a otro empleado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {
                                            employee = new EmployeeClass();

                                            DireccionGestor menu = new DireccionGestor();
                                            menu.WindowState = FormWindowState.Normal;
                                            menu.Show();
                                            this.Close();
                                        }
                                        else
                                        {
                                            employee = new EmployeeClass();

                                            EmployeeForm menu = new EmployeeForm();
                                            menu.WindowState = FormWindowState.Normal;
                                            menu.Show();
                                            this.Close();
                                        }
                                    }

                                    else
                                    {
                                        man.Close();

                                        MessageBox.Show("NUEVO EMPLEADO " + nameEmployeeBox.Text + "HA SIDO AGREGADO.");
                                        if (MessageBox.Show("Agregar a otro empleado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                        {

                                            employee = new EmployeeClass();

                                            DireccionGestor menu = new DireccionGestor();
                                            menu.WindowState = FormWindowState.Normal;
                                            menu.Show();
                                            this.Close();
                                        }
                                        else
                                        {
                                            employee = new EmployeeClass();

                                            EmployeeForm menu = new EmployeeForm();
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
            }
            else if(savebuttonstrip.Text == "MODIFICAR") {

                man.WindowState = FormWindowState.Normal;

                if (referenciaopcionbox.Text == "NO")
                {
                    man.Close();
                    telephoneReferenceBox.Text = "NINGUNA";
                    relationReferenceBox.Text = "NINGUNA";
                    personalReferenceBox.Text = "NINGUNA";

                }

                try
                {
                    man.Close();
                    string userDataName = UserAccessForm.getusername() + "_employee_table";
                    EmployeeClass save = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    AgendaClass addevent = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());


                    double mensuality = double.Parse(mensualitybox.Text);

                    string nameevent = "CUMPLEAÑOS DE " + nameEmployeeBox.Text;
                    string date = birthDateBox.Value.Day.ToString() + "/" + birthDateBox.Value.Month.ToString() + "/" + birthDateBox.Value.Year.ToString();
                    string momentdate = birthDateBox.Value.Day.ToString() + "/" + birthDateBox.Value.Month.ToString();

                    save.ModifyData(DireccionGestor.getnombrestatic(), trabajando.Text,userDataName,   dategetin, salidapicker, gottendegree.Text, nameEmployeeBox.Text, idBox.Text, birthDateBox, 
                        telephoneNumberBox.Text, schedule.Text, cargobox.Text , comboNacionalidad.Text,int.Parse(ageBox.Text), mensuality, personalReferenceBox.Text, telephoneReferenceBox.Text, 
                        relationReferenceBox.Text, AlergyNmaeBox.Text, DolenciaNameBox.Text, nameMedicineBox.Text, MotivoMedicineBox.Text, picturetextbox.Text, monedatipo.Text,
                        sexobox.Text, direccionbox.Text,emailcombo.Text,EmployeeClass.getids());
                    addevent.modifydata(UserAccessForm.getusername(), DireccionGestor.getnombrestatic(), nameevent, 1, date, "7:20:0", "NO", "NO", "NO", "NO", "NO", "NO", "NO", momentdate, "SI");
                    LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    add.editContact(nameEmployeeBox.Text, telephoneNumberBox.Text, direccionbox.Text, emailcombo.Text, DireccionGestor.getnombrestatic(), UserAccessForm.getusername().ToString());

                    MessageBox.Show("EL EMPLEADO " + nameEmployeeBox.Text + " HA SIDO MODIFICADO");



                    EmployeeClass studentobject = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    EmployeeFormSearch buscar = new EmployeeFormSearch();
                    buscar.WindowState = FormWindowState.Maximized;
                    buscar.Show();
                    this.Close();




                }
                catch (FormatException datethis) { datethis.ToString(); }
            }
        }


        private void ageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");

            }
        }

        private void mensualitybox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
            }
        }

        private void nameEmployeeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameEmployeeBox.BackColor = Color.White;
        }

        private void idBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");

            }
        }

        private void telephoneNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Usa el Formato de telefono");

            }
        }

        private void telephoneReferenceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Usa el Formato de telefono");

            }
        }

        private void mensualitybox_TextChanged(object sender, EventArgs e)
        {
            mensualitybox.BackColor = Color.White;
        }

        private void nameMedicineBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameMedicineBox.BackColor = Color.White;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (savebuttonstrip.Text=="GUARDAR") {

                if (referenciaopcionbox.Text == "SI" || referenciaopcionbox.Text == "si")
                {
                    relationReferenceBox.Text = "";
                    telephoneReferenceBox.Text = "";
                    personalReferenceBox.Text = "";
                    referenciapanel.Show();
                }
                else
                {
                    referenciapanel.Hide();
                    relationReferenceBox.Text = "NINGUNA";
                    telephoneReferenceBox.Text = "NINGUNA";
                    personalReferenceBox.Text = "NINGUNA";
                }

            }
            else { 
            if (referenciaopcionbox.Text == "SI" || referenciaopcionbox.Text == "si")
            {
                
                referenciapanel.Show();
            }
            else {
                referenciapanel.Hide();
                relationReferenceBox.Text = "NINGUNA";
                telephoneReferenceBox.Text = "NINGUNA";
                personalReferenceBox.Text = "NINGUNA";
            }

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (savebuttonstrip.Text=="GUARDAR") {


                if (alergiaopcionbox.Text == "SI" || alergiaopcionbox.Text == "si")
                {

                    AlergyNmaeBox.Text = "";
                    alergypanel.Show();

                }
                else
                {
                    alergypanel.Hide();
                    AlergyNmaeBox.Text = "NINGUNA";

                }

            } else {

                if (alergiaopcionbox.Text == "SI" || alergiaopcionbox.Text == "si")
                {

                    alergypanel.Show();

                }
                else
                {
                    alergypanel.Hide();
                    AlergyNmaeBox.Text = "NINGUNA";

                }

            }

        }

        private void dolenciaopcionbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (savebuttonstrip.Text=="GUARDAR") {


                if (dolenciaopcionbox.Text == "SI" || dolenciaopcionbox.Text == "si")
                {

                    DolenciaNameBox.Text = "";
                    dolenciapanel.Show();
                }
                else
                {
                    dolenciapanel.Hide();
                    DolenciaNameBox.Text = "NINGUNA";

                }

            } else {

                if (dolenciaopcionbox.Text == "SI" || dolenciaopcionbox.Text == "si")
                {

                    dolenciapanel.Show();
                }
                else
                {
                    dolenciapanel.Hide();
                    DolenciaNameBox.Text = "NINGUNA";

                }
            }
        }

        private void medicamentosopcionbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (savebuttonstrip.Text=="GUARDAR") {
                if (medicamentosopcionbox.Text == "SI" || medicamentosopcionbox.Text == "si")
                {

                    MotivoMedicineBox.Text = "";
                    nameMedicineBox.Text = "";
                    medicinepanel.Show();
                }
                else
                {
                    medicinepanel.Hide();
                    MotivoMedicineBox.Text = "NINGUNA";
                    nameMedicineBox.Text = "NINGUNA";
                }
            } else {

                if (medicamentosopcionbox.Text == "SI" || medicamentosopcionbox.Text == "si")
                {
                    medicinepanel.Show();
                }
                else
                {
                    medicinepanel.Hide();
                    MotivoMedicineBox.Text = "NINGUNA";
                    nameMedicineBox.Text = "NINGUNA";
                }
            }
        }

        private void MotivoMedicineBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MotivoMedicineBox.BackColor = Color.White;
        }

        private void DolenciaNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DolenciaNameBox.BackColor = Color.White;
        }

        private void AlergyNmaeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlergyNmaeBox.BackColor = Color.White;
        }

        private void relationReferenceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            relationReferenceBox.BackColor = Color.White;
        }

        private void telephoneReferenceBox_TextChanged(object sender, EventArgs e)
        {
            telephoneReferenceBox.BackColor = Color.White;
        }

        private void personalReferenceBox_TextChanged(object sender, EventArgs e)
        {
            personalReferenceBox.BackColor = Color.White;
        }

        private void ageBox_TextChanged(object sender, EventArgs e)
        {
            ageBox.BackColor = Color.White;
        }

        private void comboNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboNacionalidad.BackColor = Color.White;
        }

        private void cargobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargobox.BackColor = Color.White;
        }

        private void schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            schedule.BackColor = Color.White;
        }

        private void telephoneNumberBox_TextChanged(object sender, EventArgs e)
        {
            telephoneNumberBox.BackColor = Color.White;
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            idBox.BackColor = Color.White;
        }

        private void gottendegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            gottendegree.BackColor = Color.White;
        }

        private void dategetin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trabajando_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trabajando.Text == "SI") { salidapicker.Enabled = false; }
            else { salidapicker.Enabled = true; }
        }

        private void EmployeeForm_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void referenciapanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}