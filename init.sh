sudo apt-get update
sudo apt-get install -y mono-base mono-xsp4

cd lib
sh get-libs.sh
cd ..

git submodule update --init --recursive
