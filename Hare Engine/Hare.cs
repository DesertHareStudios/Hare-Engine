namespace HareEngine {

    public class Hare {


        public static Color clearColor = new Color(0f, 0f, 0f);
        public static Window window;

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
            OpenTK.Toolkit.Init();
        }

        public static void Run() {
            window.Run(60);
        }

        public delegate void f();

    }

}
