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
                _active = value;
                foreach (Transform t in transform.childs) {
                    t.gameObject.Active = value;
                }
            }
        }

        public GameObject(Transform transform, string name, string tag) {
            this.transform = transform;
            this.Name = name;
            this.Tag = tag;
        }
        public GameObject(Transform transform, string name) {
            this.transform = transform;
            this.Name = name;
            this.Tag = "Default";
        }

        public GameObject(Transform transform) {
            this.transform = transform;
            this.Name = "New GameObject";
            this.Tag = "Default";
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

    }

}
