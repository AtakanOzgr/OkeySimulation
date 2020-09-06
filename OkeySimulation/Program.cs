using OkeySimulation.Game;
using OkeySimulation.Players;
using OkeySimulation.Stones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Stone> stones = new List<Stone>();
            List<Player> players = new List<Player>();
            GameManager manager = new GameManager();

            manager.normalizeColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Stones are being created!");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            stones = manager.createStones();

            int counter = 0;
            for (int i = 0; i < stones.Count; i++)
            {
               
                Stone temp = stones[i];
                counter++;
                manager.switchColor(temp);
                Console.Write(temp.getValue() +" ");
                if (counter == 26)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }

            Console.WriteLine();
            manager.normalizeColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Stones are being shuffled!");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            manager.Shuffle(stones);

            int counter2 = 0;
            for (int i = 0; i < stones.Count; i++)
            {

                Stone temp = stones[i];
                counter2++;
                manager.switchColor(temp);
                Console.Write(temp.getValue() + " ");
                if (counter2 == 26)
                {
                    Console.WriteLine();
                    counter2 = 0;
                }
            }

            Console.WriteLine();
            manager.normalizeColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Players are being created!");
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            players=manager.createPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                Player temp = players[i];
                Console.WriteLine("------------");
                Console.WriteLine(temp.playerName);
                Console.WriteLine("------------");

            }


            Console.WriteLine();
            manager.normalizeColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Stones are being scattered!");
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            manager.scatterStones(stones,players);

            for (int i = 0; i < players.Count; i++)
            {
                Player temp = players[i];
                Console.WriteLine("------------");
                Console.Write(temp.playerName +" ");
                if (temp.getPriority())
                {
                    Console.WriteLine(" starts the game!");
                }
                else
                {
                    Console.WriteLine();
                }
                Console.WriteLine("------------");
                List<Stone> tempBoard = temp.getMyBoard();
                for (int j = 0; j < tempBoard.Count; j++)
                {
                    Stone tempStone = tempBoard[j];
                    manager.switchColor(tempStone);
                    Console.Write(tempStone.getValue() + " ");
                }
                Console.WriteLine();
                manager.normalizeColor();
                
            }

            Console.WriteLine();
            manager.normalizeColor();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Stones are being paired!");
            Console.WriteLine("---------------------------");
            Console.WriteLine();

           

            for (int i = 0; i < players.Count; i++)
            {
                Player temp = players[i];
                Console.WriteLine("------------");
                Console.Write(temp.playerName + " ");
                Console.WriteLine();
                Console.WriteLine("------------");
                List<Stone> tempBoard = temp.getMyBoard();
                List<Stone> tempList =  manager.boardManager(tempBoard, temp);
                for (int j = 0; j < tempList.Count; j++)
                {
                    Stone tempStone = tempBoard[j];
                    manager.switchColor(tempStone);
                    Console.Write(tempStone.getValue() + " ");
                }
                Console.WriteLine();
                manager.normalizeColor();

            }




            Console.ReadLine();


        }
    }
}
