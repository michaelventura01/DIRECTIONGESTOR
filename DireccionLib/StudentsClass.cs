using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using DireccionLib;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace DireccionLib
{
    public class StudentsClass
    {

        private static int id;
        private string schedule;
        private string provincia;
        private string municipio;
        private string oficialiaJCE;
        private string book;
        private string folio;
        private int year;
        private string birthdate;
        private string sex;
        private string nameComplete;
        private int age;
        private string grade;
        private string dateIn;
        private string dateOut;
        private string telephoneNumber;
        private string direction;
        private string tutorName;
        private string tutorId;
        private string nacionality;
        private string tutordirection;
        private string tutorNacionality;
        private string studyingNow;
        private string telephoneTutorNumber;
        private string job;
        private string jobtelephoneNumber;
        private string adress;
        private string alergy;
        private string actNumber;
        private string specialmedicine;
        private string medicineReason;
        private string emergencyNumber;
        private string nameSindrome;
        private double mensuality;
        private string pictureroute;
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
        private DateTime datenow;

        public bool answer;
        private string userMessageStudent;
        
        public StudentsClass() { }
        
        public StudentsClass(string dbserver, string db, string dbuser, string dbpass, string dbport)
        {

            server = dbserver;
            database = db;
            userdatabase = dbuser;
            password = dbpass;
            port = dbport;

        }
        public StudentsClass(string schedule, string actNumber, string provincia, string municipio, string oficialiaJCE, string book, string folio, int year, string birthdate, string sex, string nameComplete, int age, string telephoneNumber, string direction, string tutorName, string tutorId, string nacionality, string tutordirection, string telephoneTutorNumber, string telephonenumber, string job, string jobtelephoneNumber, string alergy, string specialmedicine, string medicineReason, string emergencyNumber, string nameSindrome, double mensuality, string dateIn, string dateOut, string grade, string adress, string tutorNacionality, string studyinNow, string pictureroute)
        {
            
            this.schedule = schedule;
            this.actNumber = actNumber;
            this.provincia = provincia;
            this.municipio = municipio;
            this.oficialiaJCE = oficialiaJCE;
            this.book = book;
            this.folio = folio;
            this.year = year;
            this.birthdate = birthdate;
            this.sex = sex;
            this.nameComplete = nameComplete;
            this.age = age;
            this.telephoneNumber = telephoneNumber;
            this.direction = direction;
            this.tutorName = tutorName;
            this.tutorId = tutorId;
            this.nacionality = nacionality;
            this.tutordirection = tutordirection;
            this.telephoneTutorNumber = telephoneTutorNumber;
            this.job = job;
            this.jobtelephoneNumber = jobtelephoneNumber;
            this.alergy = alergy;
            this.specialmedicine = specialmedicine;
            this.medicineReason = medicineReason;
            this.emergencyNumber = emergencyNumber;
            this.nameSindrome = nameSindrome;
            this.mensuality = mensuality;
            this.grade = grade;
            this.dateIn = dateIn;
            this.dateOut = dateOut;
            this.adress = adress;
            this.tutorNacionality = tutorNacionality;
            this.pictureroute = pictureroute;

        }


        private static string namestatic = "";
        private static int edadstatic = 0;
        private static string cursostatic = "";
        public static string getstaticname() { return namestatic; }
        public static int getstaticedad() { return edadstatic; }
        public static string getstaticcurso() { return cursostatic; }

        public bool fillcombos(ComboBox name, ComboBox edad, ComboBox grado, string orden) {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {

                name.Text = read["NOMBRE COMPLETO"].ToString();
                edad.Text = read["EDAD"].ToString();
                grado.Text = read["CURSO"].ToString();
                namestatic = name.Text;
                edadstatic = int.Parse(edadstatic.ToString());
                cursostatic = grado.Text;
                answer = true;
            }
            else {
                name.Text = "";
                edad.Text = "";
                grado.Text = "";
                namestatic = "";
                edadstatic = 0;
                cursostatic = "";
                answer = false;

            }


            return answer;
        }

        public static void setid( int iD) { id = iD; }


        public bool filleverylabel(Label Edad, Label grado, Label horario, Label fechanacimiento, Label nacionalidad, Label telefono, 
            Label direccion, Label sexo, Label inscrito, Label fechaentrada, Label fechasalida, Label nroacta, Label folio, Label libro, Label anio, 
            Label oficialia, Label municipio, Label alergia, Label medicina, Label razonmedicina, Label sindrome, Label tutor, Label cedula, Label mensual, 
            Label tipomoneda,  TextBox rutafoto, Label parentesco, Label email, string orden)
        {

            //nombre for where clause
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                Edad.Text = read["EDAD"].ToString()+"  AÑOS";
                grado.Text = read["CURSO"].ToString();
                horario.Text = read["HORARIO"].ToString();
                fechanacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                nacionalidad.Text = read["NACIONALIDAD"].ToString();
                telefono.Text = read["TELEFONO"].ToString();
                direccion.Text = read["DIRECCION"].ToString();
                sexo.Text = read["SEXO"].ToString();
                inscrito.Text = read["ESTUDIANDO"].ToString();
                fechaentrada.Text = read["FECHA DE ENTRADA"].ToString();
                fechasalida.Text = read["FECHA DE SALIDA"].ToString();
                nroacta.Text = read["NUMERO DE ACTA"].ToString();
                folio.Text = read["FOLIO"].ToString();
                libro.Text = read["LIBRO"].ToString();
                anio.Text = read["AÑO"].ToString();
                oficialia.Text = read["OFICIALIA"].ToString();
                municipio.Text = read["MUNICIPIO"].ToString();
                alergia.Text = read["NOMBRE DE ALERGIA"].ToString();
                medicina.Text = read["NOMBRE DE MEDICINA"].ToString();
                razonmedicina.Text = read["RAZON DE MEDICINA"].ToString();
                sindrome.Text = read["SINDROME"].ToString();
                tutor.Text = read["NOMBRE DEL TUTOR"].ToString();
                cedula.Text = read["CEDULA DEL TUTOR"].ToString();
                mensual.Text = read["MENSUALIDAD"].ToString();
                
                tipomoneda.Text = read["TIPO MONEDA"].ToString();
                rutafoto.Text = read["RUTA DE FOTO"].ToString();
                parentesco.Text = read["PARENTESCO"].ToString();
                email.Text = read["EMAIL"].ToString();


               


                answer = true;
            }
            else
            {

                answer = false;
            }

            conection.Close();

            return answer;
        }


        public bool filleverything(ComboBox tanda, DateTimePicker entrada, ComboBox nacionalidad, TextBox nroacta, TextBox provincia, TextBox municipio, ComboBox oficialia, TextBox libro, TextBox folio, ComboBox year, DateTimePicker nacimiento, ComboBox sexo, ComboBox nombrecompleto, TextBox edad, ComboBox telefono, TextBox direccion, ComboBox curso,  ComboBox nombrealergia, ComboBox nombremedicamento, ComboBox motivomedicamento, ComboBox nombresindrome, TextBox nombretutor, TextBox cedulatutor, ComboBox tutornacionality, TextBox pago,  ComboBox empresa, ComboBox telefonoempresa,  ComboBox inscrito, TextBox foto, ComboBox moneda, ComboBox parentesco, ComboBox email, string orden)
        {

            
            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                foto.Text = read["RUTA DE FOTO"].ToString();
                tanda.Text = read["HORARIO"].ToString();
                entrada.Text = read["FECHA DE ENTRADA"].ToString();
                nacionalidad.Text = read["NACIONALIDAD"].ToString();

                nroacta.Text = read["NUMERO DE ACTA"].ToString();
                provincia.Text = read["PROVINCIA"].ToString();
                municipio.Text = read["MUNICIPIO"].ToString();
                oficialia.Text = read["OFICIALIA"].ToString();
                libro.Text = read["LIBRO"].ToString();
                folio.Text = read["FOLIO"].ToString();
                year.Text = read["AÑO"].ToString();
                moneda.Text = read["TIPO MONEDA"].ToString();




                nacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                sexo.Text = read["SEXO"].ToString();
                nombrecompleto.Text = read["NOMBRE COMPLETO"].ToString();
                edad.Text = read["EDAD"].ToString();
                telefono.Text = read["TELEFONO"].ToString();
                direccion.Text = read["DIRECCION"].ToString();
                curso.Text = read["CURSO"].ToString();


                nombrealergia.Text = read["NOMBRE DE ALERGIA"].ToString();

                
                nombremedicamento.Text = read["NOMBRE DE MEDICINA"].ToString();
                motivomedicamento.Text = read["RAZON DE MEDICINA"].ToString();
               


                nombresindrome.Text = read["SINDROME"].ToString();
               

                nombretutor.Text = read["NOMBRE DEL TUTOR"].ToString();
                cedulatutor.Text = read["CEDULA DEL TUTOR"].ToString();
                tutornacionality.Text = read["NACIONALIDAD DEL TUTOR"].ToString();
                pago.Text = read["MENSUALIDAD"].ToString();

                inscrito.Text = read["ESTUDIANDO"].ToString();

                empresa.Text = read["NOMBRE DE EMPRESA"].ToString();
                telefonoempresa.Text = read["TELEFONO DE EMPRESA"].ToString();
                parentesco.Text = read["PARENTESCO"].ToString();
                email.Text = read["EMAIL"].ToString();


                answer = true;
            }
            else
            {
                
                answer = false;
            }

            conection.Close();

            return answer;
        }

        public bool fillboxes(ComboBox name, DateTimePicker nacimiento, ComboBox edad, ComboBox grado, ComboBox inscrito, DateTimePicker getindateTimePicker, DateTimePicker getoutdateTimePicker, ComboBox inscritobox, Panel inscritopanel, string orden) {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read()==true) {
                nacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                edad.Text = read["EDAD"].ToString();
                grado.Text = read["CURSO"].ToString();
                inscrito.Text = read["ESTUDIANDO"].ToString();
                getindateTimePicker.Text = read["FECHA DE ENTRADA"].ToString();

                string fechasalida = read["FECHA DE SALIDA"].ToString();
                if (fechasalida == "00/00/0000" || fechasalida == "")
                {

                    
                    inscritopanel.Hide();
                }
                else
                {
                    

                    getoutdateTimePicker.Text = fechasalida;

                    inscritopanel.Show();

                }
                namestatic = name.Text;
                answer = true;

            }
            else {
                datenow = DateTime.Now;

                nacimiento.Text = datenow.ToString();
                edad.Text = "";
                grado.Text = "";
                inscrito.Text = "";
                MessageBox.Show("Asegurese de selecionar el campo [NOMBRE COMPLETO] en la tabla");
                name.Text = "";
                answer = false;
            }
            conection.Close();

            return answer;
        }

       public void FillFieldsForm(ComboBox combo) {
            
            command = new MySqlCommand("select distinct * from USERS.USERS_TABLE;", conection);
            

            try {

                conection.Open();
                read = command.ExecuteReader();
                while (read.Read()) {
                    //userName = read.GetString("USER_NAME");
                    //combo.Items.Add(userName);
                }



                conection.Close();
            }
            catch (Exception problem) { 
                conection.Close();
                userMessageStudent = problem.ToString(); 
            }



            
        }


        public bool ModifyData(string userDataName ,string nombre,string salida,  string inscrito) {

            


            command = new MySqlCommand("UPDATE " + userDataName + " SET `ESTUDIANDO` = '" + inscrito +"'  , `FECHA DE SALIDA`='" + salida + "' where  `NOMBRE COMPLETO` = '" + nombre + "';", conection);
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
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }

            

            return answer;
        }

        public bool ModifyData(string userDataName,string Nombre, string schedule, string actNumber, string provincia, string municipio, string oficialiaJCE, string book, string folio, int year, DateTimePicker birthdate, string sex, string nameComplete, int age, string telephoneNumber, string direction, string tutorName, string tutorId, string nacionality,  string telephonenumber, string job, string jobtelephoneNumber, string alergy, string specialmedicine, string medicineReason,  string nameSindrome, double mensuality, string pictureroute, string grade, string adress, string tutorNacionality, DateTimePicker dateIn, string inscrito, DateTimePicker dateout, string moneda, string parentesco, string email) {


            this.birthdate = birthdate.Value.Day.ToString() + "/" + birthdate.Value.Month.ToString() + "/" + birthdate.Value.Year.ToString();
            this.dateIn = dateIn.Value.Day.ToString() + "/" + dateIn.Value.Month.ToString() + "/" + dateIn.Value.Year.ToString();
            if (inscrito == "SI" || inscrito == "si") {
                this.dateOut = "00/00/0000";
                
            }
            else if (inscrito == "NO" || inscrito == "no")
            {
                this.dateOut = dateout.Value.Day.ToString() + "/" + dateout.Value.Month.ToString() + "/" + dateout.Value.Year.ToString();
            }

            command = new MySqlCommand("UPDATE " + userDataName + " SET `NOMBRE COMPLETO` = '" + nameComplete + "' ,  EDAD=  '" + age + "' , CURSO='" + grade + "' ,HORARIO='" + schedule + "', NACIONALIDAD =  '" + nacionality + "', `NUMERO DE ACTA`= '" + actNumber + "' , PROVINCIA='" + provincia + "' , MUNICIPIO='" + municipio + "', OFICIALIA ='" + oficialiaJCE + "', LIBRO ='" + book + "', FOLIO = '" + folio + "', AÑO='" + year + "', `FECHA DE NACIMIENTO`='" + this.birthdate + "' , SEXO='" + sex + "',  TELEFONO= '" + telephonenumber + "', DIRECCION= '" + adress + "', `NOMBRE DE ALERGIA`= '" + alergy + "', `NOMBRE DE MEDICINA` ='" + specialmedicine + "', `RAZON DE MEDICINA` = '" + medicineReason + "', SINDROME= '" + nameSindrome + "', `NOMBRE DEL TUTOR`= '" + tutorName + "', `CEDULA DEL TUTOR`= '" + tutorId + "', `NACIONALIDAD DEL TUTOR`='" + tutorNacionality + "', MENSUALIDAD= '" + mensuality + "' , `NOMBRE DE EMPRESA`= '" + job + "', `TELEFONO DE EMPRESA`='" + jobtelephoneNumber + "' , ESTUDIANDO= '" + inscrito + "', `FECHA DE ENTRADA`='" + this.dateIn + "',`RUTA DE FOTO` ='" + pictureroute + "', `FECHA DE SALIDA`='" + this.dateOut + "',`TIPO MONEDA`='"+moneda+ "' ,`PARENTESCO`='" + parentesco + "',`EMAIL`='" + email + "' where  `NOMBRE COMPLETO` = '" + Nombre+"' ;", conection);


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
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }


            return answer;


        }

        public bool addperiod(string periodo, int messes, string usuario) {

            string complete = usuario + "_period_table";
            command = new MySqlCommand("INSERT into " + complete + " (PERIODO,  MESES ) values ('" + periodo + "', '" + messes + "');", conection);
            
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
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            return answer;
        }
        public bool editperiod(string periodo, int messes, string usuario, string periodopass)
        {

            string complete = usuario + "_period_table";
            command = new MySqlCommand("UPDATE " + complete + " SET PERIODO= '" + periodo + "',  MESES ='" + messes + "' WHERE PERIODO='"+periodopass+"';", conection);



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
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            return answer;
        }


        public bool SaveData(string userDataName, string schedule, string actNumber, string provincia, string municipio, string oficialiaJCE, string book, string folio, int year, DateTimePicker birthdate, string sex, string nameComplete, int age, string telephoneNumber, string direction, string tutorName, string tutorId, string nacionality, string tutordirection, string telephoneTutorNumber, string telephonenumber, string job, string jobtelephoneNumber, string alergy, string specialmedicine, string medicineReason, string emergencyNumber, string nameSindrome, double mensuality, string pictureroute, string grade, string adress, string tutorNacionality, DateTimePicker dateIn, string moneda, string parentesco, string email) 
        {
            studyingNow = "SI";
            this.birthdate = birthdate.Value.Day.ToString() + "/" +birthdate.Value.Month.ToString() + "/" +birthdate.Value.Year.ToString();
            this.dateIn = dateIn.Value.Day.ToString() + "/" + dateIn.Value.Month.ToString() + "/" + dateIn.Value.Year.ToString();
            string ruta = pictureroute;

            command = new MySqlCommand("INSERT into " + userDataName + " (`NOMBRE COMPLETO`,  EDAD , CURSO ,HORARIO, NACIONALIDAD , `NUMERO DE ACTA` , PROVINCIA , MUNICIPIO, OFICIALIA , LIBRO , FOLIO , AÑO , `FECHA DE NACIMIENTO`, SEXO ,  TELEFONO, DIRECCION , `NOMBRE DE ALERGIA` , `NOMBRE DE MEDICINA` , `RAZON DE MEDICINA` , SINDROME, `NOMBRE DEL TUTOR`, `CEDULA DEL TUTOR`, `NACIONALIDAD DEL TUTOR`, MENSUALIDAD , `NOMBRE DE EMPRESA` , `TELEFONO DE EMPRESA` , ESTUDIANDO , `FECHA DE ENTRADA` ,`RUTA DE FOTO`, `TIPO MONEDA`, PARENTESCO, EMAIL) values ('" + nameComplete + "', '" + age + "' , '" + grade + "', '" + schedule + "', '" + nacionality + "', '" + actNumber + "','" + provincia + "','" + municipio + "', '" + oficialiaJCE + "','" + book + "','" + folio + "', '" + year + "','" + this.birthdate + "' ,'" + sex + "','" + telephonenumber + "','" + adress + "','" + alergy + "','" + specialmedicine + "','" + medicineReason + "','" + nameSindrome + "','" + tutorName + "','" + tutorId + "','" + tutorNacionality + "','" + mensuality + "','" + job + "','" + jobtelephoneNumber + "','" + studyingNow + "','" + this.dateIn + "','" + ruta + "', '" + moneda+ "', '" + parentesco + "', '" + email + "' )", conection);
            
            

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
                userMessageStudent = mistake.ToString(); 
                conection.Close(); 
            }
            catch (Exception mistake) 
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }

            
            return answer;
        }


        private int cuenta;
        public int getcuenta() {
            return cuenta;
        }
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


            } catch (MySqlException er) {
                
                conection.Close();
                er.ToString();
            }

            
        }

        

        public void ShowDataGridFound(DataGridView findinggrid, string orden)
        {
            try {


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


            } catch (MySqlException er) {
                conection.Close();
                er.ToString();
                cuenta = 0;
                    }
            

           
        }

        public bool ordensql(string orden) {

            command = new MySqlCommand(orden, conection);
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) answer = true;
                else answer = false;
                conection.Close();

            }
            catch (Exception problem) {
                conection.Close();
                problem.ToString();
            }

            return answer; }

        public bool NameNoCopied(string userName, string userDataName)
        {

            command = new MySqlCommand("SELECT * FROM " + userDataName + " where `NOMBRE COMPLETO`='" + userName + "';", conection);


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
                userMessageStudent = problem.ToString();
            }

            return answer;

        }

        public void OrderID(string userDataName) 
        {
            string command1 = "ALTER TABLE "+userDataName+" DROP ID;";
            string command2 = "ALTER TABLE " + userDataName + " ADD ID INT(6) NOT NULL AUTO_INCREMENT FIRST, ADD PRIMARY KEY (ID);";
            command = new MySqlCommand(command1+command2, conection);


            try
            {
                conection.Open();
                read = command.ExecuteReader();
                conection.Close();
            }
            catch (InvalidOperationException mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
            catch (Exception mistake)
            {
                userMessageStudent = mistake.ToString();
                conection.Close();
            }
        }

        public string getback(string columna, string orden)
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
            catch (IndexOutOfRangeException a) {
                a.ToString();
                conection.Close();
            }
            catch (MySqlException d)
            {
                conection.Close();
                d.ToString();
            }
            return data;
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
            catch (MySqlException expsql) {

                expsql.ToString();
            }
            catch (InvalidOperationException apd) {
                apd.ToString();
            }
        }

        public bool getAnswer() { return answer; }
        public string getMensajeUser() { return userMessageStudent; }

        public bool AddAsistanceStudent(string nombre, string periodo, string curso,string estado, string nameUser)
        {
            string complete = nameUser + "_asistance_student_table";


            command = new MySqlCommand("INSERT into " + complete + " (NOMBRE, PERIODO, CURSO, ESTADO) values ('" + nombre + "','" + periodo + "','" + curso + "' ,'" + estado + "' );", conection);


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
            catch (MySqlException mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();

            }

            return createtablestudentanswer;
        }
        public bool editAsistanceStudent(string nombre, string periodo,string estado, string id, string nameUser)
        {
            string complete = nameUser + "_asistance_student_table";
            command = new MySqlCommand("UPDATE " + complete + " NOMBRE='" + nombre + "', PERIODO='" + periodo + "',ESTADO='"+estado+"'  WHERE ID='" + id + "' ;", conection);


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

        private bool createtablestudentanswer;
        private string message;

        public bool editasistancestudent(string mes, string dato,string id, string nameUser)
        {
            string complete = nameUser + "_asistance_student_table";
            string orden = "";

            if (mes == "enero" || mes == "ENERO")
            {

                orden = "UPDATE " + complete + " SET ENERO = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "febrero" || mes == "FEBRERO")
            {
                orden = "UPDATE " + complete + " SET FEBRERO = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "marzo" || mes == "MARZO")
            {
                orden = "UPDATE " + complete + " SET MARZO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "abril" || mes == "ABRIL")
            {
                orden = "UPDATE " + complete + " SET ABRIL = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "mayo" || mes == "MAYO")
            {
                orden = "UPDATE " + complete + " SET MAYO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "junio" || mes == "JUNIO")
            {
                orden = "UPDATE " + complete + " SET JUNIO = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "julio" || mes == "JULIO")
            {
                orden = "UPDATE " + complete + " SET JULIO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "agosto" || mes == "AGOSTO")
            {
                orden = "UPDATE " + complete + " SET AGOSTO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "septiembre" || mes == "SEPTIEMBRE")
            {
                orden = "UPDATE " + complete + " SET SEPTIEMBRE = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "octubre" || mes == "OCTUBRE")
            {
                orden = "UPDATE " + complete + " SET OCTUBRE = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "nomviembre" || mes == "NOVIEMBRE")
            {
                orden = "UPDATE " + complete + " SET NOVIEMBRE = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "diciembre" || mes == "DICIEMBRE")
            {
                orden = "UPDATE " + complete + " SET DICIEMBRE = '" + dato + "' WHERE ID = '" + id + "';";

            }
            command = new MySqlCommand(orden, conection);


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
            catch (MySqlException mistake)
            {
                message = mistake.ToString();
                MessageBox.Show(message);
            }
            catch (Exception mistake)
            {
                message = mistake.ToString();
                
            }
            

            return createtablestudentanswer;
        }
        public bool deleteAsistanceStudent(string id, string nameUser)
        {
            string complete = nameUser + "_asistance_student_table";

            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE ID = '" + id + "';", conection);


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


        public bool AddCalificationStudent(string nombre, string periodo,string curso, string asignatura,string profesor, string estado, string nameUser)
        {
            string complete = nameUser + "_calification_student_table";
            command = new MySqlCommand("INSERT into " + complete + " (NOMBRE, PERIODO, CURSO, ASIGNATURA, PROFESOR, ESTADO) values ('" + nombre + "','" + periodo + "' ,'" + curso + "','" + asignatura + "','" + profesor + "','"+estado+"');", conection);


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
            catch (MySqlException mistake)
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
        public bool editCalificatorStudent(string nombre, string periodo, string curso, string asignatura, string profesor,string estado, string id, string nameUser)
        {
            string complete = nameUser + "_calification_student_table";
            command = new MySqlCommand("UPDATE " + complete + " SET  NOMBRE='" + nombre + "', PERIODO='" + periodo + "', CURSO='" + curso + "', ASIGNATURA='" + asignatura + "', PROFESOR='" + profesor + "',ESTADO='" + estado + "'  WHERE ID='" + id + "';", conection);


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
        public bool editCalificationStudent(string mes, string dato, string id, string nameUser)
        {
            string complete = nameUser + "_calification_student_table";
            string orden = "";
            

            orden = "UPDATE " + complete + " SET " + mes + " = '" + dato + "'  WHERE ID = '" + id + "';";

            if (mes == "enero" || mes == "ENERO")
            {

                orden = "UPDATE " + complete + " SET ENERO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "febrero" || mes == "FEBRERO")
            {

                orden = "UPDATE " + complete + " SET  FEBRERO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "marzo" || mes == "MARZO")
            {
                orden = "UPDATE " + complete + " SET MARZO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "abril" || mes == "ABRIL")
            {
                orden = "UPDATE " + complete + " SET ABRIL = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "mayo" || mes == "MAYO")
            {
                orden = "UPDATE " + complete + " SET MAYO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "junio" || mes == "JUNIO")
            {
                orden = "UPDATE " + complete + " SET JUNIO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "julio" || mes == "JULIO")
            {
                orden = "UPDATE " + complete + " SET JULIO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "agosto" || mes == "AGOSTO")
            {
                orden = "UPDATE " + complete + " SET AGOSTO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "septiembre" || mes == "SEPTIEMBRE")
            {
                orden = "UPDATE " + complete + " SET SEPTIEMBRE = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "octubre" || mes == "OCTUBRE")
            {
                orden = "UPDATE " + complete + " SET OCTUBRE = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "nomviembre" || mes == "NOVIEMBRE")
            {
                orden = "UPDATE " + complete + " SET NOVIEMBRE = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "diciembre" || mes == "DICIEMBRE")
            {
                orden = "UPDATE " + complete + " SET DICIEMBRE = '" + dato+"'  WHERE ID = '" + id + "';";

            }

            command = new MySqlCommand(orden, conection);


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
        /*
         string calf = "";
            if (dato == "A" || dato == "a") { calf = "4"; }
            else if (dato == "B" || dato == "b") { calf = "3"; }
            else if (dato == "C" || dato == "c") { calf = "2"; }
            else if (dato == "D" || dato == "d") { calf = "1"; }
            else if (dato == "F" || dato == "f") { calf = "0"; }
            else { calf = dato; }
         */
        public bool deleteCalificationStudent(string id, string nameUser)
        {
            string complete = nameUser + "_calification_student_table";

            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE ID = '" + id + "';", conection);


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

        public bool evaluatstudent(string mes, string dato, string tipoevalucion, string id, string nameUser)
        {


            string complete = nameUser + "_calification_student_table"; ;
            string orden = "";
            string calf = "";


            if (dato == "A" || dato == "a") { calf = "4"; }
            else if (dato == "B" || dato == "b") { calf = "3"; }
            else if (dato == "C" || dato == "c") { calf = "2"; }
            else if (dato == "D" || dato == "d") { calf = "1"; }
            else if (dato == "F" || dato == "f") { calf = "0"; }
            else { calf = dato; }


            if (tipoevalucion == "FIN DE PERIODO" || tipoevalucion == "fin de periodo")
            {

                orden = "UPDATE " + complete + " `FIN DE PERIODO` = '" + calf + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "COMPLETIVO" || tipoevalucion == "completivo")
            {
                orden = "UPDATE " + complete + " `COMPLETIVO` = '" + calf + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "EXTRA ORDINARIO" || tipoevalucion == "extra ordinario" || tipoevalucion == "EXTRA-ORDINARIO" || tipoevalucion == "extra-ordinario")
            {
                orden = "UPDATE " + complete + " `EXTRA ORDINARIO` = '" + calf + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "ESPECIAL" || tipoevalucion == "especial")
            {
                orden = "UPDATE " + complete + " `ESPECIAL` = '" + calf + "'  WHERE ID = '" + id + "';";

            }

            orden = "UPDATE " + complete + "`" + tipoevalucion + "` = '" + calf + "'  WHERE ID = '" + id + "';";
            command = new MySqlCommand(orden, conection);


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
        public bool editevaluationestudent(string dato, string tipoevalucion, string id, string nameUser)
        {


            string complete = nameUser + "_calification_student_table"; ;
            string orden = "";
            


            if (tipoevalucion == "FIN DE PERIODO" || tipoevalucion == "fin de periodo")
            {

                orden = "UPDATE " + complete + " `FIN DE PERIODO` = '" + dato + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "COMPLETIVO" || tipoevalucion == "completivo")
            {
                orden = "UPDATE " + complete + " `COMPLETIVO` = '" + dato + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "EXTRA ORDINARIO" || tipoevalucion == "extra ordinario" || tipoevalucion == "EXTRA-ORDINARIO" || tipoevalucion == "extra-ordinario")
            {
                orden = "UPDATE " + complete + " `EXTRA ORDINARIO` = '" + dato + "'  WHERE ID = '" + id + "';";


            }
            else if (tipoevalucion == "ESPECIAL" || tipoevalucion == "especial")
            {
                orden = "UPDATE " + complete + " `ESPECIAL` = '" + dato + "'  WHERE ID = '" + id + "';";

            }

            orden = "UPDATE " + complete + "`"+tipoevalucion+"` = '" + dato + "'  WHERE ID = '" + id + "';";
            command = new MySqlCommand(orden, conection);


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
        public bool setestadoevaluationstudent(string dato, string id, string nameUser)
        {

            string complete = nameUser + "_calification_student_table"; 
            string orden = "";
            string calf = "";


            if (dato == "A" || dato == "a") { calf = "4"; }
            else if (dato == "B" || dato == "b") { calf = "3"; }
            else if (dato == "C" || dato == "c") { calf = "2"; }
            else if (dato == "D" || dato == "d") { calf = "1"; }
            else if (dato == "F" || dato == "f") { calf = "0"; }
            else { calf = dato; }


            orden = "UPDATE " + complete + " ESTADO = '" + calf + "'  WHERE ID = '" + id + "' ;";

            command = new MySqlCommand(orden, conection);


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

       

        //Getters

        public static int getId() { return id; }
        public string getschedule() { return schedule; }
        public string getprovincia() { return provincia; }
        public string getmunicipio() { return municipio; }
        public string getoficialiaJCE() { return oficialiaJCE; }
        public string getbook() { return book; }
        public string getfolio() { return folio; }
        public int getyear() { return year; }
        public string getbirthdate() { return birthdate; }
        public string getsex() { return sex; }
        public string getnameComplete() { return nameComplete; }
        public int getage() { return age; }
        public string gettelephoneNumber() { return telephoneNumber; }
        public string getdirection() { return direction; }
        public string gettutorName() { return tutorName; }
        public string gettutorId() { return tutorId; }
        public string getnacionality() { return nacionality; }
        public string gettutordirection() { return tutordirection; }
        public string gettelephoneTutorNumber() { return telephoneTutorNumber; }
        public string getjob() { return job; }
        public string getjobtelephoneNumber() { return jobtelephoneNumber; }
        public string getalergy() { return alergy; }
        public string getactNumber() { return actNumber; }
        public string getspecialmedicine() { return specialmedicine; }
        public string getmedicineReason() { return medicineReason; }
        public string getemergencyNumber() { return emergencyNumber; }
        public string getnameSindrome() { return nameSindrome; }
        public double getmensuality() { return mensuality; }
        public string getpictureroute() { return pictureroute; }
        public string getuserMessageStudent() { return userMessageStudent; }
        

    }
}
