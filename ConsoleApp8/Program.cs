using ConsoleApp8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
            
            Console.ReadLine();
        }
    }
}
