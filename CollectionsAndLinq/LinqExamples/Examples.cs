using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsAndLinq.LinqExamples
{
    class Examples
    {
        public void Run()
        {
            //new list of whole numbers
            var numbers = new List<int> { 12, 15, 400, 1, 3208, 19, 12, 16, 400, 23, 100 };
            var badNumbers = new List<int> { 13, 666 };

            //filtering data (similar to Array.filter)
            var bigNumbers = numbers.Where(number => number > 27); //filters numbers where number is greater than 27 and returns a new collection of IEnumberable<T>
            var matches = bigNumbers == numbers; //are the collections literally the same? do they store the same reference - not do they share the same values

            //Select is like Array.map, returns a new collectino of IEnumerable<T>
            //transforming data
            var biggerNumbers = numbers.Select(number => number + 27);

            var biggestNumber = numbers.Max(); //returns the max item in collection

            var firstNumber = numbers.First(); //returns first item of collection

            var firstMatchingNumber = numbers.First(number => number > 12); //returns first matching item
            //var firstMatchingNumber = numbers.First(number => number > 12).First() - this would loop through everything, return what's greater than 12, and then return the first item

            //contains but cooler
            var anyNumbers = numbers.Any(); //does this collection have anything in it
            var hasReallyBigNumbers = numbers.Any(numbers => numbers > 1000000); // is there a number greater than 1000000, returns a boolean


            //Complex/Reference Types and Linq
            var animals = new List<Animal>
            {// collection initializer
                new Animal {Type = "Giraffe", HeightInInches = 204, WeightInPounds = 1800}, //object initializers
                new Animal {Type = "Tiger", HeightInInches = 40, WeightInPounds = 500},
                new Animal {Type = "Frog", HeightInInches = 3, WeightInPounds = 0},
                new Animal {Type = "Gorilla", HeightInInches = 63, WeightInPounds = 3500}
            };

            //filter data
            //materializing an IEnumerable
            //Linq by default uses a concept called deferred execution to only filter/transform data Just In Time
            var animalsThatStartWithG = animals.Where(animal => animal.Type.StartsWith('G'));

            //transform data
            var animalDescriptions = animals
                .Select(animal => $@"A {animal.Type} is {animal.HeightInInches} inches tall and {animal.WeightInPounds}lbs heavy.");

            foreach (var description in animalDescriptions)
            {
                Console.WriteLine(description);
            }

            //group a collection by a given key (based on a function)
            var groupAnimals = animals.GroupBy(animal => animal.Type.First());

            foreach (var animalGroup in groupAnimals)
            {
                Console.WriteLine($"Animals that start with {animalGroup.Key}");

                foreach (var animal in animalGroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }

            //group and transform at the same time
            var groupAnimalNames = animals.GroupBy(animal => animal.Type.First(), animal => animal.Type);

            foreach (var animalGroup in groupAnimalNames)
            {
                Console.WriteLine($"Animals that start with {animalGroup.Key}");

                foreach (var name in animalGroup)
                {
                    Console.WriteLine(name);
                }
            }

            //can chain until it's not an IEnumerable anymore
            var filteredAndTransformedAnimals = animals
                .Where(animal => animal.HeightInInches > 20)
                .Select(animal => animal.Type);

            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5).Take(1));

            var onlyGoodNumbers = numbers.Except(badNumbers);

            //removes all duplicates - unique numbers only show up once
            var uniqueNumbers = numbers.Distinct();
        }
    }
}
