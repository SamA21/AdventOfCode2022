using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class Calories
    {
        public static List<Elf> ConvertData(List<string> data)
        {
            List<Elf> elves = new List<Elf>();
            int elvesCount = 0;
            int currentCalories = 0;
            int currentIndex = 0;
            foreach (var calorie in data)
            {
                bool isCalorie = int.TryParse(calorie, out int currentCalorie);
                if (isCalorie)
                {
                    currentCalories += currentCalorie;
                }
                else
                {
                    elvesCount++;
                    elves.Add(new Elf()
                    {
                        Number = elvesCount,
                        TotalCalories = currentCalories
                    });

                    if (currentIndex != data.Count)
                        currentCalories = 0;
                }
                
                currentIndex++;
            }
            elves.Add(new Elf()
            {
                Number = elvesCount,
                TotalCalories = currentCalories
            });

            return elves;
        }
    }
}
