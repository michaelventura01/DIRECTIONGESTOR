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
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            subjectverbutton.BackColor = Color.Blue;

            EmployeeClass ver = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
            ver.FillNameBox(comboasignado, orden);


            if (DireccionGestor.getorigen() == "inicio") { titlelabel.Text = "AGREGAR ASIGNATURA"; }
            else if (DireccionGestor.getorigen() == "editor")
            {
                titlelabel.Text = "MODIFICAR ASIGNATURA";
                try {
                    asignaturatextbox.Text = LoginClass.getdata()[1];
                    comboasignado.Text = LoginClass.getdata()[2];
                    descripcionbox.Text = LoginClass.getdata()[3];
                    subjectverbutton.Enabled = false;


                } catch (NullReferenceException epd) { epd.ToString(); }
                
            }
            else if (DireccionGestor.getorigen() == "buscador")
            {
                titlelabel.Text = "AGREGAR ASIGNATURA";
                subjectverbutton.Enabled = false;
            }

            ver.FillNameBox(comboasignado, orden);
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            subjectverbutton.BackColor = Color.Blue;

            EmployeeClass ver = new EmployeeClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden = "SELECT `NOMBRE COMPLETO` FROM " + UserAccessForm.getusername() + "_employee_table;";
            ver.FillNameBox(comboasignado,orden);


            if (DireccionGestor.getorigen() == "inicio") { titlelabel.Text = "AGREGAR ASIGNATURA"; }
            else if (DireccionGestor.getorigen() == "editor") {
                titlelabel.Text = "MODIFICAR ASIGNATURA";
                try {
                    asignaturatextbox.Text = ShowSubjects.getinfo()[0];
                    comboasignado.Text = ShowSubjects.getinfo()[1];
                    descripcionbox.Text = ShowSubjects.getinfo()[2];
                    subjectverbutton.Enabled = false;

                } catch (NullReferenceException epd) { epd.ToString(); }
                
            }
            else if (DireccionGestor.getorigen() == "buscador") {
                titlelabel.Text = "AGREGAR ASIGNATURA";
                subjectverbutton.Enabled = false;
            }

            ver.FillNameBox(comboasignado, orden);
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subjectverbutton_Click(object sender, EventArgs e)
        {
            ShowSubjects see = new ShowSubjects();
            see.WindowState = FormWindowState.Normal;
            see.Show();
            this.Close();

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            LoginClass ver;
            string asign;
            string orden;
            string teach;


            if (asignaturatextbox.Text == "" || comboasignado.Text == "" || descripcionbox.Text == "")
            {
                if (asignaturatextbox.Text == "") { asignaturatextbox.BackColor = Color.Red; } else { asignaturatextbox.BackColor = Color.Green; }
                if (comboasignado.Text == "") { comboasignado.BackColor = Color.Red; } else { comboasignado.BackColor = Color.Green; }
                if (descripcionbox.Text == "") { descripcionbox.BackColor = Color.Red; } else { descripcionbox.BackColor = Color.Green; }

            }
            else if (DireccionGestor.getorigen() == "inicio")
            {
                carga pap = new carga();
                pap.WindowState = FormWindowState.Normal;
                pap.Show();
                ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string complete = UserAccessForm.getusername() + "_subject_table";
                

                orden = "SELECT ASIGNATURA FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                asign=ver.takedatatable(orden,"ASIGNATURA");
                 orden = "SELECT ASIGNADO FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                teach = ver.takedatatable(orden, "ASIGNADO");
                try
                {
                    
                    if ((asign == asignaturatextbox.Text) && (teach == comboasignado.Text))
                    {

                        MessageBox.Show("LA ASIGNATURA " + asignaturatextbox.Text + " FUE ASIGNADA A " + comboasignado.Text);
                        pap.Close();

                    }
                    else
                    {
                        ver.AddSubject(asignaturatextbox.Text,comboasignado.Text,descripcionbox.Text,UserAccessForm.getusername());
                        
                        pap.Close();
                        MessageBox.Show("ASIGNATURA " + asignaturatextbox.Text + " HA SIDO CREADA");
                        ShowSubjects.setchange("modify");
                        this.Close();
                    }
                }
                catch (NullReferenceException PAP)
                {
                    PAP.ToString();
                    pap.Close();
                    MessageBox.Show("ASIGNATURA " + asignaturatextbox.Text + " HA SIDO CREADA");
                    ShowSubjects.setchange("modify");
                    this.Close();

                }

            }

            else if (DireccionGestor.getorigen() == "editor")
            {
                carga pap = new carga();
                pap.WindowState = FormWindowState.Normal;
                pap.Show();
                ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string complete = UserAccessForm.getusername() + "_subject_table";
                orden = "SELECT * FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";

                orden = "SELECT ASIGNATURA FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                asign = ver.takedatatable(orden, "ASIGNATURA");
                orden = "SELECT ASIGNADO FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                teach = ver.takedatatable(orden, "ASIGNADO");
                if ((asign == asignaturatextbox.Text) && (teach == comboasignado.Text))
                {
                    pap.Close();
                    MessageBox.Show("LA ASIGNATURA " + asignaturatextbox.Text + " FUE ASIGNADA A " + comboasignado.Text);


                }
                else
                {

                    orden = "RENAME TABLE `" + LoginClass.getdata()[1] + "_" + UserAccessForm.getusername() + "_evaluation_student_table` TO `" + asignaturatextbox.Text + "_" + UserAccessForm.getusername() + "_evaluation_student_table`;";
                    ver.ordensql(orden);
                    orden = "RENAME TABLE `" + LoginClass.getdata()[1] + "_" + UserAccessForm.getusername() + "_calification_student_table` TO `" + asignaturatextbox.Text + "_" + UserAccessForm.getusername() + "_calification_student_table`;";
                    ver.ordensql(orden);
                    complete = UserAccessForm.getusername() + "_subject_table";
                    ver.editSubject(asignaturatextbox.Text, comboasignado.Text, descripcionbox.Text, LoginClass.getdata()[1], LoginClass.getdata()[2], UserAccessForm.getusername());
                    pap.Close();
                    MessageBox.Show("ASIGNATURA " + LoginClass.getdata()[1] + " HA SIDO EDITADA");
                    ShowSubjects.setchange("modify");
                    this.Close();
                }

            }
            else if (DireccionGestor.getorigen() == "buscador")
            {
                carga pap = new carga();
                pap.WindowState = FormWindowState.Normal;
                pap.Show();
                ver = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string complete = UserAccessForm.getusername() + "_subject_table";


                orden = "SELECT ASIGNATURA FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                asign = ver.takedatatable(orden, "ASIGNATURA");
                orden = "SELECT ASIGNADO FROM " + complete + " WHERE ASIGNATURA='" + asignaturatextbox.Text + "' and ASIGNADO='" + comboasignado.Text + "';";
                teach = ver.takedatatable(orden, "ASIGNADO");
                try
                {

                    if ((asign == asignaturatextbox.Text) && (teach == comboasignado.Text))
                    {

                        MessageBox.Show("LA ASIGNATURA " + asignaturatextbox.Text + " FUE ASIGNADA A " + comboasignado.Text);
                        pap.Close();

                    }
                    else
                    {
                        ver.AddSubject(asignaturatextbox.Text, comboasignado.Text, descripcionbox.Text, UserAccessForm.getusername());
                        MessageBox.Show("ASIGNATURA " + asignaturatextbox.Text + " HA SIDO CREADA");
                        ShowSubjects.setchange("modify");
                        this.Close();
                    }
                }
                catch (NullReferenceException PAP)
                {
                    PAP.ToString();
                    pap.Close();
                    MessageBox.Show("ASIGNATURA " + asignaturatextbox.Text + " HA SIDO CREADA");
                    ShowSubjects.setchange("modify");
                    this.Close();

                }

            }
        }
        

        private int cuenta;

        private void timer_Tick(object sender, EventArgs e)
        {
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                cancelbutton.PerformClick();
            }

        }

        private void AddSubject_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
