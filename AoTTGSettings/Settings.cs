using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AoTTGSettings
{
    internal class Settings
    {
        public Ability Ability { get; set; }
        public CustomSkins CustomSkins { get; set; }
        public General General { get; set; }
        public Graphics Graphics { get; set; }
        public Input Input { get; set; }
        public LegacyGameSettings LegacyGameSettings { get; set; }
        public Profile Profile { get; set; }
        public UI UI { get; set; }
        public Weather Weather { get; set; }
        public readonly List<string> Languages = new List<string>();
        public readonly List<string> Theme = new List<string>();
        private readonly string AottgPath;
        public Settings(string aottgPath)
        {
            AottgPath = aottgPath;
            LoadGeneral();
            LoadAbility();
            LoadCustomSkins();
            LoadGraphics();
            LoadInput();
            LoadLegacyGameSettings();
            LoadProfile();
            LoadUI();
            LoadWeather();
            LoadLanguages();
            LoadThemes();
        }

        public void LoadThemes()
        {
            Theme.Clear();

            foreach (string theme in Directory.GetFiles(Path.Combine(AottgPath, "AottgRC_Data\\Resources\\UIThemes")))
            {
                Theme.Add(Path.GetFileNameWithoutExtension(theme));
            }
        }

        public void LoadLanguages()
        {
            Languages.Clear();

            foreach (string lang in Directory.GetFiles(Path.Combine(AottgPath, "AottgRC_Data\\Resources\\Languages")))
            {
                Languages.Add(Path.GetFileNameWithoutExtension(lang));
            }
        }
        public void LoadGeneral()
        {
            General = JsonConvert.DeserializeObject<General>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\General.json")));
        }
        public void LoadAbility()
        {
            Ability = JsonConvert.DeserializeObject<Ability>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Ability.json")));
        }
        public void LoadCustomSkins()
        {
            CustomSkins = JsonConvert.DeserializeObject<CustomSkins>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\CustomSkins.json")));
        }
        public void LoadGraphics()
        {
            Graphics = JsonConvert.DeserializeObject<Graphics>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Graphics.json")));
        }
        public void LoadInput()
        {
            Input = JsonConvert.DeserializeObject<Input>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Input.json")));
        }
        public void LoadLegacyGameSettings()
        {
            LegacyGameSettings = JsonConvert.DeserializeObject<LegacyGameSettings>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\LegacyGameSettings.json")));
        }
        public void LoadProfile()
        {
            Profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Profile.json")));
        }
        public void LoadUI()
        {
            UI = JsonConvert.DeserializeObject<UI>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\UI.json")));
        }
        public void LoadWeather()
        {
            Weather = JsonConvert.DeserializeObject<Weather>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Weather.json")));
        }






        public void SaveGeneral()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\General.json"), JsonConvert.SerializeObject(General, Formatting.Indented));
        }

        public void SaveAbility()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Ability.json"), JsonConvert.SerializeObject(Ability));
        }
        public void SaveCustomSkins()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\CustomSkins.json"), JsonConvert.SerializeObject(CustomSkins, Formatting.Indented));
        }
        public void SaveGraphics()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Graphics.json"), JsonConvert.SerializeObject(Graphics, Formatting.Indented));
        }
        public void SaveInput()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Input.json"), JsonConvert.SerializeObject(Input, Formatting.Indented));
        }
        public void SaveLegacyGameSettings()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\LegacyGameSettings.json"), JsonConvert.SerializeObject(LegacyGameSettings, Formatting.Indented));
        }
        public void SaveProfile()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Profile.json"), JsonConvert.SerializeObject(Profile, Formatting.Indented));
        }
        public void SaveUI()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\UI.json"), JsonConvert.SerializeObject(UI, Formatting.Indented));
        }
        public void SaveWeather()
        {
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Weather.json"), JsonConvert.SerializeObject(Weather, Formatting.Indented));
        }
    }
}
