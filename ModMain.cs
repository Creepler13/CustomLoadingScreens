using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLoadingScreens.CustomBackgrounds;
using MelonLoader;

namespace CustomLoadingScreens
{
    public class ModMain : MelonMod
    {

        public static string CustomLoadingScreenPath = "CustomLoadingScreens";
        public static string CustomBackgroundsPath = "UserData/CustomBackgrounds";

        public override void OnApplicationStart()
        {
            Settings.load();
            ImageRegistry reg = new ImageRegistry();
            LoadingImg_Patch.reg = reg;
            LoadingImg_Patch.reg.load(CustomLoadingScreenPath);

            ChangeableTexture.registry = new ImageRegistry();
            ChangeableTexture.registry.load(CustomBackgroundsPath);
        }

    }
}
