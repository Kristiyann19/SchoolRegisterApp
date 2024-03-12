import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "../login/components/login.component";
import { RegistrationComponent } from "../registration/components/registration.component";
import { AllUsersComponent } from "../user/components/all-users/all-users.component";
import { AllSchoolsComponent } from "../school/all-schools/components/all-schools.component";
import { AllPeopleComponent } from "../people/components/all-people/all-people.component";

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "registration", component: RegistrationComponent },
  { path: "all-users", component: AllUsersComponent },
  { path: "all-schools", component: AllSchoolsComponent },
  { path: "all-people", component: AllPeopleComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
