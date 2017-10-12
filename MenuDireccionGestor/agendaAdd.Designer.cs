namespace DireccionLib
{
    partial class agendaAdd
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
            this.cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.timeBox = new System.Windows.Forms.DateTimePicker();
            this.datebox = new System.Windows.Forms.DateTimePicker();
            this.motivoBox = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.ComboBox();
            this.titlelabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tareasverbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.activobox = new System.Windows.Forms.ComboBox();
            this.labelactivo = new System.Windows.Forms.Label();
            this.paneldias = new System.Windows.Forms.Panel();
            this.domingocheckBox = new System.Windows.Forms.CheckBox();
            this.sabadocheckBox = new System.Windows.Forms.CheckBox();
            this.viernescheckbox = new System.Windows.Forms.CheckBox();
            this.juevescheckBox = new System.Windows.Forms.CheckBox();
            this.miercolescheckBox = new System.Windows.Forms.CheckBox();
            this.martescheckBox = new System.Windows.Forms.CheckBox();
            this.lunescheck = new System.Windows.Forms.CheckBox();
            this.comborepeticion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.melodypanel = new System.Windows.Forms.Panel();
            this.stopmusic = new System.Windows.Forms.PictureBox();
            this.playmusic = new System.Windows.Forms.PictureBox();
            this.addbuton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.melodybox = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.paneldias.SuspendLayout();
            this.melodypanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopmusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playmusic)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelbutton.Location = new System.Drawing.Point(28, 392);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(107, 33);
            this.cancelbutton.TabIndex = 19;
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
            this.OKbutton.Location = new System.Drawing.Point(282, 392);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(107, 33);
            this.OKbutton.TabIndex = 18;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // timeBox
            // 
            this.timeBox.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeBox.Location = new System.Drawing.Point(193, 204);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(234, 20);
            this.timeBox.TabIndex = 17;
            // 
            // datebox
            // 
            this.datebox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datebox.Location = new System.Drawing.Point(193, 170);
            this.datebox.Name = "datebox";
            this.datebox.Size = new System.Drawing.Size(234, 20);
            this.datebox.TabIndex = 16;
            // 
            // motivoBox
            // 
            this.motivoBox.Location = new System.Drawing.Point(193, 74);
            this.motivoBox.Name = "motivoBox";
            this.motivoBox.Size = new System.Drawing.Size(234, 20);
            this.motivoBox.TabIndex = 15;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl.Location = new System.Drawing.Point(20, 22);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(73, 19);
            this.lbl.TabIndex = 14;
            this.lbl.Text = "TITULO:";
            // 
            // priority
            // 
            this.priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priority.FormattingEnabled = true;
            this.priority.Items.AddRange(new object[] {
            "MUY IMPORTANTE",
            "NORMAL",
            "POCO IMPORTANTE"});
            this.priority.Location = new System.Drawing.Point(193, 137);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(234, 21);
            this.priority.TabIndex = 96;
            this.priority.SelectedIndexChanged += new System.EventHandler(this.importancy_SelectedIndexChanged);
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Arial Black", 14.75F, System.Drawing.FontStyle.Bold);
            this.titlelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titlelabel.Location = new System.Drawing.Point(25, 22);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(220, 28);
            this.titlelabel.TabIndex = 97;
            this.titlelabel.Text = "AGREGAR TAREAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(20, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 98;
            this.label2.Text = "PRIORIDAD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(20, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 99;
            this.label3.Text = "FECHA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(20, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 100;
            this.label4.Text = "HORA:";
            // 
            // tareasverbutton
            // 
            this.tareasverbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.tareasverbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tareasverbutton.Location = new System.Drawing.Point(155, 392);
            this.tareasverbutton.Name = "tareasverbutton";
            this.tareasverbutton.Size = new System.Drawing.Size(107, 33);
            this.tareasverbutton.TabIndex = 101;
            this.tareasverbutton.Text = "TAREAS";
            this.tareasverbutton.UseVisualStyleBackColor = true;
            this.tareasverbutton.Click += new System.EventHandler(this.tareasverbutton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.activobox);
            this.panel1.Controls.Add(this.labelactivo);
            this.panel1.Controls.Add(this.tareasverbutton);
            this.panel1.Controls.Add(this.paneldias);
            this.panel1.Controls.Add(this.comborepeticion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.OKbutton);
            this.panel1.Controls.Add(this.cancelbutton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(30, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 442);
            this.panel1.TabIndex = 102;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // activobox
            // 
            this.activobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activobox.FormattingEnabled = true;
            this.activobox.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.activobox.Location = new System.Drawing.Point(213, 189);
            this.activobox.Name = "activobox";
            this.activobox.Size = new System.Drawing.Size(81, 21);
            this.activobox.TabIndex = 103;
            this.activobox.SelectedIndexChanged += new System.EventHandler(this.activobox_SelectedIndexChanged);
            // 
            // labelactivo
            // 
            this.labelactivo.AutoSize = true;
            this.labelactivo.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelactivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelactivo.Location = new System.Drawing.Point(108, 185);
            this.labelactivo.Name = "labelactivo";
            this.labelactivo.Size = new System.Drawing.Size(99, 27);
            this.labelactivo.TabIndex = 105;
            this.labelactivo.Text = "ACTIVO:";
            // 
            // paneldias
            // 
            this.paneldias.BackColor = System.Drawing.Color.BlueViolet;
            this.paneldias.Controls.Add(this.domingocheckBox);
            this.paneldias.Controls.Add(this.sabadocheckBox);
            this.paneldias.Controls.Add(this.viernescheckbox);
            this.paneldias.Controls.Add(this.juevescheckBox);
            this.paneldias.Controls.Add(this.miercolescheckBox);
            this.paneldias.Controls.Add(this.martescheckBox);
            this.paneldias.Controls.Add(this.lunescheck);
            this.paneldias.Location = new System.Drawing.Point(0, 219);
            this.paneldias.Name = "paneldias";
            this.paneldias.Size = new System.Drawing.Size(416, 76);
            this.paneldias.TabIndex = 104;
            this.paneldias.Paint += new System.Windows.Forms.PaintEventHandler(this.paneldias_Paint);
            // 
            // domingocheckBox
            // 
            this.domingocheckBox.AutoSize = true;
            this.domingocheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domingocheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.domingocheckBox.Location = new System.Drawing.Point(207, 46);
            this.domingocheckBox.Name = "domingocheckBox";
            this.domingocheckBox.Size = new System.Drawing.Size(90, 20);
            this.domingocheckBox.TabIndex = 6;
            this.domingocheckBox.Text = "DOMINGO";
            this.domingocheckBox.UseVisualStyleBackColor = true;
            this.domingocheckBox.CheckedChanged += new System.EventHandler(this.domingocheckBox_CheckedChanged);
            // 
            // sabadocheckBox
            // 
            this.sabadocheckBox.AutoSize = true;
            this.sabadocheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sabadocheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sabadocheckBox.Location = new System.Drawing.Point(110, 46);
            this.sabadocheckBox.Name = "sabadocheckBox";
            this.sabadocheckBox.Size = new System.Drawing.Size(82, 20);
            this.sabadocheckBox.TabIndex = 5;
            this.sabadocheckBox.Text = "SABADO";
            this.sabadocheckBox.UseVisualStyleBackColor = true;
            this.sabadocheckBox.CheckedChanged += new System.EventHandler(this.sabadocheckBox_CheckedChanged);
            // 
            // viernescheckbox
            // 
            this.viernescheckbox.AutoSize = true;
            this.viernescheckbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viernescheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.viernescheckbox.Location = new System.Drawing.Point(24, 46);
            this.viernescheckbox.Name = "viernescheckbox";
            this.viernescheckbox.Size = new System.Drawing.Size(83, 20);
            this.viernescheckbox.TabIndex = 4;
            this.viernescheckbox.Text = "VIERNES";
            this.viernescheckbox.UseVisualStyleBackColor = true;
            this.viernescheckbox.CheckedChanged += new System.EventHandler(this.viernescheckbox_CheckedChanged);
            // 
            // juevescheckBox
            // 
            this.juevescheckBox.AutoSize = true;
            this.juevescheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.juevescheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.juevescheckBox.Location = new System.Drawing.Point(323, 14);
            this.juevescheckBox.Name = "juevescheckBox";
            this.juevescheckBox.Size = new System.Drawing.Size(77, 20);
            this.juevescheckBox.TabIndex = 3;
            this.juevescheckBox.Text = "JUEVES";
            this.juevescheckBox.UseVisualStyleBackColor = true;
            this.juevescheckBox.CheckedChanged += new System.EventHandler(this.juevescheckBox_CheckedChanged);
            // 
            // miercolescheckBox
            // 
            this.miercolescheckBox.AutoSize = true;
            this.miercolescheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miercolescheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.miercolescheckBox.Location = new System.Drawing.Point(207, 14);
            this.miercolescheckBox.Name = "miercolescheckBox";
            this.miercolescheckBox.Size = new System.Drawing.Size(103, 20);
            this.miercolescheckBox.TabIndex = 2;
            this.miercolescheckBox.Text = "MIERCOLES";
            this.miercolescheckBox.UseVisualStyleBackColor = true;
            this.miercolescheckBox.CheckedChanged += new System.EventHandler(this.miercolescheckBox_CheckedChanged);
            // 
            // martescheckBox
            // 
            this.martescheckBox.AutoSize = true;
            this.martescheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.martescheckBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.martescheckBox.Location = new System.Drawing.Point(110, 14);
            this.martescheckBox.Name = "martescheckBox";
            this.martescheckBox.Size = new System.Drawing.Size(81, 20);
            this.martescheckBox.TabIndex = 1;
            this.martescheckBox.Text = "MARTES";
            this.martescheckBox.UseVisualStyleBackColor = true;
            this.martescheckBox.CheckedChanged += new System.EventHandler(this.martescheckBox_CheckedChanged);
            // 
            // lunescheck
            // 
            this.lunescheck.AutoSize = true;
            this.lunescheck.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lunescheck.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lunescheck.Location = new System.Drawing.Point(24, 14);
            this.lunescheck.Name = "lunescheck";
            this.lunescheck.Size = new System.Drawing.Size(70, 20);
            this.lunescheck.TabIndex = 0;
            this.lunescheck.Text = "LUNES";
            this.lunescheck.UseVisualStyleBackColor = true;
            this.lunescheck.CheckedChanged += new System.EventHandler(this.lunescheck_CheckedChanged);
            // 
            // comborepeticion
            // 
            this.comborepeticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comborepeticion.FormattingEnabled = true;
            this.comborepeticion.Items.AddRange(new object[] {
            "NO",
            "ELEGIR",
            "DIARIO",
            "TODOS LOS DIAS"});
            this.comborepeticion.Location = new System.Drawing.Point(163, 52);
            this.comborepeticion.Name = "comborepeticion";
            this.comborepeticion.Size = new System.Drawing.Size(234, 21);
            this.comborepeticion.TabIndex = 103;
            this.comborepeticion.SelectedIndexChanged += new System.EventHandler(this.comborepeticion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(20, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 101;
            this.label5.Text = "REPETIR:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // melodypanel
            // 
            this.melodypanel.BackColor = System.Drawing.Color.DarkBlue;
            this.melodypanel.Controls.Add(this.stopmusic);
            this.melodypanel.Controls.Add(this.playmusic);
            this.melodypanel.Controls.Add(this.addbuton);
            this.melodypanel.Controls.Add(this.label1);
            this.melodypanel.Controls.Add(this.melodybox);
            this.melodypanel.Location = new System.Drawing.Point(30, 354);
            this.melodypanel.Name = "melodypanel";
            this.melodypanel.Size = new System.Drawing.Size(416, 76);
            this.melodypanel.TabIndex = 105;
            // 
            // stopmusic
            // 
            this.stopmusic.BackColor = System.Drawing.Color.DarkBlue;
            this.stopmusic.Image = global::DireccionLib.Properties.Resources.stop_flat;
            this.stopmusic.Location = new System.Drawing.Point(357, 16);
            this.stopmusic.Name = "stopmusic";
            this.stopmusic.Size = new System.Drawing.Size(39, 42);
            this.stopmusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopmusic.TabIndex = 128;
            this.stopmusic.TabStop = false;
            this.stopmusic.Click += new System.EventHandler(this.stopmusic_Click);
            // 
            // playmusic
            // 
            this.playmusic.BackColor = System.Drawing.Color.DarkBlue;
            this.playmusic.Image = global::DireccionLib.Properties.Resources.Play_groen;
            this.playmusic.Location = new System.Drawing.Point(357, 16);
            this.playmusic.Name = "playmusic";
            this.playmusic.Size = new System.Drawing.Size(39, 42);
            this.playmusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playmusic.TabIndex = 127;
            this.playmusic.TabStop = false;
            this.playmusic.Click += new System.EventHandler(this.playmusic_Click);
            // 
            // addbuton
            // 
            this.addbuton.BackColor = System.Drawing.Color.Green;
            this.addbuton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbuton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addbuton.Location = new System.Drawing.Point(243, 14);
            this.addbuton.Name = "addbuton";
            this.addbuton.Size = new System.Drawing.Size(103, 47);
            this.addbuton.TabIndex = 126;
            this.addbuton.Text = "AGREGAR";
            this.addbuton.UseVisualStyleBackColor = false;
            this.addbuton.Click += new System.EventHandler(this.addbuton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 106;
            this.label1.Text = "MELODIA:";
            // 
            // melodybox
            // 
            this.melodybox.FormattingEnabled = true;
            this.melodybox.Location = new System.Drawing.Point(24, 37);
            this.melodybox.Name = "melodybox";
            this.melodybox.Size = new System.Drawing.Size(203, 21);
            this.melodybox.TabIndex = 0;
            this.melodybox.SelectedIndexChanged += new System.EventHandler(this.melodybox_SelectedIndexChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // agendaAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(480, 516);
            this.Controls.Add(this.melodypanel);
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.datebox);
            this.Controls.Add(this.motivoBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "agendaAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "agendaAdd";
            this.Load += new System.EventHandler(this.agendaAdd_Load);
            this.MouseHover += new System.EventHandler(this.agendaAdd_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.paneldias.ResumeLayout(false);
            this.paneldias.PerformLayout();
            this.melodypanel.ResumeLayout(false);
            this.melodypanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopmusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playmusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.DateTimePicker timeBox;
        private System.Windows.Forms.DateTimePicker datebox;
        private System.Windows.Forms.TextBox motivoBox;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox priority;
        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tareasverbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comborepeticion;
        private System.Windows.Forms.Panel paneldias;
        private System.Windows.Forms.CheckBox domingocheckBox;
        private System.Windows.Forms.CheckBox sabadocheckBox;
        private System.Windows.Forms.CheckBox viernescheckbox;
        private System.Windows.Forms.CheckBox juevescheckBox;
        private System.Windows.Forms.CheckBox miercolescheckBox;
        private System.Windows.Forms.CheckBox martescheckBox;
        private System.Windows.Forms.CheckBox lunescheck;
        private System.Windows.Forms.ComboBox activobox;
        private System.Windows.Forms.Label labelactivo;
        private System.Windows.Forms.Panel melodypanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox melodybox;
        private System.Windows.Forms.Button addbuton;
        private System.Windows.Forms.PictureBox playmusic;
        private System.Windows.Forms.PictureBox stopmusic;
        private System.Windows.Forms.Timer timer;
    }
}