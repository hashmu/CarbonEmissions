using System;
using System.Collections.Generic;
using System.Text;

namespace CarbonEmissions.Models
{
    /// <summary>
    /// Base class for all appliances. Each appliance type will inherit from this, and include any additional specific members if required.
    /// </summary>
    class Appliance
    {
        #region Members
        public string Name { get; set; }
        public string Description { get; set; }
        //power usage in watts
        public float Power { get; set; }
        //use per year in hours
        public float UsePerYear { get; set; }
        //total energy use in a year, in Wh
        public float EnergyUse { get { return Power * UsePerYear; } }
        //energy star rating, made a float to account for half-star ratings
        public float StarRating { get; set; }
        #endregion
    }

    class WashingMachine : Appliance
    {

    }

    class Television : Appliance
    {

    }
}
