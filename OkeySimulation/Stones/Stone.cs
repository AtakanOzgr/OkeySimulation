using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeySimulation.Stones
{
    public class Stone
    {
        private string color;
        private int value;
        private bool isJoker = false;
        private bool isFake = false;
        private int bound;
        private Stone rightStone;
        private Stone leftStone;
        private bool hasRight = false;
        private bool hasLeft = false;
        private bool isMemberOfPair = false;
        private bool isMemberOfHalfPair = false;
        private bool isTheRightOfPair = false;
        private bool isNothing = false;

        public Stone(int value)
        {
            this.value = value;
        }

        public int getBound() =>
            this.bound;

        public string getColor() =>
            this.color;

        public bool getFake() =>
            this.isFake;

        public bool getHasLeft() =>
            this.hasLeft;

        public bool getHasRight() =>
            this.hasRight;

        public bool getIsJoker() =>
            this.isJoker;

        public bool getIsMemberOfHalfPair()
        {
            bool isMemberOfHalfPair;
            if (!(!this.getHasLeft() && this.getHasRight()))
            {
                isMemberOfHalfPair = this.isMemberOfHalfPair;
            }
            else
            {
                this.isMemberOfHalfPair = true;
                isMemberOfHalfPair = this.isMemberOfHalfPair;
            }
            return isMemberOfHalfPair;
        }

        public bool getIsMemberOfPair()
        {
            bool isMemberOfPair;
            if (!(this.getHasLeft() && this.getHasRight()))
            {
                isMemberOfPair = this.isMemberOfPair;
            }
            else
            {
                this.isMemberOfPair = true;
                isMemberOfPair = this.isMemberOfPair;
            }
            return isMemberOfPair;
        }

        public bool getIsNothing()
        {
            bool isNothing;
            if (this.getHasLeft() || this.getHasRight())
            {
                isNothing = this.isNothing;
            }
            else
            {
                this.isNothing = true;
                isNothing = this.isNothing;
            }
            return isNothing;
        }

        public bool getIsRightOfPair()
        {
            bool isTheRightOfPair;
            if (!(this.getHasLeft() && !this.getHasRight()))
            {
                isTheRightOfPair = this.isTheRightOfPair;
            }
            else
            {
                this.isTheRightOfPair = true;
                isTheRightOfPair = this.isTheRightOfPair;
            }
            return isTheRightOfPair;
        }

        public Stone getLeftNode() =>
            this.leftStone;

        public Stone getRightNode() =>
            this.rightStone;

        public int getValue() =>
            this.value;

        public void leftNode(Stone left)
        {
            this.leftStone = left;
            this.hasLeft = true;
        }

        public void rightNode(Stone right)
        {
            this.rightStone = right;
            this.hasRight = true;
        }

        public void setBound(int value)
        {
            this.bound = value;
        }

        public void setColor(string _color)
        {
            this.color = _color;
        }

        public void setFake()
        {
            this.isFake = true;
        }

        public void setJoker()
        {
            this.isJoker = true;
        }

        public void setValue(int _value)
        {
            this.value = _value;
        }
    }
}
