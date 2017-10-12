namespace DireccionLib
{
    partial class EmployeeFormSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeFormSearch));
            this.finderpanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cargobox = new System.Windows.Forms.ComboBox();
            this.birthdatebox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.editbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.edadbox = new System.Windows.Forms.ComboBox();
            this.comboname = new System.Windows.Forms.ComboBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.eliminarbutton = new System.Windows.Forms.Button();
            this.namelbl = new System.Windows.Forms.Label();
            this.searchbutton = new System.Windows.Forms.Button();
            this.buttonpanel = new System.Windows.Forms.Panel();
            this.encontradoslabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trabajandopanel = new System.Windows.Forms.Panel();
            this.getoutdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.workingbox = new System.Windows.Forms.ComboBox();
            this.getindateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.findinggrid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backstripbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.cleanbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.hourlabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.datelabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.timera = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.datecontrol = new System.Windows.Forms.DateTimePicker();
            this.finderpanel.SuspendLayout();
            this.buttonpanel.SuspendLayout();
            this.trabajandopanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // finderpanel
            // 
            this.finderpanel.BackColor = System.Drawing.Color.Goldenrod;
            this.finderpanel.Controls.Add(this.label4);
            this.finderpanel.Controls.Add(this.cargobox);
            this.finderpanel.Controls.Add(this.birthdatebox);
            this.finderpanel.Controls.Add(this.label1);
            this.finderpanel.Controls.Add(this.editbutton);
            this.finderpanel.Controls.Add(this.label3);
            this.finderpanel.Controls.Add(this.edadbox);
            this.finderpanel.Controls.Add(this.comboname);
            this.finderpanel.Controls.Add(this.addbutton);
            this.finderpanel.Controls.Add(this.eliminarbutton);
            this.finderpanel.Controls.Add(this.namelbl);
            this.finderpanel.Controls.Add(this.searchbutton);
            this.finderpanel.Location = new System.Drawing.Point(222, 69);
            this.finderpanel.Name = "finderpanel";
            this.finderpanel.Size = new System.Drawing.Size(1126, 72);
            this.finderpanel.TabIndex = 82;
            this.finderpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.finderpanel_Paint);
            this.finderpanel.MouseHover += new System.EventHandler(this.finderpanel_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(866, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "CARGO";
            // 
            // cargobox
            // 
            this.cargobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cargobox.FormattingEnabled = true;
            this.cargobox.Location = new System.Drawing.Point(927, 11);
            this.cargobox.Name = "cargobox";
            this.cargobox.Size = new System.Drawing.Size(161, 21);
            this.cargobox.TabIndex = 69;
            this.cargobox.SelectedIndexChanged += new System.EventHandler(this.cargobox_SelectedIndexChanged);
            // 
            // birthdatebox
            // 
            this.birthdatebox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdatebox.Location = new System.Drawing.Point(621, 10);
            this.birthdatebox.Name = "birthdatebox";
            this.birthdatebox.Size = new System.Drawing.Size(100, 20);
            this.birthdatebox.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(449, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "FECHA DE NACIMIENTO";
            // 
            // editbutton
            // 
            this.editbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editbutton.Location = new System.Drawing.Point(727, 38);
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(117, 25);
            this.editbutton.TabIndex = 66;
            this.editbutton.Text = "EDITAR";
            this.editbutton.UseVisualStyleBackColor = true;
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(744, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "EDAD";
            // 
            // edadbox
            // 
            this.edadbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edadbox.FormattingEnabled = true;
            this.edadbox.Location = new System.Drawing.Point(793, 10);
            this.edadbox.Name = "edadbox";
            this.edadbox.Size = new System.Drawing.Size(51, 21);
            this.edadbox.TabIndex = 64;
            this.edadbox.SelectedIndexChanged += new System.EventHandler(this.edadbox_SelectedIndexChanged);
            // 
            // comboname
            // 
            this.comboname.FormattingEnabled = true;
            this.comboname.Location = new System.Drawing.Point(180, 9);
            this.comboname.Name = "comboname";
            this.comboname.Size = new System.Drawing.Size(233, 21);
            this.comboname.TabIndex = 61;
            this.comboname.SelectedIndexChanged += new System.EventHandler(this.comboname_SelectedIndexChanged);
            // 
            // addbutton
            // 
            this.addbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addbutton.Location = new System.Drawing.Point(850, 38);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(117, 25);
            this.addbutton.TabIndex = 6;
            this.addbutton.Text = "AGREGAR";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // eliminarbutton
            // 
            this.eliminarbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eliminarbutton.Location = new System.Drawing.Point(971, 38);
            this.eliminarbutton.Name = "eliminarbutton";
            this.eliminarbutton.Size = new System.Drawing.Size(117, 25);
            this.eliminarbutton.TabIndex = 5;
            this.eliminarbutton.Text = "DESPEDIR";
            this.eliminarbutton.UseVisualStyleBackColor = true;
            this.eliminarbutton.Click += new System.EventHandler(this.eliminarbutton_Click);
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.namelbl.Location = new System.Drawing.Point(24, 11);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(154, 16);
            this.namelbl.TabIndex = 2;
            this.namelbl.Text = "NOMBRE COMPLETO";
            // 
            // searchbutton
            // 
            this.searchbutton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchbutton.Location = new System.Drawing.Point(23, 38);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(117, 25);
            this.searchbutton.TabIndex = 1;
            this.searchbutton.Text = "BUSCAR";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // buttonpanel
            // 
            this.buttonpanel.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonpanel.Controls.Add(this.encontradoslabel);
            this.buttonpanel.Controls.Add(this.label8);
            this.buttonpanel.Controls.Add(this.trabajandopanel);
            this.buttonpanel.Controls.Add(this.label5);
            this.buttonpanel.Controls.Add(this.workingbox);
            this.buttonpanel.Controls.Add(this.getindateTimePicker);
            this.buttonpanel.Controls.Add(this.label6);
            this.buttonpanel.Location = new System.Drawing.Point(222, 795);
            this.buttonpanel.Name = "buttonpanel";
            this.buttonpanel.Size = new System.Drawing.Size(1126, 71);
            this.buttonpanel.TabIndex = 80;
            this.buttonpanel.MouseHover += new System.EventHandler(this.buttonpanel_MouseHover);
            // 
            // encontradoslabel
            // 
            this.encontradoslabel.AutoSize = true;
            this.encontradoslabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encontradoslabel.ForeColor = System.Drawing.Color.Red;
            this.encontradoslabel.Location = new System.Drawing.Point(713, 27);
            this.encontradoslabel.Name = "encontradoslabel";
            this.encontradoslabel.Size = new System.Drawing.Size(38, 27);
            this.encontradoslabel.TabIndex = 84;
            this.encontradoslabel.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(507, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "EMPLEADOS ENCONTRADOS:";
            // 
            // trabajandopanel
            // 
            this.trabajandopanel.Controls.Add(this.getoutdateTimePicker);
            this.trabajandopanel.Controls.Add(this.label7);
            this.trabajandopanel.Location = new System.Drawing.Point(793, 15);
            this.trabajandopanel.Name = "trabajandopanel";
            this.trabajandopanel.Size = new System.Drawing.Size(305, 44);
            this.trabajandopanel.TabIndex = 82;
            // 
            // getoutdateTimePicker
            // 
            this.getoutdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.getoutdateTimePicker.Location = new System.Drawing.Point(167, 14);
            this.getoutdateTimePicker.Name = "getoutdateTimePicker";
            this.getoutdateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.getoutdateTimePicker.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(27, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 16);
            this.label7.TabIndex = 75;
            this.label7.Text = "FECHA DE SALIDA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(308, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "TRABAJANDO:";
            // 
            // workingbox
            // 
            this.workingbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workingbox.FormattingEnabled = true;
            this.workingbox.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.workingbox.Location = new System.Drawing.Point(415, 31);
            this.workingbox.Name = "workingbox";
            this.workingbox.Size = new System.Drawing.Size(53, 21);
            this.workingbox.TabIndex = 80;
            this.workingbox.SelectedIndexChanged += new System.EventHandler(this.workingbox_SelectedIndexChanged);
            // 
            // getindateTimePicker
            // 
            this.getindateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.getindateTimePicker.Location = new System.Drawing.Point(169, 31);
            this.getindateTimePicker.Name = "getindateTimePicker";
            this.getindateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.getindateTimePicker.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(18, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "FECHA DE ENTRADA:";
            // 
            // findinggrid
            // 
            this.findinggrid.AllowUserToAddRows = false;
            this.findinggrid.AllowUserToDeleteRows = false;
            this.findinggrid.AllowUserToResizeColumns = false;
            this.findinggrid.AllowUserToResizeRows = false;
            this.findinggrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.findinggrid.BackgroundColor = System.Drawing.Color.Chocolate;
            this.findinggrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.findinggrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.findinggrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.findinggrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.findinggrid.GridColor = System.Drawing.Color.LightGray;
            this.findinggrid.Location = new System.Drawing.Point(222, 141);
            this.findinggrid.Name = "findinggrid";
            this.findinggrid.ReadOnly = true;
            this.findinggrid.Size = new System.Drawing.Size(1126, 654);
            this.findinggrid.TabIndex = 79;
            this.findinggrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentClick);
            this.findinggrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentDoubleClick);
            this.findinggrid.MouseHover += new System.EventHandler(this.findinggrid_MouseHover);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backstripbutton,
            this.toolStripButton3,
            this.cleanbuttonstrip,
            this.toolStripSeparator5,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.hourlabelstrip,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.datelabelstrip,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 875);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1600, 25);
            this.toolStrip1.TabIndex = 83;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // backstripbutton
            // 
            this.backstripbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.backstripbutton.Image = ((System.Drawing.Image)(resources.GetObject("backstripbutton.Image")));
            this.backstripbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backstripbutton.Name = "backstripbutton";
            this.backstripbutton.Size = new System.Drawing.Size(72, 22);
            this.backstripbutton.Text = "ATRAS";
            this.backstripbutton.Click += new System.EventHandler(this.backstripbutton_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton2";
            // 
            // cleanbuttonstrip
            // 
            this.cleanbuttonstrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cleanbuttonstrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cleanbuttonstrip.Image = global::DireccionLib.Properties.Resources.mxcperaser_blue_512;
            this.cleanbuttonstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cleanbuttonstrip.Name = "cleanbuttonstrip";
            this.cleanbuttonstrip.Size = new System.Drawing.Size(85, 22);
            this.cleanbuttonstrip.Text = "LIMPIAR";
            this.cleanbuttonstrip.Click += new System.EventHandler(this.cleanbuttonstrip_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // hourlabelstrip
            // 
            this.hourlabelstrip.BackColor = System.Drawing.SystemColors.Menu;
            this.hourlabelstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hourlabelstrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.hourlabelstrip.Image = ((System.Drawing.Image)(resources.GetObject("hourlabelstrip.Image")));
            this.hourlabelstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hourlabelstrip.Name = "hourlabelstrip";
            this.hourlabelstrip.Size = new System.Drawing.Size(64, 22);
            this.hourlabelstrip.Text = "00:00:00";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // datelabelstrip
            // 
            this.datelabelstrip.BackColor = System.Drawing.SystemColors.Menu;
            this.datelabelstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.datelabelstrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.datelabelstrip.Image = ((System.Drawing.Image)(resources.GetObject("datelabelstrip.Image")));
            this.datelabelstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.datelabelstrip.Name = "datelabelstrip";
            this.datelabelstrip.Size = new System.Drawing.Size(60, 22);
            this.datelabelstrip.Text = "Disable";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(95, 22);
            this.toolStripButton2.Text = "IMPRIMIR";
            // 
            // timera
            // 
            this.timera.Enabled = true;
            this.timera.Interval = 1000;
            this.timera.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(263, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 27);
            this.label2.TabIndex = 84;
            this.label2.Text = "BUSCAR EMPLEADO";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // datecontrol
            // 
            this.datecontrol.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datecontrol.Location = new System.Drawing.Point(526, 22);
            this.datecontrol.Name = "datecontrol";
            this.datecontrol.Size = new System.Drawing.Size(100, 20);
            this.datecontrol.TabIndex = 85;
            // 
            // EmployeeFormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.datecontrol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.finderpanel);
            this.Controls.Add(this.buttonpanel);
            this.Controls.Add(this.findinggrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeFormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeFormSearch";
            this.Load += new System.EventHandler(this.EmployeeFormSearch_Load);
            this.MouseHover += new System.EventHandler(this.EmployeeFormSearch_MouseHover);
            this.finderpanel.ResumeLayout(false);
            this.finderpanel.PerformLayout();
            this.buttonpanel.ResumeLayout(false);
            this.buttonpanel.PerformLayout();
            this.trabajandopanel.ResumeLayout(false);
            this.trabajandopanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel finderpanel;
        private System.Windows.Forms.DateTimePicker birthdatebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox edadbox;
        private System.Windows.Forms.ComboBox comboname;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button eliminarbutton;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.Panel buttonpanel;
        private System.Windows.Forms.DataGridView findinggrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backstripbutton;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton cleanbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel hourlabelstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel datelabelstrip;
        private System.Windows.Forms.Timer timera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cargobox;
        private System.Windows.Forms.Panel trabajandopanel;
        private System.Windows.Forms.DateTimePicker getoutdateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox workingbox;
        private System.Windows.Forms.DateTimePicker getindateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DateTimePicker datecontrol;
        private System.Windows.Forms.Label encontradoslabel;
        private System.Windows.Forms.Label label8;
    }
}