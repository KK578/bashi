const gulp = require('gulp');
const del = require('del');
const log = require('fancy-log');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');

function debugLog(data) {
    try {
        const filename = data.history[0];
        log.info(filename);
    }
    catch {
        // Intentional ignore.
    }
}

function cleanSass() {
    return del('./wwwroot/css/*.css');
}

async function compileSass(cb) {
    await del('./wwwroot/css/**.css');
    await gulp.src('./wwwroot/css/*.scss', { since: gulp.lastRun(compileSass) })
        .on('data', (data) => log.info(JSON.stringify(data.history[0])))
        .pipe(sass())
        .pipe(gulp.dest('./wwwroot/css/'))
        .pipe(cleanCss())
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('./wwwroot/css/'));
    cb();
}

function watchSass(cb) {
    gulp.watch('./wwwroot/css/**.scss', compileSass);
}

exports.clean = cleanSass;
exports.compile = compileSass;
exports.watch = watchSass;

exports.default = exports.watch;
