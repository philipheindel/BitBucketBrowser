using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBucketBrowser
{
    public class JsonSchema
    {
        public class Root<T>
        {
            public string size { get; set; }
            public string limit { get; set; }
            public bool islastPage { get; set; }
            public List<T> values { get; set; }
        }
        public class Project
        {
            public string key { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public Links links { get; set; }
        }
        public class Repository
        {
            public string slug { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string scmId { get; set; }
            public string state { get; set; }
            public string statusMessage { get; set; }
            public bool forkable { get; set; }
            public Project project { get; set; }
        }
        public class Links
        {
            public List<Clone> clone { get; set; }
            public List<Self> self { get; set; }
        }
        public class Self
        {
            public string href { get; set; }
        }
        public class Clone
        {
            public string href { get; set; }
            public string name { get; set; }
        }
    }
}
