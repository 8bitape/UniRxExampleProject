using UniRx;
using UniRxEventAggregator.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UniRxExampleProject.Presenters
{
    public class PlayerView : PubSubMonoBehaviour
    {
        [SerializeField]
        private Text _nameText;

        [RequiredProperty]
        public Text NameText { get { return this._nameText; } }

        [SerializeField]
        private Text _currentHealthText;

        [RequiredProperty]
        public Text CurrentHealthText { get { return this._currentHealthText; } }

        [SerializeField]
        private Button _decreaseHealthButton;

        [RequiredProperty]
        public Button DecreaseHealthButton { get { return this._decreaseHealthButton; } }

        private void Awake()
        {
            if (!this.IsValidObject())
            {
                return;
            }
            
            this.Register(new BehaviorSubject<PlayerView>(this));
        }
    }
}