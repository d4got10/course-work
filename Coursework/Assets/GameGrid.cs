using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameGrid : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private TileBase _wallTile;
    [SerializeField] private TileBase _emptyTile;
    [SerializeField] private TileBase _playerTile;

    public int Size { get; private set; }

    public void Init(int size, byte[,] data)
    {
        Size = size;
        for (int x = -1; x < Size + 1; x++)
        {
            for (int y = -1; y < Size + 1; y++)
            {
                var position = new Vector3Int(x, y, 0);
                position.x -= Size / 2;
                position.y -= Size / 2;

                if (IsOutside(position))
                {
                    SetCellType(position, 1);
                }
                else
                {
                    SetCellType(position, data[x, y]);
                }
            }
        }
    }

    private bool IsOutside(Vector3Int position)
    {
        int x = position.x + Size / 2;
        int y = position.y + Size / 2;
        return (x < 0 || x >= Size || y < 0 || y >= Size);
    }

    public void SetCellType(Vector3Int position, int type)
    {
        if (type == 0)
            _tilemap.SetTile(position, _emptyTile);
        else if (type == 1)
            _tilemap.SetTile(position, _wallTile);
        else if (type == 2)
            _tilemap.SetTile(position, _playerTile);
    }
}
