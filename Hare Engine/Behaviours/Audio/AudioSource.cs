using OpenTK.Audio.OpenAL;

namespace HareEngine {

    public class AudioSource : Behaviour {

        private bool isPlaying = false;

        public AudioClip clip;
        public bool loop = false;
        public bool doppler = false;
        public bool surround = false;

        public bool IsPlaying {
            get {
                return isPlaying;
            }
        }

        public AudioSource(GameObject gameObject) : base(gameObject) { }

        //TODO actually make a sound

        public void Play() { }
        public void Pause() { }
        public void Stop() { }

    }

}
