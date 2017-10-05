namespace HareEngine {

    class Transform {
        
        public GameObject gameObject;
        public Transform parent;
        public Vector position;
        public Octonion rotation;
        public Vector scale;

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
