BRANCH=$1

if [ -z "$BRANCH" ]; then
    BRANCH="master"
fi

echo "Branch: $BRANCH"

curl https://raw.githubusercontent.com/CompulsiveCoder/ipfs-echo/$BRANCH/prepare.sh | sh
curl https://raw.githubusercontent.com/CompulsiveCoder/ipfs-echo/$BRANCH/run-from-github.sh | sh

