using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionLib;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DireccionLib
{
    public class FuncionClass
    {
        private string[] data;
        private bool answer;
        public FuncionClass() { }

        private static string server;
        private static string database;
        private static string userdatabase;
        private static string password;
        private static string port;
        MySqlConnection conection;

         


        MySqlCommand command;
        MySqlDataReader read;
        MySqlDataAdapter dataadapter;



        public FuncionClass(string dbserver, string db, string dbuser, string dbpass, string dbport) {

                    server = dbserver;
                    database = db;
                    userdatabase = dbuser;
                    password = dbpass;
                    port = dbport;

    }


        public bool ordensql(string orden)
        {
            try
            {
                conection = new MySqlConnection("Persist Security Info=False; server= " + server + "; database=" + database + "; uid=" + userdatabase + "; password=" + password + "; Port=" + port + ";");
            }
            catch (ArgumentException poa)
            {

                MessageBox.Show("CONEXION CON BASE DE DATOS ESTABLECIDA");

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
            catch (ArgumentException poa) {

                MessageBox.Show("CONEXION CON BASE DE DATOS NO PUDO SER ESTABLECIDA");
                conection.Close();
            }

            catch (Exception problem)
            {
                MessageBox.Show("CONEXION CON BASE DE DATOS NO PUDO SER ESTABLECIDA");
                conection.Close();
            }
            

            return answer;
        }

        public bool saveperfil(string server, string name, string user, string pass, string port, string ruta) {




            string path= System.IO.Path.Combine(ruta,"dataperfil");
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            try
           {

               
               writer.Write(server+"#");
               writer.Write(name + "#");
               writer.Write(user + "#");
               writer.Write(pass + "#");
               writer.Write(port);
               writer.Close();


                MessageBox.Show("SE HA GUARDADO EL PERFIL");
            }
           catch (Exception ex)
           {
                writer.Close();
                ex.ToString();
                MessageBox.Show("HA OCURRIDO ALGO DURANTE LA CREACION DEL PERFIL, INTENTELO DE NUEVO");
           }
            return answer;
        }


        public string[] readperfil(string ruta)
        {

            string path = System.IO.Path.Combine(ruta, "dataperfil");




            try
            {
                if (File.Exists(path))
                {

                    StreamReader theReader = new StreamReader(path);

                    data = theReader.ReadToEnd().Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

                    theReader.Close();

                    server = data[0];
                    database = data[1];
                    userdatabase = data[2];
                    password = data[3];
                    port = data[4];


                }
                else
                {

                    server = "localhost";
                    data[0] = server;

                    database = "users";
                    data[1] = database;
                    userdatabase = "root";
                    data[2] = userdatabase;
                    password = "1234";
                    data[3] = password;
                    port = "3306";
                    data[4] = port;
                }
            }
            catch (NullReferenceException ar) {

                try { 
                server = "localhost";
                data[0] = server;

                database = "users";
                data[1] = database;
                userdatabase = "root";
                data[2] = userdatabase;
                password = "1234";
                data[3] = password;
                port = "3306";
                data[4] = port;
                }
                catch (NullReferenceException aar) {

                    aar.ToString();
                }
            }
            


            return data;
        }

    }
}
