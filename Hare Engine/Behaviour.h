#pragma once

class Transform;
class GameObject;

class Behaviour {

public:
	virtual void Awake() {}
	virtual void Start() {}
	virtual void Update() {}
	virtual void LateUpdate() {}
	GameObject* gameObject;
	Transform* transform;
};