using System.Text;

namespace Лаба_ОАИП_9
{
    static class ReversePolishNotation
    {
        public static bool CalculateRPN(string expression)
        {
            Stack<string> stack = new();
            StringBuilder num = new();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    num.Append(c);
                }
                else
                {
                    ProcessNonDigitCharacter(stack, num, c);
                }
            }

            return false;
        }

        private static void ProcessNonDigitCharacter(Stack<string> stack, StringBuilder num, char c)
        {
            if (c == '+' && num.Length > 0)
            {
                stack.Push(num.ToString());
                num.Clear();
            }
            else if (IsOperator(c))
            {
                if (ApplyOperation(stack, c))
                {
                    return;
                }
            }
            else
            {
                num.Append(c);
            }
        }

        private static bool IsOperator(char c)
        {
            return c == 'S' || c == 'M' ||  c == 'D';
        }

        private static bool ApplyOperation(Stack<string> operands, char c)
        {
            if (IsValidOperation(operands, c))
            {
                try
                {
                    ExecuteOperation(operands, c);
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsValidOperation(Stack<string> operands, char c)
        {
            return (c == 'S' && operands.Count == 4) ||
                   (c == 'M' && operands.Count == 3) ||
                   (c == 'D' && operands.Count == 1);
        }

        private static void ExecuteOperation(Stack<string> operands, char c)
        {
            switch (c)
            {
                case 'S':
                    ExecuteSquareOperation(operands);
                    break;
                case 'M':
                    ExecuteMoveOperation(operands);
                    break;
                case 'D':
                    ExecuteDeleteOperation(operands);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }

        private static void ExecuteSquareOperation(Stack<string> operands)
        {
            Square square = new(int.Parse(operands.Pop()), int.Parse(operands.Pop()), int.Parse(operands.Pop()), operands.Pop());
            square.Draw();
            Init.pictureBox.Image = Init.bitmap;
            ShapeContainer.AddFigure(square);
        }

        private static void ExecuteMoveOperation(Stack<string> operands)
        {
            int dy = int.Parse(operands.Pop());
            int dx = int.Parse(operands.Pop());
            string name = operands.Pop();
            Figure figure = ShapeContainer.figureList.FirstOrDefault(f => f.Name.Equals(name));
            if (figure != null)
            {
                figure.MoveTo(dx, dy);
            }
            else
            {
                throw new InvalidOperationException("Figure not found");
            }
        }

        private static void ExecuteDeleteOperation(Stack<string> operands)
        {
            string nameToDelete = operands.Pop();
            Figure figureToDelete = ShapeContainer.figureList.FirstOrDefault(f => f.Name.Equals(nameToDelete));
            if (figureToDelete != null)
            {
                figureToDelete.DeleteF(figureToDelete);
            }
            else
            {
                throw new InvalidOperationException("Figure not found");
            }
        }
    }
}