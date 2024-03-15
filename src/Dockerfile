# docker build --tag ghcr.io/<your_github_user>/asp-rest-demo:latest . 
# docker run -d -p 5001:8080 --name asp-rest-demo asp-rest-demo
# docker push ghcr.io/<your_github_user>/asp-rest-demo:latest

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# copy everything else and build app
COPY . ./source/asp-rest-demo/
WORKDIR /source/asp-rest-demo
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "asp-rest-demo.dll"]
