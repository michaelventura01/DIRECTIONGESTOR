using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionLib;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;
using System.Data;

namespace DireccionLib
{
    public class MovementsClass
    {
        private int idmovement;
        private string datemovement;
        private string timemovement;
        private string reasonmovement;
        private double profit;
        private double expense;
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

        public bool answer;
        private string userMessage;


        public MovementsClass() { }
        public MovementsClass(string dbserver, string db, string dbuser, string dbpass, string dbport)
        {

            server = dbserver;
            database = db;
            userdatabase = dbuser;
            password = dbpass;
            port = dbport;

        }
        public MovementsClass(int idmovement, string datemovement,  string timemovement, string reasonmovement,double profit, double expense) 
        {
            this.idmovement = idmovement;
            this.datemovement = datemovement;
            this.timemovement = timemovement;
            this.reasonmovement = reasonmovement;
            this.profit = profit;
            this.expense = expense;
        }


        public void OrderID(string userDataName)
        {
            string command1 = "ALTER TABLE " + userDataName + " DROP ID;";
            string command2 = "ALTER TABLE " + userDataName + " ADD ID INT(6) NOT NULL AUTO_INCREMENT FIRST, ADD PRIMARY KEY (ID);";
            command = new MySqlCommand(command1 + command2, conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                conection.Close();
            }
            catch (InvalidOperationException mistake)
            {
                userMessage = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessage = mistake.ToString();
                conection.Close();
            }
        }



        /*public bool TimeNoCopied(string time,string razon, string userDataName)
        {
            
            command = new MySqlCommand("SELECT * FROM " + userDataName + " where `HORA DEL MOVIMIENTO`='" + time + "' AND MOTIVO = '"+razon+"';", conection);


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
                conection.Close();
                userMessage = problem.ToString();
            }

            return answer;

        }
        */

