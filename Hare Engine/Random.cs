namespace HareEngine {

    class Random {

        private static int x = 1618;

        public static float Value {
            get {
                x = (314 * x + 7) % 1618;
                return (float)x / 1617f;
            }
        }

        public static float Range(float min, float max) {
            return (Value * (max - min)) + min;
        }

        public static bool Probably(float probability) {
            return Value <= probability;
        }

        public static bool Probably() {
            return Probably(1f / 2f);
        }

    }

}
