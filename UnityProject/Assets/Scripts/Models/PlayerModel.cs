using System.Linq;
using UniRx;
using UniRxExampleProject.Data;
using UnityValidation.Attributes;

namespace UniRxExampleProject.Models
{
    public class PlayerModel
    {
        [RequiredProperty]
        public ReactiveProperty<string> Name { get; set; }

        [RequiredProperty]
        public ReactiveProperty<int> MaxHealth { get; set; }

        [RequiredProperty]
        public ReactiveProperty<int> CurrentHealth { get; set; }

        [RequiredProperty]
        public ReadOnlyReactiveProperty<bool> IsDead { get; set; }

        public PlayerModel(PlayerData playerData)
        {
            // Initialises reactive properties with initial data
            this.Name = new ReactiveProperty<string>(playerData.Name);

            this.MaxHealth = new ReactiveProperty<int>(playerData.MaxHealth);

            this.CurrentHealth = new ReactiveProperty<int>(playerData.MaxHealth);

            this.IsDead = this.CurrentHealth
                .Select(x => x <= 0)
                .ToReadOnlyReactiveProperty();
        }
    }
}
