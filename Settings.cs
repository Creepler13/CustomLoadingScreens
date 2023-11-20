using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CustomLoadingScreens.CustomBackgrounds;
using MelonLoader;

namespace CustomLoadingScreens
{
    internal class Settings
    {

        public static MelonPreferences_Category category;

        private static MelonPreferences_Entry<bool> onlyCustomImagesEntry;
        private static MelonPreferences_Entry<double> customImageProbabilityEntry;
        private static MelonPreferences_Entry<bool> useRandomTextEntrys;
        private static MelonPreferences_Entry<string[]> randomTextEntry;
        private static MelonPreferences_Entry<bool> useCustomTextEntrys;
        private static MelonPreferences_Entry<Dictionary<string, string>> customTextEntries;



        public static bool onlyCustomImages
        {
            get
            {
                return onlyCustomImagesEntry.Value;
            }
            set
            {
                onlyCustomImagesEntry.Value = value;
            }
        }

        public static double customImageProbability
        {
            get
            {
                return customImageProbabilityEntry.Value;
            }
            set
            {
                customImageProbabilityEntry.Value = value;
            }
        }

        public static bool useCustomText
        {
            get
            {
                return useCustomTextEntrys.Value;
            }
            set
            {
                useCustomTextEntrys.Value = value;
            }
        }

        public static bool useRandomText
        {
            get
            {
                return useRandomTextEntrys.Value;
            }
            set
            {
                useRandomTextEntrys.Value = value;
            }
        }

        public static Dictionary<string, string> customText
        {
            get
            {
                return customTextEntries.Value;
            }
            set
            {
                customTextEntries.Value = value;
            }
        }

        public static string[] randomText
        {
            get
            {
                return randomTextEntry.Value;
            }
            set
            {
                randomTextEntry.Value = value;
            }
        }



        public static void load()
        {
            category = MelonPreferences.CreateCategory("CustomLoadingScreensSetttings");
            category.IsInlined = false;
            category.SetFilePath("Userdata/CustomLoadingScreens.cfg", true);
            onlyCustomImagesEntry = category.CreateEntry<bool>("onlyCustomImages", true, "onlyCustomImages", "Custom images will be Shown during loading screens");
            customImageProbabilityEntry = category.CreateEntry<double>("customImageProbability", 0, "customImageProbability", "only important if onlyCustomImages is false.\n Probabilty from 0-1 that decides the chance that a custom image is shown (0 = the same probability as default images)");
            useRandomTextEntrys = category.CreateEntry<bool>("useRandomTextEntrys", false, "userandomTextEntrys", "images will be shown together with random texts in the Array.");
            randomTextEntry = category.CreateEntry<string[]>("randomTextEntrys", new string[0], "randomTextEntrys", "custom text that will randomly be shown during the loading screen (Example : [\"A\",\"B\"])");
            useCustomTextEntrys = category.CreateEntry<bool>("useCustomTextEntrys", false, "useCustomTextEntrys", " custom images will be shown together with their set texts. (only if a value is set)");
            customTextEntries = category.CreateEntry<Dictionary<string, string>>("customText", new Dictionary<string, string>(), "customText");



            HomeScreenPatch.homeScreenBackground.addSubTexture(HomeScreenPatch.homeScreenLeftBackground, "Left");
            HomeScreenPatch.homeScreenBackground.addSubTexture(HomeScreenPatch.homeScreenRightBackground, "Right");
            addChangealbeTextureSetting(HomeScreenPatch.homeScreenBackground, "Home Menu", new string[] { "Particle", "ParPetal", "Left", "Right", "Left_ImgCircuit", "Right_ImgCircuit" });
            addChangealbeTextureSetting(PnlMenuPatch.menuBackground, "Menu Background", new string[] { });
            addChangealbeTextureSetting(PnlStagePatch.stageSelectBackground, "Stage Select Background", new string[] { });
        }

        public static void addChangealbeTextureSetting(ChangeableTexture cT, String name, string[] objectthataredisablelalale)
        {
            MelonPreferences_Category category = MelonPreferences.CreateCategory(name);
            category.IsInlined = true;
            category.SetFilePath("Userdata/CustomBackgrounds.cfg", true);

            cT.image = category.CreateEntry<string>("filename", "", "filename", "Will only replace Texture when an image name is given");
            foreach (ChangeableTexture text in cT.subTextures.Values)
            {
                text.image = category.CreateEntry<string>("filename_" + text.id, "");
            }

            foreach (string oname in objectthataredisablelalale)
            {
                if (oname == objectthataredisablelalale.First<string>())
                    cT.adddisablebleObject(category.CreateEntry<bool>("disable_" + oname, false, "disable " + oname, "Here a list of Objects that can be Diabled"), oname);
                else
                    cT.adddisablebleObject(category.CreateEntry<bool>("disable_" + oname, false, "disable " + oname), oname);
            }

            category.SaveToFile();
        }



        public static void save()
        {

            category.SaveToFile(false);
        }

    }
}
