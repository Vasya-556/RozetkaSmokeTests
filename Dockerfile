FROM mcr.microsoft.com/playwright/dotnet:v1.64.1-noble

RUN curl -sSL https://dot.net/v1/dotnet-install.sh \
    | bash /dev/stdin --install-dir /usr/share/dotnet --channel 9.0
    
WORKDIR /app

COPY RozetkaSmokeTests.csproj ./

RUN dotnet restore

COPY . .

RUN dotnet build --configuration Release --no-restore

ENV HEADED=1

ENTRYPOINT ["xvfb-run", "-a", "dotnet", "test", "--no-build", "--no-restore", "--configuration", "Release"]