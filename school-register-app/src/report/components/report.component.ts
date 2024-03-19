import { Component } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { ReportService } from "../service/report.service";
import { ReportDto } from "../dtos/report.dto";
import { PositionEnumLocalization } from "../../enums/position.enum";

@Component({
  selector: "app-report",
  templateUrl: "./report.component.html",
  styleUrl: "./report.component.css",
})
export class ReportComponent {

  report: ReportDto = new ReportDto
  reports: ReportDto[] = [];
  positionEnumLocalization = PositionEnumLocalization
  constructor(public reportService: ReportService) {}

  ngOnInit(){
    this.loadReport(this.report);
  }

  loadReport(report: ReportDto) {
    this.reportService.getReport(report)
    .pipe(
      catchError((err) => {
        return throwError(() => err);
      })
    ).subscribe((res) => {
      this.reports = res;
    })
  }

}
