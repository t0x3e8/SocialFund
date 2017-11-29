var gulp = require('gulp');

// copy of data.json file in order to satify Unit Tests
gulp.task('prepUnitTests', function () {
    gulp.src('SF.App/data.json')
        .pipe(gulp.dest('SF.Tests/bin/Debug/netcoreapp2.0/'));
})

gulp.task('copyLibs', function () {
    // font awesome
    gulp.src('node_modules/components-font-awesome/css/*.css')
        .pipe(gulp.dest('SF.App/wwwroot/css/lib/'));

    gulp.src('node_modules/components-font-awesome/fonts/*')
        .pipe(gulp.dest('SF.App/wwwroot/css/fonts/'));

    // bootstrap
    gulp.src('node_modules/bootstrap/dist/css/bootstrap.*css')
        .pipe(gulp.dest('SF.App/wwwroot/css/lib/'));

    gulp.src('node_modules/bootstrap/dist/js/bootstrap.*js')
        .pipe(gulp.dest('SF.App/wwwroot/js/lib/'));

    // datatables
    gulp.src('node_modules/datatables.net-bs4/css/dataTables.bootstrap4.*css')
        .pipe(gulp.dest('SF.App/wwwroot/css/lib/'));

    gulp.src('node_modules/datatables.net-bs4/js/dataTables.bootstrap4.*js')
        .pipe(gulp.dest('SF.App/wwwroot/js/lib/'));

    gulp.src('node_modules/datatables.net/js/jquery.dataTables.*js')
        .pipe(gulp.dest('SF.App/wwwroot/js/lib/'));

    // jquery
    gulp.src('node_modules/jquery/dist/jquery.*js')
        .pipe(gulp.dest('SF.App/wwwroot/js/lib/'));

    // jquery easing
    gulp.src('node_modules/jquery-easing/jquery.easing.*js')
        .pipe(gulp.dest('SF.App/wwwroot/js/lib/'));

})