using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    class Table
    {
        public int[,] table = new int[3, 3];

        public Table(int[,] table)
        {
            this.table = table;
        }

        public Table(string key)
        {
            List<string> words = new List<string>();

            foreach (var item in key)
            {
                words.Add(item+"");
            }

            words.Reverse();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = int.Parse(words[words.Count-1]);
                    words.RemoveAt(words.Count-1);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public string Key
        {
            get { return GetKey(); }
        }
        private string GetKey()
        {
            string key = "";
            /*for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    key += table[i, j];

                }
            }*/

            key += table[0, 0];
            key += table[0, 1];
            key += table[0, 2];
            key += table[1, 0];
            key += table[1, 1];
            key += table[1, 2];
            key += table[2, 0];
            key += table[2, 1];
            key += table[2, 2];

            //Console.WriteLine("key"+ key);
            return key;
        }


        private void Swap(int a,int b)
        {
            Tuple<int, int> indexItemA = GetIndex(a);
            Tuple<int, int> indexItemB = GetIndex(b);

            int temp = table[indexItemA.Item1, indexItemA.Item2];

            table[indexItemA.Item1, indexItemA.Item2] = table[indexItemB.Item1, indexItemB.Item2];
            table[indexItemB.Item1, indexItemB.Item2] = temp;
        }

        public bool CanMoveUp()
        {
            if (GetIndex(0).Item1 - 1 >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanMoveDown()
        {
            if (GetIndex(0).Item1 + 1 <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanMoveRight()
        {
            if (GetIndex(0).Item2 + 1 <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanMoveLeft()
        {
            if (GetIndex(0).Item2 - 1 >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Table MoveUp()
        {
            Tuple<int, int> tempIndex = GetIndex(0);
            int tempNum = table[tempIndex.Item1 - 1, tempIndex.Item2];

            table[tempIndex.Item1 - 1, tempIndex.Item2] = 0;
            table[tempIndex.Item1, tempIndex.Item2] = tempNum;

            return this;
        }

        public Table MoveDown()
        {
            Tuple<int, int> tempIndex0 = GetIndex(0);
            int tempNum = table[tempIndex0.Item1 + 1, tempIndex0.Item2];

            table[tempIndex0.Item1 + 1, tempIndex0.Item2] = 0;
            table[tempIndex0.Item1, tempIndex0.Item2] = tempNum;

            return this;
        }

        public Table MoveLeft()
        {
            Tuple<int, int> tempIndex = GetIndex(0);
            int tempNum = table[tempIndex.Item1, tempIndex.Item2 - 1];

            table[tempIndex.Item1, tempIndex.Item2 - 1] = 0;
            table[tempIndex.Item1, tempIndex.Item2] = tempNum;

            return this;
        }

        public Table MoveRight()
        {
            Tuple<int, int> tempIndex = GetIndex(0);
            int tempNum = table[tempIndex.Item1, tempIndex.Item2 + 1];
            table[tempIndex.Item1, tempIndex.Item2 + 1] = 0;
            table[tempIndex.Item1, tempIndex.Item2] = tempNum;

            return this;
        }



        public Tuple<int, int> GetIndex(int item)
        {
            Tuple<int, int> indexItem = new Tuple<int, int>(3, 3);

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == item)
                    {
                        indexItem = new Tuple<int, int>(i, j);
                    }
                }
            }

            return indexItem;
        }
    }
}