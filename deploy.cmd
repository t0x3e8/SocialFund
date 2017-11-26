if [ -e "$DEPLOYMENT_TARGET/SF.App/bower.json" ]; then
  cd "$DEPLOYMENT_TARGET/SF.App/"
  eval ./node_modules/.bin/bower install
  exitWithMessageOnError "bower failed"
  cd - > /dev/null
fi