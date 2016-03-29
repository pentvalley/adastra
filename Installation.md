#Steps to install and start Adastra.

# Introduction #

These are instructions on how to use Adastra. Everything should be straight-forward. No special skills are required.

# Details #
  * Microsoft Windows 7/Vista/XP (Windows 7 recommended)
  * [MS .NET framework 4.0](http://www.microsoft.com/net/download.aspx) is required
  * uninstall any previous Adastra deployment
  * download and install Adastra
  * install OpenVibe 0.11 or later (usually in c:\Program Files\openvibe)
  * check [Emotiv EPOC](EmotivEPOCH.md) if you are using this device
  * start Adastra (Adastra.exe) and set OpenVibe's install folder in the main form (if not set automatically)

# Additional notes #
OpenVibe is started by Adastra, you do not need to start it in advance. Adastra modifies one of the OpenVibe's bat files in order to resolve a bug with parameters forwarding in OpenVibe 10.1. Currently Adastra runs only on Windows. Running Adastra under [Mono](http://www.mono-project.com) is currently unsupported. See [Mono porting](MonoPorting.md) page.