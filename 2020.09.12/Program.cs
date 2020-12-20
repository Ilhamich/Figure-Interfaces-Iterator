using System;
using System.Text;
using System.Collections;
using System.Threading;

namespace _2020._09._12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            bool exit = true;

            do
            {
                int chois = UI.ChoisOfFigure();
                int size = 0;

                switch (chois)
                {
                    case 1:
                        PointMenu(UI.START_X_POSITION, UI.START_Y_POSITION);
                        break;

                    case 2:
                        size = UI.GiveFigureSize("Выберите размер ломаной линии : ");
                        PolylineMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 3:
                        size = UI.GiveFigureSize("Выберите размер круга : ");
                        CirclMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 4:
                        size = UI.GiveFigureSize("Выберите размер квадрата : ");
                        SquareMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 5:
                        size = UI.GiveFigureSize("Выберите размер треугольника : ");
                        TriangleMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 6:
                        size = UI.GiveFigureSize("Выберите размер ромба : ");
                        RombMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 7:
                        size = UI.GiveFigureSize("Выберите размер круга в квадрате : ");
                        CircInSquareMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 8:
                        size = UI.GiveFigureSize("Выберите размер ромба в круге : ");
                        RombInCircleMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    case 9:
                        size = UI.STANDART_SIZE_FIGURE;
                        PictureMenu(UI.START_X_POSITION, UI.START_Y_POSITION, size);
                        break;

                    default:
                        exit = false;
                        break;
                }
            } while (exit);
        }
    
        static void PointMenu(int startX, int startY)
        {
            InputUser chois = 0;
            bool result = true;
            Point myPoint = new Point(startX, startY);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_POINT;
              
                chois = UI.ChooseActionForFigure(menu);
                UI.ClearPoints(myPoint.CentrX, myPoint.CentrY);

                BL.ChangeFigure(chois, ref result, myPoint);

                if (result)
                {
                    UI.PrintPoint(myPoint.CentrX, myPoint.CentrY, ColorFigure.Red);
                }
            } while (result);
        }

        static void PolylineMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Polyline myPolyline = new Polyline(startX + UI.DISTANCE_FOR_X, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_FIGURE;
              
                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] polyline = myPolyline.GetView();

                    for (int i = 0; i < myPolyline.Length; i++)
                    {
                        UI.ClearPoints(polyline[i].X, polyline[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, myPolyline);

                if (result)
                {
                    Coordinates[] polyline = myPolyline.GetView();

                    for (int i = 0; i < myPolyline.Length; i++)
                    {
                        UI.PrintPoint(polyline[i].X, polyline[i].Y, ColorFigure.Magenta);
                    }
                }
            } while (result);
        }

        static void SquareMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Square mySquare = new Square(startX, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_SIMPLE_FIGURE;

                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] square = mySquare.GetView();

                    for (int i = 0; i < mySquare.Length; i++)
                    {
                        UI.ClearPoints(square[i].X, square[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, mySquare);

                if (result)
                {
                    Coordinates[] forSquare = mySquare.GetView();

                    for (int i = 0; i < forSquare.Length; i++)
                    {
                        UI.PrintPoint(forSquare[i].X, forSquare[i].Y, ColorFigure.Blue);
                    }
                }
            } while (result);
        }

        static void CirclMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Circle myCircle = new Circle(startX, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_SIMPLE_FIGURE;

                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] circle = myCircle.GetView();

                    for (int i = 0; i < myCircle.Length; i++)
                    {
                        UI.ClearPoints(circle[i].X, circle[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, myCircle);

                if (result)
                {
                    Coordinates[] circle = myCircle.GetView();

                    for (int i = 0; i < myCircle.Length; i++)
                    {
                        UI.PrintPoint(circle[i].X, circle[i].Y, ColorFigure.Green);
                    }
                }
            } while (result);
        }

        static void TriangleMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Triangle myTriangle = new Triangle(startX, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_FIGURE;

                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] triangle = myTriangle.GetView();

                    for (int i = 0; i < myTriangle.Length; i++)
                    {
                        UI.ClearPoints(triangle[i].X, triangle[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, myTriangle);

                if (result)
                {
                    Coordinates[] triangl = myTriangle.GetView();

                    for (int i = 0; i < myTriangle.Length; i++)
                    {
                        UI.PrintPoint(triangl[i].X, triangl[i].Y, ColorFigure.DarkYellow);
                    }
                }
            } while (result);
        }

        static void RombMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Romb myRomb = new Romb(startX, startY, size);
            
            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_SIMPLE_FIGURE;

                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] romb = myRomb.GetView();

                    for (int i = 0; i < myRomb.Length; i++)
                    {
                        UI.ClearPoints(romb[i].X, romb[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, myRomb);

                if (result)
                {
                    Coordinates[] romb = myRomb.GetView();

                    for (int i = 0; i < romb.Length; i++)
                    {
                        UI.PrintPoint(romb[i].X, romb[i].Y, ColorFigure.Cyan);
                    }
                }
            } while (result);
        }

        static void CircInSquareMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            CirclInSquare figureCIS = new CirclInSquare(startX, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_SIMPLE_FIGURE;
          
                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] circleinSquare = figureCIS.GetView();

                    for (int i = 0; i < figureCIS.Length; i++)
                    {
                        UI.ClearPoints(circleinSquare[i].X, circleinSquare[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, figureCIS);

                if (result)
                {
                    Coordinates[] circleinSquare = figureCIS.GetView();

                    for (int i = 0; i < circleinSquare.Length; i++)
                    {
                        if (i < figureCIS.LengthSquare)
                        {
                            UI.PrintPoint(circleinSquare[i].X, circleinSquare[i].Y, ColorFigure.Blue);
                        }
                        else
                        {
                            UI.PrintPoint(circleinSquare[i].X, circleinSquare[i].Y, ColorFigure.Green);
                        }
                    }
                }
            } while (result);
        }

        static void RombInCircleMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            RombInCircl figureRC = new RombInCircl(startX, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = UI.MENU_SIMPLE_FIGURE;
            
                chois = UI.ChooseActionForFigure(menu);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] rombInCircl = figureRC.GetView();

                    for (int i = 0; i < figureRC.Length; i++)
                    {
                        UI.ClearPoints(rombInCircl[i].X, rombInCircl[i].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, figureRC);

                if (result)
                {
                    Coordinates[] rombInCircle = figureRC.GetView();

                    for (int i = 0; i < rombInCircle.Length; i++)
                    {
                        if (i < figureRC.LengthCircle)
                        {
                            UI.PrintPoint(rombInCircle[i].X, rombInCircle[i].Y, ColorFigure.Green);
                        }
                        else
                        {
                            UI.PrintPoint(rombInCircle[i].X, rombInCircle[i].Y, ColorFigure.Cyan);
                        }
                    }
                }
            } while (result);
        }

        static void PictureMenu(int startX, int startY, int size)
        {
            IFigure circl = new Circle(startX, startY, size);
            IFigure square = new Square(circl.CentrX + UI.DISTANCE_FOR_X,
                    circl.CentrY, size);
            IFigure triangle = new Triangle(square.CentrX + UI.DISTANCE_FOR_X,
                    square.CentrY, size);
            IFigure romb = new Romb(triangle.CentrX + UI.DISTANCE_FOR_X,
                   triangle.CentrY, size);
            IFigure cirqlInSquare = new CirclInSquare(square.CentrX,
                    square.CentrY + UI.DISTANCE_FOR_Y, size);
            IFigure rombInCircle = new RombInCircl(triangle.CentrX,
                    triangle.CentrY + UI.DISTANCE_FOR_Y, size);

            Picture allFigure = new Picture(circl, square, triangle, romb,
                    cirqlInSquare, rombInCircle);

            //if (allFigure is IFigure f)
            //{
            //    f.MoveByY(1);
            //}

            //foreach (IFigure item in allFigure)
            //{
            //    Coordinates[] allFigr = item.GetView();
            //}

            //((IEnumerable)allFigure).GetEnumerator();

            int figure = 0;
            FigureImput chois = 0;
            bool result = true;

            do
            {
                Coordinates[] allFigr = allFigure.GetView();

                for (int i = 0; i < allFigr.Length; i++)
                {
                    UI.PrintPoint(allFigr[i].X, allFigr[i].Y, ColorFigure.Green);
                }

                figure = ChooseFigureOnPicture(ref chois, allFigure);

                if (chois == FigureImput.Enter)
                {
                    FiguresMenu(allFigure, figure);
                }
                else
                {
                    if (chois == FigureImput.Escape)
                    {
                        result = false;
                    }
                }
            } while (result);
        }

        static int ChooseFigureOnPicture(ref FigureImput chois, Picture allFigure)
        {
            FigureImput figure;
            int chFigure = 0;

            do
            {
                figure = UI.ChoisFigureOnPicture();
                Thread.Sleep(40);

                if (figure != FigureImput.Enter && figure != FigureImput.Escape)
                {
                    chFigure = (byte)figure - 1;
                    chois = figure;
                    ColorFigure color = ColorFigure.Green;

                    for (int i = 0; i < allFigure.Length; i++)
                    {
                        Coordinates[] tmpFigure = allFigure[i].GetView();

                        if (i != (byte)figure - 1)
                        {
                            color = ColorFigure.Green;
                        }
                        else
                        {
                            color = ColorFigure.Magenta;
                        }

                        for (int j = 0; j < tmpFigure.Length; j++)
                        {
                            UI.PrintPoint(tmpFigure[j].X, tmpFigure[j].Y, color);
                        }
                    }
                }
                else
                {
                    chois = figure;
                }
            } while (chois != FigureImput.Enter && chois != FigureImput.Escape);

            return chFigure;
        }

        static void FiguresMenu(Picture allFigure, int figure)
        {
            InputUser chois = 0;
            bool result = true;
            IFigure chosenFigure = allFigure[figure];

            do
            {
                string[] menu = UI.MENU_FIGURE;

                chois = UI.ChooseActionForFigure(menu);

                Thread.Sleep(40);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] tmpFigure = allFigure[figure].GetView();

                    for (int j = 0; j < tmpFigure.Length; j++)
                    {
                        UI.ClearPoints(tmpFigure[j].X, tmpFigure[j].Y);
                    }
                }

                BL.ChangeFigure(chois, ref result, chosenFigure);

                allFigure[figure] = chosenFigure;

                if (result)
                {
                    for (int i = 0; i < allFigure.Length; i++)
                    {
                        Coordinates[] tmpFigure = allFigure[i].GetView();
                        ColorFigure color = ColorFigure.Green;

                        if (i == figure)
                        {
                            color = ColorFigure.Magenta;
                        }

                        for (int j = 0; j < tmpFigure.Length; j++)
                        {
                            UI.PrintPoint(tmpFigure[j].X, tmpFigure[j].Y, color);
                        }
                    }
                }
            } while (result);

            UI.ClearMasseges(UI.MENU_FIGURE);
        }
    }
}
