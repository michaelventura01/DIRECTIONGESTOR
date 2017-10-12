namespace DireccionLib
{
    partial class UserAccessForm
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
            this.label17 = new System.Windows.Forms.Label();
            this.userbox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accessbutton = new System.Windows.Forms.Button();
            this.createuserbutton = new System.Windows.Forms.Button();
            this.closebutton = new System.Windows.Forms.Button();
            this.problemuserbutton = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.TextBox();
            this.conexionpanel = new System.Windows.Forms.Panel();
            this.horalabel = new System.Windows.Forms.Label();
            this.fechalabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.conexionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(204, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 29);
            this.label17.TabIndex = 99;
            this.label17.Text = "INICIAR USUARIO";
            // 
            // userbox
            // 
            this.userbox.FormattingEnabled = true;
            this.userbox.Location = new System.Drawing.Point(343, 124);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(219, 21);
            this.userbox.TabIndex = 1;
            this.userbox.SelectedIndexChanged += new System.EventHandler(this.cargobox_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.LightGray;
            this.label19.Location = new System.Drawing.Point(206, 127);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 18);
            this.label19.TabIndex = 105;
            this.label19.Text = "USUARIO: ";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(343, 159);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '*';
            this.passwordbox.Size = new System.Drawing.Size(219, 20);
            this.passwordbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(206, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 107;
            this.label1.Text = "CONTRASEÑA: ";
            // 
            // accessbutton
            // 
            this.accessbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.accessbutton.Font = new System.Drawing.Font("Arial Black", 10.75F, System.Drawing.FontStyle.Bold);
            this.accessbutton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.accessbutton.Location = new System.Drawing.Point(421, 220);
            this.accessbutton.Name = "accessbutton";
            this.accessbutton.Size = new System.Drawing.Size(141, 51);
            this.accessbutton.TabIndex = 3;
            this.accessbutton.Text = "ACEPTAR";
            this.accessbutton.UseVisualStyleBackColor = false;
            this.accessbutton.Click += new System.EventHandler(this.accessbutton_Click);
            // 
            // createuserbutton
            // 
            this.createuserbutton.BackColor = System.Drawing.Color.Navy;
            this.createuserbutton.Font = new System.Drawing.Font("Arial Black", 10.25F, System.Drawing.FontStyle.Bold);
            this.createuserbutton.ForeColor = System.Drawing.Color.White;
            this.createuserbutton.Location = new System.Drawing.Point(252, 220);
            this.createuserbutton.Name = "createuserbutton";
            this.createuserbutton.Size = new System.Drawing.Size(141, 51);
            this.createuserbutton.TabIndex = 4;
            this.createuserbutton.Text = "CREAR USUARIO";
            this.createuserbutton.UseVisualStyleBackColor = false;
            this.createuserbutton.Click += new System.EventHandler(this.createuserbutton_Click);
            // 
            // closebutton
            // 
            this.closebutton.BackColor = System.Drawing.Color.DarkRed;
            this.closebutton.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.closebutton.ForeColor = System.Drawing.SystemColors.Control;
            this.closebutton.Location = new System.Drawing.Point(72, 220);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(141, 51);
            this.closebutton.TabIndex = 5;
            this.closebutton.Text = "SALIR";
            this.closebutton.UseVisualStyleBackColor = false;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // problemuserbutton
            // 
            this.problemuserbutton.BackColor = System.Drawing.Color.DarkRed;
            this.problemuserbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.problemuserbutton.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.problemuserbutton.ForeColor = System.Drawing.SystemColors.Control;
            this.problemuserbutton.Location = new System.Drawing.Point(-2, 0);
            this.problemuserbutton.Name = "problemuserbutton";
            this.problemuserbutton.Size = new System.Drawing.Size(630, 32);
            this.problemuserbutton.TabIndex = 112;
            this.problemuserbutton.Text = "Hay problemas con el USUARIO o la CONTRASEÑA, Modificar Usuario?";
            this.problemuserbutton.UseVisualStyleBackColor = false;
            this.problemuserbutton.Click += new System.EventHandler(this.problemuserbutton_Click);
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(55, 185);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(22, 20);
            this.picture.TabIndex = 114;
            // 
            // conexionpanel
            // 
            this.conexionpanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.conexionpanel.Controls.Add(this.horalabel);
            this.conexionpanel.Controls.Add(this.fechalabel);
            this.conexionpanel.Controls.Add(this.label2);
            this.conexionpanel.Location = new System.Drawing.Point(-10, 295);
            this.conexionpanel.Name = "conexionpanel";
            this.conexionpanel.Size = new System.Drawing.Size(647, 34);
            this.conexionpanel.TabIndex = 115;
            // 
            // horalabel
            // 
            this.horalabel.AutoSize = true;
            this.horalabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horalabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.horalabel.Location = new System.Drawing.Point(446, 5);
            this.horalabel.Name = "horalabel";
            this.horalabel.Size = new System.Drawing.Size(90, 22);
            this.horalabel.TabIndex = 2;
            this.horalabel.Text = "00:00:00";
            // 
            // fechalabel
            // 
            this.fechalabel.AutoSize = true;
            this.fechalabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechalabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fechalabel.Location = new System.Drawing.Point(269, 5);
            this.fechalabel.Name = "fechalabel";
            this.fechalabel.Size = new System.Drawing.Size(108, 22);
            this.fechalabel.TabIndex = 1;
            this.fechalabel.Text = "00/00/0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(52, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "ULTIMA CONEXION:";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DireccionLib.Properties.Resources.synchronize1600;
            this.pictureBox1.Location = new System.Drawing.Point(596, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::DireccionLib.Properties.Resources.mxcpengrane_md;
            this.pictureBox.Location = new System.Drawing.Point(54, 55);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(126, 124);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 113;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // UserAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(628, 327);
            this.Controls.Add(this.conexionpanel);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.problemuserbutton);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.createuserbutton);
            this.Controls.Add(this.accessbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.label17);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserAccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccessUserForm";
            this.Load += new System.EventHandler(this.UserAccessForm_Load);
            this.conexionpanel.ResumeLayout(false);
            this.conexionpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox userbox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button accessbutton;
        private System.Windows.Forms.Button createuserbutton;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button problemuserbutton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox picture;
        private System.Windows.Forms.Panel conexionpanel;
        private System.Windows.Forms.Label horalabel;
        private System.Windows.Forms.Label fechalabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}