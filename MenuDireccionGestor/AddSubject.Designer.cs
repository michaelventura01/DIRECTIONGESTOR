namespace DireccionLib
{
    partial class AddSubject
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
            this.titlelabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboasignado = new System.Windows.Forms.ComboBox();
            this.asignaturatextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcionbox = new System.Windows.Forms.TextBox();
            this.subjectverbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titlelabel.Location = new System.Drawing.Point(46, 23);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(255, 24);
            this.titlelabel.TabIndex = 1;
            this.titlelabel.Text = "AGREGAR ASIGNATURA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.comboasignado);
            this.panel1.Controls.Add(this.asignaturatextbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.descripcionbox);
            this.panel1.Controls.Add(this.subjectverbutton);
            this.panel1.Controls.Add(this.cancelbutton);
            this.panel1.Controls.Add(this.OKbutton);
            this.panel1.Location = new System.Drawing.Point(28, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 281);
            this.panel1.TabIndex = 110;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // comboasignado
            // 
            this.comboasignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboasignado.FormattingEnabled = true;
            this.comboasignado.Location = new System.Drawing.Point(134, 71);
            this.comboasignado.Name = "comboasignado";
            this.comboasignado.Size = new System.Drawing.Size(274, 21);
            this.comboasignado.TabIndex = 109;
            // 
            // asignaturatextbox
            // 
            this.asignaturatextbox.Location = new System.Drawing.Point(134, 26);
            this.asignaturatextbox.Name = "asignaturatextbox";
            this.asignaturatextbox.Size = new System.Drawing.Size(274, 20);
            this.asignaturatextbox.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOMBRE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "ASIGNADO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(17, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "DESCRIPCION:";
            // 
            // descripcionbox
            // 
            this.descripcionbox.Location = new System.Drawing.Point(22, 140);
            this.descripcionbox.Multiline = true;
            this.descripcionbox.Name = "descripcionbox";
            this.descripcionbox.Size = new System.Drawing.Size(386, 63);
            this.descripcionbox.TabIndex = 105;
            // 
            // subjectverbutton
            // 
            this.subjectverbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.subjectverbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.subjectverbutton.Location = new System.Drawing.Point(134, 225);
            this.subjectverbutton.Name = "subjectverbutton";
            this.subjectverbutton.Size = new System.Drawing.Size(161, 33);
            this.subjectverbutton.TabIndex = 104;
            this.subjectverbutton.Text = "ASIGNATURAS";
            this.subjectverbutton.UseVisualStyleBackColor = true;
            this.subjectverbutton.Click += new System.EventHandler(this.subjectverbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelbutton.Location = new System.Drawing.Point(21, 225);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(107, 33);
            this.cancelbutton.TabIndex = 103;
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
            this.OKbutton.Location = new System.Drawing.Point(301, 225);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(107, 33);
            this.OKbutton.TabIndex = 102;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // AddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(488, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSubject";
            this.Load += new System.EventHandler(this.AddSubject_Load);
            this.MouseHover += new System.EventHandler(this.AddSubject_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcionbox;
        private System.Windows.Forms.Button subjectverbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.ComboBox comboasignado;
        private System.Windows.Forms.TextBox asignaturatextbox;
        private System.Windows.Forms.Timer timer;
    }
}