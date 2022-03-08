using System.ComponentModel;
using System.Drawing.Text;

namespace BevelControl
{
	/// <summary>
	///     определить открытый делегат button_Click
	/// </summary>
	public delegate void ClickEventHandler(object sender, EventArgs e);

	/// <summary>
	///     определить открытый делегат MouseDown
	/// </summary>
	public delegate void MouseDwnEventHandler(object sender, MouseEventArgs e);

	public delegate void MouseMovEventHandler(object sender, MouseEventArgs e);

	public delegate void MouseUpEventHandler(object sender, MouseEventArgs e);

	[ToolboxBitmap(typeof(BevelControl))]
	[DesignerCategory("code")]
	[Description("It is a component to decorate WinForms")]
	[DefaultProperty("Style")]
	public partial class BevelControl: UserControl
	{
		/// <summary>
		///     Контур контрольных отсечек на боковой линейке
		/// </summary>
		private readonly SolidBrush _brush2 = new SolidBrush(Color.Red);

		/// <summary>
		///     Шрифт для надписей
		/// </summary>
		private readonly Font _font5 = new Font(new FontFamily(GenericFontFamilies.Serif), 5);

		private readonly Font _font10 = new Font(new FontFamily(GenericFontFamilies.Serif), 10);

		/// <summary>
		///     каждой ячейке массива соответствует интервал по X&&Y на экране
		///     По ключу(экран координаты) берем значение(0 или 1)
		/// </summary>
		readonly Dictionary<Rectangle, char> _array = new Dictionary<Rectangle, char>();

		//[index].X------------?----------[index].Y
		private readonly List<Point> _intervalX = new List<Point>();
		private readonly List<Point> _intervalY = new List<Point>();
		private Pen _pen1, _pen2;
		private SolidBrush _brush = new SolidBrush(Color.Black);

		/// <summary>
		///     Для сохранки размерноси массива[ x, y];
		/// </summary>
		private int _xLenght, _yLenght;

		private Point _kolichKletok;

		/// <summary>
		///     массив для изменений, его на вывод в вайлы
		/// </summary>
		private int[,] _arr;

		private bool _flag;
		private Point _x1Y1, _x2Y2;

		private bool _rejim;

		public BevelControl()
		{
			InitializeComponent();
			//по умолчанию
			Style = BevelStyle.Lowered;
			Shape = BevelShape.Box;

			BevelColor = SystemColors.ButtonHighlight;
			BevelShadowColor = SystemColors.ButtonShadow;

			BevelLineStep = 5;
			BKarandash = '1';
			BSterka = '0';
			Rejim = false;
			KarandashColor = Color.MediumVioletRed;
			LastikColor = SystemColors.ButtonFace;
			FontSize = 5;
			LinFPos = LineijFontPosition.Left;

			Width = 40;
			Height = 40;
		}

		/// <summary>
		///     Установить режим рисования Ласик\Карандаш
		/// </summary>
		public bool Rejim
		{
			get { return _rejim; }
			set
			{
				_rejim = value;
				Invalidate();
			}
		}

		/// <summary>
		///     Событие которое высветится в событиях контрола
		/// </summary>
		public event ClickEventHandler CliclEvent;

		/// <summary>
		///     Выполнить переход к элементу ЛОГИКА
		/// </summary>
		private void button1_Click(object sender, EventArgs e)
		{
			if (CliclEvent != null)
				CliclEvent(sender, e);
			else
			{
				MessageBox.Show(@"Нет подписавшихся");
			}
		}


		/// <summary>
		///     метод для рисования рамки с тенью
		/// </summary>
		void BevelRect(Graphics g, Rectangle rect)
		{
			g.DrawLine(_pen1, new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
			g.DrawLine(_pen1, new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));

			g.DrawLine(_pen2, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
			g.DrawLine(_pen2, new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Bottom));
		}

