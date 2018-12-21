#include "head.h"

int main()
{
	Node nodes;
	nodes.getdir();
	nodes.connect();
	nodes.read();
	nodes.select();
	cout << "selsected" << endl;
	nodes.send();
	return 0;
}

void Node::getdir()
{
	_getcwd(relativePath, 1000);
	
	return;
}

void Node::connect()
{
	CoInitialize(NULL);  
	   
	HRESULT hr = sqlSp.CreateInstance(_uuidof(Connection));
	if (FAILED(hr))     
	{
		cout << "Failed" << endl;
		return;
	}
	else
	{
		_bstr_t strConnect = "Provider=SQLOLEDB;Server=127.0.0.1;Database=master;uid=sa;pwd=123456789;";
		try 
		{ 
			sqlSp->Open(strConnect, "", "", adModeUnknown);
		}
		catch (_com_error &e) { 
			cout << e.Description() << endl;
		}
	}
	 
	if (FAILED(m_pRecordset.CreateInstance(_uuidof(Recordset))))
	{
		cout << "Failed" << endl;
		return;
	}
	try 
	{  
		m_pRecordset->Open("create table npg(itemID int, itemName varchar(100), itemDuration int not NULL, itemPrereq varchar(1000) DEFAULT NULL)", (IDispatch*)sqlSp, adOpenDynamic, adLockOptimistic,
			adCmdText);
	}
	catch (_com_error &e)  
	{
		cout << e.Description() << endl;
	}

}


void Node::read()
{
	string bcpStr = "exec master..xp_cmdshell 'bcp npg in " + string(relativePath) + "\\npdatabase.npdb -c -T'";
	bcpSql = bcpStr.c_str();
	cout << bcpSql;
	m_pRecordset = sqlSp->Execute(_bstr_t(bcpSql), NULL, adCmdText);
}

void Node::select()
{
	char buf[100];
	string exchange;
	ifstream infile(string(relativePath) + "\\dbquery.npdb", ios::in);
	infile.getline(buf, 1000, '\n');
	exchange = buf;
	selSql = exchange.c_str();
	cout << selSql;
	infile.close();
	m_pRecordset = sqlSp->Execute(_bstr_t(selSql), NULL, adCmdText);

	ofstream outfile(string(relativePath)+"\\dbquery.npdb", ios::out);  
	while (!m_pRecordset->adoEOF) 
	{
		 string ID = (char*)(_bstr_t)(m_pRecordset->Fields->GetItem(_variant_t("itemID"))->Value);
		 string Name = (char*)(_bstr_t)(m_pRecordset->Fields->GetItem(_variant_t("itemName"))->Value);
		 string Duration = (char*)(_bstr_t)(m_pRecordset->Fields->GetItem(_variant_t("itemDuration"))->Value);
		 string Prerequisite = (char*)(_bstr_t)(m_pRecordset->Fields->GetItem(_variant_t("itemPrereq"))->Value);
	
		 outfile<< ID << "\t" << Name << "\t" << Duration << "\t" << Prerequisite << endl;
		m_pRecordset->MoveNext(); 
	}
	outfile.close();  
	
	}

void Node::send()
{
	delSql = "drop table npg";
	m_pRecordset = sqlSp->Execute(_bstr_t(delSql), NULL, adCmdText);
	ofstream outfile(string(relativePath) + "\\QuerySuccess", ios::out);
	outfile.close();
}
