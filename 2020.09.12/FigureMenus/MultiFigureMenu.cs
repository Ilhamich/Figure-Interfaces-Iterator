using _2020._09._12.Interfaces;

namespace _2020._09._12.FigureMenus
{
    public class MultiFigureMenu : FigureMenu
    {
        ColorFigure _externalColor;

        public MultiFigureMenu(string[] listMenu, IMultiFigure figure, ColorFigure[] colors)
            : base(listMenu, colors[0])
        {
            _figure = figure;
            _externalColor = colors[1];
        }

        public override void RunMenu()
        {
            do
            {
                base.RunMenu();

                if (_chois != InputUser.Escape)
                {
                    Coordinates[] multiFigure = _figure.GetView();

                    for (int i = 0; i < _figure.Length; i++)
                    {
                        Visualizer.ClearPoints(multiFigure[i].X, multiFigure[i].Y);
                    }
                }

                BL.ChangeFigure(_chois, _figure, ref _result);

                if (_result)
                {
                    Coordinates[] multiFigure = _figure.GetView();

                    for (int i = 0; i < multiFigure.Length; i++)
                    {
                        if (i < ((IMultiFigure)_figure).ExternalFigureLength)
                        {
                            Visualizer.PrintPoint(multiFigure[i].X, multiFigure[i].Y, _externalColor);
                        }
                        else
                        {
                            Visualizer.PrintPoint(multiFigure[i].X, multiFigure[i].Y, _color);
                        }
                    }
                }
            } while (_result);
        }
    }
}
