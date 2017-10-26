﻿using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace HareEngine {

    public class Texture : Asset {

        private Bitmap img;
        private int id;

        public int Width {
            get {
                return img.Width;
            }
        }

        public int Height {
            get {
                return img.Height;
            }
        }

        public int ID {
            get {
                return id;
            }
        }

        public Texture() : base("") {
            id = -1;
        }

        public Texture(string filepath) : base(filepath) {
            try {
                img = new Bitmap(filepath);
                int texID = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, texID);
                BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, data.Scan0);
                img.UnlockBits(data);
                id = texID;
            } catch {
                id = -1;
            }
        }

    }

}
