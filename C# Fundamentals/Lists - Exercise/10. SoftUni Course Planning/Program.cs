using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] commands = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = commands[0];
                string firstLesson = commands[1];

                string secondLesson = "";
                string firstExerciseName = "";
                string secondExerciseName = "";
                switch (action)
                {
                    case "Add":
                        if (!schedule.Contains(firstLesson))
                        {
                            schedule.Add(firstLesson);
                        }
                        break;
                    case "Insert":
                        if (!schedule.Contains(firstLesson))
                        {
                            int indexToInsert = int.Parse(commands[2]);
                            if (indexToInsert >= 0 && indexToInsert <= schedule.Count - 1)
                            {
                                schedule.Insert(indexToInsert, firstLesson);
                            }
                        }
                        break;
                    case "Remove":
                        if (schedule.Contains(firstLesson))
                        {
                            schedule.Remove(firstLesson);
                            string exerciseName = firstLesson + "-Exercise";
                            if (schedule.Contains(exerciseName))
                            {
                                schedule.Remove(exerciseName);
                            }
                        }
                        break;
                    case "Swap":
                        if (schedule.Contains(firstLesson) && schedule.Contains(commands[2]))
                        {
                            firstExerciseName = firstLesson + "-Exercise";
                            secondLesson = commands[2];
                            secondExerciseName = commands[2] + "-Exercise";
                            int firstLessonIndex = schedule.IndexOf(firstLesson);
                            int secondLessonIndex = schedule.IndexOf(secondLesson);
                            LessonSwap(schedule, firstLessonIndex, secondLessonIndex, firstLesson, secondLesson);

                            if (schedule.Contains(firstExerciseName))
                            {
                                schedule.Remove(firstExerciseName);
                                schedule.Insert(secondLessonIndex + 1, firstExerciseName);
                            }
                            if (schedule.Contains(secondExerciseName))
                            {
                                schedule.Remove(secondExerciseName);
                                schedule.Insert(firstLessonIndex + 1, secondExerciseName);
                            }

                        }
                        break;
                    case "Exercise":
                        firstExerciseName = firstLesson + "-Exercise";
                        if (schedule.Contains(firstExerciseName))
                        {
                            continue;
                        }
                        else if (schedule.Contains(firstLesson))
                        {
                            int lessonIndex = schedule.IndexOf(firstLesson);
                            schedule.Insert(lessonIndex + 1, firstExerciseName);
                        }
                        else
                        {
                            schedule.Add(firstLesson);
                            schedule.Add(firstExerciseName);
                        }
                        break;
                }
            }
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
        static List<string> LessonSwap(List<string> schedule, int firstLessonIndex, int secondLessonIndex,
            string firstLesson, string secondLesson)
        {
            schedule.Remove(firstLesson);
            schedule.Remove(secondLesson);
            schedule.Insert(firstLessonIndex, secondLesson);
            schedule.Insert(secondLessonIndex, firstLesson);
            return schedule;
        }
    }
}
