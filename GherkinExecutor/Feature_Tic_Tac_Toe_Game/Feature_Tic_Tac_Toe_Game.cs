namespace gherkinexecutor.Feature_Tic_Tac_Toe_Game{
[TestClass]
public class Feature_Tic_Tac_Toe_Game{


    [TestMethod]
    public void Test_Scenario_Make_a_move(){
         Feature_Tic_Tac_Toe_Game_glue feature_Tic_Tac_Toe_Game_glue_object = new Feature_Tic_Tac_Toe_Game_glue();

        List<List<string>> stringListList1 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Tic_Tac_Toe_Game_glue_object.Given_board_is(stringListList1);

         List<Move> objectList2 = new List<Move>{
             new Move.Builder()
                .SetRow("1")
                .SetColumn("2")
                .SetMark("X")
                .Build()
            };
        feature_Tic_Tac_Toe_Game_glue_object.When_move_is(objectList2);

        string table3 =
            """
            |   | X  |   |
            |   |    |   |
            |   |    |   |
            """.Trim();
        feature_Tic_Tac_Toe_Game_glue_object.Then_board_is_now(table3);
        }
    [TestMethod]
    public void Test_Scenario_Make_a_move_using_single_element(){
         Feature_Tic_Tac_Toe_Game_glue feature_Tic_Tac_Toe_Game_glue_object = new Feature_Tic_Tac_Toe_Game_glue();

        List<List<string>> stringListList4 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Tic_Tac_Toe_Game_glue_object.Given_board_is(stringListList4);

        List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "1,2,X"
            }
            };
        feature_Tic_Tac_Toe_Game_glue_object.When_one_move_is(stringListList5);

        string table6 =
            """
            |   | X  |   |
            |   |    |   |
            |   |    |   |
            """.Trim();
        feature_Tic_Tac_Toe_Game_glue_object.Then_board_is_now(table6);
        }
    [TestMethod]
    public void Test_Scenario_Make_multiple_moves(){
         Feature_Tic_Tac_Toe_Game_glue feature_Tic_Tac_Toe_Game_glue_object = new Feature_Tic_Tac_Toe_Game_glue();

        List<List<string>> stringListList7 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Tic_Tac_Toe_Game_glue_object.Given_board_is(stringListList7);

         List<Move> objectList8 = new List<Move>{
             new Move.Builder()
                .SetRow("1")
                .SetColumn("2")
                .SetMark("X")
                .Build()
            , new Move.Builder()
                .SetRow("2")
                .SetColumn("3")
                .SetMark("O")
                .Build()
            };
        feature_Tic_Tac_Toe_Game_glue_object.When_moves_are(objectList8);

        string table9 =
            """
            |   | X  |    |
            |   |    | O  |
            |   |    |    |
            """.Trim();
        feature_Tic_Tac_Toe_Game_glue_object.Then_board_is_now(table9);
        }
    [TestMethod]
    public void Test_Scenario_check_the_prints_to_see_how_it_works(){
         Feature_Tic_Tac_Toe_Game_glue feature_Tic_Tac_Toe_Game_glue_object = new Feature_Tic_Tac_Toe_Game_glue();

        List<List<string>> stringListList10 = new List<List<string>>{
           new List<string>{
            "0"
            ,"x"
            ,"0"
            }
           ,new List<string>{
            "x"
            ,"0"
            ,"x"
            }
           ,new List<string>{
            "0"
            ,"x"
            ,"0"
            }
            };
        feature_Tic_Tac_Toe_Game_glue_object.Given_board_is(stringListList10);

        string table11 =
            """
            | 0  | x  | 0  |
            | x  | 0  | x  |
            | 0  | x  | 0  |
            """.Trim();
        feature_Tic_Tac_Toe_Game_glue_object.Then_board_is_now(table11);
        }
    }
}

