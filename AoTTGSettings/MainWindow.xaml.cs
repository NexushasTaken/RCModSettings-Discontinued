using System;
using System.Collections.Generic;
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
        private GameSettingMenus CurrentGameSettingsMenu = GameSettingMenus.None;
        private SkinsMenus CurrentSkinMenu = SkinsMenus.None;
        private readonly double DecA = 0.01;
        private readonly double DecB = 100.0;

        private readonly TextBox[] GeneralInputsTB;
        private readonly TextBox[] HumanInputsTB;
        private readonly TextBox[] TitanInputsTB;
        private readonly TextBox[] Shifter_InputsTB;
        private readonly TextBox[] Interaction_InputsTB;
        private readonly TextBox[] RCEditor_InputsTB;

        private readonly TextBox[] HumanSkinTB;
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

            GeneralInputsTB = new TextBox[]
            {
                Forward_InputA, Forward_InputB,
                Backward_InputA, Backward_InputB,
                Left_InputA, Left_InputB,
                Right_InputA, Right_InputB,
                Pause_InputA, Pause_InputB,
                Restart_InputA, Restart_InputB,
                Chat_InputA, Chat_InputB,
                ToggleFullScreen_InputA, ToggleFullScreen_InputB,
                ChangeCamera_InputA, ChangeCamera_InputB,
                HideUI_InputA, HideUI_InputB,
                ResetMinimap_InputA, ResetMinimap_InputB,
                ToggleMinimap_InputA, ToggleMinimap_InputB,
                MinimizeMinimap_InputA, MinimizeMinimap_InputB,
                JoinGame_InputA, JoinGame_InputB,
                SpectateLive_InputA, SpectateLive_InputB,
                SpectateFree_InputA, SpectateFree_InputB,
                SpectatePrevious_InputA, SpectatePrevious_InputB,
                SpectateNext_InputA, SpectateNext_InputB
            };
            HumanInputsTB = new TextBox[]
            {
                 NormalAtk_InputA, NormalAtk_InputB,
                 SpecialAtk_InputA, SpecialAtk_InputB,
                 HookLeft_InputA, HookLeft_InputB,
                 HookRight_InputA, HookRight_InputB,
                 HookBoth_InputA, HookBoth_InputB,
                 Dash_InputA, Dash_InputB,
                 ReelIn_InputA, ReelIn_InputB,
                 ReelOut_InputA, ReelOut_InputB,
                 Dodge_InputA, Dodge_InputB,
                 FocusTitan_InputA, FocusTitan_InputB,
                 HumanJump_InputA, HumanJump_InputB,
                 Reload_InputA, Reload_InputB,
                 HorseMount_InputA, HorseMount_InputB,
                 HorseWalk_InputA, HorseWalk_InputB,
                 HorseJump_InputA, HorseJump_InputB,
                 Flare1_InputA, Flare1_InputB,
                 Flare2_InputA, Flare2_InputB,
                 Flare3_InputA, Flare3_InputB
            };
            TitanInputsTB = new TextBox[]
            {
                PunchAtk_InputA, PunchAtk_InputB,
                SlamAtk_InputA, SlamAtk_InputB,
                SlapAtk_InputA, SlapAtk_InputB,
                GrabFront_InputA, GrabFront_InputB,
                GrabBack_InputA, GrabBack_InputB,
                GrabNape_InputA, GrabNape_InputB,
                Bite_InputA, Bite_InputB,
                CoverNape_InputA, CoverNape_InputB,
                TitanJump_InputA, TitanJump_InputB,
                Sit_InputA, Sit_InputB,
                Walk_InputA, Walk_InputB
            };
            Shifter_InputsTB = new TextBox[]
            {
                ShifterNormalAtk_InputA, ShifterNormalAtk_InputB,
                ShifterSpecialAtk_InputA, ShifterSpecialAtk_InputB,
                ShifterCoverNape_InputA, ShifterCoverNape_InputB,
                ShifterJump_InputA, ShifterJump_InputB,
                ShifterSit_InputA, ShifterSit_InputB,
                ShifterWalk_InputA, ShifterWalk_InputB,
                ShifterRoar_InputA, ShifterRoar_InputB
            };
            Interaction_InputsTB = new TextBox[]
            {
                 Interact_InputA, Interact_InputB,
                 InteractCannonSlow_InputA, InteractCannonSlow_InputB,
                 InteractCannonFire_InputA, InteractCannonFire_InputB,
                 InteractEmoteMenu_InputA, InteractEmoteMenu_InputB,
                 InteractMenuNext_InputA, InteractMenuNext_InputB,
                 Interact1_InputA, Interact1_InputB,
                 Interact2_InputA, Interact2_InputB,
                 Interact3_InputA, Interact3_InputB,
                 Interact4_InputA, Interact4_InputB,
                 Interact5_InputA, Interact5_InputB,
                 Interact6_InputA, Interact6_InputB,
                 Interact7_InputA, Interact7_InputB,
                 Interact8_InputA, Interact8_InputB
            };
            RCEditor_InputsTB = new TextBox[]
            {
                RCEditorUp_InputA, RCEditorUp_InputB,
                RCEditorDown_InputA, RCEditorDown_InputB,
                RCEditorSlow_InputA, RCEditorSlow_InputB,
                RCEditorFast_InputA, RCEditorFast_InputB,
                RCEditorRotateRight_InputA, RCEditorRotateRight_InputB,
                RCEditorRotateLeft_InputA, RCEditorRotateLeft_InputB,
                RCEditorRotateClockwise_InputA, RCEditorRotateClockwise_InputB,
                RCEditorRotateCounterClockwise_InputA, RCEditorRotateCounterClockwise_InputB,
                RCEditorRotateBack_InputA, RCEditorRotateBack_InputB,
                RCEditorRotateForward_InputA, RCEditorRotateForward_InputB,
                RCEditorPlace_InputA, RCEditorPlace_InputB,
                RCEditorDelete_InputA, RCEditorDelete_InputB,
                RCEditorCursorMode_InputA, RCEditorCursorMode_InputB
            };

            HumanSkinTB = new TextBox[]
            {
                HumanHairSkin,
                HumanEyesSkin,
                HumanGlassesSkin,
                HumanFaceSkin,
                HumanSkinSkin,
                HumanCostumeSkin,
                HumanLogoSkin,
                HumanGearLeftSkin,
                HumanGearRightSkin,
                HumanGasSkin,
                HumanHoddieSkin,
                HumanWeaponTrailSkin,
                HumanHorseSkin,
                HumanThunderspearLeftSkin,
                HumanThunderspearRightSkin
            };
        
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
                    CurrentInputMenu = InputMenu.General;
                    CurrentGameSettingsMenu = GameSettingMenus.Titans;
                    CurrentSkinMenu = SkinsMenus.Human;
                    ShowSkinMenu(Human_Canvas);
                    ShowGameSettingsMenu(Titan_Settings);
                    ShowInputMenu(General_Inputs);
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
        private enum GameSettingMenus
        {
            None,
            Titans,
            Pvp,
            Misc,
            Weather
        }
        private enum SkinsMenus
        {
            None,
            Human,
            Titan,
            Shifter,
            Skybox,
            Forest,
            City,
            CustomLevel
        }
        private enum Load_
        {
            Auto,
            Manual
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
                        Volume_Slider.Value = Settings.General.Volume * DecB;
                        Volume_TextBox.Text = Settings.General.Volume.ToString();
                        MouseSpeed_Slider.Value = Settings.General.MouseSpeed * DecB;
                        MouseSpeed_TextBox.Text = Settings.General.MouseSpeed.ToString();
                        CameraDistance_Slider.Value = Settings.General.CameraDistance * DecB;
                        CameraDistance_TextBox.Text = Settings.General.CameraDistance.ToString();


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
                        Settings.LoadInput();
                        Load_Inputs(HumanInputsTB, Settings.Input.Human.GetInputs());
                        DoubleTapToDash_CheckBox.IsChecked = Settings.Input.Human.DashDoubleTap;
                        ReelOutScroolSmoothing_Slider.Value = Settings.Input.Human.ReelOutScrollSmoothing * DecB;
                        ReelOutScroolSmoothing_TextBox.Text = Settings.Input.Human.ReelOutScrollSmoothing.ToString();

                        Load_Inputs(GeneralInputsTB, Settings.Input.General.GetInputs());
                        Load_Inputs(TitanInputsTB, Settings.Input.Titan.GetInputs());
                        Load_Inputs(Shifter_InputsTB, Settings.Input.Shifter.GetInputs());
                        Load_Inputs(Interaction_InputsTB, Settings.Input.Interaction.GetInputs());
                        Load_Inputs(RCEditor_InputsTB, Settings.Input.RCEditor.GetInputs());
                        break;
                    }
                case Menu.Skins:
                    {
                        Settings.LoadCustomSkins();
                        HumanSkinSet_ComboBox.Items.Clear();
                        foreach (string name in Settings.CustomSkins.Human.GetSkinNameSet())
                        {
                            HumanSkinSet_ComboBox.Items.Add(name);
                        }
                        HumanSkinSet_ComboBox.SelectedIndex = Settings.CustomSkins.Human.SelectedSetIndex;
                        Load_Skins(HumanSkinTB, Settings.CustomSkins.Human.GetSkinSet());
                        HumanSkinOn.IsChecked = Settings.CustomSkins.Human.SkinsEnabled;
                        HumanSkinLocal.IsChecked = Settings.CustomSkins.Human.SkinsLocal;
                        HumanShowGasSkin.IsChecked = Settings.CustomSkins.Human.GasEnabled;
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
                        Settings.General.Volume = (float)(Volume_Slider.Value * DecA);
                        Settings.General.MouseSpeed = (float)(MouseSpeed_Slider.Value * DecA);
                        Settings.General.CameraDistance = (float)(CameraDistance_Slider.Value * DecA);
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
                        Save_Inputs(HumanInputsTB, Settings.Input.Human.GetInputs());
                        Settings.Input.Human.DashDoubleTap = DoubleTapToDash_CheckBox.IsChecked.Value;
                        Settings.Input.Human.ReelOutScrollSmoothing = (float)(ReelOutScroolSmoothing_Slider.Value * DecB);
                        Settings.Input.Human.ReelOutScrollSmoothing = (float)Convert.ToDouble(ReelOutScroolSmoothing_TextBox.Text);

                        Save_Inputs(GeneralInputsTB, Settings.Input.General.GetInputs());
                        Save_Inputs(TitanInputsTB, Settings.Input.Titan.GetInputs());
                        Save_Inputs(Shifter_InputsTB, Settings.Input.Shifter.GetInputs());
                        Save_Inputs(Interaction_InputsTB, Settings.Input.Interaction.GetInputs());
                        Save_Inputs(RCEditor_InputsTB, Settings.Input.RCEditor.GetInputs());
                        Settings.SaveInput();
                        break;
                    }
                case Menu.Skins:
                    {
                        Settings.SaveCustomSkins();
                        break;
                    }
                case Menu.CustomMap: //Nothing LOL
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

        private void Load_Skins(TextBox[] textBoxes, List<string> list)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                Console.WriteLine(list[i]);
                textBoxes[i].Text = list[i];
            }
        }
        private void Load_Inputs(TextBox[] textBoxes, List<List<string>> list)
        {
            int i = 0;
            foreach (List<string> input in list)
            {
                textBoxes[i++].Text = input[0];
                textBoxes[i++].Text = input[1];
            }
        }
        private void Save_Inputs(TextBox[] textBoxes, List<List<string>> list)
        {
            int i = 0;
            foreach (List<string> input in list)
            {
                input[0] = textBoxes[i++].Text;
                input[1] = textBoxes[i++].Text;
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
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        //Menu Functions
        private void ShowMenu(Canvas canvas)
        {
            General_Canvas.Visibility = Visibility.Collapsed;
            Graphics_Canvas.Visibility = Visibility.Collapsed;
            UI_Canvas.Visibility = Visibility.Collapsed;
            Input_Canvas.Visibility = Visibility.Collapsed;
            Skins_Canvas.Visibility = Visibility.Collapsed;
            CustomMap_Canvas.Visibility = Visibility.Collapsed;
            GameSettings_Canvas.Visibility = Visibility.Collapsed;
            Ability_Canvas.Visibility = Visibility.Collapsed;
            canvas.Visibility = Visibility.Visible;
            Load();
        }
        private void ShowInputMenu(Canvas canvas)
        {
            General_Inputs.Visibility = Visibility.Collapsed;
            Human_Inputs.Visibility = Visibility.Collapsed;
            Titan_Inputs.Visibility = Visibility.Collapsed;
            Shifter_Inputs.Visibility = Visibility.Collapsed;
            Interaction_Inputs.Visibility = Visibility.Collapsed;
            RCEditor_Inputs.Visibility = Visibility.Collapsed;
            canvas.Visibility = Visibility.Visible;
            Load();
        }
        private void ShowGameSettingsMenu(Canvas canvas)
        {
            Titan_Settings.Visibility = Visibility.Collapsed;
            PVP_Settings.Visibility = Visibility.Collapsed;
            Misc_Settings.Visibility = Visibility.Collapsed;
            Weather_Settings.Visibility = Visibility.Collapsed;
            canvas.Visibility = Visibility.Visible;
            Load();
        }
        private void ShowSkinMenu(Canvas canvas)
        {
            Human_Canvas.Visibility = Visibility.Collapsed;
            Titan_Canvas.Visibility = Visibility.Collapsed;
            Shifter_Canvas.Visibility = Visibility.Collapsed;
            Skybox_Canvas.Visibility = Visibility.Collapsed;
            Forest_Canvas.Visibility = Visibility.Collapsed;
            City_Canvas.Visibility = Visibility.Collapsed;
            CustomLevel_Canvas.Visibility = Visibility.Collapsed;
            canvas.Visibility = Visibility.Visible;
            Load();
        }

        //Menu Click Buttons
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
        private void GeneralInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.General)
            {
                CurrentInputMenu = InputMenu.General;
                ShowInputMenu(General_Inputs);
            }
        }
        private void HumanInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.Human)
            {
                CurrentInputMenu = InputMenu.Human;
                ShowInputMenu(Human_Inputs);
            }
        }
        private void TitanInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.Titan)
            {
                CurrentInputMenu = InputMenu.Titan;
                ShowInputMenu(Titan_Inputs);
            }
        }
        private void ShifterInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.Shifter)
            {
                CurrentInputMenu = InputMenu.Shifter;
                ShowInputMenu(Shifter_Inputs);
            }
        }
        private void InteractionInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.Interaction)
            {
                CurrentInputMenu = InputMenu.Interaction;
                ShowInputMenu(Interaction_Inputs);
            }
        }
        private void RCEditorInput_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentInputMenu != InputMenu.RCEditor)
            {
                CurrentInputMenu = InputMenu.RCEditor;
                ShowInputMenu(RCEditor_Inputs);
            }
        }
        private void TitanGameSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGameSettingsMenu != GameSettingMenus.Titans)
            {
                CurrentGameSettingsMenu = GameSettingMenus.Titans;
                ShowGameSettingsMenu(Titan_Settings);
            }
        }
        private void PVPGameSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGameSettingsMenu != GameSettingMenus.Pvp)
            {
                CurrentGameSettingsMenu = GameSettingMenus.Pvp;
                ShowGameSettingsMenu(PVP_Settings);
            }
        }
        private void MiscGameSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGameSettingsMenu != GameSettingMenus.Misc)
            {
                CurrentGameSettingsMenu = GameSettingMenus.Misc;
                ShowGameSettingsMenu(Misc_Settings);
            }
        }
        private void WeatherGameSettings_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentGameSettingsMenu != GameSettingMenus.Weather)
            {
                CurrentGameSettingsMenu = GameSettingMenus.Weather;
                ShowGameSettingsMenu(Weather_Settings);
            }
        }
        private void HumanSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.Human)
            {
                CurrentSkinMenu = SkinsMenus.Human;
                ShowSkinMenu(Human_Canvas);
            }
        }
        private void TitanSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.Titan)
            {
                CurrentSkinMenu = SkinsMenus.Titan;
                ShowSkinMenu(Titan_Canvas);
            }
        }
        private void ShifterSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.Shifter)
            {
                CurrentSkinMenu = SkinsMenus.Shifter;
                ShowSkinMenu(Shifter_Canvas);
            }
        }
        private void SkyboxSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.Skybox)
            {
                CurrentSkinMenu = SkinsMenus.Skybox;
                ShowSkinMenu(Skybox_Canvas);
            }
        }
        private void ForestSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.Forest)
            {
                CurrentSkinMenu = SkinsMenus.Forest;
                ShowSkinMenu(Forest_Canvas);
            }
        }
        private void CitySkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.City)
            {
                CurrentSkinMenu = SkinsMenus.City;
                ShowSkinMenu(City_Canvas);
            }
        }
        private void CustomLevelSkins_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSkinMenu != SkinsMenus.CustomLevel)
            {
                CurrentSkinMenu = SkinsMenus.CustomLevel;
                ShowSkinMenu(CustomLevel_Canvas);
            }
        }

        //UI Menu Functions
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

        //General Menu Functions
        private void Volume_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Volume_TextBox.Text = (Volume_Slider.Value * DecA).ToString();
            }
        }
        private void Mouse_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MouseSpeed_TextBox.Text = (MouseSpeed_Slider.Value * DecA).ToString();
            }
        }
        private void CameraDistance_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                CameraDistance_TextBox.Text = (CameraDistance_Slider.Value * DecA).ToString();
            }
        }
        private void Volume_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Volume_Slider.Value = Convert.ToDouble(Volume_TextBox.Text) * DecB;
            }
        }
        private void MouseSpeed_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                MouseSpeed_Slider.Value = Convert.ToDouble(MouseSpeed_TextBox.Text) * DecB;
            }
        }
        private void CameraDistance_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                CameraDistance_Slider.Value = Convert.ToDouble(CameraDistance_TextBox.Text) * DecB;
            }
        }

        //Custom Skins 
        private void HumanSkinSet_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Handled == false)
            {
                Load_Skins(HumanSkinTB, Settings.CustomSkins.Human.GetSkinSetByIndex(HumanSkinSet_ComboBox.SelectedIndex));
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
