import { APP_INITIALIZER, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FormsModule } from "@angular/forms";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { ToastrModule } from "ngx-toastr";
import { LoginComponent } from "../login/components/main/login.component";
import { RegistrationComponent } from "../registration/components/registration.component";
import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { UserComponent } from "../user/components/user.component";
import { LoginService } from "../login/services/login.service";
import { NavComponent } from "./root/nav/nav.component";
import { RegistrationService } from "../registration/services/registration.service";
import { UserService } from "../user/services/user.service";

export function appInitializer(userService: UserService) {
  return () => userService.initializeUser();
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
    NgbModule,
    CommonModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: AuthInterceptor, 
      multi: true 
    },
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [UserService],
    },
    LoginService,
    RegistrationService,
    UserService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
