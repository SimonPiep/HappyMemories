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

        }
        public int callOnlineAPI(string input)
        {
            Random rnd = new Random();
            return rnd.Next(1, 3); 
        }
    }





}
