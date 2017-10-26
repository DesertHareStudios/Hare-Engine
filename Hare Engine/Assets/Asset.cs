namespace HareEngine {

    public class Asset {

        private string fp;

        public string FilePath {
            get {
                return fp;
            }
        }

        public Asset(string filepath) {
            fp = filepath;
        }

    }

}
