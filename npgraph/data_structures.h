#pragma once

#include <string>

#define StackInitSize  10
#define StackIncrement 5
using namespace std;
//Adjcency List 邻接表 -- Shi Yuheng **********
struct edgeNode_AdjList             //邻接表边信息
{
    int headId;                     //此边指向的顶点的代号
    bool crucial;                   //是否在关键路径上
    struct edgeNode_AdjList* nextEdge;  //指向下一条边
};
struct vertexNode_AdjList           //邻接表头节点链表，即图中各顶点（工作项）
{
    int id;                         //该顶点代号
    string name;
    int duration;                   //持续时间
    int es,tf,ef,ls,ff,lf;          //最早开始时间，总时差，最早完成时间，最迟开始时间，自由时差，最迟完成时间
    int inDegree;
    vertexNode_AdjList* next;       //注意此顶点表不是数组而是链表，指向下一顶点
    edgeNode_AdjList* nextEdge;     //第一邻边
};
typedef vertexNode_AdjList* adjList;

adjList createAdjList();
//返回空的邻接表指针
void destroyAdjList(adjList &g);
//释放邻接表空间
void appendNode(adjList &g, int id, string name, int duration, int es=0, int tf=0, int ef=0, int ls=0, int ff=0, int lf=0, int inDegree=0,  vertexNode_AdjList *next=NULL, edgeNode_AdjList *firstEdge=NULL);
//根据参数将结点添加到g，注意默认参数
vertexNode_AdjList* searchVertex(adjList g, int id);
//寻找g中代号为id的结点，返回指向它的指针
void appendEdge(adjList g, int tailId, int headId, bool crucial=false, edgeNode_AdjList* nextEdge=NULL);
//根据参数添加g中tailId结点出发，指向代号为headId的边，注意默认参数
int countNodeNumber(adjList g);
int countEdgeNumber(adjList g);
int getId(adjList g, string name);
//*******************


// Stack
struct Stack
{
    int *base;
    int *top;
    int stacksize;
};

int InitStack(Stack &s);//初始化建立空栈
int Push(Stack &s,int e);//插入e为新的栈顶元素
int Pop(Stack &s,int &e);//删除栈顶元素，并且用e返回其值
int StackEmpty(Stack &s);//判断栈是否为空 空为1 非空为0