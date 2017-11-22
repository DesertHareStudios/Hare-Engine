using System;
using System.Drawing;
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

        public Texture(string filepath, string name) : base(filepath, name) {
            if (filepath != "") {
                try {
                    img = new Bitmap(filepath);
                    id = GL.GenTexture();
                    GL.BindTexture(TextureTarget.Texture2D, id);
                    BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                        ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                        OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                    img.UnlockBits(data);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, 0);
                } catch (Exception e) {
                    Debug.Exception(e);
                    id = -1;
                }
            } else {
                id = -1;
            }
        }

    }

}
