DIR=$PWD

echo "Initializing ipfs-echo project"

cd mod/ipfs-cs/
sh init.sh
cd $DIR

cd lib
sh get-libs.sh
cd $DIR
