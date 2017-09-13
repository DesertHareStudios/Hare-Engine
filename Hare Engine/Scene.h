#pragma once

#include <string>
#include <vector>
#include <thread>
#include "GameObject.h"

class Scene {
public:
	std::string name;
	std::vector<GameObject*> gameObjects;

	Scene(std::string name) {
		this->name = name;
	}

	Scene() {
		this->name = "";
	}

	void Update() {
		std::vector<std::thread> threads;
		for (int i = 0; i < gameObjects.size(); i++) {
			for (int j = 0; j < gameObjects[i].behaviours.size(); j++) {
				std::thread update(gameObjects[i].behaviours[j].Update);
			}
		}
		for (int i = 0; i < threads.size(); i++) {
			threads[i].join();
		}
		LateUpdate();
	}

	void LateUpdate() {
		std::vector<std::thread> threads;
		for (int i = 0; i < gameObjects.size(); i++) {
			for (int j = 0; j < gameObjects[i].behaviours.size(); j++) {
				std::thread update(gameObjects[i].behaviours[j].Update);
			}
		}
		for (int i = 0; i < threads.size(); i++) {
			threads[i].join();
		}
	}

};