import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Nature } from '../../interfaces/nature';
import { NatureService } from '../nature.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
@Component({
  selector: 'app-nature-detail',
  templateUrl: './nature-detail.component.html',
  styleUrls: ['./nature-detail.component.scss']
})
export class NatureDetailComponent implements OnInit {
nature : Nature;
router : Router;
public contentHeader: object;
  constructor(private natureService:NatureService, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    const id = this.activatedroute.snapshot.params.id;
    this.natureService.loadNatureById(id).subscribe(data => { this.nature= data})
    this.contentHeader = {
      headerTitle: ' Nature',
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
                  name: 'Nature',
                  isLink: true,
                  link: '/apps/nature/list'
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
