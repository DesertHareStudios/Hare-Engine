namespace HareEngine {

    class Vector {

        public float x;
        public float y;
        public float z;
        public float w;
        public float magnitude;

        public Vector(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            magnitude = 0f;
        }

        public Vector(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 0f;
            magnitude = 0f;
        }
        public Vector(float x, float y) {
            this.x = x;
            this.y = y;
            this.z = 0f;
            this.w = 0f;
            magnitude = 0f;
        }
        public Vector() {
            this.x = 0f;
            this.y = 0f;
            this.z = 0f;
            this.w = 0f;
            magnitude = 0f;
        }

        public static Vector Lerp(Vector from, Vector to, float t) {
            return new Vector(
                from.x + (to.x - from.x) * t,
                from.y + (to.y - from.y) * t,
                from.z + (to.z - from.z) * t,
                from.w + (to.w - from.w) * t
            );
        }

        public static Vector operator +(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x + b.x;
            output.y = a.y + b.y;
            output.z = a.z + b.z;
            output.w = a.w + b.w;
            return output;
        }

        public static Vector operator -(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x - b.x;
            output.y = a.y - b.y;
            output.z = a.z - b.z;
            output.w = a.w - b.w;
            return output;
        }

        public static Vector operator *(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x * b.x;
            output.y = a.y * b.y;
            output.z = a.z * b.z;
            output.w = a.w * b.w;
            return output;
        }

        public static Vector operator /(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x / b.x;
            output.y = a.y / b.y;
            output.z = a.z / b.z;
            output.w = a.w / b.w;
            return output;
        }

    }

}
