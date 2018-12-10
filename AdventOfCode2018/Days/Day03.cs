using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day03
    {
        public void Part1()
        {
            IDictionary<int, IDictionary<int, int>> fabric = new Dictionary<int, IDictionary<int, int>>();

            List<FabricPart> fabricParts = new FileRead().GetFabricPart("../../../Inputs/Day03.txt");
            int count = 0;
            foreach (FabricPart fabricPart in fabricParts)
            {
                int posX = fabricPart.PosX;
                int posY = fabricPart.PosY;
                int sizeX = fabricPart.SizeX;
                int sizeY = fabricPart.SizeY;

                for (int indexOut = posX; indexOut < posX + sizeX; indexOut++)
                {
                    if (!fabric.ContainsKey(indexOut))
                    {
                        fabric[indexOut] = new Dictionary<int, int>();
                    }
                    IDictionary<int, int> fabricPartDic = fabric[indexOut];
                    for (int indexNot = posY; indexNot < posY + sizeY; indexNot++)
                    {
                        if (!fabricPartDic.ContainsKey(indexNot))
                        {
                            fabricPartDic[indexNot] = 1;
                        }
                        else
                        {
                            int includedId = fabricPartDic[indexNot];
                            if (includedId == 1)
                            {
                                count++;
                                fabricPartDic[indexNot] = ++includedId;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("End result of day  3 (part 1) is " + count); //120408
        }

        public void Part2()
        {
            IDictionary<int, IDictionary<int, int>> fabric = new Dictionary<int, IDictionary<int, int>>();
            HashSet<int> ids = new HashSet<int>();

            List<FabricPart> fabricParts = new FileRead().GetFabricPart("../../../Inputs/Day03.txt");

            foreach (FabricPart fabricPart in fabricParts)
            {
                int id = fabricPart.Id;
                int posX = fabricPart.PosX;
                int posY = fabricPart.PosY;
                int sizeX = fabricPart.SizeX;
                int sizeY = fabricPart.SizeY;

                ids.Add(id);
                for (int indexOut = posX; indexOut < posX + sizeX; indexOut++)
                {
                    if (!fabric.ContainsKey(indexOut))
                    {
                        fabric[indexOut] = new Dictionary<int, int>();
                    }
                    IDictionary<int, int> fabricPartDic = fabric[indexOut];
                    for (int indexNot = posY; indexNot < posY + sizeY; indexNot++)
                    {
                        if (!fabricPartDic.ContainsKey(indexNot))
                        {
                            fabricPartDic[indexNot] = id;
                        }
                        else
                        {
                            int includedId = fabricPartDic[indexNot];
                            ids.Remove(includedId);
                            ids.Remove(id);
                        }
                    }
                }
            }

            if (ids.Count != 1) throw new Exception("Error " + ids.Count );
            foreach (int key in ids)
            {
                Console.WriteLine("End result of day  3 (part 2) is " + key); //1276
            }
        }
    }
}
