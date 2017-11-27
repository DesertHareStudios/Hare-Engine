using System.Collections.Generic;
using System.IO;

namespace HareEngine {

    public class Asset {

        private static List<Asset> assets = new List<Asset>();

        private string fp;

        public string FilePath {
            get {
                return fp;
            }
        }

        public delegate void AssetListener(Asset a);
        public static void ForEachAsset(AssetListener a) {
            foreach (Asset asset in assets) {
                a?.Invoke(asset);
            }
        }


        public delegate void AssetListener<T>(T a) where T : Asset;
        public static void ForEachAsset<T>(AssetListener<T> a) where T : Asset {
            foreach (Asset asset in assets) {
                if (asset.GetType() == typeof(T)) {
                    a?.Invoke((T)asset);
                }
            }
        }

        public static void Clear() {
            assets.Clear();
        }

        public string Name { get; protected set; }

        public Asset(string filepath, string name) {
            fp = filepath;
            Name = name;
            if (assets == null) {
                assets = new List<Asset>();
            }
            assets.Add(this);
        }

        public static Asset Get(string name) {
            foreach (Asset a in assets) {
                if (a.Name == name) {
                    return a;
                }
            }
            return null;
        }

        public static T Get<T>(string name) where T : Asset {
            foreach (Asset a in assets) {
                if (a.Name == name && (a.GetType() == typeof(T) || a.GetType().IsSubclassOf(typeof(T)))) {
                    return (T)a;
                }
            }
            return null;
        }

        public static void AutoRead(string path) {
            assets.Clear();
            RecursiveRead(path);
        }

        public static void AutoRead() {
            AutoRead(Directory.GetCurrentDirectory() + "\\Assets\\");
        }

        private static void RecursiveRead(string path) {
            if (Directory.Exists(path)) {
                string[] subdirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                foreach (string rs in subdirs) {
                    string[] ss = rs.Split('\\');
                    string s = ss[ss.Length - 1];
                    RecursiveRead(path + s);
                }
                foreach (string file in files) {
                    string[] ss = file.Split('\\');
                    string s = ss[ss.Length - 1];
                    string[] sParts = s.Split('.');
                    string extension = (sParts[sParts.Length - 1]).ToLower();
                    string name = "";
                    for (int i = 0; i < sParts.Length - 1; i++) {
                        name += sParts[i];
                        if (i < sParts.Length - 2) {
                            name += ".";
                        }
                    }
                    switch (extension) {
                        case "png":
                        case "bmp":
                            Texture tex = new Texture(file, name);
                            break;
                        //case "mp3":
                        case "ogg":
                        case "wav":
                            AudioClip audio = new AudioClip(file, name);
                            break;
                        case "glsl":
                            //TODO load shaders
                            break;
                    }
                }
            }
        }

    }

}
