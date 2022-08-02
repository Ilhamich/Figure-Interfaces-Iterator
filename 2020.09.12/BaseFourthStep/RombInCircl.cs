namespace _2020._09._12
{
    class RombInCircl : Romb
    {
        private Circle _circleOut;

        public RombInCircl(int x, int y, int size)
            : base(x, y, size)
        {
            if (size < MINIMAL_SIZE)
            {
                size = MINIMAL_SIZE;
            }
            _circleOut = new Circle(_start.X, _start.Y, size);
        }

        public override int Length
        {
            get
            {
                int lenght = 0;

                if (_triangl != null && _circleOut.Length != 0)
                {
                    lenght = _triangl.Length + _circleOut.Length;
                }

                return lenght;
            }
        }

        public int LengthCircle
        {
            get
            {
                return _circleOut.Length;
            }
        }

        public override void MoveByY(int unit)
        {
            base.MoveByY(unit);
            _circleOut.MoveByY(unit);
        }

        public override void MoveByX(int unit)
        {
            base.MoveByX(unit);
            _circleOut.MoveByX(unit);
        }

        public override void ChangeSize(int unit)
        {
            base.ChangeSize(unit);

            if (!((_circleOut.Radius + unit) < MINIMAL_SIZE))
            {
                _circleOut.ChangeSize(unit);
            }
        }

        public override Coordinates[] GetView()
        {
            Coordinates[] romb = base.GetView();
            Coordinates[] circle = _circleOut.GetView();
            Coordinates[] rombInCircle = new Coordinates[romb.Length + circle.Length];

            for (int i = 0; i < rombInCircle.Length; i++)
            {
                if (i < circle.Length)
                {
                    rombInCircle[i].X = circle[i].X;
                    rombInCircle[i].Y = circle[i].Y;
                }
                else
                {
                    rombInCircle[i].X = romb[i - circle.Length].X;
                    rombInCircle[i].Y = romb[i - circle.Length].Y;
                }
            }

            return rombInCircle;
        }

        public override IFigure GetCopy()
        {
            RombInCircl copy = (RombInCircl)MemberwiseClone();
            copy._triangl = (Coordinates[])_triangl.Clone();
            copy._circleOut = (Circle)_circleOut.GetCopy();

            return copy;
        }
    }
}
