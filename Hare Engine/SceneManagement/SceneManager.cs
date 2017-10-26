using System.Collections.Generic;
using System.Linq;

namespace HareEngine.SceneManagement {

    public class SceneManager {

        private static List<Scene> scenes = new List<Scene>();

        public static int sceneCount {
            get {
                return scenes.Count;
            }
        }

        public static void LoadScene(string sceneName) {
            foreach (Scene s in scenes) {
                if (s.Name == sceneName) {
                    Hare.currentScene = s;
                    return;
                }
            }
        }

        public static void LoadScene(int i) {
            Scene s = sceneAt(i);
            if (s != null) {
                Hare.currentScene = s;
            }
        }

        public static Scene sceneAt(int i) {
            if (i > 0 && i < sceneCount) {
                return scenes.ElementAt(i);
            }
            return null;
        }

        public static void AddScene(Scene s) {
            scenes.Add(s);
        }

    }

}
