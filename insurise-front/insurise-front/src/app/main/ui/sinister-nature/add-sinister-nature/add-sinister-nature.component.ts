import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BranchService } from 'app/main/apps/branch/branch.service';
import { SinisterNatureService } from '../sinister-nature.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';

@Component({
  selector: 'app-add-sinister-nature',
  templateUrl: './add-sinister-nature.component.html',
  styleUrls: ['./add-sinister-nature.component.scss']
})
export class AddSinisterNatureComponent implements OnInit {

  branchList:any
  constructor(private router:Router,private branchService:BranchService,private sinisterNatureService:SinisterNatureService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.branchService.getBranches().subscribe((data)=>{
      this.branchList=data
    })
  }

  add(sinNat:NgForm){
    if(sinNat.value.idaEnabled==""){
      sinNat.value.idaEnabled =false;
    }
    if(sinNat.value.transactionEnabled==""){
      sinNat.value.transactionEnabled =false;
    }
    if(sinNat.value.thirdPartyEnabled==""){
      sinNat.value.thirdPartyEnabled =false;
    }
    if(sinNat.value.victimEnabled==""){
      sinNat.value.victimEnabled =false;
    }
    if(sinNat.value.respEnabled==""){
      sinNat.value.respEnabled =false;
    }
    if(sinNat.value.respAutoEnabled==""){
      sinNat.value.respAutoEnabled =false;
    }
    if(sinNat.value.affaireEnabled==""){
      sinNat.value.affaireEnabled =false;
    }
    if(sinNat.value.expertiseEnabled==""){
      sinNat.value.expertiseEnabled =false;
    }
    if(sinNat.value.evalInterneEnabled==""){
      sinNat.value.evalInterneEnabled =false;
    }
    if(sinNat.value.evalInterneCorpEnabled==""){
      sinNat.value.evalInterneCorpEnabled =false;
    }
    if(sinNat.value.regExpertEnabled==""){
      sinNat.value.regExpertEnabled =false;
    }
    this.sinisterNatureService.addSinisterNature(sinNat.value).subscribe(()=>{
      this.router.navigate(['ui/sinisterNature/list'])
    })
  }

}
