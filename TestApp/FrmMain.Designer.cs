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
            this.btnOne = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 50;
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(90, 39);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(116, 23);
            this.btnOne.TabIndex = 4;
            this.btnOne.Text = "1 Run";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enqueue Work";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EnqueueWorkButton_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOne);
            this.Name = "FrmMain";
            this.Text = "Task Scheduling Demo";
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer StatusTimer;
		private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button button1;
    }
}

