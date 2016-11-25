/// <binding AfterBuild='default' Clean='clean' />
/// <reference path="./wwwroot/app/systemjs.config.js" />

var gulp = require("gulp");
var del = require("del");
var postcss = require("gulp-postcss");
var autoprefixer = require("autoprefixer");
var cssnano = require("cssnano");
var ts = require("gulp-typescript");
var sourcemaps = require("gulp-sourcemaps");


var tsProject = ts.createProject("tsconfig.json");
var paths = {
    src: ["source/configs/systemjs.config.js", "source/app/**/*.html"], //"source/app/**/*.ts", "source/app/**/*.js", "source/app/**/*.js.map", 
    libs: [
        "node_modules/@angular/core/bundles/core.umd.js",
        "node_modules/@angular/common/bundles/common.umd.js",
        "node_modules/@angular/compiler/bundles/compiler.umd.js",
        "node_modules/@angular/platform-browser/bundles/platform-browser.umd.js",
        "node_modules/@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js",
        "node_modules/@angular/http/bundles/http.umd.js",
        "node_modules/@angular/router/bundles/router.umd.js",
        "node_modules/@angular/forms/bundles/forms.umd.js"

        //"node_modules/reflect-metadata/Reflect.js",
        //"node_modules/zone.js/dist/zone.js",
        //"node_modules/core-js/client/shim.min.js"
    ],
    rxjs: [
        "node_modules/rxjs/**/*.js"
    ],
    webapi: [
        "node_modules/angular2-in-memory-web-api/**/*.js"
    ],
    css: ["source/app/**/*.css"]
};

gulp.task("clean:app", function () {
    return del(["wwwroot/app/**/*"]);
});

gulp.task("clean:libs", function () {
    return del(["wwwroot/libs/**/*"]);
});

gulp.task("_build:libs", function () {
    gulp.src(paths.libs).pipe(gulp.dest("wwwroot/libs/@angular"));
    gulp.src(paths.rxjs).pipe(gulp.dest("wwwroot/libs/rxjs"));
    gulp.src(paths.webapi).pipe(gulp.dest("wwwroot/libs/angular2-in-memory-web-api"));
});

gulp.task("_build:css", function () {
    var processors = [
        autoprefixer({ browsers: ["last 1 version"] }),
        cssnano()
    ];
    return gulp.src(paths.css)
        .pipe(postcss(processors))
        .pipe(gulp.dest("wwwroot/app/"));
});

gulp.task("_build:app", ["_build:css"], function () {
    gulp.src(paths.src).pipe(gulp.dest("wwwroot/app"));
    var tsResult = tsProject.src()
        .pipe(sourcemaps.init())
        .pipe(tsProject());
    return tsResult
        .js
        .pipe(sourcemaps.write("./"))
        .pipe(gulp.dest("wwwroot/app"));
});

gulp.task("default", ["clean:app","_build:app", "_build:css", "_build:libs"], function () {
   gulp.src(paths.src).pipe(gulp.dest("wwwroot/app"));
});