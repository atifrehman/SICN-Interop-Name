using System;
using System.Collections.Generic;
using System.Text;

namespace SICN_Interop
{
    public class ExperimentalSetup
    {
        public int TotalRecords { get; set; }


        public void RunExperimentation(int totalExperiments, HashSet<NamesMappingModel> namesMapping, List<string> names)
        {
            for (int i = 1; i < totalExperiments; i++)
            {

                Console.WriteLine("----------------------------------- Experient # " + (i + 1) + " ------------------------------------");
                TotalRecords = 20000 * i;
                string name = GetRandomKeywordForSearch(names);
                DisplayResults(namesMapping, name);
                Console.WriteLine("");
            }

        }

        public void DisplayResults(HashSet<NamesMappingModel> namesMapping, string name)
        {
            HashSet<NamesMappingModel> namesMappingModels = GetNamesByTotalRecords(namesMapping);
            NameSearch nameSearch = new NameSearch(namesMappingModels);

            long startTimeInMicroseconds = DateTime.Now.Ticks / 1000;
            Console.WriteLine("Search Starting Time: " + DateTime.Now.Ticks / 1000);
            nameSearch.LongNameSearch(name);
            Console.WriteLine("Search End Time: " + DateTime.Now.Ticks / 1000);
            long endTimeInMicroseconds = DateTime.Now.Ticks / 1000;

            Console.WriteLine("Total Time: " + (endTimeInMicroseconds - startTimeInMicroseconds));
        }


        public string GetRandomKeywordForSearch(List<string> names)
        {
            Random random = new Random();
            int index = random.Next(1, TotalRecords);  // creates a number between 1 and TotalRecords

            return names[index];
        }

        private HashSet<NamesMappingModel> GetNamesByTotalRecords(HashSet<NamesMappingModel> namesMapping)
        {
            try
            {
                HashSet<NamesMappingModel> filteredNamesMapping = new HashSet<NamesMappingModel>();
                if (namesMapping.Count >= TotalRecords)
                {
                    int counter = 0;
                    foreach (var item in namesMapping)
                    {
                        if (counter < TotalRecords)
                        {
                            filteredNamesMapping.Add(item);
                        }
                        counter++;
                    }
                    return filteredNamesMapping;
                }
                else
                {
                    return namesMapping;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
