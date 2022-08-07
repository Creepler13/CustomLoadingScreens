using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace CustomLoadingScreens
{
    internal class Settings
    {

        public static MelonPreferences_Category category;

        private static MelonPreferences_Entry<bool> onlyCustomImagesEntry;
        private static MelonPreferences_Entry<double> customImageProbabilityEntry;
        private static MelonPreferences_Entry<string[]> customTextEntry;

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

        public static string[] customText
        {
            get
            {
                return customTextEntry.Value;
            }
            set
            {
                customTextEntry.Value = value;
            }
        }

        public static void load()
        {
            category = MelonPreferences.CreateCategory("CustomLoadingScreensSetttings");
            category.SetFilePath("Userdata/CustomLoadingScreens.cfg", true);
            onlyCustomImagesEntry = category.CreateEntry<bool>("onlyCustomImages", true, "onlyCustomImages", "if true only custom images will be Shown during loading screens");
            customImageProbabilityEntry = category.CreateEntry<double>("customImageProbability", 0, "customImageProbability", "only important if onlyCustomImages is false.probabilty from 0-1 that decides the chance that a custom image is shown (0 = the same probability as default images)");
            customTextEntry = category.CreateEntry<string[]>("customText", new string[0], "customText", "custom text that will be shown during the loading screen");

        }

    }
}
