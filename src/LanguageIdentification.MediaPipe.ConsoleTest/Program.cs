﻿namespace Panlingo.LanguageIdentification.MediaPipe.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var modelPath = "/models/mediapipe_language_detector.tflite";
            using var stream = File.Open(modelPath, FileMode.Open);

            using var mediaPipe = new MediaPipeDetector(
                options: MediaPipeOptions.FromStream(stream)
            );

            var text = "Hello, how are you? Привіт, як справи? Привет, как дела?";

            var predictions = mediaPipe.PredictLanguages(text);

            foreach (var prediction in predictions)
            {
                Console.WriteLine(
                    $"Language: {prediction.Language}, " +
                    $"Probability: {prediction.Probability}"
                );
            }
        }
    }
}
