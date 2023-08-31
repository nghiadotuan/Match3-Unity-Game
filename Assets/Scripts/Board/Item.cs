using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Skin;
using Utilities;
using Object = UnityEngine.Object;

[Serializable]
public class Item
{
    public int IndexTextureSkin { get; private set; }

    public Cell Cell { get; private set; }

    public Transform View { get; private set; }


    public virtual void SetView(TextureSkin textureSkin)
    {
        // string prefabname = GetPrefabName();
        //
        // if (!string.IsNullOrEmpty(prefabname))
        // {
        //    // GameObject prefab = Resources.Load<GameObject>(prefabname);
        //    var prefab = GameObjectCache.GetGameObjectFromResources(prefabname);
        //     if (prefab)
        //     {
        //         View = GameObject.Instantiate(prefab).transform;
        //     }
        // }

        IndexTextureSkin = GetIndexTextureSkin();
        var prefab = Resources.Load<SpriteRenderer>(Constants.PREFAB_ITEM_BASE);
        if (!prefab) return;
        prefab.sprite = textureSkin.GetTextureItem(IndexTextureSkin);
        View = Object.Instantiate(prefab).transform;
    }

    protected virtual string GetPrefabName()
    {
        return string.Empty;
    }

    protected virtual int GetIndexTextureSkin() => 0;

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
        View.name = "item_" + cell.name;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;

        SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 0;
        }
    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    GameObject.Destroy(View.gameObject);
                    View = null;
                }
            );
        }
    }


    internal void AnimateForHint()
    {
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            GameObject.Destroy(View.gameObject);
            View = null;
        }
    }

    internal void SetItem(TextureSkin textureSkin, DataCellRoot cellRoot)
    {
        SetItemType(cellRoot.IndexTextureSkin);
        SetView(textureSkin);
        View.GetComponent<SpriteRenderer>().sprite = textureSkin.GetTextureItem(cellRoot.IndexTextureSkin);
        SetCell(cellRoot.Cell);
        SetViewPosition(cellRoot.Position);
    }

    protected virtual void SetItemType(int indexTextureSkin)
    {
    }
}