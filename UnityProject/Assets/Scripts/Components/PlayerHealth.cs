using UniRx;
using UniRxEventAggregator.Events;
using UniRxExampleProject.Models;
using UnityValidation.Attributes;
using UnityValidation.Extensions;

namespace UniRxExampleProject.Components
{
    public class PlayerHealth : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private PlayerModel PlayerModel { get; set; }

        public void Awake()
        {
            this.Subscribe<PlayerModel>(x => this.PlayerModel = x);
        }

        public void Start()
        {
            if (!this.IsValidObject())
            {
                return;
            }

            PubSub.GetEvent<DecreaseHealth>()
                .Subscribe(this.DecreaseHealth);
        }

        private void DecreaseHealth(DecreaseHealth decreaseHealth)
        {
            this.PlayerModel.CurrentHealth.Value -= decreaseHealth.Damage;
        }
    }
}
