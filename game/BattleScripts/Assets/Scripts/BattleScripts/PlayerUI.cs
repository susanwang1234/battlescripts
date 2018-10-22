using UnityEngine;
using UnityEngine.UI;


using System.Collections;


namespace BattleScripts
{
    public class PlayerUI : MonoBehaviour
    {
        #region Private Fields
		private Programmer target;

        [Tooltip("UI Text to display Programmer's Name")]
        [SerializeField]
        private Text progNameText;


        [Tooltip("UI Text to display Programmer's Foo")]
        [SerializeField]
        private Text progFooText;

		[Tooltip("UI Text to display Programmer's Bar")]
        [SerializeField]
        private Text progBarText;

		[Tooltip("UI Text to display Programmer's Bug Count")]
        [SerializeField]
        private Text progBugText;


        #endregion

        #region Private Methods

        void UpdateStatus()
        {
            if (progFooText != null)
            {
                progFooText.text = target.GetFooText();
            }
            if (progBarText != null)
            {
                progBarText.text = target.GetBarText();
            }
            if (progBugText != null)
            {
                progBugText.text = target.GetBugText();
            }
        }

        #endregion


        #region MonoBehaviour Callbacks

        void Awake()
        {
            this.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
        }

        void Update()
        {
            // Destroy itself if the target is null, It's a fail safe when Photon is destroying Instances of a Player over the network
			if (target == null)
			{
				Destroy(this.gameObject);
				return;
			}
            UpdateStatus();
        }

        #endregion


        #region Public Methods
		public void SetTarget(Programmer _target)
		{
			if (_target == null)
			{
				Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
				return;
			}
			// Cache references for efficiency
			target = _target;
			if (progNameText != null)
			{
				progNameText.text = target.photonView.Owner.NickName;
			}
            UpdateStatus();
		}

        #endregion


    }
}