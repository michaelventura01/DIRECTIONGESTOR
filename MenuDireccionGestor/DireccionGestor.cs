using System;
using System.Drawing;
using System.Windows.Forms;
using DireccionLib;
using WMPLib;
using System.Media;

namespace DireccionLib
{

    

    public partial class DireccionGestor : Form
    {

        
        private static string origen = "inicio";
        public static string getorigen() {
            return origen;
            
        }
        public static void setorigen(string valor) {
            origen = valor;
        }


        private static string ordensql = "";
        public static string getordensql() {
            return ordensql;
        }
        public static void setordensql(string orden) {
            ordensql = orden;
        }



        private static string nombrestatic;
        public static void setsombrestatic(string nombre) { nombrestatic = nombre; }
        public static string getnombrestatic() { return nombrestatic; }


        private static int edadstatic;
        public static int getedadestatic() { return edadstatic; }
        public static void setedadstatic(int edad) { edadstatic = edad; }

        private static string otrostatic;
        public static void setotrostatic(string otro) { otrostatic = otro; }
        public static string getotrostatic() { return otrostatic; }


        private static bool estadostatic;
        public static void setestadostatic(bool otro) { estadostatic = otro; }
        public static bool getestadostatic() { return estadostatic; }

        private static string prioridadstatic;
        public static void setprioridadstatic(string otro) { prioridadstatic = otro; }
        public static string getprioridadstatic() { return prioridadstatic; }



        public DireccionGestor()
        {
            InitializeComponent();
            panel1.Hide();
            picture.Hide();


            
            LoginClass student = new LoginClass(UserAccessForm.getdbserver(),UserAccessForm.getdbname(), UserAccessForm.getdbuser(),UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT * FROM  users_table WHERE USER_NAME= '" + UserAccessForm.getusername() +"';";
            student.filltwo(tipousuario,nameuserlabel,emaillabel,telefonolabel,picture,orden);
          
            if (picture.Text != "")
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string combinacion = System.IO.Path.Combine(path, "users");

                string fotopath = System.IO.Path.Combine(combinacion, picture.Text);

                userpictureBox.ImageLocation = fotopath;


            }
           



        }

        private void DireccionGestor_Load(object sender, EventArgs e)
        {
            pagolabel.Hide();
            cobrolabel.Hide();
            addstudentlabel.Hide();
            verstudentlabel.Hide();
            addempleadolabel.Hide();
            verempleadolabel.Hide();
            ingresolabel.Hide();
            gastolabel.Hide();
            movimientolabel.Hide();
            melodybox.Hide();
            if (estadostatic == true && cuenta < 400)
            {

                if (getestadostatic() == true)
                {
                    eventonamelabel.Text=getnombrestatic();
                    eventohoralabel.Text=getotrostatic();
                    prioridadbox.Text=getprioridadstatic();
                    setestadostatic(true);

                    if (prioridadbox.Text == "0")
                    {
                        panel1.BackColor = Color.Red;

                    }
                    else if (prioridadbox.Text == "1")
                    {
                        panel1.BackColor = Color.Orange;

                    }
                    else if (prioridadbox.Text == "2")
                    {
                        panel1.BackColor = Color.Yellow;
                    }


                    panel1.Show();

                }
                else
                {
                    panel1.Hide();

                }

            }



            estadostatic = false;
            
            
            prioridadbox.Hide();
            quitarbutton.Enabled = false;



            
            AgendaClass ev = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            DateTime fecha = DateTime.Now;
            ev.ShowDataGridinicio(datainicio,UserAccessForm.getusername(), fecha, daylabel.Text);
            cuentalabel.Text = ev.getcuenta().ToString();

            if (UserAccessForm.getusername() != "") 
            { 
                //nameuserlabel.Text = UserAccessForm.getusername(); 
                statelabel.Text = "Conectado"; 
                databaseinfo.Text = "MySQL "+ UserAccessForm.getdbserver(); 
            }

        }

        private void toolStripsalirbutton_Click(object sender, FormClosingEventArgs e)
        {
        }

        private void toolStripsalirbutton_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Se cerrara la aplicacion, estas seguro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }

