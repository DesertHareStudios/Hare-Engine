using System.Collections.Generic;

namespace HareEngine {

    public class Transform {

        public GameObject gameObject;
        public Transform parent;
        public List<Transform> childs;
        public Vector position;
        public Quaternion rotation;
        public Vector scale;

        public Vector RelativePosition {
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

        public Vector RotatedPosition {
            get {
                return position.Rotated(rotation);
            }
        }

        public Vector AbsoluteScale {
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

        public Transform(GameObject gameObject) {
            this.gameObject = gameObject;
            parent = null;
            childs = new List<Transform>();
            position = new Vector();
            rotation = Quaternion.Identity;
            scale = new Vector(1f, 1f, 1f);
        }

        public void Translate(Vector to) {
            position += to;
        }

        public void Translate(float x, float y, float z) {
            position += new Vector(x, y, z);
        }

        public void Translate(float x, float y) {
            position += new Vector(x, y, 0f);
        }

    }

}
