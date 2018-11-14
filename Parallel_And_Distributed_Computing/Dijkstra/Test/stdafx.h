// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

// Headers for CppUnitTest
#include "CppUnitTest.h"

// TODO: reference additional headers your program requires here
#include "../Dijkstra/random.h"
#include "../Dijkstra/Graph.h"
#include "../Dijkstra/Dijkstra.h"

// CONSTANTS
const int SMALL_SIZE = 100;
const int MIDDLE_SIZE = 500;
const int BIG_SIZE = 1000;

const int SMALL_THREAD = 2;
const int MIDDLE_THREAD = 4;
const int BIG_THREAD = 7;