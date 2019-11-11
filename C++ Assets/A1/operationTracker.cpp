#include "operationTracker.h"

//ULM stuff
void operationTracker::resetFile()
{
	timerFileOut.open("UserLog.txt", std::ofstream::trunc);
	for (int i = 0; i <= 4; i++)
	{
		timerFileOut << 0 << " ";
	}
	timerFileOut.close();
}

void operationTracker::increTimer(float _deltaTime, int _index, bool _continuousSave)
{
	timerOut[_index] += _deltaTime;

	if (_continuousSave)
	{
		saveToFile();
	}
}

void operationTracker::saveToFile()
{
	timerFileOut.open("UserLog.txt", std::ofstream::trunc);
	for (int i = 0; i <= 4; i++)
	{
		timerFileOut << timerOut[i] << " ";
	}
	timerFileOut.close();
}

void operationTracker::getFromFile()
{
	timerFileIn.open("UserLog.txt");
	
	while (!timerFileIn.eof())
	{
		for (int i = 0; i <= 4; i++)
		{
			timerFileIn >> timerIn[i];
		}
	}
	timerFileIn.close();
}

float operationTracker::retriTimer(int _index)
{
	getFromFile();
	return timerIn[_index];
}