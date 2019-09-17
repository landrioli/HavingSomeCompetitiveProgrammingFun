using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankChallenges.Practice.Algorithm.Implementation
{
    public class DayOfTheProgrammer
    {
        private static readonly Dictionary<int, int> BaseDaysOfEachMounth = new Dictionary<int, int>()
        {
            {1, 31},
            {2, 28},
            {3, 31},
            {4, 30},
            {5, 31},
            {6, 30},
            {7, 31},
            {8, 31},
            {9, 30},
            {10, 31},
            {11, 30},
            {12, 31}
        };

        private const int DayOfProgrammer = 256;

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            if (year >= 1700 && year <= 1917)
            {
                return CalculateJulianCalendar(year);
            }
            else if (year == 1918)
            {
                return CalculateTransitionCalendar(year);
            }
            else
            {
                return CalculateGregorianCalendar(year);
            }

        }

        private static string CalculateGregorianCalendar(int year)
        {
            bool isLeapMounth = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
            if (isLeapMounth)
            {
                BaseDaysOfEachMounth[2] = 29;
            }

            return string.Format($"{SumDaysForProgrammerDay()}.09.{year}");
        }

        private static string CalculateJulianCalendar(int year)
        {
            bool isLeapMounth = year % 4 == 0;
            if (isLeapMounth)
            {
                BaseDaysOfEachMounth[2] = 29;
            }

            return string.Format($"{SumDaysForProgrammerDay()}.09.{year}");
        }

        private static string CalculateTransitionCalendar(int year)
        {
            BaseDaysOfEachMounth[2] = BaseDaysOfEachMounth[2] - 13;

            return string.Format($"{SumDaysForProgrammerDay()}.09.{year}");
        }

        private static string SumDaysForProgrammerDay()
        {
            int totalDays = 0;
            for (int i = 1; i <= 8; i++)
            {
                totalDays += BaseDaysOfEachMounth[i];
            }

            return (DayOfProgrammer - totalDays).ToString();
        }
    }
}
