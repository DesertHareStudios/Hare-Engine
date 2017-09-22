/**
* Test file for Hare Engine, not part of Hare Engine itself
*/

#pragma once

#include "hare.h"

class TestBehaviour : public Behaviour {
	void Update() {
		std::cout << Time::deltaTime << "; testing " << gameObject->name << std::endl;
	}
};

int main(int argc, char** argv) {
	Scene scene = Scene("Test scene");
	GameObject go = GameObject("Test Object");
	TestBehaviour tb;
	go.addBehaviour(&tb);
	scene.gameObjects.push_back(&go);
	hare::currentScene = &scene;
	hare::init(argc, argv, "Hare Test");
	return 0;
}