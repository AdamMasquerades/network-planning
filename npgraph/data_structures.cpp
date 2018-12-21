#include "data_structures.h"
adjList createAdjList()
{
    adjList g=new vertexNode_AdjList;
    g->id=-1;
    g->name="Undefined";
    g->duration=0;
    g->es=0;
    g->tf=0;
    g->ef=0;
    g->ls=0;
    g->ff=0;
    g->lf=0;
    g->inDegree=0;
    g->next=NULL;
    g->nextEdge=NULL;
    return g;
}

void destroyAdjList(adjList &g)
{
    vertexNode_AdjList *p, *pre;
    p=g;
    while(p->next)
    {
        pre=p;
        p=p->next;
        delete pre;
    }
    return;
}

void appendNode(adjList &g, int id, string name, int duration, int es, int tf, int ef, int ls, int ff, int lf, int inDegree, vertexNode_AdjList *next, edgeNode_AdjList *firstEdge)
{
    vertexNode_AdjList *p=g;
    while(p->next)
        p=p->next;
    vertexNode_AdjList* v = new vertexNode_AdjList;
    v->id=id;
    v->name=name;
    v->duration=duration;
    v->es=es;
    v->tf=tf;
    v->ef=ef;
    v->ls=ls;
    v->ff=ff;
    v->lf=lf;
    v->inDegree=inDegree;
    v->next=next;
    v->nextEdge=firstEdge;
    p->next=v;
    return;
}

vertexNode_AdjList* searchVertex(adjList g ,int id) //在顶点链表（邻接表）中查找结点id
{
    vertexNode_AdjList *p=g;
    while(p)
    {
        if (p->id==id)
            return p;
        else p=p->next;
    }
    return NULL;
}

void appendEdge(adjList g, int tailId, int headId, bool crucial, edgeNode_AdjList* nextEdge)
{
    vertexNode_AdjList* vp=searchVertex(g, tailId);
    edgeNode_AdjList* ep=vp->nextEdge;
    edgeNode_AdjList* e=new edgeNode_AdjList;
    e->headId=headId;
    e->crucial=crucial;
    e->nextEdge=nextEdge;
    searchVertex(g, headId)->inDegree++;
    if (ep!=NULL)
    {
        while(ep->nextEdge!=NULL)
            ep=ep->nextEdge;
        ep->nextEdge=e;
    }
    else
    {
        vp->nextEdge=e;
    }
    return;
}

int countNodeNumber(adjList g)
{
    vertexNode_AdjList* p=g;
    int count=0;
    while(p)
    {
        count++;
        p=p->next;
    }
    return count;
}

int countEdgeNumber(adjList g)
{
    vertexNode_AdjList* vp=g;
    edgeNode_AdjList* ep;
    int count=0;
    while(vp)
    {
        ep=vp->nextEdge;
        while(ep)
        {
            ep=ep->nextEdge;
            count++;
        }
        vp=vp->next;
    }
    return count;
}

int getId(adjList g, string name)
{
    vertexNode_AdjList *p=g;
    while(p)
    {
        if (p->name==name)
            return p->id;
        else p=p->next;
    }
    return -1;
}

int InitStack(Stack &s)
{
    s.base=(int *)malloc(StackInitSize*sizeof(int));
    if(!s.base) 
    exit(0);
    s.top=s.base;
    s.stacksize=StackInitSize;
    return 1;
}

int StackEmpty(Stack &s)
{
     if(s.top==s.base)
     return 1;
     else
     return 0;
}

int Push(Stack &s, int e)
{
    if(s.top-s.base>=s.stacksize)
    {
        s.base=(int*)realloc(s.base,(s.stacksize+StackIncrement)*sizeof(int));
        if(!s.base) exit(0);
        s.top=s.base+s.stacksize;
        s.stacksize=s.stacksize+StackIncrement;
    }
    *s.top++=e;
   return 1;
}

int Pop(Stack &s, int &e)
{
    if (s.base==s.top)
    return 0;
    e=*--s.top;
    return 1;
}