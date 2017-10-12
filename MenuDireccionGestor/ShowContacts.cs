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
    public partial class ShowContacts : Form
    {
        public ShowContacts()
        {
            InitializeComponent();
        }

        private void ShowContacts_Load(object sender, EventArgs e)
        {
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
            string orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM "+UserAccessForm.getusername()+"_contacts_table;";
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGridFound(dataGrid,orden);
            cuentalabel.Text = ver.getcuenta().ToString();
            orden = "SELECT distinct NOMBRE FROM " + UserAccessForm.getusername() + "_contacts_table;";
            ver.Fillcombo(namecombo,orden);
            orden = "SELECT distinct TELEFONO FROM " + UserAccessForm.getusername() + "_contacts_table;";
            ver.Fillcombo(telefonocombo, orden);
        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarbutton_Click(object sender, EventArgs e)
        {
            telefonocombo.Text = "";
            namecombo.Text = "";
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
            string orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table;";
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = ver.getcuenta().ToString();
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("editor");
            dataout = new string[5];
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_employee_table";
            
            string orden = "SELECT * FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='" + namecombo.Text + "';";
            if (ver.fillcombos(namecombo, telefonocombo, orden))
            {
                editbutton.Enabled = true;
                quitarbutton.Enabled = true;

                try
                {
                    dataout[0] = namecombo.Text;
                    dataout[1] = telefonocombo.Text;
                    dataout[2] = LoginClass.getdata()[0];
                    dataout[3] = LoginClass.getdata()[1];
                    dataout[4] = LoginClass.getdata()[2];

                    DireccionGestor.setorigen("editor");
                    addContact add = new addContact();
                    add.WindowState = FormWindowState.Normal;
                    add.Show();
                }
                catch (IndexOutOfRangeException por)
                {
                    por.ToString();

                }
                this.Close();
            }
            else
            {

                editbutton.Enabled = false;
                quitarbutton.Enabled = false;

            }

        }

        private void agregarbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");
            addContact add = new addContact();
            add.WindowState = FormWindowState.Normal;
            add.Show();
            this.Close();
        }

        private void buscarbutton_Click(object sender, EventArgs e)
        {
            string orden = "";
            if (namecombo.Text=="") {orden= "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table WHERE TELEFONO='"+telefonocombo.Text+"';"; }
            else if (telefonocombo.Text=="") { orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='" + namecombo.Text + "';"; }
            else { orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='" + namecombo.Text + "' AND TELEFONO='"+telefonocombo.Text+"';"; }
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = ver.getcuenta().ToString();

        }


        private static string[] dataout;
        public static string[] getdataout() { return dataout; }
        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                dataout = new string[5];
                LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string dato = this.dataGrid.CurrentCell.Value.ToString();

                string orden = "SELECT * FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='" + dato + "';";
                if (ver.fillcombos(namecombo, telefonocombo, orden))
                {
                    editbutton.Enabled = true;
                    quitarbutton.Enabled = true;
                    dataout[0] = namecombo.Text;
                    dataout[1] = telefonocombo.Text;
                    dataout[2] = LoginClass.getdata()[0];
                    dataout[3] = LoginClass.getdata()[1];
                    dataout[4] = LoginClass.getdata()[2];
                }
                else
                {

                    editbutton.Enabled = false;
                    quitarbutton.Enabled = false;

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                
                dataout = new string[5];
                LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string dato = this.dataGrid.CurrentCell.Value.ToString();

                string orden = "SELECT * FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='" + dato + "';";
                if (ver.fillcombos(namecombo, telefonocombo, orden))
                {
                    editbutton.Enabled = true;
                    quitarbutton.Enabled = true;

                    try
                    {
                        dataout[0] = namecombo.Text;
                        dataout[1] = telefonocombo.Text;
                        dataout[2] = LoginClass.getdata()[0];
                        dataout[3] = LoginClass.getdata()[1];
                        dataout[4] = LoginClass.getdata()[2];

                        DireccionGestor.setorigen("editor");
                        addContact add = new addContact();
                        add.WindowState = FormWindowState.Normal;
                        add.Show();
                    }
                    catch (IndexOutOfRangeException por)
                    {
                        por.ToString();

                    }
                    this.Close();
                }
                else
                {

                    editbutton.Enabled = false;
                    quitarbutton.Enabled = false;

                }
            }
            catch (NullReferenceException pafh) { pafh.ToString(); }

           
        }

        private void quitarbutton_Click(object sender, EventArgs e)
        {
            
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            
            string orden = "DELETE FROM " + UserAccessForm.getusername() + "_contacts_table WHERE ID='" + dataout[4] + "';";

            ver.ordensql(orden);
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
             orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table;";
            ver.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = ver.getcuenta().ToString();
            namecombo.Text = "";
            telefonocombo.Text = "";
            MessageBox.Show("CONTACTO ELIMINADO");


        }

        private void namecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table WHERE NOMBRE='"+namecombo.Text+"'; ";
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = ver.getcuenta().ToString();
        }

        private void telefonocombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string orden = "SELECT NOMBRE,TELEFONO,DIRECCION,EMAIL FROM " + UserAccessForm.getusername() + "_contacts_table WHERE TELEFONO='" + telefonocombo.Text + "'; ";
            LoginClass ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGridFound(dataGrid, orden);
            cuentalabel.Text = ver.getcuenta().ToString();
        }

        private void dataGrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void ShowContacts_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
