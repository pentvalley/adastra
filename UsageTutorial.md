# Introduction #

This page explains how to conduct a scientific experiment and points out what are the different configurations you need to perform in order to achieve your goal.

# Details #

Our scenario will be to acquire data from an EEG signal, train using machine learning and evaluate our computed model. "Model" is the result from the training process produced by a certain machine learning algorithm (also called "method"). The resulted "model" is often called "classifier". Scenario is based on Adastra 2.4.

These are the quick steps for the above scenario:
  1. Start Adastra
  1. Choose OpenVibe as data source from the three options (OpenVibe, Emotiv, Optimizator)
  1. Select "Train" from the top dropdown menu
  1. if you are going to use real-time signal then you will need to start OpenVibe acquisition server manually and check "Real-time" in Adastra
  1. Click "Start"
  1. Two things happen in parallel:
    * an instance of OpenVibe is programatically started (console window that contains OpenVibe startup output)
    * a new "Train" form appears that is explained in the next steps
  1. Next you need to record data for specific actions (at least 2). Predefined actions include Left,Right,Up (mouse cursor movement). Recorded data is not the EEG signal itself, but in the form of feature vectors. These "feature vectors" are the format required by the machine learning methods
  1. next you should save what you have just recorded by clicking the "Managed Recordings" button
  1. next you can start computing a model (building a "classifier") or (if you saved your source data) exit this form and proceed to the next step (recommended)
  1. when in Adastra main form choose "Optimizator" in the left bottom corner of the main form
  1. click "Start"
  1. a new form appears, select "Load EEG record", this will load the previously recorded data (Left, Right, Up..).
  1. next select a method to train and evaluate
  1. click "Start" on the Optimizator form
  1. wait patiently until all methods are trained
  1. final result will appear as each method will display an error value and time elapsed
  1. less error means better method, choose "Save Best Model" to save the method with least error
  1. you can also evaluate your method in real-time later