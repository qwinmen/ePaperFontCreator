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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bevelControlPanel = new BevelControl.BevelControl();
            this.groupBoxFieldConfig = new System.Windows.Forms.GroupBox();
            this.groupBoxDrawMode = new System.Windows.Forms.GroupBox();
            this.radioButtonLastic = new System.Windows.Forms.RadioButton();
            this.radioButtonKarandash = new System.Windows.Forms.RadioButton();
            this.buttonClearPanel = new System.Windows.Forms.Button();
            this.comboBoxFonts = new System.Windows.Forms.ComboBox();
            this.groupBoxFieldConfig.SuspendLayout();
            this.groupBoxDrawMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // bevelControlPanel
            // 
            this.bevelControlPanel.AutoScroll = true;
            this.bevelControlPanel.BevelLineStep = 20;
            this.bevelControlPanel.BKarandash = '1';
            this.bevelControlPanel.BSterka = '0';
            this.bevelControlPanel.KarandashColor = System.Drawing.Color.MediumVioletRed;
            this.bevelControlPanel.LastikColor = System.Drawing.SystemColors.ButtonFace;
            this.bevelControlPanel.Location = new System.Drawing.Point(0, 0);
            this.bevelControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bevelControlPanel.Name = "bevelControlPanel";
            this.bevelControlPanel.Rejim = false;
            this.bevelControlPanel.Size = new System.Drawing.Size(405, 393);
            this.bevelControlPanel.TabIndex = 0;
            this.bevelControlPanel.CliclEvent += new BevelControl.ClickEventHandler(this.bevelControlPanel_CliclEvent);
            this.bevelControlPanel.MouseDownEvent += new BevelControl.MouseDwnEventHandler(this.bevelControlPanel_MouseDownEvent);
            this.bevelControlPanel.MouseMoveEvent += new BevelControl.MouseMovEventHandler(this.bevelControlPanel_MouseMoveEvent);
            this.bevelControlPanel.MouseUpEvent += new BevelControl.MouseUpEventHandler(this.bevelControlPanel_MouseUpEvent);
            // 
            // groupBoxFieldConfig
            // 
            this.groupBoxFieldConfig.Controls.Add(this.groupBoxDrawMode);
            this.groupBoxFieldConfig.Controls.Add(this.buttonClearPanel);
            this.groupBoxFieldConfig.Controls.Add(this.comboBoxFonts);
            this.groupBoxFieldConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxFieldConfig.Location = new System.Drawing.Point(481, 0);
            this.groupBoxFieldConfig.Name = "groupBoxFieldConfig";
            this.groupBoxFieldConfig.Size = new System.Drawing.Size(207, 393);
            this.groupBoxFieldConfig.TabIndex = 1;
            this.groupBoxFieldConfig.TabStop = false;
            this.groupBoxFieldConfig.Text = "Настройки";
            // 
            // groupBoxDrawMode
            // 
            this.groupBoxDrawMode.Controls.Add(this.radioButtonLastic);
            this.groupBoxDrawMode.Controls.Add(this.radioButtonKarandash);
            this.groupBoxDrawMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDrawMode.Location = new System.Drawing.Point(3, 19);
            this.groupBoxDrawMode.Name = "groupBoxDrawMode";
            this.groupBoxDrawMode.Size = new System.Drawing.Size(201, 100);
            this.groupBoxDrawMode.TabIndex = 2;
            this.groupBoxDrawMode.TabStop = false;
            this.groupBoxDrawMode.Text = "Режим";
            // 
            // radioButtonLastic
            // 
            this.radioButtonLastic.AutoSize = true;
            this.radioButtonLastic.Location = new System.Drawing.Point(6, 47);
            this.radioButtonLastic.Name = "radioButtonLastic";
            this.radioButtonLastic.Size = new System.Drawing.Size(63, 19);
            this.radioButtonLastic.TabIndex = 1;
            this.radioButtonLastic.Text = "Стерка";
            this.radioButtonLastic.UseVisualStyleBackColor = true;
            this.radioButtonLastic.CheckedChanged += new System.EventHandler(this.radioButtonDrawningMode_CheckedChanged);
            // 
            // radioButtonKarandash
            // 
            this.radioButtonKarandash.AutoSize = true;
            this.radioButtonKarandash.Checked = true;
            this.radioButtonKarandash.Location = new System.Drawing.Point(6, 22);
            this.radioButtonKarandash.Name = "radioButtonKarandash";
            this.radioButtonKarandash.Size = new System.Drawing.Size(81, 19);
            this.radioButtonKarandash.TabIndex = 0;
            this.radioButtonKarandash.TabStop = true;
            this.radioButtonKarandash.Text = "Карандаш";
            this.radioButtonKarandash.UseVisualStyleBackColor = true;
            this.radioButtonKarandash.CheckedChanged += new System.EventHandler(this.radioButtonDrawningMode_CheckedChanged);
            // 
            // buttonClearPanel
            // 
            this.buttonClearPanel.Location = new System.Drawing.Point(6, 155);
            this.buttonClearPanel.Name = "buttonClearPanel";
            this.buttonClearPanel.Size = new System.Drawing.Size(75, 23);
            this.buttonClearPanel.TabIndex = 1;
            this.buttonClearPanel.Text = "Очистить";
            this.buttonClearPanel.UseVisualStyleBackColor = true;
            this.buttonClearPanel.Click += new System.EventHandler(this.buttonClearPanel_Click);
            // 
            // comboBoxFonts
            // 
            this.comboBoxFonts.DisplayMember = "0";
            this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFonts.Items.AddRange(new object[] {
            "Font24",
            "Font72"});
            this.comboBoxFonts.Location = new System.Drawing.Point(6, 126);
            this.comboBoxFonts.Name = "comboBoxFonts";
            this.comboBoxFonts.Size = new System.Drawing.Size(167, 23);
            this.comboBoxFonts.TabIndex = 0;
            this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 393);
            this.Controls.Add(this.groupBoxFieldConfig);
            this.Controls.Add(this.bevelControlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ePaperFontCreator Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFieldConfig.ResumeLayout(false);
            this.groupBoxDrawMode.ResumeLayout(false);
            this.groupBoxDrawMode.PerformLayout();
            this.ResumeLayout(false);

        }

		#endregion

		private BevelControl.BevelControl bevelControlPanel;
		private GroupBox groupBoxFieldConfig;
		private ComboBox comboBoxFonts;
		private Button buttonClearPanel;
		private GroupBox groupBoxDrawMode;
		private RadioButton radioButtonLastic;
		private RadioButton radioButtonKarandash;
	}
}
