namespace HareEngine {

    public class Behaviour {

        private bool active = true;

        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
                if (value) {
                    OnEnable();
                } else {
                    OnDisable();
                }
            }
        }

        public GameObject gameObject { private set; get; }

        public Transform transform {
            get {
                return gameObject.transform;
            }
        }

        public Behaviour(GameObject gameObject) {
            this.gameObject = gameObject;
            Active = true;
        }

        protected T GetComponent<T>() where T : Behaviour {
            return gameObject.GetComponent<T>();
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void FixedUpdate() { }
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void OnCollisionEnter(Collision collision) { }
        public virtual void OnCollisionExit(Collision collision) { }
        public virtual void OnTriggerEnter(Collider collider) { }
        public virtual void OnTriggerExit(Collider collider) { }

    }

}
