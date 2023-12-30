GREEN='\033[0;32m'
RED='\033[0;31m'
NOCOLOR='\033[0m'
BOLD='\033[1m'

echo
echo -e "${BOLD}Running backend application...${NOCOLOR}"
dotnet run --project src/WordleClone.csproj
if [ $? == 0 ] ; then
  echo -e "${GREEN} ✔ The backend application is running.${NOCOLOR}"
  echo
else 
  echo -e "${RED} ✘ Error while running the backend application${NOCOLOR}"
  exit 1
fi

echo
echo -e "${BOLD}Executing e2e tests...${NOCOLOR}"
dotnet test test/e2e/WordleClone.E2E.csproj