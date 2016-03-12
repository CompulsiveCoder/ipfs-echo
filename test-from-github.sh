BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH=$(git branch | sed -n -e 's/^\* \(.*\)/\1/p')
fi

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

echo "Branch: $BRANCH"

git clone https://github.com/CompulsiveCoder/ipfs-echo.git --branch $BRANCH
cd ipfs-echo

git submodule update --init --recursive

sh init-build-test.sh
