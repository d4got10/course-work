using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server
{
    public enum GameCellTypes
    {
        Empty,
        Wall,
        Player
    }

    public class GameCell
    {
        public readonly Vector2 Position;

        public GameCellTypes Type;

        public bool IsWalkable => Type == GameCellTypes.Empty;

        public Player BoundedPlayer;

        public GameCell(Vector2 position)
        {
            Position = position;
            Type = GameCellTypes.Empty;
        }

        public void BoundPlayer(Player player)
        {
            Type = GameCellTypes.Player;
            BoundedPlayer = player;
        }

        public void UnboundPlayer()
        {
            Type = GameCellTypes.Empty;
            BoundedPlayer = null;
        }
    }
}
