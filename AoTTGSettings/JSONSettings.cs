using System.Collections.Generic;
using Newtonsoft.Json;

namespace CSharpNexus
{
    //Ability.json
    public class Ability
    {
        [JsonProperty("BombColor")]
        public List<int> BombColor { get; set; }

        [JsonProperty("BombRadius")]
        public int BombRadius { get; set; }

        [JsonProperty("BombRange")]
        public int BombRange { get; set; }

        [JsonProperty("BombSpeed")]
        public int BombSpeed { get; set; }

        [JsonProperty("BombCooldown")]
        public int BombCooldown { get; set; }

        [JsonProperty("ShowBombColors")]
        public bool ShowBombColors { get; set; }

        [JsonProperty("UseOldEffect")]
        public bool UseOldEffect { get; set; }
    }

    //CustomSkins.json
    public class Human
    {
        [JsonProperty("GasEnabled")]
        public bool GasEnabled { get; set; }

        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<HumanSkinSet> Sets { get; set; }
    }
    public class HumanSkinSet
    {
        [JsonProperty("Hair")]
        public string Hair { get; set; }

        [JsonProperty("Eye")]
        public string Eye { get; set; }

        [JsonProperty("Glass")]
        public string Glass { get; set; }

        [JsonProperty("Face")]
        public string Face { get; set; }

        [JsonProperty("Skin")]
        public string Skin { get; set; }

        [JsonProperty("Costume")]
        public string Costume { get; set; }

        [JsonProperty("Logo")]
        public string Logo { get; set; }

        [JsonProperty("GearL")]
        public string GearL { get; set; }

        [JsonProperty("GearR")]
        public string GearR { get; set; }

        [JsonProperty("Gas")]
        public string Gas { get; set; }

        [JsonProperty("Hoodie")]
        public string Hoodie { get; set; }

        [JsonProperty("WeaponTrail")]
        public string WeaponTrail { get; set; }

        [JsonProperty("Horse")]
        public string Horse { get; set; }

        [JsonProperty("ThunderSpearL")]
        public string ThunderSpearL { get; set; }

        [JsonProperty("ThunderSpearR")]
        public string ThunderSpearR { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class Titan
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<TitanSkinSet> Sets { get; set; }
    }
    public class TitanSkinSet
    {
        [JsonProperty("RandomizedPairs")]
        public bool RandomizedPairs { get; set; }

        [JsonProperty("Hairs")]
        public List<string> Hairs { get; set; }

        [JsonProperty("HairModels")]
        public List<int> HairModels { get; set; }

        [JsonProperty("Bodies")]
        public List<string> Bodies { get; set; }

        [JsonProperty("Eyes")]
        public List<string> Eyes { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class Shifter
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<ShifterSkinSet> Sets { get; set; }
    }
    public class ShifterSkinSet
    {
        [JsonProperty("Eren")]
        public string Eren { get; set; }

        [JsonProperty("Annie")]
        public string Annie { get; set; }

        [JsonProperty("Colossal")]
        public string Colossal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class Skybox
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<SkyBoxSkinSet> Sets { get; set; }
    }
    public class SkyBoxSkinSet
    {
        [JsonProperty("Front")]
        public string Front { get; set; }

        [JsonProperty("Back")]
        public string Back { get; set; }

        [JsonProperty("Left")]
        public string Left { get; set; }

        [JsonProperty("Right")]
        public string Right { get; set; }

        [JsonProperty("Up")]
        public string Up { get; set; }

        [JsonProperty("Down")]
        public string Down { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class Forest
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<ForestSkinSet> Sets { get; set; }
    }
    public class ForestSkinSet
    {
        [JsonProperty("RandomizedPairs")]
        public bool RandomizedPairs { get; set; }

        [JsonProperty("TreeTrunks")]
        public List<string> TreeTrunks { get; set; }

        [JsonProperty("TreeLeafs")]
        public List<string> TreeLeafs { get; set; }

