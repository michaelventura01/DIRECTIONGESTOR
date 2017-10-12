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
    public partial class MovementsForms : Form
    {
        public MovementsForms()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
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


            if(DireccionGestor.getotrostatic()== "refresh")
            {
                DireccionGestor.setotrostatic("");
                date.Text = DateTime.Now.ToString();
                time.Text = DateTime.Now.ToString();
                month = int.Parse(date.Value.Month.ToString());
                year = int.Parse(date.Value.Year.ToString());
                day = int.Parse(date.Value.Day.ToString());

                MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_movements_table";
                orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
                mov.ShowDataGrid(findinggrid, orden);
                monthbox.Text = "TODOS";
                payway.Text = "TODAS";
                transaccionbox.Text = "TODAS";
                monedabox.Text = "DOP";
                montotexbox.Text = "";

                string orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException f)
                {
                    ingreso = 0;
                    f.ToString();
                }
                orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException f)
                {
                    gasto = 0;
                    f.ToString();
                }
                double diner = ingreso - gasto;
                profitlabel.Text = monedabox.Text + " " + diner.ToString();
                cuentalabel.Text = mov.getcuenta().ToString();
            }


            cuenta++;
            if (cuenta == 4000)
            {

                cuenta = 0;
                backstripbutton.PerformClick();
            }
            if (cuenta==1000) {
                panelopcion.Hide();
            }


        }


        private int cuenta;






        private void backstripbutton_Click(object sender, EventArgs e)
        {
            
            DireccionGestor menu = new DireccionGestor();
            menu.WindowState = FormWindowState.Normal;
            menu.Show();
            this.Close();
        }



        private double ingreso=0;
        private double gasto = 0;
        private void MovementsForms_Load(object sender, EventArgs e)
        {
            addbutton.BackColor = Color.Green;
            eliminarbutton.BackColor = Color.Red;
            editbutton.BackColor = Color.DarkBlue;
            searchbutton.BackColor = Color.Blue;
            panelopcion.Hide();
            ingresolabel.Hide();
            gastolabel.Hide();




            cleanbuttonstrip.PerformClick();
            cleanbuttonstrip.PerformClick();
           
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToString();
            time.Text = DateTime.Now.ToString();
            month = int.Parse(date.Value.Month.ToString());
            year = int.Parse(date.Value.Year.ToString());
            day = int.Parse(date.Value.Day.ToString());

            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            string userDataName = UserAccessForm.getusername()+"_movements_table";
            string orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='"+month+"' AND AÑO='"+year+"'; ";
            mov.ShowDataGrid(findinggrid,orden);
            monthbox.Text = "TODOS";
            payway.Text = "TODAS";
            transaccionbox.Text = "TODAS";
            monedabox.Text = "DOP";
            montotexbox.Text = "";

            string orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
            mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

            try
            {
                ingreso = double.Parse(mov.getstr());
            }
            catch (FormatException f) {
                ingreso = 0;
                f.ToString();
            }
            catch (ArgumentNullException f) {
                f.ToString();
                ingreso = 0;
            }
            orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
            mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


            try
            {
                gasto = double.Parse(mov.getstr());
            }
            catch (FormatException f) {
                gasto = 0;
                f.ToString();
            }
            catch (ArgumentNullException f) {

                gasto = 0;
                f.ToString();
            }
                double diner = ingreso - gasto;
            profitlabel.Text = monedabox.Text + " " + diner.ToString();
            cuentalabel.Text = mov.getcuenta().ToString();

        }
        private string id;
        private string nameevent;
        private void findinggrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_movements_table";
                nameevent = this.findinggrid.CurrentCell.Value.ToString();

                string orden = "select * from " + userDataName + " where (`MOTIVO` = '" + nameevent + "' OR `HORA DEL MOVIMIENTO`='" + nameevent + "' ) AND `TIPO DE MONEDA`='" + monedabox.Text + "' ;";
                if (show.Fillbuscador(transaccionbox, monedabox, montotexbox, payway, monthbox, orden))
                {
                    date.Text = MovementsClass.getdato()[2];
                    time.Text = MovementsClass.getdato()[3];
                    editbutton.Enabled = true;
                    eliminarbutton.Enabled = true;
                }
                else
                {
                    editbutton.Enabled = false;
                    eliminarbutton.Enabled = false;

                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void montotexbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros");
            }
        }

        private void transaccionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";


        }

        private void monedabox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";
        }

        private void payway_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";
        }

        private void monthbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";

        }
        private int month;
        private int year;
        private int day;
        private int hour;
        private int minute;
        private int segundo;
        private void date_ValueChanged(object sender, EventArgs e)
        {
            month=int.Parse(date.Value.Month.ToString());
            year = int.Parse(date.Value.Year.ToString());
            day = int.Parse(date.Value.Day.ToString());
        }

        private void time_ValueChanged(object sender, EventArgs e)
        {
            hour = int.Parse(time.Value.Hour.ToString());
            minute= int.Parse(time.Value.Minute.ToString());
            segundo=int.Parse(time.Value.Second.ToString());
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            string orden2;
            losinglabel.Text = monedabox.Text + " " + "0.00";
            gaininglabel.Text = monedabox.Text + " " + "0.00";
            profitlabel.Text = monedabox.Text + " " + "0.00";

            hour = int.Parse(time.Value.Hour.ToString());
            minute = int.Parse(time.Value.Minute.ToString());
            segundo = int.Parse(time.Value.Second.ToString());

            hour = int.Parse(time.Value.Hour.ToString());
            minute = int.Parse(time.Value.Minute.ToString());
            segundo = int.Parse(time.Value.Second.ToString());

            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";

            string orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from " 
                + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' OR DIA='"
                +day+"' OR HORA='"+hour+"' OR MINUTO='"+minute+"' OR INGRESO = '"+montotexbox+ "' OR GASTO = '" + montotexbox 
                + "' OR `FORMA DE PAGO`='"+payway.Text+"') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


            if (monthbox.Text == "TODOS") {


                if (montotexbox.Text == "") {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }
                else
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                    + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                    + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }
                try
                {

                    ingreso = double.Parse(mov.getstr());

                } catch (FormatException fort) {
                    ingreso = 0;
                    fort.ToString();

                }
                catch (ArgumentNullException n) {

                    n.ToString();
                    ingreso = 0;
                }
                orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException fort) { fort.ToString();
                    gasto = 0;
                }
                
            }
            else if (payway.Text == "TODAS") {

                if (montotexbox.Text=="") {



                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                     + userDataName + " where(  MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                     + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND  `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                     + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND  `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";



                }
                else {
                    //me quede aqui

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                     + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                     + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                     + "'  ) AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                     + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                     + "'  ) AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }


                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {

                    ingreso = 0;
                    fort.ToString();
                }
                catch (ArgumentNullException ap) {
                    ap.ToString();
                    ingreso = 0;

                }


                if (montotexbox.Text == "")
                {
                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                 + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' ) AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where(  MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                 + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                 + "')  AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    gasto = 0;
                    fort.ToString(); }
              



            }
            else if (transaccionbox.Text == "TODAS") {

                if (montotexbox.Text == "") {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";



                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";



                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";




                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    ingreso = 0;
                    fort.ToString();  }



                if (montotexbox.Text=="") {
                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                else {




                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox
                    + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }
                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException fort){

                    gasto = 0;
                    fort.ToString(); }



            }
            else if (transaccionbox.Text == "INGRESO")
            {
               

                if (montotexbox.Text == "") {



                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {



                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where(  MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox
                    + "'  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where(  MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox
                    + "'  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }


                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    fort.ToString();
                    ingreso = 0;
                }

                if (montotexbox.Text == "") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {
                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox
                    + "'  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");

                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    fort.ToString();
                    gasto = 0;
                }


            }
            else if (transaccionbox.Text == "GASTO")
            {

                if (montotexbox.Text == "")
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR GASTO  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR GASTO  OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR GASTO = '" + montotexbox
                    + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR GASTO = '" + montotexbox
                    + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    ingreso = 0;
                    fort.ToString();
                }


                if (montotexbox.Text=="") {



                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }
                else {


                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR GASTO = '" + montotexbox
                    + "' OR `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }

                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");

                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException fort) {
                    gasto = 0;
                    fort.ToString();
                }




            }
            else if (monthbox.Text == "TODOS" && payway.Text == "TODAS") {

                if (montotexbox.Text == "") {


                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute
                        + "'  )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute
                        + "'  )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where  (AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox
                    + "' OR GASTO = '" + montotexbox + "' ) AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "' OR INGRESO = '" + montotexbox
                    + "' OR GASTO = '" + montotexbox + "' ) AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException fo) {

                    ingreso = 0;
                    fo.ToString(); }

                if (montotexbox.Text=="") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute
                    + "' )  AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( AÑO='" + year + "' OR HORA='" + hour + "' OR MINUTO='" + minute
                    + "' OR INGRESO = '" + montotexbox + "' OR GASTO = '" + montotexbox + "')  AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }



                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try{
                    gasto = double.Parse(mov.getstr());
                }catch (FormatException f) {

                    gasto = 0;
                    f.ToString(); }
                


            }
            else if (transaccionbox.Text == "TODAS" && payway.Text == "TODAS") {



                if (montotexbox.Text == "") {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {


                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( MES='" + month + "' OR AÑO='" + year + "' OR DIA='"
                    + day + "' OR HORA='" + hour + "' OR MINUTO='" + minute + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");


                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException f) {

                    ingreso = 0;
                    f.ToString(); }

                if (montotexbox.Text=="") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }
                else {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "') and `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }


                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException f) {

                    gasto = 0;
                    f.ToString(); }
               



            }
            else if (transaccionbox.Text == "TODAS" && monthbox.Text == "TODOS") {

                if (montotexbox.Text == "") {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "+ userDataName + " where  ( AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='"+ payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  ( AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='" + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where   (AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='"
                    + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where   (AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='"
                    + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";
                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException f) { f.ToString();
                    ingreso = 0;
                }
                if (montotexbox.Text=="") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where   (AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='"
                + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where   (AÑO='" + year + "' or  HORA='" + hour + "' or MINUTO='" + minute + "'  or `FORMA DE PAGO`='"
                + payway.Text + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }

                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");

                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException f) {
                    gasto = 0;
                    f.ToString(); }


            }
            else if (transaccionbox.Text == "TODAS" && monthbox.Text == "TODOS" && payway.Text == "TODAS") {


                if (montotexbox.Text == "") {


                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where  (AÑO='" + year + "' or  HORA='" + hour + "') AND  `TIPO DE MONEDA` = '"
                    + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (AÑO='" + year + "' or  HORA='" + hour + "') AND  `TIPO DE MONEDA` = '"
                    + monedabox.Text + "'; ";


                }
                else
                {
                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where  (AÑO='" + year + "' or  HORA='" + hour + "' or GASTO = '" + montotexbox + "' )AND `TIPO DE MONEDA` = '"
                    + monedabox.Text + "'; ";


                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (AÑO='" + year + "' or  HORA='" + hour + "' or GASTO = '" + montotexbox + "' )AND `TIPO DE MONEDA` = '"
                    + monedabox.Text + "'; ";

                }
                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");


                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException f) {

                    ingreso = 0;
                    f.ToString(); }

                if (montotexbox.Text=="") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (AÑO='" + year + "' or  HORA='" + hour + "' ) AND `TIPO DE MONEDA` = '"+ monedabox.Text + "'; ";

                } else {


                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where  (AÑO='" + year + "' OR  HORA='" + hour + "' OR GASTO = '" + montotexbox + "') AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }


                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException f) {
                    gasto = 0;
                    f.ToString(); }



            }
            else {


                if (montotexbox.Text == "") {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                 + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                 + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "'  OR `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                 + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "' OR  `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else
                {

                    orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from "
                    + userDataName + " where  (MES='" + month + "' or AÑO='" + year + "' or DIA='"
                    + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "' or INGRESO = '" + montotexbox + "' or GASTO = '" + montotexbox
                    + "' or `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                    orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where  (MES='" + month + "' or AÑO='" + year + "' or DIA='"
                    + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "' or INGRESO = '" + montotexbox + "' or GASTO = '" + montotexbox
                    + "' or `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";

                }

                mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

                try
                {
                    ingreso = double.Parse(mov.getstr());
                }
                catch (FormatException f) {

                    ingreso = 0;
                    f.ToString(); }

                if (montotexbox.Text=="") {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "' or  `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }
                else {

                    orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where ( MES='" + month + "' or AÑO='" + year + "' or DIA='"
                + day + "' or HORA='" + hour + "' or MINUTO='" + minute + "' or INGRESO = '" + montotexbox + "' or GASTO = '" + montotexbox
                + "' or `FORMA DE PAGO`='" + payway.Text + "' )AND `TIPO DE MONEDA` = '" + monedabox.Text + "'; ";


                }


                mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");

                try
                {
                    gasto = double.Parse(mov.getstr());
                }
                catch (FormatException f) {
                    gasto = 0;
                    f.ToString(); }


            }


            double profit = ingreso - gasto;
            losinglabel.Text = monedabox.Text + " " + gasto.ToString();
            gaininglabel.Text = monedabox.Text + " " + ingreso.ToString();
            profitlabel.Text = monedabox.Text + " " + profit.ToString();
            mov.ShowDataGrid(findinggrid, orden);
            cuentalabel.Text = mov.getcuenta().ToString();
        }

        private void calcpicturebox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "calc";
            proc.Start();
            //TIMEDATE.CPL
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            losinglabel.Text = monedabox.Text + " " + "0.00";
            gaininglabel.Text = monedabox.Text + " " + "0.00";
            profitlabel.Text = monedabox.Text + " " + "0.00";
            string userDataName = UserAccessForm.getusername() + "_movements_table";
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden2 = "SELECT SUM(INGRESO) FROM " + userDataName +" WHERE `TIPO DE MONEDA`='"+monedabox.Text+"'; ";

            mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

            try
            {
                ingreso = double.Parse(mov.getstr());
            }
            catch (FormatException f) {
                f.ToString();
                ingreso = 0;
            }


            orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " WHERE `TIPO DE MONEDA`='" + monedabox.Text + "'; ";

            mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");

            try
            {
                gasto = double.Parse(mov.getstr());
            }
            catch (FormatException f) { gasto = 0; f.ToString(); }

            double diner = ingreso - gasto;
            losinglabel.Text = monedabox.Text + " " + gasto.ToString();
            gaininglabel.Text = monedabox.Text + " " + ingreso.ToString();
            profitlabel.Text = monedabox.Text + " " + diner.ToString();
            
        }

        private void addbutton_Click(object sender, EventArgs e)
        {

            panelopcion.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panelopcion.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panelopcion.Hide();

            DireccionGestor.setorigen("inicio");
            IngresosForm ingresosobject = new IngresosForm();
            ingresosobject.WindowState = FormWindowState.Normal;
            ingresosobject.Show();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panelopcion.Hide();
            DireccionGestor.setorigen( "inicio");
            GastosForm gastosobject = new GastosForm();
            gastosobject.WindowState = FormWindowState.Normal;
            gastosobject.Show();
        }

        private void eliminarbutton_Click(object sender, EventArgs e)
        {
            string userDataName = UserAccessForm.getusername() + "_movements_table";
            MovementsClass mov = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());

            double month = 0;

            switch (monthbox.Text)
            {

                case "ENERO":
                    month = 1;
                    
                    break;

                case "FEBRERO":
                    month = 2;
                    break;

                case "MARZO":
                    month = 3;
                    break;

                case "ABRIL":
                    month = 4;
                    break;

                case "MAYO":
                    month = 5;
                    break;

                case "JUNIO":
                    month = 6;
                    break;

                case "JULIO":
                    month = 7;
                    break;

                case "AGOSTO":
                    month = 8;
                    break;

                case "SEPTIEMBRE":
                    month = 9;
                    break;

                case "OCTUBRE":
                    month = 10;
                    break;

                case "NOVIEMBRE":
                    month = 11;
                    break;

                case "DICIEMBRE":
                    month = 12;
                    break;

      
            }

            string dates = date.Value.Day.ToString() + "/" + date.Value.Month.ToString() + "/" + date.Value.Year.ToString();
            string hours = time.Value.Hour.ToString() + ":" + time.Value.Minute.ToString() + ":" + time.Value.Second.ToString();
            string dia= date.Value.Day.ToString();
            string mes = date.Value.Month.ToString();
            string anio = date.Value.Year.ToString();
            string hora = time.Value.Hour.ToString();
            string minuto = time.Value.Minute.ToString();
            string segundo = time.Value.Second.ToString();

            string orden = "";
            if (transaccionbox.Text == "INGRESO") {

                orden = "DELETE FROM " + userDataName + " WHERE MOTIVO= '" + nameevent + "' AND `HORA DEL MOVIMIENTO`= '" + hours + "' AND `FECHA DEL MOVIMIENTO`='" + dates + "' AND INGRESO = '"+montotexbox.Text+"' AND `TIPO DE MONEDA`='"+monedabox.Text+"' AND DIA='"+dia+"' AND MES='"+mes+"' AND AÑO='"+anio+"' AND HORA='"+hora+"' AND MINUTO='"+minuto+"' AND SEGUNDO ='"+segundo+"' AND `FORMA DE PAGO`='"+payway.Text+"';";


            }
            else if (transaccionbox.Text=="GASTO") {


                orden = "DELETE FROM " + userDataName + " WHERE MOTIVO= '" + nameevent + "' AND `HORA DEL MOVIMIENTO`= '" + hours + "' AND `FECHA DEL MOVIMIENTO`='" + dates + "' AND GASTO='"+montotexbox.Text+ "'AND `TIPO DE MONEDA`='" + monedabox.Text + "'AND DIA='" + dia + "' AND MES='" + mes + "' AND AÑO='" + anio + "' AND HORA='" + hora + "' AND MINUTO='" + minuto + "' AND SEGUNDO ='" + segundo + "' AND `FORMA DE PAGO`='" + payway.Text + "';";


            }



             orden = "SELECT `FECHA DEL MOVIMIENTO`, `HORA DEL MOVIMIENTO`, MOTIVO, INGRESO, GASTO, EXPLICACION, `FORMA DE PAGO` from " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
            mov.ShowDataGrid(findinggrid, orden);
            monthbox.Text = "TODOS";
            payway.Text = "TODAS";
            transaccionbox.Text = "TODAS";
            monedabox.Text = "DOP";
            montotexbox.Text = "";

            string orden2 = "SELECT SUM(INGRESO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
            mov.getsuma(gaininglabel, monedabox.Text, orden2, "INGRESO");

            try
            {
                ingreso = double.Parse(mov.getstr());
            }
            catch (FormatException f)
            {
                ingreso = 0;
                f.ToString();
            }
            orden2 = "SELECT SUM(GASTO) FROM " + userDataName + " where `TIPO DE MONEDA` = '" + monedabox.Text + "' AND MES='" + month + "' AND AÑO='" + year + "'; ";
            mov.getsuma(losinglabel, monedabox.Text, orden2, "GASTO");


            try
            {
                gasto = double.Parse(mov.getstr());
            }
            catch (FormatException f)
            {
                gasto = 0;
                f.ToString();
            }
            double diner = ingreso - gasto;
            profitlabel.Text = monedabox.Text + " " + diner.ToString();
            cuentalabel.Text = mov.getcuenta().ToString();


            if (mov.ordensql(orden)) { MessageBox.Show("MOVIMIENTO DE LAS " + hour + " EN LA FECHA " + dates); } else {

                MessageBox.Show("HA OCURRIDO ALGO DURANTE EL PROCESO");
            }


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

        private void findinggrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
                MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                string userDataName = UserAccessForm.getusername() + "_movements_table";
                nameevent = this.findinggrid.CurrentCell.Value.ToString();

                string orden = "select * from " + userDataName + " where (`MOTIVO` = '" + nameevent + "' OR `HORA DEL MOVIMIENTO`='" + nameevent + "' ) AND `TIPO DE MONEDA`='" + monedabox.Text + "' ;";
                if (show.Fillbuscador(transaccionbox, monedabox, montotexbox, payway, monthbox, orden))
                {
                    date.Text = MovementsClass.getdato()[2];
                    time.Text = MovementsClass.getdato()[3];
                    editbutton.Enabled = true;
                    eliminarbutton.Enabled = true;
                    DireccionGestor.setorigen("editor");
                    if (transaccionbox.Text == "INGRESO")
                    {
                        IngresosForm iN = new IngresosForm();
                        iN.WindowState = FormWindowState.Normal;
                        iN.Show();

                    }
                    else if (transaccionbox.Text == "GASTO")
                    {
                        GastosForm iN = new GastosForm();
                        iN.WindowState = FormWindowState.Normal;
                        iN.Show();
                    }


                }
                else
                {
                    editbutton.Enabled = false;
                    eliminarbutton.Enabled = false;


                }
            } catch (NullReferenceException pafh) { pafh.ToString(); }
            
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("editor");
            if (transaccionbox.Text == "INGRESO")
            {
                IngresosForm iN = new IngresosForm();
                iN.WindowState = FormWindowState.Normal;
                iN.Show();

            }
            else if (transaccionbox.Text == "GASTO")
            {
                GastosForm iN = new GastosForm();
                iN.WindowState = FormWindowState.Normal;
                iN.Show();
            }
        }

        private void eliminarbutton_Click_1(object sender, EventArgs e)
        {
            MovementsClass show = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string userDataName = UserAccessForm.getusername() + "_movements_table";
            string orden = "DELETE FROM " + userDataName + " WHERE ID='" + MovementsClass.getdato()[0] + "' AND `FECHA DEL MOVIMIENTO`='" + MovementsClass.getdato()[2] + "' AND  `HORA DEL MOVIMIENTO`='" + MovementsClass.getdato()[3] + "';";
            show.ordensql(orden);
            MessageBox.Show(transaccionbox.Text+ " REGISTRADO DE LAS "+ MovementsClass.getdato()[3]+" EL DIA "+ MovementsClass.getdato()[2]+ " HA SIDO ELIMINADO");
            cleanbuttonstrip.PerformClick();
        }

        private void MovementsForms_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void findinggrid_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void finderpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void buttonpanel_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
