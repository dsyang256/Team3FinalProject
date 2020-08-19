namespace TEAM3POP
{
    partial class frmATLTask
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
            this.timSocket_Connect = new System.Windows.Forms.Timer(this.components);
            this.timSocket_Check = new System.Windows.Forms.Timer(this.components);
            this.timSocket_Ka = new System.Windows.Forms.Timer(this.components);
            this.txtReadATL = new System.Windows.Forms.TextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSts = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timSocket_Connect
            // 
            this.timSocket_Connect.Tick += new System.EventHandler(this.timSocket_Connect_Tick);
            // 
            // timSocket_Check
            // 
            this.timSocket_Check.Tick += new System.EventHandler(this.timSocket_Check_Tick);
            // 
            // timSocket_Ka
            // 
            this.timSocket_Ka.Tick += new System.EventHandler(this.timSocket_Ka_Tick);
            // 
            // txtReadATL
            // 
            this.txtReadATL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtReadATL.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReadATL.Location = new System.Drawing.Point(456, 19);
            this.txtReadATL.Name = "txtReadATL";
            this.txtReadATL.ReadOnly = true;
            this.txtReadATL.Size = new System.Drawing.Size(217, 26);
            this.txtReadATL.TabIndex = 50;
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 15;
            this.ListBox1.Location = new System.Drawing.Point(0, 54);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.ScrollAlwaysVisible = true;
            this.ListBox1.Size = new System.Drawing.Size(678, 0);
            this.ListBox1.TabIndex = 51;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.lblSts);
            this.GroupBox2.Controls.Add(this.lblPort);
            this.GroupBox2.Controls.Add(this.lblIP);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox2.Font = new System.Drawing.Font("Arial", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(0, 54);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(678, 42);
            this.GroupBox2.TabIndex = 49;
            this.GroupBox2.TabStop = false;
            // 
            // lblSts
            // 
            this.lblSts.AutoSize = true;
            this.lblSts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSts.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSts.Location = new System.Drawing.Point(77, 15);
            this.lblSts.Name = "lblSts";
            this.lblSts.Size = new System.Drawing.Size(15, 17);
            this.lblSts.TabIndex = 10;
            this.lblSts.Text = "  ";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.Blue;
            this.lblPort.Location = new System.Drawing.Point(634, 15);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(40, 16);
            this.lblPort.TabIndex = 9;
            this.lblPort.Text = "9999";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.Blue;
            this.lblIP.Location = new System.Drawing.Point(448, 15);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(116, 16);
            this.lblIP.TabIndex = 8;
            this.lblIP.Text = "999.999.999.999";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(569, 15);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(67, 15);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "통신 Port : ";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(397, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(54, 15);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "통신 IP : ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 15);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "통신상태 : ";
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.DimGray;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(512, 2);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(160, 16);
            this.lblVersion.TabIndex = 52;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.DimGray;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(678, 54);
            this.Label1.TabIndex = 48;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmATLTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 96);
            this.Controls.Add(this.txtReadATL);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.Label1);
            this.KeyPreview = true;
            this.Name = "frmATLTask";
            this.Text = "frmATLTask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmATLTask_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmATLTask_FormClosed);
            this.Load += new System.EventHandler(this.frmATLTask_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmATLTask_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Timer timSocket_Connect;
        internal System.Windows.Forms.Timer timSocket_Check;
        internal System.Windows.Forms.Timer timSocket_Ka;
        internal System.Windows.Forms.TextBox txtReadATL;
        public System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label lblSts;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
    }
}