using OpenTK.Graphics.OpenGL;
using System;

namespace HareEngine {

    public class SpriteRenderer : Behaviour {

        public Texture sprite;
        public Color tint;

        public string TextureName {
            get {
                return sprite.Name;
            }
            set {
                Texture tex = (Texture)Asset.Get(value);
                if (tex != null) {
                    sprite = tex;
                }
            }
        }

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {
            sprite = new Texture("", "");
            tint = new Color(1f, 1f, 1f);
        }

        public override void OnRender() {
            GL.Disable(EnableCap.Lighting);
            GL.Color4(tint.r, tint.g, tint.b, tint.a);
            if (sprite != null) {
                GL.Enable(EnableCap.Texture2D);
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.BindTexture(TextureTarget.Texture2D, sprite.ID);
            }
            GL.Begin(PrimitiveType.Quads);
            if (sprite != null) {
                GL.TexCoord2(1, 1);
            }
            GL.Vertex2(
                    transform.position.X + (transform.AbsoluteScale.X / 2f),
                    transform.position.Y - (transform.AbsoluteScale.Y / 2f)
                );
            if (sprite != null) {
                GL.TexCoord2(1, 0);
            }
            GL.Vertex2(
                    transform.position.X + (transform.AbsoluteScale.X / 2f),
                    transform.position.Y + (transform.AbsoluteScale.Y / 2f)
                );
            if (sprite != null) {
                GL.TexCoord2(0, 0);
            }
            GL.Vertex2(
                    transform.position.X - (transform.AbsoluteScale.X / 2f),
                    transform.position.Y + (transform.AbsoluteScale.Y / 2f)
                );
            if (sprite != null) {
                GL.TexCoord2(0, 1);
            }
            GL.Vertex2(
                    transform.position.X - (transform.AbsoluteScale.X / 2f),
                    transform.position.Y - (transform.AbsoluteScale.Y / 2f)
                );
            GL.Color4(1f, 1f, 1f, 1f);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Enable(EnableCap.Lighting);
        }
    }

}