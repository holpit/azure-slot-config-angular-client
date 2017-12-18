import { ConfigModel } from './config.model';
import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs/observable';
import 'rxjs/add/operator/map';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { environment } from '../environments/environment';

@Injectable()
export class ConfigService {


  constructor(private http: HttpClient) { }

  public load = (): Observable<ConfigModel> => {

    // We are simply wrapping this in our own observer so we can intercept
    // any failed calls to our slot api (likely local dev) and instead
    // return our environment configuraiton
    return Observable.create(observer => {

      this.loadSlotConfiguration().subscribe(
        configData => {
          // Current SLot Configuration
          observer.next(configData);
        },
        (err: HttpErrorResponse) => {
          // Houston we have a problem - no configuration
          // allback to our environment
          if (err.ok === false) {
            const config = new ConfigModel();
            config.environment = environment.environmentName;
            config.version = environment.version;
            observer.next(config);
          }
        }
      );

    });

  }

 private loadSlotConfiguration = (): Observable<ConfigModel> => {
    return this.http.get<ConfigModel>('/api/config').map(data => {
      return data;
    });
  }

}
