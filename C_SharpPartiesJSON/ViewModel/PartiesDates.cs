using C_SharpPartiesJSON.JSON;
using C_SharpPartiesJSON.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C_SharpPartiesJSON.ViewModel
{
    public class PartiesDates : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _pobla = 0;
        private int _absten = 0;
        private int _nullVotes = 0;
        private int _votesV = 0;
        #endregion

        #region OBJETOS
        public int pobla
        {
            get { return _pobla; }
            set
            {
                if (_pobla != value)
                {
                    _pobla = value;
                    OnPropertyChange("pobla");
                }
            }
        }

        public int absten
        {
            get { return _absten; }
            set
            {
                if (_absten != value)
                {
                    _absten = value;
                    OnPropertyChange("absten");
                }
            }
        }

        public int nullVotes
        {
            get { return _nullVotes; }
            set
            {
                if (_nullVotes != value)
                {
                    _nullVotes = value;
                    OnPropertyChange("nullVotes");
                }
            }
        }

        public int votesV
        {
            get { return _votesV; }
            set
            {
                if (_votesV != value)
                {
                    _votesV = value;
                    OnPropertyChange("votesV");
                }
            }
        }
        #endregion
        //Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpadateOrNew()
        {
            ObservableCollection<Dates> dates = PartieDataComponent.ReadDates();

            if (dates.Count > 0)
            {
                UpdateDate();
            }
            else
            {
                NewDate();
            }
        }

        public void NewDate()
        {
            Dates newDate = new Dates
            {
                pobla = pobla,
                absten = absten,
                nullVotes = nullVotes,
                votesV = votesV
            };

            PartieDataComponent.InsertDate(newDate);
        }

        public void UpdateDate()
        {
            Dates existingDate = PartieDataComponent.ReadDates().First();
            existingDate.pobla = pobla;
            existingDate.absten = absten;
            existingDate.nullVotes = nullVotes;
            existingDate.votesV = votesV;

            PartieDataComponent.UpdateDate(existingDate);
        }

        public void LoadDates(Dates dates)
        {
            ObservableCollection<Dates> datesCollection = PartieDataComponent.ReadDates();

            if (datesCollection.Count > 0)
            {
                Dates existingDate = datesCollection.First();
                dates.pobla = existingDate.pobla;
                dates.absten = existingDate.absten;
                dates.nullVotes = existingDate.nullVotes;
                dates.votesV = existingDate.votesV;
            }
        }

    }
}
