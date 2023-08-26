using UnityEngine;

namespace Skin
{
    [CreateAssetMenu(menuName = "Skin")]
    public class SOTextureSkin : ScriptableObject
    {
        [SerializeField] private TextureSkin[] _skins;
        [SerializeField] private TextureSkin _bonusSkin;

        public TextureSkin[] Skins => _skins;
        public TextureSkin BonusSkin => _bonusSkin;

        public SkinItem SkinItem { get; set; }

        public TextureSkin GetTextureSkin()
        {
            return _skins[(sbyte) SkinItem];
        }
    }

    public enum SkinItem : sbyte
    {
        Bonus = -1,
        Normal = 0,
        Fish = 1
    }
}