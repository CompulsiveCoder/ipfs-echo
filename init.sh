#ssudo apt-get update
sudo apt-get install -y wget git unzip mono-runtime mono-xsp4

git submodule update --init --recursive

wget -q https://raw.githubusercontent.com/ipfs/install-go-ipfs/master/install-ipfs.sh
sudo sh install-ipfs.sh

DIR=$PWD

cd mod/ipfs-cs/
sh init.sh
cd $DIR

cd lib
sh get-libs.sh
cd $DIR
