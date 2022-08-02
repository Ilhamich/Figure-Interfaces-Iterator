using System;

namespace _2020._09._12
{
    class Circle : Point, IGeometrical, IFigureSizer
    {
        private const int HALFS_OF_CIRCLE = 2;
        protected Coordinates[] _circl;
        protected int _radius;
        protected int _quntityOfHalf;

        public Circle(int x, int y, int size)
            : base(new Coordinates(x, y))
        {
            if (size < 1)
            {
                size = 1;
            }

            _radius = size;
            _quntityOfHalf = _radius + _radius;
        }

        public override Coordinates[] GetView()
        {       
            _circl = new Coordinates[_quntityOfHalf * HALFS_OF_CIRCLE];

            BildCircl(_quntityOfHalf);
            
            return _circl;
        }

        public override IFigure GetCopy()       
        {
            Circle copy = (Circle)MemberwiseClone();
            copy._circl = (Coordinates[])_circl.Clone();

            return copy;
        }

        private void BildCircl(int quntity)
        {
            for (int i = 0; i < quntity; i++)
            {
                _circl[i].Y = _start.Y - _radius + i;
                _circl[i + quntity].Y = _radius + _start.Y - i;

                double tmp = Math.Sqrt((_radius * _radius) - (_circl[i].Y - _start.Y)
                        * (_circl[i].Y - _start.Y)) + _start.X;

                _circl[i].X = (int)Math.Round(tmp);
                _circl[i + quntity].X = _start.X - (_circl[i].X - _start.X);
            }
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
        }

        public override int Length
        {
            get
            {
                int length = 0;

                if (_circl != null)
                {
                    length = _circl.Length;
                }

                return length;
            }
        }

        public virtual void ChangeSize(int unit)
        {
            if ((_radius + unit) > 0)
            {
                _radius += unit;
                _quntityOfHalf = _radius + _radius;
            }           
        }

        public double Perimetr()
        {
            return _radius * (2 * Math.PI);
        }

        public double Area()
        {
            return _radius * _radius * Math.PI;
        }

        public override int CentrX
        {
            get { return _start.X; }
        }

        public override int CentrY
        {
            get { return _start.Y; }
        }
    }
}
