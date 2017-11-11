using System.Collections.Generic;

namespace HareEngine {

    public class Asset {

        private static List<Asset> assets;

        private string fp;

        public string FilePath {
            get {
                return fp;
            }
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

    }

}
