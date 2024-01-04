pushd WeatherApp.Gateway
dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer -p:PublishSingleFile=true --self-contained true
popd

pushd WeatherApp.GrpcService
dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer -p:PublishSingleFile=true --self-contained true
popd

pushd WeatherApp.Web
dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer -p:PublishSingleFile=true --self-contained true
popd
