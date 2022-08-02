namespace _2020._09._12
{
    public interface IFigure
    {
        void MoveByY(int unit);

        void MoveByX(int unit);

        Coordinates[] GetView();

        IFigure GetCopy();

        int CentrX { get; }

        int CentrY { get; }

        int Length { get; }
    }
}
