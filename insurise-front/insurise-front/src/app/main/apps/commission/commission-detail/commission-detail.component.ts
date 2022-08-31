import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { CommissionService } from '../commission.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-commission-detail',
  templateUrl: './commission-detail.component.html',
  styleUrls: ['./commission-detail.component.scss']
})
export class CommissionDetailComponent implements OnInit {

  commission : ICommission;
router : Router;
public contentHeader: object;
  constructor(private commissionService:CommissionService, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    const id = this.activatedroute.snapshot.params.id;
    this.commissionService.loadCommissionById(id).subscribe(data => { this.commission= data})
    this.contentHeader = {
      headerTitle: ' Commission',
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
                  name: 'Commission',
                  isLink: true,
                  link: '/apps/commission/list'
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
