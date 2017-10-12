using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace DireccionLib
{

    
    public partial class agendaAdd : Form
    {
        private string fecha;
        private string[] dias = new string[7];
        public agendaAdd()
        {
            InitializeComponent();
        }

        
        
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "buscador" || DireccionGestor.getorigen() == "modificar")
            {
                AgendaEvents agendaobject = new AgendaEvents();
                agendaobject.WindowState = FormWindowState.Normal;
                agendaobject.Show();
                

            } else if (DireccionGestor.getorigen() == "editor") {


                AgendaEvents agendaobject = new AgendaEvents();
                agendaobject.WindowState = FormWindowState.Normal;
                agendaobject.Show();
                


            }
            else {

                AgendaClass save = new AgendaClass();
                

            }

            this.Close();

        }

        //private string prioridad="";
        string shortdate;
        string hora;
        string lunes;
        string martes;
        string miercoles;
        string jueves;
        string viernes;
        string sabado;
        string domingo;
        private void agendaAdd_Load(object sender, EventArgs e)
        {
            //SystemSounds.Hand.Play();
            playmusic.Hide();
            stopmusic.Hide();

            activobox.Hide();
            labelactivo.Hide();
            AgendaClass add = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string orden= "SELECT distinct `SONIDO` FROM " + UserAccessForm.getusername() + "_events_table;";
            add.Fillcombo(melodybox,orden);
            
            if (DireccionGestor.getorigen() == "modificar") {


                activobox.Show();
                labelactivo.Show();
                titlelabel.Text = "EDITAR TAREAS";
                motivoBox.Text = DireccionGestor.getnombrestatic();
                fecha= DireccionGestor.getotrostatic();

                if (fecha != "00/00/0000")
                {
                    datebox.Text = fecha;

                }
                else {

                    datebox.Enabled = false;
                }

                
                AgendaClass mod = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                orden = "SELECT * FROM "+UserAccessForm.getusername()+ "_events_table WHERE DESCRIPCION= '"+DireccionGestor.getnombrestatic()+"' and FECHA = '"+DireccionGestor.getotrostatic()+"';";
                mod.filleverything(activobox, priority,shortdate,hora, lunescheck, martescheckBox, miercolescheckBox, juevescheckBox, viernescheckbox, sabadocheckBox, domingocheckBox, comborepeticion,melodybox, orden);
                
                if (hora != "00:00:00") {
                    timeBox.Text = hora;
                } else {
                    timeBox.Enabled = false;
                }

                //MessageBox.Show("LUNES "+lunes+", MARTES "+martes+", MIERCOLES "+miercoles+", JUEVES "+jueves+", VIERNES "+viernes+", SABADO "+sabado+", DOMINGO "+domingo)



                if (lunescheck.Checked == false && martescheckBox.Checked == false && miercolescheckBox.Checked == false && juevescheckBox.Checked == false && viernescheckbox.Checked == false && sabadocheckBox.Checked == false &&  domingocheckBox.Checked == false)
                {
                    //comborepeticion.Text = "NO";
                    paneldias.Hide();
                    datebox.Enabled = true;
                }
                else if (lunescheck.Checked == false && martescheckBox.Checked == false && miercolescheckBox.Checked == false && juevescheckBox.Checked == false && viernescheckbox.Checked == false && sabadocheckBox.Checked == false  && domingocheckBox.Checked == false)
                {
                    //comborepeticion.Text = "ELEGIR";
                    paneldias.Show();
                    
                    datebox.Enabled = false;
                    fecha = "00/00/0000";
                }
                else if ( lunescheck.Checked == true && martescheckBox.Checked == true &&  miercolescheckBox.Checked == true && juevescheckBox.Checked == true && viernescheckbox.Checked == true && sabadocheckBox.Checked == false && domingocheckBox.Checked == false)
                {
                    //comborepeticion.Text = "DIARIO";
                    paneldias.Show();
                    
                    datebox.Enabled = false;
                    fecha = "00/00/0000";
                }
                else if (lunescheck.Checked == true &&  martescheckBox.Checked == true && miercolescheckBox.Checked == true && juevescheckBox.Checked == true &&  viernescheckbox.Checked == true && sabadocheckBox.Checked == true && domingocheckBox.Checked == true )
                {

                    //comborepeticion.Text = "TODOS LOS DIAS";
                    paneldias.Show();
                    fecha = "00/00/0000";
                    datebox.Enabled = false;
                }



            }
            else
            {
                priority.Text = "NORMAL";
                comborepeticion.Text = "NO";

            }


            OKbutton.BackColor = Color.Green;
            cancelbutton.BackColor = Color.Red;
            tareasverbutton.BackColor = Color.Blue;
            
        }

        private void tareasverbutton_Click(object sender, EventArgs e)
        {
            DireccionGestor.setorigen("agregador");
            AgendaEvents agendaobject = new AgendaEvents();
            agendaobject.WindowState = FormWindowState.Normal;
            agendaobject.Show();
            this.Close();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {


            string fecharecordatorio = "00/00";
            fecha = datebox.Value.Day.ToString() + "/" + datebox.Value.Month.ToString() + "/" + datebox.Value.Year.ToString();
            string hora = timeBox.Value.Hour.ToString() + ":" + timeBox.Value.Minute.ToString() + ":" + timeBox.Value.Second.ToString();

            AgendaClass agenda = new AgendaClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
            string user = UserAccessForm.getusername();
            if (lunescheck.Checked == true) { dias[0] = "SI"; } else { dias[0] = "NO"; }
            if (martescheckBox.Checked == true) { dias[1] = "SI"; } else { dias[1] = "NO"; }
            if (miercolescheckBox.Checked == true) { dias[2] = "SI"; } else { dias[2] = "NO"; }
            if (juevescheckBox.Checked == true) { dias[3] = "SI"; } else { dias[3] = "NO"; }
            if (viernescheckbox.Checked == true) { dias[4] = "SI"; } else { dias[4] = "NO"; }
            if (sabadocheckBox.Checked == true) { dias[5] = "SI"; } else { dias[5] = "NO"; }
            if (domingocheckBox.Checked == true) { dias[6] = "SI"; } else { dias[6] = "NO"; }



            int prioridad = 1;

            if (priority.Text == "MUY IMPORTANTE") { prioridad = 0; }
            else if (priority.Text == "NORMAL") { prioridad = 1; }
            else { prioridad = 2; }





            if (comborepeticion.Text == "NO")
            {
                fecharecordatorio = datebox.Value.Day.ToString() + "/" + datebox.Value.Month.ToString();
            }
            else { fecharecordatorio = "00/00"; }
            
            // 0 - MUY IMPORTANTE
            // 1 - NORMAL
            // 2 - POCO IMPORTANTE

            if (DireccionGestor.getorigen() == "inicio" || DireccionGestor.getorigen() == "buscador") {
                string activo = "SI";
                
                if (motivoBox.Text == "" || priority.Text == "")
                {
                    MessageBox.Show("COMPLETE EL FORMULARIO");
                    if (motivoBox.Text == "") { motivoBox.BackColor = Color.Red; }
                    else { motivoBox.BackColor = Color.Green; }

                    if (priority.Text == "") { priority.BackColor = Color.Red; }
                    else { motivoBox.BackColor = Color.Green; }

                }
                else
                {
                    if (agenda.saveData(user, motivoBox.Text, prioridad, fecha, hora, dias[0], dias[1], dias[2], dias[3], dias[4], dias[5], dias[6], fecharecordatorio, activo, melodybox.Text))
                    {
                        MessageBox.Show("TAREA GUARDADA");
                        if (MessageBox.Show("Agregar otra tarea?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            agenda = new AgendaClass();
                            this.Close();

                        }
                        else
                        {
                            agenda = new AgendaClass();
                            this.Close();
                            agendaAdd menu = new agendaAdd();

                        }


                    }
                    else {
                        MessageBox.Show("TAREA GUARDADA" + " " + agenda.getmessageshow());
                        if (MessageBox.Show("Agregar otra tarea?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            agenda = new AgendaClass();
                            this.Close();

                        }
                        else
                        {
                            agenda = new AgendaClass();
                            this.Close();
                            agendaAdd menu = new agendaAdd();
                            menu.WindowState = FormWindowState.Normal;
                            menu.Show();
                        }
                    }
                }

            } else if (DireccionGestor.getorigen()== "modificar") {
                
                agenda.ordensql("UPDATE " + UserAccessForm.getusername() + "_events_table SET `DESCRIPCION`= '" + motivoBox.Text + "',  `FECHA` ='" + fecha + "',  `HORA` ='" + hora + "',  `PRIORIDAD` = '" + prioridad + "',  `LUNES`='" + dias[0] + "',  `MARTES` ='" + dias[1] + "', `MIERCOLES` ='" + dias[2] + "',  `JUEVES` ='" + dias[3] + "',  `VIERNES` ='" + dias[4] + "',  `SABADO` ='" + dias[5] + "',  `DOMINGO` ='" + dias[6] + "', `FECHA DE RECORDATORIO` ='" + fecharecordatorio + "', `ACTIVO` ='" + activobox.Text + "',`SONIDO`='"+ melodybox.Text + "' WHERE  `DESCRIPCION`= '" + DireccionGestor.getnombrestatic() + "' AND FECHA ='"+ DireccionGestor.getotrostatic() + "';");
                MessageBox.Show("TAREA MODIFICADA");

                AgendaEvents agendaobject = new AgendaEvents();
                agendaobject.WindowState = FormWindowState.Normal;
                agendaobject.Show();
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comborepeticion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "modificar")
            {

                if (comborepeticion.Text == "NO")
                {
                    paneldias.Hide();
                    datebox.Enabled = true;
                }
                else if (comborepeticion.Text == "ELEGIR")
                {
                    paneldias.Show();
                    datebox.Enabled = false;
                    fecha = "00/00/0000";
                }
                else if (comborepeticion.Text == "DIARIO")
                {
                    paneldias.Show();
                    datebox.Enabled = false;
                    fecha = "00/00/0000";
                }
                else if (comborepeticion.Text == "TODOS LOS DIAS")
                {
                    paneldias.Show();
                    datebox.Enabled = false;
                    fecha = "00/00/0000";

                }

            }
            else { 

            if (comborepeticion.Text == "NO")
            {
                paneldias.Hide();
                lunescheck.Checked = false;
                martescheckBox.Checked = false;
                miercolescheckBox.Checked = false;
                juevescheckBox.Checked = false;
                viernescheckbox.Checked = false;
                sabadocheckBox.Checked = false;
                domingocheckBox.Checked = false;
                datebox.Enabled = true;
            }
            else if (comborepeticion.Text == "ELEGIR")
            {
                paneldias.Show();
                lunescheck.Checked = false;
                martescheckBox.Checked = false;
                miercolescheckBox.Checked = false;
                juevescheckBox.Checked = false;
                viernescheckbox.Checked = false;
                sabadocheckBox.Checked = false;
                domingocheckBox.Checked = false;
                datebox.Enabled = false;
                fecha = "00/00/0000";
            }
            else if (comborepeticion.Text == "DIARIO")
            {
                paneldias.Show();
                lunescheck.Checked = true;
                martescheckBox.Checked = true;
                miercolescheckBox.Checked = true;
                juevescheckBox.Checked = true;
                viernescheckbox.Checked = true;
                sabadocheckBox.Checked = false;
                domingocheckBox.Checked = false;
                datebox.Enabled = false;
                fecha = "00/00/0000";
            }
            else if (comborepeticion.Text == "TODOS LOS DIAS")
            {
                paneldias.Show();
                lunescheck.Checked = true;
                martescheckBox.Checked = true;
                miercolescheckBox.Checked = true;
                juevescheckBox.Checked = true;
                viernescheckbox.Checked = true;
                sabadocheckBox.Checked = true;
                domingocheckBox.Checked = true;
                datebox.Enabled = false;
                fecha = "00/00/0000";

            }

        }
            if (lunescheck.Checked == true) { dias[0] = "SI"; } else { dias[0] = "NO"; }
            if (martescheckBox.Checked == true) { dias[1] = "SI"; } else { dias[1] = "NO"; }
            if (miercolescheckBox.Checked == true) { dias[2] = "SI"; } else { dias[2] = "NO"; }
            if (juevescheckBox.Checked == true) { dias[3] = "SI"; } else { dias[3] = "NO"; }
            if (viernescheckbox.Checked == true) { dias[4] = "SI"; } else { dias[4] = "NO"; }
            if (sabadocheckBox.Checked == true) { dias[5] = "SI"; } else { dias[5] = "NO"; }
            if (domingocheckBox.Checked == true) { dias[6] = "SI"; } else { dias[6] = "NO"; }

        }

        private void importancy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void paneldias_Paint(object sender, PaintEventArgs e)
        {

            

        }

        private void lunescheck_CheckedChanged(object sender, EventArgs e)
        {
            if (lunescheck.Checked == true) { dias[0] = "SI"; } else { dias[0] = "NO"; }
        }

        private void martescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (martescheckBox.Checked == true) { dias[1] = "SI"; } else { dias[1] = "NO"; }
            
        }

        private void miercolescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (miercolescheckBox.Checked == true) { dias[2] = "SI"; } else { dias[2] = "NO"; }
            
        }

        private void juevescheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (juevescheckBox.Checked == true) { dias[3] = "SI"; } else { dias[3] = "NO"; }
            
        }

        private void viernescheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (viernescheckbox.Checked == true) { dias[4] = "SI"; } else { dias[4] = "NO"; }
            
        }

        private void sabadocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sabadocheckBox.Checked == true) { dias[5] = "SI"; } else { dias[5] = "NO"; }
            
        }

        private void domingocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (domingocheckBox.Checked == true) { dias[6] = "SI"; } else { dias[6] = "NO"; }
        }

        private void activobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addbuton_Click(object sender, EventArgs e)
        {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            OpenFileDialog getfile = new OpenFileDialog();
            getfile.InitialDirectory = "C:\\";
            getfile.Filter = "Image Files(*.mp3)|*.mp3";
            getfile.FilterIndex = 1;

            if (getfile.ShowDialog() == DialogResult.OK)
            {
                string begin = getfile.FileName;
                string sourcePath = Path.GetDirectoryName(begin);
                string targetPath = System.IO.Path.Combine(path, UserAccessForm.getusername());

                melodybox.Text = System.IO.Path.GetFileName(getfile.FileName);
                string sourcefile = getfile.FileName;
                string destfile = System.IO.Path.Combine(path, melodybox.Text);
                
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }


                try
                {
                    System.IO.File.Copy(sourcefile, sourcefile, true);
                }
                catch (System.IO.IOException getto)
                {
                    
                    getto.ToString();
                }




                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    foreach (string s in files)
                    {
                        melodybox.Text = System.IO.Path.GetFileName(s);
                        destfile = System.IO.Path.Combine(targetPath, melodybox.Text);
                        try
                        {
                            System.IO.File.Copy(s, destfile, true);
                        }
                        catch (System.IO.IOException exept)
                        {

                            //melodybox.Text = System.IO.Path.GetFileName(getfile.FileName);
                            MessageBox.Show("TRATE DE SELECCIONAR OTRA CANCION");
                            exept.ToString();

                        }
                    }
                }

                playmusic.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna melodia", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void melodybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (melodybox.Text == "") { playmusic.Hide(); }
            else{ playmusic.Show(); }

            SystemSounds.Asterisk.Play();
            
        }


        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        private void playmusic_Click(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
           string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

           string melodypath = System.IO.Path.Combine(combinacion, melodybox.Text);

            wplayer.URL = melodypath;
            wplayer.controls.play();
            playmusic.Hide();
            stopmusic.Show();
        }

        private void stopmusic_Click(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string combinacion = System.IO.Path.Combine(path, UserAccessForm.getusername());

            string melodypath = System.IO.Path.Combine(combinacion, melodybox.Text);


            


            wplayer.URL = melodypath;
            wplayer.controls.stop();
            stopmusic.Hide();
            playmusic.Show();
            
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

        private void agendaAdd_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
}
