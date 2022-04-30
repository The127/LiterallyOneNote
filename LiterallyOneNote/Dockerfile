FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LiterallyOneNote.csproj", "LiterallyOneNote/"]
RUN dotnet restore "LiterallyOneNote/LiterallyOneNote.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "LiterallyOneNote.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiterallyOneNote.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