        private bool createtablestudentanswer;
        private string message;
        public bool AddCountAskFor(string nombre, string fecha, double cantidad, string tipomoneda, string nameUser)
        {
            string complete = nameUser + "_askfor_table";


            command = new MySqlCommand("INSERT into " + complete + " (DEUDOR, FECHA,CANTIDAD,`TIPO MONEDA`) values ('" + nombre + "','" + fecha + "','" + cantidad + "','" + tipomoneda + "' );", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }
        public bool editCountAskFor(string nombre, string fecha, double cantidad, string tipomoneda, string oldnombre, string oldfecha, double oldcantidad, string oldtipomoneda, string nameUser)
        {
            string complete = nameUser + "_askfor_table";

            //`DEUDOR` varchar(60) not null,FECHA varchar(20) not null, CANTIDAD double(10,2), `TIPO MONEDA` varchar(10),

            command = new MySqlCommand("UPDATE " + complete + " `DEUDOR`='" + nombre + "', FECHA='" + fecha + "',CANTIDAD='" + cantidad + "',`TIPO MONEDA`='" + tipomoneda + "'  WHERE `DEUDOR`='" + oldnombre + "' and FECHA='" + oldfecha + "' and CANTIDAD='" + oldcantidad + "' and `TIPO MONEDA`='" + oldtipomoneda + "';", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }
        public bool deleteCountAskFor(string oldnombre, string oldfecha, double oldcantidad, string oldtipomoneda, string nameUser)
        {
            string complete = nameUser + "_askfor_table";
            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE `DEUDOR`='" + oldnombre + "' and FECHA='" + oldfecha + "' and CANTIDAD='" + oldcantidad + "' and `TIPO MONEDA`='" + oldtipomoneda + "';", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }

        public bool AddCountPayFor(string nombre, string fecha, double cantidad, string tipomoneda, string nameUser)
        {

            string complete = nameUser + "_payfor_table";

            command = new MySqlCommand("INSERT into " + complete + " (COBRADOR, FECHA,CANTIDAD,`TIPO MONEDA`) values ('" + nombre + "','" + fecha + "','" + cantidad + "','" + tipomoneda + "' );", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }
        public bool editCountPayFor(string nombre, string fecha, double cantidad, string tipomoneda, string oldnombre, string oldfecha, double oldcantidad, string oldtipomoneda, string nameUser)
        {
            string complete = nameUser + "_askfor_table";
            //`COBRADOR`
            command = new MySqlCommand("UPDATE " + complete + " `COBRADOR`='" + nombre + "', FECHA='" + fecha + "',CANTIDAD='" + cantidad + "',`TIPO MONEDA`='" + tipomoneda + "'  WHERE `COBRADOR`='" + oldnombre + "' and FECHA='" + oldfecha + "' and CANTIDAD='" + oldcantidad + "' and `TIPO MONEDA`='" + oldtipomoneda + "';", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }
        public bool deleteCountPayFor(string oldnombre, string oldfecha, double oldcantidad, string oldtipomoneda, string nameUser)
        {
            string complete = nameUser + "_askfor_table";
            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE `COBRADOR`='" + oldnombre + "' and FECHA='" + oldfecha + "' and CANTIDAD='" + oldcantidad + "' and `TIPO MONEDA`='" + oldtipomoneda + "';", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }

            return createtablestudentanswer;
        }

        public bool setProfit(string datemovement, string timemovement, string reasonmovement, double profit,string tipomoneda, string dia, string mes, string anio, string hora, string minuto, string segundo, string explicacion, string origenfondo, string userDataName) 
        {
           
            string orden= "INSERT into " + userDataName + " (`FECHA DEL MOVIMIENTO` ,`HORA DEL MOVIMIENTO` ,MOTIVO ,INGRESO, `TIPO DE MONEDA`, DIA, MES, AÑO, HORA, MINUTO, SEGUNDO, EXPLICACION, `FORMA DE PAGO` ) values ('" + datemovement + "', '" + timemovement + "' , '" + reasonmovement + "', '" + profit + "','" + tipomoneda + "','" + dia + "','" + mes + "','" + anio + "','" + hora + "','" + minuto + "','" + segundo + "','" + explicacion + "','" + origenfondo + "' )";
           
            command = new MySqlCommand(orden, conection);

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
                userMessage = mistake.ToString();
                MessageBox.Show(userMessage);
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessage = mistake.ToString();
                MessageBox.Show(userMessage);
                conection.Close();
            }
            return answer; 
            
        }

        private int hour;
        private int minut; 
        private int secund;

        private void cambiohour(string hora, string minute, string segunde) {

            hour = int.Parse(hora);
            minut = int.Parse(minute);
            secund = int.Parse(segunde);

            secund += 1;

            if (secund == 60) {
                secund = 0;
                minute += 1;

                if (minut == 60)
                {
                    minut = 0;
                    hour += 1;

                    if (hour==25) {
                        hour = 1;
                        minut = 0;
                        secund = 0;

                    }
                }

            }
        }

        public bool setExpense(string datemovement, string timemovement, string reasonmovement, double profit, string tipomoneda, string dia, string mes, string anio, string hora, string minuto, string segundo, string explicacion, string origenfondo, string userDataName)
        {

            string orden = "INSERT into " + userDataName + " (`FECHA DEL MOVIMIENTO` ,`HORA DEL MOVIMIENTO` ,MOTIVO ,GASTO, `TIPO DE MONEDA`, DIA, MES, AÑO, HORA, MINUTO, SEGUNDO, EXPLICACION, `FORMA DE PAGO` ) values ('" + datemovement + "', '" + timemovement + "' , '" + reasonmovement + "', '" + profit + "','" + tipomoneda + "','" + dia + "','" + mes + "','" + anio + "','" + hora + "','" + minuto + "','" + segundo + "','" + explicacion + "','" + origenfondo + "' );";

            if (origenfondo == "TARGETA DE CREDITO")
            {
                setProfit(datemovement, timemovement, "INGRESO DE TARGETA DE CREDITO", profit, tipomoneda, dia, mes, anio, hora, minuto, segundo, explicacion, origenfondo, userDataName);
                cambiohour(hora, minuto, segundo);
                this.timemovement = hour + ":" + minut + ":" + secund;
                orden = "INSERT into " + userDataName + " (`FECHA DEL MOVIMIENTO` ,`HORA DEL MOVIMIENTO` ,MOTIVO ,GASTO, `TIPO DE MONEDA`, DIA, MES, AÑO, HORA, MINUTO, SEGUNDO, EXPLICACION, `FORMA DE PAGO` ) values ('" + datemovement + "', '" + this.timemovement + "' , '" + reasonmovement + "', '" + profit + "','" + tipomoneda + "','" + dia + "','" + mes + "','" + anio + "','" + hour + "','" + minut + "','" + secund + "','" + explicacion + "','" + origenfondo + "' );";
            }
            else if (origenfondo == "PRESTAMO")
            {
                setProfit(datemovement, timemovement, "INGRESO DE PRESTAMO", profit, tipomoneda, dia, mes, anio, hora, minuto, segundo, explicacion, origenfondo, userDataName);
                cambiohour(hora, minuto, segundo);
                this.timemovement = hour + ":" + minut + ":" + secund;
                orden = "INSERT into " + userDataName + " (`FECHA DEL MOVIMIENTO` ,`HORA DEL MOVIMIENTO` ,MOTIVO ,GASTO, `TIPO DE MONEDA`, DIA, MES, AÑO, HORA, MINUTO, SEGUNDO, EXPLICACION, `FORMA DE PAGO` ) values ('" + datemovement + "', '" + this.timemovement + "' , '" + reasonmovement + "', '" + profit + "','" + tipomoneda + "','" + dia + "','" + mes + "','" + anio + "','" + hour + "','" + minut + "','" + secund + "','" + explicacion + "','" + origenfondo + "' );";
            }
            else {

                orden = "INSERT into " + userDataName + " (`FECHA DEL MOVIMIENTO` ,`HORA DEL MOVIMIENTO` ,MOTIVO ,GASTO, `TIPO DE MONEDA`, DIA, MES, AÑO, HORA, MINUTO, SEGUNDO, EXPLICACION, `FORMA DE PAGO` ) values ('" + datemovement + "', '" + timemovement + "' , '" + reasonmovement + "', '" + profit + "','" + tipomoneda + "','" + dia + "','" + mes + "','" + anio + "','" + hora + "','" + minuto + "','" + segundo + "','" + explicacion + "','" + origenfondo + "' );";
            }

            
            
            
            


            command = new MySqlCommand(orden, conection);


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
                userMessage = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessage = mistake.ToString();
                conection.Close();
            }
            return answer; 
            
        }


        private double cuenta;
        public double getcuenta() { return cuenta; }

        public void ShowDataGrid(DataGridView findinggrid, string datauser)
        {
                      

            try {
                conection.Open();
                datatable = new DataTable();
                dataadapter = new MySqlDataAdapter(datauser, conection);
                dataadapter.Fill(datatable);
                findinggrid.DataSource = datatable;


                command = new MySqlCommand(datauser, conection);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    cuenta++;
                }


                conection.Close();



            }
            catch (MySqlException erp) {
                conection.Close();
                erp.ToString(); }
            }


        //edit for editing
        public bool filleverything(Label name, Label fechaentrada, Label titulo, Label cedula, Label fechanacimiento, Label telefono, Label tanda,
                    Label cargo, Label nacionalidad, Label edad, Label tipomoneda, Label pago, Label nombrereferencia, Label telefonoreferencia, Label relacion,
                    Label nombrealergia, Label nombredolencia, Label nombremedicamento, Label razonmedicamento, Label trabajando, Label fechasalida, Label sexo,
                    Label direccion, TextBox foto, string orden)
        {


            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {

                name.Text = read["NOMBRE COMPLETO"].ToString();
                sexo.Text = read["SEXO"].ToString();
                foto.Text = read["RUTA DE FOTO"].ToString();
                tanda.Text = read["HORARIO"].ToString();
                fechaentrada.Text = read["FECHA DE ENTRADA"].ToString();
                titulo.Text = read["TITULO UNIVERSITARIO"].ToString();

                cedula.Text = read["CEDULA"].ToString();
                fechanacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                telefono.Text = read["TELEFONO"].ToString();

                cargo.Text = read["PUESTO"].ToString();
                nacionalidad.Text = read["NACIONALIDAD"].ToString();
                edad.Text = read["EDAD"].ToString();
                tipomoneda.Text = read["TIPO DE MONEDA"].ToString();
                pago.Text = read["SUELDO"].ToString();
                nombrereferencia.Text = read["REFERENCIA PERSONAL"].ToString();
                telefonoreferencia.Text = read["TELEFONO DE REFERENCIA"].ToString();
                relacion.Text = read["RELACION DE REFERENCIA"].ToString();
                nombrealergia.Text = read["NOMBRE DE ALERGIA"].ToString();
                nombredolencia.Text = read["NOMBRE DE DOLENCIA"].ToString();
                nombremedicamento.Text = read["NOMBRE DE MEDICINA"].ToString();
                razonmedicamento.Text = read["RAZON DE MEDICINA"].ToString();
                trabajando.Text = read["TRABAJANDO"].ToString();
                fechasalida.Text = read["FECHA DE SALIDA"].ToString();
                direccion.Text = read["DIRECCION"].ToString();



                answer = true;
            }
            else
            {

                answer = false;
            }

            conection.Close();

            return answer;
        }

        public bool Fillbuscadorcobrador(string orden)
        {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            try
            {
                if (read.Read() == true)
                {
                    dato = new string[5];
                    dato[0] = read["ID"].ToString();
                    dato[1] = read["DEUDOR"].ToString();
                    dato[2] = read["FECHA"].ToString();
                    dato[3] = read["CANTIDAD"].ToString();
                    dato[4] = read["TIPO MONEDA"].ToString();
                    ans = true;
                }
                else
                {
                    MessageBox.Show("DEBES SELECCIONAR EL CAMPO [DEUDOR] O ALMENOS [FECHA]");
                    ans = false;
                }

                conection.Close();

            }
            catch (IndexOutOfRangeException op)
            {
                ans = false;
                conection.Close();
                MessageBox.Show("DEBES SELECCIONAR EL CAMPO [DEUDOR] O ALMENOS [FECHA]");

                MessageBox.Show(op.ToString());
            }
            catch (MySqlException ap)
            {
                ans = false;
                ap.ToString();
                conection.Close();
                MessageBox.Show(ap.ToString());
                MessageBox.Show("DEBES SELECCIONAR EL CAMPO [DEUDOR] O ALMENOS [FECHA]");

            }
            return ans;


        }

        public bool Fillbuscadorpagador(string orden)
        {
            
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            try
            {
                if (read.Read() == true)
                {
                    dato = new string[5];
                    dato[0] = read["ID"].ToString();
                    dato[1] = read["COBRADOR"].ToString();
                    dato[2] = read["FECHA"].ToString();
                    dato[3] = read["CANTIDAD"].ToString();
                    dato[4] = read["TIPO MONEDA"].ToString();
                    ans = true;
                    
                }
                else {
                    MessageBox.Show("DEBES SELECCIONAR EL CAMPO [COBRADOR] O ALMENOS [FECHA]");
                    ans = false;
                }

                conection.Close();

            }
            catch (IndexOutOfRangeException op)
            {
                ans = false;
                conection.Close();
                MessageBox.Show("DEBES SELECCIONAR EL CAMPO [COBRADOR] O ALMENOS [FECHA]");

                MessageBox.Show(op.ToString());
            }
            catch (MySqlException ap) {
                ans = false;
                ap.ToString();
                conection.Close();
                MessageBox.Show(ap.ToString());
                MessageBox.Show("DEBES SELECCIONAR EL CAMPO [COBRADOR] O ALMENOS [FECHA]");

            }
            return ans;


        }


        private static string[] dato;
        public static string[] getdato() { return dato; }
        private int id;
        public bool Fillbuscador(ComboBox transaccion,ComboBox tipodato, TextBox monto, ComboBox formapago, ComboBox mes, string orden)
        { dato = new string[8];
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            try
            {

                if (read.Read() == true)
                {
                    dato[0] = read["ID"].ToString();
                    dato[1] = read["MOTIVO"].ToString();
                    dato[2] = read["FECHA DEL MOVIMIENTO"].ToString();
                    dato[3] = read["HORA DEL MOVIMIENTO"].ToString();


                    tipodato.Text = read["TIPO DE MONEDA"].ToString();
                    
                    string cant = read["INGRESO"].ToString();
                    transaccion.Text = "INGRESO";

                    if (cant == "")
                    {
                        cant = read["GASTO"].ToString();
                        transaccion.Text = "GASTO";
                    }
                    monto.Text = cant;
                    dato[4] = monto.Text;
                    dato[5] = read["TIPO DE MONEDA"].ToString();
                    dato[6] = read["EXPLICACION"].ToString();
                    


                    formapago.Text = read["FORMA DE PAGO"].ToString();
                    dato[7] = read["FORMA DE PAGO"].ToString();
                    string month = read["MES"].ToString();

                    switch (month)
                    {

                        case "1":
                            mes.Text = "ENERO";
                            break;

                        case "2":
                            mes.Text = "FEBRERO";
                            break;

                        case "3":
                            mes.Text = "MARZO";
                            break;

                        case "4":
                            mes.Text = "ABRIL";

                            break;

                        case "5":
                            mes.Text = "MAYO";
                            break;

                        case "6":
                            mes.Text = "JUNIO";
                            break;

                        case "7":
                            mes.Text = "JULIO";

                            break;

                        case "8":
                            mes.Text = "AGOSTO";

                            break;

                        case "9":
                            mes.Text = "SEPTIEMBRE";
                            break;

                        case "10":
                            mes.Text = "OCTUBRE";
                            break;

                        case "11":
                            mes.Text = "NOVIEMBRE";

                            break;

                        case "12":
                            mes.Text = "DICIEMBRE";

                            break;

                    }

                    string fechar = read["HORA DEL MOVIMIENTO"].ToString();

                    string hor = "";

                    ans = true;
                    //foreach (string pad in dato) { MessageBox.Show(pad); }
                }
                else {

                    MessageBox.Show("DEBES SELECCIONAR EL CAMPO [MOTIVO] O ALMENOS [HORA DEL MOVIMIENTO]");
                    ans = false;
                }
              

                conection.Close();

            }
            catch (IndexOutOfRangeException op) {
                ans = false;
                conection.Close();
                MessageBox.Show("DEBES SELECCIONAR EL CAMPO [MOTIVO] O ALMENOS [HORA DEL MOVIMIENTO]");
            }

            return ans;

          
        }


        private bool ans;
        private string str;
        public string getstr() {

            return str;
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


        public double getsuma(Label label,string tpo, string orden, string colum) {
            double cuenta = 0;

            try {



                command = new MySqlCommand(orden, conection);
                conection.Open();

                read = command.ExecuteReader();
                if (read.Read() == true)
                {

                    label.Text = tpo + " " + read["SUM(" + colum + ")"].ToString();
                    str = read["SUM(" + colum + ")"].ToString();


                }
                else
                {

                    cuenta = 0.00;
                }



                conection.Close();
            }
            catch (IndexOutOfRangeException exept) {

                cuenta = 0.00;
                conection.Close();
                //MessageBox.Show(exept.ToString());
            }
            catch (MySqlException exep) {

                cuenta = 0.00;
                conection.Close();
                //MessageBox.Show(exep.ToString());
            }
            //cuenta = Convert.ToDouble( str);
            return cuenta;

        }

        

        public int getidmovement() { return idmovement; }
        public string getdate() { return datemovement; }
        public string gettime() { return timemovement; }
        public double getprofit() { return profit; }
        public double getexpense() { return expense; }
        public string getmessage() { return userMessage; }
    }
}
