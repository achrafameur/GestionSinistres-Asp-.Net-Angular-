import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BranchService } from '../branch.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import {locale as german} from "../i18n/de";
import {locale as portuguese} from "../i18n/pt";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-branch-add',
  templateUrl: './branch-add.component.html',
  styleUrls: ['./branch-add.component.scss']
})
export class BranchAddComponent implements OnInit {

  parentBranches:any
  public contentHeader : object ; 
  
  constructor(private router : Router , private branchService : BranchService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french, german, portuguese);
  }

  addBranchForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    description:new FormControl( '' , [Validators.required] ),
    parentId:new FormControl()
  })

  ngOnInit(): void {
    this.branchService.getBranches().subscribe((data)=>{
      this.parentBranches=data
    })
    this.contentHeader = {
      headerTitle: 'Branch',
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
                  name: 'Branch',
                  isLink: true,
                  link: '/apps/branch/list'
              },
              {
                  name: 'add',
                  isLink: false
              }
          ]
      }
  };
  }

  add(){
    this.branchService.addBranch(this.addBranchForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/branch/list']);
    });
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new branch!",
      icon: 'success',
      confirmButtonColor: '#7367F0',
      cancelButtonColor: '#E42728',
      // confirmButtonText: 'Ok',
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger ml-1'
      }
    }).then((result) =>{
      if (result) {
        // this.add();
      }
    });
  }
}
