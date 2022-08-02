using _2020._09._12.Interfaces;

namespace _2020._09._12
{
    public class CirclInSquare : Circle , IMultiFigure
    {
        public const int QUANTITY_OF_SIDES = 4;
        private Square _externalSquare;

        public CirclInSquare(int x, int y, int radius)
            : base(x, y, radius)
        {
            if (radius < 1)
            {
                radius = 1;
            }

            _externalSquare = new Square(_start.X, _start.Y, radius);
        }

        public override int Length
        {
            get
            {
                int lenght = 0;

                if (_circl != null && _externalSquare.Length != 0)
                {
                    lenght = _circl.Length + _externalSquare.Length;
                }

                return lenght;
            }
        }

        public int ExternalFigureLength
        {
            get { return _externalSquare.Length; }
        }

        public override void MoveByX(int unit)
        {
            base.MoveByX(unit);
            _externalSquare.MoveByX(unit);
        }

        public override void MoveByY(int unit)
        {
            base.MoveByY(unit);
            _externalSquare.MoveByY(unit);
        }

        public override void ChangeSize(int unit)
        {
            base.ChangeSize(unit);
            _externalSquare.ChangeSize(unit);
        }

        public override Coordinates[] GetView()
        {
            Coordinates[] circle = base.GetView();
            Coordinates[] square = _externalSquare.GetView();

            Coordinates[] circleInSquare = new Coordinates[circle.Length + _externalSquare.Length];

            for (int i = 0; i < circleInSquare.Length; i++)
            {
                if (i < _externalSquare.Length)
                {
                    circleInSquare[i].X = square[i].X;
                    circleInSquare[i].Y = square[i].Y;
                }
                else
                {
                    circleInSquare[i].X = circle[i - _externalSquare.Length].X;
                    circleInSquare[i].Y = circle[i - _externalSquare.Length].Y;
                }
            }

            return circleInSquare;
        }

        public override IFigure GetCopy()
        {
            CirclInSquare copy = (CirclInSquare)MemberwiseClone();
            copy._circl = (Coordinates[])_circl.Clone();
            copy._externalSquare = (Square)_externalSquare.GetCopy();

            return copy;
        }
    }
}
