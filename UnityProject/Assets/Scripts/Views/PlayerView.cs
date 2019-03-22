using UniRx;
using UniRxEventAggregator.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityValidation.Attributes;
using UnityValidation.Extensions;

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

        [SerializeField]
        private Button _reset = null;

        [RequiredProperty]
        public Button Reset { get { return this._reset; } }

        private void Awake()
        {
            if (!this.IsValidObject())
            {
                return;
            }
            
            // Registers view so other components can get ref
            this.Register(new BehaviorSubject<PlayerView>(this));
        }
    }
}