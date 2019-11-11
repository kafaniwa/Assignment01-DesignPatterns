#pragma once
#include "PluginSettings.h"
#include "SimpleClass.h"
#include "operationTracker.h"

#ifdef __cplusplus
extern "C"
{
#endif
	// Put your functions here
	PLUGIN_API int SimpleFunction();

	// operationTracker Functions
	PLUGIN_API void resetFile();
	PLUGIN_API void increTimer(float, int, bool);
	PLUGIN_API void saveToFile();
	PLUGIN_API void getFromFile();
	PLUGIN_API float retriTimer(int);

#ifdef __cplusplus
}
#endif