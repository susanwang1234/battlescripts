using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleScripts
{
	public class Programmer : MonoBehaviour {

		#region Private Fields
		
		/// <summary>
		/// </summary>
		private List<Code> program;
		
		/// <summary>
		/// </summary>
		private List<Code> hand;
		
		/// <summary>
		/// Programmer hit points. 
		/// - Range from 0-255
		/// - Will overflow or underflow (which should increment bugs)
		/// - Programmer loses when bar == 0 
		/// </summary>
		private byte foo;

		/// <summary>
		/// Programmer energy points. 
		/// - Range from 0-255
		/// - Will overflow or underflow (which should increment bugs)
		/// - Programmer loses when bar == 0 
		/// </summary>
		private byte bar;

		/// <summary>
		/// # of bugs a programmer has
		/// - Programmer loses when it hits a threshold defined in Consts
		/// - Increments everytime foo or bar overflows or underflows
		/// </summary>
		private byte bugs;


		#endregion

		#region Public Methods
		/// <summary>
		/// Displays the program that the Programmer has
		/// </summary>
		public string PrintScreen()
		{
			string screen = "";
			int n = program.Count;
			for (int i = 0; i < n; i++)
			{
				screen += program[i].Display;
				screen += "\n";
			}
			return screen;
		}
		#endregion

		#region MonoBehaviour CallBacks
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		#endregion
	}
}