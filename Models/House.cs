using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarbonEmissions.Models
{
    class House
    {
        #region Constructors
        public House()
        {
            Appliances.Add(new WashingMachine()
            {
                Name = "Clothes Washer",
                Description = "A middle of the range LG washer.",
                Power = 500.0f,
                UsePerYear = 52.0f,
                StarRating = 1.0f
            });
            Appliances.Add(new Television()
            {
                Name = "Television",
                Description = "42inch Samsung television.",
                Power = 58.0f,
                UsePerYear = 2*200.0f,
                StarRating = 1.0f
            });
        }
        #endregion

        #region Members
        public ObservableCollection<Appliance> Appliances = new ObservableCollection<Appliance>();
        public float TotalPower { get { return GetTotalPowerConsumption(); } }
        #endregion

        #region Methods
        private float GetTotalPowerConsumption()
        {
            float consumption = 0.0f;
            foreach(Appliance appliance in Appliances)
            {
                consumption += appliance.EnergyUse;
            }
            return consumption;
        }
        #endregion

    }
}
