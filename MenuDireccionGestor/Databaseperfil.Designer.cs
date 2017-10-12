namespace DireccionLib
{
    partial class Databaseperfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Databaseperfil));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbserver = new System.Windows.Forms.TextBox();
            this.dbname = new System.Windows.Forms.TextBox();
            this.dbuser = new System.Windows.Forms.TextBox();
            this.dbport = new System.Windows.Forms.TextBox();
            this.dbpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.aceptbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.dbserver);
            this.panel1.Controls.Add(this.dbname);
            this.panel1.Controls.Add(this.dbuser);
            this.panel1.Controls.Add(this.dbport);
            this.panel1.Controls.Add(this.dbpassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(48, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 301);
            this.panel1.TabIndex = 1;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // dbserver
            // 
            this.dbserver.Location = new System.Drawing.Point(309, 29);
            this.dbserver.Name = "dbserver";
            this.dbserver.Size = new System.Drawing.Size(198, 20);
            this.dbserver.TabIndex = 12;
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(309, 87);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(198, 20);
            this.dbname.TabIndex = 11;
            // 
            // dbuser
            // 
            this.dbuser.Location = new System.Drawing.Point(309, 140);
            this.dbuser.Name = "dbuser";
            this.dbuser.Size = new System.Drawing.Size(198, 20);
            this.dbuser.TabIndex = 10;
            // 
            // dbport
            // 
            this.dbport.Location = new System.Drawing.Point(309, 243);
            this.dbport.Name = "dbport";
            this.dbport.Size = new System.Drawing.Size(198, 20);
            this.dbport.TabIndex = 9;
            // 
            // dbpassword
            // 
            this.dbpassword.Location = new System.Drawing.Point(309, 191);
            this.dbpassword.Name = "dbpassword";
            this.dbpassword.Size = new System.Drawing.Size(198, 20);
            this.dbpassword.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(119, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "DATABASE NAME:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(119, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "DATABASE SERVER:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(119, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "DATABASE USER:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(119, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "DATABASE PASSWORD:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(119, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "DATABASE PORT:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "PERFIL DE BASE DE DATOS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(711, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.Color.DarkRed;
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelbutton.Location = new System.Drawing.Point(170, 392);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(163, 45);
            this.cancelbutton.TabIndex = 3;
            this.cancelbutton.Text = "CANCELAR";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // aceptbutton
            // 
            this.aceptbutton.BackColor = System.Drawing.Color.Green;
            this.aceptbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.aceptbutton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aceptbutton.Location = new System.Drawing.Point(542, 392);
            this.aceptbutton.Name = "aceptbutton";
            this.aceptbutton.Size = new System.Drawing.Size(163, 45);
            this.aceptbutton.TabIndex = 4;
            this.aceptbutton.Text = "ACEPTAR";
            this.aceptbutton.UseVisualStyleBackColor = false;
            this.aceptbutton.Click += new System.EventHandler(this.aceptbutton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(357, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Databaseperfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aceptbutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Databaseperfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Databaseperfil";
            this.Load += new System.EventHandler(this.Databaseperfil_Load);
            this.MouseHover += new System.EventHandler(this.Databaseperfil_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dbserver;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.TextBox dbuser;
        private System.Windows.Forms.TextBox dbport;
        private System.Windows.Forms.TextBox dbpassword;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button aceptbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer;
    }
}