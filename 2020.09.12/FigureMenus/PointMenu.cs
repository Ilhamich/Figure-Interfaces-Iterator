namespace _2020._09._12.FigureMenus
{
    internal class PointMenu : FigureMenu
    {
        public PointMenu(Coordinates start, string[] listMenu, ColorFigure color)
            : base(listMenu, color)
        {
            _figure = new Point(start);
        }

        public override void RunMenu()
        {
            do
            {
                base.RunMenu();

                Visualizer.ClearPoints(_figure.CentrX, _figure.CentrY);

                BL.ChangeFigure(_chois, _figure, ref _result);

                if (_result)
                    Visualizer.PrintPoint(_figure.CentrX, _figure.CentrY, _color);

            } while (_result);
        }
    }
}
