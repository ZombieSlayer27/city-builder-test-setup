namespace Features.Game
{
    using Config;
    using UnityEngine;

    public class GameDebugBehaviour : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartProduction(MapObject.Residence);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                StartProduction(MapObject.Wood);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartProduction(MapObject.Steel);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartProduction(MapObject.Bench);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                StartProduction(MapObject.Tree);
            }
        }

        private void StartProduction(MapObject mapObject)
        {
            var gameEntity = Contexts.sharedInstance.game.CreateEntity();
            gameEntity.AddMapObjectPlacement(mapObject);
        }
    }
}