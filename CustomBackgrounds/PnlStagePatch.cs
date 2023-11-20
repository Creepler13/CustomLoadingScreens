using Assets.Scripts.GameCore;
using Assets.Scripts.UI.Panels;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Object = UnityEngine.Object;

namespace CustomLoadingScreens.CustomBackgrounds
{
    [HarmonyPatch(typeof(PnlStage), "OnEnable")]
    internal class PnlStagePatch
    {
        public static ChangeableTexture stageSelectBackground = new ChangeableTexture();

        public static void Postfix(PnlStage __instance)
        {

            Transform bgsRoot = __instance.gameObject.transform.Find("BgsRoot");
            GameObject o;
            if (bgsRoot.parent.Find("ImgBg(Clone)") == null)
            {
                o = Object.Instantiate(bgsRoot.Find("BgAlbumLock").Find("Bg").Find("ImgBg").gameObject, bgsRoot.parent);
                o.transform.SetSiblingIndex(1);
                o.GetComponent<RectTransform>().position = bgsRoot.transform.position;
                o.GetComponent<RectTransform>().localScale = bgsRoot.transform.localScale;
            }
            else
                o = bgsRoot.parent.transform.Find("ImgBg(Clone)").gameObject;
            stageSelectBackground.setImage(o.GetComponent<Image>());

            //          o.GetComponent<Image>().type = Image.Type.Simple;
            //         o.GetComponent<RectTransform>().offsetMin = new Vector2(-o.GetComponent<RectTransform>().offsetMin.x, -540);

        }


    }
}
