namespace HareEngine {

    public class Physics {

        private static Physics instance;

        public static Physics Instance {
            get {
                if (instance == null) {
                    instance = new Physics();
                }
                return instance;
            }
        }

        public GravityType gravityType;
        public float GravityScale;
        public float G;

        private Physics() {
            GravityScale = 9.8f;
            gravityType = GravityType.Classic;
            G = 0.06673f;
        }

    }

    public enum GravityType {
        Classic,
        Newtonian
    }

}
