#region License Information

// **********************************************************************************************************************************
// ListDirectoryCommandParser.cs
// Last Modified: 2022/12/08 11:35 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Challenges.Day07
{
    public class ListDirectoryCommandParser : CommandParser
    {
        #region Private Members

        private readonly IEnumerable<IOutputParser> _outputParsers;

        #endregion

        #region Constructors

        public ListDirectoryCommandParser(IEnumerable<IOutputParser> outputParsers)
        {
            _outputParsers = outputParsers;
        }

        #endregion

        #region Protected Properties

        protected override string CommandTrigger => Constants.CommandListDirectory;

        #endregion

        #region Protected Overrides

        protected override void ProcessCommandInternal(string command, Queue<string> remainingCommands)
        {
            while (remainingCommands.Count > 0 && _outputParsers.Any(p => p.CanProcessOutput(remainingCommands.Peek())) == false)
            {
                var output = remainingCommands.Dequeue();
                var outputParser = _outputParsers.FirstOrDefault(p => p.CanProcessOutput(output));
                outputParser?.ProcessOutput(output);
            }
        }

        #endregion
    }
}