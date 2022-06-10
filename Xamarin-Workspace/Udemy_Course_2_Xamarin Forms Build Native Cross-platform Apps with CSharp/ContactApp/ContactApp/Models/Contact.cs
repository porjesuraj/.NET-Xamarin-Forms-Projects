using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
namespace ContactApp.Models
{
    public class Contact :INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        private string _firstName;
        [MaxLength(255)]
        public string FirstName
        {
            get { return _firstName; }
            set {

                if (_firstName == value)
                    return;

                _firstName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }




        private string _lastName;
        [MaxLength(255)]
        public string LastName
        {
            get { return _lastName; }
            set
            {

                if (_lastName == value)
                    return;

                _lastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Email { get; set; }

        public string Phone { get; set; }
        public bool Blocked { get; set; }


        public string FullName
        { get{ return $" {FirstName} {LastName}"; } }


        public Contact()
        {
            Id = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
