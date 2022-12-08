#region License Information

// **********************************************************************************************************************************
// OutputProcessor.cs
// Last Modified: 2022/12/08 10:00 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Challenges.Day07
{
    public interface IOutputProcessor
    {
        #region Public Methods

        void ProcessLines(Queue<string> outputLines);

        #endregion
    }

    public class OutputProcessor : IOutputProcessor
    {
        private readonly IEnumerable<ICommandParser> _commandParsers;
        private readonly IEnumerable<IOutputParser> _outputParsers;

        public OutputProcessor(IEnumerable<ICommandParser> commandParsers, IEnumerable<IOutputParser> outputParsers)
        {
            _commandParsers = commandParsers;
            _outputParsers = outputParsers;
        }

        #region Public Methods

        public void ProcessLines(Queue<string> outputLines)
        {
            while (outputLines.Count > 0)
            {
                var line = outputLines.Dequeue();
                var commandParser = _commandParsers.FirstOrDefault(p => p.CanProcessCommand(line));
                if (commandParser != null) commandParser.ProcessCommand(line, outputLines);
                else
                {
                    var outputParser = _outputParsers.FirstOrDefault(p => p.CanProcessOutput(line));
                    if (outputParser != null) outputParser.ProcessOutput(line);
                    else
                    {
                        Console.WriteLine($"Unable to process line {line}");
                    }
                }
            }
        }

        #endregion
    }
}