FROM smatyukevich/dotnet-dbg 

COPY ./bin/Debug/netcoreapp2.0/publish /root/app

WORKDIR /root/app
CMD  ASPNETCORE_URLS=http://0.0.0.0:${PORT} dotnet /root/app/dotnet-sample-app.dll
