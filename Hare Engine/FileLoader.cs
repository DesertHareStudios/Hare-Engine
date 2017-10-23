using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;

namespace HareEngine {

    public class FileLoader {

        public static int loadImage(string filepath) {
            try {
                Bitmap file = new Bitmap(filepath);
                return loadImage(file);
            } catch {
                return -1;
            }
        }

        public static int loadImage(Bitmap image) {
            int texID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texID);
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, data.Scan0);
            image.UnlockBits(data);
            return texID;
        }

    }

}
