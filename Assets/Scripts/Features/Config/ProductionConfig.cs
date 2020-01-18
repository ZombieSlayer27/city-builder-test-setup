namespace Features.Config
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class ProductionConfig
    {
        [SerializeField] private string id;
        [SerializeField] private bool isAuto;
        [SerializeField] private MapObject mapObject;
        [SerializeField] private Resource productionResource;
        [SerializeField] private int productionAmount;
        [SerializeField] private int productionDelay;
        [SerializeField] private int productionDuration;
        [SerializeField] private List<ResourceData> productionCostData;

        /// <summary>
        /// Name of the Production Building
        /// </summary>
        public string Id => id;

        /// <summary>
        /// Is Production starts automatically
        /// </summary>
        public bool Auto => isAuto;

        /// <summary>
        /// Delay (in seconds) before the production can start
        /// </summary>
        public int ProductionDelay => productionDelay;

        /// <summary>
        /// Duration (in seconds) of the Production
        /// </summary>
        public int ProductionDuration => productionDuration;

        /// <summary>
        /// Amount of resource produced
        /// </summary>
        public int ProductionAmount => productionAmount;

        /// <summary>
        /// Type of Resource produced
        /// </summary>
        public MapObject MapObject => mapObject;

        /// <summary>
        /// Type of resource produced by the building
        /// </summary>
        public Resource ProductionResource => productionResource;

        /// <summary>
        /// Resources required to produce
        /// </summary>
        public List<ResourceData> ProductionCostData => productionCostData;
    }
}