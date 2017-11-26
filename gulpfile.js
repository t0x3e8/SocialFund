var gulp = require('gulp');

// copy of data.json file in order to satify Unit Tests
gulp.task('prepUnitTests', function() {
    gulp.src('SF.App/data.json')
        .pipe(gulp.dest('SF.Tests/bin/Debug/netcoreapp2.0/'));
})