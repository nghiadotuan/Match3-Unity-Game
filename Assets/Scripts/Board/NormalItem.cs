using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    protected override string GetPrefabName()
    {
        string prefabname = string.Empty;
        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_ONE;
                break;
            case eNormalType.TYPE_TWO:
                prefabname = Constants.PREFAB_NORMAL_TYPE_TWO;
                break;
            case eNormalType.TYPE_THREE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_THREE;
                break;
            case eNormalType.TYPE_FOUR:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FOUR;
                break;
            case eNormalType.TYPE_FIVE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FIVE;
                break;
            case eNormalType.TYPE_SIX:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SIX;
                break;
            case eNormalType.TYPE_SEVEN:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SEVEN;
                break;
        }

        return prefabname;
    }
    
    protected override int GetIndexTextureSkin()
    {
        return ItemType switch
        {
            eNormalType.TYPE_ONE => 0,
            eNormalType.TYPE_TWO => 1,
            eNormalType.TYPE_THREE => 2,
            eNormalType.TYPE_FOUR => 3,
            eNormalType.TYPE_FIVE => 4,
            eNormalType.TYPE_SIX => 5,
            eNormalType.TYPE_SEVEN => 6,
            _ => 0,
        };
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }

    protected override void SetItemType(int indexTextureSkin)
    {
        ItemType = indexTextureSkin switch
        {
            0 => eNormalType.TYPE_ONE,
            1 => eNormalType.TYPE_TWO,
            2 => eNormalType.TYPE_THREE,
            3 => eNormalType.TYPE_FOUR,
            4 => eNormalType.TYPE_FIVE,
            5 => eNormalType.TYPE_SIX,
            6 => eNormalType.TYPE_SEVEN,
            _=> eNormalType.TYPE_ONE
        };
    }
}
