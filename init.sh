DIR=$PWD

# TODO Move this to the prepare script (and create a corresponding docker image for testing)
wget -q https://raw.githubusercontent.com/ipfs/install-go-ipfs/master/install-ipfs.sh
sudo sh install-ipfs.sh

cd $DIR

cd mod/ipfs-cs/
sh init.sh
cd $DIR

cd lib
sh get-libs.sh
cd $DIR
