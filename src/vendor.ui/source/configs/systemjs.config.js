// /**
//  * System configuration for Angular 2 samples
//  * Adjust as necessary for your application needs.
//  */
// (function (global) {
//     System.config({
//         paths: {
//             // paths serve as alias
//             'npm:': 'libs/'
//             //'npm:': '../../node_modules/'
//         },
//         // map tells the System loader where to look for things
//         map: {
//             // our app is within the app folder
//             app: 'app',
//             //app: '../app',

//             // angular bundles
//             '@angular/core': 'npm:@angular/core.umd.js',
//             '@angular/common': 'npm:@angular/common.umd.js',
//             '@angular/compiler': 'npm:@angular/compiler.umd.js',
//             '@angular/platform-browser': 'npm:@angular/platform-browser.umd.js',
//             '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic.umd.js',
//             '@angular/http': 'npm:@angular/http.umd.js',
//             '@angular/router': 'npm:@angular/router.umd.js',
//             '@angular/forms': 'npm:@angular/forms.umd.js',
//             '@angular/material': 'npm:@angular/material.umd.js',

// //               '@angular/material/core': 'npm:@angular2-material/core/core.umd.js',
// //   '@angular/material/card': 'npm:@angular2-material/card/card.umd.js',
// //   '@angular/material/button': 'npm:@angular2-material/button/button.umd.js',
// //   '@angular/material/icon': 'npm:@angular2-material/icon/icon.umd.js',

//             //'@angular/core': 'npm:@angular/core/bundles/core.umd.js',
//             //'@angular/common': 'npm:@angular/common/bundles/common.umd.js',
//             //'@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
//             //'@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
//             //'@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
//             //'@angular/http': 'npm:@angular/http/bundles/http.umd.js',
//             //'@angular/router': 'npm:@angular/router/bundles/router.umd.js',
//             //'@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',

//             // other libraries
//             // 'material': 'npm:material',
//             'rxjs': 'npm:rxjs',
//             'angular-in-memory-web-api': 'npm:angular-in-memory-web-api',
//         },
//         // packages tells the System loader how to load when no filename and/or no extension
//         packages: {
//             app: {
//                 main: './main.js',
//                 defaultExtension: 'js'
//             },
//             // material:{
//             //     defaultExtension: 'js'
//             // },
//             rxjs: {
//                 defaultExtension: 'js'
//             },
//             'angular2-in-memory-web-api': {
//                 main: './index.js',
//                 defaultExtension: 'js'
//             }
//         }
//     });
// })(this);

/**
 * WEB ANGULAR VERSION
 * (based on systemjs.config.js in angular.io)
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
; (function (global) {
  System.config({
    // DEMO ONLY! REAL CODE SHOULD NOT TRANSPILE IN THE BROWSER
    // transpiler: 'ts',
    // typescriptOptions: {
    //   // Copy of compiler options in standard tsconfig.json
    //   'target': 'es5',
    //   'module': 'commonjs',
    //   'moduleResolution': 'node',
    //   'sourceMap': true,
    //   'emitDecoratorMetadata': true,
    //   'experimentalDecorators': true,
    //   'noImplicitAny': true,
    //   'suppressImplicitAnyIndexErrors': true
    // },
    // // bundles:{

    // // }
    // meta: {
    //   'typescript': {
    //     'exports': 'ts'
    //   }
    // },
    meta: {
      'app/bundle.js': {
        format: 'global'
      }
    },
    paths: {
      // paths serve as alias
      'npm:': 'https://unpkg.com/'
    },
    // map tells the System loader where to look for things
    map: {
      // our app is within the app folder
      app: 'app',

      // angular bundles
      // '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
      // '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
      // '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
      // '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
      // '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
      // '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
      // '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
      // '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
      // '@angular/upgrade': 'npm:@angular/upgrade/bundles/upgrade.umd.js',
      // '@angular/upgrade/static': 'npm:@angular/upgrade/bundles/upgrade-static.umd.js',
      // '@angular/material': 'npm:@angular/material/material.umd.js',

      '@angular/core': 'app/vendor.js',
      '@angular/common': 'app/vendor.js',
      '@angular/compiler': 'app/vendor.js',
      '@angular/platform-browser': 'app/vendor.js',
      '@angular/platform-browser-dynamic': 'app/vendor.js',
      '@angular/http': 'app/vendor.js',
      '@angular/router': 'app/vendor.js',
      '@angular/forms': 'app/vendor.js',
      '@angular/upgrade': 'app/vendor.js',
      '@angular/upgrade/static': 'app/vendor.js',
      '@angular/material': 'app/vendor.js',
      'angular-in-memory-web-api': 'app/vendor.js',
      // other libraries
      'rxjs': 'npm:rxjs'
      // 'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.js'// ,
      // // 'ts':                        'npm:plugin-typescript@4.0.10/lib/plugin.js',
      // // 'typescript':                'npm:typescript@2.0.3/lib/typescript.js',

    },
    // packages tells the System loader how to load when no filename and/or no extension
    packages: {
      app: {
        main: './bundle.js',
        defaultExtension: 'js'
      },
      rxjs: {
        defaultExtension: 'js'
      }
    }
  });

  if (false) { bootstrap(); }

  // Bootstrap with a default `AppModule`
  // ignore an `app/app.module.ts` and `app/main.ts`, even if present
  // This function exists primarily (exclusively?) for the QuickStart
  function bootstrap() {
    console.log('Auto-bootstrapping');

    // Stub out `app/main.ts` so System.import('app') doesn't fail if called in the index.html
    System.set(System.normalizeSync('app/main.ts'), System.newModule({ }));

    // bootstrap and launch the app (equivalent to standard main.ts)
    Promise.all([
      System.import('@angular/platform-browser-dynamic'),
      getAppModule()
    ])
    .then(function (imports) {
      var platform = imports[0];
      var app      = imports[1];
      platform.platformBrowserDynamic().bootstrapModule(app.AppModule);
    })
    .catch(function(err){ console.error(err); });
  }

  // Make the default AppModule
  // returns a promise for the AppModule
  function getAppModule() {
    console.log('Making a bare-bones, default AppModule');

    return Promise.all([
      System.import('@angular/core'),
      System.import('@angular/platform-browser'),
      System.import('app/components/app.component')
    ])
    .then(function (imports) {

      var core    = imports[0];
      var browser = imports[1];
      var appComp = imports[2].AppComponent;

      var AppModule = function() {};

      AppModule.annotations = [
        new core.NgModule({
          imports:      [ browser.BrowserModule ],
          declarations: [ appComp ],
          bootstrap:    [ appComp ]
        })
      ];
      return {AppModule: AppModule};
    });
  }
})(this);

/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
