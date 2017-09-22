#include "Transform.h"
#include "..\Behaviour.h"
#include "..\GameObject.h"


void Transform::Translate(Vector vector) {
	this->position.x += vector.x;
	this->position.y += vector.y;
	this->position.z += vector.z;
	this->position.w += vector.w;
}

void Transform::Translate(float x, float y) {
	this->position.x += x;
	this->position.y += y;
}

void Transform::Translate(float x, float y, float z) {
	this->position.x += x;
	this->position.y += y;
	this->position.z += z;
}

void Transform::Translate(float x, float y, float z, float w) {
	this->position.x += x;
	this->position.y += y;
	this->position.z += z;
	this->position.w += w;
}