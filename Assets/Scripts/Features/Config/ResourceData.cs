namespace Features.Config
{
    using System;
    using UnityEngine;

    [Serializable]
    public class ResourceData
    {
        [SerializeField] private int amount;
        [SerializeField] private Resource resource;

        /// <summary>
        /// Cost of Resource
        /// </summary>
        public int Amount => amount;

        /// <summary>
        /// Resource Type
        /// </summary>
        public Resource Resource => resource;
    }
}