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
        private Text progFooDisplay;

		[Tooltip("UI Text to display Programmer's Bar")]
        [SerializeField]
        private Text progBarDisplay;

		[Tooltip("UI Text to display Programmer's Bug Count")]
        [SerializeField]
        private Text progBugDisplay;


        #endregion


        #region MonoBehaviour Callbacks


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
		}

        #endregion


    }
}