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

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "registration", component: RegistrationComponent },
  { path: "all-users", component: AllUsersComponent },
  { path: "all-schools", component: AllSchoolsComponent },
  { path: "all-people", component: AllPeopleComponent },
  { path: "person/:id", component: DetailsPersonComponent },
  { path: "add-person", component: AddPersonComponent },
  { path: "person-history/:id", component: PersonHistoryComponent },
  { path: "person-school/:id", component: PersonSchoolComponent },
  { path: "add-school", component: AddSchoolComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
