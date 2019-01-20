using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace _8Puzzle
{
    class Program
    {
        static Hashtable hashTable = new Hashtable();
        static SimplePriorityQueue<Table> heap = new SimplePriorityQueue<Table>();

        static Table goalTable;
        static Table startTable;

        static int spanTime = 0;

        static void Main(string[] args)
        {
            

            /*int[,] goal = new int[,]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,0 }
            };*/

            int[,] goal = new int[,]
            {
                {1,2,3 },
                {8,0,4 },
                {7,6,5 }
            };

            int[,] start = new int[,]
            {
                {5,4,0 },
                {6,1,8 },
                {7,3,2 }
            };

            goalTable = new Table(goal);
            startTable = new Table(start);

            Console.WriteLine("Spantime: Initial" + " | Priority: " + Priority(startTable));
            startTable.Print();
            hashTable.Add(startTable.Key, "");
            heap.Enqueue(startTable, Priority(startTable));
            Console.WriteLine("heap count: " + heap.Count);

            while (true)
            {

                Console.WriteLine(" Span " + heap.First.Key + " | Priority: " + heap.GetPriority(heap.First));

                Table tempHead = heap.First;
                heap.Dequeue();

                if (tempHead.CanMoveDown())
                {
                    Table tempTable = CloneTable(tempHead).MoveDown();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        if (CheckEnd(tempTable, tempHead)) break;
                    }

                }
                if (tempHead.CanMoveUp())
                {
                    Table tempTable = CloneTable(tempHead).MoveUp();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        if (CheckEnd(tempTable, tempHead)) break;
                    }

                }

                if (tempHead.CanMoveRight())
                {
                    Table tempTable = CloneTable(tempHead).MoveRight();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        if (CheckEnd(tempTable, tempHead)) break;
                    }

                }
                if (tempHead.CanMoveLeft())
                {
                    Table tempTable = CloneTable(tempHead).MoveLeft();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        if (CheckEnd(tempTable,tempHead)) break;
                    }

                }

                Console.WriteLine("Heap count: " + heap.Count);
            }

        }

        static bool CheckEnd(Table table , Table parent)
        {
            if (Priority(table) == 0 || table.Key == goalTable.Key)
            {
                Console.WriteLine(" [Goal] Spantime: " + spanTime + " | From Parent " + parent.Key);
                Console.ReadKey();

                return true;
            }
            else
            {
                return false;
            }

        }

        /*
        static void ShowPath(Table goalTable)
        {
            Table temp;
            while (true)
            {
                Console.WriteLine(hashTable[goalTable.Key]);


                temp = new Table();
            }
        }
        */

        static Table CloneTable(Table source)
        {
            int[,] newTable = new int[3, 3];
            Array.Copy(source.table, newTable, source.table.Length);
            
            return new Table(newTable);
        }

        static float Priority(Table table)
        {
            float sum = 0;

            /*
            sum += Taxicab(table.GetIndex(1).Item2, table.GetIndex(1).Item1, 0, 0);
            sum += Taxicab(table.GetIndex(2).Item2, table.GetIndex(2).Item1, 1, 0);
            sum += Taxicab(table.GetIndex(3).Item2, table.GetIndex(3).Item1, 2, 0);
            sum += Taxicab(table.GetIndex(8).Item2, table.GetIndex(8).Item1, 0, 1);

            sum += Taxicab(table.GetIndex(4).Item2, table.GetIndex(4).Item1, 2, 1);
            sum += Taxicab(table.GetIndex(7).Item2, table.GetIndex(7).Item1, 0, 2);
            sum += Taxicab(table.GetIndex(6).Item2, table.GetIndex(6).Item1, 1, 2);
            sum += Taxicab(table.GetIndex(5).Item2, table.GetIndex(5).Item1, 2, 2);
            */

            //12346578*
            
            sum += Taxicab(table.GetIndex(1).Item2, table.GetIndex(1).Item1, 0, 0);
            sum += Taxicab(table.GetIndex(2).Item2, table.GetIndex(2).Item1, 1, 0);
            sum += Taxicab(table.GetIndex(3).Item2, table.GetIndex(3).Item1, 2, 0);
            sum += Taxicab(table.GetIndex(4).Item2, table.GetIndex(4).Item1, 0, 1);
            sum += Taxicab(table.GetIndex(5).Item2, table.GetIndex(5).Item1, 1, 1);
            sum += Taxicab(table.GetIndex(6).Item2, table.GetIndex(6).Item1, 2, 1);
            sum += Taxicab(table.GetIndex(7).Item2, table.GetIndex(7).Item1, 0, 2);
            sum += Taxicab(table.GetIndex(8).Item2, table.GetIndex(8).Item1, 1, 2);
            

            //Console.WriteLine("      "+ sum);
            return sum;
        }

        static int Taxicab(int x1, int y1, int x2, int y2)
        {
            int result2;
            result2 = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return result2;
        }
    }
}
