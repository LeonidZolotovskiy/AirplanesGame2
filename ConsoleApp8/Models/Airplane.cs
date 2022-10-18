using System;

namespace ConsoleApp8.Models
{
    public class Airplaine
    {
        public string Name { get; set; }
        public int MinDamage { get; set; } 
        public int MaxDamage { get; set; }
        public int EvadeChance { get; set; }
        
        public bool IsAlive
        {
            get 
            { 
                if(Health > 0)
                {
                    return true;
                }
                return false;                     
            }            
        }

        private int health;
        public int Health
        {
            get { return health; }
            set 
            { 
                if(value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }                
            }
        }

        public Airplaine(string name,int health, int minDamage, int maxDamage, int evadeChance)
        {
            Name = name;
            Health = health;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            EvadeChance = evadeChance;
        }

        public string Attack(Airplaine enemy)
        {
            int randomDamage = GlobalRandom.GenerateRandomNumber(MinDamage, MaxDamage); 
            
            string message = string.Empty;

            bool isEvade = GlobalRandom.GenerateRandomNumber(0, 100) < enemy.EvadeChance;

            message = $"Самолёт {Name} атакует {enemy.Name}";

            if (isEvade)
            {
                return message += $", но {enemy.Name} уклонился";
            }
            else
            {
                enemy.TakeDamage(randomDamage);
                message += $" и наносит {randomDamage} урона";
                if (!enemy.IsAlive)
                {
                    message += $"\nСамолёт {enemy.Name} сбит";
                }
                return message;
            }
        }
        
        public void TakeDamage(int damage)
        {            
            Health -= damage;            
        }
    }
}
