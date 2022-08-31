import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Proportion } from '../../interfaces/proportion';
import { ProportionService } from '../proportion.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';

@Component({
  selector: 'app-detail-proportion',
  templateUrl: './detail-proportion.component.html',
  styleUrls: ['./detail-proportion.component.scss']
})
export class DetailProportionComponent implements OnInit {
 proportion :Proportion
 public contentHeader: object;

  constructor(private router:Router,private proportionService:ProportionService,private activatedRoute:ActivatedRoute,private _coreTranslationService: CoreTranslationService) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.params.id;
    this.proportionService.loadProportionById(id).subscribe(data => { this.proportion= data})
    this.contentHeader = {
      headerTitle: 'Proportion',
      actionButton: false,
      breadcrumb: {
          type: '',
          links: [
              {
                  name: 'Home',
                  isLink: true,
                  link: '/'
              },
              {
                  name: 'Proportion',
                  isLink: true,
                  link: '/apps/proportion/list'
              },
              {
                  name: 'Detail',
                  isLink: false
              }
          ]
      }
  };
  }

}
