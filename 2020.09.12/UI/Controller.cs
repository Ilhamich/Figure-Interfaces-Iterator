using System;

namespace _2020._09._12
{
    class Controller
    {
        public static InputUser SetKurse()
        {
            ConsoleKey keyReal = 0;
            InputUser key = 0;

            keyReal = Console.ReadKey().Key;

            switch (keyReal)
            {
                case ConsoleKey.LeftArrow:
                    key = InputUser.LeftArrow;
                    break;

                case ConsoleKey.UpArrow:
                    key = InputUser.UpArrow;
                    break;

                case ConsoleKey.RightArrow:
                    key = InputUser.RightArrow;
                    break;

                case ConsoleKey.DownArrow:
                    key = InputUser.DownArrow;
                    break;

                case ConsoleKey.Add:
                    key = InputUser.Plus;
                    break;

                case ConsoleKey.Subtract:
                    key = InputUser.Minus;
                    break;

                case ConsoleKey.Enter:
                    key = InputUser.Enter;
                    break;

                case ConsoleKey.Escape:
                    key = InputUser.Escape;
                    break;

                case ConsoleKey.Divide:
                    key = InputUser.Turn;
                    break;

                default:
                    key = InputUser.NoDirection;
                    break;
            }

            return key;
        }

        public static FigureImput SetFigure()
        {
            ConsoleKey keyReal = 0;
            FigureImput key = 0;

            keyReal = Console.ReadKey().Key;

            switch (keyReal)
            {
                case ConsoleKey.D1:
                    key = FigureImput.Circle;
                    break;
                case ConsoleKey.NumPad1:
                    key = FigureImput.Circle;
                    break;
                case ConsoleKey.D2:
                    key = FigureImput.Square;
                    break;
                case ConsoleKey.NumPad2:
                    key = FigureImput.Square;
                    break;
                case ConsoleKey.D3:
                    key = FigureImput.Triangle;
                    break;
                case ConsoleKey.NumPad3:
                    key = FigureImput.Triangle;
                    break;
                case ConsoleKey.D4:
                    key = FigureImput.Romb;
                    break;
                case ConsoleKey.NumPad4:
                    key = FigureImput.Romb;
                    break;
                case ConsoleKey.D5:
                    key = FigureImput.CircleInSquare;
                    break;
                case ConsoleKey.NumPad5:
                    key = FigureImput.CircleInSquare;
                    break;
                case ConsoleKey.D6:
                    key = FigureImput.RombinCircle;
                    break;
                case ConsoleKey.NumPad6:
                    key = FigureImput.RombinCircle;
                    break;
                case ConsoleKey.Enter:
                    key = FigureImput.Enter;
                    break;
                case ConsoleKey.Escape:
                    key = FigureImput.Escape;
                    break;
                default:
                    key = FigureImput.NoFigure;
                    break;
            }

            return key;
        }
    }
}
