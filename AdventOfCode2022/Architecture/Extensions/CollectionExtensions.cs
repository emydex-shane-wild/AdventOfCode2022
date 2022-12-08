#region License Information

// **********************************************************************************************************************************
// CollectionExtensions.cs
// Last Modified: 2022/12/08 11:13 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Architecture.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> col)
        {
            return col?.Any() != true;
        }

        public static bool IsNotNullOrEmpty<T>(this ICollection<T> col)
        {
            return col.IsNullOrEmpty() == false;
        }
    }
}