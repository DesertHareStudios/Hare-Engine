using System.Collections.Generic;
using OpenTK;
using System;

namespace HareEngine {

    public class Transform : ICloneable {

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
                    _parent._childs.Add(this);
                }
            }
        }

        public List<Transform> childs {
            get {
                return _childs;
            }
        }

        public Vector3 forward {
            get {
                rotation.Normalize();
                return rotation.Xyz;
            }
        }

        public Vector3 backward {
            get {
                return -forward;
            }
        }

        public Vector3 right {
            get {
                return Mathf.ApplyRotation(new Vector3(-forward.Z, 0, forward.X), rotation);
            }
        }

        public Vector3 left {
            get {
                return -right;
            }
        }

        public Vector3 up {
            get {
                return Vector3.UnitY;
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
            position = new Vector3(0f, 0f, 0f);
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

        public Matrix4 ModelMatrix {
            get {
                Matrix4 output = Matrix4.CreateScale(scale) * Matrix4.CreateFromQuaternion(rotation) * Matrix4.CreateTranslation(position);
                if (parent != null) {
                    output *= parent.ModelMatrix;
                }
                return output;
            }
        }

        public Matrix4 SetMVPMatrix(Camera cam) {
            return ModelMatrix * cam.ViewMatrix * cam.ProjectionMatrix;
        }

        public object Clone() {
            return this.MemberwiseClone();
        }
    }

}
