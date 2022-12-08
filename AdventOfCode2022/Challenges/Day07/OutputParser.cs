#region License Information

// **********************************************************************************************************************************
// OutputParser.cs
// Last Modified: 2022/12/08 10:36 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.Day07
{
    public interface IOutputParser
    {
        bool CanProcessOutput(string output);
        void ProcessOutput(string output);
    }

    public abstract class OutputParser : IOutputParser
    {
        #region Implementation of IOutputParser

        protected abstract bool CanProcessOutputInternal(string output);
        protected abstract void ProcessOutputInternal(string output);

        public bool CanProcessOutput(string output)
        {
            return CanProcessOutputInternal(output);
        }
        
        public void ProcessOutput(string output)
        {
            ProcessOutputInternal(output);
        }

        #endregion
    }
}