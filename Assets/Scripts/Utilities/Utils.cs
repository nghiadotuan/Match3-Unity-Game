using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public static class Utils
{
    private static Dictionary<NormalItem.eNormalType, int> s_dicAmountNormalTypeInCells;

    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType) values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static void InitDicAmountNormalType(Board board)
    {
        s_dicAmountNormalTypeInCells ??= new Dictionary<NormalItem.eNormalType, int>();
        s_dicAmountNormalTypeInCells.Clear();

        for (int x = 0; x < board.BoardSizeX; x++)
        {
            for (int y = 0; y < board.BoardSizeY; y++)
            {
                if(board.Cells[x,y].Item == null) continue;
                var item = board.Cells[x, y].Item;
                if (!(item is NormalItem normalItem)) continue;
                var type = normalItem.ItemType;
                if (s_dicAmountNormalTypeInCells.ContainsKey(type))
                {
                    s_dicAmountNormalTypeInCells[type]++;
                }
                else
                {
                    s_dicAmountNormalTypeInCells.Add(type, 1);
                }
            }
        }
        
        SortDictionary();
    }

    // sap xep dictionary tu be -> lon theo gia tri value.
    private static void SortDictionary()
    {
        var ordered = s_dicAmountNormalTypeInCells.OrderBy(x => x.Value);
        s_dicAmountNormalTypeInCells = ordered.ToDictionary(dic => dic.Key, dic => dic.Value);
    }

    private static bool IsTypeSameTypeCellNeighbour(NormalItem.eNormalType type, Cell neighbour)
    {
        if (neighbour == null) return false;
        if (neighbour.Item == null) return false;
        var item = neighbour.Item;
        if (!(item is NormalItem normalItem)) return false;
        return normalItem.ItemType == type;
    }

    public static NormalItem.eNormalType GetTypeNormalItem(this Cell cell)
    {
        foreach (var value in s_dicAmountNormalTypeInCells)
        {
            var type = value.Key;
            if(IsTypeSameTypeCellNeighbour(type, cell.NeighbourUp)) continue;
            if(IsTypeSameTypeCellNeighbour(type, cell.NeighbourBottom)) continue;
            if(IsTypeSameTypeCellNeighbour(type, cell.NeighbourLeft)) continue;
            if(IsTypeSameTypeCellNeighbour(type, cell.NeighbourRight)) continue;
            return type;
        }

        return NormalItem.eNormalType.TYPE_ONE;
    }
}