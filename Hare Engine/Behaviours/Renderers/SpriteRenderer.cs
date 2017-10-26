using OpenTK.Graphics.OpenGL;
using System;

namespace HareEngine {

    public class SpriteRenderer : Behaviour {

        public Texture sprite;
        public Color tint;

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {
            tint = new Color(1f, 1f, 1f);
            sprite = new Texture();
        }

        public override void OnRender() {
            if (sprite.ID != -1) {
                GL.Disable(EnableCap.Lighting);
                GL.Enable(EnableCap.Texture2D);
                GL.Enable(EnableCap.Blend);
                GL.BindTexture(TextureTarget.Texture2D, sprite.ID);
            } else {
                GL.Color4(tint.r, tint.g, tint.b, tint.a);
            }
            GL.Begin(PrimitiveType.Quads);
            if (sprite.ID != -1) {
                GL.TexCoord2(1, 1);
            }
            GL.Vertex2(
                    transform.position.x + (transform.AbsoluteScale.x / 2f),
                    transform.position.y - (transform.AbsoluteScale.y / 2f)
                );
            if (sprite.ID != -1) {
                GL.TexCoord2(1, 0);
            }
            GL.Vertex2(
                    transform.position.x + (transform.AbsoluteScale.x / 2f),
                    transform.position.y + (transform.AbsoluteScale.y / 2f)
                );
            if (sprite.ID != -1) {
                GL.TexCoord2(0, 0);
            }
            GL.Vertex2(
                    transform.position.x - (transform.AbsoluteScale.x / 2f),
                    transform.position.y + (transform.AbsoluteScale.y / 2f)
                );
            if (sprite.ID != -1) {
                GL.TexCoord2(0, 1);
            }
            GL.Vertex2(
                    transform.position.x - (transform.AbsoluteScale.x / 2f),
                    transform.position.y - (transform.AbsoluteScale.y / 2f)
                );
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Lighting);
        }
    }

}