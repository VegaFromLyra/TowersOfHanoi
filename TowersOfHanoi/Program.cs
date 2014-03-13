using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveTowersOfHanoi(4);
        }

        static void InitialiseTower(Tower tower, int n)
        {
            for (int i = n; i >= 1; i--)
            {
                tower.Push(i);
            }
        }

        static void SolveTowersOfHanoi(int n)
        {
            Tower tower1 = new Tower(1);
            Tower tower2 = new Tower(2);
            Tower tower3 = new Tower(3);

            InitialiseTower(tower1, n);

            Solver(tower1, tower2, tower3, n);
        }


        static void Solver(Tower source, Tower middle, Tower destination, int numOfDisks)
        {
            if (numOfDisks == 1)
            {
                int diskNum = source.Pop();

                destination.Push(diskNum);

                Console.WriteLine("Moving disk {0} from Tower {1} to Tower {2}", diskNum, source.ID, destination.ID);
            }
            else
            {
                Solver(source, destination, middle, numOfDisks - 1);
                Solver(source, middle, destination, 1);
                Solver(middle, source, destination, numOfDisks - 1);
            }
        }
    }

    class Tower
    {
        private Stack<int> stack = new Stack<int>();

        public void Push(int diskNum)
        {
            stack.Push(diskNum);
        }

        public int Pop()
        {
            return stack.Pop();
        }

        public Tower(int id)
        {
            ID = id;
        }

        public int ID { private set; get; }
    }
}
