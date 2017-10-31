using System.Collections.Generic;

namespace HareEngine {

    public class Collider : Behaviour {

        private static List<Collider> colliders = new List<Collider>();

        private Rigidbody rb;

        public bool isTrigger = false;

        public Collider(GameObject gameObject) : base(gameObject) { }

        public override void Awake() {
            rb = GetComponent<Rigidbody>();
            colliders.Add(this);
        }

        public override void FixedUpdate() {
            //TODO detect collision
        }

        public override void OnEnable() {
            colliders.Add(this);
        }

        public override void OnDisable() {
            colliders.Remove(this);
        }

    }

}
