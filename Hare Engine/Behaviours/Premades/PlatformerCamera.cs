using OpenTK;

namespace HareEngine {

    public class PlatformerCamera : Behaviour {

        public Transform target;
        public Vector3 offset;
        public float smoothSpeed;

        public PlatformerCamera(GameObject gameObject) : base(gameObject) {
            target = transform;
            offset = new Vector3(0f, 0f, 10f);
            smoothSpeed = 0.618f;
        }

        public override void LateUpdate() {
            if (target != null && target != transform) {
                transform.position = Vector3.Lerp(
                    transform.position,
                    target.position + offset,
                    Mathf.Clamp(smoothSpeed * Time.deltaTime * Time.timeScale, 0f, 1f)
                    );
            }
        }

    }

}
