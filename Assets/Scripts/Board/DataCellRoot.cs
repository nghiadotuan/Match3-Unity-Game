using UnityEngine;

[System.Serializable]
public class DataCellRoot
{
    public int BoardX { get; private set; }

    public int BoardY { get; private set; }
    public Cell NeighbourUp { get; set; }

    public Cell NeighbourRight { get; set; }

    public Cell NeighbourBottom { get; set; }

    public Cell NeighbourLeft { get; set; }
    public int IndexTextureSkin { get; private set; }
    public Cell Cell { get; private set; }
    public Vector3 Position { get; private set; }

    public void SetData(Item itemRoot, Cell cellRoot)
    {
        BoardX = cellRoot.BoardX;
        BoardY = cellRoot.BoardY;
        NeighbourUp = cellRoot.NeighbourUp;
        NeighbourRight = cellRoot.NeighbourRight;
        NeighbourBottom = cellRoot.NeighbourBottom;
        NeighbourLeft = cellRoot.NeighbourLeft;

        IndexTextureSkin = itemRoot.IndexTextureSkin;
        Cell = itemRoot.Cell;
        Position = itemRoot.View.position;
    }
}