#region License Information

// **********************************************************************************************************************************
// CrateStack.cs
// Last Modified: 2022/12/06 11:57 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;

namespace AdventOfCode2022.Challenges.DayFive
{
    public interface ICrateStack
    {
        int StackNumber { get; }
        int StackSize();
        ICrate PeekTopOfStack();
        ICrate PickTopOfStack();
        void AddCrateToStack(ICrate crate);
    }

    public class CrateStack : ICrateStack
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
    }
}