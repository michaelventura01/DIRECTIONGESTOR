using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using DireccionLib;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace DireccionLib
{
    public class EmployeeClass
    {
        private int id;
        private string employeeName;
        private string employeeId;
        private string employeeAge;
        private string employeeBirthDate;
        private string employeeTelephoneNumber;
        private string employeeAlergy;
        private string employeeFrecuentPain;
        private string employeeMedicine;
        private string employeeMedicineReason;
        private string dategetin;
        private string dategetout;
        private string titledegree;
        private string birthdate;
        private string telephonenumber;
        private string schedule;
        private string jobtitle;
        private int age;
        private string referencename;
        private string referencenumber;
        private string referencerelation;
        private string alergy;
        private string dolencia;
        private string medicine;
        private string medicinepurpose;
        private double mensuality;
        private string workingnow;
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
        private static string nombrestatic="";
        public static string getnombrestatic() { return nombrestatic; }
 
        public bool answer;
        private string userMessage;
        public EmployeeClass(string dbserver, string db, string dbuser, string dbpass, string dbport)
        {

            server = dbserver;
            database = db;
            userdatabase = dbuser;
            password = dbpass;
            port = dbport;

        }
        public EmployeeClass(string employeeName,string employeeId,string employeeAge,string employeeBirthDate,string employeeTelephoneNumber,string employeeAlergy,string employeeFrecuentPain,string employeeMedicine,string employeeMedicineReason,string dategetin,string dategetout,string titledegree,string birthdate,string telephonenumber,string schedule,string jobtitle,int age,string referencename,string referencenumber,string referencerelation,string alergy,string dolencia,string medicine,string medicinepurpose,double mensuality,string pictureroute) 
        {
            this.employeeName = employeeName;
            this.employeeId=employeeId;
            this.employeeAge=employeeAge;
            this.employeeBirthDate=employeeBirthDate;
            this.employeeTelephoneNumber=employeeTelephoneNumber;
            this.employeeAlergy=employeeAlergy;
            this.employeeFrecuentPain=employeeFrecuentPain;
            this.employeeMedicine=employeeMedicine;
            this.employeeMedicineReason=employeeMedicineReason;
            this.dategetin=dategetin;
            this.dategetout=dategetout;
            this.titledegree=titledegree;
            this.birthdate=birthdate;
            this.telephonenumber = telephonenumber;
            this.schedule=schedule;
            this.jobtitle=jobtitle;
            this.age=age;
            this.referencename=referencename;
            this.referencenumber=referencenumber;
            this.referencerelation=referencerelation;
            this.alergy=alergy;
            this.dolencia=dolencia;
            this.medicine=medicine;
            this.medicinepurpose=medicinepurpose;
            this.mensuality=mensuality;
            this.pictureroute=pictureroute;
        }
        public EmployeeClass() 
        {

        }
 
        public void FilledadBox(ComboBox combo, string datauser)
        {
            command = new MySqlCommand("select distinct EDAD from " + datauser + ";", conection);


            try
            {

                conection.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    employeeName = read.GetString("EDAD");
                    combo.Items.Add(employeeName);
                }
                conection.Close();
            }
            catch (Exception problem)
            {
                conection.Close();
                userMessage = problem.ToString();
            }
        }

        public void FillcargoBox(ComboBox combo, string datauser)
        {
            command = new MySqlCommand("select distinct PUESTO from " + datauser + ";", conection);


            try
            {

                conection.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    employeeName = read.GetString("PUESTO");
                    combo.Items.Add(employeeName);
                }
                conection.Close();
            }
            catch (Exception problem)
            {
                conection.Close();
                userMessage = problem.ToString();
            }
        }


        public void FillNameBox(ComboBox combo, string orden)
        {
            combo.Items.Clear();
            try {
                conection.Open();
                command = new MySqlCommand(orden, conection);
                read = command.ExecuteReader();
                while (read.Read()) {
                    combo.Refresh();
                    combo.Items.Add(read.GetValue(0).ToString());
                }

                conection.Close();
            }
            catch (MySqlException expsql) { }
        }

        public void FillAnothers(ComboBox degree, ComboBox charge, ComboBox alergy, ComboBox dolency, ComboBox medicine, ComboBox purpuse, string datauser) 
        {
            string command = "SELECT distinct * FROM "+datauser+";";
            
            
            this.command = new MySqlCommand(command, conection);
            

            try
            {

                conection.Open();
                read = this.command.ExecuteReader();
                while (read.Read())
                {
                    titledegree = read.GetString("`TITULO UNIVERSITARIO`");
                    degree.Items.Add(titledegree);

                    jobtitle = read.GetString("PUESTO");
                    charge.Items.Add(jobtitle);

                    employeeAlergy = read.GetString("`NOMBRE DE ALERGIA`");
                    alergy.Items.Add(employeeAlergy);

                    employeeFrecuentPain = read.GetString("`NOMBRE DE DOLENCIA`");
                    dolency.Items.Add(employeeFrecuentPain);

                    employeeMedicine=read.GetString("`NOMBRE DE MEDICINA`");
                    medicine.Items.Add(employeeMedicine);

                    employeeMedicineReason = read.GetString("`RAZON DE MEDICINA`");
                    purpuse.Items.Add(employeeMedicineReason);



                }
                conection.Close();
            }
            catch (Exception problem)
            {
                conection.Close();
                userMessage = problem.ToString();
            }
        }
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
                userMessage = problem.ToString();
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


                string sqlsentence = "SELECT `NOMBRE COMPLETO`, `CEDULA`, `FECHA DE NACIMIENTO` , `SEXO`, `TITULO UNIVERSITARIO`, PUESTO, EDAD, HORARIO, TELEFONO, DIRECCION FROM " + datauser + " WHERE TRABAJANDO = 'SI';";
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
                cuenta = 0;
                er.ToString(); }
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
            catch (MySqlException d)
            {
                conection.Close();
                d.ToString();
            }
            catch (InvalidOperationException d) {
                conection.Close();
                d.ToString();
            }
            return data;
        }

        public bool ModifyData(string userDataName, string nombre, string salida, string trabajando, string id)
        {




            command = new MySqlCommand("UPDATE " + userDataName + " SET `TRABAJANDO` = '" + trabajando + "' ,  `FECHA DE SALIDA`='" + salida + "' where  `NOMBRE COMPLETO` = '" + nombre + "' AND ID='"+id+"';", conection);
            //MessageBox.Show("UPDATE " + userDataName + " SET `TRABAJANDO` = '" + inscrito + "' ,  `DEUDA PENDIENTE`=  '" + deuda + "' , `FECHA DE SALIDA`='" + salida + "' where  `NOMBRE COMPLETO` = '" + nombre + "';");
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
                
                conection.Close();
            }
            catch (Exception mistake)
            {
                //userMessageStudent = mistake.ToString();
                conection.Close();
            }



            return answer;
        }


       
        public bool ModifyData(string nombre, string trabajando,string userDataName, DateTimePicker timegetin,  DateTimePicker timegetout, string degree, string employeename, 
            string employeeID, DateTimePicker birtdatE, string telephone, string schedule, string job, string nacionality, int age, double payment, string personalreference, 
            string telefonereference, string referecia, string alergy, string dolency, string medicinename, string medicinereason, string pictureroute, string tipomoneda, 
            string sexo, string direccion, string email,string id)
        {

            
            this.birthdate = birtdatE.Value.Day.ToString() + "/" + birtdatE.Value.Month.ToString() + "/" + birtdatE.Value.Year.ToString();
            this.dategetin = timegetin.Value.Day.ToString() + "/" + timegetin.Value.Month.ToString() + "/" + timegetin.Value.Year.ToString();
            if (trabajando == "SI" || trabajando == "si")
            {
                this.dategetout = "00/00/0000";

            }
            else if (trabajando == "NO" || trabajando == "no")
            {
                this.dategetout = timegetout.Value.Day.ToString() + "/" + timegetout.Value.Month.ToString() + "/" + timegetout.Value.Year.ToString();
            }

            command = new MySqlCommand("UPDATE " + userDataName + " SET `NOMBRE COMPLETO` = '" + employeename + "', `CEDULA` = '" + employeeID + "', `TELEFONO` = '" + telephone 
                                                                + "', `NOMBRE DE DOLENCIA` = '" + dolency + "', EDAD=  '" + age + "', PUESTO='" + job 
                                                                + "', `TITULO UNIVERSITARIO`='" + degree + "', HORARIO='" + schedule + "', NACIONALIDAD =  '" + nacionality 
                                                                + "', `FECHA DE NACIMIENTO`='" + this.birthdate + "', SEXO='" + sexo + "', `RAZON DE MEDICINA` = '" + medicinereason + "', `REFERENCIA PERSONAL`= '" + personalreference 
                                                                + "', `TELEFONO DE REFERENCIA`= '" + telefonereference + "', `RELACION DE REFERENCIA`='" + referecia 
                                                                + "', SUELDO= '" + payment + "' , TRABAJANDO= '" + trabajando + "', `FECHA DE ENTRADA`='" + this.dategetin 
                                                                + "', `RUTA DE FOTO` ='" + pictureroute + "', `FECHA DE SALIDA`='" + this.dategetout + "', `TIPO MONEDA`='" + tipomoneda 
                                                                + "', DIRECCION='" + direccion + "', EMAIL='" + email + "' where  `NOMBRE COMPLETO` = '" + nombre + "' AND ID='"+id+"';", conection);
           
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
                MessageBox.Show(mistake.ToString());
                conection.Close();
            }
            catch (Exception mistake)
            {
                MessageBox.Show(mistake.ToString());

                conection.Close();
            }


            return answer;


        }



        public bool SaveData(string userDataName, DateTimePicker timegetin, string degree,string employeename, string employeeID, DateTimePicker birtdatE, string telephone, 
            string schedule, string job, string nacionality, int age, double payment, string personalreference, string telefonereference, string referecia, string alergy, 
            string dolency, string medicinename, string medicinereason, string pictureroute, string tipomoneda, string sexo, string direccion, string email)
        {
            this.telephonenumber = telephone;
            workingnow = "SI";
            dategetin = timegetin.Value.Day.ToString()+"/" + timegetin.Value.Month.ToString() + "/" + timegetin.Value.Year.ToString();
            birthdate = birtdatE.Value.Day.ToString() + "/" + birtdatE.Value.Month.ToString() + "/" + birtdatE.Value.Year.ToString();
           
            command = new MySqlCommand("INSERT into " + userDataName + " (`NOMBRE COMPLETO`,  CEDULA, `FECHA DE NACIMIENTO`, `TITULO UNIVERSITARIO`, PUESTO, TELEFONO, HORARIO , EDAD, `REFERENCIA PERSONAL`, `TELEFONO DE REFERENCIA` , `RELACION DE REFERENCIA`, `NOMBRE DE ALERGIA`, `NOMBRE DE DOLENCIA`, `NOMBRE DE MEDICINA`, `RAZON DE MEDICINA`, `TRABAJANDO`, `RUTA DE FOTO`, `FECHA DE ENTRADA`, SUELDO ,NACIONALIDAD, SEXO, DIRECCION, `TIPO MONEDA`, EMAIL) values ('" + 
                                                        employeename + "', '" + employeeID + "' , '" + birthdate + "', '" + degree + "', '" + job + "','" + this.telephonenumber + "','" + schedule + "', '" 
                                                        + age + "','" + personalreference + "','" + telefonereference + "', '" + referecia + "','" + alergy + "' ,'" + dolency + "','" 
                                                        + medicinename + "','" + medicinereason + "','" + workingnow + "','" + pictureroute + "','" + dategetin + "' ,'" + payment + "','" 
                                                        + nacionality + "','" + sexo + "','" + direccion + "','" + tipomoneda + "','"+email+"')", conection);

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
                MessageBox.Show(userMessage = mistake.ToString());
                
                conection.Close();
            }
            catch (Exception mistake)
            {
                MessageBox.Show(userMessage = mistake.ToString());
                conection.Close();
            }


            return answer;
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


            } catch (MySqlException par) {
                conection.Close();
                cuenta = 0;
                par.ToString(); }

           
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
                conection.Close();
                expsql.ToString();
            }
            catch (InvalidOperationException d) {
                conection.Close();
                d.ToString();
            }
        }

        
        public bool filleverylabel(Label name,Label fechaentrada, Label titulo,  Label cedula, Label fechanacimiento, Label telefono, Label tanda,
                    Label cargo, Label nacionalidad, Label edad, Label tipomoneda, Label pago, Label nombrereferencia, Label telefonoreferencia, Label relacion,
                    Label nombrealergia, Label nombredolencia, Label nombremedicamento, Label razonmedicamento, Label trabajando, Label fechasalida, Label sexo, 
                    Label direccion, TextBox foto,Label email, string orden)
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
                tipomoneda.Text = read["TIPO MONEDA"].ToString();
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

        private static string namestatic = "";
        private static int edadstatic = 0;
        private static string puestostatic = "";
        public static string getstaticname() { return namestatic; }
        public static int getstaticedad() { return edadstatic; }
        public static string getstaticpuesto() { return puestostatic; }
        private DateTime datenow;

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

        private static string ids;
        public static string getids() { return ids; }

        public bool fillboxes(ComboBox name, DateTimePicker nacimiento, ComboBox edad, ComboBox puesto, ComboBox trabajando, DateTimePicker getindateTimePicker, DateTimePicker getoutdateTimePicker, ComboBox working,Panel trabajandopanel, string orden)
        {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                ids = read["ID"].ToString();
                nacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                edad.Text = read["EDAD"].ToString();
                puesto.Text = read["PUESTO"].ToString();
                trabajando.Text = read["TRABAJANDO"].ToString();
                getindateTimePicker.Text = read["FECHA DE ENTRADA"].ToString();

                string fechasalida=read["FECHA DE SALIDA"].ToString();
                if (fechasalida == "00/00/0000" || fechasalida == "")
                {

                    working.Text = "SI";
                    trabajandopanel.Hide();
                }
                else {
                    working.Text = "NO";

                    getoutdateTimePicker.Text = fechasalida;
                    
                    trabajandopanel.Show();

                }

                namestatic = name.Text;
                answer = true;
            }
            else
            {
                datenow = DateTime.Now;

                nacimiento.Text = datenow.ToString();
                edad.Text = "";
                puesto.Text = "";
                trabajando.Text = "";
                MessageBox.Show("Asegurese de selecionar el campo [NOMBRE COMPLETO] en la tabla");
                name.Text = "";
                answer = false;
            }

            conection.Close();

            return answer;
        }



        public bool fillcombos(ComboBox name, ComboBox edad, ComboBox cargo, string orden)
        {

            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {

                name.Text = read["NOMBRE COMPLETO"].ToString();
                edad.Text = read["EDAD"].ToString();
                cargo.Text = read["PUESTO"].ToString();
                namestatic = name.Text;
                edadstatic = int.Parse(edadstatic.ToString());
                nombrestatic = name.Text;
                answer = true;
                
            }
            else
            {
                name.Text = "";
                edad.Text = "";
                cargo.Text = "";
                namestatic = "";
                edadstatic = 0;
                namestatic = "";
                answer = false;

            }


            return answer;
        }


        public bool filleverything(DateTimePicker fechaentrada, ComboBox titulo, ComboBox nombre, TextBox cedula, DateTimePicker fechanacimiento, TextBox telefono, ComboBox tanda,
                    ComboBox cargo, ComboBox nacionalidad, TextBox edad, ComboBox tipomoneda, TextBox pago, TextBox nombrereferencia, TextBox telefonoreferencia, ComboBox relacion,
                    ComboBox nombrealergia, ComboBox nombredolencia, ComboBox nombremedicamento, ComboBox razonmedicamento, ComboBox trabajando, DateTimePicker fechasalida ,TextBox foto,
                    ComboBox direccion, ComboBox sexo,ComboBox email, string orden)
        {


            command = new MySqlCommand(orden, conection);
            conection.Open();
            read = command.ExecuteReader();
            if (read.Read() == true)
            {
                
                tanda.Text = read["HORARIO"].ToString();
                fechaentrada.Text = read["FECHA DE ENTRADA"].ToString();
                titulo.Text = read["TITULO UNIVERSITARIO"].ToString();
                nombre.Text = read["NOMBRE COMPLETO"].ToString();
                cedula.Text = read["CEDULA"].ToString();
                fechanacimiento.Text = read["FECHA DE NACIMIENTO"].ToString();
                telefono.Text = read["TELEFONO"].ToString();
                
                cargo.Text = read["PUESTO"].ToString();
                nacionalidad.Text = read["NACIONALIDAD"].ToString();
                edad.Text = read["EDAD"].ToString();
                tipomoneda.Text = read["TIPO MONEDA"].ToString();
                pago.Text = read["SUELDO"].ToString();
                nombrereferencia.Text = read["REFERENCIA PERSONAL"].ToString();
                telefonoreferencia.Text = read["TELEFONO DE REFERENCIA"].ToString();
                relacion.Text = read["RELACION DE REFERENCIA"].ToString();
                nombrealergia.Text = read["NOMBRE DE ALERGIA"].ToString();
                nombredolencia.Text = read["NOMBRE DE DOLENCIA"].ToString();
                nombremedicamento.Text = read["NOMBRE DE MEDICINA"].ToString();
                razonmedicamento.Text = read["RAZON DE MEDICINA"].ToString();
                trabajando.Text = read["TRABAJANDO"].ToString();

                string salidafecha= read["FECHA DE SALIDA"].ToString();
                if (salidafecha == "00/00/0000" || salidafecha == "")
                {
                    fechasalida.Enabled = false;
                }
                else {
                    fechasalida.Text = salidafecha;
                }
                direccion.Text = read["DIRECCION"].ToString();
                foto.Text = read["RUTA DE FOTO"].ToString();
                sexo.Text = read["SEXO"].ToString();
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

        private bool createtablestudentanswer;
        private string message;

        public bool AddAsistanceEmployee(string nombre, string periodo,string estado, string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";
            command = new MySqlCommand("INSERT into " + complete + " (NOMBRE, PERIODO,ESTADO) values ('" + nombre + "','" + periodo + "','"+estado+"' );", conection);
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (MySqlException es)
            {
                message = es.ToString();
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
        public bool editAsistanceEmployee(string nombre, string periodo, string id, string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";
            // command = new MySqlCommand("create table if not exists" + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null,  primary key(ID) );" , conection);

            command = new MySqlCommand("UPDATE " + complete + " SET NOMBRE='" + nombre + "', PERIODO='" + periodo + "'  WHERE ID = '" + id + "';", conection);


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
        public bool editasistanceemployee(string mes, string dato, string id, string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";
            string orden = "";

            if (mes == "enero" || mes == "ENERO")
            {

                orden = "UPDATE " + complete + " SET ENERO = '" + dato + "'  WHERE ID = '" + id + "';";

            }
            else if (mes == "febrero" || mes == "FEBRERO")
            {
                orden = "UPDATE " + complete + " SET FEBRERO = '" + dato + "'  WHERE ID = '" + id + "';";

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
                orden = "UPDATE " + complete + " SET DICIEMBRE = '" + dato + "'  WHERE ID = '" + id + "';";

            }



            // command = new MySqlCommand("create table if not exists" + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null,  primary key(ID) );" , conection);

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

            }

            return createtablestudentanswer;
        }
        public bool deleteAsistanceEmployee(string id, string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";

            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE WHERE ID = '" + id + "';", conection);


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

        public bool AddCalificationEmployee(string nombre, string periodo, string nameUser)
        {
            string complete = nameUser + "_calification_employee_table";
            command = new MySqlCommand("INSERT into " + complete + " (NOMBRE, PERIODO) values ('" + nombre + "','" + periodo + "');", conection);
            try
            {
                conection.Open();
                read = command.ExecuteReader();
                if (read.Read()) createtablestudentanswer = true;
                else createtablestudentanswer = false;


                conection.Close();

            }
            catch (MySqlException es) {
                message = es.ToString();
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
        public bool editCalificationEmployee(string nombre, string periodo,string estado, string id, string nameUser)
        {
            string complete = nameUser + "_calification_employee_table";
            // command = new MySqlCommand("create table if not exists" + complete + "(ID int(10) not null auto_increment, `NOMBRE` varchar(60) not null, ENERO varchar(3), FEBRERO varchar(3), MARZO varchar(3), ABRIL varchar(3),MAYO varchar(3), JUNIO varchar(3),JULIO varchar(3),AGOSTO varchar(3),SEPTIEMBRE varchar(3),OCTUBRE varchar(3), NOVIEMBRE varchar(3),DICIEMBRE varchar(3),PERIODO varchar(30) not null,  primary key(ID) );" , conection);

            command = new MySqlCommand("UPDATE " + complete + " SET NOMBRE='" + nombre + "', PERIODO='" + periodo + "',ESTADO='"+estado+ "'  WHERE ID = '" + id + "';", conection);


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




        public bool editcalificationemployee(string mes, string dato, string id, string nameUser)
        {
            string complete = nameUser + "_calification_employee_table";
            string orden = "";
            


            if (mes == "enero" || mes == "ENERO")
            {

                orden = "UPDATE " + complete + " SET ENERO = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "febrero" || mes == "FEBRERO")
            {
                orden = "UPDATE " + complete + " SET FEBRERO = '" + dato + "'  WHERE ID = '" + id + "';";

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
                orden = "UPDATE " + complete + " SET JULIO = '" + dato + "' WHERE ID = '" + id + "';";

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
                orden = "UPDATE " + complete + " SET NOVIEMBRE = '" + dato + "' WHERE ID = '" + id + "';";

            }
            else if (mes == "diciembre" || mes == "DICIEMBRE")
            {
                orden = "UPDATE " + complete + " SET DICIEMBRE = '" + dato + "'  WHERE ID = '" + id + "';";

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

            }

            return createtablestudentanswer;
        }
        public bool deleteCalificationEmployee(string id, string nameUser)
        {
            string complete = nameUser + "_asistance_employee_table";

            command = new MySqlCommand("DELETE FROM " + complete + "'  WHERE WHERE WHERE ID = '" + id + "';", conection);


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

    }
}
