FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.4-focal
RUN mkdir -p /app
RUN apt-get update \  
	&& apt-get install -y --no-install-recommends \
		ca-certificates \
		\
		libc6 \
		ghostscript \
		libgcc1 \
		libunwind8 \
		libgssapi-krb5-2 \
		liblttng-ust0 \
		libssl-dev \
		libstdc++6 \
		zlib1g \
		libgdiplus \
	&& rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY ./bin/dockercontent .
EXPOSE 80
ENTRYPOINT ["dotnet", "GameManagement.dll"]