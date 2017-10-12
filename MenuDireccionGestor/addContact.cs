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
    public partial class addContact : Form
    {
        public addContact()
        {
            InitializeComponent();
        }

        private void addContact_Load(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio" || DireccionGestor.getorigen() == "buscador")
            {
                titlelabel.Text = "AGREGAR CONTACTO";
            }
            else {

                titlelabel.Text = "EDITAR CONTACTO";
                if (DireccionGestor.getorigen() == "editor") {
                    nombrebox.Text = ShowContacts.getdataout()[0];
                    telefonobox.Text= ShowContacts.getdataout()[1];
                    direccionbox.Text = ShowContacts.getdataout()[2];
                    emailbox.Text = ShowContacts.getdataout()[3];

                }
            }
            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            contactsverbutton.BackColor = Color.Blue;
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            
                if (DireccionGestor.getorigen() == "editor" || DireccionGestor.getorigen() == "buscador")
                {

                    ShowContacts pop = new ShowContacts();
                    pop.WindowState = FormWindowState.Normal;
                    pop.Show();
                    this.Close();

                }
                else { this.Close(); }
            
        }

        private void contactsverbutton_Click(object sender, EventArgs e)
        {
            cuenta = 0;
            ShowContacts show = new ShowContacts();
            show.WindowState = FormWindowState.Normal;
            show.Show();
            this.Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            cuenta = 0;
            carga ca = new carga();
            ca.WindowState = FormWindowState.Normal;
            ca.Show();
            if (DireccionGestor.getorigen() == "inicio")
            {
                if (nombrebox.Text == "" || telefonobox.Text == "")
                {
                    if (nombrebox.Text == "") { nombrebox.BackColor = Color.Red; } else { nombrebox.BackColor = Color.Green; }
                    if (telefonobox.Text == "") { telefonobox.BackColor = Color.Red; } else { telefonobox.BackColor = Color.Green; }
                    MessageBox.Show("HAY CAMPOS CLAVES VACIOS");
                }
                else
                {
                    if (direccionbox.Text == "") { direccionbox.Text = "NINGUNA"; }
                    if (emailbox.Text == "") { emailbox.Text = "NINGUNA"; }

                    try
                    {
                        LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        add.AddContact(nombrebox.Text, telefonobox.Text, direccionbox.Text, emailbox.Text, UserAccessForm.getusername().ToString());
                        MessageBox.Show("NUEVO CONTACTO " + nombrebox.Text + " AGREGADO");

                        if (MessageBox.Show("Agregar a otro empleado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            add = new LoginClass();


                            this.Close();
                        }
                        else
                        {
                            add = new LoginClass();

                            addContact menu = new addContact();
                            menu.WindowState = FormWindowState.Normal;
                            menu.Show();
                            this.Close();
                        }

                    }
                    catch (FormatException datethis) { datethis.ToString(); }
                }
            }
            else if (DireccionGestor.getorigen() == "editor")
            {

                try
                {
                    LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    add.ordensql("UPDATE " + UserAccessForm.getusername() + "_contacts_table SET NOMBRE='" + nombrebox.Text + "', TELEFONO='" + telefonobox.Text + "', DIRECCION='" + direccionbox.Text + "', EMAIL='" + emailbox.Text + "' WHERE ID='" + ShowContacts.getdataout()[4] + "';");
                    MessageBox.Show("CONTACTO " + DireccionGestor.getnombrestatic() + " EDITADO");

                    ShowContacts show = new ShowContacts();
                    show.WindowState = FormWindowState.Normal;
                    show.Show();
                    this.Close();
                }
                catch (FormatException datethis) { datethis.ToString(); }
                catch (IndexOutOfRangeException oper) { oper.ToString(); }
            }
            else if (DireccionGestor.getorigen() == "buscador")
            {

                if (nombrebox.Text == "" || telefonobox.Text == "")
                {
                    if (nombrebox.Text == "") { nombrebox.BackColor = Color.Red; } else { nombrebox.BackColor = Color.Green; }
                    if (telefonobox.Text == "") { telefonobox.BackColor = Color.Red; } else { telefonobox.BackColor = Color.Green; }
                    MessageBox.Show("HAY CAMPOS CLAVES VACIOS");
                }
                else
                {
                    if (direccionbox.Text == "") { direccionbox.Text = "NINGUNA"; }
                    if (emailbox.Text == "") { emailbox.Text = "NINGUNA"; }

                    try
                    {
                        LoginClass add = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        add.AddContact(nombrebox.Text, telefonobox.Text, direccionbox.Text, emailbox.Text, UserAccessForm.getusername().ToString());
                        MessageBox.Show("NUEVO CONTACTO " + nombrebox.Text + " AGREGADO");

                        if (MessageBox.Show("Agregar a otro empleado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            add = new LoginClass();

                            ShowContacts ad = new ShowContacts();
                            ad.WindowState = FormWindowState.Normal;
                            ad.Show();
                            this.Close();
                        }
                        else
                        {
                            add = new LoginClass();

                            addContact menu = new addContact();
                            menu.WindowState = FormWindowState.Normal;
                            menu.Show();
                            this.Close();
                        }

                    }
                    catch (FormatException datethis) { datethis.ToString(); }
                }

            }


                ca.Close();
        }

        private void telefonobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No Se Permiten Espacios en Blanco");

            }

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo es para Introducir un Numero de Telefono");

            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo es para Introducir un Numero de Telefono");

            }
        }

        private void nombrebox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void telefonobox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void nombrebox_Click(object sender, EventArgs e)
        {
            nombrebox.BackColor = Color.White;
            cuenta = 0;
        }

        private void telefonobox_Click(object sender, EventArgs e)
        {
            telefonobox.BackColor = Color.White;
            cuenta = 0;
        }

        private int cuenta;
        private void timer_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta==3000) {

                cuenta = 0;
                cancelbutton.PerformClick();
            }
        }

        private void addContact_Click(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void direccionbox_Click(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void emailbox_Click(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void addContact_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
