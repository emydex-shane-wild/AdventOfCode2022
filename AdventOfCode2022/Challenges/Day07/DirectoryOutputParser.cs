#region License Information

// **********************************************************************************************************************************
// DirectoryOutputParser.cs
// Last Modified: 2022/12/08 10:37 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

namespace AdventOfCode2022.Challenges.Day07
{
    public class DirectoryOutputParser : OutputParser
    {
        private readonly IDirectoryManager _directoryManager;

        public DirectoryOutputParser(IDirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        #region Overrides of OutputParser

        protected override bool CanProcessOutputInternal(string output) => output.StartsWith(Constants.DirectoryListIdentity);

        protected override void ProcessOutputInternal(string output)
        {
            var directoryName = output.Replace($"{Constants.DirectoryListIdentity} ", "");
            var dir = _directoryManager.GetDirectory(directoryName);
            if(dir == null) _directoryManager.CreateDirectory(directoryName);
        }

        #endregion
    }
}