#pragma once

#include "Transform\transform.h"
#include "Behaviour.h"
#include <vector>

class GameObject {

public:
	Transform* transform;

	GameObject() {
		behaviours.reserve(10);
	}

private:
	std::vector<Behaviour> behaviours;
};