namespace BevelControl
{
	partial class BevelControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			// 
			// Bevel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "Bevel";
			this.Click += new System.EventHandler(this.button1_Click);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bevel_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bevel_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Bevel_MouseUp);
			this.ResumeLayout(false);
		}

		#endregion
	}
}
