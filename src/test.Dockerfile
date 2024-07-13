﻿FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN wget https://aka.ms/getvsdbgsh && \
    sh getvsdbgsh -v latest  -l /vsdbg

### CLD3
RUN apt -y update
RUN apt -y install protobuf-compiler libprotobuf-dev
###

### FastText
RUN apt -y update
RUN apt -y install curl
RUN mkdir /models -p
RUN curl --location -o /models/fasttext176.bin https://dl.fbaipublicfiles.com/fasttext/supervised-models/lid.176.bin
# RUN curl --location -o /models/fasttext217.bin https://huggingface.co/facebook/fasttext-language-identification/resolve/main/model.bin?download=true
###

# Adding local nuget packages
RUN \
  for dir in $(find /src -type d -path '*/out');\
  do \
    dotnet nuget add source $dir; \
  done

RUN dotnet nuget list source

