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
import { LoginComponent } from "../login/components/login.component";
import { RegistrationComponent } from "../registration/components/registration.component";
import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { LoginService } from "../login/services/login.service";
import { NavComponent } from "./root/nav/nav.component";
import { RegistrationService } from "../registration/services/registration.service";
import { UserService } from "../user/services/user.service";
import { AllSchoolsComponent } from "../school/all-schools/components/all-schools.component";
import { AllPeopleComponent } from "../people/components/all-people/all-people.component";
import { DetailsPersonComponent } from "../people/components/details-person/details-person.component";
import { AddPersonComponent } from "../people/components/add-person/add-person.component";
import { SettlementService } from "../settlement/services/settlement.service";
import { PersonHistoryComponent } from "../person-history/components/person-history.component";
import { PersonSchoolComponent } from "../person-school/components/person-school.component";
import { AllUsersComponent } from "../user/components/all-users/all-users.component";
import { PersonSchoolAddModalComponent } from "../person-school/modals/person-school-add-modal/person-school-add-modal.component";
import { AddSchoolComponent } from "../school/add-school/components/add-school.component";
import { ReportComponent } from "../report/components/report.component";
import { ErrorInterceptor } from "./interceptors/error.interceptor";

export function appInitializer(userService: UserService) {
  return () => userService.initializeUser();
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    AllUsersComponent,
    NavComponent,
    AllSchoolsComponent,
    AllPeopleComponent,
    DetailsPersonComponent,
    AddPersonComponent,
    PersonHistoryComponent,
    PersonSchoolComponent,
    PersonSchoolAddModalComponent,
    AddSchoolComponent,
    ReportComponent,
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
      multi: true,
    },
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [UserService],
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
    LoginService,
    RegistrationService,
    UserService,
    SettlementService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
