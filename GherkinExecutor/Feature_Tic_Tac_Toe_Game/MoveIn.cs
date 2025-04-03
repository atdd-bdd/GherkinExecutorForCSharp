using System;

namespace gherkinexecutor.Feature_Tic_Tac_Toe_Game
{
    class MoveIn
    {
        public string Row { get; set; } = "0";
        public string Column { get; set; } = "0";
        public string Mark { get; set; } = "^";

        public MoveIn(string row, string column, string mark)
        {
            this.Row = row;
            this.Column = column;
            this.Mark = mark;
        }

        public MoveIn(string moveString)
        {
            string[] parts = moveString.Split(',');
            if (parts.Length == 3)
            {
                this.Row = parts[0];
                this.Column = parts[1];
                this.Mark = parts[2];
            }
            else
            {
                throw new ArgumentException("Invalid move string format");
            }
        }

        public Move ToMove() => new(Row, Column, Mark);
    }
}

    