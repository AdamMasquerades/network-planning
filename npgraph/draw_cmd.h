#pragma once

#include <string>
#include "data_structures.h"
#include "param_processing.h"
using namespace std;

struct edgeOutputParam
{
    string tail;
    string head;
    string crucial;
};

void draw_cmd(adjList);
string appendParamAsStr(string, int);
string appendParamAsStr(string, string);