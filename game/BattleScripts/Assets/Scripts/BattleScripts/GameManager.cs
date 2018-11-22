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
    /// <summary>
    /// This class is used for managing the game.
    /// 
    /// Contains references to other players in the game
    ///
    /// Will display Programmer stats onto the screen using Unity Text GameObject
    ///
    /// Connects Inputs from users via buttons and send Photon RPC (Remote Procedure Calls) to players
    ///
    /// This allows players to execute RPC functions locally.
    ///
    /// There will be 2 instances of the GameManager in a 2 player room
    ///
    /// Each Player that is locally controlled will be considered as player 1 on thier client
    /// </summary>
    public class GameManager : MonoBehaviourPunCallbacks
    {

        #region Enums
        public enum GameState 
        {
            WAITING,
            P1_TURN,
            P2_TURN,
            P1_WIN,
            P2_WIN,     
            GAME_OVER
        }

        public enum PanelOn
        {
            TUTORIAL,
            GAME_ON,
            GAME_OVER,
            NONE

        }

        #endregion

        #region Private Fields
        /// <summary>
        /// The PhotonView for Player 1
        ///
        /// It is used to invoke RPC on player 1
        ///
        /// There is no need for a reference to Player 2 PhotonView
        ///
        /// There will be another GameManager which the Player 2 will be registered as player 1
        /// </summary>
        [SerializeField]
        PhotonView p1view;
        #endregion

        #region Public Fields
        /// <summary>
        /// Static instance of the GameManager
        /// 
        /// Can be referred to as GameManager.Instance
        /// 
        /// Will not need to call a constructor for the GameManager
        /// </summary>
        public static GameManager Instance;        

        /// <summary>
        /// Use to check the game state
        /// </summary>
        public GameState gameState;

        /// <summary>
        /// Used to check which panel should be active
        /// </summary>
        public PanelOn ActivePanel = PanelOn.NONE;

        /// <summary>
        /// Last Panel that was activated
        /// </summary>
        public PanelOn LastPanel= PanelOn.NONE;

        /// <summary>
        /// If true, next bug will cause that player to lose
        /// - if both players have bug at the same time, will continue on
        /// If false, first player to get 0 point in foo or bar will lose or first player to get 3 bugs
        /// TODO:
        /// When true, show in game view
        /// </summary>
        public bool IsSuddenDeath;        

        /// <summary>
        /// Winner of the game
        /// </summary>
        public Programmer Winner;

        /// <summary>
        /// Your own username from client  
        /// </summary>
        public string userName = "";

        /// <summary>
        /// Your own user ID from client  
        /// </summary>
        public string userId = "";


        #endregion

        // use this region to declaser objects that need to be paired in unity
        #region Unity Objects

        [Tooltip("The prefab used for representing the player")]
        public GameObject PlayerPrefab;
        
        [Tooltip("The panel used for representing the player UI")]
        public GameObject PlayerUI;

        [Tooltip("The panel used to show tutorial page")]
        public GameObject TutorialPanel;

        [Tooltip("The panel used to show end game page")]
        public GameObject GameEndPanel;

        [Tooltip("The Text to show after game is over")]
        public Text GameOverText;

        [Tooltip("Leave this blank, should be filled when loaded into Room for 1 or Room for 2")]
        public Programmer p1;
        
        [Tooltip("Leave this blank, should be filled when loaded into Room for 2")]
        public Programmer p2;
        
        [Tooltip("Text object to display player 1 name")]
        public Text p1Name;
        
        [Tooltip("Text object to display player 1 foo")]
        public Text p1Foo;
        
        [Tooltip("Text object to display player 1 bar")]
        public Text p1Bar;
        
        [Tooltip("Text object to display player 1 bugs")]
        public Text p1Bugs;
        
        [Tooltip("Text object to display player 1 program")]
        public Text p1Screen;
        
        [Tooltip("An array of button GameObjects to be used as player 1 cards")]
        public GameObject[] p1Cards = new GameObject[5];
        
        [Tooltip("A button gameobject to link to Execute Call")]
        public GameObject ExeGameObj;
        
        [Tooltip("A button gameobject to link to the Draw Card Call")]
        public GameObject DrawCardObj;
        
        [Tooltip("Text Object to display player 2 name")]
        public Text p2Name;
        
        [Tooltip("Text Object to display player 2 foo")]
        public Text p2Foo;
        
        [Tooltip("Text Object to display player 2 bar")]
        public Text p2Bar;
        
        [Tooltip("Text Object to display player 2 bugs")]
        public Text p2Bugs;
        
        [Tooltip("Text Object to display player 2 program")]
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
            IsSuddenDeath = false;
            gameState = GameState.WAITING;
            ActivePanel = PanelOn.NONE;
            LastPanel = PanelOn.NONE;
                        
            if (TutorialPanel == null )
            {
                Debug.Log("ERROR - Tutorial Panel not attached to GameManager");
            }
            if (PlayerUI == null)
            {
                Debug.Log("ERROR - Player Panel not attached to GameManager");
            }
            TutorialPanel.SetActive(false);
            PlayerUI.SetActive(true);
            UpdatePlayerPanel();

            if (Programmer.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.PlayerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }            
        }

        void Update()
        {
            CheckPanelOn();
            UpdatePlayerPanel();
            ActivateHand();
            if (p2 && p1.Bugs >= 3 && p2.Bugs >= 3) IsSuddenDeath = true;            
            CheckGameState();
            CheckPlayerWin();
           
        }

        #endregion

        #region Private Methods

        // Computes MD5 hash of match data using a secret key
        string Md5Sum(string strToEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(strToEncrypt);

            // encrypt bytes
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);

            // Convert the encrypted bytes back to a string (base 16)
            string hashString = "";

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(32, '0');
        }

        // Do a POST request on website to store match results
        IEnumerator PostScores(string p1, bool isWin)
        {
            string result = (isWin) ? "win" : "loss";
            string secretKey = "MvbvBmXOQtZfg28";
            //This connects to a server side php script that will add the name and score to a MySQL DB.
            // Supply it with a string representing the players name and the players score.
            string hash = Md5Sum(p1 + result + secretKey);

            string post_url = Consts.APPLICATION_URL + "player_id=" + WWW.EscapeURL(p1) + "&result=" + result + "&hash=" + hash;
            Debug.Log(post_url);
            // Post the URL to the site and create a download object to get the result.
            WWW post = new WWW(post_url);
            yield return post; // Wait until the download is done
            if (post.error != null)
            {
                    WebController.Alert();
                    Debug.Log("There was an error posting win record: " + post.error);
               
            }
        }

        void CheckGameState()
        {
            if (!p2) 
            {
                gameState = GameState.WAITING;
                return;
            }
            switch (gameState)
            {
                case GameState.WAITING:
                    // When both players have joined
                    // rng determines who goes first
                    if (p1 != null && p2 != null)
                    {                        
                        int t1 = p1.rng.GetRandomInt();
                        int t2 = p2.rng.GetRandomInt(); 
                        Debug.Log("T1="+t1.ToString());
                        Debug.Log("T2="+t2.ToString());
                        if (t1 > t2)
                        {
                            p1.Turn = true;
                            p2.Turn = false;
                            gameState = GameState.P1_TURN;
                            Debug.Log("Player 1 Turn");
                        }
                        else if (t2 > t1) 
                        {
                            p1.Turn = false;
                            p2.Turn = true;
                            gameState = GameState.P2_TURN;
                            Debug.Log("Player 2 Turn");
                        }
                        else
                        {
                            Debug.Log("Deciding on who's turn it is...");
                        }
                    }                        
                    break;

                case GameState.P1_TURN:
                    if (!p1.Turn)
                    {
                        p2.Turn = true;
                        gameState =GameState.P2_TURN;
                    }
                    break;

                case GameState.P2_TURN:
                    if (!p2.Turn)
                    {
                        p1.Turn = true;
                        gameState =GameState.P1_TURN;
                    }
                    break;

                case GameState.P1_WIN:        
                    Debug.Log("Player 1 Won"); 
                    Winner = p1;
                    GameOverText.text = Consts.ON_WIN_TEXT;
                    gameState = GameState.GAME_OVER;
                    StartCoroutine(PostScores(Consts.userID, true));
                    break;

                case GameState.P2_WIN:
                    Debug.Log("Player 2 Won");
                    Winner = p2;
                    GameOverText.text = Consts.ON_LOSE_TEXT;
                    gameState = GameState.GAME_OVER;
                    StartCoroutine(PostScores(Consts.userID, false));
                    break;

                case GameState.GAME_OVER:                    
                    if (p1.PlayAgain && p2.PlayAgain)
                    {
                        p1.ResetPlayerStats();
                        p2.ResetPlayerStats();
                        Winner = null;
                        ActivePanel = PanelOn.GAME_ON;
                        LastPanel = PanelOn.NONE;
                        gameState = GameState.WAITING;
                    }
                    break;

                default:
                    Debug.Log("ERROR-Unknown Game State : " + gameState);
                    break;
            }
        }

        void CheckPanelOn()
        {
            switch (ActivePanel)
            {
                case PanelOn.GAME_ON:
                    PlayerUI.SetActive(true);
                    TutorialPanel.SetActive(false);
                    GameEndPanel.SetActive(false);
                    break;

                case PanelOn.TUTORIAL:
                    PlayerUI.SetActive(false);
                    TutorialPanel.SetActive(true);
                    GameEndPanel.SetActive(false);
                    break;

                case PanelOn.GAME_OVER:
                    PlayerUI.SetActive(false);
                    TutorialPanel.SetActive(false);
                    GameEndPanel.SetActive(true);              
                    break;

                case PanelOn.NONE:
                    PlayerUI.SetActive(false);
                    TutorialPanel.SetActive(false);
                    GameEndPanel.SetActive(false);
                    break;

                default:
                    Debug.Log("ERROR-Unknown Panel Being Activated : " + ActivePanel);
                    ActivePanel = PanelOn.GAME_ON;
                    break;
            }
        }

        /// <summary>
        /// Checks to see if either player's have won
        ///
        /// If one player ends a turn with 0 foo or bar or has 3 bugs then that players lose
        ///
        /// If both players lose, the game goes into sudden death
        ///
        /// Next player to have a bug will lose
        /// </summary>
        void CheckPlayerWin()
        {
            if (!p2 || gameState == GameState.GAME_OVER) return;

            // This line is used to check for the cheat code
            // In release build, this should not be here
            if (Winner != null)
            {
                gameState = (Winner == p1) ? GameState.P1_WIN : GameState.P2_WIN; 
            }

            if (p1.Bugs >= 3 && p1.Bugs > p2.Bugs)
            {
                gameState = GameState.P2_WIN;
            }
            if ((p1.Foo == 0 || p1.Bar == 0) && (p2.Foo != 0 && p2.Bar != 0) )
            {
                gameState = GameState.P2_WIN;
            }
            if (p2.Bugs >= 3 && p2.Bugs > p1.Bugs)
            {
                gameState = GameState.P1_WIN;
            }
            if ((p2.Foo == 0 || p2.Bar == 0) && (p1.Foo != 0 && p1.Bar != 0) )
            {
                gameState = GameState.P1_WIN;
            }            
            if (gameState == GameState.P1_WIN || gameState == GameState.P2_WIN)
            {
                p1.ResetPlayerStats();
                p2.ResetPlayerStats();
                LastPanel = ActivePanel;
                ActivePanel = PanelOn.GAME_OVER;
            }
        }

        /// <summary>
        /// Updates PlayerPanel every frome.
        /// </summary>
        void UpdatePlayerPanel()
        {
            string turn = " -> (Turn)"; // TODO: Need better way to visualize player turn

            if (p1 != null)
            {
                p1Name.text = p1.GetName();
                if (gameState == GameState.P1_TURN)
                {
                    p1Name.text += turn;
                }
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
                Debug.Log("ERROR - Gamanager has no player 1");
            }        
            if (p2 != null)
            {
                p2Name.text = p2.GetName();
                if (gameState == GameState.P2_TURN)
                {
                    p2Name.text += turn;
                }
                p2Foo.text = p2.GetFooText();
                p2Bar.text = p2.GetBarText();
                p2Bugs.text = p2.GetBugText();
                p2Screen.text = p2.PrintScreen();            
                   
                if (ExeGameObj != null ) ExeGameObj.SetActive(true);

                ActivePanel = (ActivePanel == PanelOn.NONE) ? PanelOn.GAME_ON : ActivePanel;
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
                DrawCardObj.SetActive(false);
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
            DrawCardObj.SetActive(p1.Hand.Count < Consts.MAX_CARDS_IN_HAND );
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
        /// When it is P1's turn. Adds card at position i of hand to program
        ///
        /// Then generates a new card in that position
        /// </summary>
        public void AddCard(int num)
        {
            // Gamemanger is in charge of p1 state, so return if game state is not p1 turn
            if (gameState != GameState.P1_TURN) return;
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
        /// - Will also Unregisters all players registered to the GameManager
        /// - Will also clear p1 data and set p2 to null
        /// </summary>
        public void LeaveRoom()
        {            
            if(p1) 
            {
                p1.IsRegistered = false;
                p1.ResetPlayerStats();
                Debug.Log("Cleared P1 Data");
            }
            if(p2) 
            {
                p2.IsRegistered = false;       
                p2 = null;
                Debug.Log("Erased P2 Data...");
            }
            UpdatePlayerPanel();
            ActivePanel = PanelOn.NONE;
            LastPanel = PanelOn.NONE;
            PhotonNetwork.LeaveRoom();     
        }

        /// <summary>
        /// Link this function to the ExeGameObj.
        ///
        /// Will call the player's execute function on P1's turn.
        /// </summary>
        public void Execute()
        {
            // Gamemanger is in charge of p1 state, so return if game state is not p1 turn
            if (gameState != GameState.P1_TURN) return;
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
            p1.Execute(p1, p2);
            p1view.RPC("RpcExecute", RpcTarget.Others);
        }

        /// <summary>
        /// Used to register players to the game manager.
        ///
        /// Allows players to refer to each other via GameManager.Instance.p1 
        ///
        /// or GameManager.Instance.p2
        ///
        /// Params :
        /// - Programmer _prog -> Player to be registerd
        ///</summary>
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
                // call this to randomize p1 and p2 random number
                // will be used later to see who gets to go first
                // call now to get a random number, and again in update
                p1.rng.GetRandomInt();
                p2.rng.GetRandomInt();
            }
            else Debug.Log("Theres an error with registering");
            _prog.IsRegistered = true;      
            if (_prog.Program == null)      
            {
                _prog.Program = new List<Code>();
            }
        }

        /// <summary>
        /// Toggle on and off tutorial panel
        /// </summary>
        public void ToggleTutorial()
        {
            PanelOn cache = ActivePanel;
            ActivePanel = (ActivePanel != PanelOn.TUTORIAL) ?  PanelOn.TUTORIAL : LastPanel;
            LastPanel = cache;         
            Debug.Log("Panel State is now" + ActivePanel);
        }

        /// <summary>
        /// Tells that player is ready to restart
        /// </summary>
        public void Rematch()
        {
            p1view.RPC("RpcRestart", RpcTarget.All);
            GameOverText.text = Consts.ON_REMATCH_TEXT;
        }

        #endregion
    }
}