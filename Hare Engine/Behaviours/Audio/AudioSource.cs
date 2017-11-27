using OpenTK;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace HareEngine {

    public class AudioSource : Behaviour {

        public AudioClip clip;
        public bool playOnSpawn = true;
        public bool loop = false;
        public bool doppler = false;
        public bool surround = false;

        private Rigidbody rb;
        private Vector3 lastPosition;
        private Vector3 speed;
        private Vector3 direction;

        public bool IsPlaying { get; protected set; }
        public int Source { get; protected set; }
        public int Buffer { get; protected set; }
        public ALSourceState State {
            get {
                int output;
                AL.GetSource(Source, ALGetSourcei.SourceState, out output);
                return (ALSourceState)output;
            }
        }

        public void CalculateSpeed() {
            if (rb != null) {
                speed = rb.speed;
            } else {
                speed = transform.position - lastPosition;
            }
        }

        public AudioSource(GameObject gameObject) : base(gameObject) {
            Source = AL.GenSource();
            Buffer = AL.GenBuffer();
        }

        public override void Start() {
            rb = GetComponent<Rigidbody>();
            lastPosition = transform.position;
            direction = transform.forward;
            if (playOnSpawn) {
                Play();
            }
        }

        public override void FixedUpdate() {
            lastPosition = transform.position;
            direction = transform.forward;
        }

        public void Play() {
            AL.SourcePlay(Source);
        }

        public void Pause() {
            AL.SourcePause(Source);
        }
        public void Stop() {
            AL.SourceStop(Source);
        }

        public void SendToBuffer(AudioListener listener) {
            AL.BindBufferToSource(Source, Buffer);
            AL.BufferData(Buffer, clip.SoundFormat, clip.SoundData, clip.SoundData.Length, clip.SampleRate);
            AL.Source(Source, ALSourcei.Buffer, Buffer);
            AL.Source(Source, ALSourceb.Looping, loop);
            if (surround) {
                AL.Listener(ALListener3f.Position, ref listener.transform.position);
                AL.Source(Source, ALSource3f.Position, ref transform.position);
            }
            if (doppler) {
                CalculateSpeed();
                listener.SendVelocityToAL();
                AL.Source(Source, ALSource3f.Velocity, ref speed);
                AL.Source(Source, ALSource3f.Direction, ref direction);
            }
        }

    }

}
