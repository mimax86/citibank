import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public positions: PositionLevelRisk[];
  private connectionIsEstablished = false;
  private _baseUrl: string;
  private _hubConnection: HubConnection;  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    http.get<PositionLevelRisk[]>(baseUrl + 'api/Data/GetPositions').subscribe(result => {
      this.positions = result;
    }, error => console.error(error));
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection(); 
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(this._baseUrl + 'hub/update',
        {
          skipNegotiation: true, 
          transport: HttpTransportType.WebSockets
        })
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(() => this.startConnection(), 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('ALL', (data: any) => {
      var updatedPositions = data as PositionLevelRisk[];
      updatedPositions.forEach(updatedPosition => {
        var position = this.positions.find(p => p.positionId === updatedPosition.positionId);
        position.spot = updatedPosition.spot;
        position.position = updatedPosition.position;
        position.delta = updatedPosition.delta;
      });
    });
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
