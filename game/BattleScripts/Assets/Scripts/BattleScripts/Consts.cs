using System.Collections.Generic;

namespace BattleScripts
{
    /// <summary>
    /// Consts is a class which stores all constants that are used across multiple scripts. 
    /// </summary>
    public static class Consts
    {

        #region Max Values
        public const byte MAX_BUGS = 3;
        public const int MAX_CARDS_IN_HAND = 5;
        public const int MAX_PROGRAM_SIZE = 6;
        #endregion

		#region Constant Values
		public const string ROOM_PROMPT = "Room Name :\n";
        public const string ON_WIN_TEXT = "You Win!";

        public const string ON_LOSE_TEXT = "You Lose!";
        public const string ON_REMATCH_TEXT = "Wait...";

        public const string COMMENT = "// ";

        public static string APPLICATION_URL = UnityEngine.Application.absoluteURL + "/record?";

        #endregion


        #region User Info
        // These fields are set by launcher when the game is loaded at client side
        // Just made them public static so GameManager would be able to access them when new scene loads
        public static string userName = "";
        public static string userID = "1";
        #endregion

        #region Start Values
        public const byte START_FOO_POINTS = 127;
        public const byte START_BAR_POINTS = 127;
        public const byte START_BUG_COUNT = 0;
        public const string START_SCREEN = "// Code to be executed goes here\n// Press Execute to execute the code\n// MAX 6 Lines\n";
        #endregion

        #region Code Descriptions
        public const string CODE_DESC_1 = "p1.Foo += 16;";
        public const string CODE_DESC_2 = "p2.Foo -= 16;";
        public const string CODE_DESC_3 = "p1.Bar += 16;";
        public const string CODE_DESC_4 = "p2.Bar -= 16;";

        public const string CODE_DESC_5 = "p2.Foo += 16;";
        public const string CODE_DESC_6 = "p1.Foo -= 16;";
        public const string CODE_DESC_7 = "p2.Bar += 16;";
        public const string CODE_DESC_8 = "p1.Bar -= 16;";

        public const string CODE_DESC_9 = "p1.Foo /= 4;";
        public const string CODE_DESC_10 = "p2.Foo /= 4;";
        public const string CODE_DESC_11 = "p1.Bar /= 4;";
        public const string CODE_DESC_12 = "p2.Foo /= 4;";

        public const string CODE_DESC_13 = "p1.Foo *= 2;";
        public const string CODE_DESC_14 = "p2.Foo *= 2;";
        public const string CODE_DESC_15 = "p1.Bar *= 2;";
        public const string CODE_DESC_16 = "p2.Bar *= 2;";

        public const string CODE_DESC_17 = "P1 COMBO p1.Foo, Bar /= 4; ";
        public const string CODE_DESC_18 = "P2 COMBO p2.Foo, Bar /= 4; ";

        public const string CODE_DESC_19 = "p1.Foo += 1; ";
        public const string CODE_DESC_20 = "p1.Bar += 1; ";
        public const string CODE_DESC_21 = "p2.Foo += 1; ";
        public const string CODE_DESC_22 = "p2.Bar += 1; ";

        public const string CODE_DESC_23 = "swap(p1.Foo, p2.Foo); ";
        public const string CODE_DESC_24 = "swap(p1.Bar, p2.Bar); ";

        public const string CODE_DESC_25 = "p2.Program.CommentAll(); ";

        public const string CHEAT_CODE = "GameManager.Instance.Winner = this.Programmer;";
        #endregion

        #region Code Functions

        private static void ACTION_1(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Foo;
            p1.Foo += 16;
            if (overflow > p1.Foo) p1.Bugs++;
        }

        private static void ACTION_2(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Foo;
            p2.Foo -= 16;
            if (overflow < p2.Foo) p2.Bugs++;
        }

        private static void ACTION_3(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            p1.Bar += 16;
            if (overflow > p1.Bar) p1.Bugs++;
        }

        private static void ACTION_4(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            p2.Bar -= 16;
            if (overflow < p2.Bar) p2.Bugs++;
        }

        private static void ACTION_5(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Foo;
            p2.Foo += 16;
            if (overflow > p2.Foo) p2.Bugs++;
        }

        private static void ACTION_6(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Foo;
            p1.Foo -= 16;
            if (overflow < p1.Foo) p1.Bugs++;
        }

        private static void ACTION_7(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            p2.Bar += 16;
            if (overflow > p2.Bar) p2.Bugs++;
        }

        private static void ACTION_8(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            p1.Bar -= 16;
            if (overflow < p1.Bar) p1.Bugs++;
        }

        private static void ACTION_9(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Foo;
            p1.Foo /= 4;
            if (overflow < p1.Foo) p1.Bugs++;
        }

