namespace _2020._09._12
{
    class CirclInSquare : Circle
    {
        public const int QUANTITY_OF_SIDES = 4;
        private Square _inSquare;

        public CirclInSquare(int x, int y, int radius)
            : base(x, y, radius)
        {
            if (radius < 1)
            {
                radius = 1;
            }

            _inSquare = new Square(start.X, start.Y, radius);
        }

        public override int Length
        {
            get
            {
                int lenght = 0;

                if (_circl != null && _inSquare.Length != 0)
                {
                    lenght = _circl.Length + _inSquare.Length;
                }

                return lenght;
            }
        }

        public int LengthSquare
        {
            get { return _inSquare.Length; }
        }

        public override void MoveByX(int unit)
        {
            base.MoveByX(unit);
            _inSquare.MoveByX(unit);
        }

        public override void MoveByY(int unit)
        {
            base.MoveByY(unit);
            _inSquare.MoveByY(unit);
        }

        public override void ChangeSize(int unit)
        {
            base.ChangeSize(unit);
            _inSquare.ChangeSize(unit);
        }

        public override Coordinates[] GetView()
        {
            Coordinates[] circle = base.GetView();
            Coordinates[] square = _inSquare.GetView();

            Coordinates[] circleInSquare = new Coordinates[circle.Length + _inSquare.Length];

            for (int i = 0; i < circleInSquare.Length; i++)
            {
                if (i < _inSquare.Length)
                {
                    circleInSquare[i].X = square[i].X;
                    circleInSquare[i].Y = square[i].Y;
                }
                else
                {
                    circleInSquare[i].X = circle[i - _inSquare.Length].X;
                    circleInSquare[i].Y = circle[i - _inSquare.Length].Y;
                }
            }

            return circleInSquare;
        }

        public override object GetCopy()
        {
            CirclInSquare copy = (CirclInSquare)MemberwiseClone();
            copy._circl = (Coordinates[])_circl.Clone();
            copy._inSquare = (Square)_inSquare.GetCopy();

            return copy;
        }
    }
}
