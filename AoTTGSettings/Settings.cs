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






        public void SaveGeneral()
        {
            Console.WriteLine("SaveGeneral");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\General.json"), JsonConvert.SerializeObject(General, Formatting.Indented));
        }
        public void SaveAbility()
        {
            Console.WriteLine("SaveAbility");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Ability.json"), JsonConvert.SerializeObject(Ability));
        }
        public void SaveCustomSkins()
        {
            Console.WriteLine("SaveCustomSkins");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\CustomSkins.json"), JsonConvert.SerializeObject(CustomSkins, Formatting.Indented));
        }
        public void SaveGraphics()
        {
            Console.WriteLine("SaveGraphics");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Graphics.json"), JsonConvert.SerializeObject(Graphics, Formatting.Indented));
        }
        public void SaveInput()
        {
            Console.WriteLine("SaveInput");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Input.json"), JsonConvert.SerializeObject(Input, Formatting.Indented));
        }
        public void SaveLegacyGameSettings()
        {
            Console.WriteLine("SaveLegacyGameSettings");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\LegacyGameSettings.json"), JsonConvert.SerializeObject(LegacyGameSettings, Formatting.Indented));
        }
        public void SaveProfile()
        {
            Console.WriteLine("SaveProfile");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Profile.json"), JsonConvert.SerializeObject(Profile, Formatting.Indented));
        }
        public void SaveUI()
        {
            Console.WriteLine("SaveUI");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\UI.json"), JsonConvert.SerializeObject(UI, Formatting.Indented));
        }
        public void SaveWeather()
        {
            Console.WriteLine("SaveWeather");
            File.WriteAllText(Path.Combine(AottgPath, "AottgRC_Data\\UserData\\Settings\\Weather.json"), JsonConvert.SerializeObject(Weather, Formatting.Indented));
        }
    }
}
