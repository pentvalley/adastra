# Introduction #

Adastra is developed mainly in C# and the UI is multi-threaded. Adastra can be compiled with the free [Visual C# 2010 Express](http://www.microsoft.com/visualstudio/en-us/products/2010-editions/visual-csharp-express) edition of Visual Studio. One of the primary goals of this project is to be easy to develop. Simply installing VS 2010 should be enough to compile and run it. Target .NET Frameworks is 4.0.

Adastra can utilize existing [Octave](Octave.md)(Matlab clone) instance. At least one algorithm is currently implemented in [Octave](Octave.md).

# Software Libraries #

The following software libraries are used in Adastra:

  * [AForge.NET](http://www.aforgenet.com/framework)
  * [Accord.NET](http://accord-net.origo.ethz.ch)
  * [Vrpn.NET](http://wwwx.cs.unc.edu/~chrisv/vrpnnet) (contains unmanaged code)
  * [BasicDSP](http://www.phon.ucl.ac.uk/home/mark/basicdsp/)
  * [Dynamic Data Display](http://dynamicdatadisplay.codeplex.com)

All fore-mentioned libraries are provided with Adastra's downloads.

  * [Octave](Octave.md) can also be considered as a one big software library as it implements a wide list mathematical algorithms. [Octave](Octave.md) and also [OpenVibe](OpenVibe.md) are additional dependencies that are installed separately from Adastra.

Check this page if you are using [Emotiv EPOC](EmotivEPOCH.md).

# C# Interfaces #

  * Implement IRawDataReader - acquires raw data. For example the EmotivRawDataReader is used as a link between Adastra and Emotiv driver.

  * IFeatureGenerator - classes that inherit this interface provide feature vectors used by machine learning algorithms. One FeatureGenerator is responsible for all previous steps such as: acquiring signal, time slicing, signal filtering and calculation of the feature vectors themselves. For example the OpenVibeFeatureGenerator does all this job by connecting to OpenVibe.

# Additional Notes #

.NET class OpenVibeController contains calls to several Windows API unmanaged functions. Running under Linux might be possible. See [Mono porting](MonoPorting.md)