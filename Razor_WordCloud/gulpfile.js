/// <binding BeforeBuild='_main_dev' />
//task runner explorer

var gulp = require('gulp');

gulp.task('clean', function ()
{
    del(["wwwroot/js/*.js", "wwwroot/css/*.css"]);/*, "wwwroot/lib/*.*"*/
});

gulp.task('jquery', function ()
{
    gulp.src(["node_modules/jquery/dist/jquery.js"])
        .pipe(gulp.dest("wwwroot/js"));
});

gulp.task('bootstrap_css', function ()
{
    gulp.src(["node_modules/bootstrap/dist/css/bootstrap.css"])
        .pipe(gulp.dest("wwwroot/css"));
});
