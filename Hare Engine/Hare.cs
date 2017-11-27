using System.Collections.Generic;

namespace HareEngine {

    public class Hare {

        public static List<GameObject> aboutToDestroy = new List<GameObject>();

        public static Window window;
        public static Color clearColor = new Color(0.5f, 0.5f, 0.5f);

        public static int vbo_position;
        public static int vbo_color;
        public static int vbo_mview;
        public static int ibo_elements;

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
            OpenTK.Toolkit.Init();
            Asset.AutoRead();
        }

        public static void Run() {
            window.Run(60);
        }

    }

}
