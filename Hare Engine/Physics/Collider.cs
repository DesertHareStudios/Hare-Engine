using OpenTK;
using System.Collections.Generic;

namespace HareEngine {

    public abstract class Collider : Behaviour {

        private static List<Collider> colliders = new List<Collider>();

        private Rigidbody rb;
        protected int VertCount;

        public bool isTrigger = false;

        public Collider(GameObject gameObject) : base(gameObject) { }

        public override void Awake() {
            rb = GetComponent<Rigidbody>();
            colliders.Add(this);
        }

        public static bool Collides(Collider collider) {
            bool output = false;
            foreach (Collider c in colliders) {
                if (c != collider && !c.isTrigger) {

                }
            }
            return output;
        }

        public override void OnEnable() {
            colliders.Add(this);
        }

        public override void OnDisable() {
            colliders.Remove(this);
        }

        public abstract Vector3[] GetVerts();

    }

}
