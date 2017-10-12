using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionLib;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace DireccionLib
{
    public class AgendaClass
    {
        private string recordatoryName;
        private string importancy;
        private string date;
        private string time;
        private string user;
        private string filename;
        private string route;
        private bool answer;
        private string message;

        private static string server;
        private static string database;
        private static string userdatabase;
        private static string password;
        private static string port;
        MySqlConnection conection = new MySqlConnection("Persist Security Info=False; server= " + server + "; database=" + database + "; uid=" + userdatabase + "; password=" + password + "; Port=" + port + ";");
        MySqlCommand command;
        MySqlDataReader read;
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        
        //AssemblyMetadataAttribute 


        public AgendaClass() { }
        public AgendaClass(string dbserver, string db, string dbuser, string dbpass, string dbport)
        {

            server = dbserver;
            database = db;
            userdatabase = dbuser;
            password = dbpass;
            port = dbport;

        }

        public AgendaClass(string recordatoryName, string importancy, string date, string time) 
        {
            this.recordatoryName = recordatoryName;
            this.importancy = importancy;
            this.date = date;
            this.time = time;
 
        }

        public bool fillboxes(ComboBox name, DateTimePicker fecha, ComboBox activo , DateTimePicker hora, string orden)
        {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                name.Text = read["DESCRIPCION"].ToString();
                string fechat = read["FECHA DE RECORDATORIO"].ToString();
                string fechal = read["FECHA"].ToString();

                if (fechal != "00/00/0000" || fechat != "00/00")
                {
                    fecha.Text = fechal;
                }
                


                string horat = read["HORA"].ToString();
                if (horat!="00:00:00") {

                    hora.Text = horat;

                }

                activo.Text = read["ACTIVO"].ToString();
                
                answer = true;
            }
            else
            {
                
                MessageBox.Show("Asegurese de selecionar el campo [DESCRIPCION] en la tabla");
                name.Text = "";
                answer = false;
            }

            conection.Close();

            return answer;
        }


        public bool getnametarea(Label name, Label time, TextBox prioridad,TextBox sonido, string orden)
        {
            try { 
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                name.Text = read["DESCRIPCION"].ToString();
                time.Text = read["HORA"].ToString();
                prioridad.Text = read["PRIORIDAD"].ToString();
                sonido.Text = read["SONIDO"].ToString();
                answer = true;
            }
            else
            {
                answer = false;
            }

            conection.Close();

            }
            catch (MySqlException ar) {
                ar.ToString();

                answer = false;
            

            conection.Close();

        }

            return answer;
        }


        private string name;
        
        private string prioridad;

        public string getname() { return name; }
        public string gettime() { return time; }
        public string getprioridad() { return prioridad; }

        public bool getnametarea(string orden)
        {
            try { 
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                name = read["DESCRIPCION"].ToString();
                time = read["HORA"].ToString();
                prioridad = read["PRIORIDAD"].ToString();
                answer = true;
            }
            else
            {
                answer = false;
            }

            conection.Close();

            }
            catch (MySqlException)
            {

                answer = false;


                conection.Close();

            }

            return answer;
        }


        public bool getname(string name,string fecha, string prioridad, string orden)
        {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                name = read["DESCRIPCION"].ToString();
                fecha= read["FECHA"].ToString();
                prioridad= read["PRIORIDAD"].ToString(); 
                answer = true;
            }
            else
            {

                MessageBox.Show("Asegurese de selecionar el campo [DESCRIPCION] en la tabla");
                answer = false;
            }

            conection.Close();

            return answer;
        }


        public bool saveData(string userdataname,string recordatoryName, int priority, string date, string time, string lunes, string martes, string miercoles, string jueves, string viernes, string sabado, string domingo, string fecharecordatorio, string activo, string sonido)
        {

            string complete = userdataname + "_events_table";


            command = new MySqlCommand("insert into " + complete + "  (`DESCRIPCION` ,  `FECHA` ,  `HORA` ,  `PRIORIDAD` ,  `LUNES`,  `MARTES`, `MIERCOLES` ,  `JUEVES` ,  `VIERNES` ,  `SABADO` ,  `DOMINGO`, `FECHA DE RECORDATORIO`, `ACTIVO`, `SONIDO` ) values ('" + recordatoryName + "','" + date + "','" + time + "','" + priority + "','" + lunes + "','" + martes + "','" + miercoles + "','" + jueves + "','" + viernes + "','" + sabado + "','" + domingo + "','" + fecharecordatorio + "','" +activo+"','"+sonido+"')", conection);

            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            return answer;

        }


        public bool modifydata(string userdataname, string nombre,  string recordatoryName, int priority, string date, string time, string lunes, string martes, string miercoles, string jueves, string viernes, string sabado, string domingo, string fecharecordatorio, string activo)
        {

            string complete = userdataname + "_events_table";


            command = new MySqlCommand("UPDATE " + complete + " SET `DESCRIPCION`= '" + recordatoryName + "',  `FECHA` ='" + date + "',  `HORA` ='" + time + "',  `PRIORIDAD` ='" + priority + "',  `LUNES`='" + lunes + "',  `MARTES` ='" + martes + "', `MIERCOLES` ='" + miercoles + "',  `JUEVES` ='" + jueves + "',  `VIERNES` ='" + viernes + "',  `SABADO` ='" + sabado + "',  `DOMINGO` ='" + domingo + "', `FECHA DE RECORDATORIO` ='" + fecharecordatorio + "', `ACTIVO` ='" + activo + "' WHERE  `DESCRIPCION`= 'CUMPLEAÑOS DE "+nombre+"' ;", conection);

            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            return answer;
            //MessageBox.Show(message);
        }

        public void Fillcombo(ComboBox combo, string orden)
        {
            combo.Items.Clear();
            try
            {
                conection.Open();
                command = new MySqlCommand(orden, conection);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    combo.Refresh();
                    combo.Items.Add(read.GetValue(0).ToString());
                }

                conection.Close();
            }
            catch (MySqlException expsql)
            {

                MessageBox.Show(expsql.ToString());
            }
            catch (InvalidOperationException papa) {
                papa.ToString();
            }
        }



        public bool fillboxes(Label eventonamelabel, Label eventohoralabel, TextBox prioridadbox, DateTime fecha, string userdata)
        {
            string fechal = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            string fechashort = fecha.Day.ToString() + "/" + fecha.Month.ToString();
            string hora = fecha.Hour.ToString() + ":" + fecha.Minute.ToString() + ":" +fecha.Second.ToString();
            string orden = "SELECT DESCRIPCION, HORA, PRIORIDAD FROM "+ userdata+"_events_table WHERE (HORA='"+hora+"' AND ( FECHA='"+fechal+"' or `FECHA DE RECORDATORIO`='"+fechashort+"'))AND ACTIVO='SI';";
            

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                eventonamelabel.Text = read["DESCRIPCION"].ToString();
                eventohoralabel.Text = read["HORA"].ToString();
                prioridadbox.Text = read["PRIORIDAD"].ToString();
                answer = true;
            }
            else
            {
                answer = false;
            }

            conection.Close();
            return answer;



        }



        private int cuenta=0;
        public int getcuenta() { return cuenta; }
        public void ShowDataGridinicio(DataGridView findinggrid, string datauser, DateTime fecha, string dia)
        {
            string fechaahora = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            string fechaevento = fecha.Day.ToString() + "/" + fecha.Month.ToString();

            string sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND `FECHA DE RECORDATORIO`='"+fechaevento+"' ORDER BY PRIORIDAD ASC;";
              
                    
            switch (dia) {
                case "LUNES":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR LUNES='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "MARTES":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR MARTES='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "MIERCOLES":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR MIERCOLES='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "JUEVES":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR JUEVES='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "VIERNES":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR VIERNES='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "SABADO":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR SABADO='SI')ORDER BY PRIORIDAD ASC;";

                    break;
                case "DOMINGO":
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND (`FECHA DE RECORDATORIO`='" + fechaevento + "' OR DOMINGO='SI')ORDER BY PRIORIDAD ASC;";

                    break;

                default:
                    sqlsentence = "select  `DESCRIPCION`, HORA from " + datauser + "_events_table WHERE ACTIVO = 'SI' AND `FECHA DE RECORDATORIO`='" + fechaevento + "' ORDER BY PRIORIDAD ASC;";

                    break;
            }


            try { 
            conection.Open();
            dataadapter = new MySqlDataAdapter(sqlsentence, conection);
            datatable = new DataTable();
            dataadapter.Fill(datatable);
            findinggrid.DataSource = datatable;



            command = new MySqlCommand(sqlsentence, conection);
            read = command.ExecuteReader();
            while (read.Read())
            {
                cuenta++;
            }



            conection.Close();
            }
            catch (MySqlException er) {

                conection.Close();
            }
        }

        public void ShowDataGrid(DataGridView findinggrid, string datauser)
        {
            try
            {
                string sqlsentence = "select  `DESCRIPCION`, `FECHA DE RECORDATORIO`, `HORA` from " + datauser + "_events_table WHERE ACTIVO = 'SI' ORDER BY PRIORIDAD ASC;";
                conection.Open();
                dataadapter = new MySqlDataAdapter(sqlsentence, conection);
                datatable = new DataTable();
                dataadapter.Fill(datatable);
                findinggrid.DataSource = datatable;

                command = new MySqlCommand(sqlsentence, conection);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    cuenta++;
                }
            }
            catch (NullReferenceException ap) {
                ap.ToString();
            }
        }

        public void ShowDataGridfound(DataGridView findinggrid, string orden)
        {
            try
            {
                conection.Open();
                datatable = new DataTable();
                dataadapter = new MySqlDataAdapter(orden, conection);
                dataadapter.Fill(datatable);
                findinggrid.DataSource = datatable;

                command = new MySqlCommand(orden, conection);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    cuenta++;
                }

                conection.Close();
            }
            catch (ArgumentNullException argument)
            {

                MessageBox.Show(argument.ToString());
                conection.Close();
            }

        }

        public bool ordensql(string orden)
        {

            command = new MySqlCommand(orden, conection);
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;
                conection.Close();

            }
            catch (Exception problem)
            {
                MessageBox.Show(problem.ToString());
                conection.Close();
            }

            return answer;
        }

        public bool filleverything( ComboBox activo ,ComboBox prioridad,string shortdate, string hora, CheckBox lunes, CheckBox martes, CheckBox miercoles, CheckBox jueves, CheckBox viernes, CheckBox sabado, CheckBox domingo, ComboBox repeticion,ComboBox melodia, string orden)
        {


            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {

                melodia.Text = read["SONIDO"].ToString();
                string priorid =  read["PRIORIDAD"].ToString();
                

                switch (priorid)
                {
                    case "0":
                        prioridad.Text = "MUY IMPORTANTE";
                        break;
                    case "1":
                        prioridad.Text = "NORMAL";
                        break;
                    case "2":
                        prioridad.Text = "POCO IMPORTANTE";
                        break;
                    default:
                        prioridad.Text = "NORMAL";
                        break;
                }

                string lune;
                string marte;
                string miercole;
                string jueve;
                string vierne;
                string sabados;
                string domingos;
                hora = read["HORA"].ToString();
                lune=read["LUNES"].ToString();
                marte = read["MARTES"].ToString();
                miercole= read["MIERCOLES"].ToString();
                jueve= read["JUEVES"].ToString();
                vierne= read["VIERNES"].ToString();
                sabados= read["SABADO"].ToString();
                domingos= read["DOMINGO"].ToString();
                shortdate = read["FECHA DE RECORDATORIO"].ToString();
                activo.Text = read["ACTIVO"].ToString();

                if (lune == "SI")
                {
                    lunes.Checked = true;
                }
                else
                {
                    lunes.Checked = false;
                }

                if (marte == "SI")
                {
                    martes.Checked = true;
                }
                else
                {
                    martes.Checked = false;
                }

                if (miercole == "SI")
                {
                    miercoles.Checked = true;
                }
                else
                {
                    miercoles.Checked = false;
                }

                if (jueve == "SI")
                {
                    jueves.Checked = true;
                }
                else
                {
                    jueves.Checked = false;
                }

                if (vierne == "SI")
                {
                    viernes.Checked = true;
                }
                else
                {
                    viernes.Checked = false;
                }

                if (sabados == "SI")
                {
                    sabado.Checked = true;
                }
                else
                {
                    sabado.Checked = false;
                }

                if (domingos == "SI")
                {
                    domingo.Checked = true;
                }
                else
                {
                    domingo.Checked = false;
                }





                if (lunes.Checked == false && martes.Checked == false && miercoles.Checked == false && jueves.Checked == false && viernes.Checked == false && sabado.Checked == false && domingo.Checked == false)
                {
                    repeticion.Text = "NO";
                    
                }
                else if (lunes.Checked == false && martes.Checked == false && miercoles.Checked == false && jueves.Checked == false && viernes.Checked == false && sabado.Checked == false && domingo.Checked == false)
                {
                    repeticion.Text = "ELEGIR";
                    
                }
                else if (lunes.Checked == true && martes.Checked == true && miercoles.Checked == true && jueves.Checked == true && viernes.Checked == true && sabado.Checked == false && domingo.Checked == false)
                {
                    repeticion.Text = "DIARIO";
                    
                }
                else if (lunes.Checked == true && martes.Checked == true && miercoles.Checked == true && jueves.Checked == true && viernes.Checked == true && sabado.Checked == true && domingo.Checked == true)
                {

                    repeticion.Text = "TODOS LOS DIAS";
                }





                answer = true;
            }
            else
            {

                answer = false;
            }

            conection.Close();

            return answer;
        }


        public string getrecordatoryname() { return recordatoryName; }
        public string getimportancy() { return importancy; }
        public string getdate() { return date; }
        public string getmessageshow() { return message; }
        public bool getanswer() { return answer; }

    }
}
