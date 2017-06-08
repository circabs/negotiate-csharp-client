cmake_minimum_required(VERSION 3.8)

enable_language(CSharp)

project(negotiate)

FILE(GLOB SOURCE_FILES 
    "${CMAKE_SOURCE_DIR}/src/*.cs"
)

add_executable(${PROJECT_NAME} ${SOURCE_FILES})
set_target_properties(${PROJECT_NAME} PROPERTIES VS_DOTNET_REFERENCES "System;System.Net;System.Web")