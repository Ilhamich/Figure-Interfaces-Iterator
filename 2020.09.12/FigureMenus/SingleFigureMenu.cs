namespace _2020._09._12.FigureMenus
{
    public class SingleFigureMenu : FigureMenu
    {
        public SingleFigureMenu(string[] listMenu, IFigure figure, ColorFigure color)
            : base(listMenu, color)
        {
            _figure = figure;
        }

        public override void RunMenu() 
        {
            do
            {
                base.RunMenu();

                if (_chois != InputUser.Escape)
                {
                    Coordinates[] figurePoints = _figure.GetView();

                    for (int i = 0; i < _figure.Length; i++)
                    {
                        Visualizer.ClearPoints(figurePoints[i].X, figurePoints[i].Y);
                    }
                }

                BL.ChangeFigure(_chois, _figure, ref _result);

                if (_result)
                {
                    Coordinates[] figurePoints = _figure.GetView();

                    for (int i = 0; i < _figure.Length; i++)
                    {
                        Visualizer.PrintPoint(figurePoints[i].X, figurePoints[i].Y, _color);
                    }
                }
            } while (_result);
        }
    }
}
