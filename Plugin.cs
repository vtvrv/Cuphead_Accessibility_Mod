using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace Cuphead_Accessibility
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        static public ConfigEntry<bool> disableHUD;
        static public ConfigEntry<bool> disableGrain;
        static public ConfigEntry<bool> hideLevelIntroAnim;
        static public ConfigEntry<bool> disableScreenShake;
        static public ConfigEntry<bool> disableHitFlash;
        static public ConfigEntry<bool> disableBossExplosions;
        static public ConfigEntry<bool> accessLevelSelect;
        static public ConfigEntry<bool> displayHealthbar;
        static public ConfigEntry<bool> drawExtraHealthbarInfo;
        static public ConfigEntry<bool> muteAnnouncer;
        static public ConfigEntry<bool> photosensitiveBossFix_Dragon;
        static public ConfigEntry<bool> photosensitiveBossFix_Bee;
        static public ConfigEntry<bool> photosensitiveBossFix_FlyingHorse;
        //static public ConfigEntry<bool> launchToTitleScreen;  //Game forgets controller setting on Cuphead 1.3.2. Never worked on Cuphead 1.0
        //static public ConfigEntry<bool> disableAudioWarble;	//Change not noticable. May cause problems.

        public GUIStyle textureStyle;
        public GUIStyle fontStyle;

        public static Rect healthBarBackgroundPos;
        public static Rect healthBarTextPos;

        private void Awake()
        {
            disableHUD = Config.Bind("Toggles", "Disable HUD", false);
            disableGrain = Config.Bind("Toggles", "Disable Film Grain Effects", true);
            hideLevelIntroAnim = Config.Bind("Toggles", "Hide Level Intro Animation", true);
            disableScreenShake = Config.Bind("Toggles", "Disable Screen Shake", true);
            disableHitFlash = Config.Bind("Toggles", "Disable Hit Flash", true);
            disableBossExplosions = Config.Bind("Toggles", "Disable Boss Explosion Effects", true);
            accessLevelSelect = Config.Bind("Toggles", "Access Level Select", true, "Backspace key opens level select");
            displayHealthbar = Config.Bind("Toggles", "Display Healthbar", true);
            drawExtraHealthbarInfo = Config.Bind("Toggles", "Draw Extra Healthbar Info", true);
            muteAnnouncer = Config.Bind("Toggles", "Mute Announcer Intro", false);
            photosensitiveBossFix_Bee = Config.Bind("Toggles", "Photosensitive Boss Fix - Bee", true);
            photosensitiveBossFix_Dragon = Config.Bind("Toggles", "Photosensitive Boss Fix - Dragon", true);
            photosensitiveBossFix_FlyingHorse = Config.Bind("Toggles", "Photosensitive Boss Fix - Flying Horse", true);
            //launchToTitleScreen = Config.Bind("Toggles", "Launch to Title Screen", false);
            //disableAudioWarble = Config.Bind("Toggles", "Disable Audio Warble", false);

            UpdateHealthBarDimensions(Screen.width, Screen.height);

            Texture2D backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, Color.white);
            backgroundTexture.Apply();

            textureStyle = new GUIStyle();
            textureStyle.normal.background = backgroundTexture;

            //drawExtraHealthbarInfo text
            fontStyle = new GUIStyle();
            fontStyle.fontSize = 30;
            fontStyle.fontStyle = FontStyle.Bold;
            fontStyle.normal.textColor = Color.yellow;
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

            healthBarTextPos = healthBarBackgroundPos;
            healthBarTextPos.y += 11f; //center text,
            healthBarTextPos.x += 2f; 
        }

        public void ApplyHooks()
        {
            if (disableBossExplosions.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableBossExplosionsHook));
            if (disableGrain.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableGrainHook));
            if (disableHitFlash.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableHitFlashHook));
            if (disableHUD.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableHUDHook));
            if (disableScreenShake.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableScreenShakeHook));
            if (hideLevelIntroAnim.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.HideLevelIntroAnimHook));
            if (muteAnnouncer.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.MuteAnnouncer));
            if (displayHealthbar.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.HealthBarHookcs));
            if (photosensitiveBossFix_Bee.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.BossFixes.Bee));
            if (photosensitiveBossFix_Dragon.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.BossFixes.Dragon));
            if (photosensitiveBossFix_FlyingHorse.Value)
                Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.BossFixes.FlyingHorse));
            //if (launchToTitleScreen.Value)
            //    Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.LauchToTileHook));
            //if(disableAudioWarble.Value)
            //    Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DisableAudioWarbleHook));

            Harmony.CreateAndPatchAll(typeof(Cuphead_Accessibility.Hooks.DebugMenuFix));
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
                    
                    if(drawExtraHealthbarInfo.Value)
                    {
                        //draw phase markers on healthbar
                        foreach (var phase in Level.Current.timeline.events)
                        {
                            Rect eventRect = healthBarBackgroundPos;
                            eventRect.x += (healthBarBackgroundPos.width * phase.percentage);
                            eventRect.width = 3f;
                            DrawRect(eventRect, Color.white);
                        }

                        //draw current damage/health text
                        GUI.Label(healthBarTextPos, Level.Current.timeline.damage.ToString("0000") + "/" + Level.Current.timeline.health.ToString(), fontStyle);
                    }
                }
        }
    }
}