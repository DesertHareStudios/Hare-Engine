namespace HareEngine {

    class Hare {

        public static Color clearColor = new Color(0.618f, 0.618f, 0.618f);
        public static Scene currentScene;
        public static Window window;

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
        }

    }

}
