namespace Features.Config
{
    using System;
    using UnityEngine;

    [Serializable]
    public class IconAsset
    {
        [SerializeField] private Resource key;
        [SerializeField] private Sprite value;

        public Resource Key => key;
        public Sprite Value => value;
    }
}