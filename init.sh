sudo apt-get update
sudo apt-get install -y mono-complete mono-xsp4

git submodule update --init --recursive

DIR=$PWD

cd mod/ipfs-cs/
sh init.sh
cd $DIR

cd lib
sh get-libs.sh
cd $DIR
