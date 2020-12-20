namespace _2020._09._12
{
    interface IFigure
    {
        void MoveByY(int unit);

        void MoveByX(int unit);

        Coordinates[] GetView();

        object GetCopy();

        int CentrX
        {
            get;
        }

        int CentrY
        {
            get;
        }

        int Length
        {
            get;
        }
    }
}
