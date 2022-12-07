#region License Information

// **********************************************************************************************************************************
// AdventChallengeDaySeven.cs
// Last Modified: 2022/12/08 6:46 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day07
{
    public class AdventChallengeDay07 : AdventChallengeBase
    {
        private readonly IOutputProcessor _outputProcessor;
        private readonly IDirectoryManager _directoryManager;

        public AdventChallengeDay07(IOutputProcessor outputProcessor, IDirectoryManager directoryManager)
        {
            _outputProcessor = outputProcessor;
            _directoryManager = directoryManager;
        }
        
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 7;
        protected override string GetChallengeOneText() => "Find all of the directories with a total size of at most 100000. What is the sum of the total sizes of those directories?";

        protected override void ExecuteChallengeOneInternal()
        {
            var commands = new Queue<string>();
            FileExtensions.ProcessStream("day7_input_challenge1", r =>
                                                                  {
                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          commands.Enqueue(line);
                                                                      }
                                                                  });


        }
        #endregion
    }


    public interface IOutputProcessor
    {
        void ProcessLines(Queue<string> outputLines);
    }

    public class OutputProcessor : IOutputProcessor
    {
        #region Implementation of IOutputProcessor

        public void ProcessLines(Queue<string> outputLines)
        {
            
        }

        #endregion
    }

    public interface ILineOutputProcessor
    {
        void ProcessLine(string line);   
    }

    public class IILineOutputProcessor : ILineOutputProcessor
    {
        public IILineOutputProcessor(IEnumerable<ICommandParser> commandParsers)
        {
            
        }

        #region Implementation of ILineOutputProcessor

        public void ProcessLine(string line)
        {
            
        }

        #endregion
    }

    public interface ICommandParser
    {
        bool CanProcessCommand(string command);
        void ProcessCommand(string command);
    }

    public static class StringConstants
    {
        public const string CommandPrefix = "$";
    }

    public abstract class CommandParser : ICommandParser
    {
        #region Implementation of ICommandParser

        public bool CanProcessCommand(string command)
        {
            return command.StartsWith($"{StringConstants.CommandPrefix} {CommandTrigger}")
        }

        protected abstract string CommandTrigger { get; }
        protected abstract void ProcessCommandInternal(string command);
        protected object GetCommandArgument(string command)
        {
            return command.Replace($"{StringConstants.CommandPrefix} {CommandTrigger} ", "");
        }

        public void ProcessCommand(string command)
        {
            ProcessCommandInternal(command);
        }

        #endregion
    }

    public class ChangeDirectoryCommandParser : CommandParser
    {
        private readonly IDirectoryManager _directoryManager;

        public ChangeDirectoryCommandParser(IDirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        protected override string CommandTrigger => "cd";
        protected override void ProcessCommandInternal(string command)
        {
            var argument = GetCommandArgument(command);
            var directory = _directoryManager.GetDirectory(argument);
            if (directory == null)
            {
                directory = _directoryManager.CreateDirectory(argument);
            }
            _directoryManager.SetCurrentDirectory(directory);
        }
    }

    public interface IDirectoryManager
    {
        IDirectory GetDirectory(string argument);
        IDirectory CreateDirectory(string argument);
        void SetCurrentDirectory(IDirectory directory);
    }

    public class DirectoryManager : IDirectoryManager
    {

    }

    public interface IDiskItem
    {
        string Name { get; }
        int Size { get; }
        string Path{ get; }
        IDirectory ParentDirectory { get; }
    }

    public interface IDirectory : IDiskItem
    {
        bool IsTopLevel();
        bool HasFiles();
        bool HasDirectories();

        void AddFile(IFile file);
        void AddDirectory(IDirectory directory);
    }

    public interface IFile : IDiskItem
    {
    }
}