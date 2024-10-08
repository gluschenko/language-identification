﻿# Panlingo.LanguageIdentification.FastText

Welcome to **Panlingo.LanguageIdentification.FastText**, a .NET wrapper for the FastText library by Facebook AI Research (FAIR). This package seamlessly integrates language identification capabilities into .NET applications, leveraging the powerful and efficient FastText library to recognize and classify texts in multiple languages. Ideal for applications that require fast and accurate language detection.

## Requirements

- Runtime: **.NET >= 5.0**
- OS: **Linux (Ubuntu, Debian)**, **Windows 10+** or **Windows Server 2019+**, **macOS**
- Arch: **AMD64** (or **ARM** for macOS)

## Installation

To integrate the FastText functionality, follow these steps:

**Install the NuGet package**:

```sh
dotnet add package Panlingo.LanguageIdentification.FastText
```

## Usage

Integrating the FastText library into your .NET application is straightforward. Here’s a quick guide to get you started:

1. **Install the Package**: Ensure you have added the `Panlingo.LanguageIdentification.FastText` package to your project using the provided installation command.
2. **Download the Models**: Follow the provided commands to download the pretrained language identification models.
3. **Initialize the Library**: Follow the example snippet to initialize and use the FastText library for detecting languages.

```csharp
using Panlingo.LanguageIdentification.FastText;

class Program
{
    static void Main()
    {
        using var fastText = new FastTextDetector();
        fastText.LoadDefaultModel();

        var predictions = fastText.Predict(
            text: "Привіт, як справи?", 
            count: 10
        );

        foreach (var prediction in predictions)
        {
            Console.WriteLine($"{prediction.Label}: {prediction.Probability}");
        }

        var dimensions = fastText.GetModelDimensions();
        var labels = fastText.GetLabels();
    }
}
```

### Custom models

#### Download the Pretrained Models

Depending on your needs, download one of the pretrained language identification (LID) models provided by Facebook:

- For the LID model with 176 languages:
    ```sh
    curl --location -o /models/fasttext176.bin https://dl.fbaipublicfiles.com/fasttext/supervised-models/lid.176.bin
    ```

- For the LID model with 217 languages:
    ```sh
    curl --location -o /models/fasttext217.bin https://huggingface.co/facebook/fasttext-language-identification/resolve/main/model.bin?download=true
    ```

Learn more about these models here:
- [176 languages](https://fasttext.cc/docs/en/language-identification.html)
- [217 languages + script](https://huggingface.co/facebook/fasttext-language-identification)

#### Use custom model in code
```
using var fastText = new FastTextDetector();

var modelPath = "/models/fasttext176.bin";
fastText.LoadModel(modelPath);
```
OR
```
using var fastText = new FastTextDetector();

var modelPath = "/models/fasttext176.bin";
using var stream = File.Open(modelPath, FileMode.Open);
fastText.LoadModel(stream);
```

## Alternatives

If you are exploring other options, here are some alternatives to consider:

- **[theolivenbaum/fastText](https://github.com/theolivenbaum/fastText)**: An unmaintained wrapper for .NET.
- **[olegtarasov/FastText.NetWrapper](https://github.com/olegtarasov/FastText.NetWrapper)**: Another unmaintained wrapper for .NET.

## Sources

1. [Original FastText Repository](https://github.com/facebookresearch/fastText)
2. [Enriching Word Vectors with Subword Information](https://arxiv.org/abs/1607.04606v2)
3. [Language identification at Wikipedia](https://en.wikipedia.org/wiki/Language_identification)

---

We value your feedback. Feel free to open issues or contribute to the repository. Let’s make language detection in .NET even more powerful and versatile! 🌍📝

Happy coding! 👩‍💻👨‍💻

---

Stay updated by following our repository. For any inquiries or support, reach out through the [issues page](https://github.com/gluschenko/panlingo/issues).