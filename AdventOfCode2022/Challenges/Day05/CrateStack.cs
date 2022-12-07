#region License Information

// **********************************************************************************************************************************
// CrateStack.cs
// Last Modified: 2022/12/06 11:57 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;

namespace AdventOfCode2022.Challenges.Day05
{
    public interface IStackMultipleCrates : ICrateStack
    {
        void AddCratesToStack(Stack<ICrate> crates);
        Stack<ICrate> PickCratesFromTopOfStack(int crateCount);
    }

    public interface ICrateStack
    {
        int StackNumber { get; }
        int StackSize();
        ICrate PeekTopOfStack();
        ICrate PickTopOfStack();
        void AddCrateToStack(ICrate crate);
    }

    public class CrateStack : IStackMultipleCrates
    {
        private Stack<ICrate> _stack = new Stack<ICrate>();

        public CrateStack(int stackNumber)
        {
            StackNumber = stackNumber;
        }

        #region Implementation of ICrateStack

        public int StackNumber { get; }
        public int StackSize()
        {
            return _stack.Count;
        }

        public ICrate PeekTopOfStack()
        {
            return _stack.Peek();
        }

        public ICrate PickTopOfStack()
        {
            return _stack.Pop();
        }

        public void AddCrateToStack(ICrate crate)
        {
            _stack.Push(crate);
        }

        #endregion

        #region Implementation of IStackMultipleCrates

        public void AddCratesToStack(Stack<ICrate> crates)
        {
            while(crates.Count > 0)
            {
                _stack.Push(crates.Pop());
            }
        }

        public Stack<ICrate> PickCratesFromTopOfStack(int crateCount)
        {
            var stack = new Stack<ICrate>();
            var crateCountToTake = _stack.Count < crateCount ? stack.Count : crateCount;

            for (var i = 0; i < crateCountToTake; i++)
            {
                stack.Push(_stack.Pop());
            }

            return stack;
        }

        #endregion
    }
}