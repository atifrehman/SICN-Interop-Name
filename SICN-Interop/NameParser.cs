using System;
using System.Collections.Generic;
using System.Text;

namespace SICN_Interop
{
    public class NameParser
    {
        public List<string> URLToNameConverter(List<string> urls)
        {
            try
            {
                List<string> nameList = new List<string>();
                foreach (string url in urls)
                {
                    string[] urlArray = url.Split('.');
                    string name = string.Empty;
                    for (int i = urlArray.Length - 1; i >= 0; i--)
                    {
                        name = String.Concat(name, urlArray[i], '/');
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        name = String.Concat(name, "longPrefix" + (i + 1), '/');
                    }
                    nameList.Add(name);
                }

                return nameList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> LongNameToShortName(List<string> longNames)
        {
            try
            {
                List<string> shortNames = new List<string>();
                foreach (string url in longNames)
                {
                    string[] urlArray = url.Split('/');
                    string shortName = string.Empty;
                    foreach (var item in urlArray)
                    {
                        if (item.Length > 0)
                        {
                            if (item.Length == 1)
                            {
                                shortName = String.Concat(shortName, item.Substring(0, 1), '/');
                            }
                            else if (item.Length > 1)
                            {
                                shortName = String.Concat(shortName, item.Substring(0, 2), '/');
                            }

                        }

                    }
                    shortNames.Add(shortName);
                }

                return shortNames;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HashSet<NamesMappingModel> NamesMapping(List<string> longNames, List<string> shortNames)
        {
            try
            {
                HashSet<NamesMappingModel> namesMappings = new HashSet<NamesMappingModel>();
                for (int i = 0; i < longNames.Count; i++)
                {
                    NamesMappingModel namesMappingModel = new NamesMappingModel();
                    namesMappingModel.LongName = longNames[i];
                    namesMappingModel.ShortName = shortNames[i];
                    namesMappings.Add(namesMappingModel);
                }

                return namesMappings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
