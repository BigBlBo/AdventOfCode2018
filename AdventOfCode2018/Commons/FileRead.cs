using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Commons
{
    class FileRead
    {
        public List<PlantGrowPattern> GetPlantGrowPatterns(string filePath)
        {
            List<PlantGrowPattern> plantGrowPatterns = new List<PlantGrowPattern>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string patternToGrow = line.Substring(0, line.IndexOf('=')).Trim();
                    string growResult = line.Substring(line.IndexOf('>') + 1).Trim();

                    plantGrowPatterns.Add(new PlantGrowPattern
                    {
                        PatternToGrow = patternToGrow,
                        GrowResult = growResult
                    });
                }
            }

            return plantGrowPatterns;
        }

        public List<CoordinateWithStep> GetCoordinateWithSteps(string filePath)
        {
            List<CoordinateWithStep> coordinateWithSteps = new List<CoordinateWithStep>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string coordinate = line.Substring(line.IndexOf('<') + 1, line.IndexOf('>') - line.IndexOf('<') - 1);
                    string steps = line.Substring(line.IndexOf('>') + 1);
                    steps = steps.Substring(steps.IndexOf('<') + 1, steps.IndexOf('>') - steps.IndexOf('<') - 1);
                    string[] coordinateArray = coordinate.Split(',');
                    string[] stepsArray = steps.Split(',');

                    coordinateWithSteps.Add(new CoordinateWithStep
                    {
                        PosX = int.Parse(coordinateArray[0]),
                        PosY = int.Parse(coordinateArray[1]),
                        StepX = int.Parse(stepsArray[0]),
                        StepY = int.Parse(stepsArray[1])
                    });
                }
            }

            return coordinateWithSteps;
        }


        public List<Step> GetSteps(string filePath)
        {
            List<Step> steps = new List<Step>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string afterStep = line.Substring(36, 1);
                    string beforeStep = line.Substring(5, 1);
                    steps.Add(new Step { AfterStep = afterStep, BeforeStep = beforeStep });
                }
            }

            return steps;
        }

        public List<Coordinate> GetCoordinates(string filePath)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splits = line.Split(',');
                    coordinates.Add(new Coordinate { PosX = int.Parse(splits[0].Trim()), PosY = int.Parse(splits[1].Trim()) });
                }
            }

            return coordinates;
        }

        public List<GuardEvent> GetGuardEvents(string filePath)
        {
            List<GuardEvent> GuardEvents = new List<GuardEvent>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = null;
                int guardId = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    int minute = int.Parse(line.Substring(15, 2));
                    int hour = int.Parse(line.Substring(12, 2));
                    int day = int.Parse(line.Substring(9, 2));
                    int month = int.Parse(line.Substring(6, 2));
                    int year = int.Parse(line.Substring(1, 4));
                    string eventOnTimeStr = line.Substring(19).Trim();
                    if (eventOnTimeStr.StartsWith("Guard"))
                    {
                        string sub = eventOnTimeStr.Substring(eventOnTimeStr.IndexOf('#') + 1);
                        string guardIdStr = sub.Substring(0, sub.IndexOf(' '));
                        guardId = int.Parse(guardIdStr);
                    }

                    int eventOnTime = 0;
                    if (eventOnTimeStr.StartsWith("Guard")) eventOnTime = 1;
                    else if (eventOnTimeStr.StartsWith("falls")) eventOnTime = 2;
                    else if (eventOnTimeStr.StartsWith("wakes")) eventOnTime = 3;
                    else throw new Exception();

                    GuardEvents.Add(new GuardEvent
                    {
                        Minute = minute,
                        Hour = hour,
                        Day = day,
                        Month = month,
                        Year = year,
                        GuardId = guardId,
                        Date = new DateTime(year, month, day, hour, minute, 0),
                        EventOnTime = eventOnTime,
                        Line = line
                    });
                }
            }

            return GuardEvents.OrderBy(si => si.Date).ToList();
        }

        public List<FabricPart> GetFabricPart(string filePath)
        {
            List<FabricPart> fabricParts = new List<FabricPart>();
            using (var reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    int idSep = line.IndexOf('@');
                    int posSep = line.IndexOf(',');
                    int valuesSep = line.IndexOf(':');
                    int sizeSep = line.IndexOf('x');
                    int id = int.Parse(line.Substring(1, idSep - 1).Trim());
                    int posX = int.Parse(line.Substring(idSep + 1, posSep - idSep - 1).Trim());
                    int posY = int.Parse(line.Substring(posSep + 1, valuesSep - posSep - 1).Trim());
                    int sizeX = int.Parse(line.Substring(valuesSep + 1, sizeSep - valuesSep - 1).Trim());
                    int sizeY = int.Parse(line.Substring(sizeSep + 1).Trim());

                    fabricParts.Add(new FabricPart { Id = id, PosX = posX, PosY = posY, SizeX = sizeX, SizeY = sizeY });
                }
            }
            return fabricParts;
        }

        public List<string> GetLines(string filePath)
        {
            List<string> fileLines = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }
            return fileLines;
        }

        public IList<int> GetNumList(string filePath)
        {
            IList<int> numList = new List<int>();

            using (var reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    numList.Add(num);
                }
            }

            return numList;
        }

        public IDictionary<int, int> GetNumDic(string filePath)
        {
            IDictionary<int, int> numDic = new Dictionary<int, int>();

            using (var reader = new StreamReader(filePath))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if (!numDic.ContainsKey(num))
                    {
                        numDic[num] = 1;
                    }
                    else
                    {
                        numDic[num] = ++numDic[num];
                    }
                }
            }

            return numDic;
        }
    }
}
