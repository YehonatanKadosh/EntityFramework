using EFDAL;
using System.Windows;
using System.Windows.Controls;

namespace EFPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PowerRangerDal DAL = new PowerRangerDal();
        public MainWindow()
        {
            InitializeComponent();
            By_LecturerName.TextChanged += By_LecturerName_TextChanged;
            By_LectureName.TextChanged += By_LectureName_TextChanged;
            Date_Picker.SelectedDateChanged += Date_Picker_SelectedDateChanged;

        }

        private void All_Lecturers_Click(object sender, RoutedEventArgs e)
        {
            Main_DG.ItemsSource = DAL.GetAllLecturers();
        }
        private void All_Lectures_Click(object sender, RoutedEventArgs e)
        {
            Main_DG.ItemsSource = DAL.GetAllLectures();
        }
        private void By_LecturerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Main_DG.ItemsSource = DAL.GetLecturesByLecturerName(By_LecturerName.Text);
        }
        private void By_LectureName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Main_DG.ItemsSource = DAL.GetLecturesByLectureName(By_LectureName.Text);
        }

        private void Date_Picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Main_DG.ItemsSource = DAL.GetLecturesByDate(Date_Picker.SelectedDate);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Main_DG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var a = (e.EditingElement as TextBox).Text; // new text
            var b = e.Row.Item; // element 
        }
    }
}
