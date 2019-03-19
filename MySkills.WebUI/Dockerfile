FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

# Install node and npm
ENV NODE_VERSION 8.12.0
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN wget "$NODE_DOWNLOAD_URL" -O nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA  nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

# Install npm packages first, this is slow so we want to minimise the number of un-cached runs
WORKDIR /src/MySkills.WebUI/ClientApp/
COPY MySkills.WebUI/ClientApp/package.json .
COPY MySkills.WebUI/ClientApp/package-lock.json .

RUN npm install

# Restore dotnet before build to allow for caching
WORKDIR /
COPY MySkills.Application/MySkills.Application.csproj /src/MySkills.Application/
COPY MySkills.Common/MySkills.Common.csproj /src/MySkills.Common/
COPY MySkills.Domain/MySkills.Domain.csproj /src/MySkills.Domain/
COPY MySkills.Infrastructure/MySkills.Infrastructure.csproj /src/MySkills.Infrastructure/
COPY MySkills.Persistence/MySkills.Persistence.csproj /src/MySkills.Persistence/
COPY MySkills.WebUI/MySkills.WebUI.csproj /src/MySkills.WebUI/

RUN dotnet restore /src/MySkills.WebUI/MySkills.WebUI.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/MySkills.WebUI/MySkills.WebUI.csproj --no-restore -c Release
RUN dotnet publish /src/MySkills.WebUI/MySkills.WebUI.csproj --no-restore -c Release -o /app

# Copy compiled app to runtime container
FROM base AS final
COPY --from=build /app .
CMD ["dotnet", "MySkills.WebUI.dll"]