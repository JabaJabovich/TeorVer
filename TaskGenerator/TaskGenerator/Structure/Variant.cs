﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    public class Variant
    {
        public string number;
        public string studentName;
        public List<Task> tasks;


        public void TestPrint()
        {
            foreach (Task task in tasks)
                task.TestPrint();
        }

        //Перенести в класс импорта данных, когда он будет готов.
        public static List<int> GetTaskTypesFromString(String str)
        {
            List<int> result = new List<int>();

            char[] chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-' };
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (chars.Contains(str[i]))
                    sbString.Append(str[i]);
            }

            String clearedString = sbString.ToString();
            String[] splittedString = clearedString.Split(new char[] { ',' });

            for (int i = 0; i < splittedString.Length; i++)
            {
                if (splittedString[i].Contains('-'))
                {
                    String[] splittedString2 = splittedString[i].Split('-');
                    int from = Convert.ToInt32(splittedString2[0]), to = Convert.ToInt32(splittedString2[1]);
                    for (int j = from; j <= to; j++)
                    {
                        result.Add(j);
                    }
                }
                else
                {
                    int type = Convert.ToInt32(splittedString[i]);
                    result.Add(type);
                }
            }
            return result;
        }

        //Мб лучше перенести в конструктор, пока так.
        public void GenerateVariant(List<int> taskTypes)
        {
            for (int i = 0; i < taskTypes.Count; i++)
            {
                tasks.Add(TaskConstructor.CreateTask(taskTypes[i]));
            }
        }

        public Variant()
        {
            tasks = new List<Task>();
        }
    }
}