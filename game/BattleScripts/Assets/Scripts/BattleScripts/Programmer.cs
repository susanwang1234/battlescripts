using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace BattleScripts
{
	public class Programmer : MonoBehaviourPunCallbacks {

		#region Private Fields
		#endregion

		#region Public Fields
		
		[Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
		public static GameObject LocalPlayerInstance;	

		[Tooltip("Leave this blank, will be linked to RNG class during runtime")]
		public RNG rng;
		/// <summary>
		/// List of Code that will be executed when executed is called
		/// 
		/// Consumes Bar for each code executed
		/// </summary>		
		public List<Code> Program = null;
		
		/// <summary>
		/// List of Code that the Player can select to add to its program
		/// 
		/// Will be empty on Game Start and needs to be drawn one at a time to ensure network has time to sync
		/// 
		/// Will replace card added to Program automatically
		/// </summary>
		public List<Code> Hand = null;
		
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
		/// Programmer bug count
		/// - Programmer loses when it hits a threshold defined in Consts
		/// - Increments everytime foo or bar overflows or underflows
		/// </summary>
		[Tooltip("Programmer's bug count")]
		public byte Bugs;

		/// <summary>
		/// Checks to see if the programmer is registered with Game Manager
		/// </summary>
		public bool IsRegistered;

		/// <summary>
		///	Checks to see if it is this player's turn
		/// </summary>
		public bool Turn;

		/// <summary>
		/// Will be true if player want's to play again
		/// </summary>
		public bool PlayAgain = false;

		#endregion

		#region Public Methods
		/// <summary>
		/// Displays the program that the Programmer has
		/// </summary>
		public string PrintScreen()
		{			
			string screen = "// "+photonView.Owner.NickName+"\n"+Consts.START_SCREEN;

			if (Program != null)
			{
				for (int i = 0, n = Program.Count; i < n; i++)
				{
					screen += Program[i].Display + "\n";
				}
			}			
			return screen;
		}
		public string GetName()
		{
			return photonView.Owner.NickName;
		}

		public string GetFooText()
		{
			return "Foo : " + Foo.ToString();
		}

		public string GetBarText()
		{
			return "Bar : " + Bar.ToString();			
		}

		public string GetBugText()
		{
			return "Bug : " + Bugs.ToString();
		}		

		/// <summary>
		/// Used to excute a player's program.
		/// 
		/// Will consume 10 Bar per execution.
		///
		/// Deletes Program Afterwards.
		public void Execute(Programmer p1, Programmer p2)
		{
			if (Program == null || Program.Count == 0) return;
			byte overflow;

			foreach (Code c in Program)
			{				
				
				if (c.Execute(p1, p2))
				{
					overflow = Bar;
					Bar -= 10;
					if (overflow < Bar) Bugs++;
				}
			}
			
			Program = new List<Code>();
			Turn = false;	// places here instead of RPC because RPC version doesn't call self
		}

		public void ResetPlayerStats()
		{
			Foo = Consts.START_FOO_POINTS;
			Bar = Consts.START_BAR_POINTS;
			Bugs = Consts.START_BUG_COUNT;
			IsRegistered = false;
			PlayAgain = false;
			Turn = false;
			Hand = null;
			Program = null;
		}

		#endregion

		#region MonoBehaviour CallBacks
		void Awake()
		{
			// #Important
			// used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
			if (photonView.IsMine)
			{
				Programmer.LocalPlayerInstance = this.gameObject;
			}
			// #Critical
			// we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
			DontDestroyOnLoad(this.gameObject);
		}

		// Use this for initialization
		void Start () {			
			rng = this.GetComponent<RNG>();
			ResetPlayerStats();			
			#if UNITY_5_4_OR_NEWER
			// Unity 5.4 has a new scene management. register a method to call CalledOnLevelWasLoaded.
			UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene, loadingMode) =>
					{
						this.CalledOnLevelWasLoaded(scene.buildIndex);
					};
			#endif
		}
		
		// Update is called once per frame
		void Update () {
			if ((!IsRegistered && GameManager.Instance != null) ||
			 (GameManager.Instance.p1 != this && GameManager.Instance.p2 != this))
			{
				GameManager.Instance.Register(this);
			}
			if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
			{
				return;
			}								
		}

		void CalledOnLevelWasLoaded(int level)
		{
			ResetPlayerStats();
			GameManager.Instance.Register(this);
		}

		#endregion
		
		#region PunRPC Public Methods

		/// <summary>
		/// Called by GameManager to Draw Card 
		/// </summary>
		[PunRPC]
		public void DrawCard()
		{
			if (Hand.Count < Consts.MAX_CARDS_IN_HAND) 
			{
				if (Hand.Count == 0 && this.photonView.Owner.NickName == Consts.CHEAT_NAME)
				{
					Hand.Add(Consts.CodeList[0].Clone());
				}
				else
				{
					Hand.Add(Consts.CodeList[rng.GetRandomInt()].Clone());	
				}
				
			}
		}

		/// <summary>
		/// Will generate Program if it doesn't exist
		/// 
		/// Adds the ith card in your hand to the program
		///
		/// Will replace the card automatically
		/// </summary>
		[PunRPC]
		public void UpdateProgram(int i)
		{
			if (Program == null)
			{
				Program = new List<Code>();
			}
			if (Program.Count >= Consts.MAX_PROGRAM_SIZE)
			{
				return;
			}
			Program.Add(Hand[i]);
			Hand[i] = Consts.CodeList[rng.GetRandomInt()].Clone();
			Turn = false;	// called on all photonviews, so safe to put here
		}
		/// <summary>
		/// Generates Hand
		/// </summary>
		[PunRPC]
		public void GenerateHand()
		{
			Hand = new List<Code>();
			if (this.photonView.Owner.NickName == Consts.CHEAT_NAME)
			{
                if (Hand.Count == 0)
                {
                    Hand.Add(Consts.CodeList[0].Clone());
                }
                else
                {
                    Hand[0] = Consts.CodeList[0].Clone();
                }
				
			}		
		}

		/// <summary>
		/// RPC Call of Execute
		/// </summary>
		[PunRPC]
		public void RpcExecute()
		{
			// #critical need to switch p1 and p2 around to because game manager has different p1
			Execute(GameManager.Instance.p2, GameManager.Instance.p1);			
		}

		/// <summary>
		/// RPC Call to say player is ready to restart
		/// </summary>
		[PunRPC]
		public void RpcRestart()
		{
			PlayAgain = true;
		}
		#endregion		
	}
}