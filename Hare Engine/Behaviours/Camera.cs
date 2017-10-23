using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace HareEngine {

    public class Camera : Behaviour {

        public Color clearColor;
        public Viewmode viewmode;
        public float renderDistance;
        public float nearClipping;

        public Camera(GameObject gameObject) : base(gameObject) {
            renderDistance = 1000f;
            nearClipping = 0.3f;
            viewmode = Viewmode.Perspective;
            clearColor = new Color(0f, 0f, 0f);
        }

        public override void LateUpdate() {
            //TODO do camera stuff
            Hare.clearColor = clearColor;
            GL.ClearColor(Random.Value, Random.Value, Random.Value, 1f);
            Matrix4 lookat = Matrix4.LookAt(transform.position.x, transform.position.y, transform.position.z, 256, 0, 256, 0.0f, 1.0f, 0.0f);
            switch (viewmode) {
                case Viewmode.Orthographic:
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref lookat);
                    GL.Ortho(0f, Hare.window.Width, 0, Hare.window.Height, nearClipping, renderDistance);
                    break;
                case Viewmode.Perspective:
                    viewmode = Viewmode.Orthographic;
                    break;
            }
        }

    }

    public enum Viewmode {
        Orthographic,
        Perspective
    }

}