		/// <summary>
		///     Разлиновываем холст + линейка
		/// </summary>
		void BevelLine(Graphics g, Rectangle rect)
		{
			_brush = new SolidBrush(_pen1.Color);

			switch (_lineijFontPos)
			{
				case LineijFontPosition.Left:
				{
					//Линейка по Y:
					for (int i = BevelLineStep, index = 0; i < rect.Bottom; i += BevelLineStep, index++)
					{
						g.DrawLine(_pen1, new Point(rect.Left, rect.Top + i), new Point(rect.Right, rect.Top + i));
						g.DrawString(index.ToString(), new Font(new FontFamily(GenericFontFamilies.Serif), _fontSize),
							index % 10 == 0 ? _brush2 : _brush, new Point(rect.Left, (i - BevelLineStep) + BevelLineStep / 2));

						_kolichKletok.Y = index;
					}

					//Линейка по X:
					for (int i = BevelLineStep, index = 0; i < rect.Right; i += BevelLineStep, index++)
					{
						g.DrawLine(_pen1, new Point(rect.Left + i, rect.Top), new Point(rect.Left + i, rect.Bottom));
						g.DrawString(index.ToString(), new Font(new FontFamily(GenericFontFamilies.Serif), _fontSize),
							index % 10 == 0 ? _brush2 : _brush, new Point((i - BevelLineStep) + BevelLineStep / 2, rect.Top));
						_kolichKletok.X = index;
					}
				}
					break;
				case LineijFontPosition.Right:
				{
					//Линия Y:
					for (int i = BevelLineStep, index = 0; i < rect.Bottom; i += BevelLineStep, index++)
					{
						g.DrawLine(_pen1, new Point(rect.Left, rect.Top + i), new Point(rect.Right, rect.Top + i));

						g.DrawString(index.ToString(), new Font(new FontFamily(GenericFontFamilies.Serif), _fontSize),
							index % 10 == 0 ? _brush2 : _brush, new Point(rect.Right - (BevelLineStep), i - BevelLineStep));

						_kolichKletok.Y = index;
					}

					//Линия X:
					for (int i = rect.Right, index = 0, ii = BevelLineStep; i > BevelLineStep; i -= BevelLineStep, index++, ii += BevelLineStep)
					{
						g.DrawLine(_pen1, new Point(rect.Left + ii, rect.Top), new Point(rect.Left + ii, rect.Bottom));

						g.DrawString(index.ToString(), new Font(new FontFamily(GenericFontFamilies.Serif), _fontSize),
							index % 10 == 0 ? _brush2 : _brush, new Point(i - BevelLineStep, rect.Top));
						_kolichKletok.X = index;
					}
				}
					break;
			}
		}


