using UniRx;
using UniRxEventAggregator.Events;
using UniRxExampleProject.Models;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UniRxExampleProject.Presenters
{
    public class PlayerPresenter : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private PlayerModel PlayerModel { get; set; }

        [RequiredProperty]
        private PlayerView PlayerView { get; set; }

        private void Awake()
        {
            this.Subscribe<PlayerModel>(x => this.PlayerModel = x);

            this.Subscribe<PlayerView>(x => this.PlayerView = x);
        }

        private void Start()
        {
            if (!this.IsValidObject())
            {
                return;
            }

            this.PlayerView.DecreaseHealth
                .OnClickAsObservable()
                .Subscribe(_ => PubSub.Publish(new DecreaseHealth(10)));

            this.PlayerView.Reset
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    this.PlayerModel.CurrentHealth.Value = this.PlayerModel.MaxHealth.Value;
                    this.PlayerView.DecreaseHealth.interactable = true;
                });                

            this.PlayerModel.Name
                .SubscribeToText(this.PlayerView.Name);

            this.PlayerModel.CurrentHealth
                .SubscribeToText(this.PlayerView.CurrentHealth);

            this.PlayerModel.IsDead
                .Where(x => x)
                .Subscribe(_ => this.PlayerView.DecreaseHealth.interactable = false);                
        }
    }
}
