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

		private bool isCommented;
		
		#endregion

		#region Public Fields
		/// <summary>
		/// Displays to Programmer what the code is supposed to do
		/// </summary>
		public string Display 
		{
			get {
				if (isCommented)
				{
					return Consts.COMMENT + display;	
				}
				return display;
				}
			set {Display = display;}
		}
		/// <summary>
		/// Action delegate
		/// - Can be used to define an Action that can be assigned to code to run
		/// </summary>
		public delegate void Action(Programmer p1, Programmer p2);			

		#endregion

		#region Public Methods
		
		public Code(string _display, Action _action)
		{
			this.display = _display;
			this.action = _action;
			this.isCommented = false;
		}

		/// <summary>
		/// Executes the code's action
		/// </summary>
		public bool Execute(Programmer p1, Programmer p2)
		{
			if (!this.isCommented)
			{
				this.action(p1, p2);
			}		
			return !this.isCommented;	
		}

		/// <summary>
		/// Toggles the code to comment on or not
		/// </summary>
		public void Comment()
		{
			this.isCommented = !this.isCommented;
		}

		/// <summary>
		/// Makes a deep copy of Code
		/// </summary>
		public Code Clone()
		{
			return new Code(this.display, this.action);
		}

		#endregion
	}
}