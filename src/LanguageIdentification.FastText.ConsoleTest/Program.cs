﻿using System.Runtime.InteropServices;

namespace LanguageIdentification.FastText.ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(".", "*", SearchOption.AllDirectories);

            var xx = File.Exists("libfasttext.so");

            NativeLibrary.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libfasttext.so"));

            var modelPath = "/models/fasttext217.bin";

            using var fastText = new FastTextDetector();

            fastText.LoadModel(modelPath);

            var labels = fastText.GetLabels();

            var text = "Hello, how are you? Привіт, як справи? Привет, как дела?";
            var predictions = fastText.PredictMultiple(text, 10);

            Console.WriteLine($"{text}:");

            foreach (var prediction in predictions)
            {
                Console.WriteLine($"{prediction.Label.Replace("__label__", "")}: {prediction.Probability}");
            }
        }
    }
}
