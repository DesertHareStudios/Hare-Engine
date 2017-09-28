#pragma once

#include "..\hare.h"

class Camera : Behaviour {

public:

	Vector pivot;

	void LateUpdate() {
		gluLookAt(
			transform->position.x, transform->position.y, transform->position.z, //Camera
			pivot.x, pivot.y, pivot.z, // Front
			0.0, 0.0, 0.0 // Up
		);
	}

};