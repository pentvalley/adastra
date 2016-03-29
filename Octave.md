# Introduction #

Octave is a free clone of Matlab. Adastra has an Octave C# .NET wrapper that can execute any Octave/Matlab script and return the result to C# for further processing. Currently Octave is used for training [Logistic Regression](http://en.wikipedia.org/wiki/Logistic_regression) machine learning algorithm.


# Details #

Using Octave in Adastra has the following advantages:

  * reuse existing Matlab/Octave code
  * Octave/Matlab provide sophisticated math functions that might not be available in Math libraries implemented for .NET
  * cross OS software development. Adastra runs only on Windows, but Octave runs almost on any Windows, Unix OS.

In Adastra Octave can be applied mainly for the implementation of Machine Learning Algorithms and Digital Signal Processing (DSP).

Currently Adastra is tested with Octave 3.2.4, but it should work without problem with newest one 3.4.3.
Scripts in Adastra are located at: \scripts\octave directory.

# Windows download #
[http://sourceforge.net/projects/octave/files/Octave\_Windows%20-%20MinGW](http://sourceforge.net/projects/octave/files/Octave_Windows%20-%20MinGW/).

# Tips #
It is necessary that you set your Octave's install folder in: Adastra.exe.config. You need to put the folder where Octave's bin folder is contained. For version 3.4.3 this is: 'C:\Octave\Octave3.4.3\_gcc4.5.2\Octave3.4.3\_gcc4.5.2' if you have used the default install location.