# How to configure Emotiv EPOC #

[Emotiv EPOC](http://emotiv.com) is a relatively cheap EEG device that comes with Software Development KIT in several programming languages. Adastra utilize it through a C# wrapper provided by Emotiv.

Please, note that in order to be able to use the raw EEG signal from Emotiv, you need to buy [Emotiv Research SDK](http://emotiv.com/apps/sdk/209/). Only this SDK edition provides access to the RAW EEG signal used by OpenVibe and Adasta! Developer edition is not enough.

Two options are available. It is recommended that you use the first one based on OpenVibe. Second one is still work in progress.

  * Since version 0.12 OpenVibe supports Emotiv through configuration in the OpenVibe's Acquisition Server: [http://openvibe.inria.fr/how-to-connect-emotiv-epoc-with-openvibe](http://openvibe.inria.fr/how-to-connect-emotiv-epoc-with-openvibe). If you are using an older version of OpenVibe or would like to learn more then follow this [http://openvibe.inria.fr/documentation/0.8.0/Doc\_FAQ.html#Doc\_FAQ\_Emotiv](http://openvibe.inria.fr/documentation/0.8.0/Doc_FAQ.html#Doc_FAQ_Emotiv).

  * You can enable native support for Emotiv in Adastra by putting edk.dll and edk\_utils.dll in Adastra's bin folder (usually where Adastra.exe is installed). You should get these dlls from: "\Program Files\Emotiv Research Edition SDK\_v1.0.0.4-PREMIUM" depending on your Emotov SDK installation.

Adastra supports [WPF](http://en.wikipedia.org/wiki/Windows_Presentation_Foundation) signal charting for Emotiv EPOC.