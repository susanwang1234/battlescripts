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
			Foo = Consts.START_FOO_POINTS;
			Bar = Consts.START_BAR_POINTS;
			Bugs = 0;
		}
		
		// Update is called once per frame
		void Update () {
			if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
			{
				return;
			}
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
			}
			else
			{
				// Network player, receive data
				this.Foo = (byte)stream.ReceiveNext();
				this.Bar = (byte)stream.ReceiveNext();
				this.Bugs = (byte)stream.ReceiveNext();
			}
		}

		#endregion
	}
}