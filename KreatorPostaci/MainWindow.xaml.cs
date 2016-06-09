using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace KreatorPostaci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Character> CharacterList {get; set; }
        public Settings settings;
        public MainWindow()
        {
            InitializeComponent();
            CharacterList = new ObservableCollection<Character>();
            this.settings = new Settings();
            this.RaceComboBox.ItemsSource = Enum.GetValues(typeof(Races));
            this.RaceComboBox.SelectedIndex = 0;
            this.ProfessionComboBox.ItemsSource = Enum.GetValues(typeof(Professions));
            this.ProfessionComboBox.SelectedIndex = 0;
            this.DataContext = this;
            this.WeightTextBox.DataContext = "settings";
            

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string nickname = this.NickTextBox.Text;
            int lvl = int.Parse(this.LevelTextBox.Text);
            Races race = (Races)Enum.Parse(typeof(Races), this.RaceComboBox.Text);
            Professions profession = (Professions)Enum.Parse(typeof(Professions), this.ProfessionComboBox.Text);
            Character character = new Character(nickname, lvl, race, profession);
            CharacterList.Add(character);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CharacterList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("First select character from list.", "Ohh crap...");
            }
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
             Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if(result == true)
            {
                filename = dlg.FileName;
            }
            if(File.Exists(filename))
            {
                XmlFileToList(filename);
            }
            else
            {
                MessageBox.Show(@"Such file doesn't exist");
            }
        }

        private void XmlFileToList(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<Character>));
                ObservableCollection<Character> tmpList = (ObservableCollection<Character>) deserializer.Deserialize(sr);
                foreach (var item in tmpList)
                {
                    CharacterList.Add(item);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Characters"; // Default file name
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string filePath = dlg.FileName;
                ListToXmlFile(filePath);
            }
        }

        private void ListToXmlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Character>));
                serializer.Serialize(sw, CharacterList);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            settings.Weight++;
            int tmp = int.Parse(this.WeightTextBox.Text);
            tmp++;
            this.WeightTextBox.Text = tmp.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            settings.Weight--;
            //int tmp = int.Parse(this.WeightTextBox.Text);
            //tmp--;
            //this.WeightTextBox.Text = tmp.ToString();
        }
    }
}
