using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace XamarinExample.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        private string _name;

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return; 

                _name = value;

                OnPerpertyChanged(nameof(Name));
            }
        }

        private void OnPerpertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
