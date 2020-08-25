using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenges.AMZ
{
    public class MinStack
    {
        private int _min;
        private Stack<int> _stack = new Stack<int>();

        public MinStack()
        {
            _min = int.MaxValue;
        }

        public void Push(int x)
        {
            // only push the old minimum value when the current 
            // minimum value changes after pushing the new value x
            if (x <= _min)
            {
                _stack.Push(_min);
                _min = x;
            }
            _stack.Push(x);
        }

        public void Pop()
        {
            // if pop operation could result in the changing of the current minimum value, 
            // pop twice and change the current minimum value to the last minimum value.
            if (_stack.Pop() == _min)
                _min = _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min;
        }
    }
}
