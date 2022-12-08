#region License Information

// **********************************************************************************************************************************
// FileOutputParser.cs
// Last Modified: 2022/12/08 10:36 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.Day07
{
    public class FileOutputParser : OutputParser
    {
        private readonly IDirectoryManager _directoryManager;

        public FileOutputParser(IDirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        #region Overrides of OutputParser

        protected override bool CanProcessOutputInternal(string output)
        {
            var values = output.Split(' ');
            if(values.Length > 1 && int.TryParse(values[0], out var fileSize))
                return true;
            return false;
        }

        protected override void ProcessOutputInternal(string output)
        {
            var values = output.Split(' ');
            var fileSize = int.Parse(values[0]);
            var fileName = values[1];
            var currentDir = _directoryManager.GetCurrentDirectory();
            currentDir.AddFile(new File(fileName, fileSize, currentDir));
        }

        #endregion
    }
}