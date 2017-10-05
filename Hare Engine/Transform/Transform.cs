using System.Collections.Generic;

namespace HareEngine {

    class Transform {
        
        public GameObject gameObject;
        public Transform parent;
        public List<Transform> childs;
        public Vector position;
        public Octonion rotation;
        public Vector scale;

        public Transform(GameObject gameObject) {
            this.gameObject = gameObject;
            parent = null;
            childs = new List<Transform>();
            position = new Vector();
            rotation = new Octonion();
            scale = new Vector(1f, 1f, 1f, 1f);
        }

        public void Translate(Vector to) {
            position += to;
        }

        public void Translate(float x, float y, float z, float w) {
            position += new Vector(x, y, z, w);
        }

        public void Translate(float x, float y, float z) {
            position += new Vector(x, y, z, 0f);
        }

        public void Translate(float x, float y) {
            position += new Vector(x, y, 0f, 0f);
        }

    }

}
