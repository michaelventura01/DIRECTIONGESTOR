namespace DireccionLib
{
    partial class StudentFormSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentFormSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menutrip = new System.Windows.Forms.ToolStrip();
            this.backstripbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.cleanbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hourlabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.datelabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.buttonpanel = new System.Windows.Forms.Panel();
            this.encontradoslabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inscritopanel = new System.Windows.Forms.Panel();
            this.getoutdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inscritobox = new System.Windows.Forms.ComboBox();
            this.getindateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.finderpanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gradebox = new System.Windows.Forms.ComboBox();
            this.birthdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.editbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.edadbox = new System.Windows.Forms.ComboBox();
            this.namebox = new System.Windows.Forms.ComboBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.eliminarbutton = new System.Windows.Forms.Button();
            this.namelbl = new System.Windows.Forms.Label();
            this.searchbutton = new System.Windows.Forms.Button();
            this.findinggrid = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.datecontrol = new System.Windows.Forms.DateTimePicker();
            this.menutrip.SuspendLayout();
            this.buttonpanel.SuspendLayout();
            this.inscritopanel.SuspendLayout();
            this.finderpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menutrip
            // 
            this.menutrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menutrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backstripbutton,
            this.toolStripButton3,
            this.cleanbuttonstrip,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.hourlabelstrip,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.datelabelstrip,
            this.toolStripButton1,
            this.toolStripButton2});
            this.menutrip.Location = new System.Drawing.Point(0, 875);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(1600, 25);
            this.menutrip.TabIndex = 81;
            this.menutrip.Text = "toolStrip1";
            // 
            // backstripbutton
            // 
            this.backstripbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.backstripbutton.Image = ((System.Drawing.Image)(resources.GetObject("backstripbutton.Image")));
            this.backstripbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backstripbutton.Name = "backstripbutton";
            this.backstripbutton.Size = new System.Drawing.Size(72, 22);
            this.backstripbutton.Text = "ATRAS";
            this.backstripbutton.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.hourlabelstrip.Click += new System.EventHandler(this.hourlabelstrip_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
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
            // buttonpanel
            // 
            this.buttonpanel.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonpanel.Controls.Add(this.encontradoslabel);
            this.buttonpanel.Controls.Add(this.label8);
            this.buttonpanel.Controls.Add(this.inscritopanel);
            this.buttonpanel.Controls.Add(this.label5);
            this.buttonpanel.Controls.Add(this.inscritobox);
            this.buttonpanel.Controls.Add(this.getindateTimePicker);
            this.buttonpanel.Controls.Add(this.label6);
            this.buttonpanel.Location = new System.Drawing.Point(228, 794);
            this.buttonpanel.Name = "buttonpanel";
            this.buttonpanel.Size = new System.Drawing.Size(1115, 65);
            this.buttonpanel.TabIndex = 80;
            this.buttonpanel.MouseHover += new System.EventHandler(this.buttonpanel_MouseHover);
            // 
            // encontradoslabel
            // 
            this.encontradoslabel.AutoSize = true;
            this.encontradoslabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encontradoslabel.ForeColor = System.Drawing.Color.Red;
            this.encontradoslabel.Location = new System.Drawing.Point(721, 20);
            this.encontradoslabel.Name = "encontradoslabel";
            this.encontradoslabel.Size = new System.Drawing.Size(38, 27);
            this.encontradoslabel.TabIndex = 79;
            this.encontradoslabel.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(497, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "ESTUDIANTES ENCONTRADOS:";
            // 
            // inscritopanel
            // 
            this.inscritopanel.Controls.Add(this.getoutdateTimePicker);
            this.inscritopanel.Controls.Add(this.label7);
            this.inscritopanel.Location = new System.Drawing.Point(815, 10);
            this.inscritopanel.Name = "inscritopanel";
            this.inscritopanel.Size = new System.Drawing.Size(273, 45);
            this.inscritopanel.TabIndex = 77;
            // 
            // getoutdateTimePicker
            // 
            this.getoutdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.getoutdateTimePicker.Location = new System.Drawing.Point(151, 14);
            this.getoutdateTimePicker.Name = "getoutdateTimePicker";
            this.getoutdateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.getoutdateTimePicker.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(7, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 16);
            this.label7.TabIndex = 75;
            this.label7.Text = "FECHA DE SALIDA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(329, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "INSCRITO:";
            // 
            // inscritobox
            // 
            this.inscritobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inscritobox.FormattingEnabled = true;
            this.inscritobox.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.inscritobox.Location = new System.Drawing.Point(408, 25);
            this.inscritobox.Name = "inscritobox";
            this.inscritobox.Size = new System.Drawing.Size(49, 21);
            this.inscritobox.TabIndex = 75;
            this.inscritobox.SelectedIndexChanged += new System.EventHandler(this.inscritobox_SelectedIndexChanged);
            // 
            // getindateTimePicker
            // 
            this.getindateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.getindateTimePicker.Location = new System.Drawing.Point(185, 25);
            this.getindateTimePicker.Name = "getindateTimePicker";
            this.getindateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.getindateTimePicker.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(33, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 16);
            this.label6.TabIndex = 73;
            this.label6.Text = "FECHA DE ENTRADA:";
            // 
            // finderpanel
            // 
            this.finderpanel.BackColor = System.Drawing.Color.Goldenrod;
            this.finderpanel.Controls.Add(this.label4);
            this.finderpanel.Controls.Add(this.gradebox);
            this.finderpanel.Controls.Add(this.birthdate);
            this.finderpanel.Controls.Add(this.label1);
            this.finderpanel.Controls.Add(this.editbutton);
            this.finderpanel.Controls.Add(this.label3);
            this.finderpanel.Controls.Add(this.edadbox);
            this.finderpanel.Controls.Add(this.namebox);
            this.finderpanel.Controls.Add(this.addbutton);
            this.finderpanel.Controls.Add(this.eliminarbutton);
            this.finderpanel.Controls.Add(this.namelbl);
            this.finderpanel.Controls.Add(this.searchbutton);
            this.finderpanel.Location = new System.Drawing.Point(228, 67);
            this.finderpanel.Name = "finderpanel";
            this.finderpanel.Size = new System.Drawing.Size(1115, 72);
            this.finderpanel.TabIndex = 78;
            this.finderpanel.MouseHover += new System.EventHandler(this.finderpanel_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(855, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "GRADO";
            // 
            // gradebox
            // 
            this.gradebox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradebox.FormattingEnabled = true;
            this.gradebox.Items.AddRange(new object[] {
            "CUIDO ",
            "PARVULOS - INICIAL",
            "PRE-KINDER - INICIAL",
            "KINDER - INICIAL",
            "PRE-PRIMARIO - INICIAL",
            "1RO - BASICA",
            "2DO - BASICA",
            "3RO - BASICA",
            "4TO - BASICA",
            "5TO - BASICA",
            "6TO - BASICA",
            "1RO - BACHILLERATO",
            "2DO - BACHILLERATO",
            "3RO - BACHILLERATO",
            "4TO - BACHILLERATO",
            "5TO - BACHILLERATO ",
            "6TO - BACHILLERATO"});
            this.gradebox.Location = new System.Drawing.Point(920, 12);
            this.gradebox.Name = "gradebox";
            this.gradebox.Size = new System.Drawing.Size(168, 21);
            this.gradebox.TabIndex = 69;
            this.gradebox.SelectedIndexChanged += new System.EventHandler(this.gradebox_SelectedIndexChanged);
            // 
            // birthdate
            // 
            this.birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthdate.Location = new System.Drawing.Point(587, 14);
            this.birthdate.Name = "birthdate";
            this.birthdate.Size = new System.Drawing.Size(110, 20);
            this.birthdate.TabIndex = 68;
            this.birthdate.ValueChanged += new System.EventHandler(this.birthdate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(415, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "FECHA DE NACIMIENTO";
            // 
            // editbutton
            // 
            this.editbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.editbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editbutton.Location = new System.Drawing.Point(718, 41);
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(118, 25);
            this.editbutton.TabIndex = 66;
            this.editbutton.Text = "EDITAR";
            this.editbutton.UseVisualStyleBackColor = true;
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(719, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "EDAD";
            // 
            // edadbox
            // 
            this.edadbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edadbox.FormattingEnabled = true;
            this.edadbox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.edadbox.Location = new System.Drawing.Point(768, 12);
            this.edadbox.Name = "edadbox";
            this.edadbox.Size = new System.Drawing.Size(60, 21);
            this.edadbox.TabIndex = 64;
            this.edadbox.SelectedIndexChanged += new System.EventHandler(this.edadbox_SelectedIndexChanged);
            // 
            // namebox
            // 
            this.namebox.FormattingEnabled = true;
            this.namebox.Location = new System.Drawing.Point(170, 12);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(230, 21);
            this.namebox.TabIndex = 61;
            this.namebox.SelectedIndexChanged += new System.EventHandler(this.namebox_SelectedIndexChanged);
            // 
            // addbutton
            // 
            this.addbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.addbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addbutton.Location = new System.Drawing.Point(839, 41);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(118, 25);
            this.addbutton.TabIndex = 6;
            this.addbutton.Text = "AGREGAR";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // eliminarbutton
            // 
            this.eliminarbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.eliminarbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eliminarbutton.Location = new System.Drawing.Point(960, 41);
            this.eliminarbutton.Name = "eliminarbutton";
            this.eliminarbutton.Size = new System.Drawing.Size(129, 25);
            this.eliminarbutton.TabIndex = 5;
            this.eliminarbutton.Text = "DESINCRIBIR";
            this.eliminarbutton.UseVisualStyleBackColor = true;
            this.eliminarbutton.Click += new System.EventHandler(this.eliminarbutton_Click);
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.namelbl.Location = new System.Drawing.Point(10, 16);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(154, 16);
            this.namelbl.TabIndex = 2;
            this.namelbl.Text = "NOMBRE COMPLETO";
            // 
            // searchbutton
            // 
            this.searchbutton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.searchbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchbutton.Location = new System.Drawing.Point(13, 41);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(107, 25);
            this.searchbutton.TabIndex = 1;
            this.searchbutton.Text = "BUSCAR";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // findinggrid
            // 
            this.findinggrid.AllowUserToAddRows = false;
            this.findinggrid.AllowUserToDeleteRows = false;
            this.findinggrid.AllowUserToResizeColumns = false;
            this.findinggrid.AllowUserToResizeRows = false;
            this.findinggrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.findinggrid.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
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
            this.findinggrid.Location = new System.Drawing.Point(228, 139);
            this.findinggrid.Name = "findinggrid";
            this.findinggrid.ReadOnly = true;
            this.findinggrid.Size = new System.Drawing.Size(1115, 654);
            this.findinggrid.TabIndex = 79;
            this.findinggrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentClick);
            this.findinggrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentDoubleClick);
            this.findinggrid.MouseHover += new System.EventHandler(this.findinggrid_MouseHover);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(223, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 27);
            this.label2.TabIndex = 82;
            this.label2.Text = "BUSCAR ESTUDIANTE";
            // 
            // datecontrol
            // 
            this.datecontrol.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datecontrol.Location = new System.Drawing.Point(506, 25);
            this.datecontrol.Name = "datecontrol";
            this.datecontrol.Size = new System.Drawing.Size(110, 20);
            this.datecontrol.TabIndex = 83;
            // 
            // StudentFormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.datecontrol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menutrip);
            this.Controls.Add(this.buttonpanel);
            this.Controls.Add(this.finderpanel);
            this.Controls.Add(this.findinggrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentFormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentFormSearch";
            this.Load += new System.EventHandler(this.StudentFormSearch_Load);
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            this.buttonpanel.ResumeLayout(false);
            this.buttonpanel.PerformLayout();
            this.inscritopanel.ResumeLayout(false);
            this.inscritopanel.PerformLayout();
            this.finderpanel.ResumeLayout(false);
            this.finderpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.Panel buttonpanel;
        private System.Windows.Forms.Panel finderpanel;
        private System.Windows.Forms.DateTimePicker birthdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox edadbox;
        private System.Windows.Forms.ComboBox namebox;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button eliminarbutton;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.DataGridView findinggrid;
        private System.Windows.Forms.ToolStripButton backstripbutton;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton cleanbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel hourlabelstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel datelabelstrip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox gradebox;
        private System.Windows.Forms.Panel inscritopanel;
        private System.Windows.Forms.DateTimePicker getoutdateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox inscritobox;
        private System.Windows.Forms.DateTimePicker getindateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DateTimePicker datecontrol;
        private System.Windows.Forms.Label encontradoslabel;
        private System.Windows.Forms.Label label8;
    }
}