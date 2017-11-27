using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace HareEngine {

    public class SpriteCollider : Collider {

        public SpriteCollider(GameObject gameObject) : base(gameObject) { }

        public override void Awake() {
            base.Awake();
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
        }

        public override Vector3[] GetVerts() {
            Vector3[] output = new Vector3[] {
                new Vector3(0.5f, -0.5f, 0f),
                new Vector3(0.5f, 0.5f, 0f),
                new Vector3(-0.5f, 0.5f, 0f),
                new Vector3(-0.5f, -0.5f, 0f)
            };
            VertCount = output.Length;
            return output;
        }
    }

}
