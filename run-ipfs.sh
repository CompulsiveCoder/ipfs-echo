DIR=src/ipfs.echo.WWW/ipfs-data
mkdir $DIR
cd $DIR
/usr/local/bin/ipfs init -f
/usr/local/bin/ipfs daemon
