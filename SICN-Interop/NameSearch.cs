using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICN_Interop
{
    public class NameSearch
    {
        HashSet<NamesMappingModel> _nameMapping = new HashSet<NamesMappingModel>();
        public NameSearch(HashSet<NamesMappingModel> namesMapping)
        {
            _nameMapping = namesMapping;
        }
        public string LongNameSearch(string longName)
        {
            try
            {
                string shortname = _nameMapping.FirstOrDefault(x => x.LongName == longName).ShortName;
                return shortname;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string shortNameSearch(string shortName)
        {
            try
            {
                string shortname = _nameMapping.FirstOrDefault(x => x.ShortName == shortName).LongName;
                return shortname;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
