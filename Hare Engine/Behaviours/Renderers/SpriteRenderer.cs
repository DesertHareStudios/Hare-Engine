using OpenTK.Graphics.OpenGL;
using System;

namespace HareEngine {

    public class SpriteRenderer : Behaviour {

        private int tex;
        private string _spriteFilepath;

        public string SpriteFilePath {
            get {
                return _spriteFilepath;
            }
            set {
                _spriteFilepath = Environment.CurrentDirectory + "\\" + value;
                try {
                    tex = FileLoader.loadImage(_spriteFilepath);
                } catch { }
            }
        }
        public Color tint;

        public SpriteRenderer(GameObject gameObject) : base(gameObject) { }

        public override void Start() {
            SpriteFilePath = _spriteFilepath;
        }

        public override void OnRender() {
            if (tex != -1) {
                Vector p1 = (transform.position - transform.AbsoluteScale).Rotated(transform.rotation);
                Vector p2 = (transform.position + transform.AbsoluteScale).Rotated(transform.rotation);
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, tex);
                GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 1);
                GL.Vertex3(
                        (double)(p1.x),
                        (double)(p1.y),
                        (double)(transform.RotatedPosition.z)
                    );
                GL.TexCoord2(1, 1);
                GL.Vertex3(
                        (double)(p2.x),
                        (double)(p1.y),
                        (double)(transform.RotatedPosition.z)
                    );
                GL.TexCoord2(1, 0);
                GL.Vertex3(
                        (double)(p2.x),
                        (double)(p2.y),
                        (double)(transform.RotatedPosition.z)
                    );
                GL.TexCoord2(0, 0);
                GL.Vertex3(
                        (double)(p1.x),
                        (double)(p2.y),
                        (double)(transform.RotatedPosition.z)
                    );
                GL.End();
                GL.Disable(EnableCap.Texture2D);
            } else {
                try {
                    tex = FileLoader.loadImage(_spriteFilepath);
                } catch { }
            }
        }
    }

}
