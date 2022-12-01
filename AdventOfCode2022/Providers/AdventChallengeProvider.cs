#region License Information

// **********************************************************************************************************************************
// AdventChallengeProvider.cs
// Last Modified: 2022/12/01 11:18 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Collections.Generic;
using AdventOfCode2022.Challenges;

namespace AdventOfCode2022.Providers
{
    public interface IAdventChallengeProvider
    {
        IEnumerable<IAdventChallenge> AdventDates { get; }
    }

    public class AdventChallengeProvider : IAdventChallengeProvider
    {
        private readonly IEnumerable<IAdventChallenge> _challenges;

        public AdventChallengeProvider(IEnumerable<IAdventChallenge> _challenges)
        {
            this._challenges = _challenges;
        }

        #region Implementation of IAdventDateProvider

        public IEnumerable<IAdventChallenge> AdventDates => _challenges;

        #endregion
    }
}