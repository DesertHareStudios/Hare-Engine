using OpenTK;
using OpenTK.Input;

namespace HareEngine {

    public class PlatformerInput : Behaviour {

        public float Speed;
        public float JumpForce;
        private Rigidbody rb;

        public PlatformerInput(GameObject gameObject) : base(gameObject) {
            Speed = 3.14159f;
            JumpForce = 64f;
            rb = GetComponent<Rigidbody>();
        }

        public override void Update() {
            if (rb != null) {

                if (transform.position.Y < 0f) {
                    transform.position.Y = 0f;
                    rb.speed.Y = 0f;
                }

                if (Input.GetButton(Key.Left) || Input.GetButton(Key.A)) {
                    rb.Translate(-(Speed * Time.deltaTime * Time.timeScale), 0f);
                    transform.scale.X = -Mathf.Abs(transform.scale.X);
                }

                if (Input.GetButton(Key.Right) || Input.GetButton(Key.D)) {
                    rb.Translate(Speed * Time.deltaTime * Time.timeScale, 0f);
                    transform.scale.X = Mathf.Abs(transform.scale.X);
                }

                if (Input.GetButtonDown(Key.Space) || Input.GetButtonDown(Key.W)) {
                    rb.AddForce(0f, JumpForce, 0f);
                }
            }
        }


    }

}
