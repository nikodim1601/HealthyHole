using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;

namespace Domain
{
    public class Constants
    {
        /// <summary>
        /// Должности.
        /// </summary>
        public enum Positions
        {
            Manager,
            Engineer,
            TesterOfCUMdle,
        }

        public static string GetJsonPositions()
        {
            // Прошу прощения за такую порнуху, но я что-то не нагуглил как enum в json сериализовать. 
            var dict = new Dictionary<int, string>()
            {
                { 0, Positions.Engineer.GetDisplayName() },
                { 1, Positions.Manager.GetDisplayName() },
                { 2, Positions.TesterOfCUMdle.GetDisplayName() },
            };

            return JsonConvert.SerializeObject(dict);
        }
    }
}
