import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public positions: PositionLevelRisk[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PositionLevelRisk[]>(baseUrl + 'api/Data/GetPositions').subscribe(result => {
      this.positions = result;
    }, error => console.error(error));
  }
}

interface PositionLevelRisk {
  positionId: number;
  symbol: string;
  quantity: number;
  spot: string;
  position: string;
  delta: string;
}
