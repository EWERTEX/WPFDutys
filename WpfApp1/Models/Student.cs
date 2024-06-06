using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models;

public class Student: INotifyPropertyChanged
{
    private bool _isDuty;
    
    [Key] 
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Patronymic { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Group { get; set; } = "";

    public bool IsDuty
    {
        get => _isDuty;
        
        set
        {
            if (_isDuty == value) return;
            
            _isDuty = value;
            OnPropertyChanged();
        }
    }

    public string FullInfo => $"{Id}. {Surname} {Name} {Patronymic} ({Group})";

    public override string ToString()
    {
        return $"{Id}. {Surname} {Name} {Patronymic} ({Group})";
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}