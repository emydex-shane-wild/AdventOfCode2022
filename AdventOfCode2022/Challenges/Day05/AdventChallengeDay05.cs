#region License Information

// **********************************************************************************************************************************
// AdventChallengeDayFive.cs
// Last Modified: 2022/12/06 10:44 AM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Architecture.Extensions;

namespace AdventOfCode2022.Challenges.Day05
{
    public class AdventChallengeDay05 : AdventChallengeBase
    {
        #region Overrides of AdventChallengeBase

        protected override int GetDayNumber() => 5;
        protected override string GetChallengeOneText() => "After the rearrangement procedure completes, what crate ends up on top of each stack?";
        protected override string GetChallengeTwoText() => "After the rearrangement procedure completes, what crate ends up on top of each stack?";

        protected override void ExecuteChallengeOneInternal()
        {
            var stacks = CreateStacks("day5_input_challenge1");
            var directives = CreateDirections("day5_input_challenge1");
            PerformDirection(stacks, directives);
            Console.WriteLine($"Top Supply Codes on each stack is {GetTopCrateSupplyCodes(stacks)}.");
        }

        protected override void ExecuteChallengeTwoInternal()
        {
            var stacks = CreateStacks("day5_input_challenge1");
            var directives = CreateDirections("day5_input_challenge1");
            PerformDirectionWithMultiMove(stacks, directives);
            Console.WriteLine($"Top Supply Codes on each stack is {GetTopCrateSupplyCodes(stacks)}.");
        }

        private static string GetTopCrateSupplyCodes(IDictionary<int, ICrateStack> stacks)
        {
            var topOfStacks = string.Empty;
            for (var i = 1; i <= stacks.Count; i++)
            {
                topOfStacks += stacks[i]
                               .PeekTopOfStack()
                               ?.SuppliesCode.ToString() ?? "";
            }

            return topOfStacks;
        }

        private void PerformDirectionWithMultiMove(IDictionary<int, ICrateStack> stacks, Queue<IDirective> directives)
        {
            while(directives.Count > 0)
            {
                var directive = directives.Dequeue();
                if(stacks[directive.SourceStack] is IStackMultipleCrates sourceStack && stacks[directive.TargetStack] is IStackMultipleCrates targetStack)
                {
                    targetStack.AddCratesToStack(sourceStack.PickCratesFromTopOfStack(directive.AmountToMove));
                }
            }
        }

        private void PerformDirection(IDictionary<int, ICrateStack> stacks, Queue<IDirective> directives)
        {
            while(directives.Count > 0)
            {
                var directive = directives.Dequeue();

                var sourceStack = stacks[directive.SourceStack];
                var targetStack = stacks[directive.TargetStack];

                var amountToMove = sourceStack.StackSize() >= directive.AmountToMove ? directive.AmountToMove : sourceStack.StackNumber;

                for (var i = 0; i < amountToMove; i++)
                {
                    targetStack.AddCrateToStack(sourceStack.PickTopOfStack());
                }
            }
        }

        private Queue<IDirective> CreateDirections(string fileResourceName)
        {
            var directions = new Queue<IDirective>();

            FileExtensions.ProcessStream(fileResourceName, r =>
                                                           {
                                                               var startReading = false;
                                                               while (r.Peek() >= 0)
                                                               {
                                                                   var line = r.ReadLine();
                                                                   if(startReading)
                                                                   {
                                                                       directions.Enqueue(new Movement(line));
                                                                   }
                                                                   else if(line.IsNullOrEmptyOrWhiteSpace())
                                                                   {
                                                                       startReading = true;
                                                                   }
                                                               }
                                                           });

            return directions;
        }

        private IDictionary<int, ICrateStack> CreateStacks(string fileResourceName)
        {
            var invertedCrateStacks = new Stack<string>();
            var crateNumbers = string.Empty;
            
            FileExtensions.ProcessStream(fileResourceName, r =>
                                                           {
                                                               while (crateNumbers.IsNullOrEmpty())
                                                               {
                                                                   var line = r.ReadLine();
                                                                   if(line?.StartsWith(" 1") == true)
                                                                   {
                                                                       crateNumbers = line;
                                                                   }

                                                                   if(line?.StartsWith("[") == true)
                                                                   {
                                                                       invertedCrateStacks.Push(line);
                                                                   }
                                                               }
                                                           });

            var stacks = GenerateCrateStacks(crateNumbers.Replace(" ", ""));
            PopulateStacks(stacks, invertedCrateStacks);
            return stacks;
        }

        private void PopulateStacks(IDictionary<int, ICrateStack> stacks, Stack<string> invertedCrateStacks)
        {
            while(invertedCrateStacks.Count > 0)
            {
                var crateRow = invertedCrateStacks.Pop();
                for(var i = 0; i < 36; i+=4)
                {
                    var crateText = crateRow.Substring(i, 3);
                    if(crateText.IsNullOrEmptyOrWhiteSpace() == false)
                    {
                        if(char.TryParse(crateText.Replace(" ", "")
                                                    .Replace("[", "")
                                                    .Replace("]", ""), out var suppliesCode))
                        {
                            var crateStackNum = (i+4) / 4;
                            if(stacks.ContainsKey(crateStackNum))
                            {
                                stacks[crateStackNum].AddCrateToStack(new Crate(suppliesCode));
                            }
                        }
                    }
                }
            }
        }

        private IDictionary<int, ICrateStack>  GenerateCrateStacks(string crateStackNumbers)
        {
            var stacks = new List<ICrateStack>();

            for (var i = 0; i < crateStackNumbers.Length; i++)
            {
                if(int.TryParse(crateStackNumbers[i].ToString(), out var stackNumber))
                {
                    stacks.Add(new CrateStack(stackNumber));
                }
            }
            
            return stacks.ToDictionary(k => k.StackNumber, v => v);
        }

        #endregion
    }
}