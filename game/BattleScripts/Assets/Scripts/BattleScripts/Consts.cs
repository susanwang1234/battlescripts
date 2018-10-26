﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

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
		public const string CODE_DESC_1 = "0. p1.Foo += 16;";
		public const string CODE_DESC_2 = "1. p2.Foo -= 16;";
		public const string CODE_DESC_3 = "2. p1.Bar += 16;";
		public const string CODE_DESC_4 = "3. p2.Bar -= 16;";
		public const string CODE_DESC_5 = "if (p1.Foo < p2.Foo)\n\tswap(p1.Foo, p2.Foo);";
		#endregion

		#region Code Functions
		
		private static void ACTION_1(Programmer p1, Programmer p2)
		{
			byte mod = 16;
			p1.photonView.RPC("Modify", RpcTarget.All, p1.Foo, mod, true);
		}

		private static void ACTION_2(Programmer p1, Programmer p2)
		{
			byte mod = 16;
			p2.photonView.RPC("Modify", RpcTarget.All, p1.Foo, mod, false);
		}

		private static void ACTION_3(Programmer p1, Programmer p2)
		{
			byte mod = 16;
			p1.photonView.RPC("Modify", RpcTarget.All, p1.Bar, mod, true);
		}

		private static void ACTION_4(Programmer p1, Programmer p2)
		{
			byte mod = 16;
			p2.photonView.RPC("Modify", RpcTarget.All, p2.Bar, mod, false);
		}

		#endregion

		#region Code List
		public static List<Code> CodeList = new List<Code>()
		{
			new Code(CODE_DESC_1, ACTION_1),
			new Code(CODE_DESC_2, ACTION_2),
			new Code(CODE_DESC_3, ACTION_3),
			new Code(CODE_DESC_4, ACTION_4)
		};
		#endregion
	}
}