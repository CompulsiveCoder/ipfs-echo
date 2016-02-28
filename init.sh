sudo apt-get update
sudo apt-get install mono-complete

cd lib
sh get-libs.sh
cd ..

git submodule update --init --recursive
