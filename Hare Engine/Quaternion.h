#pragma once

#include "Physics\Vector.h";

class Quaternion {
private:
	Vector vector;
	float w;
public:

	Quaternion() {
		this->w = 0.0;
	}
	Quaternion(float x, float y, float z, float w) {
		this->vector = Vector(x, y, z);
		this->w = w;
	}
	Quaternion(Vector vector, float w) {
		this->vector = vector;
		this->w = w;
	}

	void normalize() {
		float magnitude = 1.0;
		w /= magnitude;
		vector.x /= magnitude;
		vector.y /= magnitude;
		vector.z /= magnitude;
	}

	Quaternion operator*(Quaternion q) {
		return Quaternion(
			this->w * q.vector.x + this->vector.x * q.w + this->vector.y * q.vector.z - this->vector.z * q.vector.y,
			this->w * q.vector.y - this->vector.x * q.vector.z + this->vector.y * q.w + this->vector.z * q.vector.x,
			this->w * q.vector.z + this->vector.x * q.vector.y - this->vector.y * q.vector.x + this->vector.z * q.w,
			this->w * q.w - this->vector.x * q.vector.x - this->vector.y * q.vector.y - this->vector.z * q.vector.z
		);
	}

	Quaternion operator*=(Quaternion q) {
		return *this * q;
	}
};