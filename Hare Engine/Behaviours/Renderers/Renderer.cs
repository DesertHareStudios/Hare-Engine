using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace HareEngine {

    public abstract class Renderer : Behaviour {

        protected static List<Renderer> renderers = new List<Renderer>();

        public static List<Renderer> All {
            get {
                return renderers;
            }
        }

        public Matrix4 ModelViewMatrix = Matrix4.Identity;
        public Matrix4 ProjectionMatrix = Matrix4.Identity;
        public Matrix4 MVPMatrix = Matrix4.Identity;
        public Texture texture;
        public int VertCount { get; protected set; }
        public int IndiceCount { get; protected set; }
        public int ColorDataCount { get; protected set; }

        public Matrix4 ModelMatrix {
            get {
                return Matrix4.CreateScale(transform.AbsoluteScale) * Matrix4.CreateFromQuaternion(transform.rotation) * Matrix4.CreateTranslation(transform.position);
            }
        }

        public Renderer(GameObject gameObject) : base(gameObject) { }

        public override void OnEnable() {
            base.OnEnable();
            renderers.Add(this);
        }

        public override void OnDisable() {
            base.OnDisable();
            renderers.Remove(this);
        }

        public abstract Vector3[] GetVerts();
        public abstract int[] GetIndices(int offset = 0);
        public abstract Vector2[] GetUVs();
        public abstract Vector4[] GetColors();

    }

}
