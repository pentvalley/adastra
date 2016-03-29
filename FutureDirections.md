### Short-term plans ###
  * add support for [P300](http://openvibe.inria.fr/documentation/unstable/Doc_Scenario_InsermP300Speller.html)
  * add support for [SSVEP](http://openvibe.inria.fr/documentation/unstable/Doc_Scenario_SSVEP.html)
  * add posterior probability [0..1] to all machine learning algorithms - not just +/-
  * add support for [Emotiv EPOC](EmotivEPOCH.md) without using OpenVibe by implementing the same Digital Signal Processing
  * add parallel computing for machine learning algorithms thanks to Microsoft Task Parallel Library or Microsoft [Accelerator](http://research.microsoft.com/en-us/projects/accelerator)
  * implement additional machine learning algorithms
  * evaluate [Machine Learning for .NET](http://machine.codeplex.com)
  * explore the idea of having calculations of the machine learning models (NN, SVM) distributed over the Microsoft Azure cloud

### Long-term plans ###

  * classification of a whole EEG record of length 3-15 minutes. This will be used to discover famous [neurodegenerative diseases](http://en.wikipedia.org/wiki/Neurodegeneration) such as [Alzheimer](http://en.wikipedia.org/wiki/Alzheimer%E2%80%99s). Today existing tests about Alzheimer diseases are often not conclusive enough, so one more will be definitely useful.
    * using non-negative matrix factorization
  * using WPF to display and annotate events in the signal
    * e.x. annotate EEG spikes as an eye-blink or rapid eye movement, etc