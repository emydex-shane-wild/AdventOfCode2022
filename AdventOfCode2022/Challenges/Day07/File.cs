#region License Information

// **********************************************************************************************************************************
// File.cs
// Last Modified: 2022/12/08 9:59 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;

namespace AdventOfCode2022.Challenges.Day07
{
    public interface IDiskItem
    {
        #region Public Properties

        string Name { get; }
        int Size { get; }
        string Path { get; }
        IDirectory ParentDirectory { get; }

        #endregion
    }

    public interface IFile : IDiskItem
    {
        string FileExtension { get; }
    }

    public class File : IFile
    {
        #region Constructors

        public File(string fileName, int fileSize, IDirectory parentDirectory)
        {
            if(fileName.Contains("/")) throw new ArgumentException("File name must not contain '/'.");
            Name = fileName;
            Size = fileSize;
            ParentDirectory = parentDirectory;
        }

        #endregion

        #region IDiskItem

        public string Name { get; }
        public int Size { get; }
        public string Path => $"{ParentDirectory?.Path ?? string.Empty}/{Name}";
        public IDirectory ParentDirectory { get; }

        #endregion

        #region IFile

        public string FileExtension
        {
            get
            {
                var fileExtIndex = Name.LastIndexOf('.');
                return Name.Substring(fileExtIndex, Name.Length - (fileExtIndex + 1));
            }
        }

        #endregion
    }
}