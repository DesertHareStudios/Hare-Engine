using System.Collections.Generic;
using OpenTK;

namespace HareEngine {

    public class Transform {

        private Transform _parent;
        private List<Transform> _childs;

        public GameObject gameObject;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public Transform parent {
            get {
                return _parent;
            }
            set {
                if (_parent != null) {
                    _parent._childs.Remove(this);
                }
                _parent = value;
                if (value != null) {
                    value._childs.Remove(this);
                    value._childs.Add(this);
                }
            }
        }

        public List<Transform> childs {
            get {
                return _childs;
            }
        }

        public Vector3 RelativePosition {
            get {
                if (parent == null) {
                    return position;
                } else {
                    return position - parent.RelativePosition;
                }
            }
            set {
                if (parent == null) {
                    position = value;
                } else {
                    position = parent.RelativePosition + value;
                }
            }
        }

        public Vector3 AbsoluteScale {
            get {
                if (parent == null) {
                    return scale;
                } else {
                    return parent.AbsoluteScale + scale;
                }
            }
            set {
                if (parent == null) {
                    scale = value;
                } else {
                    scale = value - parent.AbsoluteScale;
                }
            }
        }

        public Vector3 forward {
            get {
                return rotation.Xyz;
            }
        }

        public Vector3 right {
            get {
                return new Vector3(-forward.Z, 0, forward.X);
            }
        }

        public Vector3 left {
            get {
                return -right;
            }
        }

        public Vector3 up {
            get {
                return Mathf.ApplyRotation(new Vector3(0f, -forward.Z, forward.Y), rotation);
            }
        }

        public Vector3 down {
            get {
                return -up;
            }
        }

        public Transform(GameObject gameObject) {
            this.gameObject = gameObject;
            parent = null;
            _childs = new List<Transform>();
            position = new Vector3();
            rotation = Quaternion.Identity;
            scale = new Vector3(1f, 1f, 1f);
        }

        public void Translate(Vector3 to) {
            position += to;
        }

        public void Translate(float x, float y, float z) {
            position += new Vector3(x, y, z);
        }

        public void Translate(float x, float y) {
            position += new Vector3(x, y, 0f);
        }

    }

}
