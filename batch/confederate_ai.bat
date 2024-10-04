@echo off
echo Adding the remote repository 'confederateAI'...
git remote add confederateAI https://github.com/CursedPrograms/ConfederateAI.git

echo Fetching from 'confederateAI'...
git fetch confederateAI

echo Checking out the 'main' branch...
git checkout main

echo Merging 'confederateAI/main' into 'main' with unrelated histories allowed...
git merge confederateAI/main --allow-unrelated-histories

echo Committing the merge...
git commit -m "Merged from ConfederateAI repository"

echo Process complete!
pause
