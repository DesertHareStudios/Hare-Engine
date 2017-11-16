using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace HareEngine {

    public abstract class Renderer : Behaviour {

        public abstract Matrix4 ModelMatrix { get; }
        public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;
        public Texture texture;
        public Color tint = new Color(1f, 1f, 1f, 1f);
        public PrimitiveType vertexType = PrimitiveType.Triangles;

        public Renderer(GameObject gameObject) : base(gameObject) { }

        public abstract Vector3[] GetVerts();
        public abstract Vector2[] GetUVs();
        public abstract EnableCap[] GetCaps();
        public abstract EnableCap[] GetDisabledCaps();

    }

}
