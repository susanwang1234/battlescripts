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

        #region Private Fields
        [SerializeField]
        PhotonView p1view;
        #endregion

        #region Public Fields
        
        public static GameManager Instance;

        [Tooltip("The Prefab used for representing the player")]
        public GameObject playerPrefab;
        [Tooltip("The P used for representing the player UI")]
        public GameObject playerUI;
        public Programmer p1;
        public Programmer p2;
        public Text p1Name;
        public Text p1Foo;
        public Text p1Bar;
        public Text p1Bugs;
        public Text p1Screen;
        public GameObject[] p1Cards = new GameObject[5];
        public GameObject ExeGameObj;
        public GameObject DrawCardObj;
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
        }

        void Update()
        {
            UpdatePlayerPanel();
            ActivateHand();
        }

        #endregion

        #region Private Methods

        void UpdatePlayerPanel()
        {
            if (p1 != null)
            {
                p1Name.text = p1.GetName();
                p1Foo.text = p1.GetFooText();
                p1Bar.text = p1.GetBarText();
                p1Bugs.text = p1.GetBugText();
                p1Screen.text = p1.PrintScreen();
            }    
            else
            {
                p1Name.text = "";
                p1Foo.text = "";
                p1Bar.text = "";
                p1Bugs.text = "";
                p1Screen.text = "";
            }        
            if (p2 != null)
            {
                p2Name.text = p2.GetName();
                p2Foo.text = p2.GetFooText();
                p2Bar.text = p2.GetBarText();
                p2Bugs.text = p2.GetBugText();
                p2Screen.text = p2.PrintScreen();                
                if (ExeGameObj != null ) ExeGameObj.SetActive(true);
            }
            else 
            {
                p2Name.text = "";
                p2Foo.text = "";
                p2Bar.text = "";
                p2Bugs.text = "";
                p2Screen.text = "";                
                if (ExeGameObj != null ) ExeGameObj.SetActive(false);
            }
        }

        /// <summary>
        /// Called to Geneate P1 Hand
        /// - Should be called in update function
        /// </summary>
        void ActivateHand()
        {
            if (!p1) return;
            if (!p2)
            {
                for (int i = 0; i < Consts.MAX_CARDS_IN_HAND; i++)
                {
                    p1Cards[i].SetActive(false);
                }
                return;
            }
            if (p1.Hand == null)
            {
                p1view.RPC("GenerateHand", RpcTarget.All);
            }
            for (int i = 0; i < Consts.MAX_CARDS_IN_HAND; i++)
            {
                if (i < p1.Hand.Count)
                {                
                    p1Cards[i].SetActive(true);
                    p1Cards[i].GetComponentInChildren<Text>().text = p1.Hand[i].Display;
                }
                else
                {
                    p1Cards[i].SetActive(false);
                }
            }
            DrawCardObj.SetActive(p1.Hand.Count < Consts.MAX_CARDS_IN_HAND && p2 != null);
        }        

        /// <summary>
        /// Load Room based on number of players
        /// </summary>
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
        /// <summary>
        /// Adds card at position I of hand to program
        /// Then generates a new card in that position
        /// </summary>
        public void AddCard(int num)
        {
            if (num >= Consts.MAX_CARDS_IN_HAND || num < 0)
            {
                Debug.Log("Add Card was passed an invalid index");
                return ;
            }
            p1view.RPC("UpdateProgram", RpcTarget.All, num);
        }

        /// <summary>
        /// Calls an RPC call for players when called
        /// - Should be attached to DrawCardObj onclick function
        /// </summary>
        public void DrawCard()
        {
            if (p1.Hand.Count < Consts.MAX_CARDS_IN_HAND) 
            {
                p1view.RPC("DrawCard", RpcTarget.All);
            }
                
        }

        /// <summary>
        /// Forces player to leave the game
        /// - Unregisters players
        /// </summary>
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();     
            if(p1) p1.IsRegistered = false;
            if(p2) p2.IsRegistered = false;       
            UpdatePlayerPanel();
        }

        public void Execute()
        {
            if (p1view == null) 
            {
                Debug.Log("ERROR: p1view is null"); 
                return;
            }
            if (p1 == null)
            {
                Debug.Log("ERROR: p1 is null");
                return;
            }
            if (p2 == null)
            {
                Debug.Log("ERROR: p2view is null");
                return;
            }
            p1view.RPC("Execute", RpcTarget.All);
        }

        public void Register(Programmer _prog)
        {
            if (p1 == null) 
            {
                p1 = _prog;
                p1view = p1.photonView;
            }
            else if (p2 == null && p1 !=_prog) 
            {
                p2 = _prog;
            }
            else Debug.Log("Theres an error with registering");
            _prog.IsRegistered = true;      
            if (_prog.Program == null)      
            {
                _prog.Program = new List<Code>();
            }
        }

        #endregion
    }
}