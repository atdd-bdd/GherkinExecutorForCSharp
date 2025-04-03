using System.Text;

namespace Production
{
    public class TicTacToeGame
    {
        private readonly List<List<string>> gameBoard = new List<List<string>>();

        public TicTacToeGame()
        {
            gameBoard.Add(new List<string>());
        }

        public void SetBoard(List<List<string>> value)
        {
            gameBoard.Clear();
            foreach (var row in value)
            {
                var inRow = new List<string>();
                inRow.AddRange(row);
                gameBoard.Add(inRow);
            }
        }

        public override string ToString()
        {
            return ListOfListToString(this.gameBoard);
        }

        public void MakeAMove(int row, int column, char mark)
        {
            Console.WriteLine($"Row {row} Col {column} Mark {mark}");
            gameBoard[row - 1][column - 1] = mark.ToString();
        }

        public static string ListOfListToString(List<List<string>> value)
        {
            var maxSizes = new List<int>();
            foreach (var row in value)
            {
                int column = 0;
                foreach (var cell in row)
                {
                    if (maxSizes.Count < column + 1)
                    {
                        maxSizes.Add(0);
                    }
                    if (cell.Length > maxSizes[column])
                    {
                        maxSizes[column] = cell.Length;
                    }
                    column++;
                }
            }

            var result = new StringBuilder();
            int count = 0;
            foreach (var row in value)
            {
                result.Append("|");
                int column = 0;
                foreach (var cell in row)
                {
                    result.Append(" ");
                    int numberSpaces = maxSizes[column] - cell.Length + 1;
                    result.Append(cell);
                    result.Append(new string(' ', Math.Max(0, numberSpaces + 1)));
                    result.Append("|");
                    column++;
                }
                if (count < value.Count)
                    result.Append("\n");
                count++;
            }

            return result.ToString().Trim();
        }
    }
}
