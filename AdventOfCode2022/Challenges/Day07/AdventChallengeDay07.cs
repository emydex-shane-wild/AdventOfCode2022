#region License Information

// **********************************************************************************************************************************
// AdventChallengeDay07.cs
// Last Modified: 2022/12/08 9:48 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day07
{
    public class AdventChallengeDay07 : AdventChallengeBase
    {
        #region Private Members

        private readonly IDirectoryManager _directoryManager;
        private readonly IOutputProcessor _outputProcessor;

        #endregion

        #region Constructors

        public AdventChallengeDay07(IOutputProcessor outputProcessor, IDirectoryManager directoryManager)
        {
            _outputProcessor = outputProcessor;
            _directoryManager = directoryManager;
        }

        #endregion

        #region Protected Overrides

        protected override int GetDayNumber() => 7;
        protected override string GetChallengeOneText() => "Find all of the directories with a total size of at most 100000. What is the sum of the total sizes of those directories?";

        protected override void ExecuteChallengeOneInternal()
        {
            var lines = new Queue<string>();
            FileExtensions.ProcessStream("day7_input_challenge1", r =>
                                                                  {
                                                                      while (r.Peek() >= 0)
                                                                      {
                                                                          var line = r.ReadLine();
                                                                          lines.Enqueue(line);
                                                                      }
                                                                  });
            _outputProcessor.ProcessLines(lines);
            var dirsUpTo100k = QueryDirectories(d => d.Size <= 100000);

            var totalSize = dirsUpTo100k.Select(d => d.Size).Sum();

            Console.WriteLine($"The total size of all directories less than or equal to 100000 is {totalSize}");
        }

        private IEnumerable<IDirectory> QueryDirectories(Func<IDirectory, bool> dirPredicate)
        {
            var dirResults = new List<IDirectory>();
            var rootDir = _directoryManager.GetDirectory(StringConstants.RootDirectoryPath);
            if(rootDir == null) throw new Exception("Root directory wasn't found.");
            
            FilterDirectory(rootDir, dirResults, dirPredicate);
            return dirResults.ToArray();
        }

        private void FilterDirectory(IDirectory currentDir, List<IDirectory> dirResults, Func<IDirectory, bool> dirPredicate)
        {
            if(dirPredicate(currentDir)) dirResults.Add(currentDir);
            if(currentDir.HasDirectories())
            {
                foreach (var dir in currentDir.GetDirectories())
                {
                    FilterDirectory(dir, dirResults, dirPredicate);
                }
            }
        }

        #endregion
    }
}