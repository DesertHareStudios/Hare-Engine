#pragma once

class Behaviour {

public:
	void Awake();
	void Start();
	void Update();
	void LateUpdate();
	Transform* transform;
	GameObject* gameObject;

};