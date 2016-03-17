echo "Starting build for ipfs-echo project"
echo "Dir: $PWD"

DIR=$PWD

cd mod/ipfs-cs/
sh build.sh
cd $DIR

xbuild src/ipfs.echo.sln /p:Configuration=Release
