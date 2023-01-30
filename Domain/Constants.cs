using System.Collections.Generic;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;

namespace HealthyHole.Domain
{
    public static class Constants
    {
        /// <summary>
        /// Должности.
        /// </summary>
        public enum Positions
        {
            Master,
            Engineer,
            TesterOfCUMdle,
        }

        public static string GetJsonPositions()
        {
            // Прошу прощения за такую порнуху, но я что-то не нагуглил как enum в json сериализовать. 
            var dict = new Dictionary<int, string>()
            {
                { 0, Positions.Engineer.GetDisplayName() },
                { 1, Positions.Master.GetDisplayName() },
                { 2, Positions.TesterOfCUMdle.GetDisplayName() },
            };

            return JsonConvert.SerializeObject(dict);
        }
    }
}