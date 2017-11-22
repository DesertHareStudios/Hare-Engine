using OpenTK;

namespace HareEngine {

    public class Camera : Behaviour {

        public Color clearColor;
        public Viewmode viewmode;
        public float renderDistance;
        public float nearClipping;
        public Range fov;
        public float OrthoWidth;

        public Camera(GameObject gameObject) : base(gameObject) {
            renderDistance = 100f;
            nearClipping = 0.3f;
            viewmode = Viewmode.Orthographic;
            clearColor = new Color(0f, 0.618f, 1f);
            fov = new Range(1f, 179f, 70f);
            OrthoWidth = 3f;
        }

        public Matrix4 ProjectionMatrix {
            get {
                switch (viewmode) {
                    case Viewmode.Orthographic:
                        return Matrix4.CreateOrthographic(OrthoWidth, OrthoWidth / Hare.window.AspectRatio, 1f + nearClipping, renderDistance);
                    case Viewmode.Perspective:
                        return Matrix4.CreatePerspectiveFieldOfView(Mathf.ToRadians(fov.Value), Hare.window.AspectRatio, 1f + nearClipping, renderDistance);
                    default:
                        viewmode = Viewmode.Orthographic;
                        return ProjectionMatrix;
                }
            }
        }

        public Matrix4 ViewMatrix {
            get {
                //return Matrix4.LookAt(
                //    transform.position,
                //    (transform.position + transform.forward),
                //    transform.up);
                Matrix4 mView = Matrix4.Identity;

                float twoXSquared = 2 * transform.rotation.X * transform.rotation.X;
                float twoYSquared = 2 * transform.rotation.Y * transform.rotation.Y;
                float twoZSquared = 2 * transform.rotation.Z * transform.rotation.Z;
                float twoXY = 2 * transform.rotation.X * transform.rotation.Y;
                float twoWZ = 2 * transform.rotation.W * transform.rotation.Z;
                float twoXZ = 2 * transform.rotation.X * transform.rotation.Z;
                float twoWY = 2 * transform.rotation.W * transform.rotation.Y;
                float twoYZ = 2 * transform.rotation.Y * transform.rotation.Z;
                float twoWX = 2 * transform.rotation.W * transform.rotation.X;

                mView.M11 = 1 - twoYSquared - twoZSquared;
                mView.M12 = twoXY + twoWZ;
                mView.M13 = twoXZ - twoWY;
                mView.M21 = twoXY - twoWZ;
                mView.M22 = 1 - twoXSquared - twoZSquared;
                mView.M23 = twoYZ + twoWX;
                mView.M31 = twoXZ + twoWY;
                mView.M32 = twoYZ - twoWX;
                mView.M33 = 1 - twoXSquared - twoYSquared;

                Vector3 front = new Vector3(mView.M11, mView.M21, mView.M31);
                Vector3 up = new Vector3(mView.M12, mView.M22, mView.M32);
                Vector3 right = new Vector3(mView.M13, mView.M23, mView.M33);
                mView.M41 = -Vector3.Dot(front, transform.position);
                mView.M42 = -Vector3.Dot(up, transform.position);
                mView.M43 = -Vector3.Dot(right, transform.position);

                return mView;
            }
        }
    }

}

public enum Viewmode {
    Orthographic,
    Perspective
}
