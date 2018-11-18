using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace BattleScripts {
	public class RoomName : MonoBehaviour {
		#region Public Fields
		public Text Name;
		#endregion


		#region Monobehaviour Callbacks
		// Update is called once per frame
		void Update () {
			this.Name.text = Consts.ROOM_PROMPT + PhotonNetwork.CurrentRoom.Name;
		}
		#endregion
	}
}