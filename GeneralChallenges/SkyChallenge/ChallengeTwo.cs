using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GeneralChallenges.SkyChallenge
{
    public class ChallengeTwo
    {
        [Flags]
        public enum ResultEnum
        {
            WrongAnswer = 0,
            Ok = 1,
            TimeLimitExceed = 2,
            RuntimeError = 4,
            Passed = Ok,
            NotPassed = WrongAnswer | TimeLimitExceed | RuntimeError
        }

        public static class ResultEnumFactory
        {
            public static ResultEnum GetResultEnum(string result)
            {
                switch (result)
                {
                    case "Wrong answer":
                        return ResultEnum.WrongAnswer;
                    case "OK":
                        return ResultEnum.Ok;
                    case "Time limit exceeded":
                        return ResultEnum.TimeLimitExceed;
                    case "Runtime error":
                        return ResultEnum.RuntimeError;
                    default:
                        throw new ArgumentException($"The result {result} is invalid");
                }
            }
        }

        public int solution(string[] T, string[] R)
        {
            var dict = new Dictionary<string, ResultEnum>();
            int numberOfTests = T.Length;

            for (int i = 0; i < numberOfTests; i++)
            {
                var metaData = Regex.Match(T[i], @"^([a-z]{1,30}[0-9]+)");
                var groupKey = metaData.Groups[1].Value;
                var testResult = ResultEnumFactory.GetResultEnum(R[i]);

                if (!dict.ContainsKey(groupKey))
                    dict.Add(groupKey, testResult);
                else
                    dict[groupKey] = dict[groupKey] & testResult;
            }

            int totalGroupTests = dict.Count;
            int totalPassed = dict.Count(p => p.Value.HasFlag(ResultEnum.Passed));
            int finalResult = (int) (totalPassed * 100) / totalGroupTests;

            return finalResult;
        }
    }
}
