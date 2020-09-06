using OkeySimulation.Players;
using OkeySimulation.Stones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Game
{
    public class GameManager
    {
        private List<Stone> stones = new List<Stone>();
        private List<Player> players = new List<Player>();
        private Random rng = new Random();

        // Methods
        public List<Stone> boardManager(List<Stone> playerBoard, Player player)
        {
            int doubleCount = 0;
            List<Stone> list = new List<Stone>();
            List<Stone> colorGroup = new List<Stone>();
            List<Stone> list3 = new List<Stone>();
            List<Stone> list4 = new List<Stone>();
            List<Stone> list5 = new List<Stone>();
            List<List<Stone>> y = new List<List<Stone>>();
            List<List<Stone>> list7 = new List<List<Stone>>();
            List<List<Stone>> list8 = new List<List<Stone>>();
            List<List<Stone>> list9 = new List<List<Stone>>();
            List<Stone> list10 = new List<Stone>();
            List<Stone> list11 = new List<Stone>();
            List<Stone> list12 = new List<Stone>();
            List<Stone> list13 = new List<Stone>();
            List<Stone> result = new List<Stone>();

            Stone stone = playerBoard.Find(item => item.getIsJoker());
            if (stone != null)
            {
                list.Add(stone);
                player.setHasJoker();
                playerBoard.Remove(stone);
            }
            Stone stone2 = playerBoard.Find(item => item.getIsJoker());
            if (stone2 != null)
            {
                list.Add(stone2);
                player.setHasJoker();
                playerBoard.Remove(stone2);
            }
            int num4 = 0;
            while (true)
            {
                if (num4 == playerBoard.Count)
                {
                    break;
                }
                else if (playerBoard[num4].getColor() == "Yellow")
                {
                    colorGroup.Add(playerBoard[num4]);
                }
                else if (playerBoard[num4].getColor() == "Blue")
                {
                    list5.Add(playerBoard[num4]);
                }
                else if (playerBoard[num4].getColor() == "Black")
                {
                    list4.Add(playerBoard[num4]);
                }
                else if (playerBoard[num4].getColor() == "Red")
                {
                    list3.Add(playerBoard[num4]);
                }
                num4++;
            }

            if (colorGroup.Count > 0)
            {
                y = this.checkPairs(colorGroup);
                doubleCount = this.checkDoubles(colorGroup, doubleCount);
                this.finishBoard(y, result, 1);
            }
            if (list3.Count > 0)
            {
                list7 = this.checkPairs(list3);
                doubleCount = this.checkDoubles(list3, doubleCount);
                this.finishBoard(list7, result, 1);
            }
            if (list4.Count > 0)
            {
                list9 = this.checkPairs(list4);
                doubleCount = this.checkDoubles(list4, doubleCount);
                this.finishBoard(list9, result, 1);
            }
            if (list5.Count > 0)
            {
                list8 = this.checkPairs(list5);
                doubleCount = this.checkDoubles(list5, doubleCount);
                this.finishBoard(list8, result, 1);
            }
            if (colorGroup.Count > 0)
            {
                this.finishBoard(y, result, 2);
            }
            if (list3.Count > 0)
            {
                this.finishBoard(list7, result, 2);
            }
            if (list5.Count > 0)
            {
                this.finishBoard(list8, result, 2);
            }
            if (list4.Count > 0)
            {
                this.finishBoard(list9, result, 2);
            }
            int num3 = (player.getMyBoard().Count - (2 * doubleCount)) / 2;
            player.setDoubleScore(num3);
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }

        public int boardPointForWinner(List<Stone> playerStones, Player player)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num8 = 0;
            while (true)
            {
                if (num8 >= playerStones.Count)
                {
                    int num5 = 0;
                    int num9 = 0;
                    while (true)
                    {
                        if (num9 >= playerStones.Count)
                        {
                            num /= 2;
                            Console.WriteLine("Player has " + num3.ToString() + " in pair.");
                            Console.WriteLine("Player has " + num.ToString() + " half pair.");
                            Console.WriteLine("Player has " + num2.ToString() + " one stone.");
                            Console.WriteLine("If everything goes as player wants " + num5.ToString() + " moves advantage occurs!");
                            Console.WriteLine("If Player goes double " + player.getDoubleScore().ToString() + " moves needed!");
                            if (player.getHasJoker())
                            {
                                Console.WriteLine("Player has Joker!");
                                num2--;
                            }
                            int num6 = ((num2 - num) < 0) ? 1 : 2;
                            int num7 = player.getPriority() ? 1 : 0;
                            if (num7 == 1)
                            {
                                Console.WriteLine("Player starts game! Has One move advantage from others");
                            }
                            num4 = (num6 != 1) ? (num2 - (num5 + num7)) : (((num - num2) + num) - (num5 + num7));
                            player.setPairScore(num4);
                            return num4;
                        }
                        Stone stone2 = playerStones[num9];
                        if (stone2.getIsNothing())
                        {
                            int num10 = 0;
                            while (true)
                            {
                                if (num10 >= playerStones.Count)
                                {
                                    break;
                                }
                                Stone stone3 = playerStones[num10];
                                int num11 = stone2.getValue() - stone3.getValue();
                                if ((stone2.getValue() != stone3.getValue()) || (stone2.getColor() != stone3.getColor()))
                                {
                                    if (((num11 == 2) && (stone3.getIsNothing() || stone3.getIsRightOfPair())) && (stone2.getColor() == stone3.getColor()))
                                    {
                                        num5++;
                                        break;
                                    }
                                    if (((num11 == 2) && (stone3.getIsNothing() || stone3.getIsMemberOfHalfPair())) && (stone2.getColor() == stone3.getColor()))
                                    {
                                        num5++;
                                        break;
                                    }
                                }
                                num10++;
                            }
                        }
                        num9++;
                    }
                }
                Stone stone = playerStones[num8];
                if (stone.getIsMemberOfPair())
                {
                    num3++;
                }
                else if (stone.getIsMemberOfHalfPair() && stone.getRightNode().getIsMemberOfPair())
                {
                    num3++;
                }
                else if (stone.getIsRightOfPair() && stone.getLeftNode().getIsMemberOfPair())
                {
                    num3++;
                }
                else if (stone.getIsMemberOfHalfPair() && stone.getRightNode().getIsRightOfPair())
                {
                    num++;
                }
                else if (stone.getIsRightOfPair() && stone.getLeftNode().getIsMemberOfHalfPair())
                {
                    num++;
                }
                else if (stone.getIsNothing())
                {
                    num2++;
                }
                num8++;
            }
        }

        public int checkDoubles(List<Stone> colorGroup, int doubleCount)
        {
            List<Stone> list = colorGroup;
            int num = 0;
            while (num < list.Count)
            {
                Stone item = list[num];
                list.Remove(item);
                int num2 = 0;
                while (true)
                {
                    if (num2 >= list.Count)
                    {
                        num++;
                        break;
                    }
                    Stone stone2 = list[num2];
                    if (item.getValue() == stone2.getValue())
                    {
                        doubleCount++;
                    }
                    if (item.getIsJoker() || stone2.getIsJoker())
                    {
                        doubleCount += 2;
                    }
                    num2++;
                }
            }
            return doubleCount;
        }

        public List<List<Stone>> checkPairs(List<Stone> colorGroup)
        {
            bool flag = true;
            List<Stone> item = new List<Stone>();
            List<Stone> list2 = new List<Stone>();
            List<List<Stone>> list3 = new List<List<Stone>>();
            int num4 = 0;
            while (true)
            {
                if (num4 >= colorGroup.Count)
                {
                    int num6 = 0;
                    while (true)
                    {
                        if (num6 >= colorGroup.Count)
                        {
                            list3.Add(item);
                            list3.Add(list2);
                            return list3;
                        }
                        Stone stone2 = colorGroup[num6];
                        if (stone2.getIsMemberOfHalfPair())
                        {
                            item.Add(stone2);
                            while (true)
                            {
                                if (flag)
                                {
                                    Stone stone3 = stone2.getRightNode();
                                    item.Add(stone3);
                                    if (stone3.getHasRight())
                                    {
                                        flag = true;
                                        stone2 = stone3;
                                        continue;
                                    }
                                    flag = false;
                                }
                                flag = true;
                                break;
                            }
                        }
                        if (!stone2.getHasRight() && !stone2.getHasLeft())
                        {
                            list2.Add(stone2);
                        }
                        num6++;
                    }
                }
                Stone left = colorGroup[num4];
                int num = left.getValue();
                int num5 = 0;
                while (true)
                {
                    if (num5 >= colorGroup.Count)
                    {
                        num4++;
                        break;
                    }
                    int num2 = colorGroup[num5].getValue();
                    int num3 = num + 1;
                    if (((num2 == num3) && !left.getHasRight()) && !colorGroup[num5].getHasLeft())
                    {
                        left.rightNode(colorGroup[num5]);
                        colorGroup[num5].leftNode(left);
                    }
                    num5++;
                }
            }
        }

        public Stone createJoker(List<Stone> list)
        {
            Stone stone = null;
            int count = list.Count;
            while (true)
            {
                int num3 = this.rng.Next(count + 1);
                stone = list[num3];
                int num = list[num3].getValue();
                string str = list[num3].getColor();
                if (num != 0x34)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------");
                    Console.Write("Indicator showed up ");
                    this.switchColor(stone);
                    Console.Write(num.ToString() + "!");
                    this.normalizeColor();
                    Console.WriteLine();
                    Console.WriteLine("---------------------");
                    Console.WriteLine();
                    int jokerValue = ((num != stone.getBound()) || (str != "Yellow")) ? (((num != stone.getBound()) || (str != "Blue")) ? (((num != stone.getBound()) || (str != "Black")) ? (((num != stone.getBound()) || (str != "Red")) ? (num + 1) : 0x27) : 0x1a) : 13) : 0;
                    Stone stone2 = list.Find(item => (item.getValue() == jokerValue) && !item.getIsJoker());
                    stone2.setJoker();
                    list.Find(item => (item.getValue() == jokerValue) && !item.getIsJoker()).setJoker();
                    Stone stone4 = list.Find(item => item.getValue() == 0x34);
                    stone4.setValue(stone2.getValue());
                    stone4.setColor(stone2.getColor());
                    stone4.setFake();
                    Stone stone5 = list.Find(item => item.getValue() == 0x34);
                    stone5.setValue(stone2.getValue());
                    stone5.setColor(stone2.getColor());
                    stone5.setFake();
                    return stone2;
                }
            }
        }

        public List<Player> createPlayers()
        {
            for (int i = 1; i < 5; i++)
            {
                Player item = new Player();
                item.playerName = "Player #" + i.ToString();
                this.players.Add(item);
            }
            return this.players;
        }

        public List<Stone> createStones()
        {
            for (int i = 0; i < 0x35; i++)
            {
                if (i <= 12)
                {
                    this.stones.Add(new Yellow(i));
                    this.stones.Add(new Yellow(i));
                }
                if ((12 < i) && (i <= 0x19))
                {
                    this.stones.Add(new Blue(i));
                    this.stones.Add(new Blue(i));
                }
                if ((0x19 < i) && (i <= 0x26))
                {
                    this.stones.Add(new Black(i));
                    this.stones.Add(new Black(i));
                }
                if ((0x26 < i) && (i <= 0x33))
                {
                    this.stones.Add(new Red(i));
                    this.stones.Add(new Red(i));
                }
                if (i == 0x34)
                {
                    this.stones.Add(new FakeJoker(i));
                    this.stones.Add(new FakeJoker(i));
                }
            }
            return this.stones;
        }

        public void finishBoard(List<List<Stone>> y, List<Stone> result, int mode)
        {
            if (mode == 1)
            {
                try
                {
                    List<Stone> list = y[0];
                    int num = 0;
                    while (true)
                    {
                        if (num >= list.Count)
                        {
                            break;
                        }
                        result.Add(list[num]);
                        num++;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (mode == 2)
            {
                List<Stone> list2 = y[1];
                int num2 = 0;
                while (true)
                {
                    if (num2 >= list2.Count)
                    {
                        break;
                    }
                    result.Add(list2[num2]);
                    num2++;
                }
            }
        }

        public int IamTheWinner(List<Player> players)
        {
            int num = 0x772d_dffd;
            int index = 0;
            for (int i = 0; i < players.Count; i++)
            {
                Player item = players[i];
                string[] textArray1 = new string[] { "Player #", (i + 1).ToString(), " needs at least ", item.getMinumumScore().ToString(), " moves!" };
                Console.WriteLine(string.Concat(textArray1));
                if (item.getMinumumScore() < num)
                {
                    index = players.IndexOf(item);
                    num = item.getMinumumScore();
                }
            }
            return index;
        }

        public void normalizeColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void scatterStones(List<Stone> stones, List<Player> players)
        {
            int num = this.rng.Next(0, 4);
            int num2 = 14;
            players[num].setPriority();
            List<Stone> myStones = new List<Stone>();
            int num3 = 0;
            while (num3 < 4)
            {
                if (num3 == num)
                {
                    num2 = 15;
                }
                Player player2 = players[num3];
                int num4 = 0;
                while (true)
                {
                    if (num4 >= num2)
                    {
                        player2.setMyBoard(myStones);
                        myStones.Clear();
                        num2 = 14;
                        num3++;
                        break;
                    }
                    int index = this.rng.Next(stones.Count);
                    Stone item = stones[index];
                    myStones.Add(item);
                    stones.RemoveAt(index);
                    num4++;
                }
            }
        }

        public void Shuffle(List<Stone> list)
        {
            int count = list.Count;
            while (count > 1)
            {
                count--;
                int num2 = this.rng.Next(count + 1);
                Stone stone = list[num2];
                list[num2] = list[count];
                list[count] = stone;
            }
        }

        public void switchColor(Stone stone)
        {
            Console.ForegroundColor = !stone.getFake() ? ((stone.getColor() != "Blue") ? ((stone.getColor() != "Red") ? ((stone.getColor() != "Yellow") ? ((stone.getColor() != "Black") ? ConsoleColor.Green : ConsoleColor.Gray) : ConsoleColor.Yellow) : ConsoleColor.Red) : ConsoleColor.Blue) : ConsoleColor.Green;
        }

}
}
