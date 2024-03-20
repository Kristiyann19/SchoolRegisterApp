import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "../login/components/login.component";
import { RegistrationComponent } from "../registration/components/registration.component";
import { AllUsersComponent } from "../user/components/all-users/all-users.component";
import { AllSchoolsComponent } from "../school/all-schools/components/all-schools.component";
import { AllPeopleComponent } from "../people/components/all-people/all-people.component";

import { DetailsPersonComponent } from "../people/components/details-person/details-person.component";

import { AddPersonComponent } from "../people/components/add-person/add-person.component";
import { PersonHistoryComponent } from "../person-history/components/person-history.component";
import { PersonSchoolComponent } from "../person-school/components/person-school.component";
import { AddSchoolComponent } from "../school/add-school/components/add-school.component";
import { AuthGuard } from "./guards/auth.guard";
import { ReportComponent } from "../report/components/report.component";
import { AdminGuard } from "./guards/admin.guard";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "registration", component: RegistrationComponent },
  { path: "all-users", component: AllUsersComponent, canActivate: [AuthGuard] },
  {
    path: "all-schools",
    component: AllSchoolsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "all-people",
    component: AllPeopleComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "person/:id",
    component: DetailsPersonComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "add-person",
    component: AddPersonComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  {
    path: "person-history/:id",
    component: PersonHistoryComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "person-school/:id",
    component: PersonSchoolComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "add-school",
    component: AddSchoolComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
  { path: "report", component: ReportComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
