#region License Information

// **********************************************************************************************************************************
// AdventDateChallenge.cs
// Last Modified: 2022/12/01 11:19 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;

namespace AdventOfCode2022.Challenges
{
    public interface IAdventChallenge
    {
        int DayNumber { get; }
        string ChallengeOne { get; }
        string ChallengeTwo { get; }
        void ExecuteChallengeOne();
        void ExecuteChallengeTwo();
    }

    public abstract class AdventChallengeBase : IAdventChallenge{
        #region Implementation of IAdventDateChallenge

        public int DayNumber => GetDayNumber();
        public string ChallengeOne => GetChallengeOneText();
        public string ChallengeTwo => GetChallengeTwoText();
        
        public void ExecuteChallengeOne() => ExecuteChallengeOneInternal();
        public void ExecuteChallengeTwo() => ExecuteChallengeTwoInternal();


        protected abstract int GetDayNumber();
        protected virtual string GetChallengeOneText() => $"Challenge One has not yet been defined.";
        protected virtual string GetChallengeTwoText() => $"Challenge One has not yet been defined.";
        protected virtual void ExecuteChallengeOneInternal() { Console.WriteLine("Not yet defined."); }
        protected virtual void ExecuteChallengeTwoInternal() { Console.WriteLine("Not yet defined."); }
        
        #endregion
    }
}