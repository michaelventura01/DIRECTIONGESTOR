namespace DireccionLib
{
    partial class ShowContacts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowContacts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cuentalabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.telefonocombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.namecombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
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
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.menutrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.cuentalabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.telefonocombo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.namecombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 444);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 85);
            this.panel1.TabIndex = 108;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // cuentalabel
            // 
            this.cuentalabel.AutoSize = true;
            this.cuentalabel.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentalabel.ForeColor = System.Drawing.Color.Red;
            this.cuentalabel.Location = new System.Drawing.Point(527, 24);
            this.cuentalabel.Name = "cuentalabel";
            this.cuentalabel.Size = new System.Drawing.Size(38, 27);
            this.cuentalabel.TabIndex = 7;
            this.cuentalabel.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(379, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "ENCONTRADOS:";
            // 
            // telefonocombo
            // 
            this.telefonocombo.FormattingEnabled = true;
            this.telefonocombo.Location = new System.Drawing.Point(141, 46);
            this.telefonocombo.Name = "telefonocombo";
            this.telefonocombo.Size = new System.Drawing.Size(219, 21);
            this.telefonocombo.TabIndex = 5;
            this.telefonocombo.SelectedIndexChanged += new System.EventHandler(this.telefonocombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(32, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "TELEFONO:";
            // 
            // namecombo
            // 
            this.namecombo.FormattingEnabled = true;
            this.namecombo.Location = new System.Drawing.Point(141, 15);
            this.namecombo.Name = "namecombo";
            this.namecombo.Size = new System.Drawing.Size(219, 21);
            this.namecombo.TabIndex = 3;
            this.namecombo.SelectedIndexChanged += new System.EventHandler(this.namecombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(32, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "NOMBRE:";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.MidnightBlue;
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
            this.dataGrid.Location = new System.Drawing.Point(23, 66);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(571, 372);
            this.dataGrid.TabIndex = 107;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            this.dataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.dataGrid.DoubleClick += new System.EventHandler(this.dataGrid_DoubleClick);
            this.dataGrid.MouseHover += new System.EventHandler(this.dataGrid_MouseHover);
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
            this.menutrip.Location = new System.Drawing.Point(0, 532);
            this.menutrip.Name = "menutrip";
            this.menutrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menutrip.Size = new System.Drawing.Size(621, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 28);
            this.label1.TabIndex = 105;
            this.label1.Text = "VISUALIZAR CONTACTOS";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(621, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.menutrip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowContacts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowContacts";
            this.Load += new System.EventHandler(this.ShowContacts_Load);
            this.MouseHover += new System.EventHandler(this.ShowContacts_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.menutrip.ResumeLayout(false);
            this.menutrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStrip menutrip;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton quitarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton5;
        private System.Windows.Forms.ToolStripButton editbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton agregarbutton;
        private System.Windows.Forms.ToolStripButton backbuttonstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buscarbutton;
        private System.Windows.Forms.ToolStripSeparator toolStripButton9;
        private System.Windows.Forms.ToolStripButton limpiarbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cuentalabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox telefonocombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox namecombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}