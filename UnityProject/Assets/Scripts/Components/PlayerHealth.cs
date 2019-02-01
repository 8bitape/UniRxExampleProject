using UniRx;
using UniRxEventAggregator.Events;
using UniRxExampleProject.Models;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

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
            PubSub.GetEvent<DecreaseHealth>()
                .Where(_ => this.IsValidObject())
                .Subscribe(this.DecreaseHealth);
        }

        private void DecreaseHealth(DecreaseHealth decreaseHealth)
        {
            this.PlayerModel.CurrentHealth.Value -= decreaseHealth.Damage;
        }
    }
}
