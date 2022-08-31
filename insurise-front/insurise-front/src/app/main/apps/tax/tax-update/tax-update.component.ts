import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { TaxService } from '../tax.service';

@Component({
  selector: 'app-tax-update',
  templateUrl: './tax-update.component.html',
  styleUrls: ['./tax-update.component.scss']
})
export class TaxUpdateComponent implements OnInit {
  Tax:any
  id:any
  public contentHeader : object ;
  constructor(private router:Router,private TaxService:TaxService,private ar : ActivatedRoute) { }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.TaxService.getTaxById(this.id).subscribe((data)=>{this.Tax=data})
    this.contentHeader = {
      headerTitle: 'Tax',
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
                  name: 'Tax',
                  isLink: true,
                  link: '/apps/tax/list'
              },
              {
                  name: 'update',
                  isLink: false
              }
          ]
      }
  };
  }

  update(tax:NgForm){
    this.TaxService.updateTax(tax.value,this.id).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/tax/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this tax!",
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
