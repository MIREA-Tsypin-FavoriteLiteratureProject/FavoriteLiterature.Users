FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app
COPY . .

# Add a label for the image name
LABEL maintainer="Tsypin Ilya <tsypin.i.p@mail.ru>"
LABEL version="1.0"
LABEL description="FavLit.Works project image"

# Restore the NuGet packages
RUN dotnet restore

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release --no-build -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_HTTP_PORT=80 
ENV ASPNETCORE_DEBUG_PORT=84
EXPOSE 80
EXPOSE 84

ENTRYPOINT ["dotnet", "Users.API.dll"]