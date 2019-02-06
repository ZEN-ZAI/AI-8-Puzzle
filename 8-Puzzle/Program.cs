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
            
            int[,] goal = new int[,]
            {
                {1,2,3 },
                {4,8,6 },
                {5,7,0 }
            };

            /*
            int[,] goal = new int[,]
            {
                {1,2,3 },
                {8,0,4 },
                {7,6,5 }
            };*/

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
            hashTable.Add(startTable.Key, null);
            heap.Enqueue(startTable, Priority(startTable));

            //Console.WriteLine("heap count: " + heap.Count);

            Search();
            Console.WriteLine("\n - Show path - \n");
            ShowPath();

            Console.WriteLine(" - Finish - ");
            Console.ReadKey();
        }

        static void Search()
        {
            while (heap.First.Key != goalTable.Key)
            {

                //Console.WriteLine(" Span " + heap.First.Key + " | Priority: " + heap.GetPriority(heap.First));

                Table tempHead = heap.First;
                heap.Dequeue();

                if (tempHead.CanMoveDown())
                {
                    Table tempTable = CloneTable(tempHead).MoveDown();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | State: " + tempTable.Key + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        //tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        CheckEnd(tempTable, tempHead);
                    }

                }
                if (tempHead.CanMoveUp())
                {
                    Table tempTable = CloneTable(tempHead).MoveUp();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | State: " + tempTable.Key + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        //tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        CheckEnd(tempTable, tempHead);
                    }

                }

                if (tempHead.CanMoveRight())
                {
                    Table tempTable = CloneTable(tempHead).MoveRight();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | State: " + tempTable.Key + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        //tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        CheckEnd(tempTable, tempHead);
                    }

                }
                if (tempHead.CanMoveLeft())
                {
                    Table tempTable = CloneTable(tempHead).MoveLeft();

                    if (tempTable.Key != tempHead.Key && !hashTable.ContainsKey(tempTable.Key))
                    {
                        hashTable.Add(tempTable.Key, tempHead.Key);
                        heap.Enqueue(tempTable, Priority(tempTable));

                        Console.WriteLine("Spantime: " + ++spanTime + " | State: " + tempTable.Key + " | From Parent " + tempHead.Key + " | Priority: " + Priority(tempTable));

                        //tempTable.Print();
                        //Console.WriteLine(tempTable.Key);

                        CheckEnd(tempTable, tempHead);
                    }

                }
            }
        }

        static void CheckEnd(Table table, Table parent)
        {
            if (Priority(table) == 0 || table.Key == goalTable.Key)
            {
                Console.WriteLine(" [Goal] Spantime: " + spanTime + " | From Parent " + parent.Key);
            }

        }

        static bool IsEnd(Table table, Table parent)
        {
            if (Priority(table) == 0 || table.Key == goalTable.Key)
            {
                Console.WriteLine(" [Goal] Spantime: " + spanTime + " | From Parent " + parent.Key);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ShowPath()
        {
            int time = 0;
            string path = goalTable.Key;

            Console.WriteLine(" Goal State: "+ goalTable.Key);



            while (hashTable[path] != null)
            {

                Console.WriteLine(" State[" + ++time + "]: "+ hashTable[path].ToString());
                path = hashTable[path].ToString();

            }
        }

        static Table CloneTable(Table source)
        {
            int[,] newTable = new int[3, 3];
            Array.Copy(source.table, newTable, source.table.Length);

            return new Table(newTable);
        }

        static float Priority(Table table)
        {
            float sum = 0;

            sum += Taxicab(table.GetIndex(1), goalTable.GetIndex(1));
            sum += Taxicab(table.GetIndex(2), goalTable.GetIndex(2));
            sum += Taxicab(table.GetIndex(3), goalTable.GetIndex(3));
            sum += Taxicab(table.GetIndex(4), goalTable.GetIndex(4));
            sum += Taxicab(table.GetIndex(5), goalTable.GetIndex(5));
            sum += Taxicab(table.GetIndex(6), goalTable.GetIndex(6));
            sum += Taxicab(table.GetIndex(7), goalTable.GetIndex(7));
            sum += Taxicab(table.GetIndex(8), goalTable.GetIndex(8));

            return sum;
        }

        public Tuple<int, int> GetIndex(int item)
        {
            Tuple<int, int> indexItem = new Tuple<int, int>(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (goalTable.table[i, j] == item)
                    {
                        indexItem = new Tuple<int, int>(i, j);
                    }
                }
            }

            return indexItem;
        }

        static int Taxicab(int x1, int y1, int x2, int y2)
        {
            int result2;
            result2 = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return result2;
        }

        static int Taxicab(Tuple<int, int> index, int x2, int y2)
        {
            int result2;
            result2 = Math.Abs(index.Item2 - x2) + Math.Abs(index.Item1 - y2);
            return result2;
        }

        static int Taxicab(Tuple<int, int> xy1, Tuple<int, int> xy2)
        {
            int result2;
            result2 = Math.Abs(xy1.Item2 - xy2.Item2) + Math.Abs(xy1.Item1 - xy2.Item1);
            return result2;
        }
    }
}
