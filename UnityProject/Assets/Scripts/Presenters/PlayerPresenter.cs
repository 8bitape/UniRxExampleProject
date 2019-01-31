using UniRxEventAggregator.Events;
using UniRxExampleProject.Models;
using UnityEngine;
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
            if(this.PlayerModel.IsValidObject())
            {
                Debug.Log(this.PlayerModel.Name);
            }

            if (this.PlayerView.IsValidObject())
            {
                Debug.Log(this.PlayerView.CurrentHealthText.text);
            }
        }
    }
}
