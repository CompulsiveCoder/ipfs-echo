# ipfs-echo
Echos text into files on ipfs then outputs the hash.
Intended to streamline the process of posting small chunks of data to ipfs, such as from an arduino project.

Setup
  sh init.sh

Build
  sh build.sh

Usage
  mono ipfs-echo.exe "Hello world!" -h
  
The -h argument tells ipfs-echo to only output the hash, with other output details excluded.
This hash can be used to access the data via ipfs.

Example output
  QmQzCQn4puG4qu8PVysxZmscmQ5vT1ZXpqo7f58Uh9QfyY

After using ipfs-echo go to:
  http://ipfs.io/ipfs/[hash]
Example:
  http://ipfs.io/ipfs/QmQzCQn4puG4qu8PVysxZmscmQ5vT1ZXpqo7f58Uh9QfyY
