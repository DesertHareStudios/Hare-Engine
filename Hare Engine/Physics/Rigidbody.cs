using System.Collections.Generic;

namespace HareEngine {

    class Rigidbody : Behaviour {

        private static List<Rigidbody> bodies;

        public float mass = 1f;
        public bool useGravity = true;
        public Vector speed = new Vector();
        public List<Collider> colliders = new List<Collider>();

        public Rigidbody(GameObject gameObject) : base(gameObject) {
            if (bodies == null) {
                bodies = new List<Rigidbody>();
            }
        }

        public override void FixedUpdate() {
            if (useGravity) {
                switch (Physics.Instance.gravityType) {
                    case GravityType.Classic:
                        AddForce(0f, -Physics.Instance.GravityScale, 0f);
                        break;
                    case GravityType.Newtonian:
                        foreach (Rigidbody body in bodies) {
                            if (body != this && body.useGravity) {
                                Vector direction = transform.position - body.transform.position;
                                float distance = direction.Magnitude;
                                if (distance != 0) {
                                    float magnitude = Physics.Instance.G * (mass * body.mass) / Mathf.Pow(distance, 2);
                                    body.AddForce(direction.Normal * magnitude);
                                }
                            }
                        }
                        break;
                }
            }
        }

        public override void OnEnable() {
            bodies.Add(this);
        }

        public override void OnDisable() {
            bodies.Remove(this);
        }

        public void AddForce(Vector force) {
            //TODO add force
        }

        public void AddForce(float x, float y, float z) {
            AddForce(new Vector(x, y, z));
        }

    }

}
