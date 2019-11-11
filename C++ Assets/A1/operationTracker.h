#pragma once
#include "PluginSettings.h"
#include <iostream>
#include <fstream>
using namespace std;

class PLUGIN_API operationTracker
{
public:
	float timerOut[5] = { 0 };
	float timerIn[5] = { 0 };
	ofstream timerFileOut;
	ifstream timerFileIn;

	void resetFile();
	void increTimer(float, int, bool);
	void saveToFile();
	void getFromFile();
	float retriTimer(int);
};