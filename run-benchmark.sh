GREEN='\033[0;32m'
RED='\033[0;31m'
NOCOLOR='\033[0m'
BOLD='\033[1m'

echo
echo -e "${BOLD}Building in Release mode ...${NOCOLOR}"
dotnet build .\test\benchmark\Benchmark.csproj -c Release

echo
echo -e "${BOLD}Running benchmark ...${NOCOLOR}"
dotnet .\test\benchmark\bin\Release\net8.0\Benchmark.dll