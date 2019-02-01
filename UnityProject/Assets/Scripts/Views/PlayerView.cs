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
        private Text _name = null;

        [RequiredProperty]
        public Text Name { get { return this._name; } }

        [SerializeField]
        private Text _currentHealth = null;

        [RequiredProperty]
        public Text CurrentHealth { get { return this._currentHealth; } }

        [SerializeField]
        private Button _decreaseHealth = null;

        [RequiredProperty]
        public Button DecreaseHealth { get { return this._decreaseHealth; } }

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