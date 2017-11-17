using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HareEngine {

    public class Range {

        private float _value = 0f;
        public float Min = 0f;
        public float Max = 1f;

        public float Value {
            get {
                return _value;
            }
            set {
                _value = Mathf.Clamp(value, Min, Max);
            }
        }

        public Range() { }

        public Range(float min, float max) {
            Min = min;
            Max = max;
        }

        public Range(float value) {
            Min = -2 * value;
            Max = 2 * value;
            _value = value;
        }

        public Range(float min, float max, float value) {
            Min = min;
            Max = max;
            Value = value;
        }

    }

}
