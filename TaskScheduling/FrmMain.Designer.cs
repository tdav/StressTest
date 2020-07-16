namespace TestApp
{
	partial class FrmMain
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
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.EnqueueWorkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 50;
            // 
            // EnqueueWorkButton
            // 
            this.EnqueueWorkButton.Location = new System.Drawing.Point(90, 105);
            this.EnqueueWorkButton.Name = "EnqueueWorkButton";
            this.EnqueueWorkButton.Size = new System.Drawing.Size(116, 23);
            this.EnqueueWorkButton.TabIndex = 4;
            this.EnqueueWorkButton.Text = "Enqueue Work";
            this.EnqueueWorkButton.UseVisualStyleBackColor = true;
            this.EnqueueWorkButton.Click += new System.EventHandler(this.EnqueueWorkButton_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 252);
            this.Controls.Add(this.EnqueueWorkButton);
            this.Name = "FrmMain";
            this.Text = "Task Scheduling Demo";
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer StatusTimer;
		private System.Windows.Forms.Button EnqueueWorkButton;
	}
}

