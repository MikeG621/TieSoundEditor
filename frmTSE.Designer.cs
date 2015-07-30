namespace Idmr.TieSoundEditor
{
	partial class frmTSE
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLFD;
		private System.Windows.Forms.TextBox txtWave;
		private System.Windows.Forms.RadioButton optExport;
		private System.Windows.Forms.RadioButton optImport;
		private System.Windows.Forms.ListBox lstVOIC;
		private System.Windows.Forms.Button cmdLFD;
		private System.Windows.Forms.Button cmdWave;
		private System.Windows.Forms.OpenFileDialog opnFile;
		private System.Windows.Forms.SaveFileDialog savFile;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdExit;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTSE));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLFD = new System.Windows.Forms.TextBox();
			this.txtWave = new System.Windows.Forms.TextBox();
			this.optExport = new System.Windows.Forms.RadioButton();
			this.optImport = new System.Windows.Forms.RadioButton();
			this.lstVOIC = new System.Windows.Forms.ListBox();
			this.cmdLFD = new System.Windows.Forms.Button();
			this.cmdWave = new System.Windows.Forms.Button();
			this.opnFile = new System.Windows.Forms.OpenFileDialog();
			this.savFile = new System.Windows.Forms.SaveFileDialog();
			this.cmdSave = new System.Windows.Forms.Button();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdDump = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Resource file (LFD) to extract sound from";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "VOIC/BLAS resources";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Wave file to save as";
			// 
			// txtLFD
			// 
			this.txtLFD.Location = new System.Drawing.Point(8, 48);
			this.txtLFD.Name = "txtLFD";
			this.txtLFD.Size = new System.Drawing.Size(232, 20);
			this.txtLFD.TabIndex = 3;
			// 
			// txtWave
			// 
			this.txtWave.Enabled = false;
			this.txtWave.Location = new System.Drawing.Point(8, 120);
			this.txtWave.Name = "txtWave";
			this.txtWave.Size = new System.Drawing.Size(232, 20);
			this.txtWave.TabIndex = 4;
			// 
			// optExport
			// 
			this.optExport.Checked = true;
			this.optExport.Location = new System.Drawing.Point(312, 240);
			this.optExport.Name = "optExport";
			this.optExport.Size = new System.Drawing.Size(56, 16);
			this.optExport.TabIndex = 5;
			this.optExport.TabStop = true;
			this.optExport.Text = "Export";
			this.optExport.CheckedChanged += new System.EventHandler(this.optExport_CheckedChanged);
			// 
			// optImport
			// 
			this.optImport.Location = new System.Drawing.Point(384, 240);
			this.optImport.Name = "optImport";
			this.optImport.Size = new System.Drawing.Size(72, 16);
			this.optImport.TabIndex = 6;
			this.optImport.Text = "Import";
			// 
			// lstVOIC
			// 
			this.lstVOIC.Location = new System.Drawing.Point(312, 64);
			this.lstVOIC.Name = "lstVOIC";
			this.lstVOIC.Size = new System.Drawing.Size(120, 160);
			this.lstVOIC.TabIndex = 7;
			this.lstVOIC.SelectedIndexChanged += new System.EventHandler(this.lstVOIC_SelectedIndexChanged);
			// 
			// cmdLFD
			// 
			this.cmdLFD.Location = new System.Drawing.Point(248, 48);
			this.cmdLFD.Name = "cmdLFD";
			this.cmdLFD.Size = new System.Drawing.Size(24, 23);
			this.cmdLFD.TabIndex = 8;
			this.cmdLFD.Text = "...";
			this.cmdLFD.Click += new System.EventHandler(this.cmdLFD_Click);
			// 
			// cmdWave
			// 
			this.cmdWave.Enabled = false;
			this.cmdWave.Location = new System.Drawing.Point(248, 120);
			this.cmdWave.Name = "cmdWave";
			this.cmdWave.Size = new System.Drawing.Size(24, 23);
			this.cmdWave.TabIndex = 10;
			this.cmdWave.Text = "...";
			this.cmdWave.Click += new System.EventHandler(this.cmdWave_Click);
			// 
			// opnFile
			// 
			this.opnFile.DefaultExt = "lfd";
			this.opnFile.Filter = "LFD Resources Files|*.lfd";
			this.opnFile.Title = "LFD File";
			this.opnFile.FileOk += new System.ComponentModel.CancelEventHandler(this.opnFile_FileOk);
			// 
			// savFile
			// 
			this.savFile.DefaultExt = "wav";
			this.savFile.Filter = "Wave Files|*.wav";
			this.savFile.OverwritePrompt = false;
			this.savFile.Title = "WAV File";
			this.savFile.FileOk += new System.ComponentModel.CancelEventHandler(this.savFile_FileOk);
			// 
			// cmdSave
			// 
			this.cmdSave.Enabled = false;
			this.cmdSave.Location = new System.Drawing.Point(48, 184);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(80, 23);
			this.cmdSave.TabIndex = 9;
			this.cmdSave.Text = "Save File";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// cmdExit
			// 
			this.cmdExit.Location = new System.Drawing.Point(160, 184);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(80, 24);
			this.cmdExit.TabIndex = 11;
			this.cmdExit.Text = "E&xit";
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// cmdDump
			// 
			this.cmdDump.Location = new System.Drawing.Point(244, 225);
			this.cmdDump.Name = "cmdDump";
			this.cmdDump.Size = new System.Drawing.Size(50, 30);
			this.cmdDump.TabIndex = 13;
			this.cmdDump.Text = "dump";
			this.cmdDump.UseVisualStyleBackColor = true;
			this.cmdDump.Click += new System.EventHandler(this.cmdDump_Click);
			// 
			// frmTSE
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 269);
			this.Controls.Add(this.cmdDump);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.cmdWave);
			this.Controls.Add(this.cmdLFD);
			this.Controls.Add(this.lstVOIC);
			this.Controls.Add(this.optImport);
			this.Controls.Add(this.optExport);
			this.Controls.Add(this.txtWave);
			this.Controls.Add(this.txtLFD);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTSE";
			this.Text = "TIE Sound Extractor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdDump;
	}
}

