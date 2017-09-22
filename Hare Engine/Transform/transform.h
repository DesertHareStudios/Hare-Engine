#pragma once

#include "..\Physics\Vector.h"

class GameObject;

class Transform {

public:
	Vector position;
	Transform* parent;
	GameObject* gameObject;

	void Translate(Vector);
	void Translate(float, float);
	void Translate(float, float, float);
	void Translate(float, float, float, float);
};