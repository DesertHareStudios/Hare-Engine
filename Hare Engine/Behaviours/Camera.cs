using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;

namespace HareEngine {

    public class Camera : Behaviour {

        public Color clearColor;
        public Viewmode viewmode;
        public float renderDistance;
        public float nearClipping;
        public float fov;

        public Camera(GameObject gameObject) : base(gameObject) {
            renderDistance = 100f;
            nearClipping = 0.3f;
            viewmode = Viewmode.Perspective;
            clearColor = new Color(0f, 0f, 0f);
            fov = 1.3f;
        }

        public override void OnPrerender() {
            Hare.clearColor = clearColor;
            Matrix4 lookAt = ViewMatrix;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookAt);
            switch (viewmode) {
                case Viewmode.Orthographic:
                    Matrix4 m = ViewMatrix * Matrix4.CreateOrthographic(Hare.window.Width, Hare.window.Height, nearClipping, renderDistance);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref m);
                    break;
                case Viewmode.Perspective:
                    Matrix4 m2 = ViewMatrix * Matrix4.CreatePerspectiveFieldOfView(fov, Hare.window.AspectRatio, nearClipping, renderDistance);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref m2);
                    break;
            }
        }

        public Matrix4 ViewMatrix {
            get {
                return Matrix4.LookAt(
                    transform.position,
                    transform.position + new Vector3(
                        Mathf.Sin(transform.rotation.X) * Mathf.Cos(transform.rotation.Y),
                        Mathf.Sin(transform.rotation.Y),
                        Mathf.Cos(transform.rotation.X) * Mathf.Cos(transform.rotation.Y)
                        ),
                    Vector3.UnitY);
            }
        }

    }

    public enum Viewmode {
        Orthographic,
        Perspective
    }

}
