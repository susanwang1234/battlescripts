using System.Collections.Generic;

namespace BattleScripts
{
    /// <summary>
    /// Consts is a class which stores all constants that are used across multiple scripts. 
    /// </summary>
    public static class Consts {

		#region Max Values
		public const byte MAX_BUGS = 3;
		public const int MAX_CARDS_IN_HAND = 5;
		#endregion

		#region Constant Values
		public const string ROOM_PROMPT = "Room Name :\n";

		public const string ON_WIN_TEXT = "You Win!";

		public const string ON_LOSE_TEXT = "You Lose!";
		public const string ON_REMATCH_TEXT = "Wait...";

        public static string APPLICATION_URL = "localhost/unity/record" + "?";
		#endregion

		#region Start Values
		public const byte START_FOO_POINTS = 127;
		public const byte START_BAR_POINTS = 127;
		public const byte START_BUG_COUNT = 0; 
		public const string START_SCREEN = "// Code to be executed goes here\n// Press Execute to execute the code\n";
		#endregion

		#region Code Descriptions
		public const string CODE_DESC_1 = "p1.Foo += 16;";
		public const string CODE_DESC_2 = "p2.Foo -= 16;";
		public const string CODE_DESC_3 = "p1.Bar += 16;";
		public const string CODE_DESC_4 = "p2.Bar -= 16;";

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
			new Code(CODE_DESC_4, ACTION_4)			
		};
		#endregion

		#region Cheats
		public const string CHEAT_NAME= "_H4X3R_";
        #endregion

        #region User Info
        // These fields are set by launcher when the game is loaded at client side
        // Just made them public static so GameManager would be able to access them when new scene loads
        public static string userName = "";
        public static string userID = "";
        #endregion
    }
}