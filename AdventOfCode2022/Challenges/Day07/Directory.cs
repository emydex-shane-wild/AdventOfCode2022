#region License Information

// **********************************************************************************************************************************
// Directory.cs
// Last Modified: 2022/12/08 9:59 PM
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
    public interface IDirectory : IDiskItem
    {
        #region Public Methods

        void AddDirectory(IDirectory directory);
        IDirectory GetDirectory(string dirName);

        void AddFile(IFile file);
        bool HasDirectories();
        bool HasFiles();
        bool IsTopLevel();

        #endregion

        IDirectory[] GetDirectories();
    }

    public class Directory : IDirectory
    {
        #region Private Members

        private readonly IDictionary<string, IDirectory> _directories = new Dictionary<string, IDirectory>();
        private readonly IDictionary<string, IFile> _files = new Dictionary<string, IFile>();

        #endregion

        #region Constructors

        public Directory(string dirName, IDirectory parentDirectory)
        {
            if(dirName.Contains("/"))
            {
                throw new ArgumentException("Directory name must not contain '/'.");
            }

            Name = dirName;
            ParentDirectory = parentDirectory;
        }

        #endregion

        #region Public Methods

        public void AddDirectory(IDirectory directory)
        {
            if (_directories.ContainsKey(directory.Path))
            {
                _directories[directory.Path] = directory;
            }
            else
            {
                _directories.Add(directory.Path, directory);
            }
        }

        public IDirectory GetDirectory(string dirName)
        {
            return _directories.ContainsKey(dirName) ? _directories[dirName] : null;
        }

        public void AddFile(IFile file)
        {
            if (_files.ContainsKey(file.Path))
            {
                _files[file.Path] = file;
            }
            else
            {
                _files.Add(file.Path, file);
            }
        }

        public bool HasDirectories() => _directories.Count > 0;

        public bool HasFiles() => _files.Count > 0;

        public bool IsTopLevel() => Path == StringConstants.RootDirectoryPath;
        public IDirectory[] GetDirectories()
        {
            return _directories.IsNullOrEmpty() ? new IDirectory[]{} : _directories.Values.ToArray();
        }

        #endregion

        #region IDiskItem

        public string Name { get; }
        public int Size => CalculateSize();

        private int CalculateSize()
        {
            var totalFileSize = _files.Values.Sum(f => f.Size);
            var totalDirSize = _directories.Values.Sum(d => d.Size);
            return totalFileSize + totalDirSize;
        }

        public string Path => ParentDirectory == null ? string.Empty : $"{ParentDirectory.Path}/{Name}";
        public IDirectory ParentDirectory { get; }

        #endregion
    }
}