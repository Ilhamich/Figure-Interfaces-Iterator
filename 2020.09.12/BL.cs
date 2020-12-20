namespace _2020._09._12
{
    class BL
    {
        public static void ChangeFigure(InputUser chois, ref bool result, IFigure chosenFigure)
        {
            switch (chois)
            {
                case InputUser.LeftArrow:
                    chosenFigure.MoveByX(-1);
                    break;

                case InputUser.RightArrow:
                    chosenFigure.MoveByX(1);
                    break;

                case InputUser.UpArrow:
                    chosenFigure.MoveByY(-1);
                    break;

                case InputUser.DownArrow:
                    chosenFigure.MoveByY(1);
                    break;

                case InputUser.Plus:

                    if (chosenFigure is IFigureSizer)
                    {
                        ((IFigureSizer)chosenFigure).ChangeSize(1);
                    }
                   
                    break;

                case InputUser.Minus:
                    if (chosenFigure is IFigureSizer)
                    {
                        ((IFigureSizer)chosenFigure).ChangeSize(-1);
                    }
                    break;

                case InputUser.Turn:
                    if (chosenFigure is IFigureTurner)
                    {
                        ((IFigureTurner)chosenFigure).Turn();
                    }
                    
                    break;

                case InputUser.Enter:
                    result = true;
                    break;

                default:
                    result = false;
                    break;
            }
        }
    }
}
