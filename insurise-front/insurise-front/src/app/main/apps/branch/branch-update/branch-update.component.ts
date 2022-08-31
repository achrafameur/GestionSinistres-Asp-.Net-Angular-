import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { BranchService } from '../branch.service';

@Component({
  selector: 'app-branch-update',
  templateUrl: './branch-update.component.html',
  styleUrls: ['./branch-update.component.scss']
})
export class BranchUpdateComponent implements OnInit {
  parentBranches:any
  BRANCH:any
  id:any
  public contentHeader : object ; 
  
  constructor(private router : Router ,private branchService : BranchService,private ar : ActivatedRoute) { }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.branchService.getBranchById(this.id).subscribe(data=>this.BRANCH=data)

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
                  name: 'update',
                  isLink: false
              }
          ]
      }
  };
  }

  update(branch:NgForm){
    this.branchService.updateBranch(branch.value,this.id).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/branch/list'])
    });
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this branch!",
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
