using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace BattleScripts
{
	public class Programmer : MonoBehaviourPunCallbacks, IPunObservable {

		#region Public Fields
		
		[Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
		public static GameObject LocalPlayerInstance;

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
		/// Programmer bug count
		/// - Programmer loses when it hits a threshold defined in Consts
		/// - Increments everytime foo or bar overflows or underflows
		/// </summary>
		[Tooltip("Programmer's bug count")]
		public byte Bugs;

		public bool IsRegistered;

		public bool Turn;

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
			IsRegistered = false;
			Foo = Consts.START_FOO_POINTS;
			Bar = Consts.START_BAR_POINTS;
			Bugs = Consts.START_BUG_COUNT;
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
			IsRegistered = false;
			GameManager.Instance.Register(this);
		}

		#endregion
	
		#region IPunObservable implementation

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting)
			{
				// We own this player: send the others our data
				stream.SendNext(Foo);
				stream.SendNext(Bar);
				stream.SendNext(Bugs);
				stream.SendNext(IsRegistered);
				stream.SendNext(Turn);
			}
			else
			{
				// Network player, receive data
				this.Foo = (byte)stream.ReceiveNext();
				this.Bar = (byte)stream.ReceiveNext();
				this.Bugs = (byte)stream.ReceiveNext();
				this.IsRegistered = (bool)stream.ReceiveNext();
				this.Bar = (bool)stream.ReceiveNext();
			}
		}

		#endregion
	}
}