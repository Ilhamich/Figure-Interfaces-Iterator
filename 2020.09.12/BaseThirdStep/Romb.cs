using System;

namespace _2020._09._12
{
    class Romb : Triangle
    {
        public const int SECOND_PARTS_OF_ROMB = 2;

        public Romb(int x, int y, int size)
            : base(x, y, size)
        {
        }

        public override Coordinates[] GetView()
        {
            _triangl = new Coordinates[_sizeOfTriangle * QUANTITY_OF_PART_TRIANGLE];

            BildRomb(_sizeOfTriangle);

            return _triangl;
        }

        public override object GetCopy()
        {
            Romb copy = (Romb)MemberwiseClone();
            copy._triangl = (Coordinates[])_triangl.Clone();

            return copy;
        }

        private void BildRomb(int sizeOfRomb)
        {
            for (int i = 0; i < sizeOfRomb * QUANTITY_OF_PART_TRIANGLE; i++)
            {
                for (int j = 0; j < sizeOfRomb && i == 0; j++)
                {
                    _triangl[j].X = start.X + j;
                    _triangl[j].Y = start.Y + sizeOfRomb - 1 - j;
                    _triangl[((i + 1) * sizeOfRomb) + j].X = start.X - j;
                    _triangl[((i + 1) * sizeOfRomb) + j].Y = start.Y + sizeOfRomb - 1 - j;
                }

                for (int j = 0; j < sizeOfRomb && i == QUANTITY_OF_PART_TRIANGLE - i; j++)
                {
                    _triangl[(i * sizeOfRomb) + j].X = _triangl[j].X;
                    _triangl[(i * sizeOfRomb) + j].Y = start.Y - sizeOfRomb + j + 1;
                    _triangl[((i + 1) * sizeOfRomb) + j].X = _triangl[sizeOfRomb + j].X;
                    _triangl[((i + 1) * sizeOfRomb) + j].Y = start.Y - sizeOfRomb + j + 1;
                }
            }
        }

        public override double Perimetr()
        {
            int high = _sizeOfTriangle;
            int halfOfBase = _sizeOfTriangle;
            double hypotenuse = Math.Sqrt(high * high + (double)(halfOfBase * halfOfBase));

            return (hypotenuse + hypotenuse) * SECOND_PARTS_OF_ROMB;
        }

        public override double Area()
        {
            int high = _sizeOfTriangle;
            int basis = _sizeOfTriangle + _sizeOfTriangle;

            return (high * basis / DIVIDER_FOR_AREA_FINDER) * SECOND_PARTS_OF_ROMB;
        }
    }
}
