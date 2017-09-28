#pragma once
#include <math.h>

class Mathf {
	public:
		static float toRadians(float degrees) {
			return degrees * (3.14159 / 180.0);
		}

		static float toDegrees(float radians) {
			return radians * (180.0 / 3.14159);
		}

		static float interpolate(float from, float to, float t) {
			return from + (to - from) * t;
		}
};