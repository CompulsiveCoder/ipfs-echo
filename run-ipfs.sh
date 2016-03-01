DIR=src/ipfs.echo.WWW/ipfs-data
mkdir $DIR
cd $DIR
ipfs init -f
ipfs daemon
