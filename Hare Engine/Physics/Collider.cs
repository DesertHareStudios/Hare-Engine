using System.Collections.Generic;

namespace HareEngine {

    public class Collider : Behaviour {

        private static List<Collider> colliders = new List<Collider>();

        private Rigidbody rb;

        public bool isTrigger = false;
        public Geometry.GeoNode points;

        public Collider(GameObject gameObject) : base(gameObject) { }

        public override void Awake() {
            rb = GetComponent<Rigidbody>();
            colliders.Add(this);
        }

        public override void FixedUpdate() {
            if (!isTrigger && rb != null) {
                foreach (Collider col in colliders) {
                    if (col != this) {
                        Geometry.GeoNode node = points;
                        bool colDetected = false;
                        while (node.Next != null && !colDetected) {
                            Vector point = (node.position + transform.position).Rotated(transform.rotation);
                            float er = col.points.EnteringRatio(point, col.transform.position, col.transform.rotation);
                            if (er > 0) {
                                colDetected = true;
                                if (col.isTrigger) {
                                    gameObject.OnTriggerEnter(col);
                                } else {
                                    //TODO get collision details
                                    Collision collision = new Collision();
                                    gameObject.OnCollisionEnter(collision);
                                }
                            } else {
                                node = node.Next;
                            }
                        }
                    }
                }
            }
        }

        public override void OnEnable() {
            colliders.Add(this);
        }

        public override void OnDisable() {
            colliders.Remove(this);
        }

    }

}
