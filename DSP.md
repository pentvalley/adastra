# Introduction #

There are three ways to add or modify signals in Adastra.

  * [OpenVibe](OpenVibe.md) is being used for digital signal processing. This BCI application contains several filters implemented in the form of "boxes". You can implement DSP boxes yourself in C++ and OpenVibe will use them.

  * Adastra comes with some .NET libs that provide DSP.

  * Adastra can execute and use the result from [Octave](Octave.md)(Matlab clone). This means that you can implement digital filters in Octave or use already available. You only need to provide your input and parse your output. Check [Signal Processing](http://octave.sourceforge.net/signal/overview.html) package in [Octave](Octave.md).

# Details #

Todo.