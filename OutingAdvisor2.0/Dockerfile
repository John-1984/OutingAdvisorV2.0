FROM microsoft/dotnet AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet AS runtime
WORKDIR /app
COPY --from=build /app/out .
COPY wwwroot/images/locationImages /app/wwwroot/images/locationImages

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "OutingAdvisorV2.dll"]