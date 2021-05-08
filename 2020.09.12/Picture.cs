using System;
using System.Collections;

namespace _2020._09._12
{
    class Picture : IEnumerable
    {
        private IFigure[] _figures;

        public Picture(params IFigure[] pictures)
        {
            _figures = (IFigure[])pictures.Clone();
        }

        public Coordinates[] GetView()
        {
            Coordinates[] picture = new Coordinates[0];

            for (int i = 0; i < _figures.Length; i++)
            {
                if (i == 0)
                {
                    picture = _figures[i].GetView();
                }
                else
                {
                    Coordinates[] nextFigure = _figures[i].GetView();

                    int oldSize = picture.Length;

                    Array.Resize(ref picture, picture.Length + nextFigure.Length);

                    for (int j = 0; j < nextFigure.Length; j++)
                    {
                        picture[j + oldSize] = nextFigure[j];
                    }
                }
            }

            return picture;
        }

        public IFigure this[int index]
        {
            get
            {
                return _figures[index].GetCopy();
            }
            set
            {
                _figures[index] = value.GetCopy();
            }
        }

        public int Length
        {
            get
            {
                int length = 0;

                if (_figures != null)
                {
                    length = _figures.Length;
                }

                return length;
            }
        }

        public void AddFigure(IFigure figureNew)
        {
            Array.Resize(ref _figures, _figures.Length + 1);

            _figures[_figures.Length] = figureNew.GetCopy();
        }

        public void DeleteFigure(int index)
        {
            if (index > 0 && index < _figures.Length)
            {
                IFigure[] tmp = new IFigure[_figures.Length - 1];

                for (int i = 0; i < _figures.Length; i++)
                {
                    if (i != index)
                    {
                        tmp[i] = _figures[i].GetCopy();
                    }                  
                }

                _figures = tmp;
            }
        }

        public IEnumerator /*IEnumerable.*/GetEnumerator()  //???
        {
            return new PictureIterator(this);
        }

        public struct PictureIterator : IEnumerator
        {
            private readonly Picture _pictures;            
            private int _picturePosition;

            public PictureIterator(Picture pictures)
            {
                _pictures = pictures;
                _picturePosition = -1;
            }
            
            public object Current
            {
                get
                {
                    return _pictures._figures[_picturePosition];
                }
            }

            public bool MoveNext()
            {
                ++_picturePosition;

                return _picturePosition < _pictures.Length;
            }

            public void Reset()
            {
                _picturePosition = -1; ;
            }
        }
    }
}
