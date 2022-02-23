namespace FontCreatorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bevelControlPanel = new BevelControl.BevelControl();
            this.SuspendLayout();
            // 
            // bevelControlPanel
            // 
            this.bevelControlPanel.AutoScroll = true;
            this.bevelControlPanel.BevelLineStep = 20;
            this.bevelControlPanel.BKarandash = '1';
            this.bevelControlPanel.BSterka = '0';
            this.bevelControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bevelControlPanel.KarandashColor = System.Drawing.Color.MediumVioletRed;
            this.bevelControlPanel.LastikColor = System.Drawing.SystemColors.ButtonFace;
            this.bevelControlPanel.Location = new System.Drawing.Point(0, 0);
            this.bevelControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bevelControlPanel.Name = "bevelControlPanel";
            this.bevelControlPanel.Rejim = false;
            this.bevelControlPanel.Size = new System.Drawing.Size(573, 393);
            this.bevelControlPanel.TabIndex = 0;
            this.bevelControlPanel.CliclEvent += new BevelControl.ClickEventHandler(this.bevelControlPanel_CliclEvent);
            this.bevelControlPanel.MouseDownEvent += new BevelControl.MouseDwnEventHandler(this.bevelControlPanel_MouseDownEvent);
            this.bevelControlPanel.MouseMoveEvent += new BevelControl.MouseMovEventHandler(this.bevelControlPanel_MouseMoveEvent);
            this.bevelControlPanel.MouseUpEvent += new BevelControl.MouseUpEventHandler(this.bevelControlPanel_MouseUpEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 393);
            this.Controls.Add(this.bevelControlPanel);
            this.Name = "Form1";
            this.Text = "ePaperFontCreator Tools";
            this.ResumeLayout(false);

        }

		#endregion

		private BevelControl.BevelControl bevelControlPanel;
	}
}