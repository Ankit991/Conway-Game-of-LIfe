using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    public const int row=6, column=6;
   
   
    //for Pause and resume of simulation of cell prefabs
    public bool onoff;
   
    public float speed;
    private float slow = 0f;

    Cells[,] grid=new Cells[row,column];
   
   
    void Start()
    {
      
        Demostratesize(row,column);
    }
    private void Update()
    {
      
        if (onoff)
        {
            if (slow >=speed)
            {
                slow = 0f;
                Neighbour();
                DefiningRules();
               
            }
            else
            {
                slow += Time.deltaTime;
            }
        }

        Inputs();
      
    }
    

   

    void Demostratesize(int x,int y)
    {
       for(int j = 0; j < x; j++)
        {
            for (int i = 0; i < y; i++)
            {
                int Randomness=Random.Range(1,10);
                
                    Cells cell = Instantiate(Resources.Load("A", typeof(Cells)), new Vector2(i, j), Quaternion.identity) as Cells;
                    grid[i, j] = cell;

                if (Randomness < 7)
                {
                    grid[i, j].setlive(true);
                }
                else
                {
                    grid[i, j].setDead(false);
                }
                
            }
        }
      
    }

    void Neighbour()
    {
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < column; x++)
            {

                int Countneighbour = 0;
             
                //east
                if (x + 1 < column)
                {
                    if (grid[x + 1, y].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //west
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //north
                if (y + 1 < row)
                {
                    if (grid[x, y + 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //south
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
               
                //North_East
                if (x + 1 < column && y + 1 < row)
                {

                    if (grid[x + 1, y + 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //East_South
                if (x + 1 <column && y - 1 >= 0)
                {

                    if (grid[x + 1, y - 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //South_West
                if (x - 1 >= 0 && y - 1 >=0)
                {

                    if (grid[x - 1, y - 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
                //North_West
                if (x - 1 >= 0 && y + 1 < row)
                {
                    if (grid[x - 1, y + 1].Alive)
                    {
                        Countneighbour++;
                    }
                }
                grid[x, y].neighbour = Countneighbour;
            }
        }
    }
    private void DefiningRules()
    {
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < column; x++)
            {
                if (grid[x, y].Alive)
                {
                    /*Rule 1
                       Any live cell with fewer than two live neighbors dies, as if by underpopulation.
                    */
                    if (grid[x, y].neighbour > 2)
                    {
                        grid[x, y].setDead(false);
                    }
                    /*Rule2
                         Any live cell with two or three live neighbors lives on to the next generation.
                     */
                    if (grid[x, y].neighbour == 2 || grid[x, y].neighbour == 3)
                    {
                        grid[x, y].setlive(true);
                    }

                    /*Rule 3
                       Any live cell with more than three live neighbors dies, as if by overpopulation.
                     */
                    if (grid[x, y].neighbour < 3)
                    {
                        grid[x, y].setDead(false);
                    }
                       
                }
                else
                {
                    /*Rule4
                    Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                    */
                    if (grid[x, y].neighbour == 3)
                    {
                        grid[x, y].setlive(true);
                    }
                }

            }
        }
    }
    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.RoundToInt(Mousepos.x);
            int y = Mathf.RoundToInt(Mousepos.y);

            if (x >= 0 && y >= 0 && x < row && y < column)
            {
                grid[x, y].setlive(!grid[x, y].Alive);
                grid[x, y].setDead(grid[x, y].Alive);
            }
        }
        #region Pause/Resume
        if (Input.GetKeyDown(KeyCode.S))
        {
            onoff = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onoff = true;
        }
        #endregion
    }
   
  
}
