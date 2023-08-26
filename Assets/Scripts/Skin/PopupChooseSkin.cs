using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Skin
{
    public class PopupChooseSkin : MonoBehaviour
    {
        [SerializeField] private SOTextureSkin _textureSkin;
        [SerializeField] private Transform _parentListBtnSelectSkin;

        private List<ButtonSkin> _lisBtnSkin;

        private void Start()
        {
            _textureSkin.SkinItem = SkinItem.Normal;
            CreateListBtnSelectSkin();
        }

        private void CreateListBtnSelectSkin()
        {
            _lisBtnSkin ??= new List<ButtonSkin>();
            var prefab = GameObjectCache.GetGameObjectFromResources("prefabs/BtnSelectSkin");
            foreach (var skin in _textureSkin.Skins)
            {
                var btn = Instantiate(prefab, _parentListBtnSelectSkin).GetComponent<ButtonSkin>();
                btn.Init(skin.SkinItem, skin.NameSkin);
                _lisBtnSkin.Add(btn);
                btn.GetComponent<Button>().onClick.AddListener(() => OnClickBtnSelectSkin(skin.SkinItem));
            }
            
            SetStateListButton();
        }

        private void OnClickBtnSelectSkin(SkinItem skin)
        {
            switch (skin)
            {
                case SkinItem.Normal:
                default:
                    _textureSkin.SkinItem = SkinItem.Normal;
                    break;
                case  SkinItem.Fish:
                    _textureSkin.SkinItem = SkinItem.Fish;
                    break;
            }

            SetStateListButton();
        }

        private void SetStateListButton()
        {
            foreach (var btn in _lisBtnSkin)
            {
                btn.SetStateButton(_textureSkin.SkinItem);
            }
        }
    }
}