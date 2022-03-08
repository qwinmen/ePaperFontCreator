using System.Text;

namespace FontCreatorApp;

public class PaintGain
{
	public PaintGain(FontType fontType)
		: this((int)fontType)
	{
	}

	/// <summary>
	/// </summary>
	/// <param name="fontTypeFromEnum">Индекс шрифта</param>
	public PaintGain(int fontTypeFromEnum)
	{
		BaseConfigure(fontTypeFromEnum);
	}

	/// <summary>
	///     Выбранный шрифт
	/// </summary>
	public FontType CurrentFontType { get; private set; }

	/// <summary>
	///     Коэффициент для ширины поля
	/// </summary>
	public int CurrentWidthCoefficient { get; private set; }

	/// <summary>
	///     Коэффициент для высоты поля
	/// </summary>
	public int CurrentHeightCoefficient { get; private set; }

	/// <summary>
	///     Шаг, задающий сетку холста
	/// </summary>
	public int BevelLineStep { get; private set; }

	/// <summary>
	///     Базовые настройки холста
	/// </summary>
	/// <param name="fontTypeFromEnum">Порядковый номер шрифта</param>
	private void BaseConfigure(int fontTypeFromEnum)
	{
		switch (fontTypeFromEnum)
		{
			case (int)FontType.Font72:
				CurrentFontType = FontType.Font72;
				CurrentWidthCoefficient = 49;
				CurrentHeightCoefficient = 73;
				BevelLineStep = 10;
				break;
			case (int)FontType.Font24:
			default:
				CurrentFontType = FontType.Font24;
				CurrentWidthCoefficient = 20;
				CurrentHeightCoefficient = 24;
				BevelLineStep = 20;
				break;
		}
	}

	public string Build(int[,] arrayData, int xLenght, int yLenght)
	{
		/*
		 * получаем массив с поля
		 * переводим значение массива в Hex формат
		 * отдаем результат
		 */
		string result = "";
		List<int> stringValue = new List<int>(xLenght);
		for (int y = 0; y < yLenght; y++)
		{
			for (int i = 0; i < xLenght; i++)
			{
				stringValue.Add(arrayData[i, y]);
			}

			result += TransformToHex(stringValue) + Environment.NewLine;
			stringValue.Clear();
		}

		return result;
	}

	private string TransformToHex(List<int> stringValue)
	{
		/*
		 * разбить на части по 8
		 * каждую часть приводить к Hex
		 */
		string result = "";
		int counter = 0;
		string tmpByte = "";
		const int bitConst = 7; //колличество разрядов начиная с 0

		foreach (int i in stringValue)
		{
			tmpByte += i;
			if (counter == bitConst)
			{
				result += String.Format("0x{0:X2}, ", Convert.ToUInt64(tmpByte, 2));
				counter = 0;
				tmpByte = String.Empty;
			}
			else
				counter++;
		}

		if (counter != 0)
		{
			result += String.Format("0x{0:X2}, ", Convert.ToUInt64(
				tmpByte.PadRight(bitConst + 1, '0')
				, 2));
		}

		return result;
	}
}
