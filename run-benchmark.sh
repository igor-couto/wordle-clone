GREEN='\033[0;32m'
RED='\033[0;31m'
NOCOLOR='\033[0m'
BOLD='\033[1m'

echo
echo -e "${BOLD}Building in Release mode ...${NOCOLOR}"
dotnet build -c Release


echo
echo -e "${BOLD}Running benchmark ...${NOCOLOR}"
dotnet [...] .dll