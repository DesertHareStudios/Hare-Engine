#pragma once

#include "..\GameObject.h"
#include "..\Physics\Vector.h"

class Transform {

public:
	Vector position;
	Transform* parent;
	GameObject* gameObject;
};