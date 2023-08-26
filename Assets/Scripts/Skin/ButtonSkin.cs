using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Skin
{
    public class ButtonSkin : MonoBehaviour
    {
        [SerializeField] private Text _textSkin;
        [SerializeField] private Image _imageBtn;

        private SkinItem _skinItem;

        public void Init(SkinItem skinItem, string nameSkin)
        {
            _skinItem = skinItem;
            _textSkin.text = nameSkin;
        }

        public void SetStateButton(SkinItem skinItem)
        {
            _imageBtn.DOFade(_skinItem == skinItem ? 1 : .5f, 0);
        }
    }
}