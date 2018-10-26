using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace BattleScripts
{
	/// <summary>
	/// Random Number Generator used to generate a random number.
	/// - Contains a public field Randval which is synchronized by PhotonView 
	/// </summary>
	public class RNG : MonoBehaviourPunCallbacks, IPunObservable {
		#region Private Fields
		[SerializeField]
		int randVal = 0;
		#endregion

		#region Public Fields
		public int RandVal 
		{
			get {				
				return randVal;
			}
		}

		#endregion

		#region Public Methods
		public void Randomize()
		{
			if (photonView.IsMine)
			{
				randVal = Random.Range(0,Consts.CodeList.Count);
			}
		}
		#endregion

		#region IPunObservable implementation
		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.IsWriting)
			{
				// We own this player: send the others our data
				stream.SendNext(randVal);
			}
			else
			{
				// Network player, receive data
				this.randVal = (int)stream.ReceiveNext();					
			}
		}
		#endregion
	}
}