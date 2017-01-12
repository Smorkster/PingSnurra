
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
		private System.Windows.Forms.CheckBox checkboxTimeout;
		private System.Windows.Forms.TextBox txtTimeout;
		private System.Windows.Forms.CheckBox checkboxBuffer;
		private System.Windows.Forms.TextBox txtBuffer;
		private System.Windows.Forms.GroupBox groupboxSettings;
		private System.Windows.Forms.TextBox txtNumPings;
		private System.Windows.Forms.CheckBox checkboxLoops;
		private System.Windows.Forms.TextBox txtTTL;
		private System.Windows.Forms.CheckBox checkboxTTL;
		private System.Windows.Forms.CheckBox checkboxDontFragment;
		private System.Windows.Forms.CheckBox checkboxSettings;
		
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
			this.checkboxTimeout = new System.Windows.Forms.CheckBox();
			this.txtTimeout = new System.Windows.Forms.TextBox();
			this.checkboxBuffer = new System.Windows.Forms.CheckBox();
			this.txtBuffer = new System.Windows.Forms.TextBox();
			this.groupboxSettings = new System.Windows.Forms.GroupBox();
			this.txtNumPings = new System.Windows.Forms.TextBox();
			this.checkboxLoops = new System.Windows.Forms.CheckBox();
			this.txtTTL = new System.Windows.Forms.TextBox();
			this.checkboxTTL = new System.Windows.Forms.CheckBox();
			this.checkboxDontFragment = new System.Windows.Forms.CheckBox();
			this.checkboxSettings = new System.Windows.Forms.CheckBox();
			this.groupboxSettings.SuspendLayout();
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
			this.btnStopPing.Enabled = false;
			this.btnStopPing.Location = new System.Drawing.Point(168, 0);
			this.btnStopPing.Name = "btnStopPing";
			this.btnStopPing.Size = new System.Drawing.Size(75, 23);
			this.btnStopPing.TabIndex = 2;
			this.btnStopPing.Text = "Stop";
			this.btnStopPing.UseVisualStyleBackColor = true;
			this.btnStopPing.Click += new System.EventHandler(this.btnStopPing_Click);
			// 
			// btnStartPing
			// 
			this.btnStartPing.Location = new System.Drawing.Point(87, 0);
			this.btnStartPing.Name = "btnStartPing";
			this.btnStartPing.Size = new System.Drawing.Size(75, 23);
			this.btnStartPing.TabIndex = 3;
			this.btnStartPing.Text = "Start pinging";
			this.btnStartPing.UseVisualStyleBackColor = true;
			this.btnStartPing.Click += new System.EventHandler(this.btnStartPing_Click);
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.AutoSize = true;
			this.btnSaveLog.Location = new System.Drawing.Point(374, 0);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(75, 23);
			this.btnSaveLog.TabIndex = 5;
			this.btnSaveLog.Text = "Save log";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
			// 
			// txtPingLog
			// 
			this.txtPingLog.HideSelection = false;
			this.txtPingLog.Location = new System.Drawing.Point(1, 54);
			this.txtPingLog.Multiline = true;
			this.txtPingLog.Name = "txtPingLog";
			this.txtPingLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.txtPingLog.Size = new System.Drawing.Size(448, 559);
			this.txtPingLog.TabIndex = 6;
			this.txtPingLog.ClientSizeChanged += new System.EventHandler(this.txtPingLog_TextChanged);
			this.txtPingLog.TextChanged += new System.EventHandler(this.txtPingLog_TextChanged);
			// 
			// checkboxTimeout
			// 
			this.checkboxTimeout.AutoSize = true;
			this.checkboxTimeout.Location = new System.Drawing.Point(6, 29);
			this.checkboxTimeout.Name = "checkboxTimeout";
			this.checkboxTimeout.Size = new System.Drawing.Size(64, 17);
			this.checkboxTimeout.TabIndex = 8;
			this.checkboxTimeout.Text = "Timeout";
			this.checkboxTimeout.UseVisualStyleBackColor = true;
			this.checkboxTimeout.CheckedChanged += new System.EventHandler(this.checkboxTimeout_CheckedChanged);
			// 
			// txtTimeout
			// 
			this.txtTimeout.Enabled = false;
			this.txtTimeout.Location = new System.Drawing.Point(76, 29);
			this.txtTimeout.Name = "txtTimeout";
			this.txtTimeout.Size = new System.Drawing.Size(70, 20);
			this.txtTimeout.TabIndex = 9;
			// 
			// checkboxBuffer
			// 
			this.checkboxBuffer.AutoSize = true;
			this.checkboxBuffer.Location = new System.Drawing.Point(152, 29);
			this.checkboxBuffer.Name = "checkboxBuffer";
			this.checkboxBuffer.Size = new System.Drawing.Size(54, 17);
			this.checkboxBuffer.TabIndex = 10;
			this.checkboxBuffer.Text = "Buffer";
			this.checkboxBuffer.UseVisualStyleBackColor = true;
			this.checkboxBuffer.CheckedChanged += new System.EventHandler(this.checkboxBuffer_CheckedChanged);
			// 
			// txtBuffer
			// 
			this.txtBuffer.Enabled = false;
			this.txtBuffer.Location = new System.Drawing.Point(212, 27);
			this.txtBuffer.MaxLength = 65500;
			this.txtBuffer.Name = "txtBuffer";
			this.txtBuffer.Size = new System.Drawing.Size(100, 20);
			this.txtBuffer.TabIndex = 11;
			// 
			// groupboxSettings
			// 
			this.groupboxSettings.Controls.Add(this.txtNumPings);
			this.groupboxSettings.Controls.Add(this.checkboxLoops);
			this.groupboxSettings.Controls.Add(this.txtTTL);
			this.groupboxSettings.Controls.Add(this.checkboxTTL);
			this.groupboxSettings.Controls.Add(this.checkboxDontFragment);
			this.groupboxSettings.Controls.Add(this.checkboxTimeout);
			this.groupboxSettings.Controls.Add(this.txtBuffer);
			this.groupboxSettings.Controls.Add(this.txtTimeout);
			this.groupboxSettings.Controls.Add(this.checkboxBuffer);
			this.groupboxSettings.Location = new System.Drawing.Point(1, 54);
			this.groupboxSettings.Name = "groupboxSettings";
			this.groupboxSettings.Size = new System.Drawing.Size(448, 78);
			this.groupboxSettings.TabIndex = 12;
			this.groupboxSettings.TabStop = false;
			this.groupboxSettings.Text = "Ping settings (unchecked means default values)";
			// 
			// txtNumPings
			// 
			this.txtNumPings.Enabled = false;
			this.txtNumPings.Location = new System.Drawing.Point(243, 50);
			this.txtNumPings.Name = "txtNumPings";
			this.txtNumPings.Size = new System.Drawing.Size(100, 20);
			this.txtNumPings.TabIndex = 16;
			// 
			// checkboxLoops
			// 
			this.checkboxLoops.AutoSize = true;
			this.checkboxLoops.Location = new System.Drawing.Point(134, 52);
			this.checkboxLoops.Name = "checkboxLoops";
			this.checkboxLoops.Size = new System.Drawing.Size(103, 17);
			this.checkboxLoops.TabIndex = 15;
			this.checkboxLoops.Text = "Number of pings";
			this.checkboxLoops.UseVisualStyleBackColor = true;
			this.checkboxLoops.CheckedChanged += new System.EventHandler(this.checkboxLoops_CheckedChanged);
			// 
			// txtTTL
			// 
			this.txtTTL.Enabled = false;
			this.txtTTL.Location = new System.Drawing.Point(58, 50);
			this.txtTTL.Name = "txtTTL";
			this.txtTTL.Size = new System.Drawing.Size(70, 20);
			this.txtTTL.TabIndex = 14;
			// 
			// checkboxTTL
			// 
			this.checkboxTTL.AutoSize = true;
			this.checkboxTTL.Location = new System.Drawing.Point(6, 52);
			this.checkboxTTL.Name = "checkboxTTL";
			this.checkboxTTL.Size = new System.Drawing.Size(46, 17);
			this.checkboxTTL.TabIndex = 13;
			this.checkboxTTL.Text = "TTL";
			this.checkboxTTL.UseVisualStyleBackColor = true;
			this.checkboxTTL.CheckedChanged += new System.EventHandler(this.checkboxTTL_CheckedChanged);
			// 
			// checkboxDontFragment
			// 
			this.checkboxDontFragment.AutoSize = true;
			this.checkboxDontFragment.Location = new System.Drawing.Point(318, 29);
			this.checkboxDontFragment.Name = "checkboxDontFragment";
			this.checkboxDontFragment.Size = new System.Drawing.Size(95, 17);
			this.checkboxDontFragment.TabIndex = 12;
			this.checkboxDontFragment.Text = "Don\'t fragment";
			this.checkboxDontFragment.UseVisualStyleBackColor = true;
			// 
			// checkboxSettings
			// 
			this.checkboxSettings.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkboxSettings.AutoSize = true;
			this.checkboxSettings.Location = new System.Drawing.Point(313, 0);
			this.checkboxSettings.Name = "checkboxSettings";
			this.checkboxSettings.Size = new System.Drawing.Size(55, 23);
			this.checkboxSettings.TabIndex = 14;
			this.checkboxSettings.Text = "Settings";
			this.checkboxSettings.UseVisualStyleBackColor = true;
			this.checkboxSettings.CheckedChanged += new System.EventHandler(this.checkboxSettings_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 613);
			this.Controls.Add(this.checkboxSettings);
			this.Controls.Add(this.groupboxSettings);
			this.Controls.Add(this.txtPingLog);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.btnStartPing);
			this.Controls.Add(this.btnStopPing);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PingSnurra";
			this.groupboxSettings.ResumeLayout(false);
			this.groupboxSettings.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
