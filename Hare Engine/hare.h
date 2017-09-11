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

float Time::deltaTime = 0.0;
float Time::timeScale = 1.0;
Color hareClearColor = Color(0.618, 0.618, 0.618, 1.0);

void render(void) {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glClearColor(hareClearColor.r, hareClearColor.g, hareClearColor.b, hareClearColor.a);
	using namespace std::chrono;
	high_resolution_clock::time_point t1 = high_resolution_clock::now();

	//TODO: Render stuff
	
	high_resolution_clock::time_point t2 = high_resolution_clock::now();
	duration<double, std::milli> timeSpan = t2 - t1;
	glutSwapBuffers();
}

void hareInit(int argc, char **argv, std::string title) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutCreateWindow(title.c_str());
	glEnable(GL_DEPTH_TEST);
	glutDisplayFunc(render);
	glutMainLoop();
}