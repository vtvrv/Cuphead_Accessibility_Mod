using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace CupheadQOL
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static public ConfigEntry<bool> disableHUD;
        static public ConfigEntry<bool> disableGrain;
        static public ConfigEntry<bool> hideLevelIntroAnim;
        //static public ConfigEntry<bool> launchToTitleScreen;  //Game forgets controller setting on Cuphead 1.3.2. Never worked on Cuphead 1.0
        static public ConfigEntry<bool> disableScreenShake;
        static public ConfigEntry<bool> disableHitFlash;
        static public ConfigEntry<bool> disableBossExplosions;
        static public ConfigEntry<bool> accessLevelSelect;
        static public ConfigEntry<bool> displayHealthbar;
        //static public ConfigEntry<bool> disableAudioWarble;	//change not noticable. may cause problems.
        static public ConfigEntry<bool> photosensitiveBossFix_Dragon;
        static public ConfigEntry<bool> photosensitiveBossFix_Bee;

        public GUIStyle textureStyle;

        public static Rect healthBarBackgroundPos;

        private void Awake()
        {
            disableHUD = Config.Bind("Toggles", "Disable HUD", false);
            disableGrain = Config.Bind("Toggles", "Disable Film Grain Effects", true);
            hideLevelIntroAnim = Config.Bind("Toggles", "Hide Level Intro Animation", true);
            //launchToTitleScreen = Config.Bind("Toggles", "Launch to Title Screen", false);
            disableScreenShake = Config.Bind("Toggles", "Disable Screen Shake", true);
            disableHitFlash = Config.Bind("Toggles", "Disable Hit Flash", true);
            disableBossExplosions = Config.Bind("Toggles", "Disable Boss Explosion Effects", true);
            accessLevelSelect = Config.Bind("Toggles", "Access Level Select", true, "Backspace key opens level select");
            displayHealthbar = Config.Bind("Toggles", "Display Healthbar", true);
            //disableAudioWarble = Config.Bind("Toggles", "Disable Audio Warble", false);

            photosensitiveBossFix_Bee = Config.Bind("Toggles", "Photosensitive Boss Fix - Bee", true);
            photosensitiveBossFix_Dragon = Config.Bind("Toggles", "Photosensitive Boss Fix - Dragon", true);
            //PlayerDebug.Enable();

            UpdateHealthBarDimensions(Screen.width, Screen.height);

            Texture2D backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, Color.white);
            backgroundTexture.Apply();

            textureStyle = new GUIStyle();
            textureStyle.normal.background = backgroundTexture;
        }

        public void DrawRect(Rect position, Color color)
        {
            GUI.backgroundColor = color;
            GUI.Box(position, GUIContent.none, textureStyle);
        }

        public static void UpdateHealthBarDimensions(int w, int h) //parameters should always be screen.width and screen.height
        {
            float healthBarWidth = w * 0.25f;
            float healthBarHeight = h * 0.05f;
            healthBarBackgroundPos = new Rect((w - healthBarWidth) / 2f, healthBarHeight, healthBarWidth, healthBarHeight);
        }

        public void ApplyHooks()
        {
            if (disableBossExplosions.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableBossExplosionsHook));
            if (disableGrain.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableGrainHook));
            if (disableHitFlash.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableHitFlashHook));
            if (disableHUD.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableHUDHook));
            if (disableScreenShake.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableScreenShakeHook));
            if (hideLevelIntroAnim.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.HideLevelIntroAnimHook));
            //if (launchToTitleScreen.Value)
            //    Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.LauchToTileHook));
            if (displayHealthbar.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.HealthBarHookcs));
            //if(disableAudioWarble.Value)
            //    Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.DisableAudioWarbleHook));

            if (photosensitiveBossFix_Bee.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.BossFixes.Bee));
            if (photosensitiveBossFix_Dragon.Value)
                Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.BossFixes.Dragon));


            Harmony.CreateAndPatchAll(typeof(CupheadQOL.Hooks.MuteAnnouncer));
        }

        private void Update()
        {
            if (accessLevelSelect.Value & Input.GetKeyDown(KeyCode.Home))
                SceneManager.LoadScene("scene_menu");

            //Reload patches
            //if (Input.GetKeyDown(KeyCode.PageUp))
            //{
            //        Harmony.UnpatchAll();
            //        ApplyHooks();
            //}

            //Reload levels on top of each other for fun.
            //int k = 0;
            //if (Input.GetKeyDown(KeyCode.End))
            //{
            //    k = SceneManager.sceneCountInBuildSettings;
            //    System.Random ran = new System.Random();
            //    int num = ran.Next(0, k);
            //    SceneManager.LoadScene(Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(num)), LoadSceneMode.Additive);
            //}

        }

        private void Config_SettingChanged(object sender, SettingChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        internal void Main()
        {
            ApplyHooks();
        }

        internal void OnGUI()
        {
            if(displayHealthbar.Value & Level.Current != null)
                if (Level.Current.LevelType == Level.Type.Battle)
                {
                    DrawRect(healthBarBackgroundPos, Color.black);
                    Rect currentHealthPos = healthBarBackgroundPos;
                    currentHealthPos.width *= 1f - (Level.Current.timeline.damage / Level.Current.timeline.health);
                    DrawRect(currentHealthPos, Color.red);
                }
        }
    }
}