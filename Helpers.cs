using System;
using System.Collections.Generic;
using Advantage.API.Models;

namespace Advantage.API
{
    public class Helpers
    {
        private static Random _rand = new Random();

        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeCustomerName()
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            return prefix + suffix;
        }

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "jimena",
            "julianna",
            "lennon",
            "lucia",
            "khaleesi",
            "ivory",
            "wren",
            "ayla",
            "bailee",
            "kennedi"
        };

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "unmarked",
            "adaptable",
            "icelandic",
            "enterprising",
            "adaptive",
            "apostolic",
            "renowned",
            "contributing",
            "alternative",
            "sexy"
        };

        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(states);
        }

        private static readonly List<string> states = new List<string>()
        {
            "oregon",
            "windmill",
            "louisiana",
            "silo",
            "pallisade",
            "lighthouse",
            "badland",
            "pen",
            "fortress",
            "motel"
        };

        internal static DateTime? GetRandomOrderComplested(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;

            if (timePassed < minLeadTime)
            {
                return null;
            }
            return orderPlaced.AddDays(_rand.Next(7, 14));
        }

        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next((int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100, 1000);
        }

    }
}