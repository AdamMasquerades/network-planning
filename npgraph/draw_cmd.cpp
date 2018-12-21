#include "draw_cmd.h"
#include "data_structures.h"
#include "param_processing.h"
#include <stdlib.h>
#include <iostream>
using namespace std;
void draw_cmd(adjList g)
{   
    string command="python draw_aov.py";
    char* charcommand;
    int i=0;
    int vn=countNodeNumber(g);
    int en=countEdgeNumber(g);
    edgeOutputParam *edge = new edgeOutputParam[en+1];
    vertexNode_AdjList* vp=g;
    edgeNode_AdjList* ep;
    if (g->name=="Undefined") vn--;
    command=appendParamAsStr(command, vn);
    while(vp)
    {   
        ep=vp->nextEdge;
        while(ep)
        {
            edge[i].tail=vp->name;
            edge[i].head=searchVertex(g, ep->headId)->name;
            edge[i].crucial=(ep->crucial==1)?"1":"0";
            i++;
            ep=ep->nextEdge;
        }
        vp=vp->next;
    }
    vp=g;
    while(vp)
    {
        if (vp->name=="Undefined") 
        {
			vp=vp->next;
			continue;
		}
        command=appendParamAsStr(command, vp->name);
        command=appendParamAsStr(command, vp->es);
        command=appendParamAsStr(command, vp->tf);
        command=appendParamAsStr(command, vp->ef);
        command=appendParamAsStr(command, vp->ls);
        command=appendParamAsStr(command, vp->ff);
        command=appendParamAsStr(command, vp->lf);
        vp=vp->next;
    }
    command=appendParamAsStr(command, en);
    for(i=0;i<en;i++)
    {
        command=appendParamAsStr(command, edge[i].tail);
        command=appendParamAsStr(command, edge[i].head);
        command=appendParamAsStr(command, edge[i].crucial);
    }
    //cout<<command;
    charcommand=(char*)command.data();
    delete[] edge;
    system(charcommand);
    return;
}
string appendParamAsStr(string str, int a)
{
    char *ctemp;
    string stemp;
    itoa(a,ctemp,10);
    stemp=ctemp;
    str=str+" "+stemp;
    return str;
}
string appendParamAsStr(string str, string a)
{
    str=str+" "+a;
    return str;
}