import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { CommissionService } from '../commission.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-commission-update',
  templateUrl: './commission-update.component.html',
  styleUrls: ['./commission-update.component.scss']
})
export class CommissionUpdateComponent implements OnInit {

  Commission : ICommission;
  public contentHeader: object;


  constructor(private router : Router, private commissionService:CommissionService, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
     this.commissionService.loadCommissionById(this.activatedroute.snapshot.params.id).subscribe(data => this.Commission= data)
     this.contentHeader = {
      headerTitle: 'Commission',
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
                  name: 'Update',
                  isLink: false
              }
          ]
      }
  };
  }
  onUpdate (commission:NgForm){
    this.commissionService.updateCommission(commission.value,this.Commission.commissionId).subscribe({
      next:() => {
      this.router.navigate(["/apps/commission/list"])
    },
  error:(error) => {
    console.log(error); 
  }}); }

}
