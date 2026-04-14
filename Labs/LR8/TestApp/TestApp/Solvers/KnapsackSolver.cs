using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Debugging;
using TestApp.Models;

namespace TestApp.Solvers
{
    public static class KnapsackSolver
    {
        public static List<Item> Solve(List<Item> items, int maxWeight)
        {
            if (items == null || items.Count == 0)
                return new List<Item>();

            List<Item> bestCombination = new List<Item>();
            int bestValue = 0;

            int n = items.Count;
            int totalSubsets = 1 << n;

            for (int mask = 0; mask < totalSubsets; mask++)
            {
                int currentWeight = 0;
                int currentValue = 0;
                List<Item> currentCombination = new List<Item>();

                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        currentWeight += items[i].Weight;
                        currentValue += items[i].Cost;
                        currentCombination.Add(items[i]);
                    }
                }

                if (currentWeight <= maxWeight && currentValue > bestValue)
                {
                    bestValue = currentValue;
                    bestCombination = currentCombination;
                }
            }

            DebugLogger.Log($"Оптимальное решение найдено: стоимость = {bestValue}, вес = {bestCombination.Sum(i => i.Weight)}");
            DebugLogger.LogItems(bestCombination, "Оптимальный набор");
            return bestCombination;
        }
    }
}
