﻿using System.Runtime.InteropServices;

namespace Panlingo.LanguageIdentification.CLD3.Internal
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal readonly struct CLD3PredictionResult
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Language;

        [MarshalAs(UnmanagedType.R8)]
        public readonly double Probability;

        [MarshalAs(UnmanagedType.I1)]
        public readonly bool IsReliable;

        [MarshalAs(UnmanagedType.R8)]
        public readonly double Proportion;
    }
}
