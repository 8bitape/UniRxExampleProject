using UniRxEventAggregator.Events;
using UniRxExampleProject.Models;

namespace UniRxExampleProject.Components
{
    public class PlayerHealth : PubSubMonoBehaviour
    {
        private PlayerModel PlayerModel { get; set; }

        public void Init(PlayerModel playerModel)
        {
            this.PlayerModel = playerModel;
        }
    }
}
