using System;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;

namespace AoTTGSettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void Alternate(bool b);
        private delegate String GamePath();
        private readonly Data Data;
        private Settings Settings;
        private Menu CurrentMenu;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Data = JsonConvert.DeserializeObject<Data>(File.ReadAllText("Data.json"));
            }
            catch (FileNotFoundException)
            {
                Data = new Data
                {
                    AoTTG_Path = ""
                };
                File.WriteAllText("Data.json", JsonConvert.SerializeObject(Data, Formatting.Indented));
            }
            Settings = new Settings(Data.AoTTG_Path);
            IsAoTTGPath(() => { return Data.AoTTG_Path; });
            this.CurrentMenu = Menu.General;
        }
        private enum Menu 
        {
            General,
            Graphics,
            UI,
            Rebinds,
            Skins,
            CustomMap,
            GameSettings,
            Ability
        }

        private void Load()
        {
            switch (CurrentMenu)
            {
                case Menu.General:
                    {
                        Settings.LoadGeneral();
                        {//Language
                            Lang_ComboBox.Items.Clear();
                            string langs = Path.Combine(Data.AoTTG_Path, "AottgRC_Data\\Resources\\Languages");
                            foreach (string LangFiles in Directory.GetFiles(langs))
                            {
                                Lang_ComboBox.Items.Add(Path.GetFileNameWithoutExtension(LangFiles));
                                Console.WriteLine(LangFiles);
                            }
                            Lang_ComboBox.SelectedIndex = Lang_ComboBox.Items.IndexOf(Settings.General.Language);
                        }
                        {//Volume
                            Console.WriteLine(Settings.General.Volume);
                        }
                        {//Mouse Speed
                            Console.WriteLine(Settings.General.MouseSpeed);
                        }
                        {//Camera Distance
                            Console.WriteLine(Settings.General.CameraDistance);
                        }
                        {//Invert Mouse
                            Console.WriteLine(Settings.General.InvertMouse);
                        }
                        {//Camera Tilt
                            Console.WriteLine(Settings.General.CameraTilt);
                        }
                        {//Minimap on
                            Console.WriteLine(Settings.General.MinimapEnabled);
                        }
                        {//Snapshots on
                            Console.WriteLine(Settings.General.SnapshotsEnabled);
                        }
                        {//Snapshots in-game
                            Console.WriteLine(Settings.General.SnapshotsShowInGame);
                        }
                        {//Snapshots min dmg
                            Console.WriteLine(Settings.General.SnapshotsMinimumDamage);
                        }
                        break;
                    }
                case Menu.Graphics:
                    break;
                case Menu.UI:
                    break;
                case Menu.Rebinds:
                    break;
                case Menu.Skins:
                    break;
                case Menu.CustomMap:
                    break;
                case Menu.GameSettings:
                    break;
                case Menu.Ability:
                    break;
                default:
                    break;
            }
        }

        private bool IsAoTTGPath(GamePath path)
        {
            void Alt(bool b)
            {
                if (b)
                {
                    Menu_Settings.Visibility = Visibility.Visible;
                    Start_Confirm.Visibility = Visibility.Hidden;
                    Start_Exit.Visibility = Visibility.Hidden;
                    Start_label.Visibility = Visibility.Hidden;
                    Start_TextBox.Visibility = Visibility.Hidden;
                    Load();
                }
                else
                {
                    Menu_Settings.Visibility = Visibility.Hidden;
                    Start_Confirm.Visibility = Visibility.Visible;
                    Start_Exit.Visibility = Visibility.Visible;
                    Start_label.Visibility = Visibility.Visible;
                    Start_TextBox.Visibility = Visibility.Visible;
                }
            }
            bool exe = File.Exists(Path.Combine(path(), "AottgRC.exe"));
            bool gen = File.Exists(Path.Combine(path(), "AottgRC_Data\\UserData\\Settings\\General.json"));
            if (exe && gen)
            {
                Alt(true);
                File.WriteAllText("Data.json", JsonConvert.SerializeObject(Data, Formatting.Indented));
                return true;
            }
            else
            {
                Alt(false);
                return false;
            }
        }

        private void Quit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Start_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(!IsAoTTGPath(()=> { return Data.AoTTG_Path = Start_TextBox.Text; }))
            {
                Start_TextBox.Text = "Invalid Input!";
            }
        }

        private void Start_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Start_TextBox.Text = "";
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
    class Data
    {
        public String AoTTG_Path
        {
            get;
            set;
        }
    }

}
