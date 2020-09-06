using OkeySimulation.Stones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Players
{
    public class Player
    {
        public string playerName;
        private bool hasPriority;
        private bool isWinner;
        private bool hasJoker;
        private int pairScore;
        private int doubleScore;
        private List<Stone> myBoard = new List<Stone>();

       
        public int getDoubleScore() =>
            this.doubleScore;

        public bool getHasJoker() =>
            this.hasJoker;

        public int getMinumumScore() =>
            ((this.pairScore >= this.doubleScore) ? this.doubleScore : this.pairScore);

        public List<Stone> getMyBoard() =>
            this.myBoard;

        public bool getPriority() =>
            this.hasPriority;

        public bool getWinner() =>
            this.isWinner;

        public void setDoubleScore(int _score)
        {
            this.doubleScore = _score;
        }

        public void setHasJoker()
        {
            this.hasJoker = true;
        }

        public void setMyBoard(List<Stone> myStones)
        {
            for (int i = 0; i < myStones.Count; i++)
            {
                this.myBoard.Add(myStones[i]);
            }
        }

        public void setPairScore(int _score)
        {
            this.pairScore = _score;
        }

        public void setPriority()
        {
            this.hasPriority = true;
        }

        public void setWinner()
        {
            this.isWinner = true;
        }

    }
}
