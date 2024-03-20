import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = "Възникна грешка";
        if (error.error instanceof ErrorEvent) {
          // Client-side error
          errorMessage = `Възникна грешка: ${error.error.message}`;
        } else {
          // Server-side error
          errorMessage = error.error.message || errorMessage;
        }
        this.toastr.error(errorMessage, null, { timeOut: 5000 });
        return throwError(() => error);
      })
    );
  }
}
