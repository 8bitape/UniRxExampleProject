using System.Linq;
using UniRx;
using UnityEngine;
using UnityFramework.Attributes;

namespace UniRxExampleProject.Models
{
    public class PlayerModel
    {
        [RequiredProperty]
        public ReactiveProperty<string> Name { get; private set; }

        [RequiredProperty]
        public ReactiveProperty<int> CurrentHealth { get; private set; }

        [RequiredProperty]
        public ReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        public PlayerModel(string name, int maxHealth)
        {
            this.Name = new ReactiveProperty<string>(name);

            this.CurrentHealth = new ReactiveProperty<int>(maxHealth);

            this.IsDead = this.CurrentHealth.Select(x => x <= 0).ToReadOnlyReactiveProperty();
        }
    }
}
