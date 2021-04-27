using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
//referenciar

namespace CustomSpeech
{
    class Program
    {
        async static Task FromMic(SpeechConfig speechConfig)
        {
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            Console.WriteLine("Habla al microfono");
            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine($"Esto es lo que reconozco: {result.Text}");
            Console.ReadKey();
        }
        async static Task Main(string[] args)
        {
            var speechConfig = SpeechConfig.FromSubscription("b1985dd776aa4e8cb0cd18e5414efc02", "southcentralus");
            await FromMic(speechConfig);
        }
    }
}
