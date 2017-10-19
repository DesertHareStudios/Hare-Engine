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
                return _active;
            }
            set {
                if (transform.parent == null) {
                    _active = value;
                } else {
                    if (transform.parent.gameObject.Active) {
                        _active = value;
                        foreach (Transform t in transform.childs) {
                            t.gameObject.Active = value;
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

        public void AddBehaviour<T>() where T : Behaviour {
            behaviours.Add((T)(new Behaviour(this)));
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
