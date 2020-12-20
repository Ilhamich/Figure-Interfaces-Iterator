namespace _2020._09._12
{
    class Polyline : Point, IFigureTurner
    {
        public const int DISTANCE_OF_POINT = 3;
        Coordinates[] _polyline;
        private int _length;
        private bool _turne;

        public override int Length
        {
            get { return _length; }
        }

        public Polyline(int xF, int yF, int length)
           : base(xF, yF)
        {
            _length = length;
        }

        public void ChangeSize(int unit)
        {
            if ((_length + unit) > 0)
            {
                _length += unit;
            }
        }

        public override Coordinates[] GetView()
        {
            _polyline = new Coordinates[_length];

            if (!_turne)
            {
                BildHorizontalPolyline(start.X, start.Y);
            }
            else
            {
                BildVerticalPolyline(start.X, start.Y);
            }

            return _polyline;
        }

        public override object GetCopy()
        {
            Polyline copy = (Polyline)MemberwiseClone();
            ((Polyline)copy)._polyline = (Coordinates[])_polyline.Clone();

            return copy;
        }

        private void BildHorizontalPolyline(int xCentr, int yCentr)
        {
            for (int i = 0; i < _length - 1; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    _polyline[i].X = xCentr + DISTANCE_OF_POINT * (i + 1);

                    if (i - 1 < 0 || _polyline[i].Y < yCentr)
                    {
                        _polyline[i].Y = yCentr + DISTANCE_OF_POINT;
                    }
                    else
                    {
                        _polyline[i].Y = yCentr - DISTANCE_OF_POINT;
                    }

                }
                else
                {
                    _polyline[i].X = xCentr - DISTANCE_OF_POINT * (i + 1);

                    if (_polyline[i - 1].Y < yCentr)
                    {
                        _polyline[i].Y = yCentr + DISTANCE_OF_POINT;
                    }
                    else
                    {
                        _polyline[i].Y = yCentr - DISTANCE_OF_POINT;
                    }
                }
            }

            _polyline[_length - 1].X = xCentr;
            _polyline[_length - 1].Y = yCentr;
        }

        private void BildVerticalPolyline(int xCentr, int yCentr)
        {
            for (int i = 0; i < _length - 1; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    _polyline[i].Y = yCentr + DISTANCE_OF_POINT * (i + 1);

                    if (i - 1 < 0 || _polyline[i].X < xCentr)
                    {
                        _polyline[i].X = xCentr + DISTANCE_OF_POINT;
                    }
                    else
                    {
                        _polyline[i].X = xCentr - DISTANCE_OF_POINT;
                    }

                }
                else
                {
                    _polyline[i].Y = yCentr - DISTANCE_OF_POINT * (i + 1);

                    if (_polyline[i - 1].X < xCentr)
                    {
                        _polyline[i].X = xCentr + DISTANCE_OF_POINT;
                    }
                    else
                    {
                        _polyline[i].X = xCentr - DISTANCE_OF_POINT;
                    }
                }
            }

            _polyline[_length - 1].X = xCentr;
            _polyline[_length - 1].Y = yCentr;
        }

        public void Turn()
        {
            if (_turne)
            {
                _turne = false;
            }
            else
            {
                _turne = true;
            }
        }
    }
}
