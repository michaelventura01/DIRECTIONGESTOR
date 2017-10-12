namespace DireccionLib
{
    partial class UsersShowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersShowForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.backstripbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.cleanbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.hourlabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.datelabelstrip = new System.Windows.Forms.ToolStripLabel();
            this.finderpanel = new System.Windows.Forms.Panel();
            this.tipobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editbutton = new System.Windows.Forms.Button();
            this.namebox = new System.Windows.Forms.ComboBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.namelbl = new System.Windows.Forms.Label();
            this.searchbutton = new System.Windows.Forms.Button();
            this.buttonpanel = new System.Windows.Forms.Panel();
            this.encontradoslabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timera = new System.Windows.Forms.Timer(this.components);
            this.findinggrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.opcionpanel = new System.Windows.Forms.Panel();
            this.cargarlabel = new System.Windows.Forms.Label();
            this.cargar = new System.Windows.Forms.PictureBox();
            this.savedatalabel = new System.Windows.Forms.Label();
            this.savedata = new System.Windows.Forms.PictureBox();
            this.deletelabel = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.PictureBox();
            this.editlabel = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.PictureBox();
            this.passlabel = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.finderpanel.SuspendLayout();
            this.buttonpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.opcionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(304, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 27);
            this.label2.TabIndex = 89;
            this.label2.Text = "VER USUARIOS";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backstripbutton,
            this.toolStripButton3,
            this.cleanbuttonstrip,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.hourlabelstrip,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.datelabelstrip});
            this.toolStrip.Location = new System.Drawing.Point(0, 875);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(1600, 25);
            this.toolStrip.TabIndex = 88;
            this.toolStrip.Text = "toolStrip1";
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
            // finderpanel
            // 
            this.finderpanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.finderpanel.Controls.Add(this.tipobox);
            this.finderpanel.Controls.Add(this.label1);
            this.finderpanel.Controls.Add(this.editbutton);
            this.finderpanel.Controls.Add(this.namebox);
            this.finderpanel.Controls.Add(this.addbutton);
            this.finderpanel.Controls.Add(this.namelbl);
            this.finderpanel.Controls.Add(this.searchbutton);
            this.finderpanel.Location = new System.Drawing.Point(302, 74);
            this.finderpanel.Name = "finderpanel";
            this.finderpanel.Size = new System.Drawing.Size(1031, 72);
            this.finderpanel.TabIndex = 87;
            this.finderpanel.MouseHover += new System.EventHandler(this.finderpanel_MouseHover);
            // 
            // tipobox
            // 
            this.tipobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipobox.FormattingEnabled = true;
            this.tipobox.Items.AddRange(new object[] {
            "INICIAL-BASICA",
            "BASICA-MEDIA",
            "INICIAL-MEDIA",
            "TODOS"});
            this.tipobox.Location = new System.Drawing.Point(715, 11);
            this.tipobox.Name = "tipobox";
            this.tipobox.Size = new System.Drawing.Size(228, 21);
            this.tipobox.TabIndex = 68;
            this.tipobox.SelectedIndexChanged += new System.EventHandler(this.tipobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(660, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 67;
            this.label1.Text = "TIPO";
            // 
            // editbutton
            // 
            this.editbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.editbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editbutton.Location = new System.Drawing.Point(812, 38);
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(131, 25);
            this.editbutton.TabIndex = 66;
            this.editbutton.Text = "OPCIONES";
            this.editbutton.UseVisualStyleBackColor = true;
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // namebox
            // 
            this.namebox.FormattingEnabled = true;
            this.namebox.Items.AddRange(new object[] {
            "TODOS"});
            this.namebox.Location = new System.Drawing.Point(174, 11);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(276, 21);
            this.namebox.TabIndex = 61;
            this.namebox.SelectedIndexChanged += new System.EventHandler(this.namebox_SelectedIndexChanged);
            // 
            // addbutton
            // 
            this.addbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.addbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addbutton.Location = new System.Drawing.Point(664, 38);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(127, 25);
            this.addbutton.TabIndex = 6;
            this.addbutton.Text = "AGREGAR";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.namelbl.Location = new System.Drawing.Point(85, 10);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(83, 19);
            this.namelbl.TabIndex = 2;
            this.namelbl.Text = "USUARIO";
            // 
            // searchbutton
            // 
            this.searchbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.searchbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchbutton.Location = new System.Drawing.Point(89, 38);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(129, 25);
            this.searchbutton.TabIndex = 1;
            this.searchbutton.Text = "BUSCAR";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // buttonpanel
            // 
            this.buttonpanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonpanel.Controls.Add(this.encontradoslabel);
            this.buttonpanel.Controls.Add(this.label8);
            this.buttonpanel.Location = new System.Drawing.Point(302, 800);
            this.buttonpanel.Name = "buttonpanel";
            this.buttonpanel.Size = new System.Drawing.Size(1031, 71);
            this.buttonpanel.TabIndex = 86;
            this.buttonpanel.MouseHover += new System.EventHandler(this.buttonpanel_MouseHover);
            // 
            // encontradoslabel
            // 
            this.encontradoslabel.AutoSize = true;
            this.encontradoslabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encontradoslabel.ForeColor = System.Drawing.Color.Red;
            this.encontradoslabel.Location = new System.Drawing.Point(584, 22);
            this.encontradoslabel.Name = "encontradoslabel";
            this.encontradoslabel.Size = new System.Drawing.Size(38, 27);
            this.encontradoslabel.TabIndex = 86;
            this.encontradoslabel.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(383, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 16);
            this.label8.TabIndex = 85;
            this.label8.Text = "USUARIOS ENCONTRADOS:";
            // 
            // timera
            // 
            this.timera.Enabled = true;
            this.timera.Interval = 1000;
            this.timera.Tick += new System.EventHandler(this.timera_Tick);
            // 
            // findinggrid
            // 
            this.findinggrid.AllowUserToAddRows = false;
            this.findinggrid.AllowUserToDeleteRows = false;
            this.findinggrid.AllowUserToResizeColumns = false;
            this.findinggrid.AllowUserToResizeRows = false;
            this.findinggrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.findinggrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.findinggrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.findinggrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findinggrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.findinggrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.findinggrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.findinggrid.Location = new System.Drawing.Point(302, 185);
            this.findinggrid.Name = "findinggrid";
            this.findinggrid.ReadOnly = true;
            this.findinggrid.Size = new System.Drawing.Size(1031, 615);
            this.findinggrid.TabIndex = 90;
            this.findinggrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentClick);
            this.findinggrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.findinggrid_CellContentDoubleClick);
            this.findinggrid.MouseHover += new System.EventHandler(this.findinggrid_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(49, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 19);
            this.label3.TabIndex = 91;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(211, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 92;
            this.label4.Text = "USUARIO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(393, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 93;
            this.label5.Text = "TIPO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(548, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 19);
            this.label6.TabIndex = 94;
            this.label6.Text = "FECHA CREADO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(80, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 19);
            this.label7.TabIndex = 95;
            this.label7.Text = "ULTIMA CONEXION";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(302, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 39);
            this.panel1.TabIndex = 96;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(702, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 38);
            this.panel2.TabIndex = 96;
            this.panel2.MouseHover += new System.EventHandler(this.panel2_MouseHover);
            // 
            // opcionpanel
            // 
            this.opcionpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.opcionpanel.Controls.Add(this.cargarlabel);
            this.opcionpanel.Controls.Add(this.cargar);
            this.opcionpanel.Controls.Add(this.savedatalabel);
            this.opcionpanel.Controls.Add(this.savedata);
            this.opcionpanel.Controls.Add(this.deletelabel);
            this.opcionpanel.Controls.Add(this.delete);
            this.opcionpanel.Controls.Add(this.editlabel);
            this.opcionpanel.Controls.Add(this.edit);
            this.opcionpanel.Controls.Add(this.passlabel);
            this.opcionpanel.Controls.Add(this.pass);
            this.opcionpanel.Controls.Add(this.label9);
            this.opcionpanel.Location = new System.Drawing.Point(302, 276);
            this.opcionpanel.Name = "opcionpanel";
            this.opcionpanel.Size = new System.Drawing.Size(1031, 225);
            this.opcionpanel.TabIndex = 97;
            this.opcionpanel.MouseHover += new System.EventHandler(this.opcionpanel_MouseHover);
            // 
            // cargarlabel
            // 
            this.cargarlabel.AutoSize = true;
            this.cargarlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.cargarlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cargarlabel.Location = new System.Drawing.Point(837, 156);
            this.cargarlabel.Name = "cargarlabel";
            this.cargarlabel.Size = new System.Drawing.Size(125, 19);
            this.cargarlabel.TabIndex = 105;
            this.cargarlabel.Text = "CARGAR DATA";
            // 
            // cargar
            // 
            this.cargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cargar.Image = global::DireccionLib.Properties.Resources.icon_backup;
            this.cargar.Location = new System.Drawing.Point(854, 57);
            this.cargar.Name = "cargar";
            this.cargar.Size = new System.Drawing.Size(89, 88);
            this.cargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cargar.TabIndex = 104;
            this.cargar.TabStop = false;
            this.cargar.Click += new System.EventHandler(this.cargar_Click);
            this.cargar.MouseLeave += new System.EventHandler(this.cargar_MouseLeave);
            this.cargar.MouseHover += new System.EventHandler(this.cargar_MouseHover);
            // 
            // savedatalabel
            // 
            this.savedatalabel.AutoSize = true;
            this.savedatalabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.savedatalabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.savedatalabel.Location = new System.Drawing.Point(656, 156);
            this.savedatalabel.Name = "savedatalabel";
            this.savedatalabel.Size = new System.Drawing.Size(137, 19);
            this.savedatalabel.TabIndex = 103;
            this.savedatalabel.Text = "GUARDAR DATA";
            // 
            // savedata
            // 
            this.savedata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.savedata.Image = global::DireccionLib.Properties.Resources.multimedia;
            this.savedata.Location = new System.Drawing.Point(676, 57);
            this.savedata.Name = "savedata";
            this.savedata.Size = new System.Drawing.Size(89, 88);
            this.savedata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.savedata.TabIndex = 102;
            this.savedata.TabStop = false;
            this.savedata.Click += new System.EventHandler(this.savedata_Click);
            this.savedata.MouseLeave += new System.EventHandler(this.savedata_MouseLeave);
            this.savedata.MouseHover += new System.EventHandler(this.savedata_MouseHover);
            // 
            // deletelabel
            // 
            this.deletelabel.AutoSize = true;
            this.deletelabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.deletelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deletelabel.Location = new System.Drawing.Point(437, 156);
            this.deletelabel.Name = "deletelabel";
            this.deletelabel.Size = new System.Drawing.Size(164, 19);
            this.deletelabel.TabIndex = 101;
            this.deletelabel.Text = "ELIMINAR USUARIO";
            // 
            // delete
            // 
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.Image = global::DireccionLib.Properties.Resources.Actions_user_group_delete_icon;
            this.delete.Location = new System.Drawing.Point(475, 57);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(89, 88);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delete.TabIndex = 100;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            this.delete.MouseLeave += new System.EventHandler(this.delete_MouseLeave);
            this.delete.MouseHover += new System.EventHandler(this.delete_MouseHover);
            // 
            // editlabel
            // 
            this.editlabel.AutoSize = true;
            this.editlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.editlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editlabel.Location = new System.Drawing.Point(245, 156);
            this.editlabel.Name = "editlabel";
            this.editlabel.Size = new System.Drawing.Size(146, 19);
            this.editlabel.TabIndex = 99;
            this.editlabel.Text = "EDITAR USUARIO";
            // 
            // edit
            // 
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.Image = global::DireccionLib.Properties.Resources.business_users_edit;
            this.edit.Location = new System.Drawing.Point(271, 57);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(89, 88);
            this.edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edit.TabIndex = 98;
            this.edit.TabStop = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            this.edit.MouseLeave += new System.EventHandler(this.edit_MouseLeave);
            this.edit.MouseHover += new System.EventHandler(this.edit_MouseHover);
            // 
            // passlabel
            // 
            this.passlabel.AutoSize = true;
            this.passlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.passlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.passlabel.Location = new System.Drawing.Point(59, 156);
            this.passlabel.Name = "passlabel";
            this.passlabel.Size = new System.Drawing.Size(123, 19);
            this.passlabel.TabIndex = 97;
            this.passlabel.Text = "CONTRASEÑA";
            // 
            // pass
            // 
            this.pass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pass.Image = global::DireccionLib.Properties.Resources._26053;
            this.pass.Location = new System.Drawing.Point(78, 57);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(89, 88);
            this.pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pass.TabIndex = 1;
            this.pass.TabStop = false;
            this.pass.Click += new System.EventHandler(this.pass_Click);
            this.pass.MouseLeave += new System.EventHandler(this.pass_MouseLeave);
            this.pass.MouseHover += new System.EventHandler(this.pass_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 38);
            this.label9.TabIndex = 0;
            this.label9.Text = "X";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // UsersShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.opcionpanel);
            this.Controls.Add(this.findinggrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.finderpanel);
            this.Controls.Add(this.buttonpanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowUsersForm";
            this.Load += new System.EventHandler(this.UsersShowForm_Load);
            this.MouseHover += new System.EventHandler(this.UsersShowForm_MouseHover);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.finderpanel.ResumeLayout(false);
            this.finderpanel.PerformLayout();
            this.buttonpanel.ResumeLayout(false);
            this.buttonpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findinggrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.opcionpanel.ResumeLayout(false);
            this.opcionpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip;
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
        private System.Windows.Forms.Panel finderpanel;
        private System.Windows.Forms.Button editbutton;
        private System.Windows.Forms.ComboBox namebox;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.Panel buttonpanel;
        private System.Windows.Forms.Timer timera;
        private System.Windows.Forms.DataGridView findinggrid;
        private System.Windows.Forms.ComboBox tipobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label encontradoslabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel opcionpanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pass;
        private System.Windows.Forms.Label editlabel;
        private System.Windows.Forms.PictureBox edit;
        private System.Windows.Forms.Label passlabel;
        private System.Windows.Forms.Label deletelabel;
        private System.Windows.Forms.PictureBox delete;
        private System.Windows.Forms.Label savedatalabel;
        private System.Windows.Forms.PictureBox savedata;
        private System.Windows.Forms.Label cargarlabel;
        private System.Windows.Forms.PictureBox cargar;
    }
}