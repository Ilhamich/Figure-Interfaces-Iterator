namespace _2020._09._12
{
    abstract class Figure
    {
        public abstract void MoveByY(int unit);

        public abstract void MoveByX(int unit);

        public abstract void ChangeSize(int unit);

        public abstract void Turn();

        public abstract Figure GetCopy();

        public abstract Coordinates[] GetView();

        public abstract int CentrX
        {
            get;
        }

        public abstract int CentrY
        {
            get;
        }

        public abstract int Length
        {
            get;
        }
    }
}
