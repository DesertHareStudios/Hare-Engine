using System.Collections.Generic;
using OpenTK;

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
            clearColor = new Color(0f, 0.618f, 1f);
            fov = 70f;
        }

        public Matrix4 ProjectionMatrix {
            get {
                switch (viewmode) {
                    case Viewmode.Orthographic:
                        return Matrix4.CreateOrthographic(Hare.window.Width, Hare.window.Height, nearClipping, renderDistance);
                    case Viewmode.Perspective:
                        return Matrix4.CreatePerspectiveFieldOfView(Mathf.ToRadians(fov), Hare.window.AspectRatio, nearClipping, renderDistance);
                    default:
                        viewmode = Viewmode.Orthographic;
                        return ProjectionMatrix;
                }
            }
        }

        public Matrix4 ViewMatrix {
            get {
                return Matrix4.LookAt(
                    transform.position,
                    (transform.position + transform.forward),
                    transform.up);
            }
        }

    }

    public enum Viewmode {
        Orthographic,
        Perspective
    }

}
