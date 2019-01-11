dotnet publish -c Debug
docker build -f ".\Dockerfile.deb" -t loupetester:dev1 --target base ".\bin\Debug\netcoreapp2.1\publish"
