# Introduction

Quick and simple application to remove rerun failures from spec flow execution code.

# Getting Started

1. Clone repo
2. Edit the program file and add your specflow user Ui guid, can be found in existing runs json files
3. Build the project and it should produce an EXE file within the bin folder
4. from a command line run the exe
   -.\LivingDocParse.exe "path to Folder to all json execution files" "path to output of json file including file name to pass into specflow report generation"

-Use it in your pipeline you will need all the files from build output or build it as a self contained exe and add use it that way
