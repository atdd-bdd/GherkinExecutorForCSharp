namespace gherkinexecutor.Feature_Tic_Tac_Toe_Game {
    using Production;
    using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class Feature_Tic_Tac_Toe_Game_glue {
    const string DNCString = "?DNC?";
        TicTacToeGame game = new TicTacToeGame();

        public void Given_board_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "Given_board_is");
        foreach (List<string> value in values){
             Console.WriteLine(value);


            }
            game.SetBoard(values);
        }

    public void When_move_is(List<Move> values ) {
        Console.WriteLine("---  " + "When_move_is");
        foreach (Move value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              MoveInternal i = value.ToMoveInternal();

                game.MakeAMove(i.row, i.column, i.mark);
            }
        throw new NotImplementedException();
    }

    public void Then_board_is_now(string value ) {
        Console.WriteLine("---  " + "Then_board_is_now");
        Console.WriteLine(value);
            value = value.Substring(0, value.length() - 1);
            String result = game.ToString();
            AreEqual(value, result);

        }

        public void When_one_move_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "When_one_move_is");
            String s = value.get(0).get(0);
            MoveIn mi = new MoveIn(s);
            Move m = mi.toMove();
           
                MoveInternal oneMove = m.ToMoveInternal();
                game.MakeAMove(oneMove.row, oneMove.column,
                        oneMove.mark);
         string s = values[0][0]]
        MoveIn mi = new MoveIn(s);
        Move m = mi.toMove();
        try {
            MoveInternal oneMove = m.toMoveInternal();
            game.makeAMove(oneMove.row, oneMove.column,
                    oneMove.mark);
    
            }

    public void When_moves_are(List<Move> values ) {
        Console.WriteLine("---  " + "When_moves_are");
        foreach (Move value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              MoveInternal i = value.ToMoveInternal();
              }
        throw new NotImplementedException();
    }

    }
}
