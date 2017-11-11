using System.Collections.Generic;
using OpenTK.Audio.OpenAL;

namespace HareEngine {

    public class AudioListener : Behaviour {

        private static List<AudioListener> listeners = new List<AudioListener>();

        public AudioClip clip;

        public AudioListener(GameObject gameObject) : base(gameObject) { }

        public override void OnEnable() {
            listeners.Add(this);
        }

        public override void OnDisable() {
            listeners.Remove(this);
        }

        //TODO actually listen to audio

    }

}
