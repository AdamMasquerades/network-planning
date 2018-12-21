#include "draw_cmd.cpp"
#include "data_structures.cpp"
#include "param_processing.cpp"
#include "file_readin.cpp"
int main()
{
    adjList g=createAdjList();
    readInFromFile(g);
    topologicalSort(g);
    crucialPath(g);
    draw_cmd(g);
    destroyAdjList(g);
    return 0;
}