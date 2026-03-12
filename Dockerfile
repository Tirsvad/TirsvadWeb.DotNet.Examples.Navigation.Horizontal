################################################################################
# This Dockerfile defines a multi-stage build for a .NET application, including stages for building, testing, and publishing the application.
# The final stage creates a runtime image that can be used to run the published application.
################################################################################
FROM debian:13-slim AS base

# Install required OS packages
RUN ["apt-get", "update"]
RUN ["apt-get", "upgrade", "-y"]

RUN apt-get install -y --no-install-recommends \
    ca-certificates \
    wget \
    curl \
    build-essential \
    clang \
    zlib1g-dev \
    libssl-dev \
    python3 \
    git \
    cmake \
    && rm -rf /var/lib/apt/lists/*
# Ensure python is available in PATH as 'python'
RUN ln -s /usr/bin/python3 /usr/bin/python

# Install .NET via Microsoft APT repository (deb package registers the repo and GPG key)
ENV DOTNET_ROOT=/usr/share/dotnet \
    DOTNET_CLI_TELEMETRY_OPTOUT=1

RUN set -eux && \
     wget "https://packages.microsoft.com/config/debian/13/packages-microsoft-prod.deb" -O "packages-microsoft-prod.deb" && \
     dpkg -i "packages-microsoft-prod.deb" && \
     rm "packages-microsoft-prod.deb"

#RUN set -eux; \
    #apt-get update; \
    #apt-get install aspnetcore-runtime-8.0
    #apt-get install -y dotnet-sdk-10.0
RUN ["apt-get", "update"]
RUN ["apt-get", "install", "-y", "aspnetcore-runtime-10.0" ]

WORKDIR /src

################################################################################
# Build stage
################################################################################
FROM base AS build
COPY . .
RUN ["apt-get", "install", "-y", "dotnet-sdk-10.0"]
RUN ["dotnet", "restore"]
RUN ["dotnet", "build", "--no-restore", "-c", "Release"]

# Test stage
FROM build AS test

RUN ["dotnet", "test", "--no-build", "--verbosity", "normal"]

################################################################################
# Publish stage
################################################################################
FROM build AS publish
RUN dotnet workload install wasm-tools
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish src/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI.csproj --no-build -c Release -o /app/publish

################################################################################
# Final runtime image (optional, if you want a minimal image for running the app)
################################################################################
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5401
ENTRYPOINT ["dotnet", "/app/Examples.Navigation.Horizontal.WebUI.dll"]
