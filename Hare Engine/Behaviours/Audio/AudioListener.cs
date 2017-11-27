using System.Collections.Generic;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System;
using OpenTK;

namespace HareEngine {

    public class AudioListener : Behaviour {

        private Rigidbody rb;
        private Vector3 lastPosition;
        private Vector3 speed;
        private Vector3 direction;

        public AudioListener(GameObject gameObject) : base(gameObject) { }
        
        public override void FixedUpdate() {
            lastPosition = transform.position;
            direction = transform.forward;
        }

        private void CalculateSpeed() {
            if (rb != null) {
                speed = rb.speed;
            } else {
                speed = transform.position - lastPosition;
            }
        }

        public void SendVelocityToAL() {
            AL.Listener(ALListener3f.Velocity, ref speed);
        }

    }

}
