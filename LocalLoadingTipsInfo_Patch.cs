using Assets.Scripts.Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace CustomLoadingScreens
{
    [HarmonyPatch(typeof(LoadingTxt), MethodType.Constructor)]
    internal class LocalLoadingTipsInfo_Patch
    {

        public static List<LoadingTxt> LoadingTxt = new List<LoadingTxt>();
        private static System.Random rand = new System.Random();

        public static void Postfix(ref LoadingTxt __instance)
        {

            LoadingTxt.Add(__instance);
           
            /*  return;
            MelonLoader.MelonLogger.Msg("Start");
            if (__instance.m_Txt == null) return;
            MelonLoader.MelonLogger.Msg(__instance.m_Txt.text);
            if (Settings.customText.Length == 0) return;
            __instance.m_Txt.text = Settings.customText[rand.Next(Settings.customText.Length)];
        */
        }


    }
}
