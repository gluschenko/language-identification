﻿using Panlingo.LanguageIdentification.FastText;

namespace Panlingo.LanguageIdentification.Tests;

public class FastTextTests
{
    [Theory]
    [InlineData("__label__en", "Hello, how are you?")]
    [InlineData("__label__uk", "Привіт, як справи?")]
    [InlineData("__label__ru", "Привет, как дела?")]
    public void FastTextSingleLanguage(string languageCode, string text)
    {
        using var fastText = new FastTextDetector();

        var modelPath = "/models/fasttext176.bin";
        fastText.LoadModel(modelPath);

        var predictions = fastText.Predict(text: text, k: 10);
        var mainLanguage = predictions.FirstOrDefault();

        if (mainLanguage is null)
        {
            throw new NullReferenceException();
        }

        Assert.Equal(languageCode, mainLanguage.Label);
    }
}