		//событие onPaint которое вызывается при необходимости прорисовки
		protected override void OnPaint(PaintEventArgs e)
		{
			#region Рамка по контуру

			if (_style == BevelStyle.Lowered)
			{
				_pen1 = new Pen(BevelShadowColor, 1);
				_pen2 = new Pen(BevelColor, 1);
			}
			else
			{
				_pen1 = new Pen(BevelColor, 1);
				_pen2 = new Pen(BevelShadowColor, 1);
			}

			//в зависимости от формы обрамления выводим рисунок
			switch (_shape)
			{
				case BevelShape.Box:
					BevelRect(e.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));
					break;
				case BevelShape.Frame:
					Pen temp = _pen1;
					_pen1 = _pen2;
					BevelRect(e.Graphics, new Rectangle(0, 0, Width - 2, Height - 2));
					_pen1 = temp;
					_pen2 = temp;
					BevelRect(e.Graphics, new Rectangle(1, 1, Width - 2, Height - 2));
					break;
				case BevelShape.TopLine:
					e.Graphics.DrawLine(_pen1, new Point(0, 0), new Point(Width - 1, 0));
					e.Graphics.DrawLine(_pen2, new Point(0, 1), new Point(Width - 1, 1));
					break;
				case BevelShape.BottomLine:
					e.Graphics.DrawLine(_pen1, new Point(0, Height - 2), new Point(Width - 1, Height - 2));
					e.Graphics.DrawLine(_pen2, new Point(0, Height - 1), new Point(Width - 1, Height - 1));
					break;
				case BevelShape.LeftLine:
					e.Graphics.DrawLine(_pen1, new Point(0, 0), new Point(0, Height - 1));
					e.Graphics.DrawLine(_pen2, new Point(1, 0), new Point(1, Height - 1));
					break;
				case BevelShape.RightLine:
					e.Graphics.DrawLine(_pen1, new Point(Width - 2, 0), new Point(Width - 2, Height - 1));
					e.Graphics.DrawLine(_pen2, new Point(Width - 1, 0), new Point(Width - 1, Height - 1));
					break;
				case BevelShape.VerticalLine:
					e.Graphics.DrawLine(_pen1, new Point(Width / 2, 0), new Point(Width / 2, Height - 1));
					e.Graphics.DrawLine(_pen2, new Point(Width / 2 + 1, 0), new Point(Width / 2 + 1, Height - 1));
					break;
				case BevelShape.HorizontalLine:
					e.Graphics.DrawLine(_pen1, new Point(0, Height / 2), new Point(Width - 1, Height / 2));
					e.Graphics.DrawLine(_pen2, new Point(0, Height / 2 + 1), new Point(Width - 1, Height / 2 + 1));
					break;
			}

			#endregion

			//рисуем сетку
			BevelLine(e.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));

