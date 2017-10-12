namespace DireccionLib
{
    partial class ShowSubjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSubjects));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cuentalabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.asignaturabox = new System.Windows.Forms.ComboBox();
            this.asignadobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.menutrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.eliminarbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarbutton = new System.Windows.Forms.ToolStripButton();
            this.backbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buscarbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripSeparator();
            this.limpiarbutton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.seguridadpanel = new System.Windows.Forms.Panel();
            this.texta = new System.Windows.Forms.TextBox();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.repettextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userlabel = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.seguridadlabel = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.menutrip.SuspendLayout();
            this.seguridadpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.cuentalabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.asignaturabox);
            this.panel1.Controls.Add(this.asignadobox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 77);
            this.panel1.TabIndex = 108;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // cuentalabel
            // 
            this.cuentalabel.AutoSize = true;
            this.cuentalabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.cuentalabel.ForeColor = System.Drawing.Color.Gold;
            this.cuentalabel.Location = new System.Drawing.Point(366, 47);
            this.cuentalabel.Name = "cuentalabel";
            this.cuentalabel.Size = new System.Drawing.Size(32, 22);
            this.cuentalabel.TabIndex = 5;
            this.cuentalabel.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(221, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "RESULTADOS:";
            // 
            // asignaturabox
            // 
            this.asignaturabox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asignaturabox.FormattingEnabled = true;
            this.asignaturabox.Items.AddRange(new object[] {
            "TODOS"});
            this.asignaturabox.Location = new System.Drawing.Point(156, 13);
            this.asignaturabox.Name = "asignaturabox";
            this.asignaturabox.Size = new System.Drawing.Size(150, 21);
            this.asignaturabox.TabIndex = 3;
            this.asignaturabox.SelectedIndexChanged += new System.EventHandler(this.asignaturabox_SelectedIndexChanged);
            // 
            // asignadobox
            // 
            this.asignadobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asignadobox.FormattingEnabled = true;
            this.asignadobox.Items.AddRange(new object[] {
            "TODOS"});
            this.asignadobox.Location = new System.Drawing.Point(417, 14);
            this.asignadobox.Name = "asignadobox";
            this.asignadobox.Size = new System.Drawing.Size(175, 21);
            this.asignadobox.TabIndex = 2;
            this.asignadobox.SelectedIndexChanged += new System.EventHandler(this.asignadobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(318, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "ASIGNADO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(39, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "ASIGNATURA:";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(43, 57);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(550, 385);
            this.dataGrid.TabIndex = 107;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            this.dataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.dataGrid.MouseHover += new System.EventHandler(this.dataGrid_MouseHover);
            // 
            // menutrip
            // 
            this.menutrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menutrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.eliminarbutton,
            this.toolStripSeparator2,
            this.editbutton,
            this.toolStripButton6,
            this.agregarbutton,
            this.backbuttonstrip,
            this.toolStripSeparator1,
            this.buscarbutton,
            this.toolStripButton9,
            this.limpiarbutton});
            this.menutrip.Location = new System.Drawing.Point(0, 520);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(648, 25);
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
            // eliminarbutton
            // 
            this.eliminarbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eliminarbutton.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.eliminarbutton.Image = global::DireccionLib.Properties.Resources.mxcplatest;
            this.eliminarbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eliminarbutton.Name = "eliminarbutton";
            this.eliminarbutton.Size = new System.Drawing.Size(94, 22);
            this.eliminarbutton.Text = "ELIMINAR";
            this.eliminarbutton.Click += new System.EventHandler(this.eliminarbutton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 28);
            this.label1.TabIndex = 105;
            this.label1.Text = "ASIGNATURAS EXISTENTES";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // seguridadpanel
            // 
            this.seguridadpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.seguridadpanel.Controls.Add(this.texta);
            this.seguridadpanel.Controls.Add(this.cancelbutton);
            this.seguridadpanel.Controls.Add(this.OKbutton);
            this.seguridadpanel.Controls.Add(this.repettextbox);
            this.seguridadpanel.Controls.Add(this.label6);
            this.seguridadpanel.Controls.Add(this.userlabel);
            this.seguridadpanel.Controls.Add(this.picture);
            this.seguridadpanel.Controls.Add(this.seguridadlabel);
            this.seguridadpanel.Controls.Add(this.passwordbox);
            this.seguridadpanel.Controls.Add(this.label7);
            this.seguridadpanel.Controls.Add(this.label11);
            this.seguridadpanel.Location = new System.Drawing.Point(83, 85);
            this.seguridadpanel.Name = "seguridadpanel";
            this.seguridadpanel.Size = new System.Drawing.Size(485, 314);
            this.seguridadpanel.TabIndex = 109;
            this.seguridadpanel.MouseHover += new System.EventHandler(this.seguridadpanel_MouseHover);
            // 
            // texta
            // 
            this.texta.Location = new System.Drawing.Point(367, 10);
            this.texta.Name = "texta";
            this.texta.Size = new System.Drawing.Size(10, 20);
            this.texta.TabIndex = 202;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelbutton.Location = new System.Drawing.Point(44, 247);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(158, 33);
            this.cancelbutton.TabIndex = 199;
            this.cancelbutton.Text = "CANCEL";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OKbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OKbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKbutton.Location = new System.Drawing.Point(292, 247);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(148, 33);
            this.OKbutton.TabIndex = 198;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // repettextbox
            // 
            this.repettextbox.Location = new System.Drawing.Point(253, 199);
            this.repettextbox.Name = "repettextbox";
            this.repettextbox.PasswordChar = '*';
            this.repettextbox.Size = new System.Drawing.Size(186, 20);
            this.repettextbox.TabIndex = 197;
            this.repettextbox.Click += new System.EventHandler(this.repettextbox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(41, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 18);
            this.label6.TabIndex = 196;
            this.label6.Text = "REPETIR CONTRASEÑA: ";
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userlabel.ForeColor = System.Drawing.Color.Yellow;
            this.userlabel.Location = new System.Drawing.Point(118, 85);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(64, 19);
            this.userlabel.TabIndex = 195;
            this.userlabel.Text = "EMPTY";
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picture.Image = global::DireccionLib.Properties.Resources.mxcpcomputer_1331579_960_720;
            this.picture.Location = new System.Drawing.Point(366, 30);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(99, 101);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 190;
            this.picture.TabStop = false;
            // 
            // seguridadlabel
            // 
            this.seguridadlabel.AutoSize = true;
            this.seguridadlabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seguridadlabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seguridadlabel.Location = new System.Drawing.Point(22, 30);
            this.seguridadlabel.Name = "seguridadlabel";
            this.seguridadlabel.Size = new System.Drawing.Size(123, 22);
            this.seguridadlabel.TabIndex = 194;
            this.seguridadlabel.Text = "SEGURIDAD";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(254, 152);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '*';
            this.passwordbox.Size = new System.Drawing.Size(186, 20);
            this.passwordbox.TabIndex = 193;
            this.passwordbox.Click += new System.EventHandler(this.passwordbox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(41, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 192;
            this.label7.Text = "CONTRASEÑA:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(23, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 191;
            this.label11.Text = "USUARIO:";
            // 
            // ShowSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(648, 545);
            this.Controls.Add(this.seguridadpanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.menutrip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowSubjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowSubjects";
            this.Load += new System.EventHandler(this.ShowSubjects_Load);
            this.MouseHover += new System.EventHandler(this.ShowSubjects_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            this.seguridadpanel.ResumeLayout(false);
            this.seguridadpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton editbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton agregarbutton;
        private System.Windows.Forms.ToolStripButton backbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buscarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton9;
        private System.Windows.Forms.ToolStripButton limpiarbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox asignaturabox;
        private System.Windows.Forms.ComboBox asignadobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cuentalabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripButton eliminarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel seguridadpanel;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox repettextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label seguridadlabel;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox texta;
    }
}