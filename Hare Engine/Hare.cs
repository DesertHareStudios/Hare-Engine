namespace HareEngine {

    public class Hare {

        private static Scene _currentScene;

        public static Color clearColor = new Color(0f, 0f, 0f);
        public static Window window;
        public static Scene currentScene {
            get {
                return _currentScene;
            }
            set {
                _currentScene = value;
                if (window != null) {
                    window.ReloadScene();
                }
            }
        }

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
            OpenTK.Toolkit.Init();
            window.Run(60);
        }

        public delegate void f();

    }

}
