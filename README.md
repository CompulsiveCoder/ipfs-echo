# ipfs-echo
Streamlines the process of posting small chunks of data to ipfs, such as from an arduino project.

# One Line Download and Run
curl https://raw.githubusercontent.com/CompulsiveCoder/ipfs-echo/master/run-from-github.sh | sh

# Setup

  sh init.sh

# Build

  sh build.sh

# Basic Usage

Syntax:
  mono ipfs-echo.exe "[text]" -h

Example:
  mono ipfs-echo.exe "Hello world!" -h

Notes:
- The -h argument tells ipfs-echo to only output the hash, with other output details excluded. This hash can be used to access the data via ipfs.

Example output:

  QmQzCQn4puG4qu8PVysxZmscmQ5vT1ZXpqo7f58Uh9QfyY

After using ipfs-echo go to:

  http://ipfs.io/ipfs/[hash]
  
Example ipfs URL:

  http://ipfs.io/ipfs/QmQzCQn4puG4qu8PVysxZmscmQ5vT1ZXpqo7f58Uh9QfyY

# Publishing Data

Data can be published with a fixed and persistent URL. The same URL can be used to access the data even after it changes or is updated.

Syntax:

  mono ipfs-echo.exe "[text]" --publish "[custom key]"

Examples:

  mono ipfs-echo.exe "Hello world!" --publish "MyProject"

  mono ipfs-echo.exe "Hello world!" --publish "6c1f9b51-721f-4ccf-9a0e-ee06c4280faa"

Notes:
- Use the "--replace" argument to replace the old text with the new text. By default, it will append the text to the end so that older data isn't accidentally overwritten.

Example output snippet:

Date: 19/11/2015 1:24:02 PM; Temperature: 33c;
http://localhost:8080/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt
https://ipfs.io/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt

Date: 19/11/2015 1:24:37 PM; Temperature: 33c;
http://localhost:8080/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt
https://ipfs.io/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt

Date: 19/11/2015 1:25:11 PM; Temperature: 33c;
http://localhost:8080/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt
https://ipfs.io/ipns/QmeBPLVyvWcnGk3n6c5vapXzbkMH3ZQQiwhnnfTRdcSGMr/TemperatureData/data.txt

