#pragma once

#include <cstddef>
#include <cstring>
#include "./cld2/public/compact_lang_det.h"

#ifndef EXPORT
#   if defined(_WIN32) || defined(_WIN64)
#       define EXPORT __declspec(dllexport)
#   elif defined(__GNUC__) || defined(__clang__)
#       define EXPORT __attribute__((visibility("default")))
#   else
#       define EXPORT
#   endif
#endif

extern "C"
{
    struct PredictionResult {
        const char* language;
        const char* script;
        double probability;
        bool is_reliable;
        double proportion;
    };

    EXPORT PredictionResult* PredictLanguage(char* text, int* resultCount);

    EXPORT void FreeResults(PredictionResult* results, int count);
}
