# UkenChallengeCs

UkenChallengeCs is a C# program designed to read integers separated by new lines from a file and find the least frequent integer. It uses a HashMap to iterate through the values and count them, before checking the values against each other to find the least common, and in the case of a tie the smallest integer is chosen.

## Installation

Extract the file, navigate to "ClickToRun" click the file and voila! The results will open in a console window.

## Usage

Putting any files with the same naming structure in the "Files" folder (replacing the old ones) will allow the program to open them and parse for the relevant information. 

The code itself is easily changed to have more or less files: In the Main Method you can add file names to read in the string "filesToLoad", simply add a comma after the last value and write your new file name inside of " ". You can also delete files and use less than the original  5 with no changes to code needed.
