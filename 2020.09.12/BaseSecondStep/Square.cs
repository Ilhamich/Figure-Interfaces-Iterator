using System;

namespace _2020._09._12
{
    class Square : Point, IFigureSizer, IGeometrical
    {
        public const int QUANTITY_OF_SIDES = 4;
        public const int PARALLEL_LINE = 2;
        private const int STANDART_WIDTH = 3;
        protected int _width;
        private int _halfOfWidht;
        private Coordinates _rightDownAngle;
        private Coordinates[] _square;

        public Square(int x, int y, int halfOfWidht)
            : base(x - halfOfWidht, y - halfOfWidht)
        {
            if (halfOfWidht < 1)
            {
                halfOfWidht = 1;
            }

            _halfOfWidht = halfOfWidht;
            _width = _halfOfWidht + 1 + _halfOfWidht;
            _rightDownAngle.X = start.X + _width - 1;
            _rightDownAngle.Y = start.Y + _width - 1;
        }

        public override int CentrX
        {
            get
            {
                return start.X + _halfOfWidht;
            }
        }

        public override int CentrY
        {
            get
            {
                return start.Y + _halfOfWidht;
            }
        }

        public override int Length
        {
            get 
            {
                int length = 0;

                if (_square != null)
                {
                    length = _square.Length;
                }

                return length;
            }
        }

        public override Coordinates[] GetView()
        {
            _square = new Coordinates[_width * QUANTITY_OF_SIDES];

            for (int i = 0; i < QUANTITY_OF_SIDES; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (i < PARALLEL_LINE)
                    {
                        if ((i + 1) % PARALLEL_LINE != 0)
                        {
                            _square[j + (i * _width)].X = start.X + j;
                            _square[j + (i * _width)].Y = start.Y;
                        }
                        else
                        {
                            _square[j + (i * _width)].Y = start.Y + j;
                            _square[j + (i * _width)].X = _rightDownAngle.X;
                        }
                    }
                    else
                    {
                        if ((i + 1) % PARALLEL_LINE != 0)
                        {
                            _square[j + (i * _width)].X = _rightDownAngle.X - j;
                            _square[j + (i * _width)].Y = _rightDownAngle.Y;
                        }
                        else
                        {
                            _square[j + (i * _width)].X = start.X;
                            _square[j + (i * _width)].Y = _rightDownAngle.Y - j;
                        }
                    }
                }
            }

            return _square;
        }

        public override object GetCopy()
        {
            Square copy = (Square)MemberwiseClone();
            copy._square = (Coordinates[])_square.Clone();

            return copy;
        }

        public virtual void ChangeSize(int unit)
        {
            if ((_width + unit) > STANDART_WIDTH)
            {
                _halfOfWidht += unit;
                _width += unit + unit;
                start.X -= unit;
                start.Y -= unit;

                if (unit > 0)
                {
                    _rightDownAngle.X = start.X + _width - unit;
                    _rightDownAngle.Y = start.Y + _width - unit;
                }
                else
                {
                    _rightDownAngle.X = start.X + _width + unit;
                    _rightDownAngle.Y = start.Y + _width + unit;
                }
            }           
        }

        public override void MoveByY(int unit)
        {
            start.Y += unit;
            _rightDownAngle.Y += unit;
        }

        public override void MoveByX(int unit)
        {
            start.X += unit;
            _rightDownAngle.X += unit; 
        }

        public double Perimetr()
        {
            return (double)(_width * QUANTITY_OF_SIDES);
        }

        public double Area()
        {
            return (double)(_width * _width);
        }
    }
}
