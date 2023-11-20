using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using UnityEngine;

namespace CustomLoadingScreens
{
    internal class ImageRegistry
    {
        public Dictionary<string, TextureData> textData = new Dictionary<string, TextureData>();
        public Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();
        public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        private System.Random rand = new System.Random();
        public void load(String path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (string Imagepath in Directory.GetFiles(path))
            {
                if (File.Exists(Imagepath))
                {
                    string fileName = Path.GetFileName(Imagepath).Replace(".", "_");

                    Bitmap bm = new Bitmap(Imagepath);
                    Texture2D text = new Texture2D(bm.Width, bm.Height, TextureFormat.ARGB32, false);

                    for (int x = 0; x < bm.Width; x++)
                    {
                        for (int y = 0; y < bm.Height; y++)
                        {
                            System.Drawing.Color c = bm.GetPixel(x, bm.Height - 1 - y);
                            text.SetPixel(x, y, new UnityEngine.Color32(c.R, c.G, c.B, c.A));
                        }
                    }

                    text.Apply();
                    TextureData textDat = new TextureData();
                    textDat.rawData = text.GetRawTextureData();
                    textDat.width = text.width;
                    textDat.height = text.height;
                    textData.Add(fileName, textDat);
                    textures.Add(fileName, text);
                    Sprite s = Sprite.Create(text, new Rect(0, 0, text.width, text.height), new Vector2(0.5f, 0.5f));

                    images.Add(fileName, s);
                    if (path == ModMain.CustomLoadingScreenPath)
                        if (!Settings.customText.ContainsKey(fileName))
                            Settings.customText.Add(fileName, "");
                    //MelonLoader.MelonLogger.Msg("Loaded img " + Imagepath);
                }


            }
            Settings.save();


        }



    }
}
