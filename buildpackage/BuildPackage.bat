echo "Building the nuget package for MvcRouteTester."

copy ..\src\MvcRouteTester\bin\Debug\MvcRouteTester.dll .\lib\net45
nuget pack 

echo "Done."
pause

