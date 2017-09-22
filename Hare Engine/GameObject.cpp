#include "Transform\Transform.h"
#include "Behaviour.h"
#include "GameObject.h"
#include "Physics\Vector.h"

GameObject::GameObject(std::string name) {
	this->name = name;
	behaviours.reserve(10);
}

void GameObject::addBehaviour(Behaviour* behaviour) {
	behaviour->gameObject = this;
	behaviour->transform = this->transform;
	behaviours.push_back(behaviour);
}

template <class T>
T* GameObject::getBehaviour() {
	for each(Behaviour* b in this->behaviours) {
		if (dynamic_cast<T*>(*b) != nullptr) {
			return b;
		}
	}
	return nullptr;
}