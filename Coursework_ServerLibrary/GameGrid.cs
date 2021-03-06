using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server
{
    public class GameGrid
    {
        public readonly int Size;
        private GameCell[,] _data; 

        public GameGrid(int size)
        {
            Size = size;
            _data = new GameCell[Size, Size];
            for(int row = -Size/2; row < Size/2; row++)
            {
                for(int column = -Size/2; column < Size/2; column++)
                {
                    _data[column + Size/2, row + Size/2] = new GameCell(new Vector2(column, row));
                }
            }
        }
        public GameCell GetCellByIndex(Vector2 position) => _data[position.X, position.Y];
        public GameCell GetCellByPosition(Vector2 position) => _data[position.X + Size/2, position.Y + Size/2];
        public void SetCellType(Vector2 position, GameCellTypes type) => GetCellByPosition(position).Type = type;
        public bool IsInBounds(Vector2 position)
        {
            return position.X >= -Size / 2 && position.X < Size / 2
                && position.Y >= -Size / 2 && position.Y < Size / 2;
        }
        public bool IsWalkable(Vector2 position)
        {
            return IsInBounds(position) && GetCellByPosition(position).IsWalkable;
        }

        public bool Move(Player player, Vector2 position)
        {
            if (IsWalkable(position))
            {
                GetCellByPosition(player.Position).UnboundPlayer();
                GetCellByPosition(position).BoundPlayer(player);
                player.Position = position;
                return true;
            }
            return false;
        }

        public Vector2 GetEmptyCellPosition()
        {
            var rand = new Random();
            Vector2 position = new Vector2();
            int i = 0;
            int tries = 1000;
            for(; i < tries && IsWalkable(position) == false; i++)
            {
                position.X = rand.Next(-Size / 2, Size / 2);
                position.Y = rand.Next(-Size / 2, Size / 2);
            }
            if(i == tries)
            {
                throw new Exception("Превышено количество попыток для поиска пустой клетки.");
            }
            return position;
        }

        public void PlaceNewPlayer(Player target)
        {
            target.Position = GetEmptyCellPosition();
            GetCellByPosition(target.Position).BoundPlayer(target);
        }

        public bool TryPlacePlayer(Player target, Vector2 position)
        {
            if (IsWalkable(position))
            {
                target.Position = position;
                GetCellByPosition(target.Position).BoundPlayer(target);
                return true;
            }
            return false;
        }

        public void RemovePlayer(Player target)
        {
            GetCellByPosition(target.Position).UnboundPlayer();
        }
    }
}
