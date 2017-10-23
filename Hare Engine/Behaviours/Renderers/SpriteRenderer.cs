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

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {
            tint = new Color(1f, 1f, 1f);
        }

        public override void Start() {
            SpriteFilePath = _spriteFilepath;
        }

        public override void OnRender() {
            Vector p1 = (transform.position - transform.AbsoluteScale).Rotated(transform.rotation);
            Vector p2 = (transform.position + transform.AbsoluteScale).Rotated(transform.rotation);
            if (tex != -1) {
                GL.Disable(EnableCap.Lighting);
                GL.Enable(EnableCap.Texture2D);
                GL.Enable(EnableCap.Blend);
                GL.BindTexture(TextureTarget.Texture2D, tex);
            } else {
                GL.Color4(tint.r, tint.g, tint.b, tint.a);
            }
            GL.Begin(PrimitiveType.Quads);
            if (tex != -1) {
                GL.TexCoord2(1, 1);
            }
            GL.Vertex2(
                    transform.position.x + (transform.AbsoluteScale.x / 2f),
                    transform.position.y - (transform.AbsoluteScale.y / 2f)
                );
            if (tex != -1) {
                GL.TexCoord2(1, 0);
            }
            GL.Vertex2(
                    transform.position.x + (transform.AbsoluteScale.x / 2f),
                    transform.position.y + (transform.AbsoluteScale.y / 2f)
                );
            if (tex != -1) {
                GL.TexCoord2(0, 0);
            }
            GL.Vertex2(
                    transform.position.x - (transform.AbsoluteScale.x / 2f),
                    transform.position.y + (transform.AbsoluteScale.y / 2f)
                );
            if (tex != -1) {
                GL.TexCoord2(0, 1);
            }
            GL.Vertex2(
                    transform.position.x - (transform.AbsoluteScale.x / 2f),
                    transform.position.y - (transform.AbsoluteScale.y / 2f)
                );
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
            if (tex == -1) {
                try {
                    tex = FileLoader.loadImage(_spriteFilepath);
                } catch { }
            }
        }
    }

}
