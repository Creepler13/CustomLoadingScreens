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
    public class ImageRegistry
    {
        internal List<TextureData> textData = new List<TextureData>();
        internal List<Sprite> images = new List<Sprite>();
        internal List<Texture2D> textures = new List<Texture2D>();

        private System.Random rand = new System.Random();
        public void load()
        {
            string path = "CustomLoadingScreens";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (string Imagepath in Directory.GetFiles(path))
            {
                if (File.Exists(Imagepath))
                {
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
                    textData.Add(textDat);
                    textures.Add(text);
                    Sprite s = Sprite.Create(text, new Rect(0, 0, text.width, text.height), new Vector2(0.5f, 0.5f));


                    images.Add(s);

                    MelonLoader.MelonLogger.Msg("Loaded img " + Imagepath);
                }
            }



        }

        public Sprite getRandomSprite()
        {
            return images[rand.Next(images.Count)];
        }
        public Texture2D getRandomTexture()
        {
            return textures[rand.Next(textures.Count)];
            /*  string path = "CustomLoadingScreens";
            string[] images = Directory.GetFiles(path);
            Bitmap bm = new Bitmap(images[rand.Next(images.Length)]);
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

            return text;
        */
        }

    }
}
