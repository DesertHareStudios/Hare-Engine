namespace HareEngine {

    public class Quaternion {

        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Quaternion() {
            this.x = 0f;
            this.y = 0f;
            this.z = 0f;
            this.w = 0f;
        }

        public Quaternion Conjugate {
            get {
                return new Quaternion(-x, -y, -z, w);
            }
        }

        public Quaternion Normalise() {
            float mag2 = w * w + x * x + y * y + z * z;
            if (Mathf.Abs(mag2 - 1.0f) > 0.00001f) {
                float mag = Mathf.Sqrt(mag2);
                w /= mag;
                x /= mag;
                y /= mag;
                z /= mag;
            }
            return this;
        }

        public static Quaternion operator +(Quaternion a, Quaternion b) {
            return new Quaternion(
                a.x + b.x,
                a.y + b.y,
                a.z + b.z,
                a.w + b.w
            );
        }

        public static Quaternion operator -(Quaternion a, Quaternion b) {
            return new Quaternion(
                a.x - b.x,
                a.y - b.y,
                a.z - b.z,
                a.w - b.w
            );
        }

        public static Quaternion operator *(Quaternion a, Quaternion b) {
            return new Quaternion(
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y + a.y * b.w + a.z * b.x - a.x * b.z,
                a.w * b.z + a.z * b.w + a.x * b.y - a.y * b.x,
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z
            );
        }

        public static Quaternion operator *(Quaternion a, float b) {
            return (new Quaternion(
                    a.x * b,
                    a.y * b,
                    a.z * b,
                    a.w * b
                )).Normalise();
        }

        public static Vector operator *(Quaternion q, Vector v) {
            Quaternion vecQuat = new Quaternion(v.Normal.x, v.Normal.y, v.Normal.z, 0f);
            Quaternion resQuat = new Quaternion();
            resQuat = q * (vecQuat* q.Conjugate);
            return new Vector(resQuat.x, resQuat.y, resQuat.z);
        }

        public static float Dot(Quaternion a, Quaternion b) {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        public static Quaternion Slerp(Quaternion a, Quaternion b, float t) {
            float dot = Dot(a, b);
            float theta = Mathf.Acos(dot);
            float sTheta = Mathf.Sin(theta);
            float w1 = Mathf.Sin((1.0f - t) * theta) / sTheta;
            float w2 = Mathf.Sin(t * theta) / sTheta;
            return a * w1 + b * w2;
        }

        public static Quaternion Lerp(Quaternion from, Quaternion to, float t) {
            return (from + (to - from) * t).Normalise();
        }
    }

}
