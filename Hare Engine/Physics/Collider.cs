namespace HareEngine {

    class Collider : Behaviour {

        public bool isTrigger = false;

        public Collider(GameObject gameObject) : base(gameObject) { }

        public override void Awake() {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) {
                rb.colliders.Add(this);
            }
        }

        public virtual bool CollidesWith(Collider collider) {
            return false;
        }

    }

}
