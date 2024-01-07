using C_SharpPartiesJSON.JSON;
using C_SharpPartiesJSON.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Controls;

namespace C_SharpPartiesJSON.ViewModel
{
    public class UserModelView : INotifyPropertyChanged
    {
        #region VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;

        //Modelo de la lista de registros a mostrar
        private ObservableCollection<Partie> _listPart;
        private String _acronym = "";
        private String _name = "";
        private String _president = "";
        private int _validVot = 0;
        private int _seat = 0;
        #endregion

        #region OBJETOS
        public ObservableCollection<Partie> listPart
        {
            get { return _listPart; }
            set
            {
                _listPart = value;
                OnPropertyChange("listPart");
            }
        }
        public String acronym
        {
            get { return _acronym; }
            set
            {
                _acronym = value;
                OnPropertyChange("acronym");
            }
        }
        public String name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChange("name");
            }
        }

        public String president
        {
            get { return _president; }
            set
            {
                _president = value;
                OnPropertyChange("president");
            }
        }
        public int validVot
        {
            get { return _validVot; }
            set
            {
                _validVot = value;
                OnPropertyChange("validVot");
            }
        }
        public int seat
        {
            get { return _seat; }
            set
            {
                _seat = value;
                OnPropertyChange("seat");
            }
        }
        #endregion

        //Método que se encarga de actualizar las propiedades en cada cambio
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NewUser()
        {
            PartieDataComponent.insertPartie(new Partie
            {
                acronym = acronym,
                name = name,
                president = president,
                validVot = validVot,
                seat = seat
            });
        }
        public void DeletePartie()
        {
            PartieDataComponent.deletePartie(name);
        }
        public void UpdatePartie()
        {
            PartieDataComponent.updatePartie(name,seat,validVot);
        }


        public void LoadUsers()
        {
            listPart = PartieDataComponent.readPartie();
        }
    }
}
