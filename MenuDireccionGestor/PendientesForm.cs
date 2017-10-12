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
    public partial class PendientesForm : Form
    {
        public PendientesForm()
        {
            InitializeComponent();
        }

        private string entrada = "";
        private void PendientesForm_Load(object sender, EventArgs e)
        {
            panelpad.Hide();
            tipobox.Text = "DOP";
            tipo.Text = "DOP";
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());


            if (DireccionGestor.getorigen() == "_payfor_table")
            {


                titlelabel.Text = "CUENTAS POR PAGAR";
                changelabel.Text = "CUENTAS POR COBRAR";
                palpad.BackColor = Color.Blue;
                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";

                AP.ShowDataGridfound(datagrid, orden);

                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

                string orden2 = "SELECT COBRADOR FROM  " + UserAccessForm.getusername() + "_payfor_table ;";

                AP.Fillcombo(namecombo, orden2);
                panelpad.BackColor = Color.MidnightBlue;
            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                titlelabel.Text = "CUENTAS POR COBRAR";
                changelabel.Text = "CUENTAS POR PAGAR";
                palpad.BackColor = Color.Red;
                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";

                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR DEUDOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                string orden2 = "SELECT COBRADOR FROM  " + UserAccessForm.getusername() + "_payfor_table ;";

                AP.Fillcombo(namecombo, orden2);
                panelpad.BackColor = Color.DarkRed;
            }
        }

        private void panelpad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            panelpad.Hide();
            openpad = false;
        }
        private bool openpad;
        private void agregarbutton_Click(object sender, EventArgs e)
        {
            entrada = "agregar";
            openpad = true;
            panelpad.Show();
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            entrada = "editar";
            string date = fechabox.Value.Day.ToString() + "/" + fechabox.Value.Month.ToString() + "/" + fechabox.Value.Year.ToString();
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());


            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                titlepanel.Text = "EDITAR CUENTA POR PAGAR";
                string orden = "SELECT * FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND  COBRADOR='" + namecombo.Text + "' AND MONTO='" + cantidadbox.Text + "' AND FECHA='" + date + "';";


                AP.ShowDataGridfound(datagrid, orden);
                id = MovementsClass.getdato()[0];
                name.Text = MovementsClass.getdato()[1];
                fecha.Text = MovementsClass.getdato()[2];

                monto.Text = MovementsClass.getdato()[3];
                tipo.Text = MovementsClass.getdato()[4];
                panelpad.Show();
                entrada = "editar";
                openpad = true;


            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                titlepanel.Text = "EDITAR CUENTA POR COBRAR";
                string orden = "SELECT * FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND  COBRADOR='" + namecombo.Text + "' AND MONTO='" + cantidadbox.Text + "' AND FECHA='" + date + "';";

                AP.ShowDataGridfound(datagrid, orden);

                id = MovementsClass.getdato()[0];
                name.Text = MovementsClass.getdato()[1];
                fecha.Text = MovementsClass.getdato()[2];

                monto.Text = MovementsClass.getdato()[3];
                tipo.Text = MovementsClass.getdato()[4];

                panelpad.Show();
                entrada = "editar";
                openpad = true;
            }
           
        }

    
          

        private void OKbutton_Click(object sender, EventArgs e)
        {
            string date = fecha.Value.Day.ToString() + "/" + fecha.Value.Month.ToString() + "/" + fecha.Value.Year.ToString();
            openpad = false;
            panelpad.Show();
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                titlelabel.Text = "CUENTAS POR PAGAR";
                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();


                ////////////////////////////////////////////////////////////


                if (entrada == "agregar")
                {

                    if (name.Text == "" || monto.Text == "")
                    {

                        MessageBox.Show("Hay datos importantes vacios, termine el formulario.");



                        if (name.Text == "") { name.BackColor = Color.Red; }
                        else { name.BackColor = Color.Green; }

                        if (monto.Text == "") { monto.BackColor = Color.Red; }
                        else { monto.BackColor = Color.Green; }



                    }
                    else
                    {


                        try
                        {

                            MovementsClass ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());


                            date = fecha.Value.Day.ToString() + "/" + fecha.Value.Month.ToString() + "/" + fecha.Value.Year.ToString();
                            double montos = double.Parse(monto.Text);


                            if (ad.AddCountPayFor(name.Text, date, montos, tipobox.Text, UserAccessForm.getusername()))
                            {

                                MessageBox.Show("NUEVO CUENTA POR PAGAR EL " + date + " AGREGADA.");

                                if (MessageBox.Show("Agregar otra cuenta por pagar?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    ad = new MovementsClass();
                                    panelpad.Hide();
                                }
                                else
                                {
                                    ad = new MovementsClass();
                                    name.Text = "";
                                    tipo.Text = "DOP";
                                    monto.Text = "";
                                    fecha.Text = DateTime.Now.ToString();
                                }
                            }
                            else
                            {

                                MessageBox.Show("NUEVO CUENTA POR PAGAR EL " + date + " AGREGADA.");

                                if (MessageBox.Show("Agregar otra cuenta por pagar?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    ad = new MovementsClass();
                                    panelpad.Hide();
                                }
                                else
                                {
                                    ad = new MovementsClass();
                                    name.Text = "";
                                    tipo.Text = "DOP";
                                    monto.Text = "";
                                    fecha.Text = DateTime.Now.ToString();
                                }
                            }

                            
                            orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                            MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                            Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

                        }
                        catch (FormatException datethis) { datethis.ToString(); }
                    }
                    limpiarbutton.PerformClick();
                }
                else if (entrada == "editar")
                {
                    MovementsClass mc = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "UPDATE "+UserAccessForm.getusername()+"_payfor_table SET COBRADOR='"+name.Text+"', FECHA='"+date+"', CANTIDAD='"+monto.Text+"', `TIPO MONEDA`='"+tipo.Text+"' WHERE ID = '"+id+"'";
                    mc.ordensql(orden);
                    panelpad.Hide();
                    orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox + "';";
                    AP.ShowDataGridfound(datagrid, orden);
                    encontradolabel.Text = AP.getcuenta().ToString();
                    MessageBox.Show("COBRADOR " + MovementsClass.getdato()[1] + " EDITADO");
                }

                ////////////////////////////////////////////////////////////
            }

            else if (DireccionGestor.getorigen() == "_askfor_table")
            {

                titlelabel.Text = "CUENTAS POR COBRAR";
                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();


                ////////////////////////////////////////////////////////////


                if (entrada == "agregar")
                {

                    if (name.Text == "" || monto.Text == "")
                    {

                        MessageBox.Show("Hay datos importantes vacios, termine el formulario.");



                        if (name.Text == "") { name.BackColor = Color.Red; }
                        else { name.BackColor = Color.Green; }

                        if (monto.Text == "") { monto.BackColor = Color.Red; }
                        else { monto.BackColor = Color.Green; }



                    }
                    else
                    {


                        try
                        {

                            MovementsClass ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());


                            date = fecha.Value.Day.ToString() + "/" + fecha.Value.Month.ToString() + "/" + fecha.Value.Year.ToString();
                            double montos = double.Parse(monto.Text);


                            if (ad.AddCountAskFor(name.Text, date, montos, tipobox.Text, UserAccessForm.getusername()))
                            {

                                MessageBox.Show("NUEVA CUENTA POR COBRAR EL " + date + " AGREGADA.");

                                if (MessageBox.Show("Agregar otra cuenta por cobrar?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    ad = new MovementsClass();
                                    panelpad.Hide();
                                }
                                else
                                {
                                    ad = new MovementsClass();
                                    name.Text = "";
                                    tipo.Text = "DOP";
                                    monto.Text = "";
                                    fecha.Text = DateTime.Now.ToString();
                                }
                            }
                            else
                            {

                                MessageBox.Show("NUEVO CUENTA POR COBRAR EL " + date + " AGREGADA.");

                                if (MessageBox.Show("Agregar otra cuenta por cobrar?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    ad = new MovementsClass();
                                    panelpad.Hide();
                                }
                                else
                                {
                                    ad = new MovementsClass();
                                    name.Text = "";
                                    tipo.Text = "DOP";
                                    monto.Text = "";
                                    fecha.Text = DateTime.Now.ToString();
                                }
                            }

                            orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                            MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                            Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                        }
                        catch (FormatException datethis) { datethis.ToString(); }
                    }
                    limpiarbutton.PerformClick();
                }
                else if (entrada == "editar")
                {
                    MovementsClass mc = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                    orden = "UPDATE " + UserAccessForm.getusername() + "_askfor_table SET DEUDOR='" + name.Text + "', FECHA='" + date + "', CANTIDAD='" + monto.Text + "', `TIPO MONEDA`='" + tipo.Text + "' WHERE ID = '" + id + "'";

                    mc.ordensql(orden);
                    panelpad.Hide();
                    orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox + "';";
                    AP.ShowDataGridfound(datagrid, orden);
                    encontradolabel.Text = AP.getcuenta().ToString();
                    MessageBox.Show("DEUDOR "+MovementsClass.getdato()[1]+" EDITADO");
                }

                ////////////////////////////////////////////////////////////

            }

            limpiarbutton.PerformClick();
        }

        private void limpiarbutton_Click(object sender, EventArgs e)
        {
            if (openpad)
            {
                name.Text = "";
                tipo.Text = "DOP";
                monto.Text = "";
                fecha.Text = DateTime.Now.ToString();
            }
            else
            {
                namecombo.Text = "";
                cantidadbox.Text = "";
                fechabox.Text = DateTime.Now.ToString();
                tipobox.Text = "DOP";
                LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                editbutton.Enabled = false;
                quitarbutton.Enabled = false;
                if (DireccionGestor.getorigen() == "_payfor_table")
                {
                    titlelabel.Text = "CUENTAS POR PAGAR";
                    string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";

                    AP.ShowDataGridfound(datagrid, orden);

                    encontradolabel.Text = AP.getcuenta().ToString();
                    titlepanel.Text = "AGREGAR COBRADOR";
                    panelpad.BackColor = Color.MidnightBlue;
                    orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                    MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

                }
                else if (DireccionGestor.getorigen() == "_askfor_table")
                {
                    titlelabel.Text = "CUENTAS POR COBRAR";
                    string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";

                    AP.ShowDataGridfound(datagrid, orden);
                    encontradolabel.Text = AP.getcuenta().ToString();
                    titlepanel.Text = "AGREGAR DEUDOR";
                    panelpad.BackColor = Color.DarkRed;
                    orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                    MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                    Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

                }
            }

        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void changelabel_Click(object sender, EventArgs e)
        {
            panelpad.Hide();
            tipobox.Text = "DOP";
            tipo.Text = "DOP";
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;




            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                namecombo.Text = "";
                cantidadbox.Text = "";
                palpad.BackColor = Color.Red;
                DireccionGestor.setorigen("_askfor_table");
                titlelabel.Text = "CUENTAS POR COBRAR";
                changelabel.Text = "CUENTAS POR PAGAR";
                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR DEUDOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");
                AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden2 = "SELECT DEUDOR FROM  " + UserAccessForm.getusername() + "_askfor_table ;";

                AP.Fillcombo(namecombo, orden2);
                panelpad.BackColor = Color.DarkRed;
                
            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                namecombo.Text = "";
                cantidadbox.Text = "";
                palpad.BackColor = Color.Blue;
                DireccionGestor.setorigen("_payfor_table");
                titlelabel.Text = "CUENTAS POR PAGAR";
                changelabel.Text = "CUENTAS POR COBRAR";
                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                panelpad.BackColor = Color.MidnightBlue;
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");
                AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string orden2 = "SELECT COBRADOR FROM  " + UserAccessForm.getusername() + "_payfor_table ;";

                AP.Fillcombo(namecombo, orden2);

            }
        }

        private void palpad_Click(object sender, EventArgs e)
        {
            panelpad.Hide();
            tipobox.Text = "DOP";
            tipo.Text = "DOP";
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            editbutton.Enabled = false;
            quitarbutton.Enabled = false;
            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                palpad.BackColor = Color.Red;
                DireccionGestor.setorigen("_askfor_table");
                titlelabel.Text = "CUENTAS POR COBRAR";
                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR DEUDOR";
                panelpad.BackColor = Color.DarkRed;
                changelabel.Text = "CUENTAS POR PAGAR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                palpad.BackColor = Color.Blue;
                DireccionGestor.setorigen("_payfor_table");
                titlelabel.Text = "CUENTAS POR PAGAR";
                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                AP.ShowDataGridfound(datagrid, orden);
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                panelpad.BackColor = Color.MidnightBlue;
                changelabel.Text = "CUENTAS POR COBRAR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "';";
                MovementsClass Ad = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

                Ad.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

            }
        }
        private string id;
        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string dato = this.datagrid.CurrentCell.Value.ToString();


                if (DireccionGestor.getorigen() == "_payfor_table")
                {
                    string userDataName = UserAccessForm.getusername() + "_payfor_table";

                    namecombo.Text = dato;
                    string orden = "select * from " + userDataName + " where COBRADOR='" + dato + "';";

                    if (show.Fillbuscadorpagador(orden))
                    {
                        id = MovementsClass.getdato()[0];
                        namecombo.Text = MovementsClass.getdato()[1];
                        fechabox.Text = MovementsClass.getdato()[2];

                        cantidadbox.Text = MovementsClass.getdato()[3];
                        tipobox.Text = MovementsClass.getdato()[4];
                        editbutton.Enabled = true;
                        quitarbutton.Enabled = true;
                    }
                    else
                    {
                        editbutton.Enabled = false;
                        quitarbutton.Enabled = false;
                        namecombo.Text = "";
                        tipobox.Text = "DOP";
                        cantidadbox.Text = "";
                        fechabox.Text = DateTime.Now.ToString();

                    }
                }
                else if (DireccionGestor.getorigen() == "_askfor_table")
                {
                    string userDataName = UserAccessForm.getusername() + "_askfor_table";
                    namecombo.Text = dato;
                    string orden = "select * from " + userDataName + " where  DEUDOR='" + dato + "' ; ";
                    if (show.Fillbuscadorcobrador(orden))
                    {
                        id = MovementsClass.getdato()[0];
                        namecombo.Text = MovementsClass.getdato()[1];
                        fechabox.Text = MovementsClass.getdato()[2];

                        cantidadbox.Text = MovementsClass.getdato()[3];
                        tipobox.Text = MovementsClass.getdato()[4];
                        editbutton.Enabled = true;
                        quitarbutton.Enabled = true;
                    }
                    else
                    {
                        editbutton.Enabled = false;
                        quitarbutton.Enabled = false;
                        namecombo.Text = "";
                        tipobox.Text = "DOP";
                        cantidadbox.Text = "";
                        fechabox.Text = DateTime.Now.ToString();
                    }

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void datagrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string dato = this.datagrid.CurrentCell.Value.ToString();

                namecombo.Text = dato;
                if (DireccionGestor.getorigen() == "_payfor_table")
                {
                    string userDataName = UserAccessForm.getusername() + "_payfor_table";

                    string orden = "select * from " + userDataName + " where COBRADOR='" + dato + "' ;";
                    if (show.Fillbuscadorpagador(orden))
                    {

                        id = MovementsClass.getdato()[0];
                        namecombo.Text = MovementsClass.getdato()[1];
                        fechabox.Text = MovementsClass.getdato()[2];

                        cantidadbox.Text = MovementsClass.getdato()[3];
                        tipobox.Text = MovementsClass.getdato()[4];


                        name.Text = MovementsClass.getdato()[1];
                        fecha.Text = MovementsClass.getdato()[2];

                        monto.Text = MovementsClass.getdato()[3];
                        tipo.Text = MovementsClass.getdato()[4];
                        editbutton.PerformClick();
                    }
                    else
                    {
                        editbutton.Enabled = false;
                        quitarbutton.Enabled = false;
                        namecombo.Text = "";
                        tipobox.Text = "DOP";
                        cantidadbox.Text = "";
                        fechabox.Text = DateTime.Now.ToString();
                    }
                }
                else if (DireccionGestor.getorigen() == "_askfor_table")
                {
                    string userDataName = UserAccessForm.getusername() + "_askfor_table";
                    namecombo.Text = dato;
                    string orden = "select * from " + userDataName + " where DEUDOR='" + dato + "' ; ";
                    if (show.Fillbuscadorcobrador(orden))
                    {
                        entrada = "editar";
                        id = MovementsClass.getdato()[0];
                        namecombo.Text = MovementsClass.getdato()[1];
                        fechabox.Text = MovementsClass.getdato()[2];

                        cantidadbox.Text = MovementsClass.getdato()[3];
                        tipobox.Text = MovementsClass.getdato()[4];


                        name.Text = MovementsClass.getdato()[1];
                        fecha.Text = MovementsClass.getdato()[2];

                        monto.Text = MovementsClass.getdato()[3];
                        tipo.Text = MovementsClass.getdato()[4];
                        editbutton.PerformClick();
                    }
                    else
                    {
                        editbutton.Enabled = false;
                        quitarbutton.Enabled = false;
                        namecombo.Text = "";
                        tipobox.Text = "DOP";
                        cantidadbox.Text = "";
                        fechabox.Text = DateTime.Now.ToString();
                    }

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void tipobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            MovementsClass P = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "_payfor_table")
            {

                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' ;";

                AP.ShowDataGridfound(datagrid, orden);
                AP.getcuenta();
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' ;";
                P.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {

                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' ;";

                AP.ShowDataGridfound(datagrid, orden);
                AP.getcuenta();
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' ;";
                P.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                ////////////////////////////////////////////////////////////

            }

        }

        private void namecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            MovementsClass P = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                
                string orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND COBRADOR='" + namecombo.Text + "';";

                AP.ShowDataGridfound(datagrid, orden);
                AP.getcuenta();
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND COBRADOR='"+namecombo.Text+"';";
                P.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {

                string orden = "SELECT DEUDOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND DEUDOR='" + namecombo.Text + "';";

                AP.ShowDataGridfound(datagrid, orden);
                AP.getcuenta();
                encontradolabel.Text = AP.getcuenta().ToString();
                titlepanel.Text = "AGREGAR COBRADOR";
                orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_askfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND DEUDOR='" + namecombo.Text + "';";
                P.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                ////////////////////////////////////////////////////////////

            }

                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cantidadbox.Text == "" || namecombo.Text == "" || tipobox.Text == "") {
                editbutton.Enabled = false;
                quitarbutton.Enabled = false;
            } else if (cantidadbox.Text != "" || namecombo.Text != "" || tipobox.Text != "") {

                editbutton.Enabled = true;
                quitarbutton.Enabled = true;

            }
            cuenta++;
            if (cuenta==4000) {
                cancelbutton.PerformClick();
            }
            if (cuenta == 2400)
            {

                cuenta = 0;
                
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void quitarbutton_Click(object sender, EventArgs e)
        {
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                string userDataName = UserAccessForm.getusername() + "_payfor_table";

                string orden = "DELETE from " + userDataName + " where ID='" + id + "' ;";
                if (show.ordensql(orden))
                {                                        
                    MessageBox.Show("CUENTA POR PAGAR A "+MovementsClass.getdato()[1]+" HA SIDO SALDADA");
                    

                }
                else
                {
                    MessageBox.Show("CUENTA POR PAGAR A " + MovementsClass.getdato()[1] + " SALDADA");
                }
                limpiarbutton.PerformClick();
            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                string userDataName = UserAccessForm.getusername() + "_askfor_table";

                string orden = "DELETE from " + userDataName + " where ID='" + id + "' ;";
                if (show.ordensql(orden))
                {
                    MessageBox.Show("CUENTA POR COBRAR A " + MovementsClass.getdato()[1] + " HA SIDO SALDADA");
                    

                }
                else
                {
                    MessageBox.Show("CUENTA POR COBRAR A " + MovementsClass.getdato()[1] + " SALDADA");
                }
                limpiarbutton.PerformClick();
            }
        }

        private void buscarbutton_Click(object sender, EventArgs e)
        {
            LoginClass AP = new LoginClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden;
            MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            if (DireccionGestor.getorigen() == "_payfor_table")
            {
                string userDataName = UserAccessForm.getusername() + "_payfor_table";
                if (namecombo.Text == "" || cantidadbox.Text == "") {

                    limpiarbutton.PerformClick();
                } else if (namecombo.Text == "" || cantidadbox.Text != "") {
                     orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND COBRADOR='" + namecombo.Text + "';";

                    AP.ShowDataGridfound(datagrid, orden);
                    AP.getcuenta();
                    encontradolabel.Text = AP.getcuenta().ToString();
                    titlepanel.Text = "AGREGAR COBRADOR";
                    orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND COBRADOR='" + namecombo.Text + "';";
                    show.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                } else if (namecombo.Text != "" || cantidadbox.Text == "") {
                    orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND CANTIDAD='" + cantidadbox.Text + "';";

                    AP.ShowDataGridfound(datagrid, orden);
                    AP.getcuenta();
                    encontradolabel.Text = AP.getcuenta().ToString();
                    titlepanel.Text = "AGREGAR COBRADOR";
                    orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND CANTIDAD='" + cantidadbox.Text + "';";
                    show.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");


                }
                else if (namecombo.Text != "" || cantidadbox.Text != "") {
                    orden = "SELECT COBRADOR,FECHA,CANTIDAD FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE (`TIPO MONEDA`='" + tipobox.Text + "' AND CANTIDAD='" + cantidadbox.Text + "') or COBRADOR='" + namecombo.Text + "';";

                    AP.ShowDataGridfound(datagrid, orden);
                    AP.getcuenta();
                    encontradolabel.Text = AP.getcuenta().ToString();
                    titlepanel.Text = "AGREGAR COBRADOR";
                    orden = "SELECT SUM(CANTIDAD) FROM  " + UserAccessForm.getusername() + "_payfor_table WHERE `TIPO MONEDA`='" + tipobox.Text + "' AND CANTIDAD='" + cantidadbox.Text + "' AND COBRADOR='" + namecombo.Text + "';";
                    show.getsuma(totalalbel, tipobox.Text, orden, "CANTIDAD");

                }
                
                
            }
            else if (DireccionGestor.getorigen() == "_askfor_table")
            {
                string userDataName = UserAccessForm.getusername() + "_askfor_table";
                if (namecombo.Text == "" || cantidadbox.Text == "")
                {

                    limpiarbutton.PerformClick();
                }
                else if (namecombo.Text == "" || cantidadbox.Text != "")
                {
                    orden = "";
                }
                else if (namecombo.Text != "" || cantidadbox.Text == "")
                {
                    orden = "";
                }
                else if (namecombo.Text != "" || cantidadbox.Text != "") {
                    orden = "";
                }

            }
        }

        private void PendientesForm_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void datagrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void palpad_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panelpad_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
