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
    public partial class GastosForm : Form
    {
        public GastosForm()
        {
            InitializeComponent();
        }

        private void backbuttonstrip_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void cleanbuttonstrip_Click(object sender, EventArgs e)
        {
            cuantitybox.Text = "";
            reasonbox.Text = "";
            monedatipo.Text = "DOP";
            fondoorigen.Text = "EFECTIVO";
            datebox.Text = DateTime.Now.ToString();
            horabox.Text = DateTime.Now.ToString();
            MovementsClass movement = new MovementsClass();
        }

        private void addbuttonstrip_Click(object sender, EventArgs e)
        {
           

            if (DireccionGestor.getorigen() == "inicio")
            {
                if (reasonbox.Text == "" || cuantitybox.Text == "" || explanationbox.Text == "")
                {
                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");
                    if (reasonbox.Text == "")
                    {
                        reasonbox.BackColor = Color.Red;
                    }
                    else
                    {
                        reasonbox.BackColor = Color.Green;
                    }

                    if (cuantitybox.Text == "")
                    {
                        cuantitybox.BackColor = Color.Red;
                    }
                    else
                    {
                        cuantitybox.BackColor = Color.Green;
                    }

                    if (explanationbox.Text == "")
                    {
                        explanationbox.BackColor = Color.Red;
                    }
                    else
                    {
                        explanationbox.BackColor = Color.Green;
                    }


                }
                else
                {
                    DireccionGestor.setotrostatic("refresh");
                    try
                    {
                        string userDataName = UserAccessForm.getusername() + "_movements_table";
                        MovementsClass save = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        double cuantity = double.Parse(cuantitybox.Text);
                        string date = datebox.Value.Day.ToString() + "/" + datebox.Value.Month.ToString() + "/" + datebox.Value.Year.ToString();
                        string hour = horabox.Value.Hour.ToString() + ":" + horabox.Value.Minute.ToString() + ":" + horabox.Value.Second.ToString();






                        if (save.setExpense(date, hour, reasonbox.Text, cuantity, monedatipo.Text, datebox.Value.Day.ToString(), datebox.Value.Month.ToString()
                                , datebox.Value.Year.ToString(), horabox.Value.Hour.ToString(), horabox.Value.Minute.ToString(), horabox.Value.Second.ToString(),
                                explanationbox.Text, fondoorigen.Text, userDataName))
                            {

                                save.OrderID(userDataName);
                                MessageBox.Show("NUEVO GASTO DE DINERO A LAS " + hour + " HA SIDO REGISTRADO");
                                if (MessageBox.Show("REGISTRAR OTRO GASTO DE DINERO?", "REGISTRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    save = new MovementsClass();
                                    this.Close();
                                    GastosForm menu = new GastosForm();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                }
                                else
                                {
                                    save = new MovementsClass();
                                    this.Close();

                                }
                            }
                            else
                            {
                                MessageBox.Show("GASTO DE DINERO A LAS " + hour + " HA SIDO REGISTRADO");
                                if (MessageBox.Show("REGISTRAR OTRO GASTO DE DINERO?", "REGISTRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    save = new MovementsClass();
                                    this.Close();
                                    GastosForm menu = new GastosForm();
                                    menu.WindowState = FormWindowState.Normal;
                                    menu.Show();
                                }
                                else
                                {
                                    save = new MovementsClass();
                                    this.Close();

                                }
                            }

                        

                    }
                    catch (FormatException datethis) { datethis.ToString(); }
                    catch (InvalidCastException datethose) { MessageBox.Show(datethose.ToString()); }
                }
            }
            else if (DireccionGestor.getorigen() == "editor")
            {

                if (reasonbox.Text == "" || cuantitybox.Text == "" || explanationbox.Text == "")
                {
                    MessageBox.Show("Hay datos importantes vacios, termine el formulario.");
                    if (reasonbox.Text == "")
                    {
                        reasonbox.BackColor = Color.Red;
                    }
                    else
                    {
                        reasonbox.BackColor = Color.Green;
                    }

                    if (cuantitybox.Text == "")
                    {
                        cuantitybox.BackColor = Color.Red;
                    }
                    else
                    {
                        cuantitybox.BackColor = Color.Green;
                    }

                    if (explanationbox.Text == "")
                    {
                        explanationbox.BackColor = Color.Red;
                    }
                    else
                    {
                        explanationbox.BackColor = Color.Green;
                    }


                }
                else
                {
                    try
                    {
                        string userDataName = UserAccessForm.getusername() + "_movements_table";
                        MovementsClass save = new MovementsClass(UserAccessForm.getdbserver(), UserAccessForm.getdbname(), UserAccessForm.getdbuser(), UserAccessForm.getdbpassword(), UserAccessForm.getdbport());
                        double cuantity = double.Parse(cuantitybox.Text);
                        string date = datebox.Value.Day.ToString() + "/" + datebox.Value.Month.ToString() + "/" + datebox.Value.Year.ToString();
                        string hour = horabox.Value.Hour.ToString() + ":" + horabox.Value.Minute.ToString() + ":" + horabox.Value.Second.ToString();
                         DireccionGestor.setotrostatic("refresh");
                        string orden = "UPDATE " + userDataName + " SET `FECHA DEL MOVIMIENTO`='" + date + "',  `HORA DEL MOVIMIENTO`='" + hour + "', MOTIVO='" + reasonbox.Text + "', GASTO='" + cuantity + "', `TIPO DE MONEDA`='" + monedatipo.Text + "',DIA='" + datebox.Value.Day.ToString() + "', MES='" + datebox.Value.Month.ToString() + "', AÑO='" + datebox.Value.Year.ToString() + "', HORA='" + datebox.Value.Hour.ToString() + "', MINUTO='" + datebox.Value.Minute.ToString() + "', SEGUNDO='" + datebox.Value.Second.ToString() + "', EXPLICACION='" + explanationbox.Text + "', `FORMA DE PAGO`='" + fondoorigen.Text + "' WHERE ID='" + MovementsClass.getdato()[0] + "' AND `FECHA DEL MOVIMIENTO`='" + MovementsClass.getdato()[2] + "' AND  `HORA DEL MOVIMIENTO`='" + MovementsClass.getdato()[3] + "';";
                        save.ordensql(orden);


                        MessageBox.Show("INGRESO DE LAS " + MovementsClass.getdato()[3] + " EL DIA " + MovementsClass.getdato()[2] + " HA SIDO EDITADO");
                        this.Close();
                    }
                    catch (FormatException datethis) { MessageBox.Show(datethis.ToString()); }
                    catch (InvalidCastException datethose) { MessageBox.Show(datethose.ToString()); }

                }

            }

        }
            

            private void cuantitybox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten numeros");
                }
            }

        private void reasonbox_TextChanged(object sender, EventArgs e)
        {
            reasonbox.BackColor = Color.White;
        }

        private void explanationbox_TextChanged(object sender, EventArgs e)
        {
            explanationbox.BackColor = Color.White;
        }

        private void cuantitybox_TextChanged(object sender, EventArgs e)
        {
            cuantitybox.BackColor = Color.White;
        }

        private void GastosForm_Load(object sender, EventArgs e)
        {
            if (DireccionGestor.getorigen() == "inicio")
            {
                monedatipo.Text = "DOP";
                fondoorigen.Text = "EFECTIVO";

            }
            
            else if (DireccionGestor.getorigen() == "editor")
            {
                titlegasto.Text = "MODIFICAR GASTO";
                addbuttonstrip.Text = "MODIFICAR";
                datebox.Text = MovementsClass.getdato()[2];
                horabox.Text = MovementsClass.getdato()[3];
                reasonbox.Text = MovementsClass.getdato()[1];
                monedatipo.Text = MovementsClass.getdato()[5];
                cuantitybox.Text = MovementsClass.getdato()[4];
                explanationbox.Text = MovementsClass.getdato()[6];
                fondoorigen.Text = MovementsClass.getdato()[7];


            }
        }
        private int segundo=0;
        private void timergasto_Tick(object sender, EventArgs e)
        {
            segundo++;
            cuenta++;
            if (cuenta == 3000)
            {

                cuenta = 0;
                backbuttonstrip.PerformClick();
            }



        }


        private int cuenta;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

            IngresosForm add = new IngresosForm();
            add.WindowState = FormWindowState.Normal;
            add.Show();
            this.Close();
        }

        private void GastosForm_MouseHover(object sender, EventArgs e)
        {
            cuenta = 0;
        }
    }
    }

