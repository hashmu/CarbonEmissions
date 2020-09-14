using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarbonEmissions.Models
{
    /// <summary>
    /// Class for determining the carbon intensity used in calculations. Currently using the latest average figure for each country in the list.
    /// </summary>
    class Electricity
    {
        #region Constructors
        public Electricity()
        {
            GetIntensities();
        }
        #endregion

        #region Members
        public static string[] Countries;

        public float Intensity {
            get
            {
                if (Intensities.TryGetValue(Country, out float value))
                {
                    return value;
                }
                else
                {
                    return 0.0f;
                }
            }
        }
        Dictionary<string, float> Intensities = new Dictionary<string, float>();
        public string Country { get; set; } = "Australia";
        #endregion

        #region Methods
        private void GetIntensities()
        {
            string filepath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "carbon_intensities.csv");
            using (var reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(",");
                        if (!Intensities.ContainsKey(values[0]))
                        {
                            Intensities.Add(values[0], float.Parse(values[1]));
                        }
                    }
                    catch(Exception e)
                    {

#if UNITY_EDITOR
                        Debug.Log("Could not load " + filepath);
#endif
                    }
                }
            }
            Countries = Intensities.Keys.ToArray();
        }
#endregion
    }
}
