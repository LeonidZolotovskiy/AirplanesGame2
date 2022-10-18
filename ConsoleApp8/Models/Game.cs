using ConsoleApp8.Enums;
using System;

namespace ConsoleApp8.Models
{
    public class Game
    {
        private Random _random = new Random();
        public void Play()
        {
            Console.WriteLine("Выбор режима игры\n" +
                              "1. 1 vs 1\n" +
                              "2. Team vs Team");

            GameMode gameMode = (GameMode)int.Parse(Console.ReadLine());
            switch (gameMode)
            {
                case GameMode.OneVsOne:
                    Init1vs1();
                    break;
                case GameMode.TeamVsTeam:
                    InitTeamVsTeam();
                    break;
            }
        }

        public void Fight(Airplaine airplane1, Airplaine airplane2)
        {
            Console.WriteLine(airplane1.Attack(airplane2));

            if (!airplane2.IsAlive)
            {
                Winner(airplane1.Name);
                return;
            }
            else
            {
                Console.WriteLine(airplane2.Attack(airplane1));
                if (!airplane1.IsAlive)
                {
                    Winner(airplane2.Name);
                    return;
                }
            }
        }

        private void Winner(string name)
        {
            Console.WriteLine("Победитель " + name);
        }

        public void Fight1vs1(Airplaine airplane1, Airplaine airplane2)
        {
            bool isFirstAirPlaneAtack = GlobalRandom.GenerateRandomNumber(0, 100) < 50;

            while (airplane1.IsAlive && airplane2.IsAlive)
            {
                if (isFirstAirPlaneAtack)
                {
                    Fight(airplane1, airplane2);
                }
                else
                {
                    Fight(airplane2, airplane1);
                }
            }
        }
        public void FightTeamVsTeam(Team team1, Team team2)
        {
            byte whichTurn = 1;

            while (team1.IsAlive() && team2.IsAlive())
            {
                if (whichTurn == 1)
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("Ход команды " + team1.Name);
                    Console.WriteLine("------------");
                    Console.WriteLine(team1.Attack(team2));
                    whichTurn = 2;
                }
                else
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("Ход команды " + team2.Name);
                    Console.WriteLine("------------");
                    Console.WriteLine(team2.Attack(team1));
                    whichTurn = 1;
                }
            }

            Console.WriteLine("------------");

            if (team1.IsAlive())
            {
                Console.WriteLine("Победитель - " + team1.Name + " звено");
            }
            else
            {
                Console.WriteLine("Победитель - " + team2.Name + " звено");
            }
        }

        public void Init1vs1()
        {
            Console.WriteLine("Начало боя 1 на 1 ");

            Console.WriteLine("Введите характеристики первого самолёта ");
            Airplaine airplane1 = CreateAirplane();

            Console.WriteLine("Введите характеристики второго самолёта ");
            Airplaine airplane2 = CreateAirplane();

            Fight1vs1(airplane1, airplane2);
        }

        public void InitTeamVsTeam()
        {
            Console.WriteLine("Начало боя Команда на Команду ");

            Console.WriteLine("Введите название первой команды ");
            string team1Name = Console.ReadLine();
            Console.WriteLine("Введите название второй команды ");
            string team2Name = Console.ReadLine();
            Console.Write("Введите кол-во самолетов в первом звене: ");
            int team1Count = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во самолетов во втором звене: ");
            int team2Count = int.Parse(Console.ReadLine());

            Airplaine[] airplainsFor1Team = new Airplaine[team1Count];
            Airplaine[] airplainsFor2Team = new Airplaine[team2Count];

            for (int i = 0; i < airplainsFor1Team.Length; i++)
            {
                Console.WriteLine($"Введите характеристики {i + 1}-го самолёта команды \"{team1Name}\"");
                airplainsFor1Team[i] = CreateAirplane();
            }

            for (int i = 0; i < airplainsFor2Team.Length; i++)
            {
                Console.WriteLine($"Введите характеристики {i + 1}-го самолёта команды \"{team2Name}\"");
                airplainsFor2Team[i] = CreateAirplane();
            }

            Team team1 = new Team(team1Name, airplainsFor1Team);
            Team team2 = new Team(team2Name, airplainsFor2Team);

            FightTeamVsTeam(team1, team2);
        }

        public Airplaine CreateAirplane()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите кол-во здоровья: ");
            int health = int.Parse(Console.ReadLine());
            Console.Write("Введите минимальный урон: ");
            int minDamage = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальный урон: ");
            int maxDamage = int.Parse(Console.ReadLine());
            Console.Write("Введите шанс уклонения: ");
            int evadeChance = int.Parse(Console.ReadLine());

            return new Airplaine(name, health, minDamage, maxDamage, evadeChance);
        }
    }
}
