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
            // Loads player data from scriptable object
            this.PlayerData = Resources.Load<PlayerData>(this._playerDataPath);

            if (!this.PlayerData.IsValidObject())
            {
                return;
            }

            // Creates new player model from player data
            this.PlayerModel = new PlayerModel(this.PlayerData);

            if (!this.PlayerModel.IsValidObject())
            {
                return;
            }

            // Registers player model so other components can get ref
            this.Register(new BehaviorSubject<PlayerModel>(this.PlayerModel));

            // Adds player health component to factory
            this.gameObject.AddComponent<PlayerHealth>();            
        }
    }
}
