using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Sydeso
{
    public class speech_helper
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

        public void Speak(string text)
        {
            speechSynthesizer.SpeakAsync(text);
        }

        public void CancelSpeaking()
        {
            speechSynthesizer.SpeakAsyncCancelAll();
        }
    }
}