        private static void ACTION_10(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Foo;
            p2.Foo /= 4;
            if (overflow < p2.Foo) p2.Bugs++;
        }

        private static void ACTION_11(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            p1.Bar /= 4;
            if (overflow < p1.Bar) p1.Bugs++;
        }

        private static void ACTION_12(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            p2.Bar /= 4;
            if (overflow < p2.Bar) p2.Bugs++;
        }

        private static void ACTION_13(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Foo;
            p1.Foo *= 2;
            if (overflow > p1.Foo) p1.Bugs++;
        }

        private static void ACTION_14(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Foo;
            p2.Foo *= 2;
            if (overflow > p2.Foo) p2.Bugs++;
        }

        private static void ACTION_15(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            p1.Bar *= 2;
            if (overflow > p1.Bar) p1.Bugs++;
        }

        private static void ACTION_16(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            p2.Bar *= 2;
            if (overflow > p2.Bar) p2.Bugs++;
        }

        private static void ACTION_17(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            byte overflow2 = p1.Foo;
            p1.Foo /= 4;
            p1.Bar /= 4;
            if (overflow < p1.Foo) p1.Bugs++;
            if (overflow2 < p1.Bar) p1.Bugs++;
        }

        private static void ACTION_18(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            byte overflow2 = p2.Foo;
            p2.Foo /= 4;
            p2.Bar /= 4;
            if (overflow < p2.Foo) p2.Bugs++;
            if (overflow2 < p2.Bar) p2.Bugs++;
        }

        private static void ACTION_19(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Foo;
            p1.Foo += 1;
            if (overflow > p1.Foo) p1.Bugs++;
        }
        private static void ACTION_20(Programmer p1, Programmer p2)
        {
            byte overflow = p1.Bar;
            p1.Bar += 1;
            if (overflow > p1.Bar) p1.Bugs++;
        }
        private static void ACTION_21(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Foo;
            p2.Foo += 1;
            if (overflow > p2.Foo) p2.Bugs++;
        }
        private static void ACTION_22(Programmer p1, Programmer p2)
        {
            byte overflow = p2.Bar;
            p2.Bar += 1;
            if (overflow > p2.Bar) p2.Bugs++;
        }

        private static void ACTION_23(Programmer p1, Programmer p2)
        {
            byte temp = p1.Foo;
            p1.Foo = p2.Foo;
            p2.Foo = temp;
        }

        private static void ACTION_24(Programmer p1, Programmer p2)
        {
            byte temp = p1.Bar;
            p1.Bar = p2.Bar;
            p2.Bar = temp;
        }

        private static void ACTION_25(Programmer p1, Programmer p2)
        {
            foreach (Code c in p2.Program)
            {
                c.Comment();
            }
        }

        private static void CHEAT_ACTION(Programmer p1, Programmer p2)
        {
            GameManager.Instance.Winner = p1;
        }

        #endregion

        #region Code List
        public static List<Code> CodeList = new List<Code>()
        {
            new Code(CHEAT_CODE, CHEAT_ACTION),
            new Code(CODE_DESC_1, ACTION_1),
            new Code(CODE_DESC_2, ACTION_2),
            new Code(CODE_DESC_3, ACTION_3),
            new Code(CODE_DESC_4, ACTION_4),
            new Code(CODE_DESC_5, ACTION_5),
            new Code(CODE_DESC_6, ACTION_6),
            new Code(CODE_DESC_7, ACTION_7),
            new Code(CODE_DESC_8, ACTION_8),
            new Code(CODE_DESC_9, ACTION_9),
            new Code(CODE_DESC_10, ACTION_10),
            new Code(CODE_DESC_11, ACTION_11),
            new Code(CODE_DESC_12, ACTION_12),
            new Code(CODE_DESC_13, ACTION_13),
            new Code(CODE_DESC_14, ACTION_14),
            new Code(CODE_DESC_15, ACTION_15),
            new Code(CODE_DESC_16, ACTION_16),
            new Code(CODE_DESC_17, ACTION_17),
            new Code(CODE_DESC_18, ACTION_18),
            new Code(CODE_DESC_19, ACTION_19),
            new Code(CODE_DESC_20, ACTION_20),
            new Code(CODE_DESC_21, ACTION_21),
            new Code(CODE_DESC_22, ACTION_22),
            new Code(CODE_DESC_23, ACTION_23),
            new Code(CODE_DESC_24, ACTION_24),
            new Code(CODE_DESC_25, ACTION_25)
        };
        #endregion

        #region Cheats
        public const string CHEAT_NAME = "_H4X3R_";
        #endregion
    }
}
