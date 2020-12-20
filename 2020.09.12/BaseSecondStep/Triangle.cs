using System;

namespace _2020._09._12
{
    class Triangle : Point, IFigureTurner, IGeometrical
    {
        protected const double DIVIDER_FOR_AREA_FINDER = 2.0;
        protected const int MINIMAL_SIZE = 2;
        public const int QUANTITY_OF_PART_TRIANGLE = 4;
        protected Coordinates[] _triangl;
        protected int _sizeOfTriangle;
        protected bool _position = false;

        public override int Length
        {
            get { return _sizeOfTriangle * QUANTITY_OF_PART_TRIANGLE; }
        }

        public Triangle(int x, int y, int size)
            : base(x, y)
        {
            if (size < MINIMAL_SIZE)
            {
                size = MINIMAL_SIZE;
            }

            _sizeOfTriangle = size;
        }

        public override Coordinates[] GetView()
        {
            _triangl = new Coordinates[_sizeOfTriangle * QUANTITY_OF_PART_TRIANGLE];

            if (_position)
            {
                BildVerticalTriangle(start.X, start.Y, _sizeOfTriangle);
            }
            else
            {
                BildHorizontalTriangle(start.X, start.Y, _sizeOfTriangle);
            }

            return (Coordinates[])_triangl.Clone();
        }

        public override object GetCopy()
        {
            Triangle copy = (Triangle)MemberwiseClone();
            copy._triangl = (Coordinates[])_triangl.Clone();

            return copy;
        }

        public void Turn()
        {
            if (!_position)
            {
                _position = true;
            }
            else
            {
                _position = false;
            }
        }

        public virtual void ChangeSize(int unit)
        {
            if ((_sizeOfTriangle + unit) > 1)
            {
                _sizeOfTriangle += unit;
            }
        }

        private void BildHorizontalTriangle(int xNum, int yNum, int size)
        {
            for (int i = 0; i < size * QUANTITY_OF_PART_TRIANGLE; i++)
            {
                for (int j = 0; j < size && i == 0; j++)
                {
                    _triangl[j].X = xNum + j;
                    _triangl[j].Y = yNum;
                    _triangl[((i + 1) * size) + j].X = xNum - j;
                    _triangl[((i + 1) * size) + j].Y = yNum;
                }

                for (int j = 0; j < size && i == QUANTITY_OF_PART_TRIANGLE - i; j++)
                {
                    _triangl[(i * size) + j].X = _triangl[j].X;
                    _triangl[(i * size) + j].Y = yNum - size + 1 + j;
                    _triangl[((i + 1) * size) + j].X = _triangl[size + j].X;
                    _triangl[((i + 1) * size) + j].Y = yNum - size + 1 + j;
                }
            }
        }

        private void BildVerticalTriangle(int xNum, int yNum, int size)
        {
            for (int i = 0; i < size * QUANTITY_OF_PART_TRIANGLE; i++)
            {
                for (int j = 0; j < size && i == 0; j++)
                {
                    _triangl[j].X = xNum;
                    _triangl[j].Y = yNum - j;
                    _triangl[((i + 1) * size) + j].X = xNum;
                    _triangl[((i + 1) * size) + j].Y = yNum + j;
                }

                for (int j = 0; j < size && i == QUANTITY_OF_PART_TRIANGLE - i; j++)
                {
                    _triangl[(i * size) + j].X = xNum - size + 1 + j;
                    _triangl[(i * size) + j].Y = _triangl[j].Y;
                    _triangl[((i + 1) * size) + j].X = xNum - size + 1 + j;
                    _triangl[((i + 1) * size) + j].Y = _triangl[size + j].Y;
                }
            }
        }

        public virtual double Perimetr()
        {
            int high = _sizeOfTriangle;
            int halfOfBase = _sizeOfTriangle;
            double hypotenuse = Math.Sqrt(high * high + (double)(halfOfBase * halfOfBase));

            return hypotenuse + hypotenuse + halfOfBase + halfOfBase;
        }

        public virtual double Area()
        {
            int high = _sizeOfTriangle;
            int basis = _sizeOfTriangle + _sizeOfTriangle;

            return high * basis / DIVIDER_FOR_AREA_FINDER;
        }
    }
}
