BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

docker run -it compulsivecoder/ubuntu-mono-ipfs /bin/bash -c "curl https://raw.githubusercontent.com/CompulsiveCoder/ipfs-echo/$BRANCH/run-from-github.sh | sh"
