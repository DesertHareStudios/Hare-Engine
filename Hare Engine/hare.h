#pragma once

#include <GL\glew.h>
#include <GL\freeglut.h>
#include <iostream>
#include <string>

#include "Time.h"
#include "Mathf.h"
#include "Physics\Vector.h"
#include "Color\color.h"
#include "Input.h"
#include "GameObject.h"
#include "Transform\transform.h"
#include "Behaviour.h"
#include "Scene.h"

namespace hare {

	Color clearColor = Color(0.618, 0.618, 0.618, 1.0);
	Scene* currentScene;

	void render(void) {
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glClearColor(clearColor.r, clearColor.g, clearColor.b, clearColor.a);
		using namespace std::chrono;
		high_resolution_clock::time_point t1 = high_resolution_clock::now();

		currentScene->Update();

		high_resolution_clock::time_point t2 = high_resolution_clock::now();
		duration<double> timeSpan = t2 - t1;
		Time::deltaTime = timeSpan.count();
		glutSwapBuffers();
	}

	void init(int argc, char **argv, std::string title) {
		glutInit(&argc, argv);
		glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
		glutCreateWindow(title.c_str());
		glEnable(GL_DEPTH_TEST);
		glutDisplayFunc(render);
		glutMainLoop();
	}

}