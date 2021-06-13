using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server
{
    public interface IAttackService
    {
        void Attack(Player source, Player target);
    }
}
