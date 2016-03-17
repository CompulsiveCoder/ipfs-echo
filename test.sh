CATEGORY=$1

if [ -z "$CATEGORY" ]; then
    CATEGORY="Unit"
fi

echo "Testing ipfs-echo project"
echo "Dir: $PWD"
echo "Category: $CATEGORY"



mono lib/NUnit.Runners.2.6.4/tools/nunit-console.exe bin/Release/ipfs.echo.*.dll --include=$CATEGORY
