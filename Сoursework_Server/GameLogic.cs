using System;
using System.Collections.Generic;
using System.Text;
using CourseWork_Server.DataStructures.Danil;


namespace Сoursework_Server
{
    public class GameLogic
    {
        private RedBlackTree<Player> _players;

        public GameLogic()
        {
            _players = new RedBlackTree<Player>();
        }

        public void OnClientConnection(Client client)
        {
            
        }
    }
}
