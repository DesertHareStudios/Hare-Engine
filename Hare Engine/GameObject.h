#pragma once

#include <vector>
#include <string>
#include "Transform\transform.h"
#include "Behaviour.h"

class GameObject {

public:
	std::string name;
	std::string tag;
	Transform* transform;
	std::vector<Behaviour*> behaviours;

	GameObject(std::string name) {
		this->name = name;
		behaviours.reserve(10);
	}

	void addBehaviour(Behaviour* behaviour) {
		behaviour->gameObject = this;
		behaviour->transform = this->transform;
		behaviours.push_back(behaviour);
	}

	template <type B>
	Behaviour* getBehaviour<B>() {
		for (int i = 0; i < behaviours.size(); i++) {
			if (dynamic_cast<B*>(*behaviour[i]) != nullptr) {
				return behaviour[i];
			}
		}
		return nullptr;
	}
};