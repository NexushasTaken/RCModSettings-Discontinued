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
        private delegate string GamePath();
        private readonly Data Data;
        private readonly Settings Settings;
        private Menu CurrentMenu;
        private readonly double DecA = 0.01;
        private readonly double DecB = 100.0;
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
            _ = IsAoTTGPath(() => { return Data.AoTTG_Path; });
            CurrentMenu = Menu.General;
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
            if (!IsAoTTGPath(() => { return Data.AoTTG_Path = Start_TextBox.Text; }))
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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
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
        private enum Control
        {
            Slider,
            TextBox
        }

        private void LoadToControls(double value, System.Windows.Controls.Slider volume_Slider, System.Windows.Controls.TextBox volume_TextBox)
        {
            double SliderValue = value * DecB;
            Console.WriteLine(value);
            Console.WriteLine(value);
            Console.WriteLine(SliderValue);
            if (Volume_TextBox != null)
            {
                volume_TextBox.Text = value.ToString();
            }
            if (volume_Slider != null)
            {
                volume_Slider.Value = SliderValue;
            }
        }

        //Load and Save Functions
        private void Load()
        {
            switch (CurrentMenu)
            {
                case Menu.General:
                    {
                        LoadToControls(Settings.General.Volume, Volume_Slider, Volume_TextBox);
                        LoadToControls(Settings.General.MouseSpeed, MouseSpeed_Slider, MouseSpeed_TextBox);
                        LoadToControls(Settings.General.CameraDistance, CameraDistance_Slider, CameraDistance_TextBox);
                        break;
                    }
                case Menu.Graphics:
                    {
                        break;
                    }
                case Menu.UI:
                    {
                        break;
                    }
                case Menu.Rebinds:
                    {
                        break;
                    }
                case Menu.Skins:
                    {
                        break;
                    }
                case Menu.CustomMap: //Nothing
                    {
                        break;
                    }
                case Menu.GameSettings:
                    {
                        break;
                    }
                case Menu.Ability:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void Save()
        {
            switch (CurrentMenu)
            {
                case Menu.General:
                    {
                        Settings.SaveGeneral();
                        break;
                    }
                case Menu.Graphics:
                    {
                        Settings.SaveGraphics();
                        break;
                    }
                case Menu.UI:
                    {
                        Settings.SaveUI();
                        break;
                    }
                case Menu.Rebinds: //Nothing
                    {
                        break;
                    }
                case Menu.Skins:
                    {
                        Settings.SaveCustomSkins();
                        break;
                    }
                case Menu.CustomMap: //Nothing
                    {
                        break;
                    }
                case Menu.GameSettings:
                    {
                        Settings.SaveLegacyGameSettings();
                        break;
                    }
                case Menu.Ability:
                    {
                        Settings.SaveAbility();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Volume_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LoadToControls(Volume_Slider.Value, null, Volume_TextBox);
        }

        private void MouseSpeed_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void CameraDistance_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
    internal class Data
    {
        public string AoTTG_Path
        {
            get;
            set;
        }
    }

}
