using Assets.Scripts.GameCore;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CustomLoadingScreens.CustomBackgrounds
{
    [HarmonyPatch(typeof(GameInit), "OnEnable")]
    internal class HomeScreenPatch
    {

        public static ChangeableTexture homeScreenBackground = new ChangeableTexture();
        public static ChangeableTexture homeScreenLeftBackground = new ChangeableTexture();
        public static ChangeableTexture homeScreenRightBackground = new ChangeableTexture();

        public static void Postfix(GameInit __instance)
        {
            UnityEngine.Transform bg = __instance.gameObject.transform.Find("Standerd").Find("PnlHome").Find("Bg");

            Image i = bg.Find("ImgBlack").gameObject.GetComponent<Image>();
            if (homeScreenBackground.enabled())
            {
                i.transform.localScale = new Vector3(1, 1, 1);
            }

            homeScreenBackground.setImage(i);

            homeScreenRightBackground.setImage(bg.Find("Right").Find("ImgBaffle").gameObject.GetComponent<Image>());
            homeScreenLeftBackground.setImage(bg.Find("Left").Find("ImgBaffle").gameObject.GetComponent<Image>());

            bg.Find("Particle").gameObject.SetActive(!homeScreenBackground.disablebleObjects["Particle"].Value);
            bg.Find("ParPetal").gameObject.SetActive(!homeScreenBackground.disablebleObjects["ParPetal"].Value);
            bg.Find("Right").gameObject.SetActive(!homeScreenBackground.disablebleObjects["Right"].Value);
            bg.Find("Left").gameObject.SetActive(!homeScreenBackground.disablebleObjects["Left"].Value);
            bg.Find("Right").Find("ImgCircuit").gameObject.SetActive(!homeScreenBackground.disablebleObjects["Right_ImgCircuit"].Value);
            bg.Find("Left").Find("ImgCircuit").gameObject.SetActive(!homeScreenBackground.disablebleObjects["Left_ImgCircuit"].Value);

        }


    }
}
