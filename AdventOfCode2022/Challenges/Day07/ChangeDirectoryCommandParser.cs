#region License Information

// **********************************************************************************************************************************
// ChangeDirectoryCommandParser.cs
// Last Modified: 2022/12/08 10:00 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;

namespace AdventOfCode2022.Challenges.Day07
{
    public class ChangeDirectoryCommandParser : CommandParser
    {
        #region Private Members

        private readonly IDirectoryManager _directoryManager;

        #endregion

        #region Constructors

        public ChangeDirectoryCommandParser(IDirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        #endregion

        #region Protected Properties

        protected override string CommandTrigger => StringConstants.CommandChangeDirectory;

        #endregion

        #region Protected Overrides

        protected override void ProcessCommandInternal(string command, Queue<string> remainingCommands)
        {
            var argument = GetCommandArgument(command);
            if(argument == StringConstants.ParentDirectoryKey)
            {
                var currentDirectory = _directoryManager.GetCurrentDirectory();
                if(currentDirectory.ParentDirectory != null)
                {
                    _directoryManager.SetCurrentDirectory(currentDirectory.ParentDirectory);
                }
            }else
            {
                var directory = _directoryManager.GetDirectory(argument);
                if (directory != null)
                {
                    _directoryManager.SetCurrentDirectory(directory);
                }
                else
                {
                    throw new ArgumentException($"The folder {argument} was not in the current folder location.");
                }
            }
        }

        #endregion
    }
}