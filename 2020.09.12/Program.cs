using _2020._09._12.FigureMenus;
using System.Threading;

namespace _2020._09._12
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;

            do
            {
                int chois = Visualizer.ChoisOfFigure();
                int size = 0;
                FigureMenu figureMenu;

                switch (chois)
                {
                    case 1:
                        figureMenu = new PointMenu(Visualizer.START_X_POSITION
                            , Visualizer.START_Y_POSITION
                            , Visualizer.MENU_POINT);

                        figureMenu.RunMenu();
                        //PointMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION);
                        break;

                    case 2:
                        size = Visualizer.GiveFigureSize("Выберите размер ломаной линии : ");
                        PolylineMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 3:
                        size = Visualizer.GiveFigureSize("Выберите размер круга : ");
                        CirclMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 4:
                        size = Visualizer.GiveFigureSize("Выберите размер квадрата : ");
                        SquareMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 5:
                        size = Visualizer.GiveFigureSize("Выберите размер треугольника : ");
                        TriangleMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 6:
                        size = Visualizer.GiveFigureSize("Выберите размер ромба : ");
                        RombMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 7:
                        size = Visualizer.GiveFigureSize("Выберите размер круга в квадрате : ");
                        CircInSquareMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 8:
                        size = Visualizer.GiveFigureSize("Выберите размер ромба в круге : ");
                        RombInCircleMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
                        break;

                    case 9:
                        size = Visualizer.STANDART_SIZE_FIGURE;
                        PictureMenu(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);
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
            IFigure myPoint = new Point(startX, startY);

            do
            {
                Thread.Sleep(40);

                string[] menu = Visualizer.MENU_POINT;

                SetAction(menu, ref chois);

                Visualizer.ClearPoints(myPoint.CentrX, myPoint.CentrY);

                BL.ChangeFigure(chois, myPoint, ref result);

                if (result)
                {
                    Visualizer.PrintPoint(myPoint.CentrX, myPoint.CentrY, ColorFigure.Red);
                }
            } while (result);
        }

        static void PolylineMenu(int startX, int startY, int size)
        {
            InputUser chois = 0;
            bool result = true;
            Polyline myPolyline = new Polyline(startX + Visualizer.DISTANCE_FOR_X, startY, size);

            do
            {
                Thread.Sleep(40);

                string[] menu = Visualizer.MENU_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] polyline = myPolyline.GetView();

                    for (int i = 0; i < myPolyline.Length; i++)
                    {
                        Visualizer.ClearPoints(polyline[i].X, polyline[i].Y);
                    }
                }

                BL.ChangeFigure(chois, myPolyline, ref result);

                if (result)
                {
                    Coordinates[] polyline = myPolyline.GetView();

                    for (int i = 0; i < myPolyline.Length; i++)
                    {
                        Visualizer.PrintPoint(polyline[i].X, polyline[i].Y, ColorFigure.Magenta);
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

                string[] menu = Visualizer.MENU_SIMPLE_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] square = mySquare.GetView();

                    for (int i = 0; i < mySquare.Length; i++)
                    {
                        Visualizer.ClearPoints(square[i].X, square[i].Y);
                    }
                }

                BL.ChangeFigure(chois, mySquare, ref result);

                if (result)
                {
                    Coordinates[] forSquare = mySquare.GetView();

                    for (int i = 0; i < forSquare.Length; i++)
                    {
                        Visualizer.PrintPoint(forSquare[i].X, forSquare[i].Y, ColorFigure.Blue);
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

                string[] menu = Visualizer.MENU_SIMPLE_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] circle = myCircle.GetView();

                    for (int i = 0; i < myCircle.Length; i++)
                    {
                        Visualizer.ClearPoints(circle[i].X, circle[i].Y);
                    }
                }

                BL.ChangeFigure(chois, myCircle, ref result);

                if (result)
                {
                    Coordinates[] circle = myCircle.GetView();

                    for (int i = 0; i < myCircle.Length; i++)
                    {
                        Visualizer.PrintPoint(circle[i].X, circle[i].Y, ColorFigure.Green);
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

                string[] menu = Visualizer.MENU_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] triangle = myTriangle.GetView();

                    for (int i = 0; i < myTriangle.Length; i++)
                    {
                        Visualizer.ClearPoints(triangle[i].X, triangle[i].Y);
                    }
                }

                BL.ChangeFigure(chois, myTriangle, ref result);

                if (result)
                {
                    Coordinates[] triangl = myTriangle.GetView();

                    for (int i = 0; i < myTriangle.Length; i++)
                    {
                        Visualizer.PrintPoint(triangl[i].X, triangl[i].Y, ColorFigure.DarkYellow);
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

                string[] menu = Visualizer.MENU_SIMPLE_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] romb = myRomb.GetView();

                    for (int i = 0; i < myRomb.Length; i++)
                    {
                        Visualizer.ClearPoints(romb[i].X, romb[i].Y);
                    }
                }

                BL.ChangeFigure(chois, myRomb, ref result);

                if (result)
                {
                    Coordinates[] romb = myRomb.GetView();

                    for (int i = 0; i < romb.Length; i++)
                    {
                        Visualizer.PrintPoint(romb[i].X, romb[i].Y, ColorFigure.Cyan);
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

                string[] menu = Visualizer.MENU_SIMPLE_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] circleinSquare = figureCIS.GetView();

                    for (int i = 0; i < figureCIS.Length; i++)
                    {
                        Visualizer.ClearPoints(circleinSquare[i].X, circleinSquare[i].Y);
                    }
                }

                BL.ChangeFigure(chois, figureCIS, ref result);

                if (result)
                {
                    Coordinates[] circleinSquare = figureCIS.GetView();

                    for (int i = 0; i < circleinSquare.Length; i++)
                    {
                        if (i < figureCIS.LengthSquare)
                        {
                            Visualizer.PrintPoint(circleinSquare[i].X, circleinSquare[i].Y, ColorFigure.Blue);
                        }
                        else
                        {
                            Visualizer.PrintPoint(circleinSquare[i].X, circleinSquare[i].Y, ColorFigure.Green);
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

                string[] menu = Visualizer.MENU_SIMPLE_FIGURE;

                SetAction(menu, ref chois);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] rombInCircl = figureRC.GetView();

                    for (int i = 0; i < figureRC.Length; i++)
                    {
                        Visualizer.ClearPoints(rombInCircl[i].X, rombInCircl[i].Y);
                    }
                }

                BL.ChangeFigure(chois, figureRC, ref result);

                if (result)
                {
                    Coordinates[] rombInCircle = figureRC.GetView();

                    for (int i = 0; i < rombInCircle.Length; i++)
                    {
                        if (i < figureRC.LengthCircle)
                        {
                            Visualizer.PrintPoint(rombInCircle[i].X, rombInCircle[i].Y, ColorFigure.Green);
                        }
                        else
                        {
                            Visualizer.PrintPoint(rombInCircle[i].X, rombInCircle[i].Y, ColorFigure.Cyan);
                        }
                    }
                }
            } while (result);
        }

        static void PictureMenu(int startX, int startY, int size)
        {
            IFigure circl = new Circle(startX, startY, size);
            IFigure square = new Square(circl.CentrX + Visualizer.DISTANCE_FOR_X, circl.CentrY, size);
            IFigure triangle = new Triangle(square.CentrX + Visualizer.DISTANCE_FOR_X, square.CentrY, size);
            IFigure romb = new Romb(triangle.CentrX + Visualizer.DISTANCE_FOR_X, triangle.CentrY, size);
            IFigure cirqlInSquare = new CirclInSquare(square.CentrX, square.CentrY + Visualizer.DISTANCE_FOR_Y, size);
            IFigure rombInCircle = new RombInCircl(triangle.CentrX, triangle.CentrY + Visualizer.DISTANCE_FOR_Y, size);

            Picture allFigure = new Picture(circl, square, triangle, romb, cirqlInSquare, rombInCircle);

            int figure = 0;
            FigureImput chois = 0;
            bool result = true;

            do
            {
                Coordinates[] allFigr = allFigure.GetView();

                for (int i = 0; i < allFigr.Length; i++)
                {
                    Visualizer.PrintPoint(allFigr[i].X, allFigr[i].Y, ColorFigure.Green);
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
            FigureImput figure = FigureImput.NoFigure;
            int chFigure = 0;

            do
            {
                do
                {
                    figure = Controller.SetFigure();
                    Visualizer.ChoisFigureOnPicture(ref figure);
                } while (figure < FigureImput.Circle);

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
                            Visualizer.PrintPoint(tmpFigure[j].X, tmpFigure[j].Y, color);
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
                string[] menu = Visualizer.MENU_FIGURE;

                SetAction(menu, ref chois);

                Thread.Sleep(40);

                if (chois != InputUser.Escape)
                {
                    Coordinates[] tmpFigure = allFigure[figure].GetView();

                    for (int j = 0; j < tmpFigure.Length; j++)
                    {
                        Visualizer.ClearPoints(tmpFigure[j].X, tmpFigure[j].Y);
                    }
                }

                BL.ChangeFigure(chois, chosenFigure, ref result);

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
                            Visualizer.PrintPoint(tmpFigure[j].X, tmpFigure[j].Y, color);
                        }
                    }
                }
            } while (result);

            Visualizer.ClearMasseges(Visualizer.MENU_FIGURE);
        }

        static void SetAction(string[] menu, ref InputUser chois)
        {
            do
            {
                Visualizer.ChooseActionForFigure(menu, chois);
                chois = Controller.SetKurse();
            } while (chois < InputUser.LeftArrow || chois > (InputUser)menu.Length);
        }
    }
}
