import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { Item } from 'app/main/pages/interfaces/item';
import Swal from 'sweetalert2';
import { ArticleService } from '../article.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-article-update',
  templateUrl: './article-update.component.html',
  styleUrls: ['./article-update.component.scss']
})
export class ArticleUpdateComponent implements OnInit {

  
 Item : Item;
 public contentHeader: object;
 
 

  constructor(private router:Router,private articleService:ArticleService, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }


    ngOnInit(): void {
      
     this.articleService.loadItemById(this.activatedroute.snapshot.params.id).subscribe(data => this.Item= data)
     this.contentHeader = {
      headerTitle: 'Modifier Article',
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
                  name: 'Article',
                  isLink: true,
                  link: '/apps/article/list'
              },
              {
                  name: 'Update',
                  isLink: false
              }
          ]
      }
  };
    }

    onUpdate (item:NgForm){
      this.articleService.updateItem(item.value,this.Item.id).subscribe({
        next:() => {
          this.ConfirmTextOpen();
        this.router.navigate(["/apps/article/list"])
      },
    error:(error) => {
      console.log(error); 
    }}); }

    ConfirmTextOpen(){
      Swal.fire({
        title: 'Success!',
        text: "You have successfully updated this article!",
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
