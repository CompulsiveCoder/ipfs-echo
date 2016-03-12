BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

echo "Branch: $BRANCH"

git clone https://github.com/CompulsiveCoder/ipfs-echo.git --branch $BRANCH
cd ipfs-cs
sh init-build-test.sh
