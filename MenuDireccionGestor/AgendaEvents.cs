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
    public partial class AgendaEvents : Form
    {
        public AgendaEvents()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeClass timeobject = new TimeClass();
            //hourlabel.Text = timeobject.clockshapeshort();
            //datelabel.Text = timeobject.dateshape();

            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;



        private void backbuttonstrip_Click(object sender, EventArgs e)
        {

            if (DireccionGestor.getorigen()=="agregador") {
                agendaAdd agendaobject = new agendaAdd();
                agendaobject.WindowState = FormWindowState.Normal;
                agendaobject.Show();

            }
             

            this.Close();

            
        }

        private void menutrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AgendaEvents_Load(object sender, EventArgs e)
        {
            control.Hide();
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
            activobox.Text = "SI";
            AgendaClass ver = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            ver.ShowDataGrid(dataGridView1, UserAccessForm.getusername());
            ver = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            string orden = "SELECT `DESCRIPCION` FROM " + UserAccessForm.getusername() + "_events_table ORDER BY PRIORIDAD ASC;";

            ver.Fillcombo(comboeventoname,orden);
            cuentalabel.Text = ver.getcuenta().ToString();
        }

        private void limpiarbutton_Click(object sender, EventArgs e)
        {
            comboeventoname.Text = "";
            activobox.Text = "";
            timebox.Text = DateTime.Now.TimeOfDay.ToString();
            fechabox.Text = DateTime.Now.TimeOfDay.ToString();
            AgendaClass show = new AgendaClass();
            
            show.ShowDataGrid(dataGridView1, UserAccessForm.getusername());
            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void buscarbutton_Click(object sender, EventArgs e)
        {
            string fechacontrol = control.Value.Day.ToString() + "/" + control.Value.Month.ToString() + "/" + control.Value.Year.ToString();
            string horacontrol = control.Value.Hour.ToString() + ":" + control.Value.Minute.ToString() + ":" + control.Value.Second.ToString();
            string fechacontrolshort = control.Value.Day.ToString() + "/" + control.Value.Month.ToString();
            string fecha=fechabox.Value.Day.ToString()+"/"+ fechabox.Value.Month.ToString() + "/" + fechabox.Value.Year.ToString();
            string fechashort = fechabox.Value.Day.ToString() + "/" + fechabox.Value.Month.ToString();
            string hora=timebox.Value.Hour.ToString()+":"+ timebox.Value.Minute.ToString() + ":" + timebox.Value.Second.ToString();
            AgendaClass show = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_events_table";
            string orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where (`DESCRIPCION` = '" + comboeventoname.Text + "' or FECHA ='"+fecha+"' or HORA ='"+hora+"' or `FECHA DE RECORDATORIO`='"+fechashort+"')AND ACTIVO ='"+activobox.Text+"'  ORDER BY PRIORIDAD ASC;";

            if (fecha == fechacontrol || fechashort == fechacontrolshort)
            {
                orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where (`DESCRIPCION` = '" + comboeventoname.Text + "'  or HORA ='" + hora + "' )AND ACTIVO ='" + activobox.Text + "'  ORDER BY PRIORIDAD ASC;";



            }
            else if (hora == horacontrol)
            {
                orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where (`DESCRIPCION` = '" + comboeventoname.Text + "' or FECHA ='" + fecha + "' or `FECHA DE RECORDATORIO`='" + fechashort + "')AND ACTIVO ='" + activobox.Text + "'  ORDER BY PRIORIDAD ASC;";

            }
            else if (fecha == fechacontrol || fechashort == fechacontrolshort || hora == horacontrol)
            {
                orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where (`DESCRIPCION` = '" + comboeventoname.Text + "')AND ACTIVO ='" + activobox.Text + "' ORDER BY PRIORIDAD ASC;";

            }
            else {

                orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where (`DESCRIPCION` = '" + comboeventoname.Text + "' or FECHA ='" + fecha + "' or HORA ='" + hora + "' or `FECHA DE RECORDATORIO`='" + fechashort + "')AND ACTIVO ='" + activobox.Text + "'  ORDER BY PRIORIDAD ASC;";

            }

            show.ShowDataGridfound(dataGridView1, orden);

            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void activobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            AgendaClass show = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_events_table";
            string orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where  ACTIVO ='" + activobox.Text + "'  ORDER BY PRIORIDAD ASC;";
            
            show.ShowDataGridfound(dataGridView1, orden);

            if (activobox.Text == "NO") { quitarbutton.Enabled = false; }
            else { quitarbutton.Enabled = true; }
            cuentalabel.Text = show.getcuenta().ToString();

        }

        private void agregarbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("buscador");
            agendaAdd agendaobject = new agendaAdd();
            agendaobject.WindowState = FormWindowState.Normal;
            agendaobject.Show();
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                AgendaClass show = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_events_table";
                string dato = this.dataGridView1.CurrentCell.Value.ToString();
                comboeventoname.Text = dato;
                string orden = "select * from " + userDataName + " where `DESCRIPCION` = '" + comboeventoname.Text + "' ORDER BY PRIORIDAD ASC;";
                show.fillboxes(comboeventoname, fechabox, activobox, timebox, orden);

                if (activobox.Text == "NO") {
                    quitarbutton.Enabled = false;
                }
                else {
                    quitarbutton.Enabled = true;
                }

                if (comboeventoname.Text != "")
                {
                    editbutton.Enabled = true;
                }
                else
                {
                    editbutton.Enabled = false;
                }

                DireccionGestor.setsombrestatic(comboeventoname.Text);
                DireccionGestor.setotrostatic(fechabox.Value.Day.ToString() + "/" + fechabox.Value.Month.ToString() + "/" + fechabox.Value.Year.ToString());
                
            }
            catch (NullReferenceException pafh) { pafh.ToString(); }

        }

        private void quitarbutton_Click(object sender, EventArgs e)
        {
            if (quitarbutton.Text == "NO")
            {
                MessageBox.Show("LA TAREA DEBE DE ESTAR ACTIVA");
            } else if (comboeventoname.Text=="") {
                MessageBox.Show("DEBE SELECCIONAR UNA TAREA PARA DESACTIVAR");
            }
            else {




                string userdataname = UserAccessForm.getusername() + "_events_table";

                string orden = "UPDATE " + userdataname + " SET ACTIVO = 'NO' WHERE  `DESCRIPCION`= '" + comboeventoname.Text + "';";
                AgendaClass kit = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                kit.ordensql(orden);
                MessageBox.Show("TAREA DESACTIVADA");
                kit.ShowDataGrid(dataGridView1, UserAccessForm.getusername());


            }
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            if (comboeventoname.Text=="") {

                MessageBox.Show("DEBE SELECCIONAR UNA TAREA PARA EDITAR");
            } else { 

            DireccionGestor.setsombrestatic(comboeventoname.Text);
            DireccionGestor.setotrostatic(fechabox.Value.Day.ToString() + "/" + fechabox.Value.Month.ToString() + "/" + fechabox.Value.Year.ToString());
            DireccionGestor.setorigen("modificar");
            agendaAdd agendaobject = new agendaAdd();
            agendaobject.WindowState = FormWindowState.Normal;
            agendaobject.Show();
            }

        }

        private void comboeventoname_SelectedIndexChanged(object sender, EventArgs e)
        {
            AgendaClass show = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_events_table";
            string orden = "select DESCRIPCION, `FECHA DE RECORDATORIO`, HORA from " + userDataName + " where  DESCRIPCION= '"+comboeventoname.Text+"' AND ACTIVO ='" + activobox.Text + "'  ORDER BY PRIORIDAD ASC;";

            show.ShowDataGridfound(dataGridView1, orden);
 
            
            cuentalabel.Text = show.getcuenta().ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void control_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void AgendaEvents_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
