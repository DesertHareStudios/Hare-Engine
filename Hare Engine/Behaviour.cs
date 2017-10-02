namespace HareEngine {

    class Behaviour {

        public GameObject gameObject { private set; get; }

        public Transform transform {
            get {
                return gameObject.transform;
            }
        }

        public Behaviour(GameObject gameObject) {
            this.gameObject = gameObject;
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void FixedUpdate() { }
    }

}
