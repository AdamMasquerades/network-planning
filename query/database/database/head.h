#include <icrsint.h> 
#include <iostream> 
#include <iomanip> 
#include <string> 
#include <fstream>
#include <direct.h>

using namespace std;

#import "C:\\program files\\common files\\system\\ado\\msado15.dll" no_namespace rename("EOF", "adoEOF") 

class Node
{
public:
	int ID[10]; 
	string Name[10]; 
	int Duration[10]; 
	string Prerequisite[10]; 

	void getdir();
	void connect();
	void read();
	void select();
	void send();

	Node(){}
   ~Node(){}

private:
	_RecordsetPtr m_pRecordset;
	_ConnectionPtr  sqlSp;
	const char* bcpSql;
	const char* delSql;
	const char* selSql;
	char relativePath[1000];
};

