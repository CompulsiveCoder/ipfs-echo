echo "Getting libraries for ipfs-echo project"
echo "Dir: $PWD"

NUGET_FILE="nuget.exe"

if [ ! -f "$NUGET_FILE" ];
then
    wget http://nuget.org/nuget.exe
fi

mono nuget.exe install nunit -version 2.6.4
mono nuget.exe install nunit.runners -version 2.6.4
mono nuget.exe install newtonsoft.json -version 8.0.3

# Copy libraries to the submodule to speed up the build
cp nuget.exe ../mod/ipfs-cs/lib
cp NUnit.2.6.4/ ../mod/ipfs-cs/lib -r
cp NUnit.Runners.2.6.4/ ../mod/ipfs-cs/lib -r
