using System;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Windows.Controls;

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
        private Menu CurrentMenu = Menu.None;
        private InputMenu CurrentInputMenu = InputMenu.None;
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
        }

        //Main Window Functions
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
                    CurrentMenu = Menu.General;
                    ShowMenu(General_Canvas);
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

        //Enumerations
        private enum Menu
        {
            None,
            General,
            Graphics,
            UI,
            Input,
            Skins,
            CustomMap,
            GameSettings,
            Ability
        }
        private enum InputMenu 
        {
            None,
            General,
            Human,
            Titan,
            Shifter,
            Interaction,
            RCEditor
        }

        private enum Control
        {
            Slider,
            TextBox,
            Both
        }
        private enum Load_
        {
            Auto,
            Manual
        }

        //Controls Functions
        private void LoadToControls(double value, Slider volume_Slider, TextBox volume_TextBox, Control control, Load_ load)
        {
            double TextBoxValue;
            double SliderValue;
            if (load == Load_.Manual)
            {
                TextBoxValue = value;
                SliderValue = value * DecB;
            }
            else
            {
                TextBoxValue = value * DecA;
                SliderValue = value * DecB;
            }

            if (control == Control.TextBox)
            {
                volume_TextBox.Text = TextBoxValue.ToString();
            }
            if (control == Control.Slider)
            {
                volume_Slider.Value = SliderValue;
            }
            if (control == Control.Both)
            {
                volume_TextBox.Text = TextBoxValue.ToString();
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
                        Settings.LoadLanguages();
                        Settings.LoadGeneral();
                        Languages_ComboBox.Items.Clear();
                        foreach (string Lang in Settings.Languages)
                        {
                            _ = Languages_ComboBox.Items.Add(Lang);
                        }
                        Languages_ComboBox.SelectedIndex = Languages_ComboBox.Items.IndexOf(Settings.General.Language);
                        LoadToControls(Settings.General.Volume, Volume_Slider, Volume_TextBox, Control.Both, Load_.Manual);
                        LoadToControls(Settings.General.MouseSpeed, MouseSpeed_Slider, MouseSpeed_TextBox, Control.Both, Load_.Manual);
                        LoadToControls(Settings.General.CameraDistance, CameraDistance_Slider, CameraDistance_TextBox, Control.Both, Load_.Manual);
                        InvertMouse_CheckBox.IsChecked = Settings.General.InvertMouse;
                        CameraTilt_CheckBox.IsChecked = Settings.General.CameraTilt;
                        MinimapEnabled_CheckBox.IsChecked = Settings.General.MinimapEnabled;
                        SnapshotsEnabled_CheckBox.IsChecked = Settings.General.SnapshotsEnabled;
                        SnapshotsShowInGame_CheckBox.IsChecked = Settings.General.SnapshotsShowInGame;
                        SnapshotsMinDmg_TextBox.Text = Settings.General.SnapshotsMinimumDamage.ToString();
                        break;
                    }
                case Menu.Graphics:
                    {
                        Settings.LoadGraphics();
                        OverallQuality_ComboBox.SelectedIndex = Settings.Graphics.OverallQuality;
                        Texture_Quality_ComboBox.SelectedIndex = Settings.Graphics.TextureQuality;
                        VSynx_CheckBox.IsChecked = Settings.Graphics.VSync;
                        FPSCap_TextBox.Text = Settings.Graphics.FPSCap.ToString();
                        ShowFPS_CheckBox.IsChecked = Settings.Graphics.ShowFPS;
                        ExclusiveFullscreen_CheckBox.IsChecked = Settings.Graphics.ExclusiveFullscreen;
                        CharacterInterpolation_CheckBox.IsChecked = Settings.Graphics.InterpolationEnabled;
                        WeatherEffects_ComboBox.SelectedIndex = Settings.Graphics.WeatherEffects;
                        AntiAliasing_ComboBox.SelectedIndex = Settings.Graphics.AntiAliasing;
                        RenderDistance_Slider.Value = Settings.Graphics.RenderDistance;
                        RenderDistance_TextBox.Text = Settings.Graphics.RenderDistance.ToString();
                        AnimatedIntro_CheckBox.IsChecked = Settings.Graphics.AnimatedIntro;
                        WindEffect_CheckBox.IsChecked = Settings.Graphics.WindEffectEnabled;
                        WeaponTrail_CheckBox.IsChecked = Settings.Graphics.WeaponTrailEnabled;
                        CameraBlur_CheckBox.IsChecked = Settings.Graphics.BlurEnabled;
                        Mipmapping_CheckBox.IsChecked = Settings.Graphics.MipmapEnabled;
                        Settings.LoadGraphics();
                        break;
                    }
                case Menu.UI:
                    {
                        Settings.LoadUI();
                        UITheme_ComboBox.Items.Clear();
                        foreach (string theme in Settings.Theme)
                        {
                            UITheme_ComboBox.Items.Add(theme);
                        }
                        UITheme_ComboBox.SelectedIndex = UITheme_ComboBox.Items.IndexOf(Settings.UI.Theme);
                        UIScale_Slider.Value = Settings.UI.UIMasterScale * DecB;
                        UIScale_Textbox.Text = Settings.UI.UIMasterScale.ToString();
                        GameFeed_CheckBox.IsChecked = Settings.UI.GameFeed;
                        ShowEmotes_CheckBox.IsChecked = Settings.UI.ShowEmotes;
                        Interpolation_CheckBox.IsChecked = Settings.UI.ShowInterpolation;
                        CrosshairStyle_ComboBox.SelectedIndex = Settings.UI.CrosshairStyle;
                        CrosshairScale_Slider.Value = Settings.UI.CrosshairScale * DecB;
                        CrosshairScale_TextBox.Text = Settings.UI.CrosshairScale.ToString();
                        CrosshairDistance_CheckBox.IsChecked = Settings.UI.ShowCrosshairDistance;
                        CrosshairArrows_CheckBox.IsChecked = Settings.UI.ShowCrosshairArrows;
                        int speedometer = Settings.UI.Speedometer;
                        if (speedometer == 0)
                        {
                            Speedometer_Off.IsChecked = true;
                        }
                        else if (speedometer == 1)
                        {
                            Speedometer_Speed.IsChecked = true;
                        }
                        else if (speedometer == 2)
                        {
                            Speedometer_Damage.IsChecked = true;
                        }
                        //TODO ChatLines
                        break;
                    }
                case Menu.Input:
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
                        Settings.General.Language = Languages_ComboBox.SelectedItem.ToString();
                        Settings.General.Volume = (float)DoubleParse(Volume_TextBox.Text);
                        Settings.General.MouseSpeed = (float)DoubleParse(MouseSpeed_TextBox.Text);
                        Settings.General.CameraDistance = (float)DoubleParse(CameraDistance_TextBox.Text);
                        Settings.General.InvertMouse = InvertMouse_CheckBox.IsChecked.Value;
                        Settings.General.CameraTilt = CameraTilt_CheckBox.IsChecked.Value;
                        Settings.General.MinimapEnabled = MinimapEnabled_CheckBox.IsChecked.Value;
                        Settings.General.SnapshotsEnabled = SnapshotsEnabled_CheckBox.IsChecked.Value;
                        Settings.General.SnapshotsShowInGame = SnapshotsShowInGame_CheckBox.IsChecked.Value;
                        Settings.General.SnapshotsMinimumDamage = Convert.ToInt64(SnapshotsMinDmg_TextBox.Text);
                        Settings.SaveGeneral();
                        break;
                    }
                case Menu.Graphics:
                    {
                        Settings.Graphics.OverallQuality = OverallQuality_ComboBox.SelectedIndex;
                        Settings.Graphics.TextureQuality = Texture_Quality_ComboBox.SelectedIndex;
                        Settings.Graphics.VSync = VSynx_CheckBox.IsChecked.Value;
                        Settings.Graphics.FPSCap = Convert.ToInt32(FPSCap_TextBox.Text);
                        Settings.Graphics.ShowFPS = ShowFPS_CheckBox.IsChecked.Value;
                        Settings.Graphics.ExclusiveFullscreen = ExclusiveFullscreen_CheckBox.IsChecked.Value;
                        Settings.Graphics.InterpolationEnabled = CharacterInterpolation_CheckBox.IsChecked.Value;
                        Settings.Graphics.WeatherEffects = WeatherEffects_ComboBox.SelectedIndex;
                        Settings.Graphics.AntiAliasing = AntiAliasing_ComboBox.SelectedIndex;
                        Settings.Graphics.RenderDistance = (int)RenderDistance_Slider.Value;
                        Settings.Graphics.AnimatedIntro = AnimatedIntro_CheckBox.IsChecked.Value;
                        Settings.Graphics.WindEffectEnabled = WindEffect_CheckBox.IsChecked.Value;
                        Settings.Graphics.WeaponTrailEnabled = WeaponTrail_CheckBox.IsChecked.Value;
                        Settings.Graphics.BlurEnabled = CameraBlur_CheckBox.IsChecked.Value;
                        Settings.Graphics.MipmapEnabled = Mipmapping_CheckBox.IsChecked.Value;
                        Settings.SaveGraphics();
                        break;
                    }
                case Menu.UI:
                    {
                        Settings.UI.Theme = UITheme_ComboBox.SelectedItem.ToString();
                        Settings.UI.UIMasterScale = (float)(UIScale_Slider.Value * DecA);
                        Settings.UI.GameFeed = GameFeed_CheckBox.IsChecked.Value;
                        Settings.UI.ShowEmotes = ShowEmotes_CheckBox.IsChecked.Value;
                        Settings.UI.ShowInterpolation = Interpolation_CheckBox.IsChecked.Value;
                        Settings.UI.CrosshairStyle = CrosshairStyle_ComboBox.SelectedIndex;
                        Settings.UI.CrosshairScale = (float)(CrosshairScale_Slider.Value * DecA);
                        Settings.UI.ShowCrosshairDistance = CrosshairDistance_CheckBox.IsChecked.Value;
                        Settings.UI.ShowCrosshairArrows = CrosshairArrows_CheckBox.IsChecked.Value;
                        if (Speedometer_Off.IsChecked == true)
                        {
                            Settings.UI.Speedometer = 0;
                        }
                        else if (Speedometer_Speed.IsChecked == true)
                        {
                            Settings.UI.Speedometer = 1;
                        }
                        else if (Speedometer_Damage.IsChecked == true)
                        {
                            Settings.UI.Speedometer = 2;
                        }
                        Settings.SaveUI();
                        break;
                    }
                case Menu.Input: //Nothing
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

        //Utility Functions
        private double DoubleParse(string value)
        {
            try
            {
                return Double.Parse(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //General Functions
        private void Volume_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                LoadToControls(Volume_Slider.Value, null, Volume_TextBox, Control.TextBox, Load_.Auto);
            }
        }
        private void Mouse_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                LoadToControls(MouseSpeed_Slider.Value, null, MouseSpeed_TextBox, Control.TextBox, Load_.Auto);
            }
        }
        private void CameraDistance_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                LoadToControls(CameraDistance_Slider.Value, null, CameraDistance_TextBox, Control.TextBox, Load_.Auto);
            }
        }
        private void Volume_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoadToControls(DoubleParse(Volume_TextBox.Text), Volume_Slider, null, Control.Slider, Load_.Auto);
            }
        }
        private void MouseSpeed_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoadToControls(DoubleParse(MouseSpeed_TextBox.Text), MouseSpeed_Slider, null, Control.Slider, Load_.Auto);
            }
        }
        private void CameraDistance_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoadToControls(DoubleParse(CameraDistance_TextBox.Text), CameraDistance_Slider, null, Control.Slider, Load_.Auto);
            }
        }

        //Menu Functions
        private void ShowMenu(Canvas canvas)
        {
            General_Canvas.Visibility = Visibility.Hidden;
            Graphics_Canvas.Visibility = Visibility.Hidden;
            UI_Canvas.Visibility = Visibility.Hidden;
            Input_Canvas.Visibility = Visibility.Hidden;
            Skins_Canvas.Visibility = Visibility.Hidden;
            CustomMap_Canvas.Visibility = Visibility.Hidden;
            GameSettings_Canvas.Visibility = Visibility.Hidden;
            Ability_Canvas.Visibility = Visibility.Hidden;
            canvas.Visibility = Visibility.Visible;
            Load();
        }
        private void General_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.General)
            {
                CurrentMenu = Menu.General;
                ShowMenu(General_Canvas);
            }
        }
        private void Graphics_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.Graphics)
            {
                CurrentMenu = Menu.Graphics;
                ShowMenu(Graphics_Canvas);
            }
        }

        private void UI_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.UI)
            {
                CurrentMenu = Menu.UI;
                ShowMenu(UI_Canvas);
            }
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.Input)
            {
                CurrentMenu = Menu.Input;
                ShowMenu(Input_Canvas);
            }
        }

        private void Skins_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.Skins)
            {
                CurrentMenu = Menu.Skins;
                ShowMenu(Skins_Canvas);
            }
        }

        private void CustomMap_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.CustomMap)
            {
                CurrentMenu = Menu.CustomMap;
                ShowMenu(CustomMap_Canvas);
            }
        }

        private void GameSettings_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.GameSettings)
            {
                CurrentMenu = Menu.GameSettings;
                ShowMenu(GameSettings_Canvas);
            }
        }

        private void Ability_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMenu != Menu.Ability)
            {
                CurrentMenu = Menu.Ability;
                ShowMenu(Ability_Canvas);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void RenderDistance_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RenderDistance_TextBox.Text = ((int)RenderDistance_Slider.Value).ToString();
        }

        private void RenderDistance_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int value = (int)Convert.ToUInt64(RenderDistance_TextBox.Text);
                if (value > 3000)
                {
                    RenderDistance_TextBox.Text = "3000";
                    RenderDistance_Slider.Value = 3000;
                }
                else
                {
                    RenderDistance_Slider.Value = value;
                }
            }
        }

        private void UIScale_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                UIScale_Textbox.Text = (UIScale_Slider.Value * DecA).ToString();
            }
        }

        private void UIScale_Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                UIScale_Slider.Value = Convert.ToDouble(UIScale_Textbox.Text) * DecB;
            }
        }

        private void CrosshairScale_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                CrosshairScale_TextBox.Text = (CrosshairScale_Slider.Value * DecA).ToString();
            }
        }

        private void CrosshairScale_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                CrosshairScale_Slider.Value = Convert.ToDouble(CrosshairScale_TextBox.Text) * DecB;
            }
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
