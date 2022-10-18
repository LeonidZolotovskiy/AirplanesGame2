using ConsoleApp8.Models;
using System.Linq;

namespace ConsoleApp8
{
    public class Team
    {
        public string Name { get; set; }
        public Airplaine[] Airplains { get; set; }

        public int AirplainsCount
        {
            get
            {
                if (Airplains == null)
                {
                    return 0;
                }
                else
                {
                    return Airplains.Length;
                }
            }
        }

        public Team(string name, Airplaine[] airplains)
        {
            Name = name;
            Airplains = airplains;
        }

        public string Attack(Team team)
        {
            bool isFocusedAttack = GlobalRandom.GenerateRandomNumber(0, 100) > 50;

            if (isFocusedAttack)
            {
                return FocusedAttack(team);
            }
            else
            {
                return RandomAttack(team);
            }
        }

        private string RandomAttack(Team team)
        {
            string message = string.Empty;

            for (int i = 0; i < Airplains.Length; i++)
            {
                if (Airplains[i].IsAlive)
                {
                    var aliveEnemies = team.Airplains.Where(a => a.IsAlive).ToArray();

                    if (aliveEnemies == null || aliveEnemies.Length == 0)
                    {
                        break;
                    }

                    int randomAliveEnemy = GlobalRandom.random.Next(0, aliveEnemies.Length);

                    if (i==0)
                    {
                        message += Airplains[i].Attack(aliveEnemies[randomAliveEnemy]);
                    }
                    else
                    {
                        message += "\n" + Airplains[i].Attack(aliveEnemies[randomAliveEnemy]);
                    }
                }
            }
            return message;
        }

        private string FocusedAttack(Team team)
        {
            Airplaine focusedTarget = team.Airplains.FirstOrDefault(a => a.IsAlive);
            string message = string.Empty;

            if (focusedTarget != null)
            {
                message += $"Началась фокусированная атака по {focusedTarget.Name}";
                for (int i = 0; i < Airplains.Length; i++)
                {
                    if (focusedTarget.IsAlive)
                    {
                        if (Airplains[i].IsAlive)
                        {
                            message += "\n" + Airplains[i].Attack(focusedTarget);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                message += "\nФокусированная атака закончена!";
            }
            return message;
        }

        public bool IsAlive()
        {
            return Airplains.Any(a => a.IsAlive);
        }
    }
}
