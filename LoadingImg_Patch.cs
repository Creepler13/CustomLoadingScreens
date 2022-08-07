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

namespace CustomLoadingScreens
{


    [HarmonyPatch(typeof(LoadingImg), "OnEnable")]

    internal static class LoadingImg_Patch

    {
        public static ImageRegistry reg { get; set; }
        private static System.Random rand = new System.Random();

        public static void Postfix(ref LoadingImg __instance)
        {


            MelonLoader.MelonLogger.Msg(Settings.onlyCustomImages);
            if (!Settings.onlyCustomImages)
                if (rand.NextDouble() > Settings.customImageProbability) return;

            TextureData dat = reg.textData[rand.Next(reg.textData.Count)];

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






        public static bool is43(int x, int y)
        {
            return ((double)(x % y) / y) <= 1.7;
        }

    }

    [HarmonyPatch(typeof(LoadingTxt), "Start")]
    internal class LoadingTxt_Patch
    {
        private static System.Random rand = new System.Random();

        public static void Postfix(ref LoadingTxt __instance)
        {
            MelonLoader.MelonLogger.Msg(Settings.customText.Length);
            MelonLoader.MelonLogger.Msg(__instance.m_Txt.text);
            if (Settings.customText.Length == 0) return;
            __instance.m_Txt.text = Settings.customText[rand.Next(Settings.customText.Length)];
        }

    }


}
