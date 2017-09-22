#pragma once

#include <vector>
#include <string>

class Transform;
class Behaviour;

class GameObject {

public:
	std::string name;
	std::string tag;
	Transform* transform;
	std::vector<Behaviour*> behaviours;

	GameObject(std::string name);

	void addBehaviour(Behaviour* behaviour);

	template <class T>
	T* getBehaviour();
};