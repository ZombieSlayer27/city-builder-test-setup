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
                StartProduction(MapObject.Building, ProductionBuilding.Residence);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartProduction(MapObject.Building, ProductionBuilding.Wood);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartProduction(MapObject.Building, ProductionBuilding.Steel);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartProduction(MapObject.Decoration, decoration:DecorationBuilding.Bench);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartProduction(MapObject.Decoration, decoration:DecorationBuilding.Tree);
            }
        }

        private void StartProduction(MapObject mapObject, ProductionBuilding building = ProductionBuilding.None, DecorationBuilding decoration = DecorationBuilding.None)
        {
            if (building != ProductionBuilding.None)
            {
                var gameEntity = Contexts.sharedInstance.game.CreateEntity();
                gameEntity.AddProductionInit(building);
            }
            if (decoration != DecorationBuilding.None)
            {
                var gameEntity = Contexts.sharedInstance.game.CreateEntity();
                gameEntity.AddDecorationInit(decoration);
            }
        }
    }
}