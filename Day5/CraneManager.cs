using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class CraneManager
    {
        public List<List<string>> InitalBoxes { get; init; }
        public List<List<string>> MovedBoxes { get; set; }
        private List<string> Instructions { get; init; } 

        public CraneManager(string dataLocation)
        {
            InitalBoxes = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            Instructions = new List<string>();  
            FileStream fileStream = new FileStream(dataLocation, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                bool isInstructions = false;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        isInstructions = true;
                    }
                    else
                    {
                        if (isInstructions)
                        {
                            Instructions.Add(line);
                        }
                        else
                        {
                            var items = line?.Replace("[", string.Empty).Replace("]", string.Empty);
                            int? columnLastAdded = null;
                            int spaces = 0;
                            foreach (var item in items)
                            {
                                if (!string.IsNullOrWhiteSpace(item.ToString()) && !int.TryParse(item.ToString(), out int parsedInt)){
                                    int? newColumn = null;
                                    spaces = spaces - 1;
                                    if (spaces >= 3)
                                    {
                                        var temp = spaces / 3;
                                        if (!columnLastAdded.HasValue)
                                            columnLastAdded = 0;
                                        newColumn = columnLastAdded + temp;
                                        if (spaces % 3 != 0)
                                            newColumn++;
                                    }
                                    else if (spaces == 1) 
                                    {
                                        newColumn = columnLastAdded + 1;
                                    }
                                    else if(spaces == -1)
                                    {
                                        newColumn = 0;
                                    }

                                    if (newColumn.HasValue )
                                    {
                                        InitalBoxes[newColumn.Value].Add(item.ToString());

                                        columnLastAdded = newColumn;
                                        spaces = 0;
                                    }
                                }
                                spaces++;
                            }
                        }
                    }
                }
            }
        }
        
                                        
        public void MoveDataUsingSetInstructions(bool keepOrder)
        {
            List<List<string>> CurrentBoxes = JsonConvert.DeserializeObject<List<List<string>>>(JsonConvert.SerializeObject(InitalBoxes));
            foreach (var instruction in Instructions)
            {
                var splitInstructions = instruction.Where(char.IsDigit);
                var splitArray = splitInstructions.ToArray();
                int moveAmmount = 0;
                int moveFrom = 0;
                int moveTo = 0;
                if (splitArray.Length == 4)
                {
                    moveAmmount = int.Parse($"{splitArray[0]}{splitArray[1]}");
                    moveFrom = int.Parse(splitArray[2].ToString()) - 1;
                    moveTo = int.Parse(splitArray[3].ToString()) - 1;
                }
                else
                {
                    moveAmmount = int.Parse(splitArray[0].ToString());
                    moveFrom = int.Parse(splitArray[1].ToString()) - 1;
                    moveTo = int.Parse(splitArray[2].ToString()) - 1;
                }

                var movingBoxes = CurrentBoxes[moveFrom]?.Take(moveAmmount).ToList();
                CurrentBoxes[moveFrom]?.RemoveRange(0, moveAmmount);
                var newBox = CurrentBoxes[moveTo];
                if (movingBoxes != null)
                {
                    if (keepOrder)
                    {
                        movingBoxes.Reverse();
                    }
                    
                    foreach (var movingBox in movingBoxes)
                    {
                        CurrentBoxes[moveTo].Insert(0,movingBox);
                    }
                    
                    CurrentBoxes[moveTo] = newBox;
                }
            }
            MovedBoxes = CurrentBoxes;
        }

        public void TopItems()
        {
            if (MovedBoxes != null && MovedBoxes.Count > 0)
            {
                foreach (List<string> boxTower in MovedBoxes)
                {
                    var firstLetter = boxTower?.FirstOrDefault("N/A");
                    Console.WriteLine(firstLetter);
                }
            }
            else
            {
                Console.WriteLine("No Boxes moved");
            }
        }
    }
}
