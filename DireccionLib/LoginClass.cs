using DireccionLib;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DireccionLib 
{
    public class LoginClass
    {

        private string userName;
        private string userPassword;
        private string pictureroute; 
        private string question1;
        private string question2;
        private string question3;
        private string question4;
        private string question5;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private string answer5;
        private bool answer;
        private string message;
        
        private bool savedataanswer;
        private bool createtablestudentanswer;
        public bool createtablemovementanswer;
        
        private bool createtableemployeeanswer;

        private static string server;
        private static string database;
        private static string userdatabase;
        private static string password;
        private static string port;
        MySqlConnection conection = new MySqlConnection("Persist Security Info=False; server= "+server+"; database="+database+"; uid="+userdatabase+"; password="+password+"; Port="+port+";");
        MySqlCommand command;
        MySqlDataReader read;
        MySqlDataAdapter dataadapter;
        DataTable datatable;

        public LoginClass() { }

        public LoginClass(string dbserver, string db, string dbuser, string dbpass, string dbport)
        {

            server = dbserver;
            database = db;
            userdatabase = dbuser;
            password = dbpass;
            port = dbport;

        }

        public LoginClass(string userName, string userPassword, string pictureroute, string question1, string question2, string question3, string question4, string question5, string answer1, string answer2, string answer3, string answer4, string answer5) 
        {
            this.userName= userName; 
            this.userPassword=userPassword;
            this.pictureroute=pictureroute; 
            this.question1=question1; 
            this.question2=question2; 
            this.question3=question3; 
            this.question4=question4; 
            this.question5=question5; 
            this.answer1=answer1; 
            this.answer2=answer2; 
            this.answer3=answer3;
            this.answer4=answer4;
            this.answer5 = answer5;
        }

        public static void setOtherConecction(string serverdb, string databasedb, string userdb, string passworddb, string portdb) {
            server = serverdb;
            database = databasedb;
            userdatabase = userdb;
            password = passworddb;
            port = portdb;
    }



        public bool setConectionsecurity(string userName, string userPassword, string ans1, string ans2, string ans3, string ans4, string ans5)
        {

            try
            {


                conection.Open();

                command = new MySqlCommand("select * from  USERS_TABLE where USER_NAME = '" + userName + "' and USER_PASSWORD = '" + userPassword + "' AND ANSWER1='"+ans1+ "' AND ANSWER2='" + ans2 + "' AND ANSWER3='" + ans3 + "' AND ANSWER4='" + ans4 + "' AND ANSWER5='" + ans5 + "';", conection);
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;
                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {

                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
                message = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
                message = mistake.ToString();
                conection.Close();
            }

            return answer;
        }


        public bool setConection(string userName, string userPassword) {

            try {


                conection.Open();

                command = new MySqlCommand("select * from  USERS_TABLE where USER_NAME = '" + userName + "' and USER_PASSWORD = '" + userPassword + "'", conection);
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;
                conection.Close(); 
                
            }
            catch (InvalidOperationException mistake) {

                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
                message = mistake.ToString();
                conection.Close();
            }
            catch (IndexOutOfRangeException d)
            {
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake) {
                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
                message = mistake.ToString();
                conection.Close();
            }
            
            return answer;
        }

        public string getback(string columna,string orden)
        {

            string data = "";
            try
            {
                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    data = read[columna].ToString();

                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();
            }
            catch (MySqlException d)
            {
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d) {
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }

            return data;
        }
        public bool fillpic(TextBox picturebox, string orden)
        {

            //nombre for where clause
            try
            {
                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    string ruta = read["PICTURE_ROUTE"].ToString();


                    if (ruta != "") { picturebox.Text = ruta; }


                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();
            }
            
            catch (MySqlException d)
            {
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d) {
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            return answer;
        }

        public bool fillsecurity(Label user, Label preg1,Label preg2, Label preg3, Label preg4, Label preg5, TextBox pop, string orden)
        {
            try {

                //nombre for where clause
                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    user.Text = read["USER_NAME"].ToString();
                    preg1.Text = read["QUESTION1"].ToString();
                    preg2.Text = read["QUESTION2"].ToString();
                    preg3.Text = read["QUESTION3"].ToString();
                    preg4.Text = read["QUESTION4"].ToString();
                    preg5.Text = read["QUESTION5"].ToString();
                    pop.Text = read["PICTURE_ROUTE"].ToString();

                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();
            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                answer = false;
                message = mistake.ToString();
                conection.Close();
            }

            

            return answer;
        }




        public bool fillevery(TextBox user,TextBox pass, ComboBox tipouser, TextBox preg1, TextBox res1, TextBox preg2, TextBox res2, TextBox preg3, TextBox res3, TextBox preg4, TextBox res4, TextBox preg5, TextBox res5, TextBox pic,TextBox institucion,TextBox telefono, TextBox email, string orden)
        {
            try {
                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    user.Text = read["USER_NAME"].ToString();

                    pass.Text = read["USER_PASSWORD"].ToString();

                    preg1.Text = read["QUESTION1"].ToString();
                    res1.Text = read["ANSWER1"].ToString();

                    preg2.Text = read["QUESTION2"].ToString();
                    res2.Text = read["ANSWER2"].ToString();

                    preg3.Text = read["QUESTION3"].ToString();
                    res3.Text = read["ANSWER3"].ToString();

                    preg4.Text = read["QUESTION4"].ToString();
                    res4.Text = read["ANSWER4"].ToString();

                    preg5.Text = read["QUESTION5"].ToString();
                    res5.Text = read["ANSWER5"].ToString();


                    pic.Text = read["PICTURE_ROUTE"].ToString();
                    institucion.Text = read["INSTITUCION"].ToString();
                    telefono.Text = read["TELEFONO"].ToString();
                    email.Text = read["EMAIL"].ToString();
                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();
            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                answer = false;
                message = mistake.ToString();
                conection.Close();
            }
                        
            return answer;
        }

        public bool filldatapropia(TextBox institucion, TextBox telefono, TextBox email, string orden) {

            try {


                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {

                    institucion.Text = read["INSTITUCION"].ToString();
                    telefono.Text = read["TELEFONO"].ToString();
                    email.Text = read["EMAIL"].ToString();
                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();


            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                answer = false;
                message = mistake.ToString();
                conection.Close();
            }

            return answer;
        }

        public bool filltwo(Label tipouser, Label nameuser,Label email,Label telefono, TextBox picturebox, string orden)
        {

            try {
                //nombre for where clause
                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    tipouser.Text = "EDUCACION " + read["USERTIPO"].ToString();
                    picturebox.Text = read["PICTURE_ROUTE"].ToString();
                    nameuser.Text = read["INSTITUCION"].ToString();
                    email.Text = read["EMAIL"].ToString();
                    telefono.Text = read["TELEFONO"].ToString();

                    answer = true;
                }
                else
                {

                    answer = false;
                }

                conection.Close();

            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                answer = false;
                message = mistake.ToString();
                conection.Close();
            }

            

            return answer;
        }

        public bool FillUserBox(ComboBox combo) {


            try {
                command = new MySqlCommand("select * from USERS.USERS_TABLE;", conection);
                               
                answer = true;
                conection.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    userName = read.GetString("USER_NAME");
                    combo.Items.Add(userName);
                }
                conection.Close();

            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception mistake)
            {
                answer = false;
                message = mistake.ToString();
                conection.Close();
            }

            
            return answer;
         }

        public bool UserNoCopied(string userName) 
        {

            command = new MySqlCommand("SELECT * FROM USERS_TABLE where USER_NAME='" + userName + "';", conection);


            try
            {

                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;
                conection.Close();
            }
            catch (MySqlException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception problem)
            {
                conection.Close();
                message = problem.ToString();
            }
            
            
            
            
            return answer;      
        
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

                expsql.ToString();
            }
            catch (InvalidOperationException apd)
            {
                apd.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception problem)
            {
                conection.Close();
                message = problem.ToString();
            }
        }

        public void ShowDataGrid(DataGridView findinggrid)
        {            
                string orden = "SELECT ID, USER_NAME,USERTIPO,FECHA_CREACION,FECHA_LAST_CONECTION,HORA_LAST_CONECTION FROM users.users_table;";
                       
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
            catch (MySqlException expsql)
            {

                expsql.ToString();
            }
            catch (InvalidOperationException apd)
            {
                apd.ToString();
            }
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception problem)
            {
                conection.Close();
                message = problem.ToString();
            }


        }


        private int cuenta;
        public int getcuenta() { return cuenta; }

        public void ShowDataGridFound(DataGridView findinggrid, string orden)
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
                argument.ToString();

                conection.Close();
            }
            catch (MySqlException pr) {
                pr.ToString();
                conection.Close();
            }
            catch (InvalidOperationException ps) {
                ps.ToString();
                conection.ToString();
            }
            
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();

            }
            catch (Exception problem)
            {
                conection.Close();
                message = problem.ToString();
            }
        }

        public bool SaveData(string userName, string userPassword, string pictureroute, string question1, string question2, string question3, string question4, string question5, string answer1, string answer2, string answer3, string answer4, string answer5,string fecha, string hora, string tipouser, string institucion, string telefono, string email) 
        {


            command = new MySqlCommand("INSERT into USERS_TABLE (USER_NAME, USER_PASSWORD, QUESTION1, ANSWER1, QUESTION2, ANSWER2, QUESTION3, ANSWER3, QUESTION4, ANSWER4, QUESTION5, ANSWER5, PICTURE_ROUTE, USERTIPO, `FECHA_CREACION`, `HORA_CREACION`, INSTITUCION , TELEFONO , EMAIL) values ('" + userName + "', '" + userPassword + "' , '" + question1 + "', '" + answer1 + "', '" + question2 + "', '" + answer2 + "','" + question3 + "','" + answer3 + "', '" + question4 + "','" + answer4 + "','" + question5 + "', '" + answer5 + "','" + pictureroute + "','" + tipouser + "','" + fecha + "','" + hora + "','" + institucion + "','" + telefono + "','" + email + "' )", conection);

            
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) savedataanswer = true;
                else savedataanswer = false;
                conection.Close();
            }
         
            catch (IndexOutOfRangeException d)
            {
                answer = false;
                conection.Close();
                d.ToString();
                                        
            }

            catch (InvalidOperationException mistake) 
            { 
                message = mistake.ToString(); 
                conection.Close();
                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
            }
            catch (MySqlException mistake)
            {
                message = mistake.ToString();
                conection.Close();
                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
            }
            catch (Exception mistake) 
            { 
                message = mistake.ToString();
                conection.Close();
                MessageBox.Show("HAY PROBLEMAS CON LA BASE DE DATOS, REVISE LA CONECCIONES O AGREGUE UN NUEVO PERFIL DE BASE DE DATOS");
            }

   
                return savedataanswer; 
        }

       

        public bool CreateEventTable(string nameUser)
        {
            string complete = nameUser + "_events_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int (20) NOT NULL AUTO_INCREMENT,  `DESCRIPCION` varchar(50) NOT NULL,  `FECHA`  varchar(12) not null,  `HORA` varchar(12) not null,  `PRIORIDAD` int(3) NOT NULL, `LUNES` VARCHAR(2) NOT NULL,`MARTES` VARCHAR(2) NOT NULL,  `MIERCOLES` VARCHAR(2) NOT NULL,  `JUEVES` VARCHAR(2) NOT NULL,  `VIERNES` VARCHAR(2) NOT NULL,  `SABADO` VARCHAR(2) NOT NULL,  `DOMINGO` VARCHAR(2) NOT NULL,`FECHA DE RECORDATORIO` VARCHAR(20),`ACTIVO` VARCHAR(2) NOT NULL, `SONIDO` VARCHAR(100),  PRIMARY KEY(`ID`)); ", conection);
           
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtableemployeeanswer = true;
                else createtableemployeeanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString();
                conection.Close();
                MessageBox.Show(message);
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
                MessageBox.Show(message);
            }


            return createtableemployeeanswer;
        }
        private string dato;
        public string takedatatable(string orden, string columna) {
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                
                dato = read[columna].ToString();
                
                
            }
 

            conection.Close();
            return dato;
        }
        public void createDatabase(string server, string port, string database, string username, string password)
        {
            string connectionstring = string.Format("Server = "+server+ "; Port =" + port + "; Uid = " + username + "; Pwd = " + password + "; pooling = true; Allow Zero Datetime = False; Min Pool Size = 0; Max Pool Size = 200; ");
            using (var con = new MySqlConnection { ConnectionString = connectionstring })
            {
                using (var command = new MySqlCommand { Connection = con })
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();

                    try
                    {
                        con.Open();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message + " ERROR DURANTE EL PROCESO.");
                        return;
                    }

                    try
                    {
                        command.CommandText = "CREATE DATABASE IF NOT EXISTS "+database;
                        command.Parameters.AddWithValue("@database", database);
                        command.ExecuteNonQuery();//Execute your command
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message + " ERROR DURANTE EL PROCESO");
                        return;
                    }
                }
            }

        }
        public void CreateSchema(string name)
        {
      
            createDatabase(server,port,name,userdatabase,password);
        }

        public void FillFieldsForm(ComboBox combo)
        {
            string userName;
            command = new MySqlCommand("select distinct USER_NAME from USERS.USERS_TABLE;", conection);


            try
            {

                conection.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    userName = read.GetString("USER_NAME");
                    combo.Items.Add(userName);
                }



                conection.Close();
            }
            catch (Exception problem)
            {
                conection.Close();
                problem.ToString();
            }




        }
        public bool filllabel(Label hora, Label fecha, string orden)
        {
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                fecha.Text = read["FECHA_LAST_CONECTION"].ToString();
                hora.Text = read["HORA_LAST_CONECTION"].ToString();
                

            }
            

            conection.Close();

            return answer;
        }

        private static string[] data;
        public static string[] getdata() { return data; }

        public bool fillcombo(ComboBox tipo, ComboBox name, string orden)
        {
            data = new string[2];
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                tipo.Text = read["USERTIPO"].ToString();
                name.Text = read["USER_NAME"].ToString();
                data[0] = read["ID"].ToString();
                data[1] = read["FECHA_CREACION"].ToString();
                answer = true;
            }
            else {
                answer = false;
                MessageBox.Show("SELECCIONE EL NOMBRE DEL USUARIO");
            }


            conection.Close();

            return answer;
        }

        public bool fillcombos(ComboBox mame, ComboBox telefono, string orden)
        {
            
            try
            {
                data = new string[4];

                command = new MySqlCommand(orden, conection);
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read() == true)
                {
                    mame.Text = read["NOMBRE"].ToString();
                    telefono.Text = read["TELEFONO"].ToString();
                    data[0] = read["DIRECCION"].ToString();
                    data[1] = read["EMAIL"].ToString();
                    data[2] = read["ID"].ToString();
                    answer = true;
                }
                else
                {
                    answer = false;
                    MessageBox.Show("SELECCIONE EL NOMBRE");
                }


                conection.Close();
            }
            catch (IndexOutOfRangeException ex) {
                ex.ToString();
                conection.Close();
            }

            return answer;
        }


        public bool CreateUsertabla()
        {
            command = new MySqlCommand("CREATE TABLE if not exists `users_table` ( `ID` int (6) NOT NULL AUTO_INCREMENT,  `USER_NAME` varchar(40) NOT NULL,  `USER_PASSWORD` varchar(30) NOT NULL,  `QUESTION1` varchar(400) NOT NULL,  `ANSWER1` varchar(400) NOT NULL,  `QUESTION2` varchar(400) NOT NULL,  `ANSWER2` varchar(400) NOT NULL,  `QUESTION3` varchar(400) NOT NULL,  `ANSWER3` varchar(400) NOT NULL,  `QUESTION4` varchar(400) NOT NULL,  `ANSWER4` varchar(400) NOT NULL,  `QUESTION5` varchar(400) NOT NULL,  `ANSWER5` varchar(400) NOT NULL,  `PICTURE_ROUTE` varchar(400) DEFAULT NULL,  `USERTIPO` varchar(50) DEFAULT NULL, `FECHA_CREACION` varchar(14), `HORA_CREACION` varchar(14), `FECHA_LAST_CONECTION` varchar(14), `HORA_LAST_CONECTION` varchar(14), INSTITUCION varchar(40), TELEFONO varchar(20), EMAIL varchar(50), PRIMARY KEY(`ID`),  UNIQUE KEY `USER_NAME` (`USER_NAME`));", conection);

            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtableemployeeanswer = true;
                else createtableemployeeanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString(); conection.Close();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }


            return createtableemployeeanswer;
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
            catch (InvalidOperationException por) {
                por.ToString();
            }
            catch (MySqlException pa) { pa.ToString(); }

        }

        public bool CreateEmployeeTable(string nameUser) 
        {
            string complete = nameUser + "_employee_table";


            command = new MySqlCommand("create table if not exists " + complete + "(ID int(5) not null auto_increment,`NOMBRE COMPLETO` varchar(50) not null, CEDULA varchar(20) not null, `FECHA DE NACIMIENTO` varchar(50) not null, `TITULO UNIVERSITARIO` varchar(40) not null, PUESTO varchar(30) not null, TELEFONO varchar(20) not null, HORARIO varchar(20) not null, EDAD int(3) not null, SUELDO double(6,2) not null,`REFERENCIA PERSONAL` varchar(30) not null, `TELEFONO DE REFERENCIA` varchar(20) not null, `RELACION DE REFERENCIA` varchar (30) not null, `NOMBRE DE ALERGIA` varchar(20) not null, `NOMBRE DE DOLENCIA` varchar(30) not null, `NOMBRE DE MEDICINA` varchar (30) not null, `RAZON DE MEDICINA` varchar(40) not null, `TRABAJANDO` varchar(4) not null, `RUTA DE FOTO` text, `FECHA DE ENTRADA` varchar(50), `FECHA DE SALIDA` TEXT, `TIPO MONEDA` varchar(10),NACIONALIDAD varchar(20), SEXO varchar(20), DIRECCION varchar(100), EMAIL varchar(100), primary key(ID)); " + "ALTER TABLE " + complete + " ADD UNIQUE INDEX(`NOMBRE COMPLETO`);", conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtableemployeeanswer = true;
                else createtableemployeeanswer = false;


                conection.Close();

            }
            catch (InvalidOperationException mistake)
            {
                message = mistake.ToString(); conection.Close();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
            }
            
            
            return createtableemployeeanswer; 
        }

        public bool CreateMovementsTable(string nameUser)
        {

            string complete = nameUser+"_movements_table";


            command = new MySqlCommand("create table if not exists " + complete + "(`FECHA DEL MOVIMIENTO` VARCHAR(11) not null, `HORA DEL MOVIMIENTO` VARCHAR(11) not null, MOTIVO varchar(60) not null, INGRESO double(20,2), GASTO double(20,2),`TIPO DE MONEDA` VARCHAR(4), ID int(30) not null auto_increment, `DIA` int(2), `MES` varchar(11), `AÑO` int(5),HORA int(3),`MINUTO` int(3), `SEGUNDO` int(3),`EXPLICACION` text,`FORMA DE PAGO` VARCHAR(50),   primary key(ID));" + "ALTER TABLE " + complete + " ADD UNIQUE INDEX(ID);", conection);
            
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtableemployeeanswer = true;
                else createtableemployeeanswer = false;


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
            return createtablemovementanswer;
        }

        public bool CreateStudentTable(string nameUser) 
        {
            string complete = nameUser + "_student_table";

            command = new MySqlCommand("create table if not exists " + complete + " (ID int(10) not null auto_increment, `NOMBRE COMPLETO` varchar(60) not null,  EDAD int(3) not null, CURSO varchar(40) not null, HORARIO varchar(20) not null, NACIONALIDAD varchar(30) not null, `NUMERO DE ACTA` varchar(10) not null, PROVINCIA varchar(30) not null, MUNICIPIO varchar(30) not null, OFICIALIA varchar(30) not null, LIBRO varchar(10) not null, FOLIO varchar(10) not null, AÑO int(4) not null, `FECHA DE NACIMIENTO` varchar(50) not null, SEXO varchar(20) not null,  TELEFONO varchar(20) not null, DIRECCION varchar(60) not null, `NOMBRE DE ALERGIA` varchar(60) not null, `NOMBRE DE MEDICINA` varchar(30) not null, `RAZON DE MEDICINA` varchar(80) not null, SINDROME varchar(30) not null, `NOMBRE DEL TUTOR` varchar(60) not null, `CEDULA DEL TUTOR` varchar(20) not null, `NACIONALIDAD DEL TUTOR` varchar(20) not null, MENSUALIDAD double(8,2) not null , `NOMBRE DE EMPRESA` varchar(30) not null, `TELEFONO DE EMPRESA` varchar(20) not null, ESTUDIANDO varchar(4) not null, `RUTA DE FOTO` text, `FECHA DE SALIDA` varchar(50), `FECHA DE ENTRADA` varchar(50), `TIPO MONEDA` varchar(10), EMAIL VARCHAR(100),`PARENTESCO` VARCHAR(10), primary key(ID) );", conection);

            
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
                conection.Close();
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                conection.Close();
               
            }
            
            return createtablestudentanswer;
        }
        private string va;
        public string getva() { return va; }
        public string getsqldato(string orden, string columna) {

            va="";
            
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                
                va= read[columna].ToString();
                

                answer = true;
            }
            else
            {

                answer = false;
            }

            conection.Close();

            return va;
        }

        public bool CreateSubjectTable(string nameUser)
        {
            string complete = "`"+nameUser + "_subject_table`";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, ASIGNATURA varchar(60) not null, ASIGNADO varchar(60) not null,DESCRIPCION VARCHAR(60), primary key(ID) );" , conection);


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
                MessageBox.Show(mistake.ToString());

            }

            return createtablestudentanswer;
        }
        public bool AddSubject(string asignatura, string asignado,string descripcion, string nameUser)
        {
            string complete = nameUser + "_subject_table";

            command = new MySqlCommand("INSERT into `" + complete + "` (ASIGNATURA , ASIGNADO,DESCRIPCION) values ('" + asignatura + "','" + asignado + "','" + descripcion + "' );", conection);

            
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
                
            }

            return createtablestudentanswer;
        }
        public bool editSubject(string asignatura, string asignado,string descripcion, string oldasignatura, string oldasignado, string nameUser)
        {
            string complete = "`"+nameUser + "_subject_table`";

            command = new MySqlCommand("UPDATE " + complete + " SET `ASIGNATURA`='" + asignatura + "' , ASIGNADO ='" + asignado + "', DESCRIPCION='" + descripcion + "' WHERE `ASIGNATURA`='" + oldasignatura + "' AND ASIGNADO ='" + oldasignado + "';", conection);


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

            }

            return createtablestudentanswer;
        }
        public bool deleteSubject(string oldasignatura, string oldasignado, string nameUser)
        {
            string complete ="`"+ nameUser + "_subject_table`";

            getsqldato("SELECT ID FROM " + complete + " WHERE `ASIGNATURA`='" + oldasignatura + "' AND ASIGNADO ='" + oldasignado + "';", "ID");
            
            command = new MySqlCommand("DELETE FROM " + complete + " WHERE `ID`='" + va +"';", conection);


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
                MessageBox.Show(message);
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);

            }

            return createtablestudentanswer;
        }

        public bool CreateContactsTable(string nameUser)
        {
            string complete = nameUser + "_contacts_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, TELEFONO varchar(60) , EMAIL varchar(60) , DIRECCION varchar(60), primary key(ID) );" , conection);


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
                MessageBox.Show(mistake.ToString());
            }

            return createtablestudentanswer;
        }
        public bool AddContact(string nombre, string telefono, string direccion, string email, string nameUser)
        {
            string complete = nameUser + "_contacts_table";
            //NOMBRE, TELEFONO, EMAIL, DIRECCION 
            command = new MySqlCommand("INSERT into " + complete + " (NOMBRE, TELEFONO, EMAIL, DIRECCION) values ('" + nombre + "','" + telefono + "','" + email + "','" + direccion + "' );", conection);


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
        public bool editContact(string nombre, string telefono, string direccion, string email, string oldnombre, string nameUser)
        {
            string complete = nameUser + "_contacts_table";

            command = new MySqlCommand("UPDATE " + complete + " SET NOMBRE='" + nombre + "' , TELEFONO ='" + telefono + "', EMAIL ='" + email + "', DIRECCION ='" + direccion + "' WHERE NOMBRE='" + oldnombre + "';", conection);


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

            }

            return createtablestudentanswer;
        }
        public bool deleteContact(string oldnombre, string nameUser)
        {
            string complete = nameUser + "_contacts_table";

            command = new MySqlCommand("DELETE FROM " + complete + " WHERE `NOMBRE`='" + oldnombre + "' ;", conection);


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

            }

            return createtablestudentanswer;
        }
        public bool Createperiodtable(string nameUser)
        {
            string complete = nameUser + "_period_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment,PERIODO varchar(20) not null, MESES int(2) not null,primary key(ID) );", conection);


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
                MessageBox.Show(mistake.ToString());
            }

            return createtablestudentanswer;
        }

        

        public bool CreateAsistanceStudentTable(string nameUser)
        {
            string complete = nameUser + "_asistance_student_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null, CURSO varchar(40) not null,ESTADO VARCHAR(20) not null,primary key(ID) );" , conection);


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
                MessageBox.Show(mistake.ToString());
            }

            return createtablestudentanswer;
        }
        public bool CreateAsistanceEmployeeTable(string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null,ESTADO varchar(20) not null,  primary key(ID) );", conection);


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
                MessageBox.Show(mistake.ToString());
            }

            return createtablestudentanswer;
        }
        
        
        public bool CreateCalificationEmployeeTable(string nameUser)
        {
            string complete = "`"+nameUser + "_calification_employee_table`";

            command = new MySqlCommand("create table if not exists" + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null,  primary key(ID) );", conection);


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

            }

            return createtablestudentanswer;
        }
        public bool CreateCalificationStudentTable(string nameUser)
        {
            string complete = "`"+nameUser+"_calification_student_table`";
            
            command = new MySqlCommand("create table if not exists" + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),ASIGNATURA VARCHAR(50) not null ,CURSO VARCHAR(20) NOT NULL , PROFESOR VARCHAR(20) NOT NULL ,PERIODO varchar(30) not null, `FIN DE PERIODO` varchar(4), COMPLETIVO varchar(4), `EXTRA ORDINARIO` varchar(4), ESPECIAL varchar(4), ESTADO varchar(12),  primary key(ID) );", conection);


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

            }
            
            return createtablestudentanswer;
        }
 



        private string orden;
        private string getordersql(string mes, string calf,string oldnombre, string oldperiodo, string complete) {

            if (mes == "enero" || mes == "ENERO")
            {

                orden = "UPDATE " + complete + " ENERO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "febrero" || mes == "FEBRERO")
            {
                orden = "UPDATE " + complete + " FEBRERO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "marzo" || mes == "MARZO")
            {
                orden = "UPDATE " + complete + " MARZO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "abril" || mes == "ABRIL")
            {
                orden = "UPDATE " + complete + " ABRIL = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "mayo" || mes == "MAYO")
            {
                orden = "UPDATE " + complete + " MAYO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "junio" || mes == "JUNIO")
            {
                orden = "UPDATE " + complete + " JUNIO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "julio" || mes == "JULIO")
            {
                orden = "UPDATE " + complete + " JULIO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "agosto" || mes == "AGOSTO")
            {
                orden = "UPDATE " + complete + " AGOSTO = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "septiembre" || mes == "SEPTIEMBRE")
            {
                orden = "UPDATE " + complete + " SEPTIEMBRE = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "octubre" || mes == "OCTUBRE")
            {
                orden = "UPDATE " + complete + " OCTUBRE = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "nomviembre" || mes == "NOVIEMBRE")
            {
                orden = "UPDATE " + complete + " NOVIEMBRE = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }
            else if (mes == "diciembre" || mes == "DICIEMBRE")
            {
                orden = "UPDATE " + complete + " DICIEMBRE = '" + calf + "'  WHERE NOMBRE = '" + oldnombre + "' and PERIODO = '" + oldperiodo + "';";

            }

            return orden;

        }

      
      


        public bool CreateDocumentMissingTable(string nameUser)
        {
            string complete = nameUser + "_DocMiss_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null,FECHA varchar(20) not null, DOCUMENTO string(40), `ROL` varchar(20),  primary key(ID) );", conection);


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

        public bool CreateCountAskForTable(string nameUser)
        {
            string complete = nameUser + "_askfor_table";

            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `DEUDOR` varchar(60) not null,FECHA varchar(20) not null, CANTIDAD double(10,2), `TIPO MONEDA` varchar(10),  primary key(ID) );", conection);


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
        

        public bool CreateCountPayForTable(string nameUser)
        {
            string complete = nameUser + "_payfor_table";
            //`COBRADOR`
            command = new MySqlCommand("create table if not exists " + complete + "(ID int(10) not null auto_increment, `COBRADOR` varchar(60) not null,FECHA varchar(20) not null, CANTIDAD double(10,2), `TIPO MONEDA` varchar(10),  primary key(ID) );", conection);


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
        



        public bool createruta(string nombre) {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\"+nombre;
            string path2= Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\" + nombre;

            string path3 = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\" + nombre;
            //Environment.
            //string file = "\\" + UserAccessForm.getusername() + "\\" + C.Text + ageBox.Text + ".txt";
            // Specify the directory you want to manipulate.
            //string path = @"c:\MyDir";

            try
                {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    // Console.WriteLine("That path exists already.");
                    answer = true;
                }
                else {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                if (Directory.Exists(path2))
                {
                    answer = true;
                }
                else {

                    DirectoryInfo di2 = Directory.CreateDirectory(path2);
                }
                if (Directory.Exists(path3))
                {
                    answer = true;
                }
                else {

                    DirectoryInfo di3 = Directory.CreateDirectory(path3);
                }
                // Try to create the directory.
                    

                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
                }
                catch (Exception e)
                {
                //Console.WriteLine("The process failed: {0}", e.ToString());
                answer = false;
                }
                finally { }
            

            return answer;
        }
        public bool ordensql(string orden)
        {

            command = new MySqlCommand(orden, conection);
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) { answer = true; }
                else { answer = false; }
                conection.Close();

            }
            catch (Exception problem)
            {
                conection.Close();
                problem.ToString();
                MessageBox.Show(problem.ToString());
                answer = false;
            }

            return answer;
        }

        public void ordenNonsql(string orden)
        {

            command = new MySqlCommand(orden, conection);
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
                
                conection.Close();

            }
            catch (Exception problem)
            {
                conection.Close();
                problem.ToString();
                MessageBox.Show(problem.ToString());
                
            }

            
        }

        public bool CreateNewUser(string userName, string userPassword, string pictureroute, string question1, string question2, string question3, string question4, string question5, string answer1, string answer2, string answer3, string answer4, string answer5, string tipouser,string fecha, string hora, string institucion, string telefono, string email) 
        {
            if (SaveData(userName, userPassword, pictureroute, question1, question2, question3, question4, question5, answer1, answer2, answer3, answer4, answer5,fecha,hora, tipouser, institucion,telefono,email) != true )
            {
                OrderID();
                createruta(userName);
                answer = true; 
            }
            else
            {
                answer = false;
            }
            
            return answer;
        }

        public void OrderID() 
        {
            string command1 = "ALTER TABLE users_table DROP ID;";
            string command2 = "ALTER TABLE users_table ADD ID INT(6) NOT NULL AUTO_INCREMENT FIRST, ADD PRIMARY KEY (ID);";
            command = new MySqlCommand(command1+command2, conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
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
        }
        public bool getAnswer() { return answer; }
        public string getMensajeUser() { return message; }
        public bool ReadData() { return answer; }
        public bool SearchData() { return answer; }
        public bool DeleteData() { return answer; }


        public string getusername() { return userName; }
        public string getuserpassword() { return userPassword; }



        public string getpictureroute(){ return pictureroute;}
        public string getquestion1() { return question1;}
        public string getquestion2() { return question2;}
        public string getquestion3() { return question3;}
        public string getquestion4() { return question4;}
        public string getquestion5() { return question5;}
        public string getanswer1() { return answer1; }
        public string getanswer2() { return answer2; }
        public string getanswer3() { return answer3; }
        public string getanswer4() { return answer4; }
        public string getanswer5() { return answer5; }

      
    }
}
