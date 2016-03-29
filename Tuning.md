# Introduction #
When doing Digital Signal Processing and Machine Learning you can choose a operation workflow and tune each one of the elements of the workflow.

# Configure OpenVibe filters #

A "box" in OpenVibe scenario is a single element in workflow which is actually called a "scenario". You can open an OpenVibe scenario in Adastra and tune each one of the following boxes:

  * You can select which channels to be used from the "Channel Selector"
  * You can use a Surface Laplacian to focus the signal around specific channels. Laplacian derivation is often used as a spatial filter to enhance scalp potential data. It is used to improve the signal-to-noise ratio and to enhance 'striate cortical activity' selectively. The purpose of this spatial filter is to create the best possible linear combination of electrodes in order to obtain signal with least noise possible and to maximize the contribution of each channel to the 'useful' signal.

  * Several simple digital filters are used that you may want to enable/disable or modify.

# Configure Machine Learning #
There are several machine learning models and learning methods.

  * Logistic regression usually use two main learning algorithms. First one is **gradienet descent** and the second one is normal equation.

  * There are currently two two types of neural networks supported. First one is a standard multi-layer perceptron. MLP has an automatic number of hidden rows assignment ...