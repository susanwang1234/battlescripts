using System.Collections;
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

		#region Start Values
		public const byte START_FOO_POINTS = 127;
		public const byte START_BAR_POINTS = 127;
		public const byte START_BUG_COUNT = 0; 
		public const string START_SCREEN = "// Code to be executed goes here\n// Press Execute to execute the code\n";
		#endregion

		#region Code Descriptions
		public const string CODE_DESC_1 = "p1.Foo++;";
		public const string CODE_DESC_2 = "p2.Foo--;";
		#endregion

		#region Code Functions
		private static void Action_1(Programmer p1, Programmer p2)
		{
			p1.Foo++;
		}

		private static void Action_2(Programmer p1, Programmer p2)
		{
			p2.Foo--;
		}

		#endregion

		#region Code List
		public static List<Code> CodeList = new List<Code>()
		{
			new Code(CODE_DESC_1, Action_1),
			new Code(CODE_DESC_2, Action_2)
		};
		#endregion
	}
}