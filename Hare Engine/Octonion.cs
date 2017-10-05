namespace HareEngine {

    class Octonion {

        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;

        public Octonion(float a, float b, float c, float d, float e, float f, float g, float h) {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
        }

        public Octonion(float a, float b, float c, float d) {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = 0f;
            this.f = 0f;
            this.g = 0f;
            this.h = 0f;
        }

        public Octonion() {
            this.a = 0f;
            this.b = 0f;
            this.c = 0f;
            this.d = 0f;
            this.e = 0f;
            this.f = 0f;
            this.g = 0f;
            this.h = 0f;
        }

        public static Octonion operator +(Octonion a, Octonion b) {
            return new Octonion(
                a.a + b.a,
                a.b + b.b,
                a.c + b.c,
                a.d + b.d,
                a.e + b.e,
                a.f + b.f,
                a.g + b.g,
                a.h + b.h
            );
        }

        public static Octonion operator -(Octonion a, Octonion b) {
            return new Octonion(
                a.a - b.a,
                a.b - b.b,
                a.c - b.c,
                a.d - b.d,
                a.e - b.e,
                a.f - b.f,
                a.g - b.g,
                a.h - b.h
            );
        }

        public static Octonion operator *(Octonion a, Octonion b) {
            return new Octonion(
                a.a * b.a - a.b * b.b - a.c * b.c - a.d * b.d - a.e * b.e - a.f * b.f - a.g * b.g - a.h * b.h,
                a.a * b.b + a.b * b.a + a.c * b.d - a.d * b.c + a.e * b.f - a.f * b.e - a.g * b.h + a.h * b.g,
                a.a * b.c - a.b * b.d + a.c * b.a + a.d * b.b + a.e * b.g + a.f * b.h - a.g * b.e - a.h * b.f,
                a.a * b.d + a.b * b.c - a.c * b.b + a.d * b.a + a.e * b.h - a.f * b.g + a.g * b.f - a.h * b.e,
                a.a * b.e - a.b * b.f - a.c * b.g - a.d * b.h + a.e * b.a + a.f * b.b + a.g * b.c + a.h * b.d,
                a.a * b.f + a.b * b.e - a.c * b.h + a.d * b.g - a.e * b.b + a.f * b.a - a.g * b.d + a.h * b.c,
                a.a * b.g + a.b * b.h + a.c * b.e - a.d * b.f - a.e * b.c + a.f * b.d + a.g * b.a - a.h * b.b,
                a.a * b.h - a.b * b.g + a.c * b.f + a.d * b.e - a.e * b.d - a.f * b.c + a.g * b.b + a.h * b.a
            );
        }

        public static Octonion operator /(Octonion a, Octonion b) {
            float denominator = b.a * b.a + b.b * b.b + b.c * b.c + b.d * b.d + b.e * b.e + b.f * b.f + b.g * b.g + b.h * b.h;
            return new Octonion(
                (+a.a * b.a + a.b * b.b + a.c * b.c + a.d * b.d + a.e * b.e + a.f * b.f + a.g * b.g + a.h * b.h) / denominator,
                (-a.a * b.b + a.b * b.a - a.c * b.d + a.d * b.c - a.e * b.f + a.f * b.e + a.g * b.h - a.h * b.g) / denominator,
                (-a.a * b.c + a.b * b.d + a.c * b.a - a.d * b.b - a.e * b.g - a.f * b.h + a.g * b.e + a.h * b.f) / denominator,
                (-a.a * b.d - a.b * b.c + a.c * b.b + a.d * b.a - a.e * b.h + a.f * b.g - a.g * b.f + a.h * b.e) / denominator,
                (-a.a * b.e + a.b * b.f + a.c * b.g + a.d * b.h + a.e * b.a - a.f * b.b - a.g * b.c - a.h * b.d) / denominator,
                (-a.a * b.f - a.b * b.e + a.c * b.h - a.d * b.g + a.e * b.b + a.f * b.a + a.g * b.d - a.h * b.c) / denominator,
                (-a.a * b.g - a.b * b.h - a.c * b.e + a.d * b.f + a.e * b.c - a.f * b.d + a.g * b.a + a.h * b.b) / denominator,
                (-a.a * b.h + a.b * b.g - a.c * b.f - a.d * b.e + a.e * b.d + a.f * b.c - a.g * b.b + a.h * b.a) / denominator
            );
        }

        public static Octonion operator *(Octonion a, float b) {
            return new Octonion(
                    a.a * b,
                    a.b * b,
                    a.c * b,
                    a.d * b,
                    a.e * b,
                    a.f * b,
                    a.g * b,
                    a.h * b
                );
        }

        public static float Dot(Octonion a, Octonion b) {
            return a.a * b.a + a.b * b.b + a.c * b.c + a.d * b.d + a.e * b.e +
                a.f * b.f + a.g * b.g + a.h * b.h;
        }

        public static Octonion Slerp(Octonion a, Octonion b, float t) {
            float dot = Dot(a, b);
            float theta = Mathf.Acos(dot);
            float sTheta = Mathf.Sin(theta);
            float w1 = Mathf.Sin((1.0f - t) * theta) / sTheta;
            float w2 = Mathf.Sin(t * theta) / sTheta;
            return a * w1 + b * w2;
        }

        public static Octonion Lerp(Octonion from, Octonion to, float t) {
            return new Octonion(
                    from.a + (to.a - from.a) * t,
                    from.b + (to.b - from.b) * t,
                    from.c + (to.c - from.c) * t,
                    from.d + (to.d - from.d) * t,
                    from.e + (to.e - from.e) * t,
                    from.f + (to.f - from.f) * t,
                    from.g + (to.g - from.g) * t,
                    from.h + (to.h - from.h) * t
                );
        }

    }

}
