using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;


namespace BattleScripts
{
    public class GameManager : MonoBehaviourPunCallbacks
    {

        #region Public Fields
        
        public static GameManager Instance;

        [Tooltip("The Prefab used for representing the player")]
        public GameObject playerPrefab;
        [Tooltip("The P used for representing the player UI")]
        public GameObject playerUI;
        public List<Programmer> ProgrammerCollection;
        public Text p1Name;
        public Text p1Foo;
        public Text p1Bar;
        public Text p1Bugs;
        public Text p1Screen;
        public Text p2Name;
        public Text p2Foo;
        public Text p2Bar;
        public Text p2Bugs;
        public Text p2Screen;

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


                LoadArena();
            }
        }

        #endregion

        #region MonoBehaviour CallBacks

        void Start()
        {
            Instance = this;
            UpdatePlayerPanel();

            if (Programmer.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }
            ProgrammerCollection = new List<Programmer>();
        }

        void Update()
        {
            UpdatePlayerPanel();
        }

        #endregion

        #region Private Methods

        void UpdatePlayerPanel()
        {
            if (ProgrammerCollection.Count > 0)
            {
                p1Name.text = ProgrammerCollection[0].GetName();
                p1Foo.text = ProgrammerCollection[0].GetFooText();
                p1Bar.text = ProgrammerCollection[0].GetBarText();
                p1Bugs.text = ProgrammerCollection[0].GetBugText();
                p1Screen.text = ProgrammerCollection[0].GetName() + "'s Screen\n";
                if (ProgrammerCollection.Count > 1)
                {
                    p2Name.text = ProgrammerCollection[1].GetName();
                    p2Foo.text = ProgrammerCollection[1].GetFooText();
                    p2Bar.text = ProgrammerCollection[1].GetBarText();
                    p2Bugs.text = ProgrammerCollection[1].GetBugText();
                    p2Screen.text = ProgrammerCollection[1].GetName() + "'s Screen\n";
                }
                else 
                {
                    p2Name.text = "";
                    p2Foo.text = "";
                    p2Bar.text = "";
                    p2Bugs.text = "";
                    p2Screen.text = "";
                }
            }    
            else
            {
                p1Name.text = "";
                p1Foo.text = "";
                p1Bar.text = "";
                p1Bugs.text = "";
                p1Screen.text = "";
            }        
        }

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        #endregion

        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
            ProgrammerCollection = null;
            UpdatePlayerPanel();
        }

        public void Register(Programmer _prog)
        {
            ProgrammerCollection.Add(_prog);
            _prog.IsRegistered = true;            
        }

        #endregion
    }
}