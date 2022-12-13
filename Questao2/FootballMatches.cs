using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class FootballMatches
    {
        public int Page { get; set; }

        public int Per_page { get; set; }

        public int Total { get; set; }

        public int Total_pages { get; set; }

        public List<Data>? Data { get; set; }
    }

    public class Data
    {
        public string Competition { get; set; } = string.Empty;

        public int Year { get; set; }

        public string Round { get; set; } = string.Empty;

        public string Team1 { get; set; } = string.Empty;

        public string Team2 { get; set; } = string.Empty;

        public int Team1goals { get; set; }

        public int Team2goals { get; set; }
    }
}
