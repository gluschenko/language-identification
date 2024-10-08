FROM ubuntu:22.04 AS build

WORKDIR /repo
COPY ["src/LanguageIdentification.MediaPipe.Native/LanguageIdentification.MediaPipe.Native.csproj", "src/LanguageIdentification.MediaPipe.Native/"]
COPY ["src/LanguageIdentification.MediaPipe.Native/Scripts/setup-build.sh", "src/LanguageIdentification.MediaPipe.Native/Scripts/"]
COPY ["src/LanguageIdentification.MediaPipe.Native/Scripts/setup-runtime.sh", "src/LanguageIdentification.MediaPipe.Native/Scripts/"]
COPY ["src/LanguageIdentification.MediaPipe.Native/Scripts/run-build.sh", "src/LanguageIdentification.MediaPipe.Native/Scripts/"]
WORKDIR /repo/src/LanguageIdentification.MediaPipe.Native

RUN bash ./Scripts/setup-runtime.sh
RUN bash ./Scripts/setup-build.sh

# Inspired by https://github.com/google-ai-edge/mediapipe/blob/master/Dockerfile

ENV DEBIAN_FRONTEND=noninteractive

# Install node.js source
RUN apt-get update && apt-get install -y ca-certificates curl gnupg && \
    curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg && \
    echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_20.x nodistro main" | tee /etc/apt/sources.list.d/nodesource.list

RUN apt-get update && apt-get install -y --no-install-recommends \
        build-essential \
        gcc g++ \
        ca-certificates \
        curl \
        ffmpeg \
        git \
        wget \
        unzip \
        nodejs \
        # npm \
        python3-dev \
        python3-opencv \
        python3-pip \
        libopencv-core-dev \
        libopencv-highgui-dev \
        libopencv-imgproc-dev \
        libopencv-video-dev \
        libopencv-calib3d-dev \
        libopencv-features2d-dev \
        software-properties-common && \
    apt-get update && apt-get install -y openjdk-8-jdk && \
    apt-get install -y mesa-common-dev libegl1-mesa-dev libgles2-mesa-dev && \
    apt-get install -y mesa-utils && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Install Clang 16
RUN wget https://apt.llvm.org/llvm.sh
RUN chmod +x llvm.sh
RUN ./llvm.sh 16
RUN ln -sf /usr/bin/clang-16 /usr/bin/clang
RUN ln -sf /usr/bin/clang++-16 /usr/bin/clang++
RUN ln -sf /usr/bin/clang-format-16 /usr/bin/clang-format

RUN pip3 install --upgrade setuptools
RUN pip3 install wheel
RUN pip3 install future
RUN pip3 install absl-py "numpy<2" jax[cpu] opencv-contrib-python protobuf==3.20.1
RUN pip3 install six==1.14.0
RUN pip3 install tensorflow
RUN pip3 install tf_slim

RUN ln -s /usr/bin/python3 /usr/bin/python

# Install Bazel
RUN apt install apt-transport-https curl gnupg -y
RUN curl -fsSL https://bazel.build/bazel-release.pub.gpg | gpg --dearmor >bazel-archive-keyring.gpg
RUN mv bazel-archive-keyring.gpg /usr/share/keyrings
RUN echo "deb [arch=amd64 signed-by=/usr/share/keyrings/bazel-archive-keyring.gpg] https://storage.googleapis.com/bazel-apt stable jdk1.8" | tee /etc/apt/sources.list.d/bazel.list

RUN apt-get update -y && apt-get install bazel-6.1.1 -y

# Install ZX
RUN npm install -g zx

COPY . .

ENTRYPOINT ["bash", "./Scripts/run-build.sh"]
