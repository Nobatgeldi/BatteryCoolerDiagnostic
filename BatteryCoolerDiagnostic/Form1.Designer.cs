
namespace BatteryCoolerDiagnostic
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_connect = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectionProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_connect.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connect.ForeColor = System.Drawing.Color.White;
            this.btn_connect.Location = new System.Drawing.Point(12, 15);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(177, 50);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "CONNECT";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.CONNECT_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(198, 15);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(176, 50);
            this.txtInfo.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionProgressBar,
            this.connectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 78);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(386, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectionProgressBar
            // 
            this.connectionProgressBar.Name = "connectionProgressBar";
            this.connectionProgressBar.Size = new System.Drawing.Size(300, 20);
            // 
            // connectionStatus
            // 
            this.connectionStatus.BackColor = System.Drawing.Color.Transparent;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(39, 21);
            this.connectionStatus.Text = "Status";
            // 
            // notify
            // 
            this.notify.Text = "notifyIcon1";
            this.notify.Visible = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Battery Cooler";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(386, 104);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Battery Cooler Diagnostic";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar connectionProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

