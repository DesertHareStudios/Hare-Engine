using System.Collections.Generic;
using System.Linq;

namespace HareEngine {

    public class Hare {

        private static int sceneIndex = -1;

        public static Color clearColor = new Color(0.618f, 0.618f, 0.618f);
        public static Window window;
        public static List<Scene> scenes;

        public static Scene currentScene {
            get {
                if (sceneIndex > 0 && sceneIndex < scenes.Count()) {
                    return scenes.ElementAt(sceneIndex);
                } else {
                    return null;
                }
            }
        }

        public static void Init(int width, int height, string title) {
            window = new Window(width, height, title);
            OpenTK.Toolkit.Init();
            window.Run();
        }

    }

}
