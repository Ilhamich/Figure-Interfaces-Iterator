using _2020._09._12.FigureMenus;
using _2020._09._12.Interfaces;
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
                Coordinates start = new Coordinates(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION); ;
                IFigure figure;

                IMultiFigure multiFigure;
                MultiFigureMenu multiFigureMenu;
                ColorFigure[] colors;

                switch (chois)
                {
                    case 1:
                        figureMenu = new PointMenu(start, Visualizer.MENU_POINT, ColorFigure.Red);
                        figureMenu.RunMenu();
                        break;

                    case 2:
                        size = Visualizer.GiveFigureSize("Выберите размер ломаной линии : ");
                        figure = new Polyline(start.X + Visualizer.DISTANCE_FOR_X, start.Y, size);

                        figureMenu = new SingleFigureMenu(Visualizer.MENU_FIGURE
                            , figure
                            , ColorFigure.Magenta);

                        figureMenu.RunMenu();
                        break;

                    case 3:
                        size = Visualizer.GiveFigureSize("Выберите размер круга : ");
                        figure = new Circle(start.X, start.Y, size);

                        figureMenu = new SingleFigureMenu(Visualizer.MENU_SIMPLE_FIGURE
                            , figure
                            , ColorFigure.Green);

                        figureMenu.RunMenu();
                        break;

                    case 4:
                        size = Visualizer.GiveFigureSize("Выберите размер квадрата : ");
                        figure = new Square(start.X, start.Y, size);

                        figureMenu = new SingleFigureMenu(Visualizer.MENU_SIMPLE_FIGURE
                            , figure
                            , ColorFigure.Blue);

                        figureMenu.RunMenu();
                        break;

                    case 5:
                        size = Visualizer.GiveFigureSize("Выберите размер треугольника : ");
                        figure = new Triangle(start.X, start.Y, size);

                        figureMenu = new SingleFigureMenu(Visualizer.MENU_FIGURE
                            , figure
                            , ColorFigure.DarkYellow);

                        figureMenu.RunMenu();
                        break;

                    case 6:
                        size = Visualizer.GiveFigureSize("Выберите размер ромба : ");
                        figure = new Romb(start.X, start.Y, size);

                        figureMenu = new SingleFigureMenu(Visualizer.MENU_SIMPLE_FIGURE
                            , figure
                            , ColorFigure.Cyan);

                        figureMenu.RunMenu();
                        break;

                    case 7:
                        size = Visualizer.GiveFigureSize("Выберите размер круга в квадрате : ");
                        multiFigure = new CirclInSquare(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);

                        colors = new ColorFigure[] { ColorFigure.Green, ColorFigure.Blue };

                        multiFigureMenu = new MultiFigureMenu(Visualizer.MENU_SIMPLE_FIGURE
                            , multiFigure
                            , colors);

                        multiFigureMenu.RunMenu();
                        break;

                    case 8:
                        size = Visualizer.GiveFigureSize("Выберите размер ромба в круге : ");
                        multiFigure = new RombInCircl(Visualizer.START_X_POSITION, Visualizer.START_Y_POSITION, size);

                        colors = new ColorFigure[] {ColorFigure.Cyan, ColorFigure.Green};

                        multiFigureMenu = new MultiFigureMenu(Visualizer.MENU_SIMPLE_FIGURE
                            , multiFigure
                            , colors);

                        multiFigureMenu.RunMenu();
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
