using System.Threading;

namespace _2020._09._12.FigureMenus
{
    internal class PointMenu : FigureMenu
    {
        public PointMenu(int startX, int startY, string[] listMenu)
            :base(listMenu)
        {
            _figure = new Point(startX, startY);
        }

        public override void RunMenu()
        {
            do
            {
                base.RunMenu();

                Visualizer.ClearPoints(_figure.CentrX, _figure.CentrY);

                BL.ChangeFigure(_chois, _figure, ref _result);

                if (_result)
                    Visualizer.PrintPoint(_figure.CentrX, _figure.CentrY, ColorFigure.Red);
                
            } while (_result);
        }
    }
}
