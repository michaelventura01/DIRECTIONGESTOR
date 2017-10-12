namespace DireccionLib
{
    partial class userPasswordForm
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
            this.userlabel = new System.Windows.Forms.Label();
            this.seguridadlabel = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.repettextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.newpasstextbox = new System.Windows.Forms.TextBox();
            this.newlabel = new System.Windows.Forms.Label();
            this.tipolabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picturetext = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userlabel.ForeColor = System.Drawing.Color.Yellow;
            this.userlabel.Location = new System.Drawing.Point(108, 66);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(64, 19);
            this.userlabel.TabIndex = 181;
            this.userlabel.Text = "EMPTY";
            // 
            // seguridadlabel
            // 
            this.seguridadlabel.AutoSize = true;
            this.seguridadlabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seguridadlabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seguridadlabel.Location = new System.Drawing.Point(13, 15);
            this.seguridadlabel.Name = "seguridadlabel";
            this.seguridadlabel.Size = new System.Drawing.Size(237, 22);
            this.seguridadlabel.TabIndex = 180;
            this.seguridadlabel.Text = "CAMBIAR CONTRASEÑA";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(245, 150);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '*';
            this.passwordbox.Size = new System.Drawing.Size(186, 20);
            this.passwordbox.TabIndex = 179;
            this.passwordbox.Click += new System.EventHandler(this.passwordbox_Click);
            this.passwordbox.TextChanged += new System.EventHandler(this.passwordbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 178;
            this.label1.Text = "CONTRASEÑA:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(13, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 177;
            this.label11.Text = "NOMBRE:";
            // 
            // repettextbox
            // 
            this.repettextbox.Location = new System.Drawing.Point(245, 202);
            this.repettextbox.Name = "repettextbox";
            this.repettextbox.PasswordChar = '*';
            this.repettextbox.Size = new System.Drawing.Size(186, 20);
            this.repettextbox.TabIndex = 183;
            this.repettextbox.Click += new System.EventHandler(this.repettextbox_Click);
            this.repettextbox.TextChanged += new System.EventHandler(this.repettextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(33, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 18);
            this.label2.TabIndex = 182;
            this.label2.Text = "REPETIR CONTRASEÑA: ";
            // 
            // cancelbutton
            // 
            this.cancelbutton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.cancelbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelbutton.Location = new System.Drawing.Point(35, 250);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(158, 33);
            this.cancelbutton.TabIndex = 185;
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
            this.OKbutton.Location = new System.Drawing.Point(283, 250);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(148, 33);
            this.OKbutton.TabIndex = 184;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.Image = global::DireccionLib.Properties.Resources.mxcpcomputer_1331579_960_720;
            this.pictureBox.Location = new System.Drawing.Point(358, 15);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(99, 101);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 176;
            this.pictureBox.TabStop = false;
            // 
            // newpasstextbox
            // 
            this.newpasstextbox.Location = new System.Drawing.Point(245, 176);
            this.newpasstextbox.Name = "newpasstextbox";
            this.newpasstextbox.PasswordChar = '*';
            this.newpasstextbox.Size = new System.Drawing.Size(186, 20);
            this.newpasstextbox.TabIndex = 187;
            this.newpasstextbox.Click += new System.EventHandler(this.newpasstextbox_Click);
            this.newpasstextbox.TextChanged += new System.EventHandler(this.newpasstextbox_TextChanged);
            // 
            // newlabel
            // 
            this.newlabel.AutoSize = true;
            this.newlabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newlabel.Location = new System.Drawing.Point(32, 177);
            this.newlabel.Name = "newlabel";
            this.newlabel.Size = new System.Drawing.Size(168, 18);
            this.newlabel.TabIndex = 186;
            this.newlabel.Text = "NUEVA CONTRASEÑA:";
            // 
            // tipolabel
            // 
            this.tipolabel.AutoSize = true;
            this.tipolabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipolabel.ForeColor = System.Drawing.Color.Yellow;
            this.tipolabel.Location = new System.Drawing.Point(108, 94);
            this.tipolabel.Name = "tipolabel";
            this.tipolabel.Size = new System.Drawing.Size(64, 19);
            this.tipolabel.TabIndex = 189;
            this.tipolabel.Text = "EMPTY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 188;
            this.label4.Text = "EDUCACION:";
            // 
            // picturetext
            // 
            this.picturetext.Location = new System.Drawing.Point(463, 15);
            this.picturetext.Name = "picturetext";
            this.picturetext.Size = new System.Drawing.Size(8, 20);
            this.picturetext.TabIndex = 190;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // userPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(481, 307);
            this.Controls.Add(this.picturetext);
            this.Controls.Add(this.tipolabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newpasstextbox);
            this.Controls.Add(this.newlabel);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.repettextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.seguridadlabel);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "userPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "userPasswordForm";
            this.Load += new System.EventHandler(this.userPasswordForm_Load);
            this.MouseHover += new System.EventHandler(this.userPasswordForm_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label seguridadlabel;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox repettextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox newpasstextbox;
        private System.Windows.Forms.Label newlabel;
        private System.Windows.Forms.Label tipolabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox picturetext;
        private System.Windows.Forms.Timer timer1;
    }
}