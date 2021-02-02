﻿using System;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //anything with angle brackets after the type name is a generic type
            //List<T>
            //Pronounced List of T
            //T is a Generic Type Parameter
            //string in this case closes the generic type
            var teachers = new List<string>() {"Jameka", "Dylan", "Nathan"};
            var e13 = new List<string>();
            e13.Add("Dana");
            e13.Add("Rob");
            e13.Add("Ryan");
            e13.Add("Wanda");

            //e13.Add(teachers[0]);
            //e13.Add(teachers[1]);
            //e13.Add(teachers[2]);

            //foreach (var teacher in teachers)
            //{
            //      e13.Add(teacher);
            //}

            //gets enumerator for a type
            foreach (var student in e13) //invalid operation exception
            {
                if (student == "Hunter")
                {
                    //changes to the underlying collection do not allow for continued looping
                    e13.Remove(student);  
                }
            }

            e13.AddRange(teachers);

            e13.ForEach(name =>
            {
                Console.WriteLine(name);
            });

            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye Wanda");
            }
            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye again Wanda.");
            }

            //Dictionary<TKey,TValue>
            //Arity (`2) -> how many generic type parameters a type has. Dictionary`2
            //Very fast information retrieval
            //Slower information storage
            //Good for: infrequently updated but often read data
            //Good for: loading information at startup or in the background and fast retrieval on demand (caching)

            //the first parameter is the type for the key, the second is the type for the value
            var words = new Dictionary<string, string> 
            { //collection initializer
                {"soup", "a thing I don't have right now, but want."}, //key value pair
                {"cake", "a thing I don't have right now, but want."}
            };

            words.Add("Arity", "how many generic type parameters a type has");
            words["Arity"] = "A thing Nathan made up"; // look up an item by key using the indexer
            //words.Add("Arity", "another definition") //argument exception

            if (!words.TryAdd("Arity", "another definition"))
            {
                words["Arity"] = "another definition";
            }

            words.Remove("cake");

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }

            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"{word} means {definition}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is a definition of soup");



            var a1 = new A<int>();
            var a2 = new A<string>();

            a1.DoStuff(123);
            a2.DoStuff("Other stuff");
        }
    }

    class A<T>
    {
        public void DoStuff(T thingToDo)
        {
            Console.WriteLine($"stuff {thingToDo}");
        }
    }
}