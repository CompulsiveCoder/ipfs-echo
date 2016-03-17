echo "Preparing for ipfs-echo project"
echo "Dir: $PWD"

sudo apt-get update
sudo apt-get install -y git wget mono-complete mono-xsp4 unzip

wget -q https://raw.githubusercontent.com/ipfs/install-go-ipfs/master/install-ipfs.sh
sudo sh install-ipfs.sh

mozroots --import --sync
