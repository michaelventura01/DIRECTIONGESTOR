namespace DireccionLib
{
    partial class GastosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GastosForm));
            this.menutrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripSeparator();
            this.addbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.backbuttonstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fondoorigen = new System.Windows.Forms.ComboBox();
            this.explanationbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.monedatipo = new System.Windows.Forms.ComboBox();
            this.cuantitybox = new System.Windows.Forms.TextBox();
            this.reasonbox = new System.Windows.Forms.TextBox();
            this.horabox = new System.Windows.Forms.DateTimePicker();
            this.datebox = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titlegasto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timergasto = new System.Windows.Forms.Timer(this.components);
            this.menutrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menutrip
            // 
            this.menutrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menutrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.cleanbuttonstrip,
            this.toolStripButton6,
            this.addbuttonstrip,
            this.backbuttonstrip,
            this.toolStripSeparator1});
            this.menutrip.Location = new System.Drawing.Point(0, 438);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(451, 25);
            this.menutrip.TabIndex = 117;
            this.menutrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = global::DireccionLib.Properties.Resources.y9izE5EcE;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(92, 22);
            this.toolStripButton1.Text = "INGRESO";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(6, 25);
            // 
            // addbuttonstrip
            // 
            this.addbuttonstrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.addbuttonstrip.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.addbuttonstrip.Image = global::DireccionLib.Properties.Resources.y9izE5EcE1;
            this.addbuttonstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addbuttonstrip.Name = "addbuttonstrip";
            this.addbuttonstrip.Size = new System.Drawing.Size(97, 22);
            this.addbuttonstrip.Text = "AGREGAR";
            this.addbuttonstrip.Click += new System.EventHandler(this.addbuttonstrip_Click);
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
            // fondoorigen
            // 
            this.fondoorigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fondoorigen.FormattingEnabled = true;
            this.fondoorigen.Items.AddRange(new object[] {
            "EFECTIVO",
            "CHEQUE",
            "CUENTA DE AHORROS",
            "TARGETA DE DEBITO",
            "TARGETA DE CREDITO",
            "PRESTAMO",
            "OTRO"});
            this.fondoorigen.Location = new System.Drawing.Point(189, 270);
            this.fondoorigen.Name = "fondoorigen";
            this.fondoorigen.Size = new System.Drawing.Size(214, 21);
            this.fondoorigen.TabIndex = 130;
            // 
            // explanationbox
            // 
            this.explanationbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.explanationbox.Location = new System.Drawing.Point(39, 338);
            this.explanationbox.Multiline = true;
            this.explanationbox.Name = "explanationbox";
            this.explanationbox.Size = new System.Drawing.Size(364, 80);
            this.explanationbox.TabIndex = 128;
            this.explanationbox.TextChanged += new System.EventHandler(this.explanationbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(36, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 22);
            this.label4.TabIndex = 127;
            this.label4.Text = "DETALLES:";
            // 
            // monedatipo
            // 
            this.monedatipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monedatipo.FormattingEnabled = true;
            this.monedatipo.Items.AddRange(new object[] {
            "DOP",
            "USD",
            "EUR"});
            this.monedatipo.Location = new System.Drawing.Point(164, 224);
            this.monedatipo.Name = "monedatipo";
            this.monedatipo.Size = new System.Drawing.Size(63, 21);
            this.monedatipo.TabIndex = 126;
            // 
            // cuantitybox
            // 
            this.cuantitybox.Location = new System.Drawing.Point(233, 225);
            this.cuantitybox.Name = "cuantitybox";
            this.cuantitybox.Size = new System.Drawing.Size(170, 20);
            this.cuantitybox.TabIndex = 125;
            this.cuantitybox.TextChanged += new System.EventHandler(this.cuantitybox_TextChanged);
            // 
            // reasonbox
            // 
            this.reasonbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.reasonbox.Location = new System.Drawing.Point(164, 180);
            this.reasonbox.Name = "reasonbox";
            this.reasonbox.Size = new System.Drawing.Size(239, 20);
            this.reasonbox.TabIndex = 124;
            this.reasonbox.TextChanged += new System.EventHandler(this.reasonbox_TextChanged);
            // 
            // horabox
            // 
            this.horabox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horabox.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horabox.Location = new System.Drawing.Point(164, 133);
            this.horabox.Name = "horabox";
            this.horabox.Size = new System.Drawing.Size(150, 22);
            this.horabox.TabIndex = 123;
            // 
            // datebox
            // 
            this.datebox.Font = new System.Drawing.Font("Arial", 10F);
            this.datebox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datebox.Location = new System.Drawing.Point(164, 88);
            this.datebox.Name = "datebox";
            this.datebox.Size = new System.Drawing.Size(150, 23);
            this.datebox.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(36, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 121;
            this.label6.Text = "HORA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(36, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 120;
            this.label3.Text = "CANTIDAD:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(36, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 119;
            this.label2.Text = "MOTIVO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(36, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 118;
            this.label1.Text = "FECHA:";
            // 
            // titlegasto
            // 
            this.titlegasto.AutoSize = true;
            this.titlegasto.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.titlegasto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titlegasto.Location = new System.Drawing.Point(35, 33);
            this.titlegasto.Name = "titlegasto";
            this.titlegasto.Size = new System.Drawing.Size(238, 27);
            this.titlegasto.TabIndex = 131;
            this.titlegasto.Text = "REGISTRO DE GASTO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(35, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 19);
            this.label5.TabIndex = 132;
            this.label5.Text = "FORMA DE PAGO:";
            // 
            // timergasto
            // 
            this.timergasto.Enabled = true;
            this.timergasto.Tick += new System.EventHandler(this.timergasto_Tick);
            // 
            // GastosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(451, 463);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.titlegasto);
            this.Controls.Add(this.fondoorigen);
            this.Controls.Add(this.explanationbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.monedatipo);
            this.Controls.Add(this.cuantitybox);
            this.Controls.Add(this.reasonbox);
            this.Controls.Add(this.horabox);
            this.Controls.Add(this.datebox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menutrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GastosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GastosForm";
            this.Load += new System.EventHandler(this.GastosForm_Load);
            this.MouseHover += new System.EventHandler(this.GastosForm_MouseHover);
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.ToolStripButton cleanbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton addbuttonstrip;
        private System.Windows.Forms.ToolStripButton backbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox fondoorigen;
        private System.Windows.Forms.TextBox explanationbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox monedatipo;
        private System.Windows.Forms.TextBox cuantitybox;
        private System.Windows.Forms.TextBox reasonbox;
        private System.Windows.Forms.DateTimePicker horabox;
        private System.Windows.Forms.DateTimePicker datebox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titlegasto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timergasto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}