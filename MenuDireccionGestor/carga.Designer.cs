namespace DireccionLib
{
    partial class carga
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
            this.message = new System.Windows.Forms.Label();
            this.timecharge = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.message.ForeColor = System.Drawing.Color.White;
            this.message.Location = new System.Drawing.Point(27, 63);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(277, 56);
            this.message.TabIndex = 1;
            this.message.Text = "CARGANDO";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timecharge
            // 
            this.timecharge.Enabled = true;
            this.timecharge.Tick += new System.EventHandler(this.timecharge_Tick);
            // 
            // carga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(370, 181);
            this.Controls.Add(this.message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "carga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "carga";
            this.Load += new System.EventHandler(this.carga_Load);
            this.MouseHover += new System.EventHandler(this.carga_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Timer timecharge;
    }
}