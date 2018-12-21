#include "param_processing.h"
#include "data_structures.h"

#define INFINITE 1000000
int hnumber=0;
int crucialPath(adjList &g)//关键路径
{   vertexNode_AdjList *p;
    vertexNode_AdjList *q;
    if(searchVertex(g, -1)==NULL){//判断无前驱结点的个数
	p=g;
	q=g;
    }
    if(searchVertex(g, -1)!=NULL){
    	p=g->next;
    	q=g->next;
	}
	edgeNode_AdjList *e;
    while(q->next!=NULL&&p!=NULL)
    {   
        if(p->ff==0)//如果p为关键路径上的节点 
        {   
            q=p->next;
            while(q->ff!=0)
            q=q->next;//去找到下一个关键路径上的点
            if(q!=NULL)//找到了，找连接两者的边
            {   
                e=p->nextEdge;
		        while(e->headId!=q->id&&e!=NULL)//
		            e=e->nextEdge;
                if(e==NULL)
                    return 0;//找不到边，报错 
                e->crucial=1;//找到边 修改crucial的值
                p=q;
            }   
            if (q==NULL)
                return 0;//如果找不到，报错 
       }
        else    
        p=p->next;
    }
    return 1;
}

int topologicalSort(adjList &g)
{   
	Stack s;
	int nodenum;
	nodenum=countNodeNumber(g);   /*统计结点数目*/
	Stack idsort;                    //静态结点排序数组
	InitStack(s);
    InitStack(idsort);                           /*初始化栈*/
    for(int id=1;id<nodenum; id++){//判断结点是否有前驱
    	vertexNode_AdjList *p=searchVertex(g, id) ;
    	if(p->inDegree==0){
    		hnumber++;
		}
	}
	if(hnumber>=2){//如果有两个以上无前驱结点，建立新节点并且连接
		vertexNode_AdjList *p=searchVertex(g,-1);
		p->id=0;
		for(int id=1;id<nodenum; id++){
    	vertexNode_AdjList *temp=searchVertex(g, id);
    	if(p->inDegree==0)
		{
    		appendEdge(g, 0, temp->id, false);
    		p->inDegree++;
		}
		if(temp->id==1){
			p->next=temp;
		}
	  }
	}
    if(searchVertex(g, 0)!=NULL){
    	Push(s,0);
	}
    for(int id=1; id<nodenum; id++)//无前驱结点入栈
	{
	    if(!searchVertex(g, id)->inDegree) 
		{
		Push(s,id);
		vertexNode_AdjList *p=searchVertex(g, id);
		p->ef=p->es+p->duration;
	    }
    }

	int count=0;                             
	while(StackEmpty(s)==0)                    //栈非空时
	{   
		int ID;
		Pop(s,ID); 
        Push(idsort,ID);             //ID号顶点入栈
        count++;                 //出栈，同时记录ID排序编号
		vertexNode_AdjList *p=searchVertex(g, ID) ;
        vertexNode_AdjList *nextp;
		edgeNode_AdjList *i; //找到编号ID的结点
		for(i=p->nextEdge; i; i=i->nextEdge)
		{   
			int k=i->headId;
            nextp=searchVertex(g,k);
			if(!(--(searchVertex(g, k)->inDegree))) Push(s,k);      //入度减为零的结点入栈
		    if(p->es+p->duration>=nextp->es) //计算每个节点的最早开始时间和最早结束时间
            {           
                nextp->es = p->es+p->duration;
                nextp->ef = nextp->es+nextp->duration;
            }
        }
	}//while
    for(vertexNode_AdjList *p=g->next; p; p=p->next)
    {   
        p->ls = INFINITE;
        p->ff = INFINITE;    //自由时差初始默认为无限大
    }//初始化每个节点的最迟开始时间，自由时差
    int tnumber=0; // tail vexnode number
	int maxlf=0; //多无后继节点的参数计算
    //利用拓扑逆序来计算剩余时间参数
    for(int id=1; id<nodenum; id++){
    	vertexNode_AdjList *temp;
    	temp=searchVertex(g, id);
    	if(temp->nextEdge==NULL)//count the vexnode which doesn't have nextedge
        {   tnumber++;
            if(maxlf<temp->es+temp->duration) maxlf=temp->es+temp->duration;
        }
	}
	 if(tnumber>=2){//多无后继节点时///if taill vex >=2
    	vertexNode_AdjList *tail;//建立新的尾节点并初始化
    	appendNode(g, nodenum, "END", 0, maxlf, 0, maxlf, maxlf, 0, maxlf, tnumber);
    	tail=searchVertex(g, nodenum);
    	for(int id=1; id<nodenum; id++){
    		vertexNode_AdjList *temp;
    		temp=searchVertex(g, id);
    		if(temp->nextEdge==NULL){
    			appendEdge(g, temp->id, tail->id, false);
			}//加入边的连接
			if(temp->id==nodenum-1){
				temp->next=tail;
			}//加入顺序连接表
		}
	}
	if(tnumber==1){//单个无后继节点时
		vertexNode_AdjList *tail;
		tail=searchVertex(g, nodenum-1);
		tail->ls = tail->es;
        tail->lf = tail->ls+tail->duration;
        tail->ff = 0;
        tail->tf = tail->duration;
	}
    while(StackEmpty(idsort)==0) //idsort非空时
    {      
        int idNumber;
        edgeNode_AdjList *e;
        vertexNode_AdjList *v;//当前节点
        vertexNode_AdjList *nextv;//当前节点的一个紧后节点
        Pop(idsort,idNumber);
        v=searchVertex(g,idNumber);
        if(v->nextEdge!=NULL) {//若v不为尾节点
            for(e=v->nextEdge;e;e=e->nextEdge)
            {
                int k=e->headId;
                nextv=searchVertex(g,k);
                if(nextv->ls-v->duration<v->ls)
                {
                    v->ls = nextv->ls-v->duration;
                    v->lf = v->ls+v->duration;
                    v->tf = v->duration;
                }//if   求ls  lf tf
                if(nextv->ls-v->lf<v->ff)         
                v->ff=nextv->ls-v->ef;//求最小的自由时差       
            }//for
        }
    }
	if(count<nodenum)            //有回路，报错
		return 0;                                     
	else 
    return 1;                                     
}