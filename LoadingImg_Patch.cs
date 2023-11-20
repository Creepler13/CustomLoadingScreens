using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Assets.Scripts.Database;
using rail;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts.PeroTools.Managers;
using Il2CppSystem.IO;

namespace CustomLoadingScreens
{


    [HarmonyPatch(typeof(LoadingImg), "OnEnable")]

    internal static class LoadingImg_Patch

    {
        public static ImageRegistry reg { get; set; }
        private static System.Random rand = new System.Random();

        public static void Postfix(ref LoadingImg __instance)
        {


            if (!Settings.onlyCustomImages)
                if (rand.NextDouble() > Settings.customImageProbability) return;

            string imageKey = reg.textData.Keys.ElementAt(rand.Next(reg.textData.Keys.Count));
            MelonLoader.MelonLogger.Msg("adsd");

            if (reg.textData.Count > 0)
            {
                TextureData dat = reg.textData[imageKey];

                Texture2D tempText = new Texture2D(dat.width, dat.height, TextureFormat.ARGB32, false);
                tempText.LoadRawTextureData(dat.rawData);
                tempText.Apply();
                Sprite temp = Sprite.Create(tempText, new Rect(0, 0, tempText.width, tempText.height), Vector2.zero);

                __instance.simpleIllus.active = false;
                __instance.specialIllus.active = false;
                __instance.verySpecialIllus.active = false;
                __instance.specialIllusfor43.active = false;

                Il2CppArrayBase<Image> components = __instance.simpleIllus.GetComponents<Image>();
                Il2CppArrayBase<Image> components43 = __instance.specialIllusfor43.GetComponents<Image>();

                if (is43(tempText.width, tempText.height))
                {
                    __instance.specialIllusfor43.active = true;

                    components = __instance.specialIllusfor43.GetComponents<Image>();

                }
                else
                {
                    __instance.simpleIllus.active = true;
                    components = __instance.simpleIllus.GetComponents<Image>();
                }

                foreach (Image c in components)
                {

                    c.sprite = temp;
                }
            }
            MelonLoader.MelonLogger.Msg("adsd");
            foreach (Text Text in __instance.GetComponentsInChildren<Text>())
            {
                MelonLoader.MelonLogger.Msg("adsd");
                if (Settings.useCustomText)
                    if (Settings.customText.ContainsKey(imageKey))
                        if (Settings.customText[imageKey] != "")
                            Text.m_Text = Settings.customText[imageKey];
                        else if (Settings.useRandomText && Settings.randomText.Length != 0) Text.m_Text = Settings.randomText[rand.Next(Settings.randomText.Length)];

            }



        }

        public static bool is43(int x, int y)
        {
            return ((double)(x % y) / y) <= 1.7;
        }

    }




}
