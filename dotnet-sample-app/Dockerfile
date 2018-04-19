FROM microsoft/aspnetcore-build AS build
WORKDIR /app
COPY . .
RUN dotnet publish -o out

FROM microsoft/aspnetcore AS runtime

RUN DEBIAN_FRONTEND=noninteractive apt-get update && apt-get install -y unzip procps
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v vs2017u1 -l ~/vsdbg

WORKDIR /app
COPY --from=build /app/out ./
CMD  ASPNETCORE_URLS=http://0.0.0.0:${PORT} dotnet dotnet-sample-app.dll