        private void addagendabutton_Click(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se cerrara la aplicacion, estas seguro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateStudentTable(UserAccessForm.getusername());
            origen = "inicio";
            StudentForm studentaddobject = new StudentForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
            this.Close();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEmployeeTable(UserAccessForm.getusername());
            origen = "inicio";
            EmployeeForm employeeaddobject = new EmployeeForm();
            employeeaddobject.WindowState = FormWindowState.Maximized;
            employeeaddobject.Show();
            this.Close();
        }

        private void eventoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEventTable(UserAccessForm.getusername());
            origen = "inicio";
            AgendaEvents agendaevent = new AgendaEvents();
            agendaevent.WindowState = FormWindowState.Normal;
            agendaevent.Show();
            
        }

        private void eventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEventTable(UserAccessForm.getusername());
            origen = "inicio";
            agendaAdd agendaobjectl = new agendaAdd();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
            
        }

        private void alumnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateStudentTable(UserAccessForm.getusername());
            StudentFormSearch searchstudent = new StudentFormSearch();
            searchstudent.WindowState = FormWindowState.Normal;
            searchstudent.Show();
            this.Close();
        }

        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEmployeeTable(UserAccessForm.getusername());
            EmployeeFormSearch searchemployee = new EmployeeFormSearch();
            searchemployee.WindowState = FormWindowState.Normal;
            searchemployee.Show();
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEventTable(UserAccessForm.getusername());
            origen = "inicio";
            agendaAdd agendaevent = new agendaAdd();
            agendaevent.WindowState = FormWindowState.Normal;
            agendaevent.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salidaDeDineroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            origen = "inicio";
            GastosForm gastosobject = new GastosForm();
            gastosobject.WindowState = FormWindowState.Normal;
            gastosobject.Show();
            
        }

        private void timepanel_Paint(object sender, PaintEventArgs e)
        {
            TimeClass objecttime = new TimeClass();

            
            if (objecttime.inthour() >= 5 && objecttime.inthour() < 12) 
            {

                clocklabel.BackColor = Color.DeepSkyBlue;
                datelabel.BackColor = Color.DeepSkyBlue;
                timepanel.BackColor = Color.DeepSkyBlue;
                nightpictureBox.Hide();
                morningpictureBox.Show();
                nightpictureBox.Hide();
            } 



            if (objecttime.inthour() >= 12 && objecttime.inthour() < 19) 
            {
                clocklabel.BackColor = Color.Gold;
                datelabel.BackColor = Color.Gold;
                timepanel.BackColor = Color.Gold;                
                morningpictureBox.Hide();
                afnernoonpictureBox.Show();
                nightpictureBox.Hide();
            }

            if (objecttime.inthour() >= 19 || objecttime.inthour() <5) 
            {
                clocklabel.BackColor = Color.BlueViolet;
                datelabel.BackColor = Color.BlueViolet;
                timepanel.BackColor = Color.BlueViolet;
                afnernoonpictureBox.Hide();
                nightpictureBox.Show();
                morningpictureBox.Hide();
            } 
            


        }

        private void clocklabel_Click(object sender, EventArgs e)
        {
            
        }
        private string fecharecordatorio = "";

        private int cuenta;
        private int cuentasonido;
        private bool estatesong=false;

        private void timer_Tick(object sender, EventArgs e)
        {
            //cont.Text = cuenta.ToString();
            cuenta++;
            cuentasonido++;
            
            TimeClass timeobject = new TimeClass();
            clocklabel.Text = timeobject.clockshape();
            datelabel.Text = timeobject.dateshape();

            string day= DateTime.Now.DayOfWeek.ToString();

            switch (day) {

                case "Monday":
                    daylabel.Text = "LUNES";
                    break;
                case "Tuesday":
                    daylabel.Text = "MARTES";
                    break;
                case "Wednesday":
                    daylabel.Text = "MIERCOLES";
                    break;
                case "Thursday":
                    daylabel.Text = "JUEVES";
                    break;
                case "Friday":
                    daylabel.Text = "VIERNES";
                    break;
                case "Saturday":
                    daylabel.Text = "SABADO";
                    break;
                case "Sunday":
                    daylabel.Text = "DOMINGO";
                    break;
            }
            

            AgendaClass ev = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            DateTime fecha = DateTime.Now;
            ev.ShowDataGridinicio(datainicio, UserAccessForm.getusername(), fecha, daylabel.Text);
            cuentalabel.Text = ev.getcuenta().ToString();

            if (cuenta == 600)
            {

                cuenta = 0;
                panel1.Hide();
                eventonamelabel.Text = "";
                eventohoralabel.Text = "";
                estadostatic = false;

            }

            string hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string fechal = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(); ;
            string fechashort = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();



            WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
            string orden = "SELECT DESCRIPCION, HORA, PRIORIDAD, SONIDO FROM " + UserAccessForm.getusername() + "_events_table WHERE (HORA='" + hora + "' AND ( FECHA='" + fechal + "' or `FECHA DE RECORDATORIO`='" + fechashort + "'))AND ACTIVO='SI';";
            if (ev.getnametarea(eventonamelabel, eventohoralabel, prioridadbox,melodybox, orden))
            {
                SystemSounds.Hand.Play();

                panel1.Show();

                cuenta = 0;
                cuentasonido = 0;


                
                setsombrestatic(eventonamelabel.Text);
                setotrostatic(eventohoralabel.Text);
                setprioridadstatic(prioridadbox.Text);
                setestadostatic(true);

                if (prioridadbox.Text == "0")
                {
                    panel1.BackColor = Color.Red;

                }
                else if (prioridadbox.Text == "1")
                {
                    panel1.BackColor = Color.Orange;

                }
                else if (prioridadbox.Text == "2")
                {
                    panel1.BackColor = Color.Yellow;
                }

                if (melodybox.Text != "")
                {
                    estatesong = false;
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

                    string melodypath = System.IO.Path.Combine(combinacion, melodybox.Text);

                    wplayer.URL = melodypath;
                    wplayer.controls.play();


                }
                else {

                    estatesong = true;
                }
                
                if (MessageBox.Show("SON LAS " + eventohoralabel.Text + " ES HORA DE " + eventonamelabel.Text, "PARAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cuentasonido=0;
                    
                    estatesong = false;
                }
                else {
                    cuentasonido = 0;
                    estatesong = true;
                }
               
            }

            if (cuentasonido == 300 && melodybox.Text!=""&& estatesong==true) {

                if (MessageBox.Show("SON LAS " + eventohoralabel.Text + " ES HORA DE " + eventonamelabel.Text, "PARAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    cuentasonido = 0;
                    estatesong = false;
                }
                else
                {
                    cuentasonido = 0;
                    estatesong = true;
                }
            }

            if (estatesong==false) { wplayer.controls.stop(); }



        }
        
        
        private void datelabel_Click(object sender, EventArgs e)
        {

        }

        private void morningpictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void afnernoonpictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void nightpictureBox_Click(object sender, EventArgs e)
        {

        }
        
        private void agregarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            origen = "inicio";
            IngresosForm ingresosobject = new IngresosForm();
            ingresosobject.WindowState = FormWindowState.Normal;
            ingresosobject.Show();
            
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            MovementsForms moveobject = new MovementsForms();
            moveobject.WindowState = FormWindowState.Normal;
            moveobject.Show();
            this.Close();
            
        }

        private void cerrarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            UserAccessForm moveobject = new UserAccessForm();
            moveobject.WindowState = FormWindowState.Normal;
            moveobject.Show();
            this.Close();
        }

        private void cerrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            UserAccessForm moveobject = new UserAccessForm();
            moveobject.WindowState = FormWindowState.Normal;
            moveobject.Show();
            this.Close();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            origen = "inicio";
            UserAddForm adduser = new UserAddForm();
            adduser.WindowState = FormWindowState.Maximized;
            adduser.Show();
            this.Close();

        }
        private static UsersShowForm showuser;
        public static void setcloseshowuser() {
            try
            {
                showuser.Close();
            } catch (NullReferenceException arp) {
                arp.ToString();

            } }
        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            showuser = new UsersShowForm();
            showuser.WindowState = FormWindowState.Maximized;
            showuser.Show();
            this.Close();
        }

        private void nameuserlabel_Click(object sender, EventArgs e)
        {

        }

        private void checklistagenda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void agregarAsignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private string nombre;
        private string fecha = "";
        private string prioridad = "";
        private void datainicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (nombre != "")
            {

                quitarbutton.Enabled = true;
               
            }
            else {

                quitarbutton.Enabled = false;
               

            }
            try {
                AgendaClass show = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_events_table";
                string dato = this.datainicio.CurrentCell.Value.ToString();
                nombre = dato;
                string orden = "select * from " + userDataName + " where `DESCRIPCION` = '" + nombre + "' ORDER BY PRIORIDAD ASC;";
                show.getname(nombre, fecha, prioridad, orden);
                DireccionGestor.setsombrestatic(nombre);
                DireccionGestor.setotrostatic(fecha);
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            

        }

        private void quitarbutton_Click(object sender, EventArgs e)
        {
            string userdataname = UserAccessForm.getusername() + "_events_table";

            string orden = "UPDATE " + userdataname + " SET ACTIVO = 'NO' WHERE  `DESCRIPCION`= '" + nombre +"' ;";
            AgendaClass kit = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            kit.ordensql(orden);
            MessageBox.Show("TAREA "+nombre+" DESACTIVADA");

            quitarbutton.Enabled = false;
            
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("inicio");
            AgendaEvents agendaobject = new AgendaEvents();
            agendaobject.WindowState = FormWindowState.Normal;
            agendaobject.Show();
            
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void alertpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calcpicturebox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "calc";
            proc.Start();
            //TIMEDATE.CPL
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
            addstudentlabel.Show();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            addstudentlabel.Hide();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            verstudentlabel.Show();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            verstudentlabel.Hide();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            addempleadolabel.Show();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            addempleadolabel.Hide();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            verempleadolabel.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            verempleadolabel.Hide();
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            ingresolabel.Show();
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            ingresolabel.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            gastolabel.Show();
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            gastolabel.Hide();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            movimientolabel.Show();
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            movimientolabel.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateStudentTable(UserAccessForm.getusername());
            origen = "inicio";
            StudentForm studentaddobject = new StudentForm();
            studentaddobject.WindowState = FormWindowState.Maximized;
            studentaddobject.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEmployeeTable(UserAccessForm.getusername());
            origen = "inicio";
            EmployeeForm employeeaddobject = new EmployeeForm();
            employeeaddobject.WindowState = FormWindowState.Maximized;
            employeeaddobject.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateStudentTable(UserAccessForm.getusername());
            StudentFormSearch searchstudent = new StudentFormSearch();
            searchstudent.WindowState = FormWindowState.Normal;
            searchstudent.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateEmployeeTable(UserAccessForm.getusername());
            EmployeeFormSearch searchemployee = new EmployeeFormSearch();
            searchemployee.WindowState = FormWindowState.Normal;
            searchemployee.Show();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            origen = "inicio";
            IngresosForm ingresosobject = new IngresosForm();
            ingresosobject.WindowState = FormWindowState.Normal;
            ingresosobject.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            origen = "inicio";
            GastosForm gastosobject = new GastosForm();
            gastosobject.WindowState = FormWindowState.Normal;
            gastosobject.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateMovementsTable(UserAccessForm.getusername());
            MovementsForms moveobject = new MovementsForms();
            moveobject.WindowState = FormWindowState.Normal;
            moveobject.Show();
            this.Close();
        }

        private void timepanel_Click(object sender, EventArgs e)
        {

        }

        private void timepanel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TIMEDATE.CPL";
            proc.Start();
            
        }

        private void clocklabel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TIMEDATE.CPL";
            proc.Start();
        }

        private void datelabel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TIMEDATE.CPL";
            proc.Start();
        }

        private void daylabel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "TIMEDATE.CPL";
            proc.Start();
        }

        private void cONTACTOToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateContactsTable(UserAccessForm.getusername());
            
            origen = "inicio";
            addContact agendaobjectl = new addContact();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void aSIGNATURASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateSubjectTable(UserAccessForm.getusername());
            origen = "inicio";
            AddSubject agendaobjectl = new AddSubject();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void cONTACTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateContactsTable(UserAccessForm.getusername());
            origen = "inicio";
            ShowContacts agendaobjectl = new ShowContacts();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }
        
        private void aSIGNATURASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateSubjectTable(UserAccessForm.getusername());
            origen = "inicio";
            ShowSubjects agendaobjectl = new ShowSubjects();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void cUENTASPORCOBRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateCountAskForTable(UserAccessForm.getusername());
            origen = "_askfor_table";
            PendientesForm agendaobjectl = new PendientesForm();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void cUENTASPORPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateCountPayForTable(UserAccessForm.getusername());
            origen = "_payfor_table";
            PendientesForm agendaobjectl = new PendientesForm();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void eSTUDIANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origen = "inicio asistencia estudiante";
            CalificationForm agendaobjectl = new CalificationForm();
            agendaobjectl.WindowState = FormWindowState.Maximized;
            agendaobjectl.Show();
            
            this.Close();
        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origen = "inicio asistencia empleado";
            CalificationForm agendaobjectl = new CalificationForm();
            agendaobjectl.WindowState = FormWindowState.Maximized;
            agendaobjectl.Show();
            this.Close();
        }
        
        private void eSTUDIANTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            origen = "inicio calificar estudiante";
            CalificationForm agendaobjectl = new CalificationForm();
            agendaobjectl.WindowState = FormWindowState.Maximized;
            agendaobjectl.Show();
            this.Close();
        }
        
        private void eMPLEADOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            origen = "inicio calificar empleado";
            CalificationForm agendaobjectl = new CalificationForm();
            agendaobjectl.WindowState = FormWindowState.Maximized;
            agendaobjectl.Show();
            this.Close();
        }
        
        private void eSTUDIANTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            origen = "inicio evaluar estudiante";
            CalificationForm agendaobjectl = new CalificationForm();
            agendaobjectl.WindowState = FormWindowState.Maximized;
            agendaobjectl.Show();
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            cobrolabel.Show();
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            cobrolabel.Hide();
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pagolabel.Show();
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pagolabel.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateCountAskForTable(UserAccessForm.getusername());
            origen = "_payfor_table";
            PendientesForm agendaobjectl = new PendientesForm();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateCountAskForTable(UserAccessForm.getusername());
            origen = "_askfor_table";
            PendientesForm agendaobjectl = new PendientesForm();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            contactlabel.Text = "AGREGAR CONTACTO";
            pictureBox9.BackColor = Color.Turquoise;
            panelcontact.BackColor = Color.Turquoise;
            telefonolabel.BackColor = Color.Turquoise;
            emaillabel.BackColor = Color.Turquoise;
            contactlabel.BackColor = Color.Turquoise;

        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            contactlabel.Text = "CONTACTO:";
            panelcontact.BackColor = Color.Orange;
            pictureBox9.BackColor = Color.Orange;
            telefonolabel.BackColor = Color.Orange;
            emaillabel.BackColor = Color.Orange;
            contactlabel.BackColor = Color.Orange;
        }

        private void panelcontact_MouseHover(object sender, EventArgs e)
        {
            contactlabel.Text = "VER CONTACTOS";
            
            pictureBox9.BackColor = Color.Chocolate;
            panelcontact.BackColor = Color.Chocolate;
            telefonolabel.BackColor = Color.Chocolate;
            emaillabel.BackColor = Color.Chocolate;
            contactlabel.BackColor = Color.Chocolate;
        }

        private void panelcontact_MouseLeave(object sender, EventArgs e)
        {
            contactlabel.Text = "CONTACTO:";
            panelcontact.BackColor = Color.Orange;
            pictureBox9.BackColor = Color.Orange;
            telefonolabel.BackColor = Color.Orange;
            emaillabel.BackColor = Color.Orange;
            contactlabel.BackColor = Color.Orange;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateContactsTable(UserAccessForm.getusername());

            origen = "inicio";
            addContact agendaobjectl = new addContact();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void panelcontact_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelcontact_Click(object sender, EventArgs e)
        {
            LoginClass create = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            create.CreateContactsTable(UserAccessForm.getusername());
            origen = "inicio";
            ShowContacts agendaobjectl = new ShowContacts();
            agendaobjectl.WindowState = FormWindowState.Normal;
            agendaobjectl.Show();
        }

        private void datainicio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            toolStripButton3.PerformClick();
        }

        private void datainicio_DoubleClick(object sender, EventArgs e)
        {
            toolStripButton3.PerformClick();
        }
    }
}


/* DialogResult dialog = MessageBox.Show("Quieres cerrar la aplicacion", "Salir?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) { Application.Exit(); }
            else if (dialog == DialogResult.No) { e.Cancel = true; }
        
            */
