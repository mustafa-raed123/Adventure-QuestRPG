using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Classes
{
    public class BossMonster : Monster
    {

        public BossMonster(string Name , int Health, int AttackPower) : base(Name , Health , AttackPower)
        {
           
        }
    }
}
