/Applications/Unity/Unity.app/Contents/MacOS/Unity \
    -quit \
    -batchmode \
    -nographics \
    -projectPath `pwd` \
    -executeMethod Build.PerformBuild \
    -logFile build.log
