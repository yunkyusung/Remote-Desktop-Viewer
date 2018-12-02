[Version]
Class=IEXPRESS
SEDVersion=3
[Options]
PackagePurpose=ExtractOnly
ShowInstallProgramWindow=0
HideExtractAnimation=0
UseLongFileName=1
InsideCompressed=0
CAB_FixedSize=0
CAB_ResvCodeSigning=0
RebootMode=I
InstallPrompt=%InstallPrompt%
DisplayLicense=%DisplayLicense%
FinishMessage=%FinishMessage%
TargetName=%TargetName%
FriendlyName=%FriendlyName%
AppLaunched=%AppLaunched%
PostInstallCmd=%PostInstallCmd%
AdminQuietInstCmd=%AdminQuietInstCmd%
UserQuietInstCmd=%UserQuietInstCmd%
SourceFiles=SourceFiles
[Strings]
InstallPrompt=You are about to extract RemoteDesktopViewer(RDV) v1.0.0
DisplayLicense=C:\Users\The Boys\Documents\GitHub\Remote-Desktop-Viewer\LICENSE.txt
FinishMessage=RDV has been extracted
TargetName=C:\Users\The Boys\Documents\GitHub\Remote-Desktop-Viewer\RDV_v1.0.0_Setup.exe
FriendlyName=RemoteDesktopViewr(RDV)_v1.0.0_Setup
AppLaunched=
PostInstallCmd=
AdminQuietInstCmd=
UserQuietInstCmd=
FILE0="Client.exe"
FILE1="Server.exe"
FILE2="LICENSE"
FILE3="README.md"
[SourceFiles]
SourceFiles0=C:\Users\The Boys\Documents\GitHub\Remote-Desktop-Viewer\Client\Client\bin\Debug\
SourceFiles1=C:\Users\The Boys\Documents\GitHub\Remote-Desktop-Viewer\Server\Server\bin\Debug\
SourceFiles2=C:\Users\The Boys\Documents\GitHub\Remote-Desktop-Viewer\
[SourceFiles0]
%FILE0%=
[SourceFiles1]
%FILE1%=
[SourceFiles2]
%FILE2%=
%FILE3%=
