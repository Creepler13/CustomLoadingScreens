using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CustomLoadingScreens.CustomBackgrounds
{
    internal class ChangeableTexture
    {

        System.Random rand = new System.Random();

        public String id, description;
        public MelonPreferences_Entry<String> image;

        public Dictionary<string, ChangeableTexture> subTextures = new Dictionary<string, ChangeableTexture>();
        public Dictionary<string, MelonPreferences_Entry<bool>> disablebleObjects = new Dictionary<string, MelonPreferences_Entry<bool>>();

        public static ImageRegistry registry { get; set; }

        public bool enabled()
        {
            return image.Value != "";
        }

        public void adddisablebleObject(MelonPreferences_Entry<bool> obj, string name)
        {
            disablebleObjects[name] = obj;
        }

        public void addSubTexture(ChangeableTexture text, string name)
        {
            text.id = name;
            subTextures[name] = text;
        }

        public void setImage(Image img)
        {
            if (image.Value == "")
                return;

            string imageKey = image.Value.Replace(".", "_");

            if (!registry.textData.ContainsKey(imageKey))
                return;

            TextureData dat = registry.textData[imageKey];
            Texture2D tempText = new Texture2D(dat.width, dat.height, TextureFormat.ARGB32, false);
            tempText.LoadRawTextureData(dat.rawData);
            tempText.Apply();
            Sprite temp = Sprite.Create(tempText, new Rect(0, 0, tempText.width, tempText.height), Vector2.zero);
            img.sprite = temp;
            img.color = new UnityEngine.Color(1, 1, 1, 1);
        }
    }
}
