using System.Collections.Generic;
using OpenTK;

namespace HareEngine {

    public class Transform {

        public GameObject gameObject;
        public Transform parent;
        public List<Transform> childs;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

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
                return new Vector3((float)Mathf.Sin((float)rotation.X), 0, (float)Mathf.Cos((float)rotation.X));
            }
        }

        public Vector3 right {
            get {
                return new Vector3(-forward.Z, 0, forward.X);
            }
        }

        public Transform(GameObject gameObject) {
            this.gameObject = gameObject;
            parent = null;
            childs = new List<Transform>();
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
