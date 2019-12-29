const gulp = require('gulp');
const del = require('del');
const log = require('fancy-log');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');

function cleanSass() {
    return del('./wwwroot/css/*.css');
}

async function compileSass() {
    return await gulp.src('./wwwroot/css/**.scss')
        .pipe(sass().on('error', log.error))
        .pipe(gulp.dest('./wwwroot/css/'))
        .pipe(cleanCss().on('error', log.error))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('./wwwroot/css/'))
}

async function watchSass(cb) {
    await compileSass();
    gulp.watch('./wwwroot/css/**.scss', compileSass);
}

exports.clean = cleanSass;
exports.compile = compileSass;
exports.watch = watchSass;

exports.default = exports.watch;
