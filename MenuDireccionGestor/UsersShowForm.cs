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
    public partial class UsersShowForm : Form
    {
        public UsersShowForm()
        {
            InitializeComponent();
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            show.ShowDataGrid(findinggrid);
            encontradoslabel.Text = show.getcuenta().ToString();
            show.FillFieldsForm(namebox);
        }




        private void timera_Tick(object sender, EventArgs e)
        {

            


            if (refresh == "refresh") {
                refresh = "";
                LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                show.ShowDataGrid(findinggrid);
                namebox.Text = "";
                tipobox.Text = "";
                encontradoslabel.Text = show.getcuenta().ToString();
            }



            

            TimeClass timeobject = new TimeClass();
            hourlabelstrip.Text = timeobject.clockshape();
            datelabelstrip.Text = timeobject.dateshape();


            AgendaClass ev = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            string hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string fechal = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(); ;
            string fechashort = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();

            cuenta++;
            if (cuenta == 4000)
            {

                cuenta = 0;
                backstripbutton.PerformClick();
            }
            if (cuenta==1000) {
                opcionpanel.Hide();
            }



        }


        private int cuenta;

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            namebox.Text = "TODOS";
            tipobox.Text = "TODOS";
            string orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";
            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();

        }

        private void backstripbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor begin = new DireccionGestor();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            this.Close();

        }
        private static string state;
        public static string getstate(){
            return state;
        }
        public static void setstate(string data)
        {
            state = data;
        }

        private static string refresh;
        public static void setrefresh(string status) {
            refresh = status;
        }

        private static string[] datauser;
        public static string[] getdatauser() { return datauser; }
        private void UsersShowForm_Load(object sender, EventArgs e)
        {
            
            addbutton.BackColor = Color.Green;
            editbutton.BackColor = Color.DarkBlue;
            searchbutton.BackColor = Color.Blue;

            passlabel.Hide();
            editlabel.Hide();
            deletelabel.Hide();
            savedatalabel.Hide();
            cargarlabel.Hide();


            opcionpanel.Hide();
            editbutton.Enabled = false;
            namebox.Text = "TODOS";
            tipobox.Text = "TODOS";
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {

            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";

            if ((tipobox.Text == "" || tipobox.Text == "TODOS") && (namebox.Text == ""|| namebox.Text == "TODOS" ))
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";
            }
            else if ((tipobox.Text == "" && namebox.Text != "")|| (tipobox.Text == "TODOS" && namebox.Text != "TODOS"))
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table where USER_NAME='"+namebox.Text+"';";
            }
            else if ((tipobox.Text != "" && namebox.Text == "")|| (tipobox.Text != "TODOS" && namebox.Text == "TODOS"))
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table where USERTIPO='" + tipobox.Text + "';";
            }
            else {

                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table where USERTIPO='" + tipobox.Text + "' AND  USER_NAME='" + namebox.Text + "';";
            }



             show.ShowDataGridFound(findinggrid,orden);
            encontradoslabel.Text = show.getcuenta().ToString();


        }
        private static string[] datum;
        public static string[] getdatum() { return datum; }
        
        private void findinggrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            editbutton.Enabled = false;
            try {
                datum = new string[4];
                string userDataName = UserAccessForm.getusername() + "_employee_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();
                
                namebox.Text = dato;


                string orden = "select * from users_table where `USER_NAME` = '" + dato + "';";

                
                if (show.fillcombo(tipobox, namebox, orden) == true)
                {
                    datum = new string[4];
                    datum[0] = namebox.Text;
                    datum[1] = tipobox.Text;
                    datum[2] = LoginClass.getdata()[0];
                    datum[3] = LoginClass.getdata()[1];
                    
                }

                



            }
            catch (NullReferenceException pafh) {
                pafh.ToString();
                editbutton.Enabled = false;
            }


            if (show.ordensql("SELECT USER_NAME FROM USERS_TABLE WHERE `USER_NAME` = '" + namebox.Text + "';")==false)
            {

                editbutton.Enabled = false;
            }
            else
            {
                editbutton.Enabled = true;
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");

            UserAddForm adduser = new UserAddForm();
            adduser.WindowState = FormWindowState.Maximized;
            adduser.Show();
            this.Close();
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            opcionpanel.Show();
            editbutton.Enabled = false;
           
            namebox.Text = "";
            tipobox.Text = "";
        }

        private void eliminarbutton_Click(object sender, EventArgs e)
        {

            editbutton.Enabled = false;
            
            namebox.Text = "";
            tipobox.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            opcionpanel.Hide();
        }

        private void findinggrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            editbutton.Enabled = false;
            try {

                string userDataName = UserAccessForm.getusername() + "_employee_table";
                string dato = this.findinggrid.CurrentCell.Value.ToString();


                namebox.Text = dato;
                string orden = "select * from users_table where `USER_NAME` = '" + dato + "';";

                if (show.fillcombo(tipobox, namebox, orden) == true)
                {
                    datum = new string[4];
                    datum[0] = namebox.Text;
                    datum[1] = tipobox.Text;
                    datum[2] = LoginClass.getdata()[0];
                    datum[3] = LoginClass.getdata()[1];
                    opcionpanel.Show();
                    namebox.Text = "";
                    tipobox.Text = "";

                }
                else
                {
                    editbutton.Enabled = false;

                }



            }
            catch (NullReferenceException pafh) {

                pafh.ToString();
                editbutton.Enabled = false;
            }

            if (show.ordensql("SELECT USER_NAME FROM USERS_TABLE WHERE `USER_NAME` = '" + namebox.Text + "';"))
            {

                editbutton.Enabled = true;
            }
            else
            {
                editbutton.Enabled = false;
            }

        }

        private void pass_MouseHover(object sender, EventArgs e)
        {

            passlabel.Show();
           
        }

        private void pass_MouseLeave(object sender, EventArgs e)
        {

            passlabel.Hide();

        }

        private void edit_MouseHover(object sender, EventArgs e)
        {
            editlabel.Show();
        }

        private void edit_MouseLeave(object sender, EventArgs e)
        {
            editlabel.Hide();
        }

        private void delete_MouseHover(object sender, EventArgs e)
        {
            deletelabel.Show();
        }

        private void delete_MouseLeave(object sender, EventArgs e)
        {
            deletelabel.Hide();
        }

        private void savedata_MouseHover(object sender, EventArgs e)
        {
            savedatalabel.Show();
        }

        private void savedata_MouseLeave(object sender, EventArgs e)
        {
            savedatalabel.Hide();
        }

        private void cargar_MouseHover(object sender, EventArgs e)
        {
            cargarlabel.Show();
        }

        private void cargar_MouseLeave(object sender, EventArgs e)
        {
            cargarlabel.Hide();
        }

        private void pass_Click(object sender, EventArgs e)
        {
            state = "change";
            userPasswordForm begin = new userPasswordForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            opcionpanel.Hide();
            
        }

        private void edit_Click(object sender, EventArgs e)
        {
            state = "edit";
            userPasswordForm begin = new userPasswordForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            opcionpanel.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            state = "delete";
            userPasswordForm begin = new userPasswordForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            opcionpanel.Hide();
        }

        private void savedata_Click(object sender, EventArgs e)
        {
            state = "save";
            userPasswordForm begin = new userPasswordForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            opcionpanel.Hide();
        }

        private void cargar_Click(object sender, EventArgs e)
        {
            state = "cargar";
            userPasswordForm begin = new userPasswordForm();
            begin.WindowState = FormWindowState.Normal;
            begin.Show();
            opcionpanel.Hide();
        }

        private void namebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";

            if (namebox.Text == "" || namebox.Text == "TODOS")
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";
            }
            else 
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table where USER_NAME='" + namebox.Text + "';";
            }
            



            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void tipobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoginClass show = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";

            if ((tipobox.Text == "" || tipobox.Text == "TODOS") )
            {
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";
            }
            else { 
                orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table where USERTIPO='" + tipobox.Text + "';";
            }
            



            show.ShowDataGridFound(findinggrid, orden);
            encontradoslabel.Text = show.getcuenta().ToString();
        }

        private void UsersShowForm_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void buttonpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void findinggrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
        private int stop;
        private void opcionpanel_MouseHover(object sender, EventArgs e)
        {
            stop = cuenta;
            cuenta = 0;
            cuenta = stop;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void finderpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
