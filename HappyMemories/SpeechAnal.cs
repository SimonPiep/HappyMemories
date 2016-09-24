using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMemories
{
    class SpeechAnal
    {
        public SpeechAnal()
        {
            some = 0;
        }
        private int some;
        public int callOnlineAPI(string input)
        {
            return some++ % 3;
        }
    }





}
