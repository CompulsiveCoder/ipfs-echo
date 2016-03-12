BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

git clone https://github.com/CompulsiveCoder/ipfs-echo.git --branch $BRANCH
cd ipfs-echo

git submodule update --init --recursive

sh init-build-run.sh
