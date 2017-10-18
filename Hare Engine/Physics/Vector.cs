namespace HareEngine {

    public class Vector {

        public float x;
        public float y;
        public float z;

        public Vector(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector(float x, float y) {
            this.x = x;
            this.y = y;
            this.z = 0f;
        }
        public Vector() {
            this.x = 0f;
            this.y = 0f;
            this.z = 0f;
        }

        public float Magnitude {
            get {
                return Mathf.Sqrt(
                        Mathf.Pow(x, 2) +
                        Mathf.Pow(y, 2) +
                        Mathf.Pow(z, 2)
                    );
            }
            set {
                Normalise();
                x *= value;
                y *= value;
                z *= value;
            }
        }

        public float Distance(Vector b) {
            return Mathf.Sqrt(
                Mathf.Pow(b.x - x, 2) +
                Mathf.Pow(b.y - y, 2) +
                Mathf.Pow(b.z - z, 2)
            );
        }

        public Vector Normalise() {
            float mag = Magnitude;
            x /= mag;
            y /= mag;
            z /= mag;
            return this;
        }

        public Vector Normal {
            get {
                return (new Vector(x, y, z)).Normalise();
            }
        }

        public static Vector Lerp(Vector from, Vector to, float t) {
            return from + (to - from) * t;
        }

        public static Vector operator +(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x + b.x;
            output.y = a.y + b.y;
            output.z = a.z + b.z;
            return output;
        }

        public static Vector operator -(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x - b.x;
            output.y = a.y - b.y;
            output.z = a.z - b.z;
            return output;
        }

        public static Vector operator *(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x * b.x;
            output.y = a.y * b.y;
            output.z = a.z * b.z;
            return output;
        }

        public static Vector operator /(Vector a, Vector b) {
            Vector output = new Vector();
            output.x = a.x / b.x;
            output.y = a.y / b.y;
            output.z = a.z / b.z;
            return output;
        }

        public static Vector operator *(Vector a, float b) {
            return new Vector(
                    a.x * b,
                    a.y * b,
                    a.z * b
                );
        }

        public static Vector operator /(Vector a, float b) {
            return new Vector(
                    a.x / b,
                    a.y / b,
                    a.z / b
                );
        }

        public static float Distance(Vector a, Vector b) {
            return Mathf.Sqrt(
                Mathf.Pow(b.x - a.x, 2) +
                Mathf.Pow(b.y - a.y, 2) +
                Mathf.Pow(b.z - a.z, 2)
            );
        }

        public Vector Rotated(Quaternion q) {
            return q * this;
        }

    }

}
