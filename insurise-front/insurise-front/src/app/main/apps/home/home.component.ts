import { Component, OnInit } from '@angular/core';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
  }

}
