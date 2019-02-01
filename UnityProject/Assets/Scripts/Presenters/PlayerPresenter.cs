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
            this.PlayerView.DecreaseHealth
                .OnClickAsObservable()
                .Where(_ => this.IsValidObject())
                .Subscribe(_ => PubSub.Publish(new DecreaseHealth(10)));

            this.PlayerView.Reset
                .OnClickAsObservable()
                .Where(_ => this.IsValidObject())
                .Subscribe(_ => PubSub.Publish(new Reset()));

            this.PlayerModel.Name
                .Where(_ => this.IsValidObject())
                .SubscribeToText(this.PlayerView.Name);

            this.PlayerModel.CurrentHealth
                .Where(_ => this.IsValidObject())
                .SubscribeToText(this.PlayerView.CurrentHealth);

            this.PlayerModel.IsDead
                .Where(_ => this.IsValidObject())
                .Where(x => x)
                .Subscribe(_ => this.PlayerView.DecreaseHealth.interactable = false);

            PubSub.GetEvent<Reset>()
                .Where(_ => this.IsValidObject())
                .Subscribe(_ => this.PlayerView.DecreaseHealth.interactable = true);
        }
    }
}
