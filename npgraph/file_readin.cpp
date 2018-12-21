#include "file_readin.h"
using namespace std;
void readInFromFile(adjList &g)
{
	string lineBuffer;
	string fileName;
	int i, startNodeNum;
	string id, name, duration, prereq;
    ifstream fin;
	fin.open("fileName");
	getline(fin, fileName);
	//cout<<fileName;
	fin.close();
    fin.open(fileName);
	startNodeNum=0;
    while(!fin.eof())
    {
    	i=1;
	    getline(fin, lineBuffer);
	    id="";
	    while(lineBuffer[i]!=' ')
	    {
	    	id=id+lineBuffer[i];
	    	i++;
		}
		i++;
		name="";
	    while(lineBuffer[i]!=' ')
	    {
	    	name=name+lineBuffer[i];
	    	i++;
		}
		i++;
		duration="";
	    while(lineBuffer[i]!=' ')
	    {
	    	duration=duration+lineBuffer[i];
	    	i++;
		}
		i++;
		prereq="";
	    while(lineBuffer[i]!='\0')
	    {
	    	prereq=prereq+lineBuffer[i];
	    	i++;
		}

		appendNode(g,atoi((char*)id.data()),name,atoi((char*)duration.data()));
		//cout<<"appendNode(g, "<<atoi((char*)id.data())<<", "<<name<<", "<<atoi((char*)duration.data())<<");"<<endl;
		if (prereq=="")
		{
			startNodeNum++;
			if (startNodeNum>2)
			{
				//cout<<"appendEdge(g, "<<0<<", "<<atoi((char*)id.data())<<");"<<endl;
				appendEdge(g, 0, atoi((char*)id.data()));
			}
			if (startNodeNum==2)
			{
				g->name="START";
				g->id=0;
				//cout<<"appendEdge(g, "<<0<<", 1);"<<endl;
				//cout<<"appendEdge(g, "<<0<<", "<<atoi((char*)id.data())<<");"<<endl;
				appendEdge(g, 0, 1);
				appendEdge(g, 0, atoi((char*)id.data()));
			}
		}
		else
		{
			string prereqItem="";
			prereq+=',';
			for(int j=0;j<prereq.size();j++)
			{
				if (prereq[j]==',')
				{
					appendEdge(g, getId(g,prereqItem), atoi((char*)id.data()));
					//cout<<"appendEdge(g, "<<prereqItem<<", "<<atoi((char*)id.data())<<");"<<endl;
					prereqItem="";
				}
				else
				{
					prereqItem+=prereq[j];
				}
			}
		}
	}
    fin.close();
	return;
}