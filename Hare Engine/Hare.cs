namespace HareEngine {

    public class Hare {

        public static Window window;
        public static Color clearColor = new Color(0.5f, 0.5f, 0.5f);

        public static int vbo_position;
        public static int vbo_color;
        public static int vbo_mview;
        public static int ibo_elements;

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
            OpenTK.Toolkit.Init();
        }

        public static void Run() {
            window.Run(60);
        }

    }

}
