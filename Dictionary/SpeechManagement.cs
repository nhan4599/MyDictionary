<<<<<<< HEAD
﻿using System.Speech.Synthesis;

namespace Dictionary
{
    class SpeechManagement
    {
        private readonly SpeechSynthesizer speech;

        public SpeechManagement()
        {
            speech = new SpeechSynthesizer();
            speech.SetOutputToDefaultAudioDevice();
            speech.Volume = 80; // âm lượng (0 -> 100) nha
            speech.Rate = -1; // tốc độ đọc nè (-10 -> 10) 
        }

        public void Speak(string word)
        {
            speech.Speak(word);
        }

        public void Dispose()
        {
            speech.Dispose();
        }
    }
}
=======
﻿using System.Speech.Synthesis;

namespace Dictionary
{
    class SpeechManagement
    {
        private readonly SpeechSynthesizer speech;

        public SpeechManagement()
        {
            speech = new SpeechSynthesizer();
            speech.SetOutputToDefaultAudioDevice();
            speech.Volume = 100;
            speech.Rate = -3;
        }

        public void Speak(string word)
        {
            speech.Speak(word);
        }

        public void Dispose()
        {
            speech.Dispose();
        }
    }
}
>>>>>>> 443a72d8de5ae5828dff712e3f73c64ff5c87876
