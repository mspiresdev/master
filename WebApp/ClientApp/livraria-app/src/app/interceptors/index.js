"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
//import { NotifyInterceptor } from './notify.interptor';
//import { HttpsInterceptor } from './https.interceptor';
//import { ProfilerInterceptor } from './profiler.interceptor';
//import { AuthInterceptor } from './auth.interceptor';
//import { CacheInterceptor } from './cache.interceptor';
//import { HeaderInterceptor } from './header.interceptor';
var error_interceptor_1 = require("./error.interceptor");
//import { FakeInterceptor } from './fake.interceptor';
//import { LoaderInterceptor } from './loader.interceptor';
//import { ConvertInterceptor } from './convert.interceptor';
exports.httpInterceptorProviders = [
    //{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: ConvertInterceptor, multi: true },
    { provide: http_1.HTTP_INTERCEPTORS, useClass: error_interceptor_1.ErrorInterceptor, multi: true },
];
//# sourceMappingURL=index.js.map