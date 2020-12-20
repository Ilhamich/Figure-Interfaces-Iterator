namespace _2020._09._12
{
    class Point : IFigure
    {
        protected Coordinates start;
        private const int POINT_ELEMENTS_LENGTH = 1;

        public Point(int x, int y)
        {
            start = new Coordinates();
            start.X = x;
            start.Y = y;
        }

        public Point(int num)
            : this(num, num)
        {
        }

        public virtual void MoveByY(int unit)
        {
            start.Y += unit;
        }

        public virtual void MoveByX(int unit)
        {
            start.X += unit;
        }

        public virtual Coordinates[] GetView()
        {
            Coordinates[] starts = new Coordinates[POINT_ELEMENTS_LENGTH];

            starts[0] = start;

            return starts;
        }

        public virtual object GetCopy()
        {
            Point copy = (Point)MemberwiseClone();

            return copy;
        }

        public virtual int CentrX
        {
            get { return start.X; }
        }

        public virtual int CentrY
        {
            get { return start.Y; }
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
