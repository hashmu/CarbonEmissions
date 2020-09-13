using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace CarbonEmissions.Models
{
    /// <summary>
    /// The owner of many fine things. Things that consume energy. Energy that produces carbon emissions when converted into usable forms.
    /// </summary>
    class Person
    {
        #region Constructor
        public Person()
        {
            House = new House();
            Electricity = new Electricity();
        }
        #endregion

        #region Members
        House House;
        Electricity Electricity;
        #endregion

        #region Methods
        public ObservableCollection<Appliance> GetAppliances()
        {
            return House.Appliances;
        }

        public float GetFootprint()
        {
            float footprint = 0.0f;
            foreach(Appliance appliance in House.Appliances)
            {
                footprint += appliance.EnergyUse * Electricity.Intensity / 1000.0f;
            }
            return footprint;
        }

        public string GetCountry()
        {
            return Electricity.Country;
        }
        
        public void SetCountry(string country)
        {
            Electricity.Country = country;
        }
        #endregion
    }
}
