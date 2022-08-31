import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChainElementService } from '../chain-element.service';
import { locale as English  } from '../../chain/i18n/en';
import { locale as Francais } from '../../chain/i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { ChainElement } from '../../interfaces/chainElement';

@Component({
  selector: 'app-element-detail',
  templateUrl: './element-detail.component.html',
  styleUrls: ['./element-detail.component.scss']
})
export class ElementDetailComponent implements OnInit {
  element:ChainElement
  
  public contentHeader: object;
  constructor(private chainElementService:ChainElementService, private router: Router, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
    const id = this.activatedroute.snapshot.params.id;
    this.chainElementService.loadChainElementById(id).subscribe(data => { this.element= data; console.log(data)})
    this.contentHeader = {
      headerTitle: 'Detail Element',
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
                  name: 'Element',
                  isLink: true,
                  link: '/apps/chain-element/list'
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
