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
}
