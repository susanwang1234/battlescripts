using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleScripts
{
	public class Programmer : MonoBehaviour {

		#region Public Fields
		
		/// <summary>
		/// Instance of Programmer for current player to refer to
		///</summary>
		public static Programmer Instance;

		/// <summary>
		/// </summary>
		public List<Code> Program;
		
		/// <summary>
		/// </summary>
		public List<Code> Hand;
		
		/// <summary>
		/// Programmer hit points. 
		/// - Range from 0-255
		/// - Will overflow or underflow (which should increment bugs)
		/// - Programmer loses when bar == 0 
		/// </summary>
		[Tooltip("Programmer's hit points")]
		public byte Foo;

		/// <summary>
		/// Programmer energy points. 
		/// - Range from 0-255
		/// - Will overflow or underflow (which should increment bugs)
		/// - Programmer loses when bar == 0 
		/// </summary>
		[Tooltip("Programmer's energy points")]
		public byte Bar;

		/// <summary>
		/// # of bugs a programmer has
		/// - Programmer loses when it hits a threshold defined in Consts
		/// - Increments everytime foo or bar overflows or underflows
		/// </summary>
		[Tooltip("Programmer's bug count")]
		public byte Bugs;

		#endregion

		#region Public Methods
		/// <summary>
		/// Displays the program that the Programmer has
		/// </summary>
		public string PrintScreen()
		{
			string screen = "";
			int n = Program.Count;
			for (int i = 0; i < n; i++)
			{
				screen += Program[i].Display;
				screen += "\n";
			}
			return screen;
		}
		#endregion

		#region MonoBehaviour CallBacks
		// Use this for initialization
		void Start () {
			Foo = Consts.START_FOO_POINTS;
			Bar = Consts.START_BAR_POINTS;
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		#endregion
	}
}