Core algorithms in Adastra are pure C# and they will run on [Mono](http://www.mono-project.com/Main_Page) without modification.

Adastra can use [GTK Sharp](http://www.mono-project.com/GtkSharp) for UI.

When porting to [Mono](http://www.mono-project.com/Main_Page) the following components will need special care:

  * VRPN.net contains unmanaged code
  * OpenVibeController should be ported (should not be a problem)
  * Windows Forms signal charting should be disabled or replaced with another control
  * WPF is used by Adastra, so these parts will need to be totally rewritten