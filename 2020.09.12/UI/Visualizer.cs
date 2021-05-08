using System;

namespace _2020._09._12
{
    class Visualizer
    {
        public const int QUNTITY_OF_FIGURE = 9;
        public const int START_X_POSITION = 30;
        public const int START_Y_POSITION = 6;
        public const int DISTANCE_FOR_X = 20;
        public const int DISTANCE_FOR_Y = 15;
        public const int STANDART_SIZE_FIGURE = 5;
        public const int QUNTITY_FIGURE_ON_PICTURE = 6;

        public static readonly string[] MENU_POINT =
           {
                "Подвинуть влево : ←" , "Подвинуть вправо : →",
                "Подвинуть вверх : ↑", "Подвинуть вниз : ↓",
                "Показать : Enter", "Выход : Esc"
           };

        public static readonly string[] MENU_FIGURE =
           {
                "Подвинуть влево : ←" , "Подвинуть вправо : →",
                "Подвинуть вверх : ↑", "Подвинуть вниз : ↓", "Увеличить : +",
                "Уменьшить : -", "Повернуть = /", "Показать : Enter", "Выход : Esc"
           };

        public static readonly string[] MENU_SIMPLE_FIGURE =
           {
                "Подвинуть влево : ←" , "Подвинуть вправо : →",
                "Подвинуть вверх : ↑", "Подвинуть вниз : ↓", "Увеличить : +",
                "Уменьшить : -", "Показать : Enter", "Выход : Esc"
           };

        public static void PrintPoint(int x, int y, ColorFigure color)
        {
            Console.ForegroundColor = (ConsoleColor)(short)color;

            if (x >= 0 && y >= 0
                    && x < Console.WindowWidth && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }

            Console.ResetColor();
        }

        public static void ClearAllField()
        {
            Console.Clear();
        }

        public static void ClearPoints(int x, int y)
        {
            if (x >= 0 && y >= 0
                    && x < Console.WindowWidth && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
            }
        }

        public static void ClearLine(int x, int y, string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                x++;
            }
        }

        public static void ClearMasseges(string[] massages, int xForClear = 0, int yForClear = 0)
        {
            int tmpX = xForClear;
            string offer = "Выберите действие : ";

            for (int j = 0; j <= offer.Length; j++)
            {
                Console.SetCursorPosition(xForClear++, yForClear);
                Console.Write(' ');
            }

            xForClear = 0;

            for (int i = 0; i < massages.Length; i++)
            {
                Console.SetCursorPosition(xForClear, yForClear++);

                for (int j = 0; j < massages[i].Length; j++)
                {
                    Console.SetCursorPosition(xForClear++, yForClear);
                    Console.Write(' ');
                }

                xForClear = tmpX;
            }
        }

        public static int ChoisOfFigure()
        {
            Console.Clear();

            bool result = true;
            int chois;
            string offer = "Выберите фигуру : ";
            string[] menu =
            {
                    offer, "Точка : 1", "Ломаная линия : 2", "Круг : 3",
                    "Квадрат : 4", "Трехугольник : 5", "Ромб : 6",
                    "Круг в Квадрете : 7", "Ромб в круге : 8",
                    "Все фигуры : 9", "Выход : 0", "Подтвердить выбор : Enter"
            };

            do
            {
                int xForPrint = 0;
                int yForPrint = 0;

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        if (i != menu.Length - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }

                    Console.SetCursorPosition(xForPrint, yForPrint++);
                    Console.Write(menu[i]);
                }

                Console.ResetColor();
                yForPrint = 0;

                Console.SetCursorPosition(xForPrint + offer.Length, yForPrint);
                string figure = Console.ReadLine();

                result = !int.TryParse(figure, out chois);

                if (result || chois < 0 || chois > QUNTITY_OF_FIGURE)
                {
                    ClearLine(xForPrint + offer.Length, yForPrint, figure);
                }

            } while (result || chois < 0 || chois > QUNTITY_OF_FIGURE);

            Console.Clear();

            return chois;
        }

        public static void ChoisFigureOnPicture(ref FigureImput chois)
        {
            int xForPrint = 0;
            int yForPrint = 0;
            string offer = "Выберите фигуру : ";
            string[] menu =
            {
                offer, "Круг : 1", "Квадрат : 2", "Трехугольник : 3",
                "Ромб : 4", "Круг в Квадрете : 5", "Ромб в круге : 6",
                "Выбрать : Enter", "Выход : Esc"
            };

            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(xForPrint, yForPrint++);
                Console.Write(menu[i]);
            }

            yForPrint = 0;

            Console.SetCursorPosition(xForPrint + offer.Length, yForPrint);

            if (chois < FigureImput.Circle)
            {
                ClearLine(xForPrint + offer.Length, yForPrint, " ");
            }

            if (chois == FigureImput.Enter || chois == FigureImput.Escape)
            {
                ClearLine(xForPrint + offer.Length, yForPrint, " ");

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.SetCursorPosition(xForPrint, yForPrint);
                    ClearLine(xForPrint, yForPrint++, menu[i]);
                }
            }
        }

        public static int GiveFigureSize(string line)
        {
            int size;
            bool result = true;

            do
            {
                int xForPrint = 0;
                int yForPrint = 0;
                string offer = line;

                Console.SetCursorPosition(xForPrint, yForPrint);
                Console.Write(offer);

                string chois = Console.ReadLine();
                result = !int.TryParse(chois, out size);

                if (result)
                {
                    ClearLine(xForPrint + offer.Length, yForPrint, chois);
                }
            } while (result);

            Console.Clear();

            return size;
        }

        public static void ChooseActionForFigure(string[] menu, InputUser key)
        {
            int xForPrint = 0;
            int yForPrint = 0;
            string offer = "Выберите действие : ";

            Console.SetCursorPosition(xForPrint, yForPrint++);
            Console.Write(offer);

            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(xForPrint, yForPrint++);
                Console.Write(menu[i]);
            }

            yForPrint = 0;

            Console.SetCursorPosition(xForPrint + offer.Length, yForPrint);

            if (key < InputUser.LeftArrow || key > (InputUser)menu.Length)
            {
                ClearLine(xForPrint + offer.Length, yForPrint, " ");
            }
        }
    }
}
