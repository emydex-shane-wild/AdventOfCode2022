#region License Information

// **********************************************************************************************************************************
// FileExtensions.cs
// Last Modified: 2022/12/08 6:50 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.IO;

namespace AdventOfCode2022.Architecture.Extensions
{
    public static class FileExtensions
    {
        #region Public Static Methods

        public static void ProcessStream(string resourceName, Action<StreamReader> fileProcessAction)
        {
            using (var memoryStream = new MemoryStream(FileAccessHelper.GetResourceData(resourceName)))
            {
                using (var reader = new StreamReader(memoryStream))
                {
                    fileProcessAction(reader);
                }
            }
        }

        #endregion
    }
}