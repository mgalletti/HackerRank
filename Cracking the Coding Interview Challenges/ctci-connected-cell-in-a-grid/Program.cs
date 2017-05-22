using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[][] grid = new int[n][];
        for(int grid_i = 0; grid_i < n; grid_i++){
           string[] grid_temp = Console.ReadLine().Split(' ');
           grid[grid_i] = Array.ConvertAll(grid_temp,Int32.Parse);
        }
        RegionCounter counter = new RegionCounter(grid, n, m);
        Console.Write(counter.Analize().ToString());
    }
}

class RegionCounter
{
    int[][] matrix;
    int width;
    int height;
    
    public RegionCounter(int[][] m, int w, int h) {
        matrix = m;
        width = w;
        height = h;
        regionCount = new SortedSet<int>();
    }
    
    private string GetKey(int x, int y) {
        return string.Format("{0}{1}", x, y);
    }
    
    private bool DFS(int x, int y, ref int count, HashSet<string> visited) {
        string key = GetKey(x, y);
        if (visited.Contains(key) || x >= width || y >= height || x < 0 || y < 0)
            return false;
        
        visited.Add(key);
        if (matrix[x][y] == 1) {
            count++;
            DFS(x + 1, y, ref count, visited);
            DFS(x, y + 1, ref count, visited);
            DFS(x + 1, y + 1, ref count, visited);
            DFS(x - 1, y, ref count, visited);
            DFS(x - 1, y - 1, ref count, visited);
            DFS(x, y - 1, ref count, visited);
            DFS(x + 1, y -1, ref count, visited);
            DFS(x - 1, y + 1, ref count, visited);
            return true;
        }
        else
            return false;
            
    }
    
    private SortedSet<int> regionCount;
    
    public int Analize() {
        int count = 0;
        HashSet<string> visited = new HashSet<string>();
        for (int i=1; i<width-1; i++) {
            for (int j=1; j<height-1; j++) {
                if (DFS(i, j, ref count, visited)) {
                    if (!regionCount.Contains(count))
                        regionCount.Add(count);
                    count = 0;
                }
            }
        }
        return regionCount.Max;
    }
}