Given a dynamic library somewhere in `./out-x64`, a wrapper, and an executable...

## Shared

CMake for Wrapper:
```
set(SOURCES
"source.cpp")

add_library(${PROJECT_NAME} ${SOURCES})
```
CMake for executable:


## Windows

CMake for Wrapper:
```
target_link_directories(${PROJECT_NAME} PUBLIC out-x64)
target_link_libraries(${PROJECT_NAME} PUBLIC AngouriMath.CPP.Exporting)
```
CMake for executable:

TODO:
