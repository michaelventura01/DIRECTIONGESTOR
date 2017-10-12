namespace DireccionLib
{
    partial class addContact
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contactsverbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.direccionbox = new System.Windows.Forms.TextBox();
            this.emailbox = new System.Windows.Forms.TextBox();
            this.telefonobox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nombrebox = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titlelabel.Location = new System.Drawing.Point(49, 33);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(237, 24);
            this.titlelabel.TabIndex = 0;
            this.titlelabel.Text = "AGREGAR CONTACTO";
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
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "TELEFONO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(17, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "DIRECCION:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(17, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "EMAIL:";
            // 
            // contactsverbutton
            // 
            this.contactsverbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.contactsverbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.contactsverbutton.Location = new System.Drawing.Point(152, 213);
            this.contactsverbutton.Name = "contactsverbutton";
            this.contactsverbutton.Size = new System.Drawing.Size(129, 33);
            this.contactsverbutton.TabIndex = 104;
            this.contactsverbutton.Text = "CONTACTOS";
            this.contactsverbutton.UseVisualStyleBackColor = true;
            this.contactsverbutton.Click += new System.EventHandler(this.contactsverbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OKbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OKbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKbutton.Location = new System.Drawing.Point(287, 213);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(121, 33);
            this.OKbutton.TabIndex = 102;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelbutton.Location = new System.Drawing.Point(21, 213);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(121, 33);
            this.cancelbutton.TabIndex = 103;
            this.cancelbutton.Text = "CANCEL";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // direccionbox
            // 
            this.direccionbox.Location = new System.Drawing.Point(139, 117);
            this.direccionbox.Name = "direccionbox";
            this.direccionbox.Size = new System.Drawing.Size(269, 20);
            this.direccionbox.TabIndex = 105;
            this.direccionbox.Click += new System.EventHandler(this.direccionbox_Click);
            // 
            // emailbox
            // 
            this.emailbox.Location = new System.Drawing.Point(139, 166);
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(269, 20);
            this.emailbox.TabIndex = 106;
            this.emailbox.Click += new System.EventHandler(this.emailbox_Click);
            // 
            // telefonobox
            // 
            this.telefonobox.Location = new System.Drawing.Point(139, 72);
            this.telefonobox.Name = "telefonobox";
            this.telefonobox.Size = new System.Drawing.Size(269, 20);
            this.telefonobox.TabIndex = 107;
            this.telefonobox.Click += new System.EventHandler(this.telefonobox_Click);
            this.telefonobox.TextChanged += new System.EventHandler(this.telefonobox_TextChanged);
            this.telefonobox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefonobox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel1.Controls.Add(this.nombrebox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.telefonobox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.emailbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.direccionbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.contactsverbutton);
            this.panel1.Controls.Add(this.cancelbutton);
            this.panel1.Controls.Add(this.OKbutton);
            this.panel1.Location = new System.Drawing.Point(32, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 266);
            this.panel1.TabIndex = 109;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // nombrebox
            // 
            this.nombrebox.Location = new System.Drawing.Point(139, 26);
            this.nombrebox.Name = "nombrebox";
            this.nombrebox.Size = new System.Drawing.Size(269, 20);
            this.nombrebox.TabIndex = 108;
            this.nombrebox.Click += new System.EventHandler(this.nombrebox_Click);
            this.nombrebox.TextChanged += new System.EventHandler(this.nombrebox_TextChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // addContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(497, 359);
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.addContact_Load);
            this.Click += new System.EventHandler(this.addContact_Click);
            this.MouseHover += new System.EventHandler(this.addContact_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button contactsverbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.TextBox direccionbox;
        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.TextBox telefonobox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nombrebox;
        private System.Windows.Forms.Timer timer;
    }
}