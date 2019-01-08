using System;
using System.Collections.Generic;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Sydeso
{
    public class speech_helper
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        SpeechRecognitionEngine recEngine;

        public void Speak(string text)
        {
            speechSynthesizer.SpeakAsync(text);
        }

        public void SpeakFirst(string text)
        {
            speechSynthesizer.Speak(text);
        }

        public void CancelSpeaking()
        {
            speechSynthesizer.SpeakAsyncCancelAll();
        }

        private List<String> _user_details;
        public void StartRecognizing(List<String> user)
        {
            _user_details = user;
            recEngine = new SpeechRecognitionEngine();
            Choices commands = new Choices();
            commands.Add(new string[] { "Hello", "How are you" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);

            Grammar grammar = new Grammar(gb);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();

            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Hello":
                    CancelSpeaking();
                    Speak("Hello, " + _user_details[1] + " " + _user_details[2] + ".");
                    break;
                case "How are you":
                    CancelSpeaking();
                    Speak("I am fine, thank you for asking..");
                    break;
                default:
                    CancelSpeaking();
                    Speak("Command does not recognized.");
                    break;
            }
        }

        public void StopRecognizing()
        {
            recEngine.RecognizeAsyncCancel();
            recEngine.RecognizeAsyncStop();
            recEngine.UnloadAllGrammars();
            recEngine = null;
        }
    }
}
