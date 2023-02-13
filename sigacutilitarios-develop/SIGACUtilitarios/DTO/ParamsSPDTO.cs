using System;
using System.Collections.Generic;

namespace SIGACUtilitarios.DTO
{
    public class ParamsSPDTO
    {
        public Dictionary<string, string> parametrosString = new Dictionary<string, string>();
        public Dictionary<string, int> parametrosInt = new Dictionary<string, int>();
        public Dictionary<string, int?> parametrosIntNull = new Dictionary<string, int?>();
        public Dictionary<string, decimal> parametrosDecimal = new Dictionary<string, decimal>();
        public Dictionary<string, decimal?> parametrosDecimalNull = new Dictionary<string, decimal?>();
        public Dictionary<string, DateTime> parametrosDate = new Dictionary<string, DateTime>();
        public Dictionary<string, DateTime?> parametrosDateNull = new Dictionary<string, DateTime?>();
        public string cursor;


    }
}
