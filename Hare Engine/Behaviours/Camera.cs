using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace HareEngine {

    public class Camera : Behaviour {

        public Viewmode viewmode;
        public float renderDistance;
        public float nearClipping;

        public Camera(GameObject gameObject) : base(gameObject) {
            renderDistance = 1000f;
            nearClipping = 0.3f;
            viewmode = Viewmode.Perspective;
        }

        public override void LateUpdate() {
            //TODO do camera stuff
            GL.Viewport(0, 0, Hare.window.Width, Hare.window.Height);
            Matrix4 lookat = Matrix4.LookAt(transform.position.x, transform.position.y, transform.position.z, 256, 0, 256, 0.0f, 1.0f, 0.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            switch (viewmode) {
                case Viewmode.Orthographic:
                    GL.Ortho(0f, Hare.window.Width, 0, Hare.window.Height, nearClipping, renderDistance);
                    break;
                case Viewmode.Perspective:
                    break;
            }
        }

    }

    public enum Viewmode {
        Orthographic,
        Perspective
    }

}
