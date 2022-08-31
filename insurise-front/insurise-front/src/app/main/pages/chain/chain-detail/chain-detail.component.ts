import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ChainDto } from '../../interfaces/chain';
import { ChainService } from '../chain.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
@Component({
  selector: 'app-chain-detail',
  templateUrl: './chain-detail.component.html',
  styleUrls: ['./chain-detail.component.scss']
})
export class ChainDetailComponent implements OnInit {

  chain : ChainDto;
 public contentHeader: object;


  constructor(private chainService:ChainService,private activatedroute :ActivatedRoute,router:Router,private _coreTranslationService: CoreTranslationService) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    const id = this.activatedroute.snapshot.params.id;
    this.chainService.loadChainById(id).subscribe(data => {  this.chain= data; console.log(data)})
 
    this.contentHeader = {
      headerTitle: ' Chain',
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
                  name: 'Chain',
                  isLink: true,
                  link: '/apps/chain/list'
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
