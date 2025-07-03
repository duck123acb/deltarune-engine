# Makefile for raylib project

# Compiler and flags
CXX = clang++
CXXFLAGS = -Wall -std=c++17

# Paths
RAYLIB_PATH = $(HOME)/raylib
INCLUDES = -I$(RAYLIB_PATH)/src
LIBDIR = -L$(RAYLIB_PATH)/src

# Libraries
LIBS = -lraylib -ldl -lGL -lm -lpthread -lrt -lX11

# Targets
TARGET = main
SRC = src/main.cpp $(wildcard src/engine/*.cpp)

# Default rule
all: $(TARGET)

$(TARGET): $(SRC)
	$(CXX) $(CXXFLAGS) $(SRC) -o $(TARGET) $(INCLUDES) $(LIBDIR) $(LIBS)

# Clean up build files
clean:
	rm -f $(TARGET)

