using System.Collections.Generic;

namespace HareEngine {

    public class GameObject {

        public List<Behaviour> behaviours;
        public string Name;
        public string Tag;
        public Transform transform { private set; get; }
        private bool _active = true;

        public bool Active {
            get {
                if (_active) {
                    if (transform.parent != null) {
                        return transform.parent.gameObject.Active;
                    }
                }
                return _active;
            }
            set {
                _active = value;
                if (behaviours != null) {
                    foreach (Behaviour b in behaviours) {
                        if (b.Active) {
                            if (_active) {
                                b.OnEnable();
                            } else {
                                b.OnDisable();
                            }
                        }
                    }
                }
            }
        }

        public GameObject(string name, string tag) {
            this.transform = new Transform(this);
            this.Name = name;
            this.Tag = tag;
            behaviours = new List<Behaviour>();
        }
        public GameObject(string name) {
            this.transform = new Transform(this);
            this.Name = name;
            this.Tag = "Default";
            behaviours = new List<Behaviour>();
        }

        public GameObject() {
            this.transform = new Transform(this);
            this.Name = "New GameObject";
            this.Tag = "Default";
            behaviours = new List<Behaviour>();
        }

        public void AddBehaviour(Behaviour b) {
            behaviours.Add(b);
        }

        public T GetComponent<T>() where T : Behaviour {
            foreach (Behaviour b in behaviours) {
                if (b.GetType() == typeof(T)) {
                    return (T)b;
                }
            }
            return null;
        }

        public void OnCollisionEnter(Collision collision) {
            foreach (Behaviour b in behaviours) {
                if (b.Active) {
                    b.OnCollisionEnter(collision);
                }
            }
        }
        public void OnCollisionExit(Collision collision) {
            foreach (Behaviour b in behaviours) {
                if (b.Active) {
                    b.OnCollisionExit(collision);
                }
            }
        }
        public void OnTriggerEnter(Collider collider) {
            foreach (Behaviour b in behaviours) {
                if (b.Active) {
                    b.OnTriggerEnter(collider);
                }
            }
        }
        public void OnTriggerExit(Collider collider) {
            foreach (Behaviour b in behaviours) {
                if (b.Active) {
                    b.OnTriggerExit(collider);
                }
            }
        }

    }

}
