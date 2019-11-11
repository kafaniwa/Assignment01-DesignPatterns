#include "Wrapper.h"

SimpleClass simpleClass;
int SimpleFunction()
{
	return simpleClass.SimpleFunction();
}

operationTracker OperationTracker;
void resetFile()
{
	return OperationTracker.resetFile();
}
void increTimer(float _deltaTime, int _index, bool _continousSave)
{
	return OperationTracker.increTimer(_deltaTime, _index, _continousSave);
}
void saveToFile()
{
	return OperationTracker.saveToFile();
}
void getFromFile()
{
	return OperationTracker.getFromFile();
}
float retriTimer(int _index)
{
	return OperationTracker.retriTimer(_index);
}