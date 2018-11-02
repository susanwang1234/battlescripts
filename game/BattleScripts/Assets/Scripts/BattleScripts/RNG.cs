using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace BattleScripts
{
	/// <summary>
	/// Random Number Generator used to generate a random number.
	/// </summary>
	public class RNG : MonoBehaviourPunCallbacks, IPunObservable {
		#region Private Fields
		/// <summary>
		/// Random value to be sync across clients
		/// </summary>
		[SerializeField]
		int randVal;
		#endregion

		#region Public Methods
		/// <summary>
		/// Used to generate a random value
		///
		/// Only the owner of the photonView will generate a new random value
		///
		/// Returns old random value
		/// </summary>
		public int GetRandomInt()
		{
			int cache = randVal;	// old random value to return later
			if (photonView.IsMine)
			{
				randVal = Random.Range(1,Consts.CodeList.Count);
			}
			return cache;
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