var gulp = require('gulp');

gulp.task('prepUnitTests', function() {
    gulp.src('SF.App/data.json')
        .pipe(gulp.dest('SF.Tests/bin/Debug/netcoreapp2.0/'));
})