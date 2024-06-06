using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp1.DataBase;
using System.Text.RegularExpressions;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : INotifyPropertyChanged
{
    private ObservableCollection<Student> _students;
    public ObservableCollection<Student> Students
    {
        get => _students;

        set
        {
            _students = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<Student> _attendants;
    public ObservableCollection<Student> Attendants
    {
        get => _attendants;

        set
        {
            _attendants = value;
            OnPropertyChanged();
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        using (var db = new StudentContext())
        {
            Students = new ObservableCollection<Student>(db.Students.ToList());
        }

        Attendants = new ObservableCollection<Student>(Students.Where(s => s.IsDuty == true));

        foreach (var student in Students)
        {
            student.PropertyChanged += StudentOnPropertyChanged;
        }
    }

    private void StudentOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if(sender is not Student student)
            return;

        if (!Attendants.Contains(student) && student.IsDuty)
        {
            Attendants.Add(student);
            OnPropertyChanged();
            return;
        }

        if (student.IsDuty || !Attendants.Contains(student)) return;
        
        Attendants.Remove(student);
        OnPropertyChanged();
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void ButtonGenerateOnClick(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(CountBox.Text, out var attendantsCount))
        {
            MessageBox.Show("Некорректное значение количества дежурных");
            return;
        }

        attendantsCount += Attendants.Count;
        
        if (attendantsCount > Students.Count)
        {
            MessageBox.Show("В списке недостаточно студентов");
            return;
        }
        
        var random = new Random();

        for (var i = 0; i < attendantsCount; i++)
        {
            while (StudentsBox.Items.Count < attendantsCount)
            {
                var attendant = Students.FirstOrDefault(s => s.Id == random.Next(1, Students.Count + 1));

                if (attendant == null || Attendants.Contains(attendant)) continue;

                attendant.IsDuty = true;
            }
        }
    }

    private void ButtonClearOnClick(object sender, RoutedEventArgs e)
    {
        foreach (var attendant in Attendants.ToList())
        {
            attendant.IsDuty = false;
            Attendants.Remove(attendant);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}