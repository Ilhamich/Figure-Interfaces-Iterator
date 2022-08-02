using System.Threading;

namespace _2020._09._12.FigureMenus
{
    public interface IFigureMenu
    {
        void RunMenu();
    }

    public class FigureMenu : IFigureMenu
    {
        protected InputUser _chois;
        protected ColorFigure _color;
        protected bool _result;
        protected IFigure _figure;
        protected string[] _listMenu;

        public FigureMenu(string[] listMenu, ColorFigure color)
        {
            _chois = 0;
            _result = true;
            _listMenu = listMenu;
            _color = color;
        }

        public virtual void RunMenu()
        {
            Thread.Sleep(40);
            SetAction();
        }

        protected void SetAction()
        {
            do
            {
                Visualizer.ChooseActionForFigure(_listMenu, _chois);
                _chois = Controller.SetKurse();
            } while (_chois < InputUser.LeftArrow || _chois > (InputUser)_listMenu.Length);
        }
    }
}
