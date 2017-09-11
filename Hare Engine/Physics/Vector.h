#pragma once

#include "..\Mathf.h"

class Vector {
public:
	float x;
	float y;
	float z;
	float w;
	float magnitude;

	Vector(float, float, float, float);
	Vector(float, float, float);
	Vector(float, float);
	Vector();
	Vector operator+(Vector);
	Vector operator-(Vector);
	Vector operator*(Vector);
	Vector operator/(Vector);
};