namespace _2020._09._12
{
    class Point : IFigure
    {
        protected Coordinates _start;
        private const int POINT_ELEMENTS_LENGTH = 1;

        public Point(Coordinates start)
        {
            _start = start;
        }

        public Point(int num)
            : this(new Coordinates(num, num))
        {
        }

        public virtual void MoveByY(int unit)
        {
            _start.Y += unit;
        }

        public virtual void MoveByX(int unit)
        {
            _start.X += unit;
        }

        public virtual Coordinates[] GetView()
        {
            Coordinates[] starts = new Coordinates[POINT_ELEMENTS_LENGTH];

            starts[0] = _start;

            return starts;
        }

        public virtual IFigure GetCopy()
        {
            Point copy = (Point)MemberwiseClone();

            return copy;
        }

        public virtual int CentrX
        {
            get { return _start.X; }
        }

        public virtual int CentrY
        {
            get { return _start.Y; }
        }

        public virtual int Length
        {
            get
            {
                return 1;
            }
        }
    }
}
