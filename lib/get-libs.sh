wget http://nuget.org/nuget.exe

mozroots --import --sync

mono nuget.exe install nunit
mono nuget.exe install newtonsoft.json
