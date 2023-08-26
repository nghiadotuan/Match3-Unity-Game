using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skin
{
    [Serializable]
    public class TextureSkin
    {
        [SerializeField] private SkinItem _skinItem;
        [SerializeField] private string _nameSkin;
        [SerializeField] private List<Sprite> _listTextureItems;

        public Sprite GetTextureItem(int index)
        {
            if (index < 0 || index >= _listTextureItems.Count)
            {
                throw new Exception("Index out range of list");
            }

            return _listTextureItems[index];
        }

        public SkinItem SkinItem => _skinItem;
        public string NameSkin => _nameSkin;
    }
}