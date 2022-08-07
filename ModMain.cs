using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;


namespace CustomLoadingScreens
{
    public class ModMain : MelonMod
    {

        public override void OnApplicationStart()
        {
            Settings.load();
            ImageRegistry reg = new ImageRegistry();
            LoadingImg_Patch.reg = reg;
            LoadingImg_Patch.reg.load();
        }

    }
}
