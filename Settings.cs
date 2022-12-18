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
            useCustomTextEntrys = category.CreateEntry<bool>("useCustomTextEntrys", true, "useCustomTextEntrys", " custom images will be shown together with their set texts. (only if a value is set)");
            customTextEntries = category.CreateEntry<Dictionary<string, string>>("customText", new Dictionary<string, string>(), "customText");
        }

        public static void save()
        {
            category.SaveToFile();
        }

    }
}
