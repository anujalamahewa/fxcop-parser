Welcome !
=========


This repository contains the source code for: **FxCopParser.exe**


## Background


I faced a paticular issue while trying to integrate FxCop with Jenkins.

The specific scenario I tried to achieve was, _'If there's an error reported by FxCop, the Jenkins job should fail.'_

Even though Violation Plugin _https://wiki.jenkins.io/display/JENKINS/Violations_ helped with the visualisation of the errors, it didn't help with achieving the build failure that I wanted.

Here's my FxCop.project configurations:

`"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe" /project:"D:\Testing\Source\FxCop\BrokerApplication.FxCop" /out:"D:\Testing\Source\FxCop\BrokerApplication.xml"`


## What FxCopParser.exe does

It's a very simple console application.

This program will read the FxCop report and calculate the following:

* criticalErrors
* errors
* criticalWarnings
* warnings

and if there are any _criticalErrors_ or _errors_ will will output the exit code `Exit(1)`

## How to run FxCopParser.exe

1. Checkout FxCopParser.exe (under release folder)
2. Pass the FxCop result xml file to it

`"D:\Testing\Source\FxCop\FxCopParser.exe" "D:\Testing\Source\FxCop\BrokerApplication.xml"`

If there are any _criticalErrors_ or _errors_ reported in the xml, if will return the exit code `Exit(1)`
