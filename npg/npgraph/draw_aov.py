import sys
from graphviz import Digraph

g=Digraph('G', filename='aov.gv', node_attr={'shape': 'record'})
g.attr(rankdir='LR')

def vertex(graph, name, es, tf, ef, ls, ff, lf):
    graph.node(name, r'%s%s%d%s%d%s%d%s%d%s%d%s%d%s'%(name,'|{',es,'|',tf,'|',ef,'}|{',ls,'|',ff,'|',lf,'}'))

'''
sys.argv[]:
0         1       7k-5        7k-4      ... 7k+1      ... 2+7nodeNum  7N+3k
$filename nodeNum node(k)name node(k)es ... node(k)lf ... edgeNum     edge(k)Tail
eg: python draw_aov.py 2 a 1 2 3 4 5 6 b 6 5 4 3 2 1 2 a b 0 b a 1
'''

if __name__=="__main__":
    nodeNum=eval(sys.argv[1])
    for nodei in range(1,nodeNum+1):
        nname=sys.argv[7*nodei-5]
        nes=eval(sys.argv[7*nodei-4])
        ntf=eval(sys.argv[7*nodei-3])
        nef=eval(sys.argv[7*nodei-2])
        nls=eval(sys.argv[7*nodei-1])
        nff=eval(sys.argv[7*nodei])
        nlf=eval(sys.argv[7*nodei+1])
        vertex(g, nname, nes, ntf, nef, nls, nff, nlf)
    edgeNum=eval(sys.argv[2+7*nodeNum])
    for edgei in range(1, edgeNum+1):
        edgeTail=7*nodeNum+3*edgei
        crucial=eval(sys.argv[edgeTail+2])
        if crucial==0:
            g.edge(sys.argv[edgeTail], sys.argv[edgeTail+1], _attributes={'penwidth':'1', 'arrowsize':'0.8'})
        if crucial==1:
            g.edge(sys.argv[edgeTail], sys.argv[edgeTail+1], _attributes={'penwidth':'4', 'arrowsize':'1.3'})
    g.render(view=True, format='png', cleanup=True)