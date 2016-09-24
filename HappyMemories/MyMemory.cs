using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMemories
{
    class MyMemory
    {
        public MyMemory()
        {
            _thememory = "";
        }
        public string Thememory { get { return _thememory; } set { _thememory = value; } }
        private string _thememory;

        public int HappinessRating { get { return _happinessRating; } set { _happinessRating = value; } }
        private int _happinessRating;

        public List<string> feelings { get { return _feelings; } set { feelings = value; } }
        private List<string> _feelings;
    }


}
