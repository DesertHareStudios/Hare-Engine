using System.Collections.Generic;

namespace HareEngine {

    public class Rigidbody : Behaviour {

        private static List<Rigidbody> bodies;

        private Geometry.Line path;
        private Vector previousPosition;

        public float mass = 1f;
        public bool useGravity = true;
        public bool isKinematic = false;
        public Vector speed = new Vector();
        public Vector centerOfMass = new Vector();
        public Geometry.Line Path {
            get {
                return path;
            }
        }

        public Rigidbody(GameObject gameObject) : base(gameObject) {
            if (bodies == null) {
                bodies = new List<Rigidbody>();
            }
        }

        public override void Awake() {
            bodies.Add(this);
        }

        public override void FixedUpdate() {
            previousPosition = transform.position;
            if (!isKinematic) {
                transform.position += speed * Time.fixedDeltaTime * Time.timeScale;
                if (useGravity) {
                    switch (Physics.Instance.gravityType) {
                        case GravityType.Classic:
                            AddForce(0f, -Physics.Instance.GravityScale, 0f);
                            break;
                        case GravityType.Newtonian:
                            foreach (Rigidbody body in bodies) {
                                if (body != this && body.useGravity) {
                                    Vector direction = (transform.position + centerOfMass) - (body.transform.position + body.centerOfMass);
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
            path = new Geometry.Line(previousPosition, transform.position);
        }

        public void Translate(Vector to) {
            previousPosition = transform.position;
            transform.position += to;
            path = new Geometry.Line(previousPosition, transform.position);
        }

        public void Translate(float x, float y, float z) {
            previousPosition = transform.position;
            transform.position += new Vector(x, y, z);
            path = new Geometry.Line(previousPosition, transform.position);
        }

        public void Translate(float x, float y) {
            previousPosition = transform.position;
            transform.position += new Vector(x, y, 0f);
            path = new Geometry.Line(previousPosition, transform.position);
        }

        public override void OnEnable() {
            bodies.Add(this);
        }

        public override void OnDisable() {
            bodies.Remove(this);
        }

        public void AddForce(Vector force) {
            //TODO add force
            speed += force;
        }

        public void AddForce(float x, float y, float z) {
            AddForce(new Vector(x, y, z));
        }

    }

}
