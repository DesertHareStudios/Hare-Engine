#pragma once

#include "..\Physics\Vector.h"
#include "..\Quaternion.h";

class GameObject;

class Transform {

public:
	Vector position;
	Quaternion rotation;
	Transform* parent;
	GameObject* gameObject;

	void Translate(Vector);
	void Translate(float, float);
	void Translate(float, float, float);
	void Translate(float, float, float, float);
};