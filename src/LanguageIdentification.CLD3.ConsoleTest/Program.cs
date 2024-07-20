﻿namespace Panlingo.LanguageIdentification.CLD3.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var cld3 = new CLD3Detector(minNumBytes: 0, maxNumBytes: 512);

            var text = "Hello, how are you? Привіт, як справи? Привет, как дела?";

            var singlePrediction = cld3.PredictLanguage(text);

            Console.WriteLine($"Language: {singlePrediction.Language}");
            Console.WriteLine($"Probability: {singlePrediction.Probability}");
            Console.WriteLine($"IsReliable: {singlePrediction.IsReliable}");
            Console.WriteLine($"Proportion: {singlePrediction.Proportion}");

            var predictions = cld3.PredictLangauges(text, 3);

            foreach (var prediction in predictions)
            {
                Console.WriteLine(
                    $"Language: {prediction.Language}, " +
                    $"Probability: {prediction.Probability}, " +
                    $"IsReliable: {prediction.IsReliable}, " +
                    $"Proportion: {prediction.Proportion}"
                );
            }
        }
    }
}
