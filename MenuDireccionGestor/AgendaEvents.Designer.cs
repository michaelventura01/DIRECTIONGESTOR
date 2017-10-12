namespace DireccionLib
{
    partial class AgendaEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendaEvents));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cuentalabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.activobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timebox = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.fechabox = new System.Windows.Forms.DateTimePicker();
            this.comboeventoname = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.control = new System.Windows.Forms.DateTimePicker();
            this.menutrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 28);
            this.label1.TabIndex = 98;
            this.label1.Text = "VISUALIZAR TAREAS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.menutrip.Location = new System.Drawing.Point(0, 471);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(577, 25);
            this.menutrip.TabIndex = 99;
            this.menutrip.Text = "toolStrip1";
            this.menutrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menutrip_ItemClicked);
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
            this.quitarbutton.Size = new System.Drawing.Size(79, 22);
            this.quitarbutton.Text = "QUITAR";
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
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(23, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(531, 311);
            this.dataGridView1.TabIndex = 102;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.MouseHover += new System.EventHandler(this.dataGridView1_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.cuentalabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.activobox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.timebox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fechabox);
            this.panel1.Controls.Add(this.comboeventoname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 117);
            this.panel1.TabIndex = 103;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // cuentalabel
            // 
            this.cuentalabel.AutoSize = true;
            this.cuentalabel.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.cuentalabel.ForeColor = System.Drawing.Color.Gold;
            this.cuentalabel.Location = new System.Drawing.Point(443, 47);
            this.cuentalabel.Name = "cuentalabel";
            this.cuentalabel.Size = new System.Drawing.Size(38, 27);
            this.cuentalabel.TabIndex = 11;
            this.cuentalabel.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(284, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "ENCONTRADOS: ";
            // 
            // activobox
            // 
            this.activobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.activobox.FormattingEnabled = true;
            this.activobox.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.activobox.Location = new System.Drawing.Point(443, 84);
            this.activobox.Name = "activobox";
            this.activobox.Size = new System.Drawing.Size(70, 24);
            this.activobox.TabIndex = 9;
            this.activobox.SelectedIndexChanged += new System.EventHandler(this.activobox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(352, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "ACTIVO: ";
            // 
            // timebox
            // 
            this.timebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.timebox.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timebox.Location = new System.Drawing.Point(158, 84);
            this.timebox.Name = "timebox";
            this.timebox.Size = new System.Drawing.Size(103, 23);
            this.timebox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(57, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "HORA: ";
            // 
            // fechabox
            // 
            this.fechabox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fechabox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechabox.Location = new System.Drawing.Point(158, 50);
            this.fechabox.Name = "fechabox";
            this.fechabox.Size = new System.Drawing.Size(103, 23);
            this.fechabox.TabIndex = 3;
            // 
            // comboeventoname
            // 
            this.comboeventoname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboeventoname.FormattingEnabled = true;
            this.comboeventoname.Location = new System.Drawing.Point(158, 15);
            this.comboeventoname.Name = "comboeventoname";
            this.comboeventoname.Size = new System.Drawing.Size(355, 24);
            this.comboeventoname.TabIndex = 2;
            this.comboeventoname.SelectedIndexChanged += new System.EventHandler(this.comboeventoname_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(57, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "FECHA: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(57, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "NOMBRE: ";
            // 
            // control
            // 
            this.control.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.control.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.control.Location = new System.Drawing.Point(288, 11);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(103, 23);
            this.control.TabIndex = 104;
            this.control.ValueChanged += new System.EventHandler(this.control_ValueChanged);
            // 
            // AgendaEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(577, 496);
            this.Controls.Add(this.control);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menutrip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgendaEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgendaEvents";
            this.Load += new System.EventHandler(this.AgendaEvents_Load);
            this.MouseHover += new System.EventHandler(this.AgendaEvents_MouseHover);
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton quitarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton5;
        private System.Windows.Forms.ToolStripButton editbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton agregarbutton;
        private System.Windows.Forms.ToolStripButton backbuttonstrip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker timebox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechabox;
        private System.Windows.Forms.ComboBox comboeventoname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buscarbutton;
        private System.Windows.Forms.ComboBox activobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripButton9;
        private System.Windows.Forms.ToolStripButton limpiarbutton;
        private System.Windows.Forms.DateTimePicker control;
        private System.Windows.Forms.Label cuentalabel;
        private System.Windows.Forms.Label label6;
    }
}