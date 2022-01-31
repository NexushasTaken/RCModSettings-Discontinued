using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoTTGSettings
{
    class Settings
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
        private readonly string AottgPath;
        public Settings(string aottgPath)
        {
            this.AottgPath = aottgPath;
            LoadGeneral();
            LoadAbility();
            LoadCustomSkins();
            LoadGraphics();
            LoadInput();
            LoadLegacyGameSettings();
            LoadProfile();
            LoadUI();
            LoadWeather();
        }
        public void LoadGeneral()
        {
            this.General = JsonConvert.DeserializeObject<General>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\General.json")));
        }
        public void LoadAbility()
        {
            this.Ability = JsonConvert.DeserializeObject<Ability>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Ability.json")));
        }
        public void LoadCustomSkins()
        {
            this.CustomSkins = JsonConvert.DeserializeObject<CustomSkins>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\CustomSkins.json")));
        }
        public void LoadGraphics()
        {
            this.Graphics = JsonConvert.DeserializeObject<Graphics>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Graphics.json")));
        }
        public void LoadInput()
        {
            this.Input = JsonConvert.DeserializeObject<Input>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Input.json")));
        }
        public void LoadLegacyGameSettings()
        {
            this.LegacyGameSettings = JsonConvert.DeserializeObject<LegacyGameSettings>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\LegacyGameSettings.json")));
        }
        public void LoadProfile()
        {
            this.Profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Profile.json")));
        }
        public void LoadUI()
        {
            this.UI = JsonConvert.DeserializeObject<UI>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\UI.json")));
        }
        public void LoadWeather()
        {
            this.Weather = JsonConvert.DeserializeObject<Weather>(File.ReadAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Weather.json")));
        }
    }
}
