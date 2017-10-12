namespace DireccionLib
{
    partial class PendientesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendientesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalalbel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.encontradolabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cantidadbox = new System.Windows.Forms.TextBox();
            this.tipobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fechabox = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.namecombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.menutrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.quitarbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripSeparator();
            this.editbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarbutton = new System.Windows.Forms.ToolStripButton();
            this.backbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripSeparator();
            this.limpiarbutton = new System.Windows.Forms.ToolStripButton();
            this.titlelabel = new System.Windows.Forms.Label();
            this.panelpad = new System.Windows.Forms.Panel();
            this.OKbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.titlepanel = new System.Windows.Forms.Label();
            this.palpad = new System.Windows.Forms.Panel();
            this.changelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.menutrip.SuspendLayout();
            this.panelpad.SuspendLayout();
            this.palpad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.totalalbel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.encontradolabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cantidadbox);
            this.panel1.Controls.Add(this.tipobox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.fechabox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.namecombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 111);
            this.panel1.TabIndex = 108;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // totalalbel
            // 
            this.totalalbel.AutoSize = true;
            this.totalalbel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalalbel.ForeColor = System.Drawing.Color.Red;
            this.totalalbel.Location = new System.Drawing.Point(526, 84);
            this.totalalbel.Name = "totalalbel";
            this.totalalbel.Size = new System.Drawing.Size(32, 22);
            this.totalalbel.TabIndex = 10;
            this.totalalbel.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label9.Location = new System.Drawing.Point(416, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "TOTAL:";
            // 
            // encontradolabel
            // 
            this.encontradolabel.AutoSize = true;
            this.encontradolabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encontradolabel.ForeColor = System.Drawing.Color.Blue;
            this.encontradolabel.Location = new System.Drawing.Point(564, 57);
            this.encontradolabel.Name = "encontradolabel";
            this.encontradolabel.Size = new System.Drawing.Size(32, 22);
            this.encontradolabel.TabIndex = 8;
            this.encontradolabel.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label4.Location = new System.Drawing.Point(416, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "ENCONTRADOS:";
            // 
            // cantidadbox
            // 
            this.cantidadbox.Location = new System.Drawing.Point(207, 54);
            this.cantidadbox.Name = "cantidadbox";
            this.cantidadbox.Size = new System.Drawing.Size(141, 20);
            this.cantidadbox.TabIndex = 6;
            // 
            // tipobox
            // 
            this.tipobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipobox.FormattingEnabled = true;
            this.tipobox.Items.AddRange(new object[] {
            "DOP",
            "USD",
            "EUR"});
            this.tipobox.Location = new System.Drawing.Point(140, 54);
            this.tipobox.Name = "tipobox";
            this.tipobox.Size = new System.Drawing.Size(61, 21);
            this.tipobox.TabIndex = 5;
            this.tipobox.SelectedIndexChanged += new System.EventHandler(this.tipobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(35, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "CANTIDAD:";
            // 
            // fechabox
            // 
            this.fechabox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechabox.Location = new System.Drawing.Point(494, 23);
            this.fechabox.Name = "fechabox";
            this.fechabox.Size = new System.Drawing.Size(127, 20);
            this.fechabox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(417, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "FECHA:";
            // 
            // namecombo
            // 
            this.namecombo.FormattingEnabled = true;
            this.namecombo.Location = new System.Drawing.Point(140, 22);
            this.namecombo.Name = "namecombo";
            this.namecombo.Size = new System.Drawing.Size(244, 21);
            this.namecombo.TabIndex = 1;
            this.namecombo.SelectedIndexChanged += new System.EventHandler(this.namecombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE:";
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid.Location = new System.Drawing.Point(23, 52);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(635, 373);
            this.datagrid.TabIndex = 107;
            this.datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellContentClick);
            this.datagrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellContentDoubleClick);
            this.datagrid.MouseHover += new System.EventHandler(this.datagrid_MouseHover);
            // 
            // menutrip
            // 
            this.menutrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menutrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.quitarbutton,
            this.toolStripButton5,
            this.editbutton,
            this.toolStripButton6,
            this.agregarbutton,
            this.backbuttonstrip,
            this.toolStripSeparator1,
            this.buscarbutton,
            this.toolStripButton9,
            this.limpiarbutton});
            this.menutrip.Location = new System.Drawing.Point(0, 541);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(681, 25);
            this.menutrip.TabIndex = 106;
            this.menutrip.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // quitarbutton
            // 
            this.quitarbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.quitarbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.quitarbutton.Image = global::DireccionLib.Properties.Resources.minus;
            this.quitarbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitarbutton.Name = "quitarbutton";
            this.quitarbutton.Size = new System.Drawing.Size(80, 22);
            this.quitarbutton.Text = "SALDAR";
            this.quitarbutton.Click += new System.EventHandler(this.quitarbutton_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(6, 25);
            // 
            // editbutton
            // 
            this.editbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.editbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.editbutton.Image = global::DireccionLib.Properties.Resources.mxcpPencil_icon;
            this.editbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(77, 22);
            this.editbutton.Text = "EDITAR";
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(6, 25);
            // 
            // agregarbutton
            // 
            this.agregarbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.agregarbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.agregarbutton.Image = global::DireccionLib.Properties.Resources.y9izE5EcE1;
            this.agregarbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.agregarbutton.Name = "agregarbutton";
            this.agregarbutton.Size = new System.Drawing.Size(93, 22);
            this.agregarbutton.Text = "AGREGAR";
            this.agregarbutton.Click += new System.EventHandler(this.agregarbutton_Click);
            // 
            // backbuttonstrip
            // 
            this.backbuttonstrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.backbuttonstrip.Image = ((System.Drawing.Image)(resources.GetObject("backbuttonstrip.Image")));
            this.backbuttonstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backbuttonstrip.Name = "backbuttonstrip";
            this.backbuttonstrip.Size = new System.Drawing.Size(72, 22);
            this.backbuttonstrip.Text = "ATRAS";
            this.backbuttonstrip.Click += new System.EventHandler(this.backbuttonstrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buscarbutton
            // 
            this.buscarbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buscarbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.buscarbutton.Image = global::DireccionLib.Properties.Resources.mxcpjpeg;
            this.buscarbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buscarbutton.Name = "buscarbutton";
            this.buscarbutton.Size = new System.Drawing.Size(83, 22);
            this.buscarbutton.Text = "BUSCAR";
            this.buscarbutton.Click += new System.EventHandler(this.buscarbutton_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(6, 25);
            // 
            // limpiarbutton
            // 
            this.limpiarbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.limpiarbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.limpiarbutton.Image = global::DireccionLib.Properties.Resources.mxcperaser_blue_512;
            this.limpiarbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.limpiarbutton.Name = "limpiarbutton";
            this.limpiarbutton.Size = new System.Drawing.Size(84, 22);
            this.limpiarbutton.Text = "LIMPIAR";
            this.limpiarbutton.Click += new System.EventHandler(this.limpiarbutton_Click);
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Arial Black", 14.75F, System.Drawing.FontStyle.Bold);
            this.titlelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titlelabel.Location = new System.Drawing.Point(18, 21);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(262, 28);
            this.titlelabel.TabIndex = 105;
            this.titlelabel.Text = "LISTA DE PENDIENTES";
            // 
            // panelpad
            // 
            this.panelpad.BackColor = System.Drawing.Color.DarkRed;
            this.panelpad.Controls.Add(this.OKbutton);
            this.panelpad.Controls.Add(this.cancelbutton);
            this.panelpad.Controls.Add(this.fecha);
            this.panelpad.Controls.Add(this.label8);
            this.panelpad.Controls.Add(this.tipo);
            this.panelpad.Controls.Add(this.monto);
            this.panelpad.Controls.Add(this.label7);
            this.panelpad.Controls.Add(this.name);
            this.panelpad.Controls.Add(this.label5);
            this.panelpad.Controls.Add(this.titlepanel);
            this.panelpad.Location = new System.Drawing.Point(75, 81);
            this.panelpad.Name = "panelpad";
            this.panelpad.Size = new System.Drawing.Size(522, 241);
            this.panelpad.TabIndex = 109;
            this.panelpad.Paint += new System.Windows.Forms.PaintEventHandler(this.panelpad_Paint);
            this.panelpad.MouseHover += new System.EventHandler(this.panelpad_MouseHover);
            // 
            // OKbutton
            // 
            this.OKbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OKbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbutton.ForeColor = System.Drawing.Color.ForestGreen;
            this.OKbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKbutton.Location = new System.Drawing.Point(321, 184);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(121, 33);
            this.OKbutton.TabIndex = 115;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.Color.Red;
            this.cancelbutton.Location = new System.Drawing.Point(84, 184);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(122, 33);
            this.cancelbutton.TabIndex = 116;
            this.cancelbutton.Text = "CANCEL";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(116, 130);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(98, 20);
            this.fecha.TabIndex = 114;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(39, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 19);
            this.label8.TabIndex = 113;
            this.label8.Text = "FECHA:";
            // 
            // tipo
            // 
            this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo.FormattingEnabled = true;
            this.tipo.Items.AddRange(new object[] {
            "DOP",
            "USD",
            "EUR"});
            this.tipo.Location = new System.Drawing.Point(321, 130);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(52, 21);
            this.tipo.TabIndex = 112;
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(379, 130);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(104, 20);
            this.monto.TabIndex = 111;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(241, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 110;
            this.label7.Text = "MONTO:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(132, 79);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(351, 20);
            this.name.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(39, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 107;
            this.label5.Text = "NOMBRE:";
            // 
            // titlepanel
            // 
            this.titlepanel.AutoSize = true;
            this.titlepanel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.titlepanel.ForeColor = System.Drawing.SystemColors.Control;
            this.titlepanel.Location = new System.Drawing.Point(39, 23);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(96, 23);
            this.titlepanel.TabIndex = 106;
            this.titlepanel.Text = "AGREGAR";
            // 
            // palpad
            // 
            this.palpad.BackColor = System.Drawing.Color.DarkRed;
            this.palpad.Controls.Add(this.changelabel);
            this.palpad.Location = new System.Drawing.Point(421, 2);
            this.palpad.Name = "palpad";
            this.palpad.Size = new System.Drawing.Size(260, 47);
            this.palpad.TabIndex = 110;
            this.palpad.Click += new System.EventHandler(this.palpad_Click);
            this.palpad.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.palpad.MouseHover += new System.EventHandler(this.palpad_MouseHover);
            // 
            // changelabel
            // 
            this.changelabel.AutoSize = true;
            this.changelabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changelabel.Location = new System.Drawing.Point(18, 14);
            this.changelabel.Name = "changelabel";
            this.changelabel.Size = new System.Drawing.Size(87, 19);
            this.changelabel.TabIndex = 108;
            this.changelabel.Text = "CUENTAS";
            this.changelabel.Click += new System.EventHandler(this.changelabel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PendientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(681, 566);
            this.Controls.Add(this.palpad);
            this.Controls.Add(this.panelpad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.menutrip);
            this.Controls.Add(this.titlelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PendientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PendientesForm";
            this.Load += new System.EventHandler(this.PendientesForm_Load);
            this.MouseHover += new System.EventHandler(this.PendientesForm_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            this.panelpad.ResumeLayout(false);
            this.panelpad.PerformLayout();
            this.palpad.ResumeLayout(false);
            this.palpad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton quitarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton5;
        private System.Windows.Forms.ToolStripButton editbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton agregarbutton;
        private System.Windows.Forms.ToolStripButton backbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buscarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton9;
        private System.Windows.Forms.ToolStripButton limpiarbutton;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label encontradolabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cantidadbox;
        private System.Windows.Forms.ComboBox tipobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechabox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox namecombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelpad;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label titlepanel;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox tipo;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label totalalbel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel palpad;
        private System.Windows.Forms.Label changelabel;
        private System.Windows.Forms.Timer timer1;
    }
}