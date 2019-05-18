Welcome !
=========


This repository contains the source code for: **FxCopParser.exe**


## Background


I faced a paticular issue while trying to integrate FxCop with Jenkins.

The specific output I wanted was, _'If there's an error reported by FxCop, the Jenkins job should fail.'_

Even though Violation Plugin [https://wiki.jenkins.io/display/JENKINS/Violations] helped with the visualisation of the errors, it didn't help with the build failure that I wanted.

Here's my FxCop.project configurations:

`"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe" /project:"D:\Testing\Source\FxCop\BrokerApplication.FxCop" /out:"D:\Testing\Source\FxCop\BrokerApplication.xml"`


## What FxCopParser.exe does

It's a very simple console application.

This program will read the FxCop report and calculate the following:

* criticalErrors
* errors
* criticalWarnings
* warnings

and if there are any _criticalErrors_ or _errors_ will will output the exit code 'Exit(1)'
