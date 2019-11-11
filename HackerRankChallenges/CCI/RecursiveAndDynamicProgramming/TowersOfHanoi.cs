using System;
using System.Collections.Generic;
using System.Text;

namespace CCIChallenges.RecursiveAndDynamicProgramming
{
    public class TowersOfHanoi
    {
        private Stack<int> _disks = new Stack<int>();
        public String name;

        public void MoveTopTo(TowersOfHanoi t)
        {
            int top = _disks.Pop();
            t._disks.Push(top);
        }

        public void MoveDisks(int quantity, TowersOfHanoi destination, TowersOfHanoi buffer)
        {
            if (quantity <= 0) return;

            MoveDisks(quantity - 1, buffer, destination);
            MoveTopTo(destination);
            buffer.MoveDisks(quantity - 1, destination, this);
        }

        public static void Main()
        {
            var source = new TowersOfHanoi();
            var destination = new TowersOfHanoi();
            var buffer = new TowersOfHanoi();

            source.name = "s";
            destination.name = "d";
            buffer.name = "b";

            /* Load up tower */
            int numberOfDisks = 3;
            for (int disk = numberOfDisks - 1; disk >= 0; disk--)
            {
                source._disks.Push(disk);
            }

            source.MoveDisks(numberOfDisks, destination, buffer);
        }
    }
}
