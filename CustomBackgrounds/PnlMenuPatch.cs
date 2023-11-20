using Assets.Scripts.GameCore;
using Assets.Scripts.PeroTools.Nice.Values;
using Assets.Scripts.UI.Panels;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace CustomLoadingScreens.CustomBackgrounds
{
    [HarmonyPatch(typeof(PnlMenu), "OnEnable")]
    internal class PnlMenuPatch
    {

        public static ChangeableTexture menuBackground = new ChangeableTexture();

        public static void Postfix(PnlMenu __instance)
        {
            Image im = __instance.gameObject.transform.Find("Bg").Find("ImgBackground").GetComponent<Image>();
            menuBackground.setImage(im);
        }


    }


}