			//заполним эту сетку значением поля Ластик
			StokZapolnenie(e.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));
		}

		/// <summary>
		///     При старте программы заполнить клетки знаком из поля Ластик
		/// </summary>
		private void StokZapolnenie(Graphics g, Rectangle rect)
		{
			if (_arr == null)
			{
				//При запуске первый раз отрисовываем значения
				_array.Clear();

				//какое количество клеток? Х=[?], У=[?]
				_arr = new int[_kolichKletok.X + 1, _kolichKletok.Y + 2];

				//запоминаем размерности массива
				_xLenght = _kolichKletok.X + 1;
				_yLenght = _kolichKletok.Y + 2;

				//по У
				for (int j = 0, ind = 0; j < rect.Bottom; j += BevelLineStep, ind++)
				{
					//по Х
					for (int i = BevelLineStep, index = 0; i < rect.Right; i += BevelLineStep, index++)
					{
						_arr[index, ind] = int.Parse(_lastic.ToString());
						Rectangle tmpRect = new Rectangle(i - _bevelStep, j, _bevelStep, _bevelStep);
						//закрасим этот квадрат
						g.FillRectangle(new SolidBrush(_arr[index, ind] == int.Parse(_karandash.ToString()) ? KarandashColor : LastikColor), tmpRect);

						g.DrawString(_lastic.ToString(), _bevelStep <= 10 ? _font5 : _font10, _brush,
							new Point(i - BevelLineStep, j - rect.Top));

						_array.Add(tmpRect, _lastic);
						_intervalX.Add(new Point(i - _bevelStep, i)); //intervalX[index] = new Point(i - bevelStep, i);//
					}

					_intervalY.Add(new Point(j, j + _bevelStep)); //intervalY[ind] = new Point(j, j + bevelStep);
				}
			}
			/*------------Note---------------------------------*/
			else
			{
				//Рисуем значения которые уже есть в массиве
				//какое количество клеток? Х=[?], У=[?]
				var tmp = new int[_kolichKletok.X + 1, _kolichKletok.Y + 2];
				_array.Clear();
				//мы будем получать новые значения интервалов
				_intervalX.Clear();
				_intervalY.Clear();

				//по У
				for (int j = 0, ind = 0; j < rect.Bottom; j += BevelLineStep, ind++)
				{
					//по Х
					for (int i = BevelLineStep, index = 0; i < rect.Right; i += BevelLineStep, index++)
					{
						//Стандартный режим - холст не растягивался для допКлеток
						//index < arr[-,].Length && ind <= arr[,-].Lengt

						if (index < _xLenght && ind < _yLenght)
						{
							Rectangle tmpRect = new Rectangle(i - _bevelStep, j, _bevelStep, _bevelStep);
							//закрасим этот квадрат
							g.FillRectangle(new SolidBrush(_arr[index, ind] == int.Parse(_karandash.ToString()) ? KarandashColor : LastikColor), tmpRect);

							//на квадрате отрисуем символ
							g.DrawString(_arr[index, ind].ToString(), _bevelStep <= 10 ? _font5 : _font10, _brush,
								new Point(i - BevelLineStep, j - rect.Top));

							_array.Add(tmpRect, Convert.ToChar(_arr[index, ind])); //char.Parse(arr[index, ind].ToString()));
						}
						else //После растяжки холста дополняем нулями массивы
						{
							tmp[index, ind] = int.Parse(_lastic.ToString());
							Rectangle tmpRect = new Rectangle(i - _bevelStep, j, _bevelStep, _bevelStep);
							//закрасим этот квадрат
							g.FillRectangle(new SolidBrush(tmp[index, ind] == int.Parse(_karandash.ToString()) ? KarandashColor : LastikColor), tmpRect);

							//дополнить новое пространство нулями
							g.DrawString(_lastic.ToString(), _bevelStep <= 10 ? _font5 : _font10, _brush,
								new Point(i - BevelLineStep, j - rect.Top));

							//добавляем новые поля с нулями в массив
							_array.Add(tmpRect, _lastic);
						}

						//в каком промежутке искать значения по иксу
						_intervalX.Add(new Point(i - _bevelStep, i)); //intervalX[index] = new Point(i - bevelStep, i);
					}

					_intervalY.Add(new Point(j, j + _bevelStep)); //intervalY[ind] = new Point(j, j + bevelStep);
				}

				//перенести значения из tmp[,] добавить в arr[,]
				//копируем начало из arr[,] в tmp[,]:
				if (_arr.Length < tmp.Length)
				{
					tmp = CopyArr(tmp, _arr);
					_xLenght = _kolichKletok.X + 1;
					_yLenght = _kolichKletok.Y + 2;
					_arr = new int[_kolichKletok.X + 1, _kolichKletok.Y + 2];
					_arr = tmp;
				}
			}

			//рисуем сетку
			BevelLine(g, new Rectangle(0, 0, Width - 1, Height - 1));
		}

		/// <summary>
		///     Скопировать полный массив arr[,] в неполный массив tmp[,]
		///     Заполнить массив arr
		/// </summary>
		private int[,] CopyArr(int[,] tmp, int[,] mArr)
		{
			//var tmp = new int[kolichKletok.X + 1, kolichKletok.Y + 2];
			int ilim;
			int jlim;

			if (_kolichKletok.Y + 2 < _yLenght)
				ilim = _kolichKletok.Y + 2;
			else ilim = _yLenght;

			if (_kolichKletok.X + 1 < _xLenght)
				jlim = _kolichKletok.X + 1;
			else jlim = _xLenght;

			//при растягивании mArr < tmp //при уменьшении mArr > tmp
			for (int i = 0; i < ilim; i++)
			{
				for (int j = 0; j < jlim; j++)
				{
					tmp[j, i] = mArr[j, i];
				}
			}

			return tmp;
		}

		/// <summary>
		///     выяснить что находится в массиве по экранной координате [x;y]
		/// </summary>
		public char ReturnPoint(int x, int y, Graphics graphics)
		{
			int index = 0;
			int decindex = 0;

			foreach (Point point in _intervalX)
			{
				if (x >= point.X && x <= point.Y)
					foreach (Point point1 in _intervalY)
					{
						if (y >= point1.X && y <= point1.Y)
						{
							ClearRectangle(new Rectangle(_intervalX[index].X + 1, _intervalY[decindex].X + 1, _bevelStep - 1, _bevelStep - 1), graphics);

							return _array[
								new Rectangle(_intervalX[index].X, _intervalY[decindex].X,
									_bevelStep, _bevelStep)];
						}

						decindex++;
					}

				index++;
			}

			/*
			//если x попадает в интервал X AND если у попадает в интервал Y
			if(x >= intervalX[index].X && x <= intervalX[index].Y)
			    if(y >= intervalY[index].X && y <= intervalY[index].Y)
			        return array[new Rectangle(intervalX[index].X, intervalY[index].X, intervalX[index].Y, intervalY[index].Y)];
			*/
			return '-';
		}

		/// <summary>
		///     Нарисовать где кликнул
		///     MouseDown()-->ReturnNewPoint()
		/// </summary>
		public char ReturnNewPoint(int x, int y, Graphics graphics)
		{
			var index = 0;
			var decindex = 0;

			foreach (Point point in _intervalX)
			{
				if (x >= point.X && x <= point.Y)
					foreach (Point point1 in _intervalY)
					{
						if (y >= point1.X && y <= point1.Y)
						{
							//нарисовать символ
							NewRectangle(new Rectangle(_intervalX[index].X + 1, _intervalY[decindex].X + 1, _bevelStep - 1, _bevelStep - 1), graphics);

							//записать изменения в массив для сохранки в файл
							if (index < _xLenght && decindex < _yLenght)
								_arr[index, decindex] = _rejim
									? int.Parse(_lastic.ToString())
									: int.Parse(_karandash.ToString());
							else //расширить arr[] нулями
							{
								//index = 106//_xLen = 100
								MessageBox.Show(@"Область будет обрезана!");
								_arr = ArrNull(_arr, index, decindex);
							}

							//вернуть символ по ключу-квадрату)
							return _array[
								new Rectangle(_intervalX[index].X, _intervalY[decindex].X,
									_bevelStep, _bevelStep)];
						}

						decindex++;
					}

				index++;
			}

			/*
			//если x попадает в интервал X AND если у попадает в интервал Y
			if(x >= intervalX[index].X && x <= intervalX[index].Y)
			    if(y >= intervalY[index].X && y <= intervalY[index].Y)
			        return array[new Rectangle(intervalX[index].X, intervalY[index].X, intervalX[index].Y, intervalY[index].Y)];
			*/
			return '+';
		}

		/// <summary>
		///     Забить нулями и расширить массив
		/// </summary>
		private int[,] ArrNull(int[,] tmp, int newX, int newY)
		{
			var loc = new int[newX >= _xLenght ? newX : _xLenght, newY >= _yLenght ? newY : _yLenght];

			for (int i = 0; i < newY; i++)
			{
				for (int j = 0; j < newX; j++)
				{
					if (j < _xLenght) loc[j, i] = tmp[j, i]; //&& i < _yLenght
					else loc[j, i] = int.Parse(_lastic.ToString());
				}
			}

			return loc;
		}

		/// <summary>
		///     Событие MouseDown
		/// </summary>
		public event MouseDwnEventHandler MouseDownEvent;

		public event MouseMovEventHandler MouseMoveEvent;
		public event MouseUpEventHandler MouseUpEvent;

		/// <summary>
		///     Старт рисовалки
		/// </summary>
		private void Bevel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_x1Y1 = new Point(e.X, e.Y);
				_flag = true;

				var erg = CreateGraphics();
				//стер где кликнул
				ReturnPoint(e.X, e.Y, erg);

				//нарисовал где кликнул
				ReturnNewPoint(e.X, e.Y, erg);

				//erg.DrawString("1", new Font(new FontFamily(GenericFontFamilies.Serif), 10), brush, new Point(e.X, e.Y));
				//MessageBox.Show("kletok=" + kolichKletok.ToString() + "  klik=" + e.Location + "  char=" + tn);
			}

			//delegate
			if (MouseDownEvent != null)
				MouseDownEvent(sender, e);
			else
			{
				MessageBox.Show(@"Нет подписавшихся");
			}
		}

		/// <summary>
		///     Рисуем
		/// </summary>
		private void Bevel_MouseMove(object sender, MouseEventArgs e)
		{
			if (_flag)
			{
				var erg = CreateGraphics();
				//стер где кликнул
				ReturnPoint(e.X, e.Y, erg);
				//MessageBox.Show("kletok=" + kolichKletok.ToString() + "  klik=" + e.Location + "  char=" + tn);

				_x2Y2 = new Point(e.X, e.Y);

				//нарисовал где кликнул
				ReturnNewPoint(e.X, e.Y, erg);
				//erg.DrawString("1", new Font(new FontFamily(GenericFontFamilies.Serif), 10), brush, new Point(e.X, e.Y));

				_x1Y1.X = _x2Y2.X;
				_x1Y1.Y = _x2Y2.Y;
			}

			if (MouseMoveEvent != null)
				MouseMoveEvent(sender, e);
			else
			{
				MessageBox.Show(@"Нет подписавшихся");
			}
		}

		/// <summary>
		///     Конец отрисовки
		/// </summary>
		private void Bevel_MouseUp(object sender, MouseEventArgs e)
		{
			_flag = false;
			if (MouseUpEvent != null)
				MouseUpEvent(sender, e);
			else
			{
				MessageBox.Show(@"Нет подписавшихся");
			}
		}

		/// <summary>
		///     Закрасить квадрат для нанесения на него строки
		/// </summary>
		private void ClearRectangle(Rectangle rect, Graphics holst)
		{
			//закрасим этот квадрат
			holst.FillRectangle(new SolidBrush(_rejim ? _lastikColor : _karandashColor), rect);
			//стоковая закраска
			//holst.FillRectangle(new SolidBrush(DefaultBackColor), rect);
		}

		/// <summary>
		///     Нарисовать символ на расчищеном месте
		///     ReturnNewPoint()-->NewRectangle()
		/// </summary>
		private void NewRectangle(Rectangle rect, Graphics holst)
		{
			//закрасим этот квадрат//holst.FillRectangle(new SolidBrush(_rejim ? lastikColor : karandashColor), rect);
			//отрисуем символ
			holst.DrawString(_rejim ? _lastic.ToString() : _karandash.ToString(), _font10, _brush, rect);
		}

		/// <summary>
		///     Свойство для доступа к массиву с числами которые на холсте.
		///     Для сохранения в файл.
		/// </summary>
		public int[,] SaveArrayToFile(out int xLenght, out int yLenght)
		{
			xLenght = _xLenght;
			yLenght = _yLenght;
			return _arr;
		}


		/// <summary>
		///     Загрузить массив символов с последующим выводом на холс
		/// </summary>
		public void LoadFromFile(int[,] aFile, int xlen, int ylen)
		{
			if (aFile == null) return;

			//загрузить содержимое aFile в arr
			if (_xLenght > xlen && _yLenght > ylen) //if (arr.Length > aFile.Length)
				_arr = CopyArrFile(_arr, aFile, xlen, ylen);
			else
			{
				//когда массив из файла больше массива холста
				//надо расширить массив холста и записать в него значения с файла
				_arr = new int[xlen, ylen];
				_arr = aFile;
				//увеличить индексы
				_xLenght = xlen;
				_yLenght = ylen;
			}
			//
		}

		/// <summary>
		///     Скопировать малый массив mArr в больший массив tmp
		/// </summary>
		private int[,] CopyArrFile(int[,] tmp, int[,] mArr, int xlen, int ylen)
		{
			var ilim = ylen;
			var jlim = xlen;

			//при растягивании mArr < tmp //при уменьшении mArr > tmp
			for (var i = 0; i < ilim; i++)
			{
				for (var j = 0; j < jlim; j++)
				{
					tmp[j, i] = mArr[j, i];
				}
			}

			return tmp;
		}

		/// <summary>
		///     Очистить полотно
		/// </summary>
		[Description("Очистить полотно")]
		public void ClearHolst()
		{
			_arr = null;
			Invalidate();
		}

		#region Properties

		//свойство которое будет определять стиль обрамления
		private BevelStyle _style;

		[Category("Style"), Description("Свойство которое будет определять стиль обрамления")]
		[DefaultValue(typeof(BevelStyle), "Lowered")]
		public BevelStyle Style
		{
			get { return _style; }
			set
			{
				_style = value;
				Invalidate();
			}
		}

		//свойство определяющее форму обрамления
		private BevelShape _shape;

		[Category("Style"), Description("Свойство определяющее форму обрамления")]
		[DefaultValue(typeof(BevelShape), "Box")]
		public BevelShape Shape
		{
			get { return _shape; }
			set
			{
				_shape = value;
				Invalidate();
			}
		}

		//цвет обрамления
		[Category("Style"), Description("Цвет обрамления")]
		[DefaultValue(typeof(Color), "ButtonHighlight")]
		public Color BevelColor { get; set; }

		//цвет тени
		[Category("Style"), Description("Цвет тени")]
		[DefaultValue(typeof(Color), "ButtonShadow")]
		public Color BevelShadowColor { get; set; }

		//шаг сетки
		private int _bevelStep;

		/// <summary>
		///     шаг сетки
		/// </summary>
		[Category("Style"), Description("Размер клеток в сетке")]
		[DefaultValue(typeof(int), "10")]
		public int BevelLineStep
		{
			get { return _bevelStep; }
			set
			{
				_bevelStep = value;
				Invalidate();
			}
		}

		//карандаш
		private char _karandash;

		/// <summary>
		///     Чем будем рисовать
		/// </summary>
		[Category("Style"), Description("Символ для рисования карандашом")]
		[DefaultValue(typeof(int), "1")]
		public char BKarandash
		{
			get { return _karandash; }
			set
			{
				_karandash = value;
				Invalidate();
			}
		}

		//ластик
		private char _lastic;

		/// <summary>
		///     Чем будем стирать
		/// </summary>
		[Category("Style"), Description("Символ для стёрки")]
		[DefaultValue(typeof(int), "0")]
		public char BSterka
		{
			get { return _lastic; }
			set
			{
				_lastic = value;
				Invalidate();
			}
		}

		private Color _lastikColor;

		/// <summary>
		///     цвет ластика
		/// </summary>
		[Category("Style"), Description("Цвет закраски Ластик")]
		[DefaultValue(typeof(Color), "ButtonHighlight")]
		public Color LastikColor
		{
			get { return _lastikColor; }
			set
			{
				_lastikColor = value;
				Invalidate();
			}
		}

		private Color _karandashColor;

		/// <summary>
		///     цвет пера
		/// </summary>
		[Category("Style"), Description("Цвет закраски Карандаш")]
		[DefaultValue(typeof(Color), "ButtonHighlight")]
		public Color KarandashColor
		{
			get { return _karandashColor; }
			set
			{
				_karandashColor = value;
				Invalidate();
			}
		}

		private int _fontSize;

		/// <summary>
		///     Размер шрифта у линейки
		/// </summary>
		[Category("Style"), Description("Размер шрифта у линейки")]
		[DefaultValue(typeof(int), "5")]
		public int FontSize
		{
			get { return _fontSize; }
			set
			{
				_fontSize = value;
				Invalidate();
			}
		}

		/// <summary>
		///     свойство определяющее сторону отрисовки линейки
		/// </summary>
		private LineijFontPosition _lineijFontPos;

		[Category("Style"), Description("Выравнивание метки линейки внутри клетки.")]
		[DefaultValue(typeof(LineijFontPosition), "Left")]
		public LineijFontPosition LinFPos
		{
			get { return _lineijFontPos; }
			set
			{
				_lineijFontPos = value;
				Invalidate();
			}
		}

		#endregion
	}
}
