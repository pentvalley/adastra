For the latest updates, please visit the [release log](ReleaseLog.md).

Currently in trunk: [fieldtrip buffer](http://fieldtrip.fcdonders.nl/development/realtime) support

### General Description: ###

Adastra is a BCI ([Brain Computer Interface](http://en.wikipedia.org/wiki/Brain-computer_interface)) application. Adastra's main goals include:

  * apply [machine learning](MachineLearning.md) and DSP in BCI
  * create an industrial application that is practical, easy to install, has a contemporary look and feel and it is easily extendable

Adastra can work in combination with another BCI application called OpenVibe. Adastra can use real-time data from OpenVibe.

Adastra also supports direct access to [Emotiv EPOC](EmotivEPOCH.md) (since version 2.1).

Adastra supports executing [Octave](Octave.md)(Matlab) code thanks to a C# Octave wrapper (since version 2.5).

Adastra is written in Microsoft C# (which is in respect to target goal two).

Please, check [Installation](Installation.md) and [Adastra tutorial](UsageTutorial.md).

There are different scenarios supported in Adastra. For example OpenVibe is used to acquire, filter the [EEG](http://en.wikipedia.org/wiki/Eeg) signal and generate feature vectors from it. Then these feature vectors are forwarded to Adastra's machine learning (ML) algorithms. ML is used to train Adastra to detect actions such as left/right and up/down brain controlled mouse cursor movements.

Several [machine learning](MachineLearning.md) algorithms are supported:
  * LDA+MLP: Linear Discriminant Analysis + Multi - Layer Perceptron
  * LDA+SVM: Linear Discriminant Analysis + Support Vector Machines

Software developers should check the [Programming](Programming.md) section.

### Usage: ###

  * it can be used for BCI experiments by researchers
  * commercial EEG software and/or devices
  * to help disabled people (to control computers, wheelchairs, etc)
  * [exoskeletons](exoskeleton.md) (Iron Man suit?)


Information about future development is provided [here](FutureDirections.md).

Related project: [Gipsa-lab extensions](http://code.google.com/p/openvibe-gipsa-extensions) for the OpenVibe project. Contains a game that you play using EEG amplifier and the [P300](http://en.wikipedia.org/wiki/P300_%28neuroscience%29) paradigm.