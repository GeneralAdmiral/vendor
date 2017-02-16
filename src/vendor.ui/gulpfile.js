/// <binding AfterBuild='default' Clean='clean' />
/// <reference path="./wwwroot/app/systemjs.config.js" />

var gulp = require('gulp');
var del = require('del');
var postcss = require('gulp-postcss');
var autoprefixer = require('autoprefixer');
var cssnano = require('cssnano');
var ts = require('gulp-typescript');
var sourcemaps = require('gulp-sourcemaps');


var tsProject = ts.createProject('tsconfig.json');
var paths = {
    src: ['source/configs/systemjs.config.js', 'source/app/**/*.ts', 'source/app/**/*.html'], // "source/app/**/*.ts", "source/app/**/*.js", "source/app/**/*.js.map",
    libs: [
        'node_modules/@angular/core/bundles/core.umd.js',
        'node_modules/@angular/common/bundles/common.umd.js',
        'node_modules/@angular/compiler/bundles/compiler.umd.js',
        'node_modules/@angular/platform-browser/bundles/platform-browser.umd.js',
        'node_modules/@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
        'node_modules/@angular/http/bundles/http.umd.js',
        'node_modules/@angular/router/bundles/router.umd.js',
        'node_modules/@angular/forms/bundles/forms.umd.js',
        'node_modules/@angular/material/material.umd.js',
        'node_modules/angular-in-memory-web-api/bundles/in-memory-web-api.umd.js',
        // 'node_modules/angular2-in-memory-web-api/**/*.js',
        // 'node_modules/rxjs/**/*.js'

        // "node_modules/reflect-metadata/Reflect.js",
        'node_modules/zone.js/dist/zone.js',
        // "node_modules/core-js/client/shim.min.js"
        'node_modules/systemjs/dist/system.js',
    ],
    material: [
        'node_modules/@angular/material/**/*.js'
    ],
    rxjs: [
        'node_modules/rxjs/**/*.js'
    ],
    webapi: [
        'node_modules/angular2-in-memory-web-api/**/*.js'
    ],
    css: ['source/app/**/*.css'],
    content: 'source/content/**/*'
};

gulp.task('clean:app', function () {
    return del(['wwwroot/app/**/*.js']);
});

// gulp.task('clean:libs', function () {
//     return del(['wwwroot/libs/**/*']);
// });

// gulp.task('_build:libs', ['clean:libs'], function () {
//     // gulp.src(paths.libs).pipe(gulp.dest('wwwroot/libs/@angular'));
//     // // gulp.src(paths.material).pipe(gulp.dest('wwwroot/libs/@angular/material'))
//     // gulp.src(paths.rxjs).pipe(gulp.dest('wwwroot/libs/rxjs'));
//     // gulp.src(paths.webapi).pipe(gulp.dest('wwwroot/libs/angular-in-memory-web-api'));
//     // gulp.src(paths.content).pipe(gulp.dest('wwwroot/content'));
// });

gulp.task('_build:css', function () {
    del(['wwwroot/app/styles']);
    del(['wwwroot/app/components']);
    var processors = [
        autoprefixer({ browsers: ['last 1 version'] }),
        cssnano()
    ];
    return gulp.src(paths.css)
        .pipe(postcss(processors))
        .pipe(gulp.dest('wwwroot/app/'));
});

// // gulp.task('clean:css', function () {
// //     del(['wwwroot/app/styles']);
// //     return del(['wwwroot/app/components']);
// // });

// gulp.task('_build:app', ['_build:css'], function () {
//     gulp.src(paths.src).pipe(gulp.dest('wwwroot/app'));
//     var tsResult = tsProject.src()
//         .pipe(sourcemaps.init())
//         .pipe(tsProject());
//     return tsResult
//         .js
//         .pipe(sourcemaps.write('./'))
//         .pipe(gulp.dest('wwwroot/app'));
// });

// gulp.task('default', ['clean:app', '_build:app', '_build:css'], function () {
//    gulp.src(paths.src).pipe(gulp.dest('wwwroot/app'));
// });

var tsify = require('tsify');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var glob = require('glob');
var babelify = require('babelify');

gulp.task('html-copy', function () {
    return gulp.src(['source/app/**/*.html'])
        .pipe(gulp.dest('wwwroot/app'));
});

gulp.task('_default', ['clean:app'], function () { // , 'html-copy', '_build:css'], function () {
    gulp.src('source/configs/systemjs.config.js').pipe(gulp.dest('wwwroot/app'));
    // var bundles = glob.sync(paths.libs);
    browserify({
        basedir: '.',
        debug: true,
        entries: paths.libs
    })
        // .plugin(tsify)
        // .transform(babelify, { extensions: [ '.tsx', '.ts', '.d.ts', '.js', '.map.js' ] })
        .bundle()
        .pipe(source('vendor.js'))
        .pipe(gulp.dest('wwwroot/app'));
    return browserify({
        basedir: '.',
        debug: true,
        entries: ['source/app/main.ts']
    })
        .plugin(tsify)
        // .transform(babelify, { extensions: [ '.tsx', '.ts', '.d.ts', '.js', '.map.js' ] })
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(gulp.dest('wwwroot/app'));
});

gulp.task('clean:bundle', function () {
    return del(['wwwroot/app/bundle.js']);
});

gulp.task('default', ['clean:bundle'], function () {
    return browserify({
        basedir: '.',
        debug: true,
        entries: ['source/app/main.ts']
    })
        .plugin(tsify)
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(gulp.dest('wwwroot/app'));
});