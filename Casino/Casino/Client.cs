using System; //DateTime
using System.ComponentModel;

namespace Casino
{
    public class Client : INotifyPropertyChanged //Wykaz
    {
        private int _id;
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public Client(int id, string name, string surname, DateTime dateOfBirth)
        {
            this._id = id;
            this._name = name;
            this._surname = surname;
            this._dateOfBirth = dateOfBirth;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return $"[Id: {_id}] {_name} {_surname}, {_dateOfBirth.ToString("dd/MM/yyyy")}";
        }
    }
}
