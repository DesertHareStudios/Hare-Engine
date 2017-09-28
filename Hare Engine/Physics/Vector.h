#pragma once

#include "..\Mathf.h"

class Vector {
public:
	float x;
	float y;
	float z;
	float w;
	float magnitude;

	Vector(float x, float y, float z, float w) {
		this->x = x;
		this->y = y;
		this->z = z;
		this->w = w;
		this->magnitude = 0;
	}
	Vector(float x, float y, float z) {
		this->x = x;
		this->y = y;
		this->z = z;
		this->w = 0.0;
		this->magnitude = 0;
	}
	Vector(float x, float y) {
		this->x = x;
		this->y = y;
		this->z = 0.0;
		this->w = 0.0;
		this->magnitude = 0;
	}
	Vector() {
		this->x = 0.0;
		this->y = 0.0;
		this->z = 0.0;
		this->w = 0.0;
		this->magnitude = 0;
	}
	Vector operator+(Vector);
	Vector operator-(Vector);
	Vector operator*(Vector);
	Vector operator/(Vector);
	Vector operator+=(Vector);
	Vector operator-=(Vector);
	Vector operator*=(Vector);
	Vector operator/=(Vector);

	static Vector interpolate(Vector from, Vector to, float t) {
		return Vector(
			from.x + (to.x - from.x) * t,
			from.y + (to.y - from.y) * t,
			from.z + (to.z - from.z) * t,
			from.w + (to.w - from.w) * t
		);
	}
};