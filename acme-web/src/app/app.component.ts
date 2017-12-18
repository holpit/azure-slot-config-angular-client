import { Observable } from 'rxjs/observable';
import { Component } from '@angular/core';
import { ConfigService } from './config.service';
import { ConfigModel } from './config.model';
import { Subscription} from 'rxjs/Subscription';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent  {

  config: ConfigModel;

  constructor(private configService: ConfigService) {
    this.configService.load().subscribe(result => {
      console.log(result);
      this.config = result;
    });
  }

}
