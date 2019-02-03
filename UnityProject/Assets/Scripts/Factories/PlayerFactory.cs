using UniRx;
using UniRxEventAggregator.Events;
using UniRxExampleProject.Components;
using UniRxExampleProject.Data;
using UniRxExampleProject.Models;
using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UniRxExampleProject.Factories
{
    public class PlayerFactory : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private PlayerData PlayerData { get; set; }

        [RequiredProperty]
        private PlayerModel PlayerModel { get; set; }
        
        private readonly string _playerDataPath = "Data/PlayerData";

        private void Awake()
        {
            this.PlayerData = Resources.Load<PlayerData>(this._playerDataPath);

            if (!this.PlayerData.IsValidObject())
            {
                return;
            }

            this.PlayerModel = new PlayerModel(this.PlayerData);

            if (!this.PlayerModel.IsValidObject())
            {
                return;
            }

            this.Register(new BehaviorSubject<PlayerModel>(this.PlayerModel));

            this.gameObject.AddComponent<PlayerHealth>();            
        }
    }
}
