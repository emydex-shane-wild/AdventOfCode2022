#region License Information

// **********************************************************************************************************************************
// DirectoryManager.cs
// Last Modified: 2022/12/08 9:59 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;

namespace AdventOfCode2022.Challenges.Day07
{
    public interface IDirectoryManager
    {
        #region Public Methods

        IDirectory CreateDirectory(string dirName);
        IDirectory GetDirectory(string dirName);
        void SetCurrentDirectory(IDirectory directory);
        IDirectory GetCurrentDirectory();

        #endregion
    }

    public class DirectoryManager : IDirectoryManager
    {
        #region Private Members

        private readonly IDictionary<string, IDirectory> _directoryByPathLookup = new Dictionary<string, IDirectory>();
        private IDirectory _currentDirectory;

        #endregion

        #region Constructors

        public DirectoryManager()
        {
            _currentDirectory = new Directory(string.Empty, null);
            _directoryByPathLookup.Add(_currentDirectory.Path, _currentDirectory);
        }

        #endregion

        #region Public Methods

        public IDirectory CreateDirectory(string dirName)
        {
            var directory = new Directory(dirName, _currentDirectory);
            if(_directoryByPathLookup.ContainsKey(directory.Path))
            {
                throw new InvalidOperationException("Folder in current directory already exists.");
            }

            _currentDirectory.AddDirectory(directory);
            _directoryByPathLookup.Add(directory.Path, directory);
            return directory;
        }

        public IDirectory GetDirectory(string dirName)
        {
            IDirectory dir;
            if(dirName.Contains("/"))
            {
                dirName = dirName.Length == 1 ? string.Empty : dirName;
                dir = _directoryByPathLookup.ContainsKey(dirName) ? _directoryByPathLookup[dirName] : null;
            }
            else
            {
                dir = _currentDirectory.GetDirectory($"{_currentDirectory.Path}/{dirName}");
            }
            return dir;
        }

        public void SetCurrentDirectory(IDirectory directory)
        {
            if(directory == null)
            {
                return;
            }

            _currentDirectory = directory;
        }

        public IDirectory GetCurrentDirectory() => _currentDirectory;

        #endregion
    }
}