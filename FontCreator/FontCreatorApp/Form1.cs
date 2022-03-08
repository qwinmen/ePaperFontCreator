namespace FontCreatorApp
{
	public partial class Form1: Form
	{
		private PaintGain _paintGainLogic;

		public Form1()
		{
			InitializeComponent();
		}

		private void bevelControlPanel_CliclEvent(object sender, EventArgs e)
		{
		}

		private void bevelControlPanel_MouseDownEvent(object sender, MouseEventArgs e)
		{
		}

		private void bevelControlPanel_MouseMoveEvent(object sender, MouseEventArgs e)
		{
		}

		private void bevelControlPanel_MouseUpEvent(object sender, MouseEventArgs e)
		{
			int[,] paintData = this.bevelControlPanel.SaveArrayToFile(out int xLenght, out int yLenght);
			string text = _paintGainLogic.Build(paintData, xLenght, yLenght);
			textBoxHex.Text = text;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//установить дефолтным шрифт
			this.comboBoxFonts.SelectedIndex = 0;
		}

		private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox currentBoxItem = sender as ComboBox;
			if (currentBoxItem == null)
				throw new Exception("Ошибка приведения к типу.");

			//Перерисовать под новый шрифт:
			_paintGainLogic = new PaintGain(currentBoxItem.SelectedIndex);

			int width = _paintGainLogic.BevelLineStep * _paintGainLogic.CurrentWidthCoefficient;
			int height = _paintGainLogic.BevelLineStep * _paintGainLogic.CurrentHeightCoefficient;
			this.bevelControlPanel.Size = new Size(width, height);
			this.bevelControlPanel.BevelLineStep = _paintGainLogic.BevelLineStep;
		}

		private void buttonClearPanel_Click(object sender, EventArgs e)
		{
			//Очистить поле для рисования
			this.bevelControlPanel.ClearHolst();
		}

		/// <summary>
		///     Установить режим рисования
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButtonDrawningMode_CheckedChanged(object sender, EventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton == null)
				return;

			//включить карандаш или стерку:
			if (radioButton.TabIndex == 0 && radioButton.Checked)
				this.bevelControlPanel.Rejim = false;
			else if (radioButton.TabIndex == 1 && radioButton.Checked)
				this.bevelControlPanel.Rejim = true;
		}
	}
}
