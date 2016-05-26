
namespace PingSnurra
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStopPing;
		private System.Windows.Forms.Button btnStartPing;
		private System.Windows.Forms.Button btnSaveLog;
		private System.Windows.Forms.TextBox txtPingLog;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStopPing = new System.Windows.Forms.Button();
			this.btnStartPing = new System.Windows.Forms.Button();
			this.btnSaveLog = new System.Windows.Forms.Button();
			this.txtPingLog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(1, 28);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(448, 20);
			this.txtAddress.TabIndex = 0;
			this.txtAddress.Text = "google.com";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Address to ping";
			// 
			// btnStopPing
			// 
			this.btnStopPing.Location = new System.Drawing.Point(168, 0);
			this.btnStopPing.Name = "btnStopPing";
			this.btnStopPing.Size = new System.Drawing.Size(75, 23);
			this.btnStopPing.TabIndex = 2;
			this.btnStopPing.Text = "Stop";
			this.btnStopPing.UseVisualStyleBackColor = true;
			this.btnStopPing.Click += new System.EventHandler(this.BtnStopPingClick);
			// 
			// btnStartPing
			// 
			this.btnStartPing.Location = new System.Drawing.Point(87, 0);
			this.btnStartPing.Name = "btnStartPing";
			this.btnStartPing.Size = new System.Drawing.Size(75, 23);
			this.btnStartPing.TabIndex = 3;
			this.btnStartPing.Text = "Start pinging";
			this.btnStartPing.UseVisualStyleBackColor = true;
			this.btnStartPing.Click += new System.EventHandler(this.BtnStartPingClick);
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Location = new System.Drawing.Point(374, 0);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(75, 23);
			this.btnSaveLog.TabIndex = 5;
			this.btnSaveLog.Text = "Save log";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLogClick);
			// 
			// txtPingLog
			// 
			this.txtPingLog.Location = new System.Drawing.Point(1, 54);
			this.txtPingLog.Multiline = true;
			this.txtPingLog.Name = "txtPingLog";
			this.txtPingLog.Size = new System.Drawing.Size(448, 559);
			this.txtPingLog.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 613);
			this.Controls.Add(this.txtPingLog);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.btnStartPing);
			this.Controls.Add(this.btnStopPing);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAddress);
			this.Name = "MainForm";
			this.Text = "PingSnurra";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
