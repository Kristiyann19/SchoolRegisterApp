import { APP_INITIALIZER, NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { LoginComponent } from "../login/components/main/login.component";
import { RegistrationComponent } from "../registration/components/registration.component";
import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { UserComponent } from "../user/components/user.component";
import { LoginService } from "../login/services/login.service";
import { NavComponent } from "./root/nav/nav.component";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { ToastrModule } from "ngx-toastr";
import { RouterModule } from "@angular/router";

export function appInitializer(loginService: LoginService) {
  return () => loginService.initializeUser();
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    UserComponent,
    NavComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    NgbModule,
    CommonModule,
    ToastrModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [LoginService],
    },
    LoginService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
