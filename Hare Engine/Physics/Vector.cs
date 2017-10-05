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

        public float Distance(Vector b) {
            return Mathf.Sqrt(
                Mathf.Pow(b.x - x, 2) +
                Mathf.Pow(b.y - y, 2) +
                Mathf.Pow(b.z - z, 2) +
                Mathf.Pow(b.w - w, 2)
            );
        }

        public static Vector Lerp(Vector from, Vector to, float t) {
            return from - (to - from) * t;
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

        public static Vector operator *(Vector a, float b) {
            return new Vector(
                    a.x * b,
                    a.y * b,
                    a.z * b,
                    a.w * b
                );
        }

        public static Vector operator /(Vector a, float b) {
            return new Vector(
                    a.x / b,
                    a.y / b,
                    a.z / b,
                    a.w / b
                );
        }

        public static float Distance(Vector a, Vector b) {
            return Mathf.Sqrt(
                Mathf.Pow(b.x - a.x, 2) +
                Mathf.Pow(b.y - a.y, 2) +
                Mathf.Pow(b.z - a.z, 2) +
                Mathf.Pow(b.w - a.w, 2)
            );
        }

    }

}