        [JsonProperty("Ground")]
        public string Ground { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class City
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<CitySkinSet> Sets { get; set; }
    }
    public class CitySkinSet
    {
        [JsonProperty("Houses")]
        public List<string> Houses { get; set; }

        [JsonProperty("Ground")]
        public string Ground { get; set; }

        [JsonProperty("Wall")]
        public string Wall { get; set; }

        [JsonProperty("Gate")]
        public string Gate { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class CustomLevel
    {
        [JsonProperty("SkinsLocal")]
        public bool SkinsLocal { get; set; }

        [JsonProperty("SkinsEnabled")]
        public bool SkinsEnabled { get; set; }

        [JsonProperty("SkinSets")]
        public List<object> SkinSets { get; set; }

        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<CustomLevelSkinSet> Sets { get; set; }
    }
    public class CustomLevelSkinSet
    {
        [JsonProperty("Ground")]
        public string Ground { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class CustomSkins
    {
        [JsonProperty("Human")]
        public Human Human { get; set; }

        [JsonProperty("Titan")]
        public Titan Titan { get; set; }

        [JsonProperty("Shifter")]
        public Shifter Shifter { get; set; }

        [JsonProperty("Skybox")]
        public Skybox Skybox { get; set; }

        [JsonProperty("Forest")]
        public Forest Forest { get; set; }

        [JsonProperty("City")]
        public City City { get; set; }

        [JsonProperty("CustomLevel")]
        public CustomLevel CustomLevel { get; set; }
    }

    //General.json
    public class General
    {
        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Volume")]
        public double Volume { get; set; }

        [JsonProperty("MouseSpeed")]
        public double MouseSpeed { get; set; }

        [JsonProperty("CameraDistance")]
        public double CameraDistance { get; set; }

        [JsonProperty("InvertMouse")]
        public bool InvertMouse { get; set; }

        [JsonProperty("CameraTilt")]
        public bool CameraTilt { get; set; }

        [JsonProperty("SnapshotsEnabled")]
        public bool SnapshotsEnabled { get; set; }

        [JsonProperty("SnapshotsShowInGame")]
        public bool SnapshotsShowInGame { get; set; }

        [JsonProperty("SnapshotsMinimumDamage")]
        public int SnapshotsMinimumDamage { get; set; }

        [JsonProperty("MinimapEnabled")]
        public bool MinimapEnabled { get; set; }
    }

    //Graphics.json
    public class Graphics
    {
        [JsonProperty("OverallQuality")]
        public int OverallQuality { get; set; }

        [JsonProperty("TextureQuality")]
        public int TextureQuality { get; set; }

        [JsonProperty("VSync")]
        public bool VSync { get; set; }

        [JsonProperty("FPSCap")]
        public int FPSCap { get; set; }

        [JsonProperty("ExclusiveFullscreen")]
        public bool ExclusiveFullscreen { get; set; }

        [JsonProperty("ShowFPS")]
        public bool ShowFPS { get; set; }

        [JsonProperty("MipmapEnabled")]
        public bool MipmapEnabled { get; set; }

        [JsonProperty("WeaponTrailEnabled")]
        public bool WeaponTrailEnabled { get; set; }

        [JsonProperty("WindEffectEnabled")]
        public bool WindEffectEnabled { get; set; }

        [JsonProperty("InterpolationEnabled")]
        public bool InterpolationEnabled { get; set; }

        [JsonProperty("RenderDistance")]
        public int RenderDistance { get; set; }

        [JsonProperty("WeatherEffects")]
        public int WeatherEffects { get; set; }

        [JsonProperty("AnimatedIntro")]
        public bool AnimatedIntro { get; set; }

        [JsonProperty("BlurEnabled")]
        public bool BlurEnabled { get; set; }

        [JsonProperty("AntiAliasing")]
        public int AntiAliasing { get; set; }
    }

    //Input.json
    public class GeneralInput
    {
        [JsonProperty("Forward")]
        public List<string> Forward { get; set; }

        [JsonProperty("Back")]
        public List<string> Back { get; set; }

        [JsonProperty("Left")]
        public List<string> Left { get; set; }

        [JsonProperty("Right")]
        public List<string> Right { get; set; }

        [JsonProperty("Pause")]
        public List<string> Pause { get; set; }

        [JsonProperty("Restart")]
        public List<string> Restart { get; set; }

        [JsonProperty("Chat")]
        public List<string> Chat { get; set; }

        [JsonProperty("ToggleFullscreen")]
        public List<string> ToggleFullscreen { get; set; }

        [JsonProperty("ChangeCamera")]
        public List<string> ChangeCamera { get; set; }

        [JsonProperty("HideUI")]
        public List<string> HideUI { get; set; }

        [JsonProperty("MinimapReset")]
        public List<string> MinimapReset { get; set; }

        [JsonProperty("MinimapToggle")]
        public List<string> MinimapToggle { get; set; }

        [JsonProperty("MinimapMaximize")]
        public List<string> MinimapMaximize { get; set; }

        [JsonProperty("JoinGame")]
        public List<string> JoinGame { get; set; }

        [JsonProperty("SpectateToggleLive")]
        public List<string> SpectateToggleLive { get; set; }

        [JsonProperty("SpectateToggleFreeCamera")]
        public List<string> SpectateToggleFreeCamera { get; set; }

        [JsonProperty("SpectatePreviousPlayer")]
        public List<string> SpectatePreviousPlayer { get; set; }

        [JsonProperty("SpectateNextPlayer")]
        public List<string> SpectateNextPlayer { get; set; }
    }
    public class HumanInput
    {
        [JsonProperty("AttackDefault")]
        public List<string> AttackDefault { get; set; }

        [JsonProperty("AttackSpecial")]
        public List<string> AttackSpecial { get; set; }

        [JsonProperty("HookLeft")]
        public List<string> HookLeft { get; set; }

        [JsonProperty("HookRight")]
        public List<string> HookRight { get; set; }

        [JsonProperty("HookBoth")]
        public List<string> HookBoth { get; set; }

        [JsonProperty("Dash")]
        public List<string> Dash { get; set; }

        [JsonProperty("ReelIn")]
        public List<string> ReelIn { get; set; }

        [JsonProperty("ReelOut")]
        public List<string> ReelOut { get; set; }

        [JsonProperty("Dodge")]
        public List<string> Dodge { get; set; }

        [JsonProperty("FocusTitan")]
        public List<string> FocusTitan { get; set; }

        [JsonProperty("Jump")]
        public List<string> Jump { get; set; }

        [JsonProperty("Reload")]
        public List<string> Reload { get; set; }

        [JsonProperty("HorseMount")]
        public List<string> HorseMount { get; set; }

        [JsonProperty("HorseWalk")]
        public List<string> HorseWalk { get; set; }

        [JsonProperty("HorseJump")]
        public List<string> HorseJump { get; set; }

        [JsonProperty("Flare1")]
        public List<string> Flare1 { get; set; }

        [JsonProperty("Flare2")]
        public List<string> Flare2 { get; set; }

        [JsonProperty("Flare3")]
        public List<string> Flare3 { get; set; }

        [JsonProperty("DashDoubleTap")]
        public bool DashDoubleTap { get; set; }

        [JsonProperty("ReelOutScrollSmoothing")]
        public double ReelOutScrollSmoothing { get; set; }
    }
    public class TitanInput
    {
        [JsonProperty("AttackPunch")]
        public List<string> AttackPunch { get; set; }

        [JsonProperty("AttackSlam")]
        public List<string> AttackSlam { get; set; }

        [JsonProperty("AttackSlap")]
        public List<string> AttackSlap { get; set; }

        [JsonProperty("AttackGrabFront")]
        public List<string> AttackGrabFront { get; set; }

        [JsonProperty("AttackGrabBack")]
        public List<string> AttackGrabBack { get; set; }

        [JsonProperty("AttackGrabNape")]
        public List<string> AttackGrabNape { get; set; }

        [JsonProperty("AttackBite")]
        public List<string> AttackBite { get; set; }

        [JsonProperty("CoverNape")]
        public List<string> CoverNape { get; set; }

        [JsonProperty("Jump")]
        public List<string> Jump { get; set; }

        [JsonProperty("Sit")]
        public List<string> Sit { get; set; }

        [JsonProperty("Walk")]
        public List<string> Walk { get; set; }
    }
    public class ShifterInput
    {
        [JsonProperty("AttackDefault")]
        public List<string> AttackDefault { get; set; }

        [JsonProperty("AttackSpecial")]
        public List<string> AttackSpecial { get; set; }

        [JsonProperty("CoverNape")]
        public List<string> CoverNape { get; set; }

        [JsonProperty("Jump")]
        public List<string> Jump { get; set; }

        [JsonProperty("Sit")]
        public List<string> Sit { get; set; }

        [JsonProperty("Walk")]
        public List<string> Walk { get; set; }

        [JsonProperty("Roar")]
        public List<string> Roar { get; set; }
    }
    public class Interaction
    {
        [JsonProperty("Interact")]
        public List<string> Interact { get; set; }

        [JsonProperty("CannonSlow")]
        public List<string> CannonSlow { get; set; }

        [JsonProperty("CannonFire")]
        public List<string> CannonFire { get; set; }

        [JsonProperty("EmoteMenu")]
        public List<string> EmoteMenu { get; set; }

        [JsonProperty("MenuNext")]
        public List<string> MenuNext { get; set; }

        [JsonProperty("QuickSelect1")]
        public List<string> QuickSelect1 { get; set; }

        [JsonProperty("QuickSelect2")]
        public List<string> QuickSelect2 { get; set; }

        [JsonProperty("QuickSelect3")]
        public List<string> QuickSelect3 { get; set; }

        [JsonProperty("QuickSelect4")]
        public List<string> QuickSelect4 { get; set; }

        [JsonProperty("QuickSelect5")]
        public List<string> QuickSelect5 { get; set; }

        [JsonProperty("QuickSelect6")]
        public List<string> QuickSelect6 { get; set; }

        [JsonProperty("QuickSelect7")]
        public List<string> QuickSelect7 { get; set; }

        [JsonProperty("QuickSelect8")]
        public List<string> QuickSelect8 { get; set; }
    }
    public class RCEditor
    {
        [JsonProperty("Up")]
        public List<string> Up { get; set; }

        [JsonProperty("Down")]
        public List<string> Down { get; set; }

        [JsonProperty("Slow")]
        public List<string> Slow { get; set; }

        [JsonProperty("Fast")]
        public List<string> Fast { get; set; }

        [JsonProperty("RotateRight")]
        public List<string> RotateRight { get; set; }

        [JsonProperty("RotateLeft")]
        public List<string> RotateLeft { get; set; }

        [JsonProperty("RotateCCW")]
        public List<string> RotateCCW { get; set; }

        [JsonProperty("RotateCW")]
        public List<string> RotateCW { get; set; }

        [JsonProperty("RotateBack")]
        public List<string> RotateBack { get; set; }

        [JsonProperty("RotateForward")]
        public List<string> RotateForward { get; set; }

        [JsonProperty("Place")]
        public List<string> Place { get; set; }

        [JsonProperty("Delete")]
        public List<string> Delete { get; set; }

        [JsonProperty("Cursor")]
        public List<string> Cursor { get; set; }
    }
    public class Input
    {
        [JsonProperty("General")]
        public GeneralInput General { get; set; }

        [JsonProperty("Human")]
        public HumanInput Human { get; set; }

        [JsonProperty("Titan")]
        public TitanInput Titan { get; set; }

        [JsonProperty("Shifter")]
        public ShifterInput Shifter { get; set; }

        [JsonProperty("Interaction")]
        public Interaction Interaction { get; set; }

        [JsonProperty("RCEditor")]
        public RCEditor RCEditor { get; set; }
    }

    //LegacyGameSettings.json
    public class LegacyGameSettings
    {
        [JsonProperty("TitanSpawnCap")]
        public int TitanSpawnCap { get; set; }

        [JsonProperty("GameType")]
        public int GameType { get; set; }

        [JsonProperty("LevelScript")]
        public string LevelScript { get; set; }

        [JsonProperty("LogicScript")]
        public string LogicScript { get; set; }

        [JsonProperty("TitanNumberEnabled")]
        public bool TitanNumberEnabled { get; set; }

        [JsonProperty("TitanNumber")]
        public int TitanNumber { get; set; }

        [JsonProperty("TitanSpawnEnabled")]
        public bool TitanSpawnEnabled { get; set; }

        [JsonProperty("TitanSpawnNormal")]
        public int TitanSpawnNormal { get; set; }

        [JsonProperty("TitanSpawnAberrant")]
        public int TitanSpawnAberrant { get; set; }

        [JsonProperty("TitanSpawnJumper")]
        public int TitanSpawnJumper { get; set; }

        [JsonProperty("TitanSpawnCrawler")]
        public int TitanSpawnCrawler { get; set; }

        [JsonProperty("TitanSpawnPunk")]
        public int TitanSpawnPunk { get; set; }

        [JsonProperty("TitanSizeEnabled")]
        public bool TitanSizeEnabled { get; set; }

        [JsonProperty("TitanSizeMin")]
        public int TitanSizeMin { get; set; }

        [JsonProperty("TitanSizeMax")]
        public int TitanSizeMax { get; set; }

        [JsonProperty("TitanHealthMode")]
        public int TitanHealthMode { get; set; }

        [JsonProperty("TitanHealthMin")]
        public int TitanHealthMin { get; set; }

        [JsonProperty("TitanHealthMax")]
        public int TitanHealthMax { get; set; }

        [JsonProperty("TitanArmorEnabled")]
        public bool TitanArmorEnabled { get; set; }

        [JsonProperty("TitanArmorCrawlerEnabled")]
        public bool TitanArmorCrawlerEnabled { get; set; }

        [JsonProperty("TitanArmor")]
        public int TitanArmor { get; set; }

        [JsonProperty("TitanExplodeEnabled")]
        public bool TitanExplodeEnabled { get; set; }

        [JsonProperty("TitanExplodeRadius")]
        public int TitanExplodeRadius { get; set; }

        [JsonProperty("RockThrowEnabled")]
        public bool RockThrowEnabled { get; set; }

        [JsonProperty("PointModeEnabled")]
        public bool PointModeEnabled { get; set; }

        [JsonProperty("PointModeAmount")]
        public int PointModeAmount { get; set; }

        [JsonProperty("BombModeEnabled")]
        public bool BombModeEnabled { get; set; }

        [JsonProperty("TeamMode")]
        public int TeamMode { get; set; }

        [JsonProperty("InfectionModeEnabled")]
        public bool InfectionModeEnabled { get; set; }

        [JsonProperty("InfectionModeAmount")]
        public int InfectionModeAmount { get; set; }

        [JsonProperty("FriendlyMode")]
        public bool FriendlyMode { get; set; }

        [JsonProperty("BladePVP")]
        public int BladePVP { get; set; }

        [JsonProperty("AHSSAirReload")]
        public bool AHSSAirReload { get; set; }

        [JsonProperty("CannonsFriendlyFire")]
        public bool CannonsFriendlyFire { get; set; }

        [JsonProperty("TitanPerWavesEnabled")]
        public bool TitanPerWavesEnabled { get; set; }

        [JsonProperty("TitanPerWaves")]
        public int TitanPerWaves { get; set; }

        [JsonProperty("TitanMaxWavesEnabled")]
        public bool TitanMaxWavesEnabled { get; set; }

        [JsonProperty("TitanMaxWaves")]
        public int TitanMaxWaves { get; set; }

        [JsonProperty("PunksEveryFive")]
        public bool PunksEveryFive { get; set; }

        [JsonProperty("GlobalMinimapDisable")]
        public bool GlobalMinimapDisable { get; set; }

        [JsonProperty("PreserveKDR")]
        public bool PreserveKDR { get; set; }

        [JsonProperty("RacingEndless")]
        public bool RacingEndless { get; set; }

        [JsonProperty("EndlessRespawnEnabled")]
        public bool EndlessRespawnEnabled { get; set; }

        [JsonProperty("EndlessRespawnTime")]
        public int EndlessRespawnTime { get; set; }

        [JsonProperty("KickShifters")]
        public bool KickShifters { get; set; }

        [JsonProperty("AllowHorses")]
        public bool AllowHorses { get; set; }

        [JsonProperty("Motd")]
        public string Motd { get; set; }
    }

    //Profile.json
    public class Profile
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Guild")]
        public string Guild { get; set; }
    }

    //UI.json
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class UI
    {
        [JsonProperty("Theme")]
        public string Theme { get; set; }

        [JsonProperty("GameFeed")]
        public bool GameFeed { get; set; }

        [JsonProperty("UIMasterScale")]
        public int UIMasterScale { get; set; }

        [JsonProperty("CrosshairScale")]
        public double CrosshairScale { get; set; }

        [JsonProperty("ShowCrosshairArrows")]
        public bool ShowCrosshairArrows { get; set; }

        [JsonProperty("ShowCrosshairDistance")]
        public bool ShowCrosshairDistance { get; set; }

        [JsonProperty("CrosshairStyle")]
        public int CrosshairStyle { get; set; }

        [JsonProperty("Speedometer")]
        public int Speedometer { get; set; }

        [JsonProperty("ShowInterpolation")]
        public bool ShowInterpolation { get; set; }

        [JsonProperty("ShowEmotes")]
        public bool ShowEmotes { get; set; }

        [JsonProperty("ChatLines")]
        public int ChatLines { get; set; }

        [JsonProperty("ChatWidth")]
        public int ChatWidth { get; set; }

        [JsonProperty("ChatHeight")]
        public int ChatHeight { get; set; }
    }

    //Weather
    public class WeatherSet
    {
        [JsonProperty("Skybox")]
        public string Skybox { get; set; }

        [JsonProperty("SkyboxColor")]
        public List<double> SkyboxColor { get; set; }

        [JsonProperty("Daylight")]
        public List<double> Daylight { get; set; }

        [JsonProperty("AmbientLight")]
        public List<double> AmbientLight { get; set; }

        [JsonProperty("Flashlight")]
        public List<double> Flashlight { get; set; }

        [JsonProperty("FogDensity")]
        public double FogDensity { get; set; }

        [JsonProperty("FogColor")]
        public List<double> FogColor { get; set; }

        [JsonProperty("Rain")]
        public int Rain { get; set; }

        [JsonProperty("Thunder")]
        public int Thunder { get; set; }

        [JsonProperty("Snow")]
        public int Snow { get; set; }

        [JsonProperty("Wind")]
        public int Wind { get; set; }

        [JsonProperty("UseSchedule")]
        public bool UseSchedule { get; set; }

        [JsonProperty("ScheduleLoop")]
        public bool ScheduleLoop { get; set; }

        [JsonProperty("Schedule")]
        public string Schedule { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Preset")]
        public bool Preset { get; set; }
    }
    public class WeatherSets
    {
        [JsonProperty("SelectedSetIndex")]
        public int SelectedSetIndex { get; set; }

        [JsonProperty("Sets")]
        public List<WeatherSet> Sets { get; set; }
    }
    public class Weather
    {
        [JsonProperty("WeatherSets")]
        public WeatherSets WeatherSets { get; set; }
    }


}