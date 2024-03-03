using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BackTracking
{
    internal class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            bool result = false;
            int row = board.Length;
            int col = board[0].Length;
            bool[,] visited = new bool[row,col];
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        visited[i,j] = true;
                        result = result || Exist(board, word, 1, visited, i, j, row, col);
                        visited[i, j] = false;
                    }
                }
            }
            return result;
        }

        private bool Exist(char[][] board, string word, int index, bool[,] visited, int row, int col, int maxRow, int maxCol)
        {
            if (index == word.Length) return true;
            bool result = false;
            // going left 
            if(row - 1 >= 0 && !visited[row - 1, col] && word[index] == board[row - 1][col])
            {
                visited[row - 1, col] = true;
                result = result || Exist(board, word, index + 1, visited, row - 1, col, maxRow, maxCol);
                visited[row - 1, col] = false;
            }
            // going right 
            if (row + 1 < maxRow && !visited[row + 1, col] && word[index] == board[row + 1][col])
            {
                visited[row + 1, col] = true;
                result = result || Exist(board, word, index + 1, visited, row + 1, col, maxRow, maxCol);
                visited[row + 1, col] = false;
            }
            // going up 
            if (col - 1 >= 0 && !visited[row, col - 1] && word[index] == board[row][col - 1])
            {
                visited[row, col - 1] = true;
                result = result || Exist(board, word, index + 1, visited, row, col - 1, maxRow, maxCol);
                visited[row, col - 1] = false;
            }
            // going down 
            if (col + 1 < maxCol && !visited[row, col + 1] && word[index] == board[row][col + 1])
            {
                visited[row, col + 1] = true;
                result = result || Exist(board, word, index + 1, visited, row, col + 1, maxRow, maxCol);
                visited[row, col + 1] = false;
            }
            return result;

        }



       
    }
}
