using System.Linq;
using UniRx;
using UniRxExampleProject.Data;
using UnityEngine;
using UnityFramework.Attributes;

namespace UniRxExampleProject.Models
{
    public class PlayerModel
    {
        [RequiredProperty]
        public ReactiveProperty<string> Name { get; set; }

        [RequiredProperty]
        public ReactiveProperty<int> CurrentHealth { get; set; }

        [RequiredProperty]
        public ReadOnlyReactiveProperty<bool> IsDead { get; set; }

        public PlayerModel(PlayerData playerData)
        {
            this.Name = new ReactiveProperty<string>(playerData.Name);

            this.CurrentHealth = new ReactiveProperty<int>(playerData.MaxHealth);

            this.IsDead = this.CurrentHealth
                .Select(x => x <= 0)
                .ToReadOnlyReactiveProperty();
        }

        public void Reset(PlayerData playerData)
        {
            this.Name.Value = playerData.Name;

            this.CurrentHealth.Value = playerData.MaxHealth;
        }
    }
}
