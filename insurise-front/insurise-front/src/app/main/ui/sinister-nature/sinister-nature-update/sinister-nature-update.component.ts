import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from 'app/main/apps/branch/branch.service';
import { SinisterNatureService } from '../sinister-nature.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
@Component({
  selector: 'app-sinister-nature-update',
  templateUrl: './sinister-nature-update.component.html',
  styleUrls: ['./sinister-nature-update.component.scss']
})
export class SinisterNatureUpdateComponent implements OnInit {
  
  branchList:any
  id:any
  SinNature:any
  
  constructor(private router : Router ,private sinisterNatureService : SinisterNatureService ,private ar: ActivatedRoute
    ,private branchService:BranchService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.sinisterNatureService.getSinisterNatureById(this.id).subscribe((data)=>{
      this.SinNature=data
    })
    this.branchService.getBranches().subscribe((data)=>{
      this.branchList=data
    })
  }

  update(sinNat:NgForm){
    this.sinisterNatureService.updateSinisterNature(sinNat.value,this.id).subscribe( {next:()=>{
      this.router.navigate(['/ui/sinisterNature/list'])
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

}
