using CarbonEmissions.Commands;
using CarbonEmissions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;

namespace CarbonEmissions.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        #region Constructors
        public MainViewModel()
        {
            _person = new Person();
            CountryIndex = Array.IndexOf(Electricity.Countries, "Australia");
        }
        #endregion

        #region Members
        private Person _person;
        private int _applianceIndex = 0;
        public int ApplianceIndex
        {
            get
            {
                return _applianceIndex;
            }
            set
            {
                _applianceIndex = value;
                OnPropertyChanged("ApplianceIndex");
            }
        }
        private int _countryIndex = 0;
        public int CountryIndex
        {
            get
            {
                return _countryIndex;
            }
            set
            {
                _countryIndex = value;
                _person.SetCountry(Electricity.Countries[CountryIndex]);
                OnPropertyChanged("CountryIndex");
                UpdateFootprint();

            }
        }
        private float _carbonTheshold = 20.0f;
        public string Footprint
        {
            get
            {
                return _person.GetFootprint().ToString("0.00");
            }
        }
        private Brush _progressBarColour;
        public Brush ProgressBarColour
        {
            get
            {

                int r = (int)(255.0f * MathF.Min(1.0f, _person.GetFootprint() / _carbonTheshold));
                return new SolidColorBrush(Color.FromRgb((byte)r, (byte)(255 - r), 0));
            }
            set
            {
                _progressBarColour = value;
            }
        }
        private DataManager dataManager = new DataManager();
        //private ObservableCollection<string> _countries = new ObservableCollection<string>();
        #endregion

        #region Commands
        public ICommand SelectApplianceCommand { get { return new ParameteredCommand(parameter=>SelectAppliance(parameter)); } }
        public ICommand QuitCommand { get { return new DelegateCommand(() => Application.Current.Shutdown()); } }
        public IEnumerable<Appliance> Appliances { get { return _person.GetAppliances(); } }
        public IEnumerable<string> Countries { get { return new ObservableCollection<string>(Electricity.Countries); } }
        #endregion

        #region Methods
        private void SelectAppliance(object sender)
        {
            Appliance app = _person.GetAppliances()[_applianceIndex];
            System.Windows.MessageBox.Show(app.Description, app.Name);
            if (sender is Appliance)
            {
                Appliance appliance = sender as Appliance;
                System.Windows.MessageBox.Show(appliance.Description, appliance.Name);

            }
        }

        public void UpdateFootprint()
        {
            OnPropertyChanged("Footprint");
            OnPropertyChanged("ProgressBarColour");
        }
        #endregion







        //public ICommand DisplayFilesCommand { get { return new DelegateCommand(DisplayFiles); } }
        //private readonly ObservableCollection<VideoInfo> _videos = new ObservableCollection<VideoInfo>();
        //public IEnumerable<VideoInfo> Videos
        //{
        //    get { return _videos; }
        //}

    }
}
