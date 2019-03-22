using UnityEngine;
using UnityValidation.Attributes;

namespace UniRxExampleProject.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private string _name = string.Empty;

        [RequiredProperty]
        public string Name { get { return this._name; } }

        [SerializeField]
        private int _maxHealth = 100;

        [RequiredProperty]
        public int MaxHealth { get { return this._maxHealth; } }
    }
}
