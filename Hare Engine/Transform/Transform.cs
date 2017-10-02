namespace HareEngine {

    class Transform {

        public Transform parent;
        public Vector position;
        //public Quaternion rotation;
        //public GameObject gameObject;

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
