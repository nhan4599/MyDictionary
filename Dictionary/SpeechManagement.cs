using System.Speech.Synthesis;

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
