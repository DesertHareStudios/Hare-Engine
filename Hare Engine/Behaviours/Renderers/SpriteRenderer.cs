using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace HareEngine {

    public class SpriteRenderer : Behaviour {
        
        private Bitmap bitmap;
        private string prevFilepath;

        public string spriteFilepath;
        public Color tint;

        public SpriteRenderer(GameObject gameObject) : base(gameObject) {}

        public override void OnRender() {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(
                    (double)(transform.position.x - transform.AbsoluteScale.x),
                    (double)(transform.position.y + transform.AbsoluteScale.y),
                    (double)(transform.position.z)
                );
            GL.Vertex3(
                    (double)(transform.position.x + transform.AbsoluteScale.x),
                    (double)(transform.position.y + transform.AbsoluteScale.y),
                    (double)(transform.position.z)
                );
            GL.Vertex3(
                    (double)(transform.position.x + transform.AbsoluteScale.x),
                    (double)(transform.position.y - transform.AbsoluteScale.y),
                    (double)(transform.position.z)
                );
            GL.Vertex3(
                    (double)(transform.position.x - transform.AbsoluteScale.x),
                    (double)(transform.position.y - transform.AbsoluteScale.y),
                    (double)(transform.position.z)
                );
        }
    }

}
