import { Component, Inject, } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public positions: Position[];
  private connectionIsEstablished = false;
  private _serviceUrl = 'http://localhost:52915/';
  private _hubConnection: HubConnection;
  public columns: any[];

  constructor(http: HttpClient) {
    this.columns = [
      { field: 'id', header: 'PositionId' },
      { field: 'sbl', header: 'Symbol' },
      { field: 'q', header: 'Quantity' },
      { field: 'spt', header: 'Spot' },
      { field: 'pos', header: 'Position' },
      { field: 'dlt', header: 'Delta' }
    ];

    http.get<Position[]>(this._serviceUrl + 'api/position').subscribe(result => {
      this.positions = result;
    }, error => console.error(error));
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(this._serviceUrl + 'update',
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
    this._hubConnection.on('position', (data: any) => {
      var updatedPositions = data as Position[];
      updatedPositions.forEach(updatedPosition => {
        var position = this.positions.find(p => p.id === updatedPosition.id);
        position.spt = updatedPosition.spt;
        position.pos = updatedPosition.pos;
        position.dlt = updatedPosition.dlt;
      });
    });
  }
}


interface Position {
  id: number;
  sbl: string;
  q: number;
  spt: string;
  pos: string;
  dlt: string;
}
