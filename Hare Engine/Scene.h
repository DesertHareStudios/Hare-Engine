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
		threads.reserve(gameObjects.size() * 10);
		try {
			for (int i = 0; i < gameObjects.size(); i++) {
				for (int j = 0; j < gameObjects[i]->behaviours.size(); j++) {
					threads.push_back(std::thread([&] {
						try {
							gameObjects[i]->behaviours[j]->Update();
						} catch (...) {}
					}));
				}
			}
		} catch (...) {}
		for (int i = 0; i < threads.size(); i++) {
			threads[i].join();
		}
		LateUpdate();
	}

	void LateUpdate() {
		std::vector<std::thread> threads;
		threads.reserve(gameObjects.size() * 10);
		try {
			for (int i = 0; i < gameObjects.size(); i++) {
				for (int j = 0; j < gameObjects[i]->behaviours.size(); j++) {
					threads.push_back(std::thread([&] {
						try {
							gameObjects[i]->behaviours[j]->LateUpdate();
						} catch (...) {}
					}));
				}
			}
		} catch (...) {}
		for (int i = 0; i < threads.size(); i++) {
			threads[i].join();
		}
	}

};