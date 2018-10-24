using System.Collections;
using System.Collections.Generic;

namespace BattleScripts
{
	/// <summary>
	/// Code which the Programmer could stock in their hand or program
	/// - Display
	/// - Action
	/// - Execute()
	/// </summary>
	public class Code  {

		#region Private Fields
		
		private string display;		
		private Action action;
		
		#endregion

		#region Public Fields
		/// <summary>
		/// Displays to Programmer what the code is supposed to do
		/// </summary>
		public string Display 
		{
			get {return display;}
			set {Display = display;}
		}

		/// <summary>
		/// Action delegate
		/// - Can be used to define an Action that can be assigned to code to run
		/// </summary>
		public delegate void Action();
		
		#endregion

		#region Public Methods
		
		public Code(string _display, Action _action)
		{
			this.display = _display;
			this.action = _action;
		}

		/// <summary>
		/// Executes the code's action
		/// </summary>
		public void Execute()
		{
			this.action();
		}

		#endregion
	}
}