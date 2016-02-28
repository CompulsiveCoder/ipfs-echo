sudo apt-get update
sudo apt-get install -y mono-runtime mono-xsp4

cd mod/ipfs-cs/
sh init.sh
cd ../..

cd lib
sh get-libs.sh
cd ..

git submodule update --init --recursive
