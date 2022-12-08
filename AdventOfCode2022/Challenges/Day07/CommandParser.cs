#region License Information

// **********************************************************************************************************************************
// CommandParser.cs
// Last Modified: 2022/12/08 10:00 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace AdventOfCode2022.Challenges.Day07
{
    public interface ICommandParser
    {
        #region Public Methods

        bool CanProcessCommand(string command);
        void ProcessCommand(string command, Queue<string> remainingCommands);

        #endregion
    }

    public abstract class CommandParser : ICommandParser
    {
        #region Protected Properties

        protected abstract string CommandTrigger { get; }

        #endregion

        #region Protected Methods

        protected abstract void ProcessCommandInternal(string command, Queue<string> remainingCommands);

        protected string GetCommandArgument(string command)
        {
            return command.Replace($"{Constants.CommandPrefix} {CommandTrigger} ", "");
        }

        #endregion

        #region Public Methods

        public bool CanProcessCommand(string command)
        {
            return command.StartsWith($"{Constants.CommandPrefix} {CommandTrigger}");
        }

        public void ProcessCommand(string command, Queue<string> remainingCommands)
        {
            ProcessCommandInternal(command, remainingCommands);
        }

        #endregion
    }
}