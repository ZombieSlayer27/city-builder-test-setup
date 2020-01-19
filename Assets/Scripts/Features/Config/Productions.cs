namespace Features.Config
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class Productions
    {
        [SerializeField]
        private List<ProductionConfig> config;

        /// <summary>
        /// Collection of production Configs
        /// </summary>
        public List<ProductionConfig> Config => config;
    }
}